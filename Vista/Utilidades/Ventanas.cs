using System.Drawing;
using System.Windows.Forms;

namespace Vista.Utilidades
{

    public static class Ventanas
    {

        // pone el icono del programa en la ventana
        public static void PonerIcono(Form ventana)
        {
            try
            {
                ventana.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch
            {
            }
        }

        // esconde el formulario y deja la tabla en todo el ancho (para los que solo consultan)
        public static void SoloLectura(Form ventana, Control tabla, Control formulario)
        {
            formulario.Visible = false;
            tabla.Width = ventana.ClientSize.Width - tabla.Left * 2;
        }
    }
}
