using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Formularios;
using Vista.Utilidades;

namespace Vista
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(ErrorEnUnaAccion);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorGrave);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FijarCultura();

            // si cierra sesión vuelve al login
            bool seguir = true;
            while (seguir)
            {
                Usuario usuario;
                using (FrmLogin login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                    usuario = login.UsuarioActual;
                }

                FrmMain principal = new FrmMain(usuario);
                Application.Run(principal);

                seguir = principal.CerroSesion;
            }
        }

        private static void FijarCultura()
        {
            CultureInfo cultura = new CultureInfo("es-SV", false);
            cultura.NumberFormat.NumberDecimalSeparator = ".";
            cultura.NumberFormat.NumberGroupSeparator = ",";
            cultura.NumberFormat.CurrencyDecimalSeparator = ".";
            cultura.NumberFormat.CurrencyGroupSeparator = ",";
            cultura.DateTimeFormat.AMDesignator = "AM";
            cultura.DateTimeFormat.PMDesignator = "PM";

            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
        }

        private static void ErrorEnUnaAccion(object sender, ThreadExceptionEventArgs e)
        {
            Mensajes.Error(Errores.Mensaje("ERR-APP-001") + "\n\nCódigo del error: ERR-APP-001");
        }

        private static void ErrorGrave(object sender, UnhandledExceptionEventArgs e)
        {
            Mensajes.Error(Errores.Mensaje("ERR-APP-002") + "\n\nCódigo del error: ERR-APP-002");
        }
    }
}
