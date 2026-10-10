namespace Vista.Formularios
{
    partial class FrmMantenimientos
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
            this.btnHoja = new Guna.UI2.WinForms.Guna2Button();
            this.cboFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cboEquipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblIngeniero = new System.Windows.Forms.Label();
            this.cboIngeniero = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProgramada = new System.Windows.Forms.Label();
            this.dtpProgramada = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            this.avisos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.avisos.ContainerControl = this;

            this.pnlTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabla.Controls.Add(this.lblTitulo);
            this.pnlTabla.Controls.Add(this.lblCuenta);
            this.pnlTabla.Controls.Add(this.btnHoja);
            this.pnlTabla.Controls.Add(this.cboFiltro);
            this.pnlTabla.Controls.Add(this.txtBuscar);
            this.pnlTabla.Controls.Add(this.dgvVisitas);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(716, 580);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Visitas de mantenimiento";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 visitas";

            this.btnHoja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHoja.Location = new System.Drawing.Point(506, 18);
            this.btnHoja.Name = "btnHoja";
            this.btnHoja.Size = new System.Drawing.Size(190, 38);
            this.btnHoja.TabIndex = 3;
            this.btnHoja.Tag = "primario";
            this.btnHoja.Text = "HOJA DE SERVICIO";
            this.pistas.SetToolTip(this.btnHoja, "Abre la hoja de servicio de la visita seleccionada (también con doble clic)");
            this.btnHoja.Click += new System.EventHandler(this.btnHoja_Click);

            this.cboFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.ItemHeight = 30;
            this.cboFiltro.Location = new System.Drawing.Point(20, 72);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(170, 36);
            this.cboFiltro.TabIndex = 0;
            this.pistas.SetToolTip(this.cboFiltro, "Muestra solo las visitas con ese estado");
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.filtro_Changed);

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(200, 72);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar por código, equipo, cliente o ingeniero...";
            this.txtBuscar.Size = new System.Drawing.Size(496, 36);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.filtro_Changed);

            this.dgvVisitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVisitas.Location = new System.Drawing.Point(20, 122);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.Size = new System.Drawing.Size(676, 438);
            this.dgvVisitas.TabIndex = 2;
            this.dgvVisitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisitas_CellClick);
            this.dgvVisitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisitas_CellDoubleClick);
            this.dgvVisitas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVisitas_CellFormatting);

            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Controls.Add(this.lblEquipo);
            this.pnlForm.Controls.Add(this.cboEquipo);
            this.pnlForm.Controls.Add(this.lblIngeniero);
            this.pnlForm.Controls.Add(this.cboIngeniero);
            this.pnlForm.Controls.Add(this.lblTipo);
            this.pnlForm.Controls.Add(this.cboTipo);
            this.pnlForm.Controls.Add(this.lblEstado);
            this.pnlForm.Controls.Add(this.cboEstado);
            this.pnlForm.Controls.Add(this.lblProgramada);
            this.pnlForm.Controls.Add(this.dtpProgramada);
            this.pnlForm.Controls.Add(this.lblObservaciones);
            this.pnlForm.Controls.Add(this.txtObservaciones);
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
            this.lblFormTitulo.Text = "Programar visita";

            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(20, 58);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Tag = "campo";
            this.lblEquipo.Text = "EQUIPO A REVISAR *";

            this.cboEquipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipo.ItemHeight = 30;
            this.cboEquipo.Location = new System.Drawing.Point(20, 76);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(308, 36);
            this.cboEquipo.TabIndex = 0;

            this.lblIngeniero.AutoSize = true;
            this.lblIngeniero.Location = new System.Drawing.Point(20, 120);
            this.lblIngeniero.Name = "lblIngeniero";
            this.lblIngeniero.Tag = "campo";
            this.lblIngeniero.Text = "INGENIERO ASIGNADO *";

            this.cboIngeniero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboIngeniero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIngeniero.ItemHeight = 30;
            this.cboIngeniero.Location = new System.Drawing.Point(20, 138);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(308, 36);
            this.cboIngeniero.TabIndex = 1;
            this.pistas.SetToolTip(this.cboIngeniero, "Usuarios activos con el rol Ingeniero");

            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 182);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Tag = "campo";
            this.lblTipo.Text = "TIPO *";

            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.ItemHeight = 30;
            this.cboTipo.Location = new System.Drawing.Point(20, 200);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(148, 36);
            this.cboTipo.TabIndex = 2;

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(180, 182);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Tag = "campo";
            this.lblEstado.Text = "ESTADO *";

            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Location = new System.Drawing.Point(180, 200);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(148, 36);
            this.cboEstado.TabIndex = 3;
            this.pistas.SetToolTip(this.cboEstado, "Una visita se completa registrando su hoja de servicio");

            this.lblProgramada.AutoSize = true;
            this.lblProgramada.Location = new System.Drawing.Point(20, 244);
            this.lblProgramada.Name = "lblProgramada";
            this.lblProgramada.Tag = "campo";
            this.lblProgramada.Text = "FECHA PROGRAMADA *";

            this.dtpProgramada.Location = new System.Drawing.Point(20, 262);
            this.dtpProgramada.Name = "dtpProgramada";
            this.dtpProgramada.Size = new System.Drawing.Size(148, 36);
            this.dtpProgramada.TabIndex = 4;

            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(20, 306);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Tag = "campo";
            this.lblObservaciones.Text = "INDICACIONES PARA EL INGENIERO";

            this.txtObservaciones.Location = new System.Drawing.Point(20, 324);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "opcional";
            this.txtObservaciones.Size = new System.Drawing.Size(308, 98);
            this.txtObservaciones.TabIndex = 5;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(308, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "PROGRAMAR VISITA";
            this.pistas.SetToolTip(this.btnGuardar, "Si hay una fila seleccionada la actualiza; si no, programa una visita nueva");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "NUEVA / LIMPIAR";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(180, 524);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 36);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "ELIMINAR";
            this.pistas.SetToolTip(this.btnEliminar, "Los repuestos que consumió la visita regresan al inventario");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMantenimientos";
            this.Text = "Mantenimientos";
            this.Load += new System.EventHandler(this.FrmMantenimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ErrorProvider avisos;
        private System.Windows.Forms.ToolTip pistas;
        private Guna.UI2.WinForms.Guna2Panel pnlTabla;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCuenta;
        private Guna.UI2.WinForms.Guna2Button btnHoja;
        private Guna.UI2.WinForms.Guna2ComboBox cboFiltro;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvVisitas;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblEquipo;
        private Guna.UI2.WinForms.Guna2ComboBox cboEquipo;
        private System.Windows.Forms.Label lblIngeniero;
        private Guna.UI2.WinForms.Guna2ComboBox cboIngeniero;
        private System.Windows.Forms.Label lblTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipo;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private System.Windows.Forms.Label lblProgramada;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpProgramada;
        private System.Windows.Forms.Label lblObservaciones;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
