namespace Modelo.Modelo
{

    // Repuesto que se usó en una visita
    public class RepuestoUsado
    {
        public const int CantidadMaxima = 999;

        public int IdDetalle { get; set; }
        public int IdMantenimiento { get; set; }
        public int IdRepuesto { get; set; }
        public string Repuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get { return Cantidad * PrecioUnitario; } }
    }
}
