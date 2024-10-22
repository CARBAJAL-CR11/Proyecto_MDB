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
    public partial class FrmTablaProductoraSerie : Form
    {
        public FrmTablaProductoraSerie()
        {
            InitializeComponent();
            CargarGridDatos();
        }

        private void CargarGridDatos()
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

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = Convert.ToString(this.dgvProductoras.SelectedRows[0].Cells[0].Value)!;
            FrmFormSeries frm = Owner as FrmFormSeries;
            frm.txtProductora.Text = codigo;
            this.Close();
        }
    }
}
