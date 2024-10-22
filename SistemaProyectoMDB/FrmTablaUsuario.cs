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
    public partial class FrmTablaUsuario : Form
    {
        public FrmTablaUsuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault();


            if (existingForm == null)
            {
                FrmFormUsuarios formulario = new FrmFormUsuarios();
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        void CargarGridDatos()
        {
            try
            {
                DataTable datos = ServUsuario.CargarUsuarios();
                DgUsuarios.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                DgUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                DgUsuarios.Columns["NombreUsuario"].HeaderText = "Nombre de Usuario";
                DgUsuarios.Columns["Correo"].HeaderText = "Correo Electrónico";
                DgUsuarios.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                // Ajustar el ancho de la columna que contiene la foto
                DgUsuarios.Columns["Foto"].Width = 100;
                DgUsuarios.Columns["Foto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //
                DgUsuarios.Columns["Pasaporte"].HeaderText = "Número de Pasaporte";
                DgUsuarios.Columns["Nivel_Usuario"].HeaderText = "Nivel de Usuario";
                DgUsuarios.Columns["NombreAgencia"].HeaderText = "Agencia";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
