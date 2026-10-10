using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class MantenimientoDatos
    {
        private const string SqlBase =
            @"SELECT IdMantenimiento, IdEquipo, NumeroSerie, Marca, Modelo, Ubicacion,
                     IdContrato, IdCliente, Cliente, IdIngeniero, Ingeniero,
                     Tipo, FechaProgramada, FechaRealizada, Estado,
                     Diagnostico, TrabajoRealizado, Observaciones, CostoRepuestos
              FROM VistaMantenimientos";

        // con 0 en idCliente o en idIngeniero no se filtra por ese dato
        public static Mantenimiento[] Listar(int idCliente, int idIngeniero)
        {
            try
            {
                string sql = SqlBase + @" WHERE (@IdCliente = 0 OR IdCliente = @IdCliente)
                                            AND (@IdIngeniero = 0 OR IdIngeniero = @IdIngeniero)
                                          ORDER BY FechaProgramada DESC, IdMantenimiento DESC";

                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdCliente", idCliente);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdIngeniero", idIngeniero);
                adaptador.Fill(tabla);
                Mantenimiento[] lista = new Mantenimiento[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static Mantenimiento Buscar(int idMantenimiento)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " WHERE IdMantenimiento = @Id", Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@Id", idMantenimiento);
                adaptador.Fill(tabla);

                if (tabla.Rows.Count > 0) return LeerFila(tabla.Rows[0]);
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Insertar(Mantenimiento m)
        {
            try
            {
                string sql = @"INSERT INTO Mantenimientos
                                   (IdEquipo, IdIngeniero, Tipo, FechaProgramada, Estado, Observaciones)
                               VALUES
                                   (@IdEquipo, @IdIngeniero, @Tipo, @Programada, @Estado, @Observaciones);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, m);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        // solo cambia los datos de la programación, la hoja se guarda aparte
        public static int Actualizar(Mantenimiento m)
        {
            try
            {
                string sql = @"UPDATE Mantenimientos
                               SET IdEquipo = @IdEquipo, IdIngeniero = @IdIngeniero, Tipo = @Tipo,
                                   FechaProgramada = @Programada, Estado = @Estado,
                                   Observaciones = @Observaciones
                               WHERE IdMantenimiento = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, m);
                    cmd.Parameters.AddWithValue("@Id", m.IdMantenimiento);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Mantenimiento m)
        {
            cmd.Parameters.AddWithValue("@IdEquipo",      m.IdEquipo);
            cmd.Parameters.AddWithValue("@IdIngeniero",   m.IdIngeniero);
            cmd.Parameters.AddWithValue("@Tipo",          m.Tipo);
            cmd.Parameters.AddWithValue("@Programada",    m.FechaProgramada.Date);
            cmd.Parameters.AddWithValue("@Estado",        m.Estado);
            cmd.Parameters.AddWithValue("@Observaciones", Nulos.Guardar(m.Observaciones));
        }

        // al eliminar la visita se devuelven los repuestos al inventario
        public static void Eliminar(int idMantenimiento)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        DevolverRepuestos(con, transaccion, idMantenimiento);

                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM Mantenimientos WHERE IdMantenimiento = @Id", con, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Id", idMantenimiento);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static RepuestoUsado[] RepuestosUsados(int idMantenimiento)
        {
            try
            {
                string sql = @"SELECT IdDetalle, IdMantenimiento, IdRepuesto, Repuesto, Cantidad, PrecioUnitario
                               FROM VistaRepuestosUsados
                               WHERE IdMantenimiento = @Id
                               ORDER BY Repuesto";

                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@Id", idMantenimiento);
                adaptador.Fill(tabla);
                RepuestoUsado[] lista = new RepuestoUsado[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow fila = tabla.Rows[i];
                    RepuestoUsado usado = new RepuestoUsado();
                    usado.IdDetalle = Convert.ToInt32(fila["IdDetalle"]);
                    usado.IdMantenimiento = Convert.ToInt32(fila["IdMantenimiento"]);
                    usado.IdRepuesto = Convert.ToInt32(fila["IdRepuesto"]);
                    usado.Repuesto = fila["Repuesto"].ToString();
                    usado.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                    usado.PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]);
                    lista[i] = usado;
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        // guarda la hoja de servicio con sus repuestos
        // se usa una transacción para que si algo falla no se guarde nada
        public static void GuardarHoja(Mantenimiento m, RepuestoUsado[] usados)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        // primero se regresa lo que ya tenía la hoja
                        DevolverRepuestos(con, transaccion, m.IdMantenimiento);

                        // y después se descuenta lo nuevo
                        foreach (RepuestoUsado usado in usados)
                            Consumir(con, transaccion, m.IdMantenimiento, usado);

                        string sql = @"UPDATE Mantenimientos
                                       SET FechaRealizada = @Realizada, Estado = @Estado,
                                           Diagnostico = @Diagnostico, TrabajoRealizado = @Trabajo,
                                           Observaciones = @Observaciones
                                       WHERE IdMantenimiento = @Id";

                        using (SqlCommand cmd = new SqlCommand(sql, con, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Realizada",     Nulos.GuardarFecha(m.FechaRealizada));
                            cmd.Parameters.AddWithValue("@Estado",        m.Estado);
                            cmd.Parameters.AddWithValue("@Diagnostico",   Nulos.Guardar(m.Diagnostico));
                            cmd.Parameters.AddWithValue("@Trabajo",       Nulos.Guardar(m.TrabajoRealizado));
                            cmd.Parameters.AddWithValue("@Observaciones", Nulos.Guardar(m.Observaciones));
                            cmd.Parameters.AddWithValue("@Id",            m.IdMantenimiento);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void DevolverRepuestos(SqlConnection con, SqlTransaction transaccion, int idMantenimiento)
        {
            string devolver = @"UPDATE Repuestos
                                SET Existencia = Repuestos.Existencia + MantenimientoRepuestos.Cantidad
                                FROM Repuestos
                                INNER JOIN MantenimientoRepuestos
                                        ON MantenimientoRepuestos.IdRepuesto = Repuestos.IdRepuesto
                                WHERE MantenimientoRepuestos.IdMantenimiento = @Id";

            using (SqlCommand cmd = new SqlCommand(devolver, con, transaccion))
            {
                cmd.Parameters.AddWithValue("@Id", idMantenimiento);
                cmd.ExecuteNonQuery();
            }

            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM MantenimientoRepuestos WHERE IdMantenimiento = @Id", con, transaccion))
            {
                cmd.Parameters.AddWithValue("@Id", idMantenimiento);
                cmd.ExecuteNonQuery();
            }
        }

        private static void Consumir(SqlConnection con, SqlTransaction transaccion, int idMantenimiento, RepuestoUsado usado)
        {
            // solo descuenta si hay suficiente existencia
            int descontados;
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Repuestos SET Existencia = Existencia - @Cantidad
                  WHERE IdRepuesto = @IdRepuesto AND Existencia >= @Cantidad", con, transaccion))
            {
                cmd.Parameters.AddWithValue("@Cantidad", usado.Cantidad);
                cmd.Parameters.AddWithValue("@IdRepuesto", usado.IdRepuesto);
                descontados = cmd.ExecuteNonQuery();
            }

            if (descontados == 0)
                throw new Exception(Errores.Regla(
                    "No hay existencia suficiente de \"" + usado.Repuesto + "\" para consumir " + usado.Cantidad + "."));

            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO MantenimientoRepuestos (IdMantenimiento, IdRepuesto, Cantidad, PrecioUnitario)
                  VALUES (@Id, @IdRepuesto, @Cantidad, @Precio)", con, transaccion))
            {
                cmd.Parameters.AddWithValue("@Id", idMantenimiento);
                cmd.Parameters.AddWithValue("@IdRepuesto", usado.IdRepuesto);
                cmd.Parameters.AddWithValue("@Cantidad", usado.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", usado.PrecioUnitario);
                cmd.ExecuteNonQuery();
            }
        }

        private static Mantenimiento LeerFila(DataRow fila)
        {
            Mantenimiento m = new Mantenimiento();
            m.IdMantenimiento = Convert.ToInt32(fila["IdMantenimiento"]);
            m.IdEquipo = Convert.ToInt32(fila["IdEquipo"]);
            m.NumeroSerie = fila["NumeroSerie"].ToString();
            m.Marca = fila["Marca"].ToString();
            m.Modelo = fila["Modelo"].ToString();
            m.Ubicacion = fila["Ubicacion"].ToString();
            m.IdContrato = Convert.ToInt32(fila["IdContrato"]);
            m.IdCliente = Convert.ToInt32(fila["IdCliente"]);
            m.Cliente = fila["Cliente"].ToString();
            m.IdIngeniero = Convert.ToInt32(fila["IdIngeniero"]);
            m.Ingeniero = fila["Ingeniero"].ToString();
            m.Tipo = fila["Tipo"].ToString();
            m.FechaProgramada = Convert.ToDateTime(fila["FechaProgramada"]);
            if (fila["FechaRealizada"] != DBNull.Value) m.FechaRealizada = Convert.ToDateTime(fila["FechaRealizada"]);
            m.Estado = fila["Estado"].ToString();
            m.Diagnostico = Nulos.Leer(fila["Diagnostico"]);
            m.TrabajoRealizado = Nulos.Leer(fila["TrabajoRealizado"]);
            m.Observaciones = Nulos.Leer(fila["Observaciones"]);
            m.CostoRepuestos = Convert.ToDecimal(fila["CostoRepuestos"]);
            return m;
        }
    }
}
