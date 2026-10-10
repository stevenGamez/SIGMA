using System;

namespace Modelo.Modelo
{
    public class Contrato
    {
        public static readonly string[] Frecuencias = { "Mensual", "Bimestral", "Trimestral", "Semestral", "Anual" };
        public static readonly string[] Estados = { "Vigente", "Suspendido", "Finalizado" };

        public const decimal MontoMaximo = 99999.99m;

        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Frecuencia { get; set; }
        public decimal MontoMensual { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int Equipos { get; set; }

        public string Codigo { get { return Textos.Codigo("CT", IdContrato); } }

        public override string ToString()
        {
            return Codigo + " · " + Cliente;
        }
    }
}
