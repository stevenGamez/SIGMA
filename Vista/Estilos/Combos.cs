using Guna.UI2.WinForms;

namespace Vista.Estilos
{

    public static class Combos
    {

        public static void Llenar(Guna2ComboBox cbo, object[] opciones)
        {
            cbo.Items.Clear();
            foreach (object opcion in opciones) cbo.Items.Add(opcion);
            if (cbo.Items.Count > 0) cbo.SelectedIndex = 0;
        }

        // selecciona la opción que tenga ese texto
        public static void Seleccionar(Guna2ComboBox cbo, string texto)
        {
            foreach (object o in cbo.Items)
            {
                if (o.ToString() == texto)
                {
                    cbo.SelectedItem = o;
                    return;
                }
            }

            if (cbo.Items.Count > 0) cbo.SelectedIndex = 0;
        }

        public static string Texto(Guna2ComboBox cbo)
        {
            if (cbo.SelectedItem == null) return "";
            return cbo.SelectedItem.ToString();
        }
    }
}
