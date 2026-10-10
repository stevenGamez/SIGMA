namespace Vista.Formularios
{
    partial class FrmInicio
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
            this.lblSaludo = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.tlpTarjetas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlUno = new Guna.UI2.WinForms.Guna2Panel();
            this.lblValorUno = new System.Windows.Forms.Label();
            this.lblNombreUno = new System.Windows.Forms.Label();
            this.pnlDos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblValorDos = new System.Windows.Forms.Label();
            this.lblNombreDos = new System.Windows.Forms.Label();
            this.pnlTres = new Guna.UI2.WinForms.Guna2Panel();
            this.lblValorTres = new System.Windows.Forms.Label();
            this.lblNombreTres = new System.Windows.Forms.Label();
            this.pnlCuatro = new Guna.UI2.WinForms.Guna2Panel();
            this.lblValorCuatro = new System.Windows.Forms.Label();
            this.lblNombreCuatro = new System.Windows.Forms.Label();
            this.pnlVisitas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblVisitas = new System.Windows.Forms.Label();
            this.lblVisitasNota = new System.Windows.Forms.Label();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.tlpTarjetas.SuspendLayout();
            this.pnlUno.SuspendLayout();
            this.pnlDos.SuspendLayout();
            this.pnlTres.SuspendLayout();
            this.pnlCuatro.SuspendLayout();
            this.pnlVisitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.SuspendLayout();

            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Location = new System.Drawing.Point(18, 16);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Tag = "titulo";
            this.lblSaludo.Text = "Hola";

            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(21, 48);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Tag = "suave";
            this.lblResumen.Text = "Resumen";

            this.tlpTarjetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTarjetas.ColumnCount = 4;
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTarjetas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTarjetas.Controls.Add(this.pnlUno, 0, 0);
            this.tlpTarjetas.Controls.Add(this.pnlDos, 1, 0);
            this.tlpTarjetas.Controls.Add(this.pnlTres, 2, 0);
            this.tlpTarjetas.Controls.Add(this.pnlCuatro, 3, 0);
            this.tlpTarjetas.Location = new System.Drawing.Point(20, 82);
            this.tlpTarjetas.Name = "tlpTarjetas";
            this.tlpTarjetas.RowCount = 1;
            this.tlpTarjetas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTarjetas.Size = new System.Drawing.Size(1096, 104);
            this.tlpTarjetas.TabIndex = 0;

            this.pnlUno.Controls.Add(this.lblValorUno);
            this.pnlUno.Controls.Add(this.lblNombreUno);
            this.pnlUno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUno.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlUno.Name = "pnlUno";
            this.pnlUno.Tag = "tarjeta";

            this.lblValorUno.AutoSize = true;
            this.lblValorUno.Location = new System.Drawing.Point(16, 12);
            this.lblValorUno.Name = "lblValorUno";
            this.lblValorUno.Tag = "numero";
            this.lblValorUno.Text = "0";

            this.lblNombreUno.AutoSize = true;
            this.lblNombreUno.Location = new System.Drawing.Point(20, 68);
            this.lblNombreUno.Name = "lblNombreUno";
            this.lblNombreUno.Tag = "suave";
            this.lblNombreUno.Text = "Contratos vigentes";

            this.pnlDos.Controls.Add(this.lblValorDos);
            this.pnlDos.Controls.Add(this.lblNombreDos);
            this.pnlDos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDos.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlDos.Name = "pnlDos";
            this.pnlDos.Tag = "tarjeta";

            this.lblValorDos.AutoSize = true;
            this.lblValorDos.Location = new System.Drawing.Point(16, 12);
            this.lblValorDos.Name = "lblValorDos";
            this.lblValorDos.Tag = "numero";
            this.lblValorDos.Text = "0";

            this.lblNombreDos.AutoSize = true;
            this.lblNombreDos.Location = new System.Drawing.Point(20, 68);
            this.lblNombreDos.Name = "lblNombreDos";
            this.lblNombreDos.Tag = "suave";
            this.lblNombreDos.Text = "Equipos registrados";

            this.pnlTres.Controls.Add(this.lblValorTres);
            this.pnlTres.Controls.Add(this.lblNombreTres);
            this.pnlTres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTres.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlTres.Name = "pnlTres";
            this.pnlTres.Tag = "tarjeta";

            this.lblValorTres.AutoSize = true;
            this.lblValorTres.Location = new System.Drawing.Point(16, 12);
            this.lblValorTres.Name = "lblValorTres";
            this.lblValorTres.Tag = "numero";
            this.lblValorTres.Text = "0";

            this.lblNombreTres.AutoSize = true;
            this.lblNombreTres.Location = new System.Drawing.Point(20, 68);
            this.lblNombreTres.Name = "lblNombreTres";
            this.lblNombreTres.Tag = "suave";
            this.lblNombreTres.Text = "Visitas pendientes";

            this.pnlCuatro.Controls.Add(this.lblValorCuatro);
            this.pnlCuatro.Controls.Add(this.lblNombreCuatro);
            this.pnlCuatro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuatro.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlCuatro.Name = "pnlCuatro";
            this.pnlCuatro.Tag = "tarjeta";

            this.lblValorCuatro.AutoSize = true;
            this.lblValorCuatro.Location = new System.Drawing.Point(16, 12);
            this.lblValorCuatro.Name = "lblValorCuatro";
            this.lblValorCuatro.Tag = "numero";
            this.lblValorCuatro.Text = "0";

            this.lblNombreCuatro.AutoSize = true;
            this.lblNombreCuatro.Location = new System.Drawing.Point(20, 68);
            this.lblNombreCuatro.Name = "lblNombreCuatro";
            this.lblNombreCuatro.Tag = "suave";
            this.lblNombreCuatro.Text = "Visitas completadas";

            this.pnlVisitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVisitas.Controls.Add(this.lblVisitas);
            this.pnlVisitas.Controls.Add(this.lblVisitasNota);
            this.pnlVisitas.Controls.Add(this.dgvVisitas);
            this.pnlVisitas.Location = new System.Drawing.Point(20, 202);
            this.pnlVisitas.Name = "pnlVisitas";
            this.pnlVisitas.Size = new System.Drawing.Size(1080, 398);
            this.pnlVisitas.TabIndex = 1;
            this.pnlVisitas.Tag = "tarjeta";

            this.lblVisitas.AutoSize = true;
            this.lblVisitas.Location = new System.Drawing.Point(20, 16);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Tag = "subtitulo";
            this.lblVisitas.Text = "Próximas visitas";

            this.lblVisitasNota.AutoSize = true;
            this.lblVisitasNota.Location = new System.Drawing.Point(22, 42);
            this.lblVisitasNota.Name = "lblVisitasNota";
            this.lblVisitasNota.Tag = "suave";
            this.lblVisitasNota.Text = "Visitas programadas o en proceso, de la más cercana a la más lejana.";

            this.dgvVisitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitas.Location = new System.Drawing.Point(20, 74);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.Size = new System.Drawing.Size(1040, 304);
            this.dgvVisitas.TabIndex = 0;
            this.dgvVisitas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVisitas_CellFormatting);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1120, 620);
            this.Controls.Add(this.lblSaludo);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.tlpTarjetas);
            this.Controls.Add(this.pnlVisitas);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.tlpTarjetas.ResumeLayout(false);
            this.pnlUno.ResumeLayout(false);
            this.pnlUno.PerformLayout();
            this.pnlDos.ResumeLayout(false);
            this.pnlDos.PerformLayout();
            this.pnlTres.ResumeLayout(false);
            this.pnlTres.PerformLayout();
            this.pnlCuatro.ResumeLayout(false);
            this.pnlCuatro.PerformLayout();
            this.pnlVisitas.ResumeLayout(false);
            this.pnlVisitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.TableLayoutPanel tlpTarjetas;
        private Guna.UI2.WinForms.Guna2Panel pnlUno;
        private System.Windows.Forms.Label lblValorUno;
        private System.Windows.Forms.Label lblNombreUno;
        private Guna.UI2.WinForms.Guna2Panel pnlDos;
        private System.Windows.Forms.Label lblValorDos;
        private System.Windows.Forms.Label lblNombreDos;
        private Guna.UI2.WinForms.Guna2Panel pnlTres;
        private System.Windows.Forms.Label lblValorTres;
        private System.Windows.Forms.Label lblNombreTres;
        private Guna.UI2.WinForms.Guna2Panel pnlCuatro;
        private System.Windows.Forms.Label lblValorCuatro;
        private System.Windows.Forms.Label lblNombreCuatro;
        private Guna.UI2.WinForms.Guna2Panel pnlVisitas;
        private System.Windows.Forms.Label lblVisitas;
        private System.Windows.Forms.Label lblVisitasNota;
        private System.Windows.Forms.DataGridView dgvVisitas;
    }
}
