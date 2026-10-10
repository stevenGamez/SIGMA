namespace Vista.Formularios
{
    partial class FrmContratos
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
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.cboFrecuencia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
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
            this.pnlTabla.Controls.Add(this.dgvContratos);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(716, 580);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Contratos de mantenimiento";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 contratos";

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(436, 18);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar contrato...";
            this.txtBuscar.Size = new System.Drawing.Size(260, 36);
            this.txtBuscar.TabIndex = 0;
            this.pistas.SetToolTip(this.txtBuscar, "Busca por código, cliente, frecuencia o estado");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContratos.Location = new System.Drawing.Point(20, 74);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.Size = new System.Drawing.Size(676, 486);
            this.dgvContratos.TabIndex = 1;
            this.dgvContratos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratos_CellClick);
            this.dgvContratos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvContratos_CellFormatting);

            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Controls.Add(this.lblCliente);
            this.pnlForm.Controls.Add(this.cboCliente);
            this.pnlForm.Controls.Add(this.lblInicio);
            this.pnlForm.Controls.Add(this.dtpInicio);
            this.pnlForm.Controls.Add(this.lblFin);
            this.pnlForm.Controls.Add(this.dtpFin);
            this.pnlForm.Controls.Add(this.lblFrecuencia);
            this.pnlForm.Controls.Add(this.cboFrecuencia);
            this.pnlForm.Controls.Add(this.lblMonto);
            this.pnlForm.Controls.Add(this.txtMonto);
            this.pnlForm.Controls.Add(this.lblEstado);
            this.pnlForm.Controls.Add(this.cboEstado);
            this.pnlForm.Controls.Add(this.lblDescripcion);
            this.pnlForm.Controls.Add(this.txtDescripcion);
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
            this.lblFormTitulo.Text = "Nuevo contrato";

            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 58);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Tag = "campo";
            this.lblCliente.Text = "CLIENTE *";

            this.cboCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.ItemHeight = 30;
            this.cboCliente.Location = new System.Drawing.Point(20, 76);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(308, 36);
            this.cboCliente.TabIndex = 0;

            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(20, 120);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Tag = "campo";
            this.lblInicio.Text = "FECHA DE INICIO *";

            this.dtpInicio.Location = new System.Drawing.Point(20, 138);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(148, 36);
            this.dtpInicio.TabIndex = 1;

            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(180, 120);
            this.lblFin.Name = "lblFin";
            this.lblFin.Tag = "campo";
            this.lblFin.Text = "FECHA DE FIN *";

            this.dtpFin.Location = new System.Drawing.Point(180, 138);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(148, 36);
            this.dtpFin.TabIndex = 2;

            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Location = new System.Drawing.Point(20, 182);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Tag = "campo";
            this.lblFrecuencia.Text = "VISITAS *";

            this.cboFrecuencia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrecuencia.ItemHeight = 30;
            this.cboFrecuencia.Location = new System.Drawing.Point(20, 200);
            this.cboFrecuencia.Name = "cboFrecuencia";
            this.cboFrecuencia.Size = new System.Drawing.Size(148, 36);
            this.cboFrecuencia.TabIndex = 3;
            this.pistas.SetToolTip(this.cboFrecuencia, "Cada cuánto se hace la visita de mantenimiento preventivo");

            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(180, 182);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Tag = "campo";
            this.lblMonto.Text = "MONTO MENSUAL ($) *";

            this.txtMonto.Location = new System.Drawing.Point(180, 200);
            this.txtMonto.MaxLength = 8;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.PlaceholderText = "0.00";
            this.txtMonto.Size = new System.Drawing.Size(148, 36);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloDecimal_KeyPress);

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 244);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Tag = "campo";
            this.lblEstado.Text = "ESTADO *";

            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Location = new System.Drawing.Point(20, 262);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(308, 36);
            this.cboEstado.TabIndex = 5;

            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 306);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Tag = "campo";
            this.lblDescripcion.Text = "ALCANCE DEL CONTRATO";

            this.txtDescripcion.Location = new System.Drawing.Point(20, 324);
            this.txtDescripcion.MaxLength = 300;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "opcional";
            this.txtDescripcion.Size = new System.Drawing.Size(308, 98);
            this.txtDescripcion.TabIndex = 6;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(308, 40);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR";
            this.pistas.SetToolTip(this.btnGuardar, "Si hay una fila seleccionada la actualiza; si no, crea un contrato nuevo");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "NUEVO / LIMPIAR";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(180, 524);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 36);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "ELIMINAR";
            this.pistas.SetToolTip(this.btnEliminar, "No se puede si el contrato todavía cubre equipos");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmContratos";
            this.Text = "Contratos";
            this.Load += new System.EventHandler(this.FrmContratos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvContratos;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblCliente;
        private Guna.UI2.WinForms.Guna2ComboBox cboCliente;
        private System.Windows.Forms.Label lblInicio;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFin;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblFrecuencia;
        private Guna.UI2.WinForms.Guna2ComboBox cboFrecuencia;
        private System.Windows.Forms.Label lblMonto;
        private Guna.UI2.WinForms.Guna2TextBox txtMonto;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private System.Windows.Forms.Label lblDescripcion;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
