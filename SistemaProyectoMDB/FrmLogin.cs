using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProyectoMDB
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color color1 = ColorTranslator.FromHtml("#8B6CDA"); // Color Coral en hexadecimal
            Color color2 = ColorTranslator.FromHtml("#36539C");
            // Crear un gradiente lineal
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                // Dibujar el gradiente sobre el fondo del formulario
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void BtnSesion_Click(object sender, EventArgs e)
        {

            if (ServUsuario.logIn(txtCorreo.Text, txtClave.Text) >= 2)
            {
                FrmDashboard dash = new FrmDashboard();
                this.Hide();
                dash.ShowDialog();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrecta, vuelva a intetar", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
