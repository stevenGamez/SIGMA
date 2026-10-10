using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Hoja de servicio de la visita, la llena el ingeniero
    public partial class FrmHojaServicio : Form
    {
        private int idMantenimiento;
        private Mantenimiento visita;
        private bool editable = false;

        private Repuesto[] inventario = new Repuesto[0];

        // repuestos que ya tenía guardados la hoja
        private RepuestoUsado[] originales = new RepuestoUsado[0];

        public bool Guardo = false;

        public FrmHojaServicio(int idMantenimiento)
        {
            InitializeComponent();
            this.idMantenimiento = idMantenimiento;
        }

        private void FrmHojaServicio_Load(object sender, EventArgs e)
        {
            Ventanas.PonerIcono(this);
            Tema.Aplicar(this);
            ConfigurarGrid();

            try
            {
                visita = MantenimientoDatos.Buscar(idMantenimiento);
                if (visita != null)
                {
                    inventario = RepuestoDatos.Listar();
                    originales = MantenimientoDatos.RepuestosUsados(idMantenimiento);
                }
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
                Close();
                return;
            }

            if (visita == null)
            {
                Mensajes.Aviso("Esa visita ya no existe.");
                Close();
                return;
            }

            MostrarVisita();
            DecidirSiEsEditable();
        }

        private void soloEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloEnteros(e);
        }

        private void ConfigurarGrid()
        {
            dgvRepuestos.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvRepuestos, "IdRepuesto");
            EstiloGrid.ColumnaOculta(dgvRepuestos, "PrecioValor");
            EstiloGrid.Columna(dgvRepuestos, "Repuesto", "Repuesto", 100);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Cantidad", "Cant.", 52);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Precio", "Precio", 68);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Subtotal", "Subtotal", 78);
        }

        private void MostrarVisita()
        {
            Text = "Hoja de servicio " + visita.Codigo;
            lblCodigo.Text = visita.Codigo + " · Mantenimiento " + visita.Tipo.ToLower();
            lblEstadoActual.Text = visita.Estado;
            lblEstadoActual.ForeColor = EstiloGrid.ColorEstado(visita.Estado);
            lblEquipo.Text = "Equipo: " + visita.Equipo;
            lblUbicacion.Text = "Ubicación: " + visita.Ubicacion + " · " + visita.Cliente;
            lblIngeniero.Text = "Ingeniero: " + visita.Ingeniero;
            lblProgramada.Text = "Fecha programada: " + visita.FechaProgramada.ToString("dd/MM/yyyy");

            cboEstado.Items.Add(Mantenimiento.EnProceso);
            cboEstado.Items.Add(Mantenimiento.Completado);
            cboEstado.SelectedIndex = 0;
            if (visita.Estado == Mantenimiento.Completado) cboEstado.SelectedIndex = 1;

            dtpRealizada.Value = DateTime.Today;
            if (visita.FechaRealizada != null) dtpRealizada.Value = visita.FechaRealizada.Value;

            txtDiagnostico.Text = visita.Diagnostico;
            txtTrabajo.Text = visita.TrabajoRealizado;
            txtObservaciones.Text = visita.Observaciones;

            foreach (RepuestoUsado usado in originales)
                AgregarFila(usado.IdRepuesto, usado.Repuesto, usado.Cantidad, usado.PrecioUnitario);

            Combos.Llenar(cboRepuesto, inventario);
            dgvRepuestos.ClearSelection();
            MostrarTotal();
        }

        private void DecidirSiEsEditable()
        {
            string motivo = "";
            editable = Sesion.Puede(Permisos.HojasRegistrar);
            if (!editable) motivo = "Solo consulta: tu rol no registra hojas de servicio.";

            if (editable && Sesion.EsIngeniero && visita.IdIngeniero != Sesion.Actual.IdUsuario)
            {
                editable = false;
                motivo = "Solo consulta: la visita está asignada a otro ingeniero.";
            }

            if (editable && visita.Estado == Mantenimiento.Cancelado)
            {
                editable = false;
                motivo = "Solo consulta: la visita está cancelada.";
            }

            if (editable)
            {
                dtpRealizada.Enabled = Combos.Texto(cboEstado) == Mantenimiento.Completado;
                return;
            }

            lblAviso.Text = motivo;
            cboEstado.Enabled = false;
            dtpRealizada.Enabled = false;
            txtDiagnostico.ReadOnly = true;
            txtTrabajo.ReadOnly = true;
            txtObservaciones.ReadOnly = true;
            btnGuardar.Visible = false;

            // si solo es consulta se quitan los controles para agregar repuestos
            lblRepuesto.Visible = false;
            cboRepuesto.Visible = false;
            lblDisponible.Visible = false;
            lblCantidad.Visible = false;
            txtCantidad.Visible = false;
            btnAgregar.Visible = false;
            btnQuitar.Visible = false;
            dgvRepuestos.Height = dgvRepuestos.Bottom - 50;
            dgvRepuestos.Top = 50;

            ActiveControl = btnCerrar;
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!editable) return;
            dtpRealizada.Enabled = Combos.Texto(cboEstado) == Mantenimiento.Completado;
        }

        private int CantidadOriginal(int idRepuesto)
        {
            foreach (RepuestoUsado usado in originales)
                if (usado.IdRepuesto == idRepuesto) return usado.Cantidad;
            return 0;
        }

        private int Disponibles(Repuesto r)
        {
            return r.Existencia + CantidadOriginal(r.IdRepuesto);
        }

        private void cboRepuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repuesto r = cboRepuesto.SelectedItem as Repuesto;
            if (r == null) return;
            lblDisponible.Text = "Disponibles: " + Disponibles(r) + " · $" + r.PrecioUnitario.ToString("N2") + " cada uno";
        }

        private DataGridViewRow FilaDe(int idRepuesto)
        {
            foreach (DataGridViewRow fila in dgvRepuestos.Rows)
                if (Convert.ToInt32(fila.Cells["IdRepuesto"].Value) == idRepuesto) return fila;
            return null;
        }

        private void AgregarFila(int idRepuesto, string nombre, int cantidad, decimal precio)
        {
            dgvRepuestos.Rows.Add(idRepuesto, precio, nombre, cantidad,
                                  "$" + precio.ToString("N2"), "$" + (cantidad * precio).ToString("N2"));
        }

        private void MostrarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvRepuestos.Rows)
                total += Convert.ToInt32(fila.Cells["Cantidad"].Value) * Convert.ToDecimal(fila.Cells["PrecioValor"].Value);

            lblTotal.Text = "Total en repuestos: $" + total.ToString("N2");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!editable) return;
            avisos.Clear();

            Repuesto r = cboRepuesto.SelectedItem as Repuesto;
            if (r == null)
            {
                Mensajes.Info("No hay repuestos registrados en el inventario.");
                return;
            }

            int cantidad;
            int.TryParse(txtCantidad.Text.Trim(), out cantidad);
            if (cantidad < 1 || cantidad > RepuestoUsado.CantidadMaxima)
            {
                Validaciones.Invalido(avisos, txtCantidad, "ERR-VAL-003", "Escribe la cantidad consumida (de 1 a " + RepuestoUsado.CantidadMaxima + ").");
                return;
            }

            DataGridViewRow fila = FilaDe(r.IdRepuesto);
            int yaEnLaHoja = 0;
            if (fila != null) yaEnLaHoja = Convert.ToInt32(fila.Cells["Cantidad"].Value);

            if (yaEnLaHoja + cantidad > Disponibles(r))
            {
                Validaciones.Invalido(avisos, txtCantidad, "ERR-VAL-003",
                    "No hay existencia suficiente de \"" + r.Nombre + "\".\n" +
                    "Disponibles: " + Disponibles(r) + ". Ya en la hoja: " + yaEnLaHoja + ".");
                return;
            }

            if (fila == null)
            {
                AgregarFila(r.IdRepuesto, r.Nombre, cantidad, r.PrecioUnitario);
            }
            else
            {
                // si ya estaba el repuesto se suma la cantidad
                int nueva = yaEnLaHoja + cantidad;
                decimal precio = Convert.ToDecimal(fila.Cells["PrecioValor"].Value);
                fila.Cells["Cantidad"].Value = nueva;
                fila.Cells["Subtotal"].Value = "$" + (nueva * precio).ToString("N2");
            }

            txtCantidad.Clear();
            dgvRepuestos.ClearSelection();
            MostrarTotal();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!editable) return;

            if (dgvRepuestos.SelectedRows.Count == 0)
            {
                Mensajes.Info("Selecciona en la tabla el repuesto que quieres quitar.");
                return;
            }

            dgvRepuestos.Rows.Remove(dgvRepuestos.SelectedRows[0]);
            dgvRepuestos.ClearSelection();
            MostrarTotal();
        }

        private RepuestoUsado[] RepuestosDeLaHoja()
        {
            RepuestoUsado[] usados = new RepuestoUsado[dgvRepuestos.Rows.Count];

            for (int i = 0; i < dgvRepuestos.Rows.Count; i++)
            {
                DataGridViewRow fila = dgvRepuestos.Rows[i];
                RepuestoUsado usado = new RepuestoUsado();
                usado.IdMantenimiento = idMantenimiento;
                usado.IdRepuesto = Convert.ToInt32(fila.Cells["IdRepuesto"].Value);
                usado.Repuesto = fila.Cells["Repuesto"].Value.ToString();
                usado.Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                usado.PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioValor"].Value);
                usados[i] = usado;
            }
            return usados;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!editable)
            {
                Mensajes.SinPermiso("registrar esta hoja de servicio");
                return;
            }

            avisos.Clear();

            string estado = Combos.Texto(cboEstado);
            string diagnostico = txtDiagnostico.Text.Trim();
            string trabajo = txtTrabajo.Text.Trim();
            bool completa = estado == Mantenimiento.Completado;

            if (diagnostico.Length < 5)
            {
                Validaciones.Invalido(avisos, txtDiagnostico, "ERR-VAL-001", "Escribe el diagnóstico: qué se encontró al revisar el equipo.");
                return;
            }

            if (completa && trabajo.Length < 5)
            {
                Validaciones.Invalido(avisos, txtTrabajo, "ERR-VAL-001", "Para completar la visita escribe el trabajo realizado.");
                return;
            }

            if (completa && dtpRealizada.Value.Date > DateTime.Today)
            {
                Validaciones.Invalido(avisos, dtpRealizada, "ERR-VAL-003", "La fecha de realización no puede ser futura.");
                return;
            }

            RepuestoUsado[] usados = RepuestosDeLaHoja();

            if (completa)
            {
                if (!Mensajes.Confirmar("¿Guardar la hoja y dejar la visita " + visita.Codigo + " como Completada?\n" +
                                        "Repuestos consumidos: " + usados.Length + ".")) return;
            }

            Mantenimiento m = new Mantenimiento();
            m.IdMantenimiento = idMantenimiento;
            m.Estado = estado;
            m.Diagnostico = diagnostico;
            m.TrabajoRealizado = trabajo;
            m.Observaciones = txtObservaciones.Text.Trim();
            if (completa) m.FechaRealizada = dtpRealizada.Value.Date;

            try
            {
                // guarda la hoja y descuenta los repuestos
                MantenimientoDatos.GuardarHoja(m, usados);
                RegistroActividadDatos.Registrar("Registró la hoja de servicio de la visita " + visita.Codigo +
                    " (" + estado + ", " + usados.Length + " repuestos)");

                Guardo = true;
                Mensajes.Info("Hoja de servicio guardada.");
                Close();
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar la hoja de servicio.", ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
