namespace Modelo.Modelo
{

    public static class Textos
    {

        // quita los espacios de más
        public static string Limpiar(string texto)
        {
            if (texto == null) return "";

            string limpio = texto.Trim();
            while (limpio.Contains("  ")) limpio = limpio.Replace("  ", " ");
            return limpio;
        }

        public static string Codigo(string prefijo, int id)
        {
            return prefijo + "-" + id.ToString("0000");
        }
    }
}
