using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Ventana principal con el menú
    public partial class FrmMain : Form
    {

        private Usuario usuarioActual;

        public bool CerroSesion = false;

        public FrmMain(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            Ventanas.PonerIcono(this);
            Tema.Aplicar(this);
            MostrarUsuario();
            MostrarMenu();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToString("dddd d 'de' MMMM 'de' yyyy");
            AbrirFormulario(new FrmInicio(), navInicio);
        }

        private Guna2Button[] BotonesMenu()
        {
            return new Guna2Button[] { navInicio, navContratos, navEquipos, navMantenimientos,
                                       navRepuestos, navClientes, navUsuarios, navRoles, navBitacora };
        }

        private void MostrarUsuario()
        {
            lblUsuario.Text = usuarioActual.Nombre;
            lblRol.Text = usuarioActual.Rol;
            if (Sesion.EsCliente) lblRol.Text = "Cliente corporativo";
        }

        private bool Alguno(string permisoA, string permisoB)
        {
            if (Sesion.Puede(permisoA)) return true;
            return Sesion.Puede(permisoB);
        }

        // el botón solo aparece si el rol tiene el permiso
        private void MostrarMenu()
        {
            navContratos.Visible = Alguno(Permisos.ContratosVer, Permisos.ContratosGestionar);
            navEquipos.Visible = Alguno(Permisos.EquiposVer, Permisos.EquiposGestionar);
            navRepuestos.Visible = Alguno(Permisos.RepuestosVer, Permisos.RepuestosGestionar);
            navClientes.Visible = Sesion.Puede(Permisos.ClientesGestionar);
            navUsuarios.Visible = Sesion.Puede(Permisos.UsuariosGestionar);
            navRoles.Visible = Sesion.Puede(Permisos.UsuariosGestionar);
            navBitacora.Visible = Sesion.Puede(Permisos.BitacoraVer);

            navMantenimientos.Visible = Alguno(Permisos.MantenimientosVer, Permisos.MantenimientosGestionar);
            if (Sesion.Puede(Permisos.HojasRegistrar)) navMantenimientos.Visible = true;

            navContratos.Text = "Contratos";
            navEquipos.Text = "Equipos";
            navMantenimientos.Text = "Mantenimientos";

            if (Sesion.EsIngeniero) navMantenimientos.Text = "Mis visitas";

            if (Sesion.EsCliente)
            {
                navContratos.Text = "Mis contratos";
                navEquipos.Text = "Mis equipos";
                navMantenimientos.Text = "Historial de mantenimiento";
            }
        }

        private void Expulsar(string motivo)
        {
            Mensajes.Aviso(motivo + "\nLa sesión se cerrará.");
            Sesion.Cerrar();
            CerroSesion = true;
            Close();
        }

        // se vuelve a leer el usuario por si lo desactivaron o le cambiaron los permisos
        private bool SesionVigente()
        {
            Usuario fresco;
            try
            {
                fresco = UsuarioDatos.Buscar(usuarioActual.IdUsuario);
                if (fresco != null) Sesion.Iniciar(fresco);
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
                return false;
            }

            if (fresco == null)
            {
                Expulsar("Tu usuario ya no existe.");
                return false;
            }

            if (!fresco.Activo)
            {
                Expulsar("Tu usuario fue desactivado por un administrador.");
                return false;
            }

            usuarioActual = fresco;
            MostrarUsuario();
            MostrarMenu();
            return true;
        }

        public void AbrirFormulario(Form formulario, Guna2Button botonActivo)
        {
            while (pnlContenido.Controls.Count > 0)
                pnlContenido.Controls[0].Dispose();

            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formulario);
            formulario.Show();

            lblTitulo.Text = botonActivo.Text;
            EstiloBotones.MarcarEstado(BotonesMenu(), botonActivo);
        }

        private void nav_Click(object sender, EventArgs e)
        {
            if (!SesionVigente()) return;

            Guna2Button boton = (Guna2Button)sender;
            if (!boton.Visible)
            {
                Mensajes.Info("Un administrador cambió los permisos de tu rol.\nYa se actualizaron en tu sesión.");
                AbrirFormulario(new FrmInicio(), navInicio);
                return;
            }

            if (sender == navInicio) AbrirFormulario(new FrmInicio(), navInicio);
            if (sender == navContratos) AbrirFormulario(new FrmContratos(), navContratos);
            if (sender == navEquipos) AbrirFormulario(new FrmEquipos(), navEquipos);
            if (sender == navMantenimientos) AbrirFormulario(new FrmMantenimientos(), navMantenimientos);
            if (sender == navRepuestos) AbrirFormulario(new FrmRepuestos(), navRepuestos);
            if (sender == navClientes) AbrirFormulario(new FrmClientes(), navClientes);
            if (sender == navUsuarios) AbrirFormulario(new FrmUsuarios(), navUsuarios);
            if (sender == navRoles) AbrirFormulario(new FrmRoles(), navRoles);
            if (sender == navBitacora) AbrirFormulario(new FrmBitacora(), navBitacora);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!Mensajes.Confirmar("¿Cerrar la sesión de " + usuarioActual.Nombre + "?")) return;

            RegistroActividadDatos.Registrar("Cerró sesión");
            Sesion.Cerrar();
            CerroSesion = true;
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CerroSesion) return;
            if (e.CloseReason != CloseReason.UserClosing) return;

            if (!Mensajes.Confirmar("¿Salir de SIGMA?"))
            {
                e.Cancel = true;
                return;
            }

            RegistroActividadDatos.Registrar("Cerró sesión");
            Sesion.Cerrar();
        }
    }
}
