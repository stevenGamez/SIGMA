using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class RolDatos
    {
        public static Rol[] Listar()
        {
            try
            {
                string sql = @"SELECT Roles.IdRol, Roles.Nombre, Roles.Descripcion,
                                      (SELECT COUNT(*) FROM Usuarios WHERE Usuarios.IdRol = Roles.IdRol) AS Usuarios
                               FROM Roles
                               ORDER BY Roles.IdRol";

                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, Conexion.Cadena);
                adaptador.Fill(tabla);
                Rol[] lista = new Rol[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow fila = tabla.Rows[i];
                    Rol rol = new Rol();
                    rol.IdRol = Convert.ToInt32(fila["IdRol"]);
                    rol.Nombre = fila["Nombre"].ToString();
                    rol.Descripcion = fila["Descripcion"].ToString();
                    rol.Usuarios = Convert.ToInt32(fila["Usuarios"]);
                    lista[i] = rol;
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
