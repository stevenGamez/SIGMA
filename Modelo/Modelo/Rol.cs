namespace Modelo.Modelo
{
    public class Rol
    {
        public const string Administrador = "Administrador";
        public const string Ingeniero = "Ingeniero";
        public const string ClienteCorporativo = "ClienteCorporativo";

        public const int IdAdministrador = 1;

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Usuarios { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
