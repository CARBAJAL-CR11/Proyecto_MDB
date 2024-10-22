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
    public partial class FrmFormSeries : Form
    {

        public FrmFormSeries()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProductora_Click(object sender, EventArgs e)
        {
            FrmTablaProductoraSerie frmTablaProductora = new FrmTablaProductoraSerie();
            AddOwnedForm(frmTablaProductora);
            frmTablaProductora.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigoSerie.Text.Trim()==""||txtDescripcion.Text.Trim()==""|| txtNombreSerie.Text.Trim()==""||txtProductora.Text.Trim()==""|| cmbClasificacion.Text=="")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {

            }
        }
    }
}
