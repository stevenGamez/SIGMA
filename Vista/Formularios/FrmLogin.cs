using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{
    public partial class FrmLogin : Form
    {

        public Usuario UsuarioActual;

        private int intentosFallidos = 0;
        private const int IntentosPermitidos = 5;
        private int segundosEspera = 0;
        private const int SegundosDeBloqueo = 30;

        public FrmLogin()
        {
            InitializeComponent();
            Ventanas.PonerIcono(this);
            Tema.Aplicar(this);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void Entrar()
        {
            if (segundosEspera > 0) return;

            string usuario = txtUsuario.Text.Trim().ToLower();
            string clave = txtClave.Text;

            avisos.SetError(txtUsuario, "");
            avisos.SetError(txtClave, "");

            if (usuario.Length == 0)
            {
                avisos.SetError(txtUsuario, Errores.Mensaje("ERR-VAL-001"));
                Mensajes.Info("Escribe tu usuario.");
                txtUsuario.Focus();
                return;
            }

            if (clave.Length == 0)
            {
                avisos.SetError(txtClave, Errores.Mensaje("ERR-VAL-001"));
                Mensajes.Info("Escribe tu contraseña.");
                txtClave.Focus();
                return;
            }

            Usuario u;
            try
            {
                u = UsuarioDatos.BuscarPorNombreUsuario(usuario);
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
                return;
            }

            // no se dice si falló el usuario o la contraseña
            if (u == null)
            {
                DatosIncorrectos();
                return;
            }

            // BCrypt compara la contraseña con el hash guardado
            if (!Clave.Coincide(clave, u.Contrasena))
            {
                DatosIncorrectos();
                return;
            }

            if (!u.Activo)
            {
                Mensajes.Info("Ese usuario está inactivo. Pide al administrador que lo active.");
                return;
            }

            try
            {
                Sesion.Iniciar(u);
                UsuarioDatos.AnotarAcceso(u.IdUsuario);
            }
            catch (Exception ex)
            {
                Sesion.Cerrar();
                Mensajes.SinConexion(ex);
                return;
            }

            intentosFallidos = 0;
            UsuarioActual = u;
            RegistroActividadDatos.Registrar("Inició sesión");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DatosIncorrectos()
        {
            intentosFallidos++;
            if (intentosFallidos >= IntentosPermitidos) Bloquear();

            avisos.SetError(txtClave, Errores.Mensaje("ERR-VAL-002"));
            Mensajes.Info("Usuario o contraseña incorrectos.");
            txtClave.Clear();
            txtClave.Focus();
        }

        // a los 5 intentos se bloquea 30 segundos
        private void Bloquear()
        {
            segundosEspera = SegundosDeBloqueo;
            btnEntrar.Enabled = false;
            MostrarEspera();
            lblEspera.Visible = true;
            reloj.Start();
        }

        private void MostrarEspera()
        {
            lblEspera.Text = "Demasiados intentos fallidos. Espera " + segundosEspera + " segundos.";
            if (segundosEspera == 1) lblEspera.Text = "Demasiados intentos fallidos. Espera 1 segundo.";
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            segundosEspera--;
            if (segundosEspera > 0)
            {
                MostrarEspera();
                return;
            }

            reloj.Stop();
            intentosFallidos = 0;
            lblEspera.Visible = false;
            btnEntrar.Enabled = true;
        }

        private void chkVer_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkVer.Checked;
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
