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
    public partial class FrmFormUsuarios : Form
    {
        private string codigo_usuario;
        public FrmFormUsuarios(string codigo = null)
        {
            InitializeComponent();
            cargarTipos();
            BtnELiminar.Visible= false;
            cargarSubs();
            if (codigo != null)
            {
                DataTable datos = ServUsuario.cargarUnUsuario(codigo);
                DataRow row = datos.Rows[0];
                codigo_usuario = codigo;
                BtnELiminar.Visible = true;
                txtCodigo.ReadOnly = true;
                TxtNombres.Text = row["nombres"].ToString();
                TxtApellidos.Text = row["apellidos"].ToString();
                TxtCorreo.Text = row["correo"].ToString();
                TxtCuenta.Text = row["estadoCuenta"].ToString();
                txtCodigo.Text = row["codigoUsuario"].ToString();
                CmbSubs.Text = row["nombreSuscripcion"].ToString();
                CmbTipos.Text = row["tipoUsuario"].ToString();
                DtNacimiento.Text = row["fechaNacimiento"].ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void cargarTipos()
        {
            DataTable tipos = ServUsuario.cagarTipos();

            // Crea una nueva fila para "Escoja una opción"
            DataRow newRow = tipos.NewRow();
            newRow["codigoTipoUsuario"] = DBNull.Value; // Valor nulo para el IdAgencia
            newRow["tipoUsuario"] = "Escoja una opción";
            tipos.Rows.InsertAt(newRow, 0); // Inserta al inicio del DataTable

            // Asigna el DataTable al ComboBox
            CmbTipos.DataSource = tipos;
            CmbTipos.DisplayMember = "tipoUsuario";
            CmbTipos.ValueMember = "codigoTipoUsuario";

            // Establece "Escoja una opción" como el ítem seleccionado por defecto
            CmbTipos.SelectedIndex = 0;
        }
        void cargarSubs()
        {
            DataTable subs = ServUsuario.cargarSusb();

            // Crea una nueva fila para "Escoja una opción"
            DataRow newRow = subs.NewRow();
            newRow["codigoSuscripcion"] = DBNull.Value; // Valor nulo para el IdAgencia
            newRow["nombreSuscripcion"] = "Escoja una opción";
            subs.Rows.InsertAt(newRow, 0); // Inserta al inicio del DataTable

            // Asigna el DataTable al ComboBox
            CmbSubs.DataSource = subs;
            CmbSubs.DisplayMember = "nombreSuscripcion";
            CmbSubs.ValueMember = "codigoSuscripcion";

            // Establece "Escoja una opción" como el ítem seleccionado por defecto
            CmbSubs.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerUsuario usuario = new ControllerUsuario
                {
                    codigoUsuario = txtCodigo.Text,
                    nombresUsuario = TxtNombres.Text,
                    apellidosUsuario = TxtApellidos.Text,
                    correoUsuario = TxtCorreo.Text,
                    claveUsuario = TxtNombres.Text + "123",
                    estadoCuenta = TxtCuenta.Text,
                    fechaNacimiento = DtNacimiento.Text,
                    tipoUsuario = CmbTipos.SelectedValue.ToString(),
                    suscripcion = CmbSubs.SelectedValue.ToString()
                };
                if (codigo_usuario !=null)
                {
                    string message;
                    bool isSuccess = ServUsuario.ActualizarUsuario(usuario, out message);

                    if (isSuccess)
                    {
                        MessageBox.Show("Usuario actualizado exitosamente.");
                        FrmTablaUsuario frmTablaUsuario = Owner as FrmTablaUsuario;
                        frmTablaUsuario.CargarGridDatosUsuarios();
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
                    bool isSuccess = ServUsuario.AgregarUsuario(usuario, out message);

                    if (isSuccess)
                    {
                        MessageBox.Show("Usuario registrado exitosamente.");
                        FrmTablaUsuario frmTablaUsuario = Owner as FrmTablaUsuario;
                        frmTablaUsuario.CargarGridDatosUsuarios();
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

        private void BtnELiminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿ELiminar el usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    /*CtrJugador jugador = new CtrJugador();
                    jugador.IdJugador = CtrJugador._idJugador;*/
                    string message;
                    bool isSuccess = ServUsuario.EliminarUsuario(codigo_usuario,out message);
                    if (isSuccess)
                    {
                        MessageBox.Show("EL usuario fue eliminado", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTablaUsuario frmTablaUsuario = Owner as FrmTablaUsuario;
                        frmTablaUsuario.CargarGridDatosUsuarios();
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
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
