namespace Vista.Formularios
{
    partial class FrmLogin
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
            this.bordes = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.arrastre = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.avisos = new System.Windows.Forms.ErrorProvider(this.components);
            this.pistas = new System.Windows.Forms.ToolTip(this.components);
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.pnlMarca = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.lblPie = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkVer = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblEspera = new System.Windows.Forms.Label();
            this.btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).BeginInit();
            this.pnlMarca.SuspendLayout();
            this.SuspendLayout();

            this.bordes.BorderRadius = 14;
            this.bordes.ContainerControl = this;
            this.bordes.DockForm = false;
            this.bordes.ResizeForm = false;

            this.arrastre.TargetControl = this.pnlMarca;

            this.avisos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.avisos.ContainerControl = this;

            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);

            this.pnlMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.pnlMarca.Controls.Add(this.lblLogo);
            this.pnlMarca.Controls.Add(this.lblMarca);
            this.pnlMarca.Controls.Add(this.lblLema);
            this.pnlMarca.Controls.Add(this.lblPie);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarca.Location = new System.Drawing.Point(0, 0);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(380, 500);
            this.pnlMarca.TabIndex = 10;

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Symbol", 44F);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(196)))), ((int)(((byte)(232)))));
            this.lblLogo.Location = new System.Drawing.Point(34, 112);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(90, 78);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "❄";

            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(40, 196);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(150, 54);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "SIGMA";

            this.lblLema.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(212)))), ((int)(((byte)(230)))));
            this.lblLema.Location = new System.Drawing.Point(46, 258);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(300, 70);
            this.lblLema.TabIndex = 2;
            this.lblLema.Text = "Sistema Integral de Gestión de\r\nMantenimiento de Aire acondicionado";

            this.lblPie.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.lblPie.Location = new System.Drawing.Point(46, 456);
            this.lblPie.Name = "lblPie";
            this.lblPie.Size = new System.Drawing.Size(300, 20);
            this.lblPie.TabIndex = 3;
            this.lblPie.Text = "Contratos · Equipos · Visitas · Repuestos";

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FillColor = System.Drawing.Color.White;
            this.btnCerrar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(125)))), ((int)(((byte)(152)))));
            this.btnCerrar.Location = new System.Drawing.Point(812, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(42, 30);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.TabStop = false;
            this.pistas.SetToolTip(this.btnCerrar, "Salir de SIGMA");

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.lblTitulo.Location = new System.Drawing.Point(430, 84);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 36);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Iniciar sesión";

            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(434, 126);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(220, 15);
            this.lblSub.TabIndex = 5;
            this.lblSub.Tag = "suave";
            this.lblSub.Text = "Ingresa con tu usuario y tu contraseña.";

            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(432, 176);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(56, 13);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Tag = "campo";
            this.lblUsuario.Text = "USUARIO";

            this.txtUsuario.Location = new System.Drawing.Point(430, 196);
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceholderText = "Tu nombre de usuario";
            this.txtUsuario.Size = new System.Drawing.Size(380, 42);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextOffset = new System.Drawing.Point(4, 0);
            this.pistas.SetToolTip(this.txtUsuario, "Por ejemplo: admin");

            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(432, 258);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(82, 13);
            this.lblClave.TabIndex = 7;
            this.lblClave.Tag = "campo";
            this.lblClave.Text = "CONTRASEÑA";

            this.txtClave.Location = new System.Drawing.Point(430, 278);
            this.txtClave.MaxLength = 60;
            this.txtClave.Name = "txtClave";
            this.txtClave.PlaceholderText = "Tu contraseña";
            this.txtClave.Size = new System.Drawing.Size(380, 42);
            this.txtClave.TabIndex = 1;
            this.txtClave.TextOffset = new System.Drawing.Point(4, 0);
            this.txtClave.UseSystemPasswordChar = true;

            this.chkVer.AutoSize = true;
            this.chkVer.Location = new System.Drawing.Point(432, 332);
            this.chkVer.Name = "chkVer";
            this.chkVer.Size = new System.Drawing.Size(140, 21);
            this.chkVer.TabIndex = 2;
            this.chkVer.Text = "Mostrar contraseña";
            this.chkVer.CheckedChanged += new System.EventHandler(this.chkVer_CheckedChanged);

            this.lblEspera.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEspera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.lblEspera.Location = new System.Drawing.Point(430, 366);
            this.lblEspera.Name = "lblEspera";
            this.lblEspera.Size = new System.Drawing.Size(380, 20);
            this.lblEspera.TabIndex = 8;
            this.lblEspera.Visible = false;

            this.btnEntrar.Location = new System.Drawing.Point(430, 396);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(380, 46);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Tag = "primario";
            this.btnEntrar.Text = "ENTRAR";
            this.pistas.SetToolTip(this.btnEntrar, "La tecla Enter hace lo mismo");
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);

            this.AcceptButton = this.btnEntrar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.chkVer);
            this.Controls.Add(this.lblEspera);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.pnlMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGMA - Iniciar sesión";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.avisos)).EndInit();
            this.pnlMarca.ResumeLayout(false);
            this.pnlMarca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2BorderlessForm bordes;
        private Guna.UI2.WinForms.Guna2DragControl arrastre;
        private System.Windows.Forms.ErrorProvider avisos;
        private System.Windows.Forms.ToolTip pistas;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Panel pnlMarca;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.Label lblPie;
        private Guna.UI2.WinForms.Guna2ControlBox btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUsuario;
        private Guna.UI2.WinForms.Guna2TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private Guna.UI2.WinForms.Guna2TextBox txtClave;
        private Guna.UI2.WinForms.Guna2CheckBox chkVer;
        private System.Windows.Forms.Label lblEspera;
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
    }
}
