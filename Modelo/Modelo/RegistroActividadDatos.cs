using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    // Bitácora: guarda lo que hace cada usuario
    public static class RegistroActividadDatos
    {

        // si falla la bitácora no pasa nada, por eso el catch vacío
        public static void Registrar(string accion)
        {
            if (Sesion.Actual.IdUsuario == 0) return;

            try
            {
                string sql = "INSERT INTO RegistroActividad (IdUsuario, Accion, Fecha) VALUES (@IdUsuario, @Accion, @Fecha)";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", Sesion.Actual.IdUsuario);
                    cmd.Parameters.AddWithValue("@Accion",    accion);
                    cmd.Parameters.AddWithValue("@Fecha",     DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        public static RegistroActividad[] Listar()
        {
            try
            {
                string sql = @"SELECT Usuario, Nombre, Accion, Fecha
                               FROM VistaActividad
                               ORDER BY Fecha DESC, IdRegistro DESC";

                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, Conexion.Cadena);
                adaptador.Fill(tabla);
                RegistroActividad[] lista = new RegistroActividad[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow fila = tabla.Rows[i];
                    RegistroActividad registro = new RegistroActividad();
                    registro.Usuario = fila["Usuario"].ToString();
                    registro.Nombre = fila["Nombre"].ToString();
                    registro.Accion = fila["Accion"].ToString();
                    registro.Fecha = Convert.ToDateTime(fila["Fecha"]);
                    lista[i] = registro;
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }
    }
}
