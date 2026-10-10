using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // CRUD de repuestos, el ingeniero solo los puede ver
    public partial class FrmRepuestos : Form
    {
        private int editId = 0;
        private bool puedeGestionar = false;

        private Repuesto[] cargados = new Repuesto[0];

        public FrmRepuestos()
        {
            InitializeComponent();
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);
            puedeGestionar = Sesion.Puede(Permisos.RepuestosGestionar);
            ConfigurarGrid();

            if (puedeGestionar) Combos.Llenar(cboCategoria, Repuesto.Categorias);
            else Ventanas.SoloLectura(this, pnlTabla, pnlForm);

            CargarDatos("");
            LimpiarFormulario();
        }

        private void soloEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloEnteros(e);
        }

        private void soloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloDecimal((Guna2TextBox)sender, e);
        }

        private void ConfigurarGrid()
        {
            dgvRepuestos.Columns.Clear();
            EstiloGrid.ColumnaOculta(dgvRepuestos, "Id");
            EstiloGrid.ColumnaFija(dgvRepuestos, "Codigo", "Código", 78);
            EstiloGrid.Columna(dgvRepuestos, "Nombre", "Repuesto", 100);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Categoria", "Categoría", 112);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Existencia", "Existencia", 86);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Minimo", "Mínimo", 76);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Precio", "Precio", 80);
            EstiloGrid.ColumnaFija(dgvRepuestos, "Estado", "Estado", 120);

            // se ocultan estas columnas para que quepa la tabla
            if (puedeGestionar)
            {
                dgvRepuestos.Columns["Codigo"].Visible = false;
                dgvRepuestos.Columns["Minimo"].Visible = false;
            }
        }

        private string Estado(Repuesto r)
        {
            if (r.Existencia == 0) return "Agotado";
            if (r.BajoStock) return "Existencia baja";
            return "Disponible";
        }

        private void CargarDatos(string filtro)
        {
            dgvRepuestos.Rows.Clear();
            filtro = filtro.Trim().ToLower();
            int bajos = 0;

            try
            {
                cargados = RepuestoDatos.Listar();

                foreach (Repuesto r in cargados)
                {
                    if (r.BajoStock) bajos++;
                    if (!Filtro.Coincide(filtro, r.Codigo, r.Nombre, r.Categoria, Estado(r))) continue;

                    dgvRepuestos.Rows.Add(r.IdRepuesto, r.Codigo, r.Nombre, r.Categoria, r.Existencia,
                                          r.StockMinimo, "$" + r.PrecioUnitario.ToString("N2"), Estado(r));
                }

                dgvRepuestos.ClearSelection();
                lblCuenta.Text = "Mostrando " + dgvRepuestos.Rows.Count + " de " + cargados.Length +
                                 " repuestos · " + bajos + " con existencia baja";
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        private Repuesto Cargado(int id)
        {
            foreach (Repuesto r in cargados)
                if (r.IdRepuesto == id) return r;
            return null;
        }

        private void dgvRepuestos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRepuestos.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }

        private void dgvRepuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!puedeGestionar) return;

            Repuesto r = Cargado(Convert.ToInt32(dgvRepuestos.Rows[e.RowIndex].Cells["Id"].Value));
            if (r == null) return;

            avisos.Clear();
            editId = r.IdRepuesto;
            lblFormTitulo.Text = "Editar repuesto " + r.Codigo;
            btnGuardar.Text = "GUARDAR CAMBIOS";

            txtNombre.Text = r.Nombre;
            Combos.Seleccionar(cboCategoria, r.Categoria);
            txtExistencia.Text = r.Existencia.ToString();
            txtMinimo.Text = r.StockMinimo.ToString();
            txtPrecio.Text = r.PrecioUnitario.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.RepuestosGestionar))
            {
                Mensajes.SinPermiso("modificar los repuestos");
                return;
            }

            avisos.Clear();

            string nombre = Textos.Limpiar(txtNombre.Text);
            if (nombre.Length < 3)
            {
                Validaciones.Invalido(avisos, txtNombre, "ERR-VAL-001", "Escribe el nombre del repuesto (al menos 3 caracteres).");
                return;
            }

            if (!Validaciones.SoloDigitos(txtExistencia.Text.Trim()))
            {
                Validaciones.Invalido(avisos, txtExistencia, "ERR-VAL-001", "Escribe cuántas unidades hay en existencia (puede ser 0).");
                return;
            }

            if (!Validaciones.SoloDigitos(txtMinimo.Text.Trim()))
            {
                Validaciones.Invalido(avisos, txtMinimo, "ERR-VAL-001", "Escribe la existencia mínima (puede ser 0).");
                return;
            }

            int existencia = int.Parse(txtExistencia.Text.Trim());
            int minimo = int.Parse(txtMinimo.Text.Trim());

            decimal precio;
            decimal.TryParse(txtPrecio.Text.Trim(), out precio);
            precio = Math.Round(precio, 2);
            if (precio <= 0)
            {
                Validaciones.Invalido(avisos, txtPrecio, "ERR-VAL-003", "Escribe el precio unitario del repuesto (mayor que cero).");
                return;
            }

            if (precio > Repuesto.PrecioMaximo)
            {
                Validaciones.Invalido(avisos, txtPrecio, "ERR-VAL-003", "El precio no puede pasar de $" + Repuesto.PrecioMaximo.ToString("N2") + ".");
                return;
            }

            try
            {
                if (RepuestoDatos.ExisteNombre(nombre, editId))
                {
                    Validaciones.Invalido(avisos, txtNombre, "ERR-SQL-002", "Ya existe un repuesto llamado \"" + nombre + "\".");
                    return;
                }

                Repuesto r = new Repuesto();
                r.IdRepuesto = editId;
                r.Nombre = nombre;
                r.Categoria = Combos.Texto(cboCategoria);
                r.Existencia = existencia;
                r.StockMinimo = minimo;
                r.PrecioUnitario = precio;

                string accion = "Registró";
                if (editId > 0)
                {
                    RepuestoDatos.Actualizar(r);
                    accion = "Editó";
                }
                else
                {
                    RepuestoDatos.Insertar(r);
                }

                RegistroActividadDatos.Registrar(accion + " el repuesto " + nombre + " (existencia " + existencia + ")");
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Repuesto guardado.");
            }
            catch (Exception ex)
            {
                Mensajes.Fallo("No se pudo guardar el repuesto.", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.Puede(Permisos.RepuestosGestionar))
            {
                Mensajes.SinPermiso("eliminar repuestos");
                return;
            }

            Repuesto r = Cargado(editId);
            if (r == null)
            {
                Mensajes.Info("Selecciona primero un repuesto de la tabla.");
                return;
            }

            if (!Mensajes.Confirmar("¿Eliminar el repuesto \"" + r.Nombre + "\"?")) return;

            try
            {
                RepuestoDatos.Eliminar(r.IdRepuesto);
                RegistroActividadDatos.Registrar("Eliminó el repuesto " + r.Nombre);
                CargarDatos(txtBuscar.Text);
                LimpiarFormulario();
                Mensajes.Info("Repuesto eliminado.");
            }
            catch (Exception ex)
            {
                Mensajes.Aviso("No se pudo eliminar el repuesto.\n" +
                    "Si ya se usó en una hoja de servicio forma parte del historial.\n\n" + Mensajes.Explicar(ex));
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
            lblFormTitulo.Text = "Nuevo repuesto";
            btnGuardar.Text = "GUARDAR";

            txtNombre.Clear();
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            txtExistencia.Clear();
            txtMinimo.Clear();
            txtPrecio.Clear();
            dgvRepuestos.ClearSelection();
        }
    }
}
