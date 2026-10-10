using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Aquí el administrador pone los permisos de cada rol
    public partial class FrmRoles : Form
    {
        private Rol rolElegido = null;

        private Rol[] roles = new Rol[0];
        private Permiso[] permisos = new Permiso[0];

        public FrmRoles()
        {
            InitializeComponent();
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            ConfigurarGrids();
            CargarRoles();

            if (roles.Length > 0) ElegirRol(roles[0]);
        }

        private void ConfigurarGrids()
        {
            dgvRoles.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvRoles, "Id");
            EstiloGrid.Columna(dgvRoles, "Rol", "Rol", 34);
            EstiloGrid.Columna(dgvRoles, "Descripcion", "Para qué sirve", 50);
            EstiloGrid.Columna(dgvRoles, "Usuarios", "Usuarios", 16);
            dgvRoles.RowTemplate.Height = 58;
            dgvRoles.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvPermisos.Columns.Clear();
            dgvPermisos.RowTemplate.Height = 32;
            EstiloGrid.ColumnaOculta(dgvPermisos, "Id");

            DataGridViewCheckBoxColumn marca = new DataGridViewCheckBoxColumn();
            marca.Name = "Tiene";
            marca.HeaderText = "Tiene";
            marca.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            marca.Width = 60;
            dgvPermisos.Columns.Add(marca);

            EstiloGrid.ColumnaFija(dgvPermisos, "Modulo", "Módulo", 140);
            EstiloGrid.Columna(dgvPermisos, "Permiso", "Permiso", 100);
        }

        private void CargarRoles()
        {
            dgvRoles.Rows.Clear();

            try
            {
                roles = RolDatos.Listar();
                permisos = PermisoDatos.Listar();

                foreach (Rol r in roles)
                    dgvRoles.Rows.Add(r.IdRol, r.Nombre, r.Descripcion, r.Usuarios);
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvRoles.Rows[e.RowIndex].Cells["Id"].Value);
            foreach (Rol r in roles)
                if (r.IdRol == id) ElegirRol(r);
        }

        private bool EsAdministrador()
        {
            if (rolElegido == null) return false;
            return rolElegido.IdRol == Rol.IdAdministrador;
        }

        private void ElegirRol(Rol rol)
        {
            rolElegido = rol;
            lblPermisos.Text = "Permisos del rol " + rol.Nombre;
            dgvPermisos.Rows.Clear();

            try
            {
                int[] asignados = PermisoDatos.IdsDeRol(rol.IdRol);

                foreach (Permiso p in permisos)
                {
                    bool tiene = Array.IndexOf(asignados, p.IdPermiso) >= 0;
                    dgvPermisos.Rows.Add(p.IdPermiso, tiene, p.Modulo, p.Nombre);
                }
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }

            dgvPermisos.ClearSelection();

            // los permisos del administrador no se pueden cambiar
            bool editable = !EsAdministrador();
            btnGuardar.Enabled = editable;
            btnMarcar.Enabled = editable;
            btnQuitar.Enabled = editable;

            lblPermisosNota.Text = "Haz clic en una fila para dar o quitar el permiso y después guarda.";
            if (!editable) lblPermisosNota.Text = "El Administrador siempre tiene todos los permisos; no se pueden cambiar.";
        }

        // con el clic en la fila se marca o se desmarca el permiso
        private void dgvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (EsAdministrador())
            {
                Mensajes.Info(PermisoDatos.AdministradorCompleto);
                return;
            }

            DataGridViewCell casilla = dgvPermisos.Rows[e.RowIndex].Cells["Tiene"];
            casilla.Value = !Convert.ToBoolean(casilla.Value);
        }

        private void MarcarTodos(bool valor)
        {
            foreach (DataGridViewRow fila in dgvPermisos.Rows)
                fila.Cells["Tiene"].Value = valor;
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            MarcarTodos(true);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            MarcarTodos(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.UsuariosGestionar))
            {
                Mensajes.SinPermiso("cambiar los permisos de los roles");
                return;
            }

            if (rolElegido == null)
            {
                Mensajes.Info("Elige primero un rol.");
                return;
            }

            int marcados = 0;
            foreach (DataGridViewRow fila in dgvPermisos.Rows)
                if (Convert.ToBoolean(fila.Cells["Tiene"].Value)) marcados++;

            int[] ids = new int[marcados];
            int i = 0;
            foreach (DataGridViewRow fila in dgvPermisos.Rows)
            {
                if (!Convert.ToBoolean(fila.Cells["Tiene"].Value)) continue;
                ids[i] = Convert.ToInt32(fila.Cells["Id"].Value);
                i++;
            }

            if (marcados == 0)
            {
                if (!Mensajes.Confirmar("El rol " + rolElegido.Nombre + " quedará sin ningún permiso:\n" +
                                        "sus usuarios solo verán la pantalla de inicio. ¿Continuar?")) return;
            }

            try
            {
                PermisoDatos.GuardarDeRol(rolElegido.IdRol, ids);
                RegistroActividadDatos.Registrar("Cambió los permisos del rol " + rolElegido.Nombre + " (" + marcados + " permisos)");
                Mensajes.Info("Permisos del rol " + rolElegido.Nombre + " guardados.\n" +
                              "Los usuarios de ese rol los reciben al abrir su siguiente pantalla.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudieron guardar los permisos.", ex);
            }
        }
    }
}
