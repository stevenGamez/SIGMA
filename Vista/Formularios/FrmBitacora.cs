using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Bitácora: solo se puede consultar
    public partial class FrmBitacora : Form
    {
        private RegistroActividad[] cargados = new RegistroActividad[0];

        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);

            dgvBitacora.Columns.Clear();
            EstiloGrid.ColumnaFija(dgvBitacora, "Fecha", "Fecha y hora", 156);
            EstiloGrid.ColumnaFija(dgvBitacora, "Usuario", "Usuario", 110);
            EstiloGrid.Columna(dgvBitacora, "Nombre", "Nombre", 26);
            EstiloGrid.Columna(dgvBitacora, "Accion", "Acción", 74);

            try
            {
                cargados = RegistroActividadDatos.Listar();
            }
            catch (Exception ex)
            {
                lblCuenta.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
                return;
            }

            Mostrar("");
        }

        private void Mostrar(string filtro)
        {
            dgvBitacora.Rows.Clear();
            filtro = filtro.Trim().ToLower();

            foreach (RegistroActividad r in cargados)
            {
                if (!Filtro.Coincide(filtro, r.Usuario, r.Nombre, r.Accion)) continue;
                dgvBitacora.Rows.Add(r.Fecha.ToString("dd/MM/yyyy hh:mm tt"), r.Usuario, r.Nombre, r.Accion);
            }

            dgvBitacora.ClearSelection();
            lblCuenta.Text = "Mostrando " + dgvBitacora.Rows.Count + " de " + cargados.Length + " acciones";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Mostrar(txtBuscar.Text);
        }
    }
}
