namespace Vista.Formularios
{
    partial class FrmRoles
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
            this.pnlRoles = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoles = new System.Windows.Forms.Label();
            this.lblRolesNota = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.pnlPermisos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.lblPermisosNota = new System.Windows.Forms.Label();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnMarcar = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuitar = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.pnlPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.SuspendLayout();

            this.pnlRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRoles.Controls.Add(this.lblRoles);
            this.pnlRoles.Controls.Add(this.lblRolesNota);
            this.pnlRoles.Controls.Add(this.dgvRoles);
            this.pnlRoles.Location = new System.Drawing.Point(20, 20);
            this.pnlRoles.Name = "pnlRoles";
            this.pnlRoles.Size = new System.Drawing.Size(440, 580);
            this.pnlRoles.TabIndex = 0;
            this.pnlRoles.Tag = "tarjeta";

            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(20, 16);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Tag = "subtitulo";
            this.lblRoles.Text = "Roles del sistema";

            this.lblRolesNota.AutoSize = true;
            this.lblRolesNota.Location = new System.Drawing.Point(22, 42);
            this.lblRolesNota.Name = "lblRolesNota";
            this.lblRolesNota.Tag = "suave";
            this.lblRolesNota.Text = "Elige un rol para ver y cambiar sus permisos.";

            this.dgvRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoles.Location = new System.Drawing.Point(20, 74);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(400, 486);
            this.dgvRoles.TabIndex = 0;
            this.dgvRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellClick);

            this.pnlPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPermisos.Controls.Add(this.lblPermisos);
            this.pnlPermisos.Controls.Add(this.lblPermisosNota);
            this.pnlPermisos.Controls.Add(this.dgvPermisos);
            this.pnlPermisos.Controls.Add(this.btnGuardar);
            this.pnlPermisos.Controls.Add(this.btnMarcar);
            this.pnlPermisos.Controls.Add(this.btnQuitar);
            this.pnlPermisos.Location = new System.Drawing.Point(476, 20);
            this.pnlPermisos.Name = "pnlPermisos";
            this.pnlPermisos.Size = new System.Drawing.Size(624, 580);
            this.pnlPermisos.TabIndex = 1;
            this.pnlPermisos.Tag = "tarjeta";

            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(20, 16);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Tag = "subtitulo";
            this.lblPermisos.Text = "Permisos del rol";

            this.lblPermisosNota.AutoSize = true;
            this.lblPermisosNota.Location = new System.Drawing.Point(22, 42);
            this.lblPermisosNota.Name = "lblPermisosNota";
            this.lblPermisosNota.Tag = "suave";
            this.lblPermisosNota.Text = "Haz clic en una fila para dar o quitar el permiso y después guarda.";

            this.dgvPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermisos.Location = new System.Drawing.Point(20, 74);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(584, 438);
            this.dgvPermisos.TabIndex = 0;
            this.dgvPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermisos_CellClick);

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 524);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(210, 38);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Tag = "primario";
            this.btnGuardar.Text = "GUARDAR PERMISOS";
            this.pistas.SetToolTip(this.btnGuardar, "Los usuarios de ese rol reciben el cambio al abrir su siguiente pantalla");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnMarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarcar.Location = new System.Drawing.Point(240, 524);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(140, 38);
            this.btnMarcar.TabIndex = 2;
            this.btnMarcar.Tag = "secundario";
            this.btnMarcar.Text = "MARCAR TODOS";
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);

            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitar.Location = new System.Drawing.Point(390, 524);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(140, 38);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Tag = "secundario";
            this.btnQuitar.Text = "QUITAR TODOS";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlRoles);
            this.Controls.Add(this.pnlPermisos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRoles";
            this.Text = "Roles y permisos";
            this.Load += new System.EventHandler(this.FrmRoles_Load);
            this.pnlRoles.ResumeLayout(false);
            this.pnlRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlPermisos.ResumeLayout(false);
            this.pnlPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip pistas;
        private Guna.UI2.WinForms.Guna2Panel pnlRoles;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblRolesNota;
        private System.Windows.Forms.DataGridView dgvRoles;
        private Guna.UI2.WinForms.Guna2Panel pnlPermisos;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.Label lblPermisosNota;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnMarcar;
        private Guna.UI2.WinForms.Guna2Button btnQuitar;
    }
}
