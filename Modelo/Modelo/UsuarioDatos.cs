using System;
using System.Data;
using System.Data.SqlClient;
using Modelo.ConexionDB;

namespace Modelo.Modelo
{

    public static class UsuarioDatos
    {

        private const string SqlBase =
            @"SELECT IdUsuario, Nombre, NombreUsuario, Contrasena, IdRol, Rol, IdCliente, Cliente,
                     Correo, Activo, FechaCreacion, UltimoAcceso
              FROM VistaUsuarios";

        public const string SinAdministrador =
            "Es el único Administrador activo: no se le puede quitar el rol, desactivar ni eliminar.\n" +
            "Primero dale el rol Administrador a otra persona.";

        public const string ConHistorial =
            "Ese usuario tiene visitas asignadas o acciones en la bitácora.\n" +
            "Desactívalo en lugar de eliminarlo.";

        public static Usuario BuscarPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " WHERE NombreUsuario = @Usuario", Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
                adaptador.Fill(tabla);

                if (tabla.Rows.Count > 0) return LeerFila(tabla.Rows[0]);
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static Usuario Buscar(int idUsuario)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(SqlBase + " WHERE IdUsuario = @Id", Conexion.Cadena);
                adaptador.SelectCommand.Parameters.AddWithValue("@Id", idUsuario);
                adaptador.Fill(tabla);

                if (tabla.Rows.Count > 0) return LeerFila(tabla.Rows[0]);
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static Usuario[] Listar()
        {
            return Consultar(SqlBase + " ORDER BY Nombre");
        }

        // solo los ingenieros activos, para el combo de las visitas
        public static Usuario[] ListarIngenieros()
        {
            return Consultar(SqlBase + " WHERE Rol = '" + Rol.Ingeniero + "' AND Activo = 1 ORDER BY Nombre");
        }

        private static Usuario[] Consultar(string sql)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, Conexion.Cadena);
                adaptador.Fill(tabla);
                Usuario[] lista = new Usuario[tabla.Rows.Count];

                for (int i = 0; i < tabla.Rows.Count; i++)
                    lista[i] = LeerFila(tabla.Rows[i]);
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static bool EsNombreUsuarioValido(string nombreUsuario)
        {
            string permitidos = "abcdefghijklmnopqrstuvwxyz0123456789._";
            if (nombreUsuario.Length < 4) return false;
            foreach (char c in nombreUsuario)
                if (permitidos.IndexOf(c) < 0) return false;
            return true;
        }

        public static bool Existe(string nombreUsuario, int exceptoId)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND IdUsuario <> @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Id", exceptoId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int AdministradoresActivosSin(int idUsuario)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM Usuarios
                      WHERE IdRol = @IdRol AND Activo = 1 AND IdUsuario <> @Id", con))
                {
                    cmd.Parameters.AddWithValue("@IdRol", Rol.IdAdministrador);
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static bool EsUltimoAdministrador(int idUsuario)
        {
            Usuario actual = Buscar(idUsuario);
            if (actual == null) return false;
            if (actual.IdRol != Rol.IdAdministrador) return false;
            if (!actual.Activo) return false;
            return AdministradoresActivosSin(idUsuario) == 0;
        }

        public static int Insertar(Usuario u)
        {
            try
            {
                string sql = @"INSERT INTO Usuarios
                                   (Nombre, NombreUsuario, Contrasena, IdRol, IdCliente, Correo, Activo, FechaCreacion)
                               VALUES
                                   (@Nombre, @Usuario, @Clave, @IdRol, @IdCliente, @Correo, @Activo, @Fecha);
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, u);
                    cmd.Parameters.AddWithValue("@Clave", u.Contrasena);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        // aquí no se cambia la contraseña
        public static int Actualizar(Usuario u)
        {
            try
            {
                bool dejaDeSerAdmin = u.IdRol != Rol.IdAdministrador;
                if (!u.Activo) dejaDeSerAdmin = true;

                if (dejaDeSerAdmin)
                {
                    if (EsUltimoAdministrador(u.IdUsuario))
                        throw new Exception(Errores.Regla(SinAdministrador));
                }

                string sql = @"UPDATE Usuarios
                               SET Nombre = @Nombre, NombreUsuario = @Usuario, IdRol = @IdRol,
                                   IdCliente = @IdCliente, Correo = @Correo, Activo = @Activo
                               WHERE IdUsuario = @Id";

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    PonerParametros(cmd, u);
                    cmd.Parameters.AddWithValue("@Id", u.IdUsuario);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static void PonerParametros(SqlCommand cmd, Usuario u)
        {
            cmd.Parameters.AddWithValue("@Nombre",    u.Nombre);
            cmd.Parameters.AddWithValue("@Usuario",   u.NombreUsuario);
            cmd.Parameters.AddWithValue("@IdRol",     u.IdRol);
            cmd.Parameters.AddWithValue("@IdCliente", Nulos.GuardarId(u.IdCliente));
            cmd.Parameters.AddWithValue("@Correo",    Nulos.Guardar(u.Correo));
            cmd.Parameters.AddWithValue("@Activo",    u.Activo);
        }

        public static void CambiarClave(int idUsuario, string claveCifrada)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Usuarios SET Contrasena = @Clave WHERE IdUsuario = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Clave", claveCifrada);
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static void AnotarAcceso(int idUsuario)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Usuarios SET UltimoAcceso = @Ahora WHERE IdUsuario = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Ahora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static int Eliminar(int idUsuario)
        {
            try
            {
                if (EsUltimoAdministrador(idUsuario))
                    throw new Exception(Errores.Regla(SinAdministrador));

                if (TieneHistorial(idUsuario))
                    throw new Exception(Errores.Regla(ConHistorial));

                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE IdUsuario = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        public static bool TieneHistorial(int idUsuario)
        {
            try
            {
                using (SqlConnection con = Conexion.Abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT (SELECT COUNT(*) FROM Mantenimientos WHERE IdIngeniero = @Id)
                           + (SELECT COUNT(*) FROM RegistroActividad WHERE IdUsuario = @Id)", con))
                {
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(Errores.Texto(ex), ex);
            }
        }

        private static Usuario LeerFila(DataRow fila)
        {
            Usuario u = new Usuario();
            u.IdUsuario = Convert.ToInt32(fila["IdUsuario"]);
            u.Nombre = fila["Nombre"].ToString();
            u.NombreUsuario = fila["NombreUsuario"].ToString();
            u.Contrasena = fila["Contrasena"].ToString();
            u.IdRol = Convert.ToInt32(fila["IdRol"]);
            u.Rol = fila["Rol"].ToString();
            u.IdCliente = Nulos.LeerEntero(fila["IdCliente"]);
            u.Cliente = Nulos.Leer(fila["Cliente"]);
            u.Correo = Nulos.Leer(fila["Correo"]);
            u.Activo = Convert.ToBoolean(fila["Activo"]);
            u.FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]);
            if (fila["UltimoAcceso"] != DBNull.Value) u.UltimoAcceso = Convert.ToDateTime(fila["UltimoAcceso"]);
            return u;
        }
    }
}
