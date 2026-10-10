namespace Modelo.Modelo
{

    // Aquí se encriptan las contraseñas con BCrypt
    public static class Clave
    {

        private const int Costo = 11;

        public const int LargoMinimo = 8;

        public static string Cifrar(string clave)
        {
            if (clave == null) clave = "";
            return BCrypt.Net.BCrypt.HashPassword(clave, Costo);
        }

        public static bool Coincide(string clave, string guardado)
        {
            if (clave == null) clave = "";
            if (string.IsNullOrEmpty(guardado)) return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(clave, guardado);
            }
            catch
            {
                return false;
            }
        }

        public static bool EsSegura(string clave)
        {
            if (clave == null) return false;
            if (clave.Length < LargoMinimo) return false;

            bool letra = false;
            bool numero = false;
            foreach (char c in clave)
            {
                if (char.IsLetter(c)) letra = true;
                if (char.IsDigit(c)) numero = true;
            }

            if (!letra) return false;
            return numero;
        }
    }
}
