using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Visitas de mantenimiento.
    // El administrador las programa y el ingeniero ve las suyas y llena la hoja.
    public partial class FrmMantenimientos : Form
    {
        private const string TodosLosEstados = "Todos los estados";

        private int editId = 0;
        private bool puedeGestionar = false;
        private bool cargando = true;

        private Mantenimiento[] cargados = new Mantenimiento[0];

        public FrmMantenimientos()
        {
            InitializeComponent();
        }

        private void FrmMantenimientos_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            puedeGestionar = Sesion.Puede(Permisos.MantenimientosGestionar);
            ConfigurarGrid();

            cboFiltro.Items.Add(TodosLosEstados);
            foreach (string estado in Mantenimiento.Estados) cboFiltro.Items.Add(estado);
            cboFiltro.SelectedIndex = 0;

            if (puedeGestionar) CargarCombos();
            else Ventanas.SoloLectura(this, pnlTabla, pnlForm);

            if (!Sesion.Puede(Permisos.HojasRegistrar)) btnHoja.Text = "VER DETALLE";
            if (Sesion.EsIngeniero) lblTitulo.Text = "Mis visitas asignadas";

            cargando = false;
            CargarDatos();
            LimpiarFormulario();
        }

        private void CargarCombos()
        {
            Combos.Llenar(cboTipo, Mantenimiento.Tipos);
            Combos.Llenar(cboEstado, Mantenimiento.Estados);

            try
            {
                Combos.Llenar(cboEquipo, EquipoDatos.Listar());
                Combos.Llenar(cboIngeniero, UsuarioDatos.ListarIngenieros());
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }
        }

        private void ConfigurarGrid()
        {
            dgvVisitas.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvVisitas, "Id");
            EstiloGrid.ColumnaFija(dgvVisitas, "Codigo", "Código", 78);
            EstiloGrid.ColumnaFija(dgvVisitas, "Fecha", "Programada", 98);
            EstiloGrid.ColumnaFija(dgvVisitas, "Tipo", "Tipo", 96);
            EstiloGrid.Columna(dgvVisitas, "Equipo", "Equipo", 40);
            EstiloGrid.Columna(dgvVisitas, "Cliente", "Cliente", 32);
            EstiloGrid.Columna(dgvVisitas, "Ingeniero", "Ingeniero", 28);
            EstiloGrid.ColumnaFija(dgvVisitas, "Estado", "Estado", 104);

            // se oculta el tipo para que quepa la tabla
            if (puedeGestionar) dgvVisitas.Columns["Tipo"].Visible = false;
        }

        private void CargarDatos()
        {
            dgvVisitas.Rows.Clear();
            string filtro = txtBuscar.Text.Trim().ToLower();
            string estado = Combos.Texto(cboFiltro);

            try
            {
                // el ingeniero solo ve las suyas
                cargados = MantenimientoDatos.Listar(Sesion.IngenieroVisible);

                foreach (Mantenimiento m in cargados)
                {
                    if (estado != TodosLosEstados && m.Estado != estado) continue;
                    if (!Filtro.Coincide(filtro, m.Codigo, m.Equipo, m.Cliente, m.Ingeniero, m.Tipo, m.Ubicacion)) continue;

                    dgvVisitas.Rows.Add(m.IdMantenimiento, m.Codigo, m.FechaProgramada.ToString("dd/MM/yyyy"),
                                        m.Tipo, m.Equipo, m.Cliente, m.Ingeniero, m.Estado);
                }

                dgvVisitas.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvVisitas.Rows.Count + " de " + cargados.Length + " visitas";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Mantenimiento Cargado(int id)
        {
            foreach (Mantenimiento m in cargados)
                if (m.IdMantenimiento == id) return m;
            return null;
        }

        private void dgvVisitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVisitas.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }

        private void dgvVisitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Mantenimiento m = Cargado(Convert.ToInt32(dgvVisitas.Rows[e.RowIndex].Cells["Id"].Value));
            if (m == null) return;

            editId = m.IdMantenimiento;
            if (!puedeGestionar) return;

            avisos.Clear();
            lblFormTitulo.Text = "Editar visita " + m.Codigo;
            btnGuardar.Text = "GUARDAR CAMBIOS";
            cboEstado.Enabled = true;

            Combos.Seleccionar(cboEquipo, m.Equipo);
            Combos.Seleccionar(cboIngeniero, m.Ingeniero);
            Combos.Seleccionar(cboTipo, m.Tipo);
            Combos.Seleccionar(cboEstado, m.Estado);
            dtpProgramada.Value = m.FechaProgramada;
            txtObservaciones.Text = m.Observaciones;
        }

        private void dgvVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AbrirHoja();
        }

        private void btnHoja_Click(object sender, EventArgs e)
        {
            AbrirHoja();
        }

        private void AbrirHoja()
        {
            Mantenimiento m = Cargado(editId);
            if (m == null)
            {
                Mensajes.Info("Selecciona primero una visita de la tabla.");
                return;
            }

            bool guardo;
            using (FrmHojaServicio hoja = new FrmHojaServicio(m.IdMantenimiento))
            {
                hoja.ShowDialog(this);
                guardo = hoja.Guardo;
            }

            if (!guardo) return;
            CargarDatos();
            LimpiarFormulario();
        }

        // para que un equipo no tenga dos visitas el mismo día
        private bool YaTieneVisita(int idEquipo, DateTime fecha)
        {
            foreach (Mantenimiento m in cargados)
            {
                if (m.IdMantenimiento == editId) continue;
                if (m.IdEquipo != idEquipo) continue;
                if (m.Estado == Mantenimiento.Cancelado) continue;
                if (m.FechaProgramada.Date == fecha) return true;
            }
            return false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.MantenimientosGestionar))
            {
                Mensajes.SinPermiso("programar visitas");
                return;
            }

            avisos.Clear();

            Equipo equipo = cboEquipo.SelectedItem as Equipo;
            if (equipo == null)
            {
                Validaciones.Invalido(avisos, cboEquipo, "ERR-VAL-001", "Elige el equipo que se va a revisar.\nSi la lista está vacía, primero registra un equipo.");
                return;
            }

            Usuario ingeniero = cboIngeniero.SelectedItem as Usuario;
            if (ingeniero == null)
            {
                Validaciones.Invalido(avisos, cboIngeniero, "ERR-VAL-001", "Elige el ingeniero asignado.\nSi la lista está vacía, crea un usuario activo con el rol Ingeniero.");
                return;
            }

            DateTime fecha = dtpProgramada.Value.Date;
            string estado = Combos.Texto(cboEstado);
            Mantenimiento anterior = Cargado(editId);

            if (anterior == null && fecha < DateTime.Today)
            {
                Validaciones.Invalido(avisos, dtpProgramada, "ERR-VAL-003", "Una visita nueva no se puede programar en una fecha que ya pasó.");
                return;
            }

            if (estado == Mantenimiento.Completado)
            {
                bool yaEstaba = false;
                if (anterior != null) yaEstaba = anterior.Estado == Mantenimiento.Completado;

                if (!yaEstaba)
                {
                    Validaciones.Invalido(avisos, cboEstado, "ERR-VAL-002", "Una visita se completa registrando su hoja de servicio.\nUsa el botón HOJA DE SERVICIO.");
                    return;
                }
            }

            if (estado != Mantenimiento.Cancelado && YaTieneVisita(equipo.IdEquipo, fecha))
            {
                Validaciones.Invalido(avisos, dtpProgramada, "ERR-SQL-002", "El equipo " + equipo.NumeroSerie + " ya tiene una visita el " + fecha.ToString("dd/MM/yyyy") + ".\nElige otra fecha.");
                return;
            }

            Mantenimiento m = new Mantenimiento();
            m.IdMantenimiento = editId;
            m.IdEquipo = equipo.IdEquipo;
            m.IdIngeniero = ingeniero.IdUsuario;
            m.Tipo = Combos.Texto(cboTipo);
            m.FechaProgramada = fecha;
            m.Estado = estado;
            m.Observaciones = Textos.Limpiar(txtObservaciones.Text);

            try
            {
                string accion = "Programó";
                if (editId > 0)
                {
                    MantenimientoDatos.Actualizar(m);
                    accion = "Editó";
                }
                else
                {
                    m.IdMantenimiento = MantenimientoDatos.Insertar(m);
                }

                RegistroActividadDatos.Registrar(accion + " la visita " + m.Codigo + " del equipo " + equipo.NumeroSerie +
                                                 " y la asignó a " + ingeniero.Nombre);
                CargarDatos();
                LimpiarFormulario();
                Mensajes.Info("Visita " + m.Codigo + " guardada y asignada a " + ingeniero.Nombre + ".");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar la visita.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.MantenimientosGestionar))
            {
                Mensajes.SinPermiso("eliminar visitas");
                return;
            }

            Mantenimiento m = Cargado(editId);
            if (m == null)
            {
                Mensajes.Info("Selecciona primero una visita de la tabla.");
                return;
            }

            string pregunta = "¿Eliminar la visita " + m.Codigo + " del equipo " + m.NumeroSerie + "?";
            if (m.Estado == Mantenimiento.Completado)
                pregunta += "\n\nEsa visita ya está completada: se borrará del historial del cliente\n" +
                            "y sus repuestos regresarán al inventario.";

            if (!Mensajes.Confirmar(pregunta)) return;

            try
            {
                MantenimientoDatos.Eliminar(m.IdMantenimiento);
                RegistroActividadDatos.Registrar("Eliminó la visita " + m.Codigo + " del equipo " + m.NumeroSerie);
                CargarDatos();
                LimpiarFormulario();
                Mensajes.Info("Visita eliminada.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo eliminar la visita.", ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            cboEquipo.Focus();
        }

        private void filtro_Changed(object sender, EventArgs e)
        {
            if (cargando) return;
            editId = 0;
            CargarDatos();
        }

        private void LimpiarFormulario()
        {
            avisos.Clear();
            editId = 0;
            lblFormTitulo.Text = "Programar visita";
            btnGuardar.Text = "PROGRAMAR VISITA";

            if (cboEquipo.Items.Count > 0) cboEquipo.SelectedIndex = 0;
            if (cboIngeniero.Items.Count > 0) cboIngeniero.SelectedIndex = 0;
            Combos.Seleccionar(cboTipo, "Preventivo");

            // las visitas nuevas siempre empiezan como Programado
            Combos.Seleccionar(cboEstado, Mantenimiento.Programado);
            cboEstado.Enabled = false;

            dtpProgramada.Value = DateTime.Today.AddDays(7);
            txtObservaciones.Clear();
            dgvVisitas.ClearSelection();
        }
    }
}
