using Services;
using System.Data;

namespace SistemaProyectoMDB
{
    public partial class FrmTablaSeries : Form
    {
        public FrmTablaSeries()
        {
            InitializeComponent();
            CargarGridDatos();
        }

        private void btnAgregarSerie_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault()!;


            if (existingForm == null)
            {
                FrmFormSeries formulario = new FrmFormSeries();
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CargarGridDatos()
        {
            try
            {
                DataTable datos = SerSerie.CargarSeries();
                dgvSeries.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                dgvSeries.Columns["codigoSerie"].HeaderText = "Codigo de serie";
                dgvSeries.Columns["nombreSerie"].HeaderText = "Nombre de serie";
                dgvSeries.Columns["fechaEmisionInicio"].HeaderText = "Fecha de emisión inicial";
                dgvSeries.Columns["fechaEmisionFin"].HeaderText = "Fecha de emisión final";
                dgvSeries.Columns["codigoDescripcion"].HeaderText = "Codigo de descripción";
                dgvSeries.Columns["descripcion"].HeaderText = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
