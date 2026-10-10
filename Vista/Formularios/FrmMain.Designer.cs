namespace Vista.Formularios
{
    partial class FrmMain
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
            this.pistas = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.navInicio = new Guna.UI2.WinForms.Guna2Button();
            this.navContratos = new Guna.UI2.WinForms.Guna2Button();
            this.navEquipos = new Guna.UI2.WinForms.Guna2Button();
            this.navMantenimientos = new Guna.UI2.WinForms.Guna2Button();
            this.navRepuestos = new Guna.UI2.WinForms.Guna2Button();
            this.navClientes = new Guna.UI2.WinForms.Guna2Button();
            this.navUsuarios = new Guna.UI2.WinForms.Guna2Button();
            this.navRoles = new Guna.UI2.WinForms.Guna2Button();
            this.navBitacora = new Guna.UI2.WinForms.Guna2Button();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.lineaUsuario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.btnSalir = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lineaSuperior = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();

            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.pnlMenu.Controls.Add(this.lblLogo);
            this.pnlMenu.Controls.Add(this.lblMarca);
            this.pnlMenu.Controls.Add(this.lblLema);
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Controls.Add(this.pnlUsuario);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(232, 720);
            this.pnlMenu.TabIndex = 0;

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Symbol", 24F);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.lblLogo.Location = new System.Drawing.Point(14, 16);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(52, 45);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "❄";

            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(64, 20);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(92, 32);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "SIGMA";

            this.lblLema.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(166)))), ((int)(((byte)(198)))));
            this.lblLema.AutoSize = true;
            this.lblLema.Location = new System.Drawing.Point(18, 66);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(200, 13);
            this.lblLema.TabIndex = 2;
            this.lblLema.Text = "Mantenimiento de aire acondicionado";

            this.flpMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpMenu.Controls.Add(this.navInicio);
            this.flpMenu.Controls.Add(this.navContratos);
            this.flpMenu.Controls.Add(this.navEquipos);
            this.flpMenu.Controls.Add(this.navMantenimientos);
            this.flpMenu.Controls.Add(this.navRepuestos);
            this.flpMenu.Controls.Add(this.navClientes);
            this.flpMenu.Controls.Add(this.navUsuarios);
            this.flpMenu.Controls.Add(this.navRoles);
            this.flpMenu.Controls.Add(this.navBitacora);
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Location = new System.Drawing.Point(14, 108);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(204, 430);
            this.flpMenu.TabIndex = 3;
            this.flpMenu.WrapContents = false;

            this.navInicio.Checked = true;
            this.navInicio.Location = new System.Drawing.Point(0, 0);
            this.navInicio.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navInicio.Name = "navInicio";
            this.navInicio.Size = new System.Drawing.Size(204, 40);
            this.navInicio.TabIndex = 0;
            this.navInicio.Tag = "menu";
            this.navInicio.Text = "Inicio";
            this.navInicio.Click += new System.EventHandler(this.nav_Click);

            this.navContratos.Location = new System.Drawing.Point(0, 46);
            this.navContratos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navContratos.Name = "navContratos";
            this.navContratos.Size = new System.Drawing.Size(204, 40);
            this.navContratos.TabIndex = 1;
            this.navContratos.Tag = "menu";
            this.navContratos.Text = "Contratos";
            this.navContratos.Click += new System.EventHandler(this.nav_Click);

            this.navEquipos.Location = new System.Drawing.Point(0, 92);
            this.navEquipos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navEquipos.Name = "navEquipos";
            this.navEquipos.Size = new System.Drawing.Size(204, 40);
            this.navEquipos.TabIndex = 2;
            this.navEquipos.Tag = "menu";
            this.navEquipos.Text = "Equipos";
            this.navEquipos.Click += new System.EventHandler(this.nav_Click);

            this.navMantenimientos.Location = new System.Drawing.Point(0, 138);
            this.navMantenimientos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navMantenimientos.Name = "navMantenimientos";
            this.navMantenimientos.Size = new System.Drawing.Size(204, 40);
            this.navMantenimientos.TabIndex = 3;
            this.navMantenimientos.Tag = "menu";
            this.navMantenimientos.Text = "Mantenimientos";
            this.navMantenimientos.Click += new System.EventHandler(this.nav_Click);

            this.navRepuestos.Location = new System.Drawing.Point(0, 184);
            this.navRepuestos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navRepuestos.Name = "navRepuestos";
            this.navRepuestos.Size = new System.Drawing.Size(204, 40);
            this.navRepuestos.TabIndex = 4;
            this.navRepuestos.Tag = "menu";
            this.navRepuestos.Text = "Repuestos";
            this.navRepuestos.Click += new System.EventHandler(this.nav_Click);

            this.navClientes.Location = new System.Drawing.Point(0, 230);
            this.navClientes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navClientes.Name = "navClientes";
            this.navClientes.Size = new System.Drawing.Size(204, 40);
            this.navClientes.TabIndex = 5;
            this.navClientes.Tag = "menu";
            this.navClientes.Text = "Clientes";
            this.navClientes.Click += new System.EventHandler(this.nav_Click);

            this.navUsuarios.Location = new System.Drawing.Point(0, 276);
            this.navUsuarios.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navUsuarios.Name = "navUsuarios";
            this.navUsuarios.Size = new System.Drawing.Size(204, 40);
            this.navUsuarios.TabIndex = 6;
            this.navUsuarios.Tag = "menu";
            this.navUsuarios.Text = "Usuarios";
            this.navUsuarios.Click += new System.EventHandler(this.nav_Click);

            this.navRoles.Location = new System.Drawing.Point(0, 322);
            this.navRoles.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navRoles.Name = "navRoles";
            this.navRoles.Size = new System.Drawing.Size(204, 40);
            this.navRoles.TabIndex = 7;
            this.navRoles.Tag = "menu";
            this.navRoles.Text = "Roles y permisos";
            this.navRoles.Click += new System.EventHandler(this.nav_Click);

            this.navBitacora.Location = new System.Drawing.Point(0, 368);
            this.navBitacora.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.navBitacora.Name = "navBitacora";
            this.navBitacora.Size = new System.Drawing.Size(204, 40);
            this.navBitacora.TabIndex = 8;
            this.navBitacora.Tag = "menu";
            this.navBitacora.Text = "Bitácora";
            this.navBitacora.Click += new System.EventHandler(this.nav_Click);

            this.pnlUsuario.Controls.Add(this.lineaUsuario);
            this.pnlUsuario.Controls.Add(this.lblUsuario);
            this.pnlUsuario.Controls.Add(this.lblRol);
            this.pnlUsuario.Controls.Add(this.btnSalir);
            this.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUsuario.Location = new System.Drawing.Point(0, 594);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(232, 126);
            this.pnlUsuario.TabIndex = 4;

            this.lineaUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(58)))), ((int)(((byte)(102)))));
            this.lineaUsuario.Location = new System.Drawing.Point(14, 0);
            this.lineaUsuario.Name = "lineaUsuario";
            this.lineaUsuario.Size = new System.Drawing.Size(204, 1);
            this.lineaUsuario.TabIndex = 0;

            this.lblUsuario.AutoEllipsis = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(18, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";

            this.lblRol.AutoEllipsis = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(166)))), ((int)(((byte)(198)))));
            this.lblRol.Location = new System.Drawing.Point(18, 38);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(200, 18);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Rol";

            this.btnSalir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(58)))), ((int)(((byte)(102)))));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(14, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(204, 38);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "CERRAR SESIÓN";
            this.pistas.SetToolTip(this.btnSalir, "Vuelve a la pantalla de inicio de sesión");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            this.pnlSuperior.BackColor = System.Drawing.Color.White;
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Controls.Add(this.lblFecha);
            this.pnlSuperior.Controls.Add(this.lineaSuperior);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(232, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1048, 64);
            this.pnlSuperior.TabIndex = 1;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(67, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio";

            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.lblFecha.Location = new System.Drawing.Point(708, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(320, 20);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lineaSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.lineaSuperior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineaSuperior.Location = new System.Drawing.Point(0, 63);
            this.lineaSuperior.Name = "lineaSuperior";
            this.lineaSuperior.Size = new System.Drawing.Size(1048, 1);
            this.lineaSuperior.TabIndex = 2;

            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(232, 64);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1048, 656);
            this.pnlContenido.TabIndex = 2;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGMA - Mantenimiento de aire acondicionado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.flpMenu.ResumeLayout(false);
            this.pnlUsuario.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip pistas;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private Guna.UI2.WinForms.Guna2Button navInicio;
        private Guna.UI2.WinForms.Guna2Button navContratos;
        private Guna.UI2.WinForms.Guna2Button navEquipos;
        private Guna.UI2.WinForms.Guna2Button navMantenimientos;
        private Guna.UI2.WinForms.Guna2Button navRepuestos;
        private Guna.UI2.WinForms.Guna2Button navClientes;
        private Guna.UI2.WinForms.Guna2Button navUsuarios;
        private Guna.UI2.WinForms.Guna2Button navRoles;
        private Guna.UI2.WinForms.Guna2Button navBitacora;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Panel lineaUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel lineaSuperior;
        private System.Windows.Forms.Panel pnlContenido;
    }
}
