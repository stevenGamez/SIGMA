namespace Vista.Utilidades
{

    public static class Filtro
    {

        // true si el texto buscado está en alguno
        public static bool Coincide(string buscado, params string[] textos)
        {
            foreach (string texto in textos)
            {
                if (texto == null) continue;
                if (texto.ToLower().Contains(buscado)) return true;
            }
            return false;
        }
    }
}
