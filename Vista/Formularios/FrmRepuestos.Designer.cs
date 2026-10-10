namespace Vista.Formularios
{
    partial class FrmRepuestos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.avisos = new System.Windows.Forms.ErrorProvider(this.components);
            this.pistas = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTabla = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvRepuestos = new System.Windows.Forms.DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblExistencia = new System.Windows.Forms.Label();
            this.txtExistencia = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMinimo = new System.Windows.Forms.Label();
            this.txtMinimo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            this.avisos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.avisos.ContainerControl = this;

            this.pnlTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabla.Controls.Add(this.lblTitulo);
            this.pnlTabla.Controls.Add(this.lblCuenta);
            this.pnlTabla.Controls.Add(this.txtBuscar);
            this.pnlTabla.Controls.Add(this.dgvRepuestos);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(716, 580);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Inventario de repuestos";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 repuestos";

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(436, 18);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar repuesto...";
            this.txtBuscar.Size = new System.Drawing.Size(260, 36);
            this.txtBuscar.TabIndex = 0;
            this.pistas.SetToolTip(this.txtBuscar, "Busca por código, nombre, categoría o estado");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvRepuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRepuestos.Location = new System.Drawing.Point(20, 74);
            this.dgvRepuestos.Name = "dgvRepuestos";
            this.dgvRepuestos.Size = new System.Drawing.Size(676, 486);
            this.dgvRepuestos.TabIndex = 1;
            this.dgvRepuestos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRepuestos_CellClick);
            this.dgvRepuestos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRepuestos_CellFormatting);

            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Controls.Add(this.lblNombre);
            this.pnlForm.Controls.Add(this.txtNombre);
            this.pnlForm.Controls.Add(this.lblCategoria);
            this.pnlForm.Controls.Add(this.cboCategoria);
            this.pnlForm.Controls.Add(this.lblExistencia);
            this.pnlForm.Controls.Add(this.txtExistencia);
            this.pnlForm.Controls.Add(this.lblMinimo);
            this.pnlForm.Controls.Add(this.txtMinimo);
            this.pnlForm.Controls.Add(this.lblPrecio);
            this.pnlForm.Controls.Add(this.txtPrecio);
            this.pnlForm.Controls.Add(this.lblNota);
            this.pnlForm.Controls.Add(this.btnGuardar);
            this.pnlForm.Controls.Add(this.btnLimpiar);
            this.pnlForm.Controls.Add(this.btnEliminar);
            this.pnlForm.Location = new System.Drawing.Point(752, 20);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(348, 580);
            this.pnlForm.TabIndex = 0;
            this.pnlForm.Tag = "tarjeta";

            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Tag = "subtitulo";
            this.lblFormTitulo.Text = "Nuevo repuesto";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Tag = "campo";
            this.lblNombre.Text = "NOMBRE DEL REPUESTO *";

            this.txtNombre.Location = new System.Drawing.Point(20, 76);
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(308, 36);
            this.txtNombre.TabIndex = 0;

            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, 120);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Tag = "campo";
            this.lblCategoria.Text = "CATEGORÍA *";

            this.cboCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.ItemHeight = 30;
            this.cboCategoria.Location = new System.Drawing.Point(20, 138);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(308, 36);
            this.cboCategoria.TabIndex = 1;

            this.lblExistencia.AutoSize = true;
            this.lblExistencia.Location = new System.Drawing.Point(20, 182);
            this.lblExistencia.Name = "lblExistencia";
            this.lblExistencia.Tag = "campo";
            this.lblExistencia.Text = "EXISTENCIA *";

            this.txtExistencia.Location = new System.Drawing.Point(20, 200);
            this.txtExistencia.MaxLength = 5;
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.PlaceholderText = "0";
            this.txtExistencia.Size = new System.Drawing.Size(148, 36);
            this.txtExistencia.TabIndex = 2;
            this.pistas.SetToolTip(this.txtExistencia, "Unidades que hay en bodega");
            this.txtExistencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloEnteros_KeyPress);

            this.lblMinimo.AutoSize = true;
            this.lblMinimo.Location = new System.Drawing.Point(180, 182);
            this.lblMinimo.Name = "lblMinimo";
            this.lblMinimo.Tag = "campo";
            this.lblMinimo.Text = "EXISTENCIA MÍNIMA *";

            this.txtMinimo.Location = new System.Drawing.Point(180, 200);
            this.txtMinimo.MaxLength = 5;
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.PlaceholderText = "0";
            this.txtMinimo.Size = new System.Drawing.Size(148, 36);
            this.txtMinimo.TabIndex = 3;
            this.pistas.SetToolTip(this.txtMinimo, "Al llegar a esta cantidad el repuesto se marca con existencia baja");
            this.txtMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloEnteros_KeyPress);

            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(20, 244);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Tag = "campo";
            this.lblPrecio.Text = "PRECIO UNITARIO ($) *";

            this.txtPrecio.Location = new System.Drawing.Point(20, 262);
            this.txtPrecio.MaxLength = 8;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PlaceholderText = "0.00";
            this.txtPrecio.Size = new System.Drawing.Size(148, 36);
            this.txtPrecio.TabIndex = 4;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloDecimal_KeyPress);

            this.lblNota.Location = new System.Drawing.Point(20, 314);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(308, 54);
            this.lblNota.Tag = "suave";
            this.lblNota.Text = "La existencia baja sola cuando un ingeniero registra el repuesto en una hoja de servicio.";

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(308, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR";
            this.pistas.SetToolTip(this.btnGuardar, "Si hay una fila seleccionada la actualiza; si no, crea un repuesto nuevo");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "NUEVO / LIMPIAR";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(180, 524);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 36);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "ELIMINAR";
            this.pistas.SetToolTip(this.btnEliminar, "No se puede si el repuesto ya se usó en alguna hoja de servicio");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRepuestos";
            this.Text = "Repuestos";
            this.Load += new System.EventHandler(this.FrmRepuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ErrorProvider avisos;
        private System.Windows.Forms.ToolTip pistas;
        private Guna.UI2.WinForms.Guna2Panel pnlTabla;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCuenta;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvRepuestos;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label lblCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategoria;
        private System.Windows.Forms.Label lblExistencia;
        private Guna.UI2.WinForms.Guna2TextBox txtExistencia;
        private System.Windows.Forms.Label lblMinimo;
        private Guna.UI2.WinForms.Guna2TextBox txtMinimo;
        private System.Windows.Forms.Label lblPrecio;
        private Guna.UI2.WinForms.Guna2TextBox txtPrecio;
        private System.Windows.Forms.Label lblNota;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
