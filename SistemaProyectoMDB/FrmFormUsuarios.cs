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
        public FrmFormUsuarios()
        {
            InitializeComponent();
            cargarTipos();
            cargarSubs();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void cargarTipos() {
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
        void cargarSubs() {
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
    }
}
