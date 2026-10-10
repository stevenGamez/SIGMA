namespace Modelo.Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public string Codigo { get { return Textos.Codigo("CL", IdCliente); } }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
