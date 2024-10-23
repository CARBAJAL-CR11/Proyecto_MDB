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

        public FrmFormProductora(string codigo = null)
        {
            InitializeComponent();
            txtCodigo.ReadOnly = false;
            btnEliminar.Visible = false;
            if (codigo != null)
            {
                DataTable datos = SerProductora.cargarUnaProductora(codigo);
                DataRow row = datos.Rows[0];
                txtCodigo.ReadOnly = true;
                btnEliminar.Visible = true;
                codigo_productora = codigo;
                txtNombreProductora.Text = row["nombreProductora"].ToString();
                txtCodigo.Text = row["codigoProductora"].ToString();
                txtCorreo.Text = row["correoProductora"].ToString();
                txtDirección.Text = row["direccionProductora"].ToString();
                mtxtTelefono.Text = row["telefonoProductora"].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerProductoras productoras = new ControllerProductoras
                {
                    codigoProductora = txtCodigo.Text,
                    nombreProductora = txtNombreProductora.Text,
                    direccionProductora = txtDirección.Text,
                    correoProductora = txtCorreo.Text,
                    telefonoProductora = mtxtTelefono.Text
                };
                if (codigo_productora != null)
                {
                    string message;
                    bool isSuccess = SerProductora.ActualizarProductora(productoras, out message);

                    if (isSuccess)
                    {
                        MessageBox.Show("Productora actualizada exitosamente.");
                        FrmTablaProductora tablaproductora = Owner as FrmTablaProductora;
                        tablaproductora.CargarGridDatos();
                        this.Close();
                       
                    }
                    else
                    {
                        MessageBox.Show(message, " Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string message;
                    bool isSuccess = SerProductora.AgregarProductora(productoras, out message);

                    if (isSuccess)
                    {
                        MessageBox.Show("Productora registrada exitosamente.");

                        FrmTablaProductora tablaproductora = Owner as FrmTablaProductora;
                        tablaproductora.CargarGridDatos();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message, " Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FrmFormProductora_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eLiminar la productora?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    /*CtrJugador jugador = new CtrJugador();
                    jugador.IdJugador = CtrJugador._idJugador;*/
                    string message;
                    bool isSuccess = SerProductora.EliminarProductora(codigo_productora, out message);
                    if (isSuccess)
                    {
                        MessageBox.Show("La productora fue eliminada", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, " Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
