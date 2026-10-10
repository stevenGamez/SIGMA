using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // CRUD de equipos, el ingeniero y el cliente solo los pueden ver
    public partial class FrmEquipos : Form
    {
        private int editId = 0;
        private bool puedeGestionar = false;

        private Equipo[] cargados = new Equipo[0];

        public FrmEquipos()
        {
            InitializeComponent();
        }

        private void FrmEquipos_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            puedeGestionar = Sesion.Puede(Permisos.EquiposGestionar);
            ConfigurarGrid();

            if (puedeGestionar) CargarCombos();
            else Ventanas.SoloLectura(this, pnlTabla, pnlForm);

            if (Sesion.EsCliente) lblTitulo.Text = "Equipos instalados en " + Sesion.Actual.Cliente;

            CargarDatos("");
            LimpiarFormulario();
        }

        private void soloEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloEnteros(e);
        }

        private void CargarCombos()
        {
            Combos.Llenar(cboTipo, Equipo.Tipos);
            Combos.Llenar(cboEstado, Equipo.Estados);

            try
            {
                Combos.Llenar(cboContrato, ContratoDatos.Listar(0));
            }
            catch (Exception ex)
            {
                Mensajes.SinConexion(ex);
            }
        }

        private void ConfigurarGrid()
        {
            dgvEquipos.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvEquipos, "Id");
            EstiloGrid.ColumnaFija(dgvEquipos, "Serie", "N.º de serie", 124);
            EstiloGrid.Columna(dgvEquipos, "Equipo", "Marca y modelo", 30);
            EstiloGrid.ColumnaFija(dgvEquipos, "Tipo", "Tipo", 92);
            EstiloGrid.ColumnaFija(dgvEquipos, "Capacidad", "BTU", 78);
            EstiloGrid.Columna(dgvEquipos, "Ubicacion", "Ubicación", 36);
            EstiloGrid.Columna(dgvEquipos, "Cliente", "Cliente", 34);
            EstiloGrid.ColumnaFija(dgvEquipos, "Contrato", "Contrato", 82);
            EstiloGrid.ColumnaFija(dgvEquipos, "Estado", "Estado", 128);

            // se ocultan estas columnas para que quepa la tabla
            if (puedeGestionar)
            {
                dgvEquipos.Columns["Tipo"].Visible = false;
                dgvEquipos.Columns["Capacidad"].Visible = false;
                dgvEquipos.Columns["Contrato"].Visible = false;
            }

            // al cliente no se le repite el nombre de su empresa
            if (Sesion.EsCliente) dgvEquipos.Columns["Cliente"].Visible = false;
        }

        private void CargarDatos(string filtro)
        {
            dgvEquipos.Rows.Clear();
            filtro = filtro.Trim().ToLower();

            try
            {
                cargados = EquipoDatos.Listar(Sesion.ClienteVisible);

                foreach (Equipo eq in cargados)
                {
                    if (!Filtro.Coincide(filtro, eq.NumeroSerie, eq.Marca, eq.Modelo, eq.Tipo,
                                         eq.Ubicacion, eq.Cliente, eq.Estado)) continue;

                    dgvEquipos.Rows.Add(eq.IdEquipo, eq.NumeroSerie, eq.Marca + " " + eq.Modelo, eq.Tipo,
                                        eq.CapacidadBTU.ToString("N0"), eq.Ubicacion, eq.Cliente, eq.Contrato, eq.Estado);
                }

                dgvEquipos.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvEquipos.Rows.Count + " de " + cargados.Length + " equipos";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Equipo Cargado(int id)
        {
            foreach (Equipo eq in cargados)
                if (eq.IdEquipo == id) return eq;
            return null;
        }

        private void dgvEquipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEquipos.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!puedeGestionar) return;

            Equipo eq = Cargado(Convert.ToInt32(dgvEquipos.Rows[e.RowIndex].Cells["Id"].Value));
            if (eq == null) return;

            avisos.Clear();
            editId = eq.IdEquipo;
            lblFormTitulo.Text = "Editar equipo";
            btnGuardar.Text = "GUARDAR CAMBIOS";

            Combos.Seleccionar(cboContrato, eq.Contrato + " · " + eq.Cliente);
            txtSerie.Text = eq.NumeroSerie;
            txtMarca.Text = eq.Marca;
            txtModelo.Text = eq.Modelo;
            Combos.Seleccionar(cboTipo, eq.Tipo);
            txtCapacidad.Text = eq.CapacidadBTU.ToString();
            txtUbicacion.Text = eq.Ubicacion;
            dtpInstalacion.Value = eq.FechaInstalacion;
            Combos.Seleccionar(cboEstado, eq.Estado);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.EquiposGestionar))
            {
                Mensajes.SinPermiso("modificar los equipos");
                return;
            }

            avisos.Clear();

            Contrato contrato = cboContrato.SelectedItem as Contrato;
            if (contrato == null)
            {
                Validaciones.Invalido(avisos, cboContrato, "ERR-VAL-001", "Elige el contrato que cubre al equipo.\nSi la lista está vacía, primero registra un contrato.");
                return;
            }

            string serie = txtSerie.Text.Trim().ToUpper();
            string marca = Textos.Limpiar(txtMarca.Text);
            string modelo = Textos.Limpiar(txtModelo.Text);
            string ubicacion = Textos.Limpiar(txtUbicacion.Text);

            if (serie.Length < 4)
            {
                Validaciones.Invalido(avisos, txtSerie, "ERR-VAL-001", "Escribe el número de serie del equipo (al menos 4 caracteres).");
                return;
            }

            if (serie.Contains(" "))
            {
                Validaciones.Invalido(avisos, txtSerie, "ERR-VAL-002", "El número de serie no lleva espacios.");
                return;
            }

            if (marca.Length < 2)
            {
                Validaciones.Invalido(avisos, txtMarca, "ERR-VAL-001", "Escribe la marca del equipo.");
                return;
            }

            if (modelo.Length < 2)
            {
                Validaciones.Invalido(avisos, txtModelo, "ERR-VAL-001", "Escribe el modelo del equipo.");
                return;
            }

            int capacidad;
            int.TryParse(txtCapacidad.Text.Trim(), out capacidad);
            if (capacidad < Equipo.CapacidadMinima || capacidad > Equipo.CapacidadMaxima)
            {
                Validaciones.Invalido(avisos, txtCapacidad, "ERR-VAL-003",
                    "La capacidad va de " + Equipo.CapacidadMinima.ToString("N0") + " a " + Equipo.CapacidadMaxima.ToString("N0") + " BTU.");
                return;
            }

            if (ubicacion.Length < 3)
            {
                Validaciones.Invalido(avisos, txtUbicacion, "ERR-VAL-001", "Escribe dónde está instalado el equipo.");
                return;
            }

            if (dtpInstalacion.Value.Date > DateTime.Today)
            {
                Validaciones.Invalido(avisos, dtpInstalacion, "ERR-VAL-003", "La fecha de instalación no puede ser futura.");
                return;
            }

            try
            {
                if (EquipoDatos.ExisteSerie(serie, editId))
                {
                    Validaciones.Invalido(avisos, txtSerie, "ERR-SQL-002", "Ya existe un equipo con el número de serie " + serie + ".");
                    return;
                }

                Equipo eq = new Equipo();
                eq.IdEquipo = editId;
                eq.IdContrato = contrato.IdContrato;
                eq.NumeroSerie = serie;
                eq.Marca = marca;
                eq.Modelo = modelo;
                eq.Tipo = Combos.Texto(cboTipo);
                eq.CapacidadBTU = capacidad;
                eq.Ubicacion = ubicacion;
                eq.FechaInstalacion = dtpInstalacion.Value.Date;
                eq.Estado = Combos.Texto(cboEstado);

                string accion = "Registró";
                if (editId > 0)
                {
                    EquipoDatos.Actualizar(eq);
                    accion = "Editó";
                }
                else
                {
                    EquipoDatos.Insertar(eq);
                }

                RegistroActividadDatos.Registrar(accion + " el equipo " + serie + " (" + contrato.Cliente + ")");
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Equipo guardado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar el equipo.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.EquiposGestionar))
            {
                Mensajes.SinPermiso("eliminar equipos");
                return;
            }

            Equipo eq = Cargado(editId);
            if (eq == null)
            {
                Mensajes.Info("Selecciona primero un equipo de la tabla.");
                return;
            }

            if (!Mensajes.Confirmar("¿Eliminar el equipo " + eq.NumeroSerie + " de " + eq.Cliente + "?")) return;

            try
            {
                EquipoDatos.Eliminar(eq.IdEquipo);
                RegistroActividadDatos.Registrar("Eliminó el equipo " + eq.NumeroSerie + " (" + eq.Cliente + ")");
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Equipo eliminado.");
            }
            catch (Exception ex)
            {
                Mensajes.Aviso("No se pudo eliminar el equipo.\n" +
                    "Si ya tiene visitas de mantenimiento, cámbiale el estado a \"Fuera de servicio\".\n\n" + Mensajes.Explicar(ex));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtSerie.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBuscar.Text);
        }

        private void LimpiarFormulario()
        {
            avisos.Clear();
            editId = 0;
            lblFormTitulo.Text = "Nuevo equipo";
            btnGuardar.Text = "GUARDAR";

            if (cboContrato.Items.Count > 0) cboContrato.SelectedIndex = 0;
            txtSerie.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            Combos.Seleccionar(cboTipo, "Mini Split");
            txtCapacidad.Clear();
            txtUbicacion.Clear();
            dtpInstalacion.Value = DateTime.Today;
            Combos.Seleccionar(cboEstado, "Operativo");
            dgvEquipos.ClearSelection();
        }
    }
}
