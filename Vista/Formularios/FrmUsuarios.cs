using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // CRUD de usuarios
    public partial class FrmUsuarios : Form
    {
        private int editId = 0;

        private Usuario[] cargados = new Usuario[0];

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            ConfigurarGrid();
            CargarCombos();
            CargarDatos("");
            LimpiarFormulario();
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void soloUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNombreUsuario(e);
        }

        private void CargarCombos()
        {
            try
            {
                Combos.Llenar(cboRol, RolDatos.Listar());
                Combos.Llenar(cboCliente, ClienteDatos.Listar());
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }
        }

        private void ConfigurarGrid()
        {
            dgvUsuarios.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvUsuarios, "Id");
            EstiloGrid.ColumnaFija(dgvUsuarios, "Usuario", "Usuario", 100);
            EstiloGrid.Columna(dgvUsuarios, "Nombre", "Nombre completo", 100);
            EstiloGrid.ColumnaFija(dgvUsuarios, "Rol", "Rol", 138);
            EstiloGrid.ColumnaFija(dgvUsuarios, "Estado", "Estado", 78);
            EstiloGrid.ColumnaFija(dgvUsuarios, "Acceso", "Último acceso", 146);
        }

        private void CargarDatos(string filtro)
        {
            dgvUsuarios.Rows.Clear();
            filtro = filtro.Trim().ToLower();

            try
            {
                cargados = UsuarioDatos.Listar();

                foreach (Usuario u in cargados)
                {
                    if (!Filtro.Coincide(filtro, u.NombreUsuario, u.Nombre, u.Rol, u.Cliente)) continue;

                    string estado = "Inactivo";
                    if (u.Activo) estado = "Activo";

                    string acceso = "Nunca";
                    if (u.UltimoAcceso != null) acceso = u.UltimoAcceso.Value.ToString("dd/MM/yyyy hh:mm tt");

                    dgvUsuarios.Rows.Add(u.IdUsuario, u.NombreUsuario, u.Nombre, u.Rol, estado, acceso);
                }

                dgvUsuarios.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvUsuarios.Rows.Count + " de " + cargados.Length + " usuarios";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Usuario Cargado(int id)
        {
            foreach (Usuario u in cargados)
                if (u.IdUsuario == id) return u;
            return null;
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Usuario u = Cargado(Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["Id"].Value));
            if (u == null) return;

            avisos.Clear();
            editId = u.IdUsuario;
            lblFormTitulo.Text = "Editar usuario";
            btnGuardar.Text = "GUARDAR CAMBIOS";

            txtNombre.Text = u.Nombre;
            txtUsuario.Text = u.NombreUsuario;
            Combos.Seleccionar(cboRol, u.Rol);
            txtCorreo.Text = u.Correo;
            if (u.IdCliente > 0) Combos.Seleccionar(cboCliente, u.Cliente);
            chkActivo.Checked = u.Activo;

            lblClave.Text = "CONTRASEÑA NUEVA";
            txtClave.Clear();
            txtClave.PlaceholderText = "dejar vacío para no cambiarla";
        }

        // la empresa solo se usa con el rol de cliente
        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCliente.Enabled = Combos.Texto(cboRol) == Rol.ClienteCorporativo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.UsuariosGestionar))
            {
                Mensajes.SinPermiso("gestionar usuarios");
                return;
            }

            avisos.Clear();

            string nombre = Textos.Limpiar(txtNombre.Text);
            string nombreUsuario = txtUsuario.Text.Trim().ToLower();
            string correo = txtCorreo.Text.Trim().ToLower();
            string clave = txtClave.Text;

            if (!Validaciones.EsNombre(nombre))
            {
                Validaciones.Invalido(avisos, txtNombre, "ERR-VAL-001", "Escribe el nombre completo del usuario.");
                return;
            }

            if (!UsuarioDatos.EsNombreUsuarioValido(nombreUsuario))
            {
                Validaciones.Invalido(avisos, txtUsuario, "ERR-VAL-002", "El usuario lleva al menos 4 caracteres: letras minúsculas, números, punto o guion bajo.");
                return;
            }

            Rol rol = cboRol.SelectedItem as Rol;
            if (rol == null)
            {
                Validaciones.Invalido(avisos, cboRol, "ERR-VAL-001", "Elige el rol del usuario.");
                return;
            }

            if (correo.Length > 0 && !Validaciones.EsCorreo(correo))
            {
                Validaciones.Invalido(avisos, txtCorreo, "ERR-VAL-002", "El correo no tiene un formato válido. Ejemplo: nombre@empresa.com");
                return;
            }

            // el cliente corporativo tiene que llevar su empresa
            int idCliente = 0;
            if (rol.Nombre == Rol.ClienteCorporativo)
            {
                Cliente cliente = cboCliente.SelectedItem as Cliente;
                if (cliente == null)
                {
                    Validaciones.Invalido(avisos, cboCliente, "ERR-VAL-001", "Un cliente corporativo necesita su empresa.\nSi la lista está vacía, primero registra el cliente.");
                    return;
                }
                idCliente = cliente.IdCliente;
            }

            // al crear es obligatoria, al editar solo si escribieron una nueva
            bool cambiaClave = clave.Length > 0;
            if (editId == 0) cambiaClave = true;

            if (cambiaClave && !Clave.EsSegura(clave))
            {
                Validaciones.Invalido(avisos, txtClave, "ERR-VAL-002", "La contraseña lleva al menos " + Clave.LargoMinimo + " caracteres, con letras y números.");
                return;
            }

            if (editId == Sesion.Actual.IdUsuario)
            {
                bool cambiaRol = rol.IdRol != Sesion.Actual.IdRol;
                if (cambiaRol || !chkActivo.Checked)
                {
                    Mensajes.Aviso("No puedes desactivar tu propio usuario ni cambiar tu propio rol.\nPídeselo a otro administrador.");
                    return;
                }
            }

            try
            {
                if (UsuarioDatos.Existe(nombreUsuario, editId))
                {
                    Validaciones.Invalido(avisos, txtUsuario, "ERR-SQL-002", "Ya existe el usuario \"" + nombreUsuario + "\". Elige otro.");
                    return;
                }

                Usuario u = new Usuario();
                u.IdUsuario = editId;
                u.Nombre = nombre;
                u.NombreUsuario = nombreUsuario;
                u.IdRol = rol.IdRol;
                u.IdCliente = idCliente;
                u.Correo = correo;
                u.Activo = chkActivo.Checked;

                string accion = "Creó";
                if (editId > 0)
                {
                    UsuarioDatos.Actualizar(u);
                    if (cambiaClave) UsuarioDatos.CambiarClave(editId, Clave.Cifrar(clave));
                    accion = "Editó";
                }
                else
                {
                    // se guarda encriptada con BCrypt
                    u.Contrasena = Clave.Cifrar(clave);
                    UsuarioDatos.Insertar(u);
                }

                RegistroActividadDatos.Registrar(accion + " el usuario " + nombreUsuario + " con el rol " + rol.Nombre);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Usuario guardado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar el usuario.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.UsuariosGestionar))
            {
                Mensajes.SinPermiso("eliminar usuarios");
                return;
            }

            Usuario u = Cargado(editId);
            if (u == null)
            {
                Mensajes.Info("Selecciona primero un usuario de la tabla.");
                return;
            }

            if (u.IdUsuario == Sesion.Actual.IdUsuario)
            {
                Mensajes.Aviso("No puedes eliminar tu propio usuario.");
                return;
            }

            if (!Mensajes.Confirmar("¿Eliminar el usuario \"" + u.NombreUsuario + "\" (" + u.Nombre + ")?")) return;

            try
            {
                UsuarioDatos.Eliminar(u.IdUsuario);
                RegistroActividadDatos.Registrar("Eliminó el usuario " + u.NombreUsuario);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Usuario eliminado.");
            }
            catch (Exception ex)
            {
                Mensajes.Aviso("No se pudo eliminar el usuario.\n\n" + Mensajes.Explicar(ex));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtNombre.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBuscar.Text);
        }

        private void LimpiarFormulario()
        {
            avisos.Clear();
            editId = 0;
            lblFormTitulo.Text = "Nuevo usuario";
            btnGuardar.Text = "CREAR USUARIO";

            txtNombre.Clear();
            txtUsuario.Clear();
            Combos.Seleccionar(cboRol, Rol.Ingeniero);
            txtCorreo.Clear();
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            cboCliente.Enabled = Combos.Texto(cboRol) == Rol.ClienteCorporativo;
            chkActivo.Checked = true;

            lblClave.Text = "CONTRASEÑA *";
            txtClave.Clear();
            txtClave.PlaceholderText = "mínimo 8, con letras y números";
            dgvUsuarios.ClearSelection();
        }
    }
}
