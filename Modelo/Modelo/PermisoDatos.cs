using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class PermisoDatos
    {
        public const string AdministradorCompleto =
            "El rol Administrador siempre tiene todos los permisos; no se le pueden quitar.";

        public static Permiso[] Listar()
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    "SELECT IdPermiso, Clave, Nombre, Modulo FROM Permisos ORDER BY IdPermiso", Conexion.Cadena);
                adaptador.Fill(tabla);
                Permiso[] lista = new Permiso[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow fila = tabla.Rows[i];
                    Permiso permiso = new Permiso();
                    permiso.IdPermiso = Convert.ToInt32(fila["IdPermiso"]);
                    permiso.Clave = fila["Clave"].ToString();
                    permiso.Nombre = fila["Nombre"].ToString();
                    permiso.Modulo = fila["Modulo"].ToString();
                    lista[i] = permiso;
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static string[] ClavesDeRol(int idRol)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    "SELECT Clave FROM VistaRolesPermisos WHERE IdRol = @IdRol", Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdRol", idRol);
                adaptador.Fill(tabla);
                string[] claves = new string[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    claves[i] = tabla.Rows[i]["Clave"].ToString();
                return claves;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int[] IdsDeRol(int idRol)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    "SELECT IdPermiso FROM RolesPermisos WHERE IdRol = @IdRol", Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@IdRol", idRol);
                adaptador.Fill(tabla);
                int[] ids = new int[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    ids[i] = Convert.ToInt32(tabla.Rows[i]["IdPermiso"]);
                return ids;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        // borra los permisos que tenía el rol y guarda los nuevos
        public static void GuardarDeRol(int idRol, int[] idsPermisos)
        {
            if (idRol == Rol.IdAdministrador)
                throw new Exception(Errores.Regla(AdministradorCompleto));

            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand borrar = new SqlCommand(
                            "DELETE FROM RolesPermisos WHERE IdRol = @IdRol", con, transaccion))
                        {
                            borrar.Parameters.AddWithValue("@IdRol", idRol);
                            borrar.ExecuteNonQuery();
                        }

                        foreach (int idPermiso in idsPermisos)
                        {
                            using (SqlCommand agregar = new SqlCommand(
                                "INSERT INTO RolesPermisos (IdRol, IdPermiso) VALUES (@IdRol, @IdPermiso)", con, transaccion))
                            {
                                agregar.Parameters.AddWithValue("@IdRol", idRol);
                                agregar.Parameters.AddWithValue("@IdPermiso", idPermiso);
                                agregar.ExecuteNonQuery();
                            }
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
    }
}
