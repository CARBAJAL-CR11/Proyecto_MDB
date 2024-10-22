using Controller;
using Model;
using Services;
using System.Data;
using System.Windows.Forms;

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
                FrmFormSeries formulario = new FrmFormSeries(0);
                AddOwnedForm(formulario);
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void CargarGridDatos()
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
                dgvSeries.Columns["clasificacionEdad"].HeaderText = "Clasificación";
                dgvSeries.Columns["codigoProductora"].HeaderText = "Productora";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSeries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult d1 = MessageBox.Show("Desea actualizar el registro","Advertencia",MessageBoxButtons.YesNo);
            if (d1 == DialogResult.Yes)
            {
                string codigo = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[0].Value)!;
                string nombre = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[1].Value)!;
                string fecha_inicial = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[2].Value)!;
                string fecha_final = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[3].Value)!;
                string codigo_descripcion = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[4].Value)!;
                string descripcion = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[5].Value)!;
                string clasificacion = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[6].Value)!;
                string codigo_productora = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[7].Value)!;
                FrmFormSeries frmseries = new FrmFormSeries(1);
                AddOwnedForm(frmseries);
                frmseries.txtCodigoSerie.Text = codigo;
                frmseries.txtNombreSerie.Text = nombre;
                frmseries.dtFechaInicio.Text = fecha_inicial;
                frmseries.dtFechaFin.Text = fecha_final;
                frmseries.txtCodigoDescripcion.Text = codigo_descripcion;
                frmseries.txtDescripcion.Text = descripcion;
                frmseries.txtProductora.Text = codigo_productora;
                frmseries.cmbClasificacion.Text = clasificacion;
                frmseries.Show();
            }
            else
            {
                DialogResult d2 = MessageBox.Show("Desea eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);
                if (d2 == DialogResult.Yes)
                {
                    ControllerSerie controllerSerie = new ControllerSerie();
                    controllerSerie.codigoSerie = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[0].Value)!;
                    ControllerDescripcion controllerDescripcion = new ControllerDescripcion();
                    controllerDescripcion.codigoDescripcion = Convert.ToString(this.dgvSeries.SelectedRows[0].Cells[4].Value)!;
                    string message;
                    bool isSuccess = SerSerie.EliminarSerie(controllerSerie, out message);
                    if (isSuccess)
                    {
                        bool isSuccess2 = SerDescripcion.EliminarDescripcion(controllerDescripcion, out message);
                        if (isSuccess2)
                        {
                            CargarGridDatos();
                            MessageBox.Show("Acción realizada exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show(message, " Error al realizar la acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(message, " Error al realizar la acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
    }
}
