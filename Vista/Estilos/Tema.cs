using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Vista.Estilos
{

    // Colores y estilos de todo el programa.
    // En el Tag de cada control se pone el estilo que lleva:
    //   botones ...... "primario", "secundario", "peligro", "menu"
    //   etiquetas .... "titulo", "subtitulo", "campo", "suave", "texto", "fuerte", "numero"
    //   paneles ...... "tarjeta"
    public static class Tema
    {
        public static readonly Color Oscuro = Color.FromArgb(11, 37, 69);
        public static readonly Color OscuroSuave = Color.FromArgb(24, 58, 102);
        public static readonly Color Primario = Color.FromArgb(27, 108, 168);
        public static readonly Color PrimarioClaro = Color.FromArgb(226, 239, 250);
        public static readonly Color Acento = Color.FromArgb(86, 196, 232);
        public static readonly Color Fondo = Color.FromArgb(238, 243, 248);
        public static readonly Color Tarjeta = Color.White;
        public static readonly Color Borde = Color.FromArgb(208, 219, 231);
        public static readonly Color CajaFondo = Color.FromArgb(247, 250, 252);
        public static readonly Color Texto = Color.FromArgb(16, 42, 67);
        public static readonly Color TextoSuave = Color.FromArgb(98, 125, 152);
        public static readonly Color TextoMenu = Color.FromArgb(196, 212, 230);
        public static readonly Color Peligro = Color.FromArgb(190, 60, 78);
        public static readonly Color PeligroClaro = Color.FromArgb(252, 238, 240);
        public static readonly Color Exito = Color.FromArgb(56, 142, 80);
        public static readonly Color Aviso = Color.FromArgb(198, 141, 46);

        private static readonly Font FuenteCaja = new Font("Segoe UI", 10F);
        private static readonly Font FuenteBoton = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Font FuenteMenu = new Font("Segoe UI", 10F);
        private static readonly Font FuenteTitulo = new Font("Segoe UI", 14F, FontStyle.Bold);
        private static readonly Font FuenteSubtitulo = new Font("Segoe UI", 11F, FontStyle.Bold);
        private static readonly Font FuenteCampo = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        private static readonly Font FuenteSuave = new Font("Segoe UI", 9F);
        private static readonly Font FuenteNumero = new Font("Segoe UI", 22F, FontStyle.Bold);
        private static readonly Font FuenteFuerte = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        private static readonly Font FuenteEncabezado = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Font FuenteCelda = new Font("Segoe UI", 9.75F);

        public static void Aplicar(Control raiz)
        {
            foreach (Control c in raiz.Controls)
            {
                Vestir(c);

                // estos controles tienen otros adentro, no se recorren
                if (c is Guna2TextBox) continue;
                if (c is Guna2ComboBox) continue;
                if (c is Guna2DateTimePicker) continue;
                if (c is DataGridView) continue;

                Aplicar(c);
            }
        }

        private static void Vestir(Control c)
        {
            string clase = "";
            if (c.Tag != null) clase = c.Tag.ToString();

            if (c is Guna2TextBox) Caja((Guna2TextBox)c);
            if (c is Guna2ComboBox) Combo((Guna2ComboBox)c);
            if (c is Guna2DateTimePicker) Fecha((Guna2DateTimePicker)c);
            if (c is Guna2Button) Boton((Guna2Button)c, clase);
            if (c is Guna2Panel) PanelTarjeta((Guna2Panel)c, clase);
            if (c is Guna2CheckBox) Casilla((Guna2CheckBox)c);
            if (c is DataGridView) Grid((DataGridView)c);
            if (c is Label) Etiqueta((Label)c, clase);
        }

        // color del fondo donde está el control (para las esquinas redondeadas)
        private static Color Superficie(Control c)
        {
            Control padre = c.Parent;
            while (padre != null)
            {
                Guna2Panel panel = padre as Guna2Panel;
                if (panel != null) return panel.FillColor;
                if (padre.BackColor != Color.Transparent) return padre.BackColor;
                padre = padre.Parent;
            }
            return Fondo;
        }

        private static void Caja(Guna2TextBox caja)
        {
            caja.BackColor = Superficie(caja);
            caja.BorderColor = Borde;
            caja.BorderRadius = 6;
            caja.FillColor = CajaFondo;
            caja.Font = FuenteCaja;
            caja.ForeColor = Texto;
            caja.PlaceholderForeColor = Color.FromArgb(150, 165, 182);
            caja.FocusedState.BorderColor = Primario;
            caja.HoverState.BorderColor = Primario;
            caja.DisabledState.BorderColor = Borde;
            caja.DisabledState.FillColor = Color.FromArgb(233, 238, 244);
            caja.DisabledState.ForeColor = TextoSuave;
        }

        private static void Combo(Guna2ComboBox combo)
        {
            combo.BackColor = Superficie(combo);
            combo.BorderColor = Borde;
            combo.BorderRadius = 6;
            combo.FillColor = CajaFondo;
            combo.Font = FuenteCaja;
            combo.ForeColor = Texto;
            combo.FocusedColor = Primario;
            combo.FocusedState.BorderColor = Primario;
            combo.HoverState.BorderColor = Primario;
            combo.ItemsAppearance.SelectedBackColor = Primario;
        }

        private static void Fecha(Guna2DateTimePicker fecha)
        {
            fecha.BackColor = Superficie(fecha);
            fecha.BorderColor = Borde;
            fecha.BorderThickness = 1;
            fecha.BorderRadius = 6;
            fecha.FillColor = CajaFondo;
            fecha.Font = FuenteCaja;
            fecha.ForeColor = Texto;
            fecha.Format = DateTimePickerFormat.Custom;
            fecha.CustomFormat = "dd/MM/yyyy";
            fecha.CheckedState.BorderColor = Borde;
            fecha.CheckedState.FillColor = CajaFondo;
            fecha.CheckedState.ForeColor = Texto;
            fecha.HoverState.BorderColor = Primario;
        }

        private static void Boton(Guna2Button boton, string clase)
        {
            boton.BackColor = Superficie(boton);
            boton.BorderRadius = 8;
            boton.Cursor = Cursors.Hand;
            boton.Font = FuenteBoton;

            if (clase == "primario")
            {
                boton.FillColor = Primario;
                boton.ForeColor = Color.White;
                boton.HoverState.FillColor = Oscuro;
                boton.DisabledState.FillColor = Color.FromArgb(170, 190, 210);
                boton.DisabledState.ForeColor = Color.White;
            }

            if (clase == "secundario")
            {
                boton.BorderColor = Borde;
                boton.BorderThickness = 1;
                boton.FillColor = CajaFondo;
                boton.ForeColor = Texto;
                boton.HoverState.FillColor = PrimarioClaro;
            }

            if (clase == "peligro")
            {
                boton.BorderColor = Peligro;
                boton.BorderThickness = 1;
                boton.FillColor = PeligroClaro;
                boton.ForeColor = Peligro;
                boton.HoverState.FillColor = Color.FromArgb(247, 218, 223);
            }

            if (clase == "menu")
            {
                boton.Font = FuenteMenu;
                boton.FillColor = Oscuro;
                boton.ForeColor = TextoMenu;
                boton.TextAlign = HorizontalAlignment.Left;
                boton.TextOffset = new Point(10, 0);
                boton.HoverState.FillColor = OscuroSuave;
                boton.HoverState.ForeColor = Color.White;
                boton.CheckedState.FillColor = Primario;
                boton.CheckedState.ForeColor = Color.White;
            }
        }

        private static void PanelTarjeta(Guna2Panel panel, string clase)
        {
            if (clase != "tarjeta") return;

            panel.BackColor = Superficie(panel);
            panel.BorderColor = Borde;
            panel.BorderThickness = 1;
            panel.BorderRadius = 10;
            panel.FillColor = Tarjeta;
        }

        private static void Casilla(Guna2CheckBox casilla)
        {
            casilla.BackColor = Superficie(casilla);
            casilla.Font = FuenteCaja;
            casilla.ForeColor = Texto;
            casilla.CheckedState.BorderColor = Primario;
            casilla.CheckedState.FillColor = Primario;
            casilla.CheckedState.BorderRadius = 3;
            casilla.UncheckedState.BorderColor = TextoSuave;
            casilla.UncheckedState.BorderRadius = 3;
            casilla.UncheckedState.BorderThickness = 1;
            casilla.UncheckedState.FillColor = Color.White;
        }

        private static void Etiqueta(Label etiqueta, string clase)
        {
            etiqueta.BackColor = Superficie(etiqueta);

            if (clase == "texto")
            {
                etiqueta.Font = FuenteCelda;
                etiqueta.ForeColor = Texto;
            }

            if (clase == "fuerte")
            {
                etiqueta.Font = FuenteFuerte;
                etiqueta.ForeColor = Texto;
            }

            if (clase == "titulo")
            {
                etiqueta.Font = FuenteTitulo;
                etiqueta.ForeColor = Texto;
            }

            if (clase == "subtitulo")
            {
                etiqueta.Font = FuenteSubtitulo;
                etiqueta.ForeColor = Texto;
            }

            if (clase == "campo")
            {
                etiqueta.Font = FuenteCampo;
                etiqueta.ForeColor = TextoSuave;
            }

            if (clase == "suave")
            {
                etiqueta.Font = FuenteSuave;
                etiqueta.ForeColor = TextoSuave;
            }

            if (clase == "numero")
            {
                etiqueta.Font = FuenteNumero;
                etiqueta.ForeColor = Primario;
            }
        }

        private static void Grid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Tarjeta;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Color.FromArgb(228, 235, 243);
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 36;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Tarjeta;
            grid.ColumnHeadersDefaultCellStyle.Font = FuenteEncabezado;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextoSuave;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tarjeta;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextoSuave;

            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.BackColor = Tarjeta;
            grid.DefaultCellStyle.Font = FuenteCelda;
            grid.DefaultCellStyle.ForeColor = Texto;
            grid.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
            grid.DefaultCellStyle.SelectionBackColor = PrimarioClaro;
            grid.DefaultCellStyle.SelectionForeColor = Texto;
        }
    }
}
