namespace Modelo.Modelo
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    // Claves de los permisos (son las mismas de la tabla Permisos)
    public static class Permisos
    {
        public const string ContratosVer = "CONTRATOS_VER";
        public const string ContratosGestionar = "CONTRATOS_GESTIONAR";
        public const string EquiposVer = "EQUIPOS_VER";
        public const string EquiposGestionar = "EQUIPOS_GESTIONAR";
        public const string RepuestosVer = "REPUESTOS_VER";
        public const string RepuestosGestionar = "REPUESTOS_GESTIONAR";
        public const string MantenimientosVer = "MANTENIMIENTOS_VER";
        public const string MantenimientosGestionar = "MANTENIMIENTOS_GESTIONAR";
        public const string HojasRegistrar = "HOJAS_REGISTRAR";
        public const string ClientesGestionar = "CLIENTES_GESTIONAR";
        public const string UsuariosGestionar = "USUARIOS_GESTIONAR";
        public const string BitacoraVer = "BITACORA_VER";
    }
}
