using Guna.UI2.WinForms;

namespace Vista.Estilos
{

    public static class EstiloBotones
    {
        public static void MarcarEstado(Guna2Button[] botones, Guna2Button seleccionado)
        {
            foreach (Guna2Button b in botones) b.Checked = (b == seleccionado);
        }
    }
}
