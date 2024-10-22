namespace SistemaProyectoMDB
{
    public partial class FrmTablaSeries : Form
    {
        public FrmTablaSeries()
        {
            InitializeComponent();
        }

        private void btnAgregarSerie_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.OfType<FrmFormUsuarios>().FirstOrDefault()!;


            if (existingForm == null)
            {
                FrmFormSeries formulario = new FrmFormSeries();
                formulario.Show();
            }
            else MessageBox.Show("El formulario ya esta abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
