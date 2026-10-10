using System.Drawing;
using System.Windows.Forms;

namespace Vista.Estilos
{

    public static class EstiloGrid
    {
        private static readonly Font Negrita = new Font("Segoe UI", 9.75F, FontStyle.Bold);

        public static Color ColorEstado(string estado)
        {
            switch (estado)
            {
                case "Completado":
                case "Vigente":
                case "Operativo":
                case "Activo":
                case "Disponible":
                    return Tema.Exito;

                case "Cancelado":
                case "Finalizado":
                case "Fuera de servicio":
                case "Inactivo":
                case "Agotado":
                    return Tema.Peligro;

                case "Existencia baja":
                    return Tema.Aviso;

                case "Programado":
                case "Suspendido":
                case "En mantenimiento":
                    return Tema.Aviso;

                case "En proceso":
                    return Tema.Primario;

                default:
                    return Tema.Texto;
            }
        }

        // pinta el estado con su color
        public static void PintarEstado(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;

            Color color = ColorEstado(e.Value.ToString());
            e.CellStyle.ForeColor = color;
            e.CellStyle.SelectionForeColor = color;
            e.CellStyle.Font = Negrita;
        }

        public static void Columna(DataGridView grid, string nombre, string titulo, int peso)
        {
            grid.Columns.Add(nombre, titulo);
            grid.Columns[nombre].FillWeight = peso;
            grid.Columns[nombre].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // columna con ancho fijo (códigos, fechas, estados)
        public static void ColumnaFija(DataGridView grid, string nombre, string titulo, int ancho)
        {
            grid.Columns.Add(nombre, titulo);
            grid.Columns[nombre].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grid.Columns[nombre].Resizable = DataGridViewTriState.False;
            grid.Columns[nombre].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns[nombre].Width = ancho;
        }

        public static void ColumnaOculta(DataGridView grid, string nombre)
        {
            grid.Columns.Add(nombre, nombre);
            grid.Columns[nombre].Visible = false;
        }
    }
}
