using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // CRUD de clientes
    public partial class FrmClientes : Form
    {
        private int editId = 0;

        private Cliente[] cargados = new Cliente[0];

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            ConfigurarGrid();
            CargarDatos("");
            LimpiarFormulario();
        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void soloTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloTelefono(e);
        }

        private void ConfigurarGrid()
        {
            dgvClientes.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvClientes, "Id");
            EstiloGrid.Columna(dgvClientes, "Nombre", "Empresa", 55);
            EstiloGrid.ColumnaFija(dgvClientes, "Nit", "NIT", 140);
            EstiloGrid.Columna(dgvClientes, "Contacto", "Contacto", 45);
            EstiloGrid.ColumnaFija(dgvClientes, "Telefono", "Teléfono", 92);
        }

        private void CargarDatos(string filtro)
        {
            dgvClientes.Rows.Clear();
            filtro = filtro.Trim().ToLower();

            try
            {
                cargados = ClienteDatos.Listar();

                foreach (Cliente c in cargados)
                {
                    if (!Filtro.Coincide(filtro, c.Nombre, c.Nit, c.Contacto, c.Telefono, c.Correo)) continue;
                    dgvClientes.Rows.Add(c.IdCliente, c.Nombre, c.Nit, c.Contacto, c.Telefono);
                }

                dgvClientes.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvClientes.Rows.Count + " de " + cargados.Length + " clientes";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Cliente Cargado(int id)
        {
            foreach (Cliente c in cargados)
                if (c.IdCliente == id) return c;
            return null;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Cliente c = Cargado(Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Id"].Value));
            if (c == null) return;

            avisos.Clear();
            editId = c.IdCliente;
            lblFormTitulo.Text = "Editar cliente " + c.Codigo;
            btnGuardar.Text = "GUARDAR CAMBIOS";

            txtNombre.Text = c.Nombre;
            txtNit.Text = c.Nit;
            txtTelefono.Text = c.Telefono;
            txtContacto.Text = c.Contacto;
            txtCorreo.Text = c.Correo;
            txtDireccion.Text = c.Direccion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.ClientesGestionar))
            {
                Mensajes.SinPermiso("modificar los clientes");
                return;
            }

            avisos.Clear();

            string nombre = Textos.Limpiar(txtNombre.Text);
            string contacto = Textos.Limpiar(txtContacto.Text);
            string correo = txtCorreo.Text.Trim().ToLower();
            string direccion = Textos.Limpiar(txtDireccion.Text);

            if (!Validaciones.EsNombre(nombre))
            {
                Validaciones.Invalido(avisos, txtNombre, "ERR-VAL-001", "Escribe el nombre de la empresa (al menos 3 letras).");
                return;
            }

            if (!Validaciones.EsNit(txtNit.Text))
            {
                Validaciones.Invalido(avisos, txtNit, "ERR-VAL-002", "El NIT tiene 14 dígitos, con este formato: 0614-150395-102-4.");
                return;
            }

            if (!Validaciones.EsTelefono(txtTelefono.Text))
            {
                Validaciones.Invalido(avisos, txtTelefono, "ERR-VAL-002", "El teléfono tiene 8 dígitos y empieza con 2, 6 o 7. Ejemplo: 2245-8800.");
                return;
            }

            if (!Validaciones.EsNombre(contacto))
            {
                Validaciones.Invalido(avisos, txtContacto, "ERR-VAL-001", "Escribe el nombre de la persona de contacto.");
                return;
            }

            if (correo.Length > 0)
            {
                if (!Validaciones.EsCorreo(correo))
                {
                    Validaciones.Invalido(avisos, txtCorreo, "ERR-VAL-002", "El correo no tiene un formato válido. Ejemplo: nombre@empresa.com");
                    return;
                }
            }

            if (direccion.Length < 5)
            {
                Validaciones.Invalido(avisos, txtDireccion, "ERR-VAL-001", "Escribe la dirección de la empresa.");
                return;
            }

            string nit = Validaciones.NormalizarNit(txtNit.Text);

            try
            {
                if (ClienteDatos.Existe("Nombre", nombre, editId))
                {
                    Validaciones.Invalido(avisos, txtNombre, "ERR-SQL-002", "Ya existe un cliente llamado \"" + nombre + "\".");
                    return;
                }

                if (ClienteDatos.Existe("Nit", nit, editId))
                {
                    Validaciones.Invalido(avisos, txtNit, "ERR-SQL-002", "Ya existe un cliente con el NIT " + nit + ".");
                    return;
                }

                Cliente c = new Cliente();
                c.IdCliente = editId;
                c.Nombre = nombre;
                c.Nit = nit;
                c.Telefono = Validaciones.NormalizarTelefono(txtTelefono.Text);
                c.Contacto = contacto;
                c.Correo = correo;
                c.Direccion = direccion;

                string accion = "Registró";
                if (editId > 0)
                {
                    ClienteDatos.Actualizar(c);
                    accion = "Editó";
                }
                else
                {
                    ClienteDatos.Insertar(c);
                }

                RegistroActividadDatos.Registrar(accion + " el cliente " + nombre);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Cliente guardado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar el cliente.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.ClientesGestionar))
            {
                Mensajes.SinPermiso("eliminar clientes");
                return;
            }

            Cliente c = Cargado(editId);
            if (c == null)
            {
                Mensajes.Info("Selecciona primero un cliente de la tabla.");
                return;
            }

            if (!Mensajes.Confirmar("¿Eliminar el cliente \"" + c.Nombre + "\"?")) return;

            try
            {
                ClienteDatos.Eliminar(c.IdCliente);
                RegistroActividadDatos.Registrar("Eliminó el cliente " + c.Nombre);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Cliente eliminado.");
            }
            catch (Exception ex)
            {
                Mensajes.Aviso("No se pudo eliminar el cliente.\n" +
                    "Si tiene contratos o usuarios, primero hay que eliminarlos o moverlos.\n\n" + Mensajes.Explicar(ex));
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
            lblFormTitulo.Text = "Nuevo cliente";
            btnGuardar.Text = "GUARDAR";

            txtNombre.Clear();
            txtNit.Clear();
            txtTelefono.Clear();
            txtContacto.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            dgvClientes.ClearSelection();
        }
    }
}
