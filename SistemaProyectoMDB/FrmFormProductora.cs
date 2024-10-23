using Controller;
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
    public partial class FrmFormProductora : Form
    {
        private string codigo_productora;

        public FrmFormProductora(string codigo=null)
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                ControllerProductoras productoras = new ControllerProductoras
                {
                    codigoProductora = txtCodigo.Text,
                    nombreProductora=txtNombreProductora.Text,
                    direccionProductora=txtDirección.Text,
                    correoProductora=txtCorreo.Text,
                    telefonoProductora=mtxtTelefono.Text
                };
                string message;
                bool isSuccess = SerProductora.AgregarProductora(productoras, out message);

                if (isSuccess)
                {
                    this.Close();
                    MessageBox.Show("Productora registrada exitosamente.");
                }
                else
                {
                    MessageBox.Show(message, " Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FrmFormProductora_Load(object sender, EventArgs e)
        {

        }
    }
}
