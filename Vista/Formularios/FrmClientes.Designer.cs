namespace Vista.Formularios
{
    partial class FrmClientes
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
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
            this.pnlTabla.Controls.Add(this.dgvClientes);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(716, 580);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Clientes corporativos";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 clientes";

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(436, 18);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar cliente...";
            this.txtBuscar.Size = new System.Drawing.Size(260, 36);
            this.txtBuscar.TabIndex = 0;
            this.pistas.SetToolTip(this.txtBuscar, "Busca por empresa, NIT, contacto, teléfono o correo");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.Location = new System.Drawing.Point(20, 74);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(676, 486);
            this.dgvClientes.TabIndex = 1;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);

            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Controls.Add(this.lblNombre);
            this.pnlForm.Controls.Add(this.txtNombre);
            this.pnlForm.Controls.Add(this.lblNit);
            this.pnlForm.Controls.Add(this.txtNit);
            this.pnlForm.Controls.Add(this.lblTelefono);
            this.pnlForm.Controls.Add(this.txtTelefono);
            this.pnlForm.Controls.Add(this.lblContacto);
            this.pnlForm.Controls.Add(this.txtContacto);
            this.pnlForm.Controls.Add(this.lblCorreo);
            this.pnlForm.Controls.Add(this.txtCorreo);
            this.pnlForm.Controls.Add(this.lblDireccion);
            this.pnlForm.Controls.Add(this.txtDireccion);
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
            this.lblFormTitulo.Text = "Nuevo cliente";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Tag = "campo";
            this.lblNombre.Text = "NOMBRE DE LA EMPRESA *";

            this.txtNombre.Location = new System.Drawing.Point(20, 76);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(308, 36);
            this.txtNombre.TabIndex = 0;

            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(20, 120);
            this.lblNit.Name = "lblNit";
            this.lblNit.Tag = "campo";
            this.lblNit.Text = "NIT *";

            this.txtNit.Location = new System.Drawing.Point(20, 138);
            this.txtNit.MaxLength = 17;
            this.txtNit.Name = "txtNit";
            this.txtNit.PlaceholderText = "0000-000000-000-0";
            this.txtNit.Size = new System.Drawing.Size(168, 36);
            this.txtNit.TabIndex = 1;
            this.pistas.SetToolTip(this.txtNit, "14 dígitos; los guiones se ponen solos al guardar");
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloTelefono_KeyPress);

            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(200, 120);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Tag = "campo";
            this.lblTelefono.Text = "TELÉFONO *";

            this.txtTelefono.Location = new System.Drawing.Point(200, 138);
            this.txtTelefono.MaxLength = 9;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PlaceholderText = "0000-0000";
            this.txtTelefono.Size = new System.Drawing.Size(128, 36);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloTelefono_KeyPress);

            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(20, 182);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Tag = "campo";
            this.lblContacto.Text = "PERSONA DE CONTACTO *";

            this.txtContacto.Location = new System.Drawing.Point(20, 200);
            this.txtContacto.MaxLength = 100;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(308, 36);
            this.txtContacto.TabIndex = 3;
            this.txtContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);

            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(20, 244);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Tag = "campo";
            this.lblCorreo.Text = "CORREO";

            this.txtCorreo.Location = new System.Drawing.Point(20, 262);
            this.txtCorreo.MaxLength = 100;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PlaceholderText = "opcional";
            this.txtCorreo.Size = new System.Drawing.Size(308, 36);
            this.txtCorreo.TabIndex = 4;

            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(20, 306);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Tag = "campo";
            this.lblDireccion.Text = "DIRECCIÓN *";

            this.txtDireccion.Location = new System.Drawing.Point(20, 324);
            this.txtDireccion.MaxLength = 200;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(308, 98);
            this.txtDireccion.TabIndex = 5;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(308, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR";
            this.pistas.SetToolTip(this.btnGuardar, "Si hay una fila seleccionada la actualiza; si no, crea un cliente nuevo");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 36);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "NUEVO / LIMPIAR";
            this.pistas.SetToolTip(this.btnLimpiar, "Vacía el formulario para registrar un cliente nuevo");
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(180, 524);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 36);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "ELIMINAR";
            this.pistas.SetToolTip(this.btnEliminar, "No se puede si el cliente tiene contratos o usuarios");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvClientes;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label lblNit;
        private Guna.UI2.WinForms.Guna2TextBox txtNit;
        private System.Windows.Forms.Label lblTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private System.Windows.Forms.Label lblContacto;
        private Guna.UI2.WinForms.Guna2TextBox txtContacto;
        private System.Windows.Forms.Label lblCorreo;
        private Guna.UI2.WinForms.Guna2TextBox txtCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private Guna.UI2.WinForms.Guna2TextBox txtDireccion;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
