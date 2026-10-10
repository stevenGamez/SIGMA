using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class EquipoDatos
    {
        private const string SqlBase =
            @"SELECT IdEquipo, IdContrato, IdCliente, Cliente, NumeroSerie, Marca, Modelo, Tipo,
                     CapacidadBTU, Ubicacion, FechaInstalacion, Estado
              FROM VistaEquipos";

        public static Equipo[] Listar()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " ORDER BY Cliente, NumeroSerie", Conexion.Cadena);
                adaptador.Fill(tabla);
                Equipo[] lista = new Equipo[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static bool ExisteSerie(string numeroSerie, int exceptoId)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Equipos WHERE NumeroSerie = @Serie AND IdEquipo <> @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Serie", numeroSerie);
                    cmd.Parameters.AddWithValue("@Id", exceptoId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Insertar(Equipo e)
        {
            try
            {
                string sql = @"INSERT INTO Equipos
                                   (IdContrato, NumeroSerie, Marca, Modelo, Tipo, CapacidadBTU,
                                    Ubicacion, FechaInstalacion, Estado)
                               VALUES
                                   (@IdContrato, @Serie, @Marca, @Modelo, @Tipo, @Capacidad,
                                    @Ubicacion, @Instalacion, @Estado);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, e);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Actualizar(Equipo e)
        {
            try
            {
                string sql = @"UPDATE Equipos
                               SET IdContrato = @IdContrato, NumeroSerie = @Serie, Marca = @Marca,
                                   Modelo = @Modelo, Tipo = @Tipo, CapacidadBTU = @Capacidad,
                                   Ubicacion = @Ubicacion, FechaInstalacion = @Instalacion, Estado = @Estado
                               WHERE IdEquipo = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, e);
                    cmd.Parameters.AddWithValue("@Id", e.IdEquipo);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Eliminar(int idEquipo)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Equipos WHERE IdEquipo = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idEquipo);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Equipo e)
        {
            cmd.Parameters.AddWithValue("@IdContrato",  e.IdContrato);
            cmd.Parameters.AddWithValue("@Serie",       e.NumeroSerie);
            cmd.Parameters.AddWithValue("@Marca",       e.Marca);
            cmd.Parameters.AddWithValue("@Modelo",      e.Modelo);
            cmd.Parameters.AddWithValue("@Tipo",        e.Tipo);
            cmd.Parameters.AddWithValue("@Capacidad",   e.CapacidadBTU);
            cmd.Parameters.AddWithValue("@Ubicacion",   e.Ubicacion);
            cmd.Parameters.AddWithValue("@Instalacion", e.FechaInstalacion.Date);
            cmd.Parameters.AddWithValue("@Estado",      e.Estado);
        }

        private static Equipo LeerFila(DataRow fila)
        {
            Equipo e = new Equipo();
            e.IdEquipo = Convert.ToInt32(fila["IdEquipo"]);
            e.IdContrato = Convert.ToInt32(fila["IdContrato"]);
            e.IdCliente = Convert.ToInt32(fila["IdCliente"]);
            e.Cliente = fila["Cliente"].ToString();
            e.NumeroSerie = fila["NumeroSerie"].ToString();
            e.Marca = fila["Marca"].ToString();
            e.Modelo = fila["Modelo"].ToString();
            e.Tipo = fila["Tipo"].ToString();
            e.CapacidadBTU = Convert.ToInt32(fila["CapacidadBTU"]);
            e.Ubicacion = fila["Ubicacion"].ToString();
            e.FechaInstalacion = Convert.ToDateTime(fila["FechaInstalacion"]);
            e.Estado = fila["Estado"].ToString();
            return e;
        }
    }
}
