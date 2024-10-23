using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaProyectoMDB
{
    public partial class FrmDashboard : Form
    {
        private bool isFormActive = false;
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        public FrmDashboard()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Crear el contorno redondeado
            int radius = 30; // Radio de las esquinas redondeadas
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Aplicar la región redondeada
            this.Region = new Region(path);
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("¿Desea cerrar sesión?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg.Equals(DialogResult.Yes))
            {
                FrmLogin login = new FrmLogin();
                this.Close();
                login.Show();
            }
        }
        private void OpenChildForm(Form childForm)
        {
            // Verificar si hay un formulario hijo abierto en el panel
            foreach (Control control in PnlContenido.Controls)
            {
                if (control is Form openForm)
                {
                    // Verificar si el formulario abierto es el mismo que el que se quiere abrir
                    if (openForm.GetType() == childForm.GetType())
                    {
                        MessageBox.Show("El formulario ya está abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Confirmar con el usuario si desea cerrar el formulario actual
                    DialogResult result = MessageBox.Show(
                        "Ya hay un formulario abierto. ¿Desea cerrarlo?",
                        "Confirmar cierre",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.Yes)
                    {
                        PnlContenido.Controls.Clear();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            PnlContenido.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PnlContenido.Controls.Add(childForm);
            childForm.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            FrmTablaUsuario frmusuario = new FrmTablaUsuario();
            OpenChildForm(frmusuario);
        }

        private void FrmDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        private void FrmDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point delta = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(delta));
            }
        }

        private void FrmDashboard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point delta = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(delta));
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmTablaSeries frmSerie = new FrmTablaSeries();
            OpenChildForm(frmSerie);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTablaPerfiles frmPerfil = new FrmTablaPerfiles();
            OpenChildForm(frmPerfil);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmTablaComentarios frmComentarios = new FrmTablaComentarios();
            OpenChildForm(frmComentarios);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmTablaSuscripciones frmSuscripciones = new FrmTablaSuscripciones();
            OpenChildForm(frmSuscripciones);
        }
    }
}
