using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Vista.Utilidades
{

    public static class Validaciones
    {

        // marca el campo con error y muestra el mensaje
        public static void Invalido(ErrorProvider avisos, Control campo, string codigo, string mensaje)
        {
            avisos.SetError(campo, Modelo.Modelo.Errores.Mensaje(codigo));
            Mensajes.Aviso(mensaje);
            campo.Focus();
        }

        public static void SoloEnteros(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        public static void SoloDecimal(Guna2TextBox caja, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar != '.') e.Handled = true;
            if (caja.Text.Contains(".")) e.Handled = true;
        }

        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsLetter(e.KeyChar)) return;
            if (e.KeyChar == ' ') return;
            e.Handled = true;
        }

        public static void SoloTelefono(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '-') return;
            e.Handled = true;
        }

        public static void SoloNombreUsuario(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            string permitidos = "abcdefghijklmnopqrstuvwxyz0123456789._";
            if (permitidos.IndexOf(char.ToLower(e.KeyChar)) < 0) e.Handled = true;
        }

        public static bool SoloDigitos(string texto)
        {
            foreach (char c in texto)
                if (!char.IsDigit(c)) return false;
            return texto.Length > 0;
        }

        public static bool EsNombre(string texto)
        {
            int letras = 0;
            foreach (char c in texto)
                if (char.IsLetter(c)) letras++;
            return letras >= 3;
        }

        // teléfono de 8 dígitos que empiece con 2, 6 o 7
        public static bool EsTelefono(string texto)
        {
            string numero = texto.Trim();
            if (numero.Length == 9)
            {
                if (numero[4] != '-') return false;
                numero = numero.Remove(4, 1);
            }
            if (numero.Length != 8) return false;
            if (!SoloDigitos(numero)) return false;
            if (numero[0] == '2') return true;
            if (numero[0] == '6') return true;
            return numero[0] == '7';
        }

        public static string NormalizarTelefono(string texto)
        {
            if (!EsTelefono(texto)) return texto.Trim();
            string numero = texto.Trim().Replace("-", "");
            return numero.Substring(0, 4) + "-" + numero.Substring(4);
        }

        // NIT de 14 dígitos, con o sin guiones
        public static bool EsNit(string texto)
        {
            string nit = texto.Trim();
            if (nit.Length == 17)
            {
                if (nit[4] != '-') return false;
                if (nit[11] != '-') return false;
                if (nit[15] != '-') return false;
                nit = nit.Replace("-", "");
            }
            if (nit.Length != 14) return false;
            return SoloDigitos(nit);
        }

        public static string NormalizarNit(string texto)
        {
            if (!EsNit(texto)) return texto.Trim();
            string nit = texto.Trim().Replace("-", "");
            return nit.Substring(0, 4) + "-" + nit.Substring(4, 6) + "-" + nit.Substring(10, 3) + "-" + nit.Substring(13);
        }

        public static bool EsCorreo(string texto)
        {
            if (texto == null) return false;
            string correo = texto.Trim().ToLower();

            string permitidos = "abcdefghijklmnopqrstuvwxyz0123456789._%+-@";
            foreach (char c in correo)
                if (permitidos.IndexOf(c) < 0) return false;

            int arroba = correo.IndexOf('@');
            if (arroba < 1) return false;
            if (correo.IndexOf('@', arroba + 1) >= 0) return false;
            if (correo.Contains("..")) return false;

            string usuario = correo.Substring(0, arroba);
            if (usuario.StartsWith(".")) return false;
            if (usuario.EndsWith(".")) return false;

            string dominio = correo.Substring(arroba + 1);
            foreach (char c in dominio)
            {
                if (char.IsLetterOrDigit(c)) continue;
                if (c == '.') continue;
                if (c == '-') continue;
                return false;
            }

            if (dominio.StartsWith("-")) return false;
            if (dominio.Contains("-.")) return false;
            if (dominio.Contains(".-")) return false;

            int punto = dominio.LastIndexOf('.');
            if (punto < 1) return false;

            string terminacion = dominio.Substring(punto + 1);
            if (terminacion.Length < 2) return false;
            foreach (char c in terminacion)
                if (!char.IsLetter(c)) return false;

            return true;
        }
    }
}
