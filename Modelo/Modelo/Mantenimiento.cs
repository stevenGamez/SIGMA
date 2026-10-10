using System;

namespace Modelo.Modelo
{

    // Visita de mantenimiento (también guarda la hoja de servicio)
    public class Mantenimiento
    {
        public const string Programado = "Programado";
        public const string EnProceso = "En proceso";
        public const string Completado = "Completado";
        public const string Cancelado = "Cancelado";

        public static readonly string[] Tipos = { "Preventivo", "Correctivo" };
        public static readonly string[] Estados = { Programado, EnProceso, Completado, Cancelado };

        public int IdMantenimiento { get; set; }
        public int IdEquipo { get; set; }
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ubicacion { get; set; }
        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public int IdIngeniero { get; set; }
        public string Ingeniero { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaRealizada { get; set; }
        public string Estado { get; set; }
        public string Diagnostico { get; set; }
        public string TrabajoRealizado { get; set; }
        public string Observaciones { get; set; }
        public decimal CostoRepuestos { get; set; }

        public string Codigo { get { return Textos.Codigo("MT", IdMantenimiento); } }

        public string Equipo { get { return NumeroSerie + " · " + Marca + " " + Modelo; } }

        public bool Pendiente
        {
            get
            {
                if (Estado == Programado) return true;
                return Estado == EnProceso;
            }
        }
    }
}
