namespace Vista.Formularios
{
    partial class FrmEquipos
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
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblContrato = new System.Windows.Forms.Label();
            this.cboContrato = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.txtCapacidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblInstalacion = new System.Windows.Forms.Label();
            this.dtpInstalacion = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
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
            this.pnlTabla.Controls.Add(this.dgvEquipos);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(716, 580);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Equipos de aire acondicionado";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 equipos";

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(436, 18);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar equipo...";
            this.txtBuscar.Size = new System.Drawing.Size(260, 36);
            this.txtBuscar.TabIndex = 0;
            this.pistas.SetToolTip(this.txtBuscar, "Busca por serie, marca, modelo, ubicación, cliente o estado");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.Location = new System.Drawing.Point(20, 74);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.Size = new System.Drawing.Size(676, 486);
            this.dgvEquipos.TabIndex = 1;
            this.dgvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellClick);
            this.dgvEquipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEquipos_CellFormatting);

            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Controls.Add(this.lblContrato);
            this.pnlForm.Controls.Add(this.cboContrato);
            this.pnlForm.Controls.Add(this.lblSerie);
            this.pnlForm.Controls.Add(this.txtSerie);
            this.pnlForm.Controls.Add(this.lblMarca);
            this.pnlForm.Controls.Add(this.txtMarca);
            this.pnlForm.Controls.Add(this.lblModelo);
            this.pnlForm.Controls.Add(this.txtModelo);
            this.pnlForm.Controls.Add(this.lblTipo);
            this.pnlForm.Controls.Add(this.cboTipo);
            this.pnlForm.Controls.Add(this.lblCapacidad);
            this.pnlForm.Controls.Add(this.txtCapacidad);
            this.pnlForm.Controls.Add(this.lblUbicacion);
            this.pnlForm.Controls.Add(this.txtUbicacion);
            this.pnlForm.Controls.Add(this.lblInstalacion);
            this.pnlForm.Controls.Add(this.dtpInstalacion);
            this.pnlForm.Controls.Add(this.lblEstado);
            this.pnlForm.Controls.Add(this.cboEstado);
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
            this.lblFormTitulo.Text = "Nuevo equipo";

            this.lblContrato.AutoSize = true;
            this.lblContrato.Location = new System.Drawing.Point(20, 58);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Tag = "campo";
            this.lblContrato.Text = "CONTRATO QUE LO CUBRE *";

            this.cboContrato.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContrato.ItemHeight = 30;
            this.cboContrato.Location = new System.Drawing.Point(20, 76);
            this.cboContrato.Name = "cboContrato";
            this.cboContrato.Size = new System.Drawing.Size(308, 36);
            this.cboContrato.TabIndex = 0;

            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(20, 120);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Tag = "campo";
            this.lblSerie.Text = "NÚMERO DE SERIE *";

            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(20, 138);
            this.txtSerie.MaxLength = 30;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(308, 36);
            this.txtSerie.TabIndex = 1;
            this.pistas.SetToolTip(this.txtSerie, "El número de la placa del equipo. No se repite");

            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(20, 182);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Tag = "campo";
            this.lblMarca.Text = "MARCA *";

            this.txtMarca.Location = new System.Drawing.Point(20, 200);
            this.txtMarca.MaxLength = 40;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(148, 36);
            this.txtMarca.TabIndex = 2;

            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(180, 182);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Tag = "campo";
            this.lblModelo.Text = "MODELO *";

            this.txtModelo.Location = new System.Drawing.Point(180, 200);
            this.txtModelo.MaxLength = 40;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(148, 36);
            this.txtModelo.TabIndex = 3;

            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 244);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Tag = "campo";
            this.lblTipo.Text = "TIPO *";

            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.ItemHeight = 30;
            this.cboTipo.Location = new System.Drawing.Point(20, 262);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(148, 36);
            this.cboTipo.TabIndex = 4;

            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(180, 244);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Tag = "campo";
            this.lblCapacidad.Text = "CAPACIDAD (BTU) *";

            this.txtCapacidad.Location = new System.Drawing.Point(180, 262);
            this.txtCapacidad.MaxLength = 7;
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.PlaceholderText = "24000";
            this.txtCapacidad.Size = new System.Drawing.Size(148, 36);
            this.txtCapacidad.TabIndex = 5;
            this.txtCapacidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloEnteros_KeyPress);

            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 306);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Tag = "campo";
            this.lblUbicacion.Text = "UBICACIÓN EN LA INSTALACIÓN *";

            this.txtUbicacion.Location = new System.Drawing.Point(20, 324);
            this.txtUbicacion.MaxLength = 150;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.PlaceholderText = "Ej.: Sala de juntas, nivel 2";
            this.txtUbicacion.Size = new System.Drawing.Size(308, 36);
            this.txtUbicacion.TabIndex = 6;

            this.lblInstalacion.AutoSize = true;
            this.lblInstalacion.Location = new System.Drawing.Point(20, 368);
            this.lblInstalacion.Name = "lblInstalacion";
            this.lblInstalacion.Tag = "campo";
            this.lblInstalacion.Text = "INSTALADO EL *";

            this.dtpInstalacion.Location = new System.Drawing.Point(20, 386);
            this.dtpInstalacion.Name = "dtpInstalacion";
            this.dtpInstalacion.Size = new System.Drawing.Size(148, 36);
            this.dtpInstalacion.TabIndex = 7;

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(180, 368);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Tag = "campo";
            this.lblEstado.Text = "ESTADO *";

            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Location = new System.Drawing.Point(180, 386);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(148, 36);
            this.cboEstado.TabIndex = 8;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(308, 40);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR";
            this.pistas.SetToolTip(this.btnGuardar, "Si hay una fila seleccionada la actualiza; si no, crea un equipo nuevo");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "NUEVO / LIMPIAR";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(180, 524);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 36);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "ELIMINAR";
            this.pistas.SetToolTip(this.btnEliminar, "No se puede si el equipo ya tiene visitas de mantenimiento");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEquipos";
            this.Text = "Equipos";
            this.Load += new System.EventHandler(this.FrmEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvEquipos;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblContrato;
        private Guna.UI2.WinForms.Guna2ComboBox cboContrato;
        private System.Windows.Forms.Label lblSerie;
        private Guna.UI2.WinForms.Guna2TextBox txtSerie;
        private System.Windows.Forms.Label lblMarca;
        private Guna.UI2.WinForms.Guna2TextBox txtMarca;
        private System.Windows.Forms.Label lblModelo;
        private Guna.UI2.WinForms.Guna2TextBox txtModelo;
        private System.Windows.Forms.Label lblTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipo;
        private System.Windows.Forms.Label lblCapacidad;
        private Guna.UI2.WinForms.Guna2TextBox txtCapacidad;
        private System.Windows.Forms.Label lblUbicacion;
        private Guna.UI2.WinForms.Guna2TextBox txtUbicacion;
        private System.Windows.Forms.Label lblInstalacion;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpInstalacion;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
