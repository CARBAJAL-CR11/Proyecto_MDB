using System;
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
    public partial class FrmTablaPerfiles : Form
    {
        public FrmTablaPerfiles()
        {
            InitializeComponent();
            CargarGridDatos();
        }
        private void CargarGridDatos()
        {
            try
            {
                DataTable datos = SerPerfil.CargarPerfiles();
                DgPerfiles.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                DgPerfiles.Columns["codigoPerfil"].HeaderText = "Codigo de Perfil";
                DgPerfiles.Columns["nombrePerfil"].HeaderText = "Nombre del Perfil";
                DgPerfiles.Columns["codigoUsuario"].HeaderText = "Codigo de Usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
