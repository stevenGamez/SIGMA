using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class ContratoDatos
    {
        private const string SqlBase =
            @"SELECT IdContrato, IdCliente, Cliente, FechaInicio, FechaFin, Frecuencia,
                     MontoMensual, Estado, Descripcion, Equipos
              FROM VistaContratos";

        public static Contrato[] Listar()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " ORDER BY IdContrato DESC", Conexion.Cadena);
                adaptador.Fill(tabla);
                Contrato[] lista = new Contrato[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Insertar(Contrato c)
        {
            try
            {
                string sql = @"INSERT INTO Contratos
                                   (IdCliente, FechaInicio, FechaFin, Frecuencia, MontoMensual, Estado, Descripcion)
                               VALUES
                                   (@IdCliente, @Inicio, @Fin, @Frecuencia, @Monto, @Estado, @Descripcion);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, c);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Actualizar(Contrato c)
        {
            try
            {
                string sql = @"UPDATE Contratos
                               SET IdCliente = @IdCliente, FechaInicio = @Inicio, FechaFin = @Fin,
                                   Frecuencia = @Frecuencia, MontoMensual = @Monto, Estado = @Estado,
                                   Descripcion = @Descripcion
                               WHERE IdContrato = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, c);
                    cmd.Parameters.AddWithValue("@Id", c.IdContrato);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Eliminar(int idContrato)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Contratos WHERE IdContrato = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idContrato);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Contrato c)
        {
            cmd.Parameters.AddWithValue("@IdCliente",   c.IdCliente);
            cmd.Parameters.AddWithValue("@Inicio",      c.FechaInicio.Date);
            cmd.Parameters.AddWithValue("@Fin",         c.FechaFin.Date);
            cmd.Parameters.AddWithValue("@Frecuencia",  c.Frecuencia);
            cmd.Parameters.AddWithValue("@Monto",       c.MontoMensual);
            cmd.Parameters.AddWithValue("@Estado",      c.Estado);
            cmd.Parameters.AddWithValue("@Descripcion", Nulos.Guardar(c.Descripcion));
        }

        private static Contrato LeerFila(DataRow fila)
        {
            Contrato c = new Contrato();
            c.IdContrato = Convert.ToInt32(fila["IdContrato"]);
            c.IdCliente = Convert.ToInt32(fila["IdCliente"]);
            c.Cliente = fila["Cliente"].ToString();
            c.FechaInicio = Convert.ToDateTime(fila["FechaInicio"]);
            c.FechaFin = Convert.ToDateTime(fila["FechaFin"]);
            c.Frecuencia = fila["Frecuencia"].ToString();
            c.MontoMensual = Convert.ToDecimal(fila["MontoMensual"]);
            c.Estado = fila["Estado"].ToString();
            c.Descripcion = Nulos.Leer(fila["Descripcion"]);
            c.Equipos = Convert.ToInt32(fila["Equipos"]);
            return c;
        }
    }
}
