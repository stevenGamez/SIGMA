using System;
using System.Windows.Forms;
using Modelo.Modelo;
using Vista.Estilos;
using Vista.Utilidades;

namespace Vista.Formularios
{

    // Pantalla de inicio con el resumen
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            Tema.Aplicar(this);

            lblSaludo.Text = "Hola, " + Sesion.Actual.Nombre.Trim().Split(' ')[0];
            lblResumen.Text = "Este es el resumen general del sistema.";
            if (Sesion.EsIngeniero) lblResumen.Text = "Estas son las visitas que tienes asignadas.";
            if (Sesion.EsCliente) lblResumen.Text = "Este es el estado de las instalaciones de " + Sesion.Actual.Cliente + ".";

            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvVisitas.Columns.Clear();
            EstiloGrid.ColumnaFija(dgvVisitas, "Fecha", "Fecha", 100);
            EstiloGrid.ColumnaFija(dgvVisitas, "Codigo", "Código", 84);
            EstiloGrid.ColumnaFija(dgvVisitas, "Tipo", "Tipo", 100);
            EstiloGrid.Columna(dgvVisitas, "Equipo", "Equipo", 38);
            EstiloGrid.Columna(dgvVisitas, "Cliente", "Cliente", 34);
            EstiloGrid.Columna(dgvVisitas, "Ingeniero", "Ingeniero", 28);
            EstiloGrid.ColumnaFija(dgvVisitas, "Estado", "Estado", 110);
        }

        private void CargarDatos()
        {
            dgvVisitas.Rows.Clear();

            try
            {
                MostrarPrimeraTarjeta();

                lblValorDos.Text = EquipoDatos.Listar(Sesion.ClienteVisible).Length.ToString();
                if (Sesion.EsCliente) lblNombreDos.Text = "Equipos instalados";

                Mantenimiento[] visitas = MantenimientoDatos.Listar(Sesion.ClienteVisible, Sesion.IngenieroVisible);
                int pendientes = 0;
                int completadas = 0;

                // se recorre al revés para que la visita más cercana salga primero
                for (int i = visitas.Length - 1; i >= 0; i--)
                {
                    Mantenimiento m = visitas[i];
                    if (m.Estado == Mantenimiento.Completado) completadas++;
                    if (!m.Pendiente) continue;

                    pendientes++;
                    dgvVisitas.Rows.Add(m.FechaProgramada.ToString("dd/MM/yyyy"), m.Codigo, m.Tipo,
                                        m.Equipo, m.Cliente, m.Ingeniero, m.Estado);
                }

                lblValorTres.Text = pendientes.ToString();
                lblValorCuatro.Text = completadas.ToString();
                dgvVisitas.ClearSelection();
            }
            catch (Exception ex)
            {
                lblVisitasNota.Text = "Sin conexión a la base de datos";
                Mensajes.SinConexion(ex);
            }
        }

        // el ingeniero no ve contratos, entonces ve los repuestos con poca existencia
        private void MostrarPrimeraTarjeta()
        {
            bool veContratos = Sesion.Puede(Permisos.ContratosVer);
            if (Sesion.Puede(Permisos.ContratosGestionar)) veContratos = true;

            if (veContratos)
            {
                int vigentes = 0;
                foreach (Contrato c in ContratoDatos.Listar(Sesion.ClienteVisible))
                    if (c.Estado == "Vigente") vigentes++;

                lblValorUno.Text = vigentes.ToString();
                lblNombreUno.Text = "Contratos vigentes";
                return;
            }

            int bajos = 0;
            foreach (Repuesto r in RepuestoDatos.Listar())
                if (r.BajoStock) bajos++;

            lblValorUno.Text = bajos.ToString();
            lblNombreUno.Text = "Repuestos con existencia baja";
        }

        private void dgvVisitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVisitas.Columns[e.ColumnIndex].Name == "Estado") EstiloGrid.PintarEstado(e);
        }
    }
}
