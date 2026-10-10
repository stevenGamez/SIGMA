namespace Modelo.Modelo
{

    // Guarda el usuario que inició sesión y sus permisos
    public static class Sesion
    {
        public static Usuario Actual = new Usuario();

        public static string[] PermisosDelRol = new string[0];

        public static void Iniciar(Usuario usuario)
        {
            Actual = usuario;
            PermisosDelRol = PermisoDatos.ClavesDeRol(usuario.IdRol);
        }

        public static void Cerrar()
        {
            Actual = new Usuario();
            PermisosDelRol = new string[0];
        }

        public static bool Puede(string clave)
        {
            foreach (string permiso in PermisosDelRol)
                if (permiso == clave) return true;
            return false;
        }

        public static bool EsAdmin     { get { return Actual.Rol == Rol.Administrador; } }
        public static bool EsIngeniero { get { return Actual.Rol == Rol.Ingeniero; } }

        // el ingeniero solo ve sus visitas, el 0 es para ver todas
        public static int IngenieroVisible
        {
            get
            {
                if (EsIngeniero) return Actual.IdUsuario;
                return 0;
            }
        }
    }
}
