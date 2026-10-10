using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class RepuestoDatos
    {
        private const string SqlBase =
            "SELECT IdRepuesto, Nombre, Categoria, Existencia, StockMinimo, PrecioUnitario FROM Repuestos";

        public static Repuesto[] Listar()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " ORDER BY Nombre", Conexion.Cadena);
                adaptador.Fill(tabla);
                Repuesto[] lista = new Repuesto[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static bool ExisteNombre(string nombre, int exceptoId)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Repuestos WHERE Nombre = @Nombre AND IdRepuesto <> @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Id", exceptoId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Insertar(Repuesto r)
        {
            try
            {
                string sql = @"INSERT INTO Repuestos (Nombre, Categoria, Existencia, StockMinimo, PrecioUnitario)
                               VALUES (@Nombre, @Categoria, @Existencia, @Minimo, @Precio);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, r);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Actualizar(Repuesto r)
        {
            try
            {
                string sql = @"UPDATE Repuestos
                               SET Nombre = @Nombre, Categoria = @Categoria, Existencia = @Existencia,
                                   StockMinimo = @Minimo, PrecioUnitario = @Precio
                               WHERE IdRepuesto = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, r);
                    cmd.Parameters.AddWithValue("@Id", r.IdRepuesto);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Eliminar(int idRepuesto)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Repuestos WHERE IdRepuesto = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idRepuesto);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Repuesto r)
        {
            cmd.Parameters.AddWithValue("@Nombre",     r.Nombre);
            cmd.Parameters.AddWithValue("@Categoria",  r.Categoria);
            cmd.Parameters.AddWithValue("@Existencia", r.Existencia);
            cmd.Parameters.AddWithValue("@Minimo",     r.StockMinimo);
            cmd.Parameters.AddWithValue("@Precio",     r.PrecioUnitario);
        }

        private static Repuesto LeerFila(DataRow fila)
        {
            Repuesto r = new Repuesto();
            r.IdRepuesto = Convert.ToInt32(fila["IdRepuesto"]);
            r.Nombre = fila["Nombre"].ToString();
            r.Categoria = fila["Categoria"].ToString();
            r.Existencia = Convert.ToInt32(fila["Existencia"]);
            r.StockMinimo = Convert.ToInt32(fila["StockMinimo"]);
            r.PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]);
            return r;
        }
    }
}
