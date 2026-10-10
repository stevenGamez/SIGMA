namespace Modelo.Modelo
{
    public class Repuesto
    {
        public static readonly string[] Categorias = { "Eléctrico", "Mecánico", "Refrigeración", "Filtración", "Otro" };

        public const int ExistenciaMaxima = 99999;
        public const decimal PrecioMaximo = 99999.99m;

        public int IdRepuesto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Existencia { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public string Codigo { get { return Textos.Codigo("RP", IdRepuesto); } }

        public bool BajoStock { get { return Existencia <= StockMinimo; } }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
