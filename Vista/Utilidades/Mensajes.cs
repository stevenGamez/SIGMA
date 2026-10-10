using System;
using System.Windows.Forms;
using Modelo.Modelo;

namespace Vista.Utilidades
{

    // Todos los MessageBox del programa
    public static class Mensajes
    {
        private const string Titulo = "SIGMA";

        public static void Info(string texto)
        {
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string texto)
        {
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string texto)
        {
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string pregunta)
        {
            DialogResult r = MessageBox.Show(pregunta, Titulo,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return r == DialogResult.Yes;
        }

        public static void SinConexion(Exception ex)
        {
            Aviso(Explicar(ex));
        }

        // si el error ya trae su código se muestra tal cual
        public static string Explicar(Exception ex)
        {
            if (ex.Message.Contains("Código del error:")) return ex.Message;
            return Errores.Mensaje("ERR-APP-001") + "\n\nCódigo del error: ERR-APP-001";
        }

        public static void Fallo(string que, Exception ex)
        {
            Error(que + "\n\n" + Explicar(ex));
        }

        public static void SinPermiso(string accion)
        {
            Info("Tu rol no tiene permiso para " + accion + ".\n" +
                 "Pide a un administrador que te habilite ese permiso.");
        }
    }
}
