namespace Vista.Formularios
{
    partial class FrmBitacora
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
            this.pnlTabla = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();

            this.pnlTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabla.Controls.Add(this.lblTitulo);
            this.pnlTabla.Controls.Add(this.lblCuenta);
            this.pnlTabla.Controls.Add(this.txtBuscar);
            this.pnlTabla.Controls.Add(this.dgvBitacora);
            this.pnlTabla.Location = new System.Drawing.Point(20, 20);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(1080, 580);
            this.pnlTabla.TabIndex = 0;
            this.pnlTabla.Tag = "tarjeta";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Tag = "subtitulo";
            this.lblTitulo.Text = "Bitácora de actividad";

            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(22, 42);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Tag = "suave";
            this.lblCuenta.Text = "Mostrando 0 acciones";

            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(780, 18);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar en la bitácora...";
            this.txtBuscar.Size = new System.Drawing.Size(280, 36);
            this.txtBuscar.TabIndex = 0;
            this.pistas.SetToolTip(this.txtBuscar, "Busca por usuario, nombre o acción");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.dgvBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBitacora.Location = new System.Drawing.Point(20, 74);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.Size = new System.Drawing.Size(1040, 486);
            this.dgvBitacora.TabIndex = 1;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.pnlTabla);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBitacora";
            this.Text = "Bitácora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.pnlTabla.ResumeLayout(false);
            this.pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip pistas;
        private Guna.UI2.WinForms.Guna2Panel pnlTabla;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCuenta;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvBitacora;
    }
}
