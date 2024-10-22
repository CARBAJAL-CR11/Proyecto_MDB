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
    public partial class FrmFormSeries : Form
    {
        public int accion;
        public FrmFormSeries(int _accion)
        {
            InitializeComponent();
            if (_accion == 1) {
                btnGuardar.Text = "Actualizar";
                txtCodigoSerie.Enabled = false;
            }
            else
            {
                txtCodigoSerie.Enabled= true;
                btnGuardar.Text = "Guardar";
            }
            accion = _accion;
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
                try
                {
                    ControllerDescripcion descripcion = new ControllerDescripcion
                    {
                        codigoDescripcion = txtCodigoDescripcion.Text,
                        codigoProductora = txtProductora.Text,
                        descripcion = txtDescripcion.Text,
                        clasificacionEdad = cmbClasificacion.Text,

                    };
                    ControllerSerie serie = new ControllerSerie
                    {
                        codigoSerie = txtCodigoSerie.Text,
                        nombreSerie = txtNombreSerie.Text,
                        fechaEmisionInicio = dtFechaInicio.Value.ToString("yyyy/MM/dd"),
                        fechaEmisionFin = dtFechaFin.Value.ToString("yyyy/MM/dd"),
                        codigoDescripcion = txtCodigoDescripcion.Text
                    };

                    string message;
                    bool isSuccess;
                    if (accion==1)
                    {
                        isSuccess = SerDescripcion.ActualizarDescripcion(descripcion, out message);
                    }
                    else
                    {
                        isSuccess = SerDescripcion.AgregarDescripcion(descripcion,out message);
                    }
                    if (isSuccess)
                    {
                        bool isSuccess2;
                        if (accion==1)
                        {
                            isSuccess2 = SerSerie.ActualizarSerie(serie, out message);
                        }
                        else
                        {
                            isSuccess2 = SerSerie.AgregarSerie(serie, out message);
                        }
                        if (isSuccess2)
                        {
                            FrmTablaSeries frmseries = Owner as FrmTablaSeries;
                            frmseries.CargarGridDatos();
                            this.Close();
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
