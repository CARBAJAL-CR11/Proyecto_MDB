using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProyectoMDB
{
    public partial class FrmTablaProductora : Form
    {
        public FrmTablaProductora()
        {
            InitializeComponent();
            CargarGridDatos();
        }
        public void CargarGridDatos()
        {
            try
            {
                DataTable datos = SerProductora.CargarProductoras();
                dgvProductoras.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                dgvProductoras.Columns["codigoProductora"].HeaderText = "Codigo";
                dgvProductoras.Columns["nombreProductora"].HeaderText = "Nombre";
                dgvProductoras.Columns["direccionProductora"].HeaderText = "Dirección";
                dgvProductoras.Columns["correoProductora"].HeaderText = "Correo";
                dgvProductoras.Columns["telefonoProductora"].HeaderText = "Teléfono";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault();


            if (existingForm == null)
            {
                FrmFormProductora formulario = new FrmFormProductora();
                formulario.ShowDialog();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvProductoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion = dgvProductoras.CurrentRow.Index;

            string Codigo = dgvProductoras[0, posicion].Value.ToString();
            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault();


            if (existingForm == null)
            {
                FrmFormProductora formulario = new FrmFormProductora(Codigo);
                formulario.ShowDialog();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
