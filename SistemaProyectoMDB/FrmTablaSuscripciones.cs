using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Services;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProyectoMDB
{
    public partial class FrmTablaSuscripciones : Form
    {
        public FrmTablaSuscripciones()
        {
            InitializeComponent();
            CargarGridDatos();
        }
        private void CargarGridDatos()
        {
            try
            {
                DataTable datos = SerSuscripcion.CargarVistaSuscripciones();
                DgSuscripciones.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                DgSuscripciones.Columns["codigoSuscripcion"].HeaderText = "Codigo de Suscripción";
                DgSuscripciones.Columns["nombreSuscripcion"].HeaderText = "Nombre del Suscripcion";
                DgSuscripciones.Columns["descripcion"].HeaderText = "Descripción";
                DgSuscripciones.Columns["cantidadUsuarios"].HeaderText = "Cantidad de Usuarios Activos";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
