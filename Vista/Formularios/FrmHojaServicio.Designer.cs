namespace Vista.Formularios
{
    partial class FrmHojaServicio
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
            this.pnlDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblIngeniero = new System.Windows.Forms.Label();
            this.lblProgramada = new System.Windows.Forms.Label();
            this.pnlHoja = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHoja = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRealizada = new System.Windows.Forms.Label();
            this.dtpRealizada = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTrabajo = new System.Windows.Forms.Label();
            this.txtTrabajo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlRepuestos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRepuestos = new System.Windows.Forms.Label();
            this.lblRepuesto = new System.Windows.Forms.Label();
            this.cboRepuesto = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuitar = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRepuestos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.pnlHoja.SuspendLayout();
            this.pnlRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos)).BeginInit();
            this.SuspendLayout();

            this.avisos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.avisos.ContainerControl = this;

            this.pnlDatos.Controls.Add(this.lblCodigo);
            this.pnlDatos.Controls.Add(this.lblEstadoActual);
            this.pnlDatos.Controls.Add(this.lblEquipo);
            this.pnlDatos.Controls.Add(this.lblUbicacion);
            this.pnlDatos.Controls.Add(this.lblIngeniero);
            this.pnlDatos.Controls.Add(this.lblProgramada);
            this.pnlDatos.Location = new System.Drawing.Point(16, 16);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(788, 96);
            this.pnlDatos.TabIndex = 10;
            this.pnlDatos.Tag = "tarjeta";

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(16, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Tag = "subtitulo";
            this.lblCodigo.Text = "MT-0000";

            this.lblEstadoActual.Location = new System.Drawing.Point(572, 13);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(200, 22);
            this.lblEstadoActual.Tag = "fuerte";
            this.lblEstadoActual.Text = "Estado";
            this.lblEstadoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblEquipo.AutoEllipsis = true;
            this.lblEquipo.Location = new System.Drawing.Point(16, 42);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(420, 20);
            this.lblEquipo.Tag = "texto";
            this.lblEquipo.Text = "Equipo";

            this.lblUbicacion.AutoEllipsis = true;
            this.lblUbicacion.Location = new System.Drawing.Point(16, 66);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(420, 20);
            this.lblUbicacion.Tag = "texto";
            this.lblUbicacion.Text = "Ubicación";

            this.lblIngeniero.AutoEllipsis = true;
            this.lblIngeniero.Location = new System.Drawing.Point(452, 42);
            this.lblIngeniero.Name = "lblIngeniero";
            this.lblIngeniero.Size = new System.Drawing.Size(320, 20);
            this.lblIngeniero.Tag = "texto";
            this.lblIngeniero.Text = "Ingeniero";

            this.lblProgramada.AutoEllipsis = true;
            this.lblProgramada.Location = new System.Drawing.Point(452, 66);
            this.lblProgramada.Name = "lblProgramada";
            this.lblProgramada.Size = new System.Drawing.Size(320, 20);
            this.lblProgramada.Tag = "texto";
            this.lblProgramada.Text = "Fecha programada";

            this.pnlHoja.Controls.Add(this.lblHoja);
            this.pnlHoja.Controls.Add(this.lblEstado);
            this.pnlHoja.Controls.Add(this.cboEstado);
            this.pnlHoja.Controls.Add(this.lblRealizada);
            this.pnlHoja.Controls.Add(this.dtpRealizada);
            this.pnlHoja.Controls.Add(this.lblDiagnostico);
            this.pnlHoja.Controls.Add(this.txtDiagnostico);
            this.pnlHoja.Controls.Add(this.lblTrabajo);
            this.pnlHoja.Controls.Add(this.txtTrabajo);
            this.pnlHoja.Controls.Add(this.lblObservaciones);
            this.pnlHoja.Controls.Add(this.txtObservaciones);
            this.pnlHoja.Location = new System.Drawing.Point(16, 124);
            this.pnlHoja.Name = "pnlHoja";
            this.pnlHoja.Size = new System.Drawing.Size(388, 452);
            this.pnlHoja.TabIndex = 0;
            this.pnlHoja.Tag = "tarjeta";

            this.lblHoja.AutoSize = true;
            this.lblHoja.Location = new System.Drawing.Point(16, 12);
            this.lblHoja.Name = "lblHoja";
            this.lblHoja.Tag = "subtitulo";
            this.lblHoja.Text = "Hoja de servicio";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(16, 46);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Tag = "campo";
            this.lblEstado.Text = "ESTADO DE LA VISITA *";

            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Location = new System.Drawing.Point(16, 64);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(174, 36);
            this.cboEstado.TabIndex = 0;
            this.pistas.SetToolTip(this.cboEstado, "En proceso: falta terminar. Completado: el trabajo quedó hecho");
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);

            this.lblRealizada.AutoSize = true;
            this.lblRealizada.Location = new System.Drawing.Point(198, 46);
            this.lblRealizada.Name = "lblRealizada";
            this.lblRealizada.Tag = "campo";
            this.lblRealizada.Text = "FECHA DE REALIZACIÓN";

            this.dtpRealizada.Location = new System.Drawing.Point(198, 64);
            this.dtpRealizada.Name = "dtpRealizada";
            this.dtpRealizada.Size = new System.Drawing.Size(174, 36);
            this.dtpRealizada.TabIndex = 1;

            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(16, 110);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Tag = "campo";
            this.lblDiagnostico.Text = "DIAGNÓSTICO *";

            this.txtDiagnostico.Location = new System.Drawing.Point(16, 128);
            this.txtDiagnostico.MaxLength = 500;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.PlaceholderText = "Qué se encontró al revisar el equipo";
            this.txtDiagnostico.Size = new System.Drawing.Size(356, 84);
            this.txtDiagnostico.TabIndex = 2;

            this.lblTrabajo.AutoSize = true;
            this.lblTrabajo.Location = new System.Drawing.Point(16, 222);
            this.lblTrabajo.Name = "lblTrabajo";
            this.lblTrabajo.Tag = "campo";
            this.lblTrabajo.Text = "TRABAJO REALIZADO";

            this.txtTrabajo.Location = new System.Drawing.Point(16, 240);
            this.txtTrabajo.MaxLength = 500;
            this.txtTrabajo.Multiline = true;
            this.txtTrabajo.Name = "txtTrabajo";
            this.txtTrabajo.PlaceholderText = "Qué se le hizo al equipo (obligatorio al completar)";
            this.txtTrabajo.Size = new System.Drawing.Size(356, 84);
            this.txtTrabajo.TabIndex = 3;

            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(16, 334);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Tag = "campo";
            this.lblObservaciones.Text = "OBSERVACIONES";

            this.txtObservaciones.Location = new System.Drawing.Point(16, 352);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "Recomendaciones o pendientes (opcional)";
            this.txtObservaciones.Size = new System.Drawing.Size(356, 84);
            this.txtObservaciones.TabIndex = 4;

            this.pnlRepuestos.Controls.Add(this.lblRepuestos);
            this.pnlRepuestos.Controls.Add(this.lblRepuesto);
            this.pnlRepuestos.Controls.Add(this.cboRepuesto);
            this.pnlRepuestos.Controls.Add(this.lblDisponible);
            this.pnlRepuestos.Controls.Add(this.lblCantidad);
            this.pnlRepuestos.Controls.Add(this.txtCantidad);
            this.pnlRepuestos.Controls.Add(this.btnAgregar);
            this.pnlRepuestos.Controls.Add(this.btnQuitar);
            this.pnlRepuestos.Controls.Add(this.dgvRepuestos);
            this.pnlRepuestos.Controls.Add(this.lblTotal);
            this.pnlRepuestos.Location = new System.Drawing.Point(416, 124);
            this.pnlRepuestos.Name = "pnlRepuestos";
            this.pnlRepuestos.Size = new System.Drawing.Size(388, 452);
            this.pnlRepuestos.TabIndex = 1;
            this.pnlRepuestos.Tag = "tarjeta";

            this.lblRepuestos.AutoSize = true;
            this.lblRepuestos.Location = new System.Drawing.Point(16, 12);
            this.lblRepuestos.Name = "lblRepuestos";
            this.lblRepuestos.Tag = "subtitulo";
            this.lblRepuestos.Text = "Repuestos consumidos";

            this.lblRepuesto.AutoSize = true;
            this.lblRepuesto.Location = new System.Drawing.Point(16, 46);
            this.lblRepuesto.Name = "lblRepuesto";
            this.lblRepuesto.Tag = "campo";
            this.lblRepuesto.Text = "REPUESTO";

            this.cboRepuesto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRepuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepuesto.ItemHeight = 30;
            this.cboRepuesto.Location = new System.Drawing.Point(16, 64);
            this.cboRepuesto.Name = "cboRepuesto";
            this.cboRepuesto.Size = new System.Drawing.Size(356, 36);
            this.cboRepuesto.TabIndex = 0;
            this.cboRepuesto.SelectedIndexChanged += new System.EventHandler(this.cboRepuesto_SelectedIndexChanged);

            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Location = new System.Drawing.Point(18, 104);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Tag = "suave";
            this.lblDisponible.Text = "Disponibles: 0";

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(16, 130);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Tag = "campo";
            this.lblCantidad.Text = "CANTIDAD";

            this.txtCantidad.Location = new System.Drawing.Point(16, 148);
            this.txtCantidad.MaxLength = 3;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PlaceholderText = "1";
            this.txtCantidad.Size = new System.Drawing.Size(100, 36);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloEnteros_KeyPress);

            this.btnAgregar.Location = new System.Drawing.Point(124, 148);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 36);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Tag = "primario";
            this.btnAgregar.Text = "AGREGAR";
            this.pistas.SetToolTip(this.btnAgregar, "Agrega el repuesto a la hoja. Se descuenta del inventario al guardar");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnQuitar.Location = new System.Drawing.Point(252, 148);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(120, 36);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Tag = "peligro";
            this.btnQuitar.Text = "QUITAR";
            this.pistas.SetToolTip(this.btnQuitar, "Quita de la hoja el repuesto seleccionado en la tabla");
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            this.dgvRepuestos.Location = new System.Drawing.Point(16, 196);
            this.dgvRepuestos.Name = "dgvRepuestos";
            this.dgvRepuestos.Size = new System.Drawing.Size(356, 204);
            this.dgvRepuestos.TabIndex = 4;

            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(16, 414);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Tag = "fuerte";
            this.lblTotal.Text = "Total en repuestos: $0.00";

            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(18, 598);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Tag = "suave";
            this.lblAviso.Text = "Los campos con * son obligatorios.";

            this.btnGuardar.Location = new System.Drawing.Point(524, 588);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 38);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR HOJA";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCerrar.Location = new System.Drawing.Point(712, 588);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(92, 38);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Tag = "secundario";
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(820, 640);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlHoja);
            this.Controls.Add(this.pnlRepuestos);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHojaServicio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hoja de servicio";
            this.Load += new System.EventHandler(this.FrmHojaServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlHoja.ResumeLayout(false);
            this.pnlHoja.PerformLayout();
            this.pnlRepuestos.ResumeLayout(false);
            this.pnlRepuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ErrorProvider avisos;
        private System.Windows.Forms.ToolTip pistas;
        private Guna.UI2.WinForms.Guna2Panel pnlDatos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblIngeniero;
        private System.Windows.Forms.Label lblProgramada;
        private Guna.UI2.WinForms.Guna2Panel pnlHoja;
        private System.Windows.Forms.Label lblHoja;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private System.Windows.Forms.Label lblRealizada;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpRealizada;
        private System.Windows.Forms.Label lblDiagnostico;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTrabajo;
        private Guna.UI2.WinForms.Guna2TextBox txtTrabajo;
        private System.Windows.Forms.Label lblObservaciones;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private Guna.UI2.WinForms.Guna2Panel pnlRepuestos;
        private System.Windows.Forms.Label lblRepuestos;
        private System.Windows.Forms.Label lblRepuesto;
        private Guna.UI2.WinForms.Guna2ComboBox cboRepuesto;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblCantidad;
        private Guna.UI2.WinForms.Guna2TextBox txtCantidad;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
        private Guna.UI2.WinForms.Guna2Button btnQuitar;
        private System.Windows.Forms.DataGridView dgvRepuestos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAviso;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
    }
}
