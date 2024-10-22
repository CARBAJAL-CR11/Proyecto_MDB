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
    public partial class FrmTablaComentarios : Form
    {
        public FrmTablaComentarios()
        {
            InitializeComponent();
            CargarGridDatos();
        }

        private void CargarGridDatos()
        {
            try
            {
                DataTable datos = SerComentario.CargarComentarios();
                DgComentarios.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                DgComentarios.Columns["codigoComentario"].HeaderText = "Codigo de Comentario";
                DgComentarios.Columns["comentario"].HeaderText = "Comentario Realizado";
                DgComentarios.Columns["codigoPerfil"].HeaderText = "Codigo de Perfil Perteneciente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
