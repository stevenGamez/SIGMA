using System;

namespace Modelo.Modelo
{
    public class Equipo
    {
        public static readonly string[] Tipos = { "Mini Split", "Cassette", "Piso-Techo", "Central", "Ventana", "Chiller" };
        public static readonly string[] Estados = { "Operativo", "En mantenimiento", "Fuera de servicio" };

        public const int CapacidadMinima = 5000;
        public const int CapacidadMaxima = 2000000;

        public int IdEquipo { get; set; }
        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int CapacidadBTU { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaInstalacion { get; set; }
        public string Estado { get; set; }

        public string Contrato { get { return Textos.Codigo("CT", IdContrato); } }

        public override string ToString()
        {
            return NumeroSerie + " · " + Marca + " " + Modelo;
        }
    }
}
