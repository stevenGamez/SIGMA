using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // CRUD de contratos, el cliente solo ve los suyos
    public partial class FrmContratos : Form
    {
        private int editId = 0;
        private bool puedeGestionar = false;

        private Contrato[] cargados = new Contrato[0];

        public FrmContratos()
        {
            InitializeComponent();
        }

        private void FrmContratos_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            puedeGestionar = Sesion.Puede(Permisos.ContratosGestionar);
            ConfigurarGrid();

            if (puedeGestionar) CargarCombos();
            else Ventanas.SoloLectura(this, pnlTabla, pnlForm);

            if (Sesion.EsCliente) lblTitulo.Text = "Contratos de " + Sesion.Actual.Cliente;

            CargarDatos("");
            LimpiarFormulario();
        }

        private void soloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloDecimal((Guna2TextBox)sender, e);
        }

        private void CargarCombos()
        {
            Combos.Llenar(cboFrecuencia, Contrato.Frecuencias);
            Combos.Llenar(cboEstado, Contrato.Estados);

            try
            {
                Combos.Llenar(cboCliente, ClienteDatos.Listar());
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }
        }

        private void ConfigurarGrid()
        {
            dgvContratos.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvContratos, "Id");
            EstiloGrid.ColumnaFija(dgvContratos, "Codigo", "Código", 78);
            EstiloGrid.Columna(dgvContratos, "Cliente", "Cliente", 100);
            EstiloGrid.ColumnaFija(dgvContratos, "Inicio", "Inicio", 92);
            EstiloGrid.ColumnaFija(dgvContratos, "Fin", "Fin", 92);
            EstiloGrid.ColumnaFija(dgvContratos, "Frecuencia", "Visitas", 96);
            EstiloGrid.ColumnaFija(dgvContratos, "Monto", "Mensual", 90);
            EstiloGrid.ColumnaFija(dgvContratos, "Equipos", "Equipos", 76);
            EstiloGrid.ColumnaFija(dgvContratos, "Estado", "Estado", 98);

            // se ocultan estas columnas para que quepa la tabla
            if (puedeGestionar)
            {
                dgvContratos.Columns["Frecuencia"].Visible = false;
                dgvContratos.Columns["Equipos"].Visible = false;
            }
        }

        private void CargarDatos(string filtro)
        {
            dgvContratos.Rows.Clear();
            filtro = filtro.Trim().ToLower();

            try
            {
                // el cliente solo ve los contratos de su empresa
                cargados = ContratoDatos.Listar(Sesion.ClienteVisible);

                foreach (Contrato c in cargados)
                {
                    if (!Filtro.Coincide(filtro, c.Codigo, c.Cliente, c.Frecuencia, c.Estado)) continue;

                    dgvContratos.Rows.Add(c.IdContrato, c.Codigo, c.Cliente,
                                          c.FechaInicio.ToString("dd/MM/yyyy"), c.FechaFin.ToString("dd/MM/yyyy"),
                                          c.Frecuencia, "$" + c.MontoMensual.ToString("N2"), c.Equipos, c.Estado);
                }

                dgvContratos.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvContratos.Rows.Count + " de " + cargados.Length + " contratos";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Contrato Cargado(int id)
        {
            foreach (Contrato c in cargados)
                if (c.IdContrato == id) return c;
            return null;
        }

        private void dgvContratos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvContratos.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!puedeGestionar) return;

            Contrato c = Cargado(Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells["Id"].Value));
            if (c == null) return;

            avisos.Clear();
            editId = c.IdContrato;
            lblFormTitulo.Text = "Editar contrato " + c.Codigo;
            btnGuardar.Text = "GUARDAR CAMBIOS";

            Combos.Seleccionar(cboCliente, c.Cliente);
            dtpInicio.Value = c.FechaInicio;
            dtpFin.Value = c.FechaFin;
            Combos.Seleccionar(cboFrecuencia, c.Frecuencia);
            txtMonto.Text = c.MontoMensual.ToString("0.00");
            Combos.Seleccionar(cboEstado, c.Estado);
            txtDescripcion.Text = c.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.ContratosGestionar))
            {
                Mensajes.SinPermiso("modificar los contratos");
                return;
            }

            avisos.Clear();

            Cliente cliente = cboCliente.SelectedItem as Cliente;
            if (cliente == null)
            {
                Validaciones.Invalido(avisos, cboCliente, "ERR-VAL-001", "Elige el cliente.\nSi la lista está vacía, primero registra un cliente en el módulo Clientes.");
                return;
            }

            DateTime inicio = dtpInicio.Value.Date;
            DateTime fin = dtpFin.Value.Date;
            if (fin <= inicio)
            {
                Validaciones.Invalido(avisos, dtpFin, "ERR-VAL-003", "La fecha de fin tiene que ser posterior a la fecha de inicio.");
                return;
            }

            decimal monto;
            decimal.TryParse(txtMonto.Text.Trim(), out monto);
            monto = Math.Round(monto, 2);
            if (monto <= 0)
            {
                Validaciones.Invalido(avisos, txtMonto, "ERR-VAL-003", "Escribe el monto mensual del contrato (mayor que cero).");
                return;
            }

            if (monto > Contrato.MontoMaximo)
            {
                Validaciones.Invalido(avisos, txtMonto, "ERR-VAL-003", "El monto mensual no puede pasar de $" + Contrato.MontoMaximo.ToString("N2") + ".");
                return;
            }

            string estado = Combos.Texto(cboEstado);
            if (estado == "Vigente")
            {
                if (fin < DateTime.Today)
                {
                    Validaciones.Invalido(avisos, cboEstado, "ERR-VAL-002", "La fecha de fin ya pasó: el contrato no puede quedar Vigente.\nCambia el estado a Finalizado o amplía la fecha de fin.");
                    return;
                }
            }

            Contrato c = new Contrato();
            c.IdContrato = editId;
            c.IdCliente = cliente.IdCliente;
            c.FechaInicio = inicio;
            c.FechaFin = fin;
            c.Frecuencia = Combos.Texto(cboFrecuencia);
            c.MontoMensual = monto;
            c.Estado = estado;
            c.Descripcion = Textos.Limpiar(txtDescripcion.Text);

            try
            {
                string accion = "Registró";
                if (editId > 0)
                {
                    ContratoDatos.Actualizar(c);
                    accion = "Editó";
                }
                else
                {
                    c.IdContrato = ContratoDatos.Insertar(c);
                }

                RegistroActividadDatos.Registrar(accion + " el contrato " + c.Codigo + " de " + cliente.Nombre);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Contrato " + c.Codigo + " guardado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar el contrato.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.ContratosGestionar))
            {
                Mensajes.SinPermiso("eliminar contratos");
                return;
            }

            Contrato c = Cargado(editId);
            if (c == null)
            {
                Mensajes.Info("Selecciona primero un contrato de la tabla.");
                return;
            }

            if (c.Equipos > 0)
            {
                Mensajes.Aviso("El contrato " + c.Codigo + " todavía cubre equipos (" + c.Equipos + ").\n" +
                    "Primero elimínalos o pásalos a otro contrato.");
                return;
            }

            if (!Mensajes.Confirmar("¿Eliminar el contrato " + c.Codigo + " de " + c.Cliente + "?")) return;

            try
            {
                ContratoDatos.Eliminar(c.IdContrato);
                RegistroActividadDatos.Registrar("Eliminó el contrato " + c.Codigo + " de " + c.Cliente);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Contrato eliminado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo eliminar el contrato.", ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            cboCliente.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBuscar.Text);
        }

        private void LimpiarFormulario()
        {
            avisos.Clear();
            editId = 0;
            lblFormTitulo.Text = "Nuevo contrato";
            btnGuardar.Text = "GUARDAR";

            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today.AddYears(1);
            Combos.Seleccionar(cboFrecuencia, "Trimestral");
            txtMonto.Clear();
            Combos.Seleccionar(cboEstado, "Vigente");
            txtDescripcion.Clear();
            dgvContratos.ClearSelection();
        }
    }
}
