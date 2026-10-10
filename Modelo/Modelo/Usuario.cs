using System;

namespace Modelo.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
