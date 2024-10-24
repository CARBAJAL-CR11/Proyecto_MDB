﻿using System;
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
            CargarGridDatosUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault();


            if (existingForm == null)
            {
                FrmFormUsuarios formulario = new FrmFormUsuarios();
                AddOwnedForm(formulario);
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void CargarGridDatosUsuarios()
        {
            try
            {
                DataTable datos = ServUsuario.CargarUsuarios();
                DgUsuarios.DataSource = datos;
                // Renombrar las columnas en el DataGridView
                DgUsuarios.Columns["codigoUsuario"].HeaderText = "Codigo";
                DgUsuarios.Columns["nombres"].HeaderText = "Nombre de Usuario";
                DgUsuarios.Columns["apellidos"].HeaderText = "Apellidos";
                DgUsuarios.Columns["fechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                //
                DgUsuarios.Columns["correo"].HeaderText = "Correo Electronico";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion = DgUsuarios.CurrentRow.Index;

            string Codigo = DgUsuarios[0, posicion].Value.ToString();
            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault();


            if (existingForm == null)
            {
                FrmFormUsuarios formulario = new FrmFormUsuarios(Codigo);
                AddOwnedForm(formulario);
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmTablaUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
