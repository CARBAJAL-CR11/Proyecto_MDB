namespace SistemaProyectoMDB
{
    partial class FrmFormCapitulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label9 = new Label();
            label1 = new Label();
            txtNombreCapitulo = new TextBox();
            label2 = new Label();
            btnAgregarTemporada = new Button();
            txtTemporada = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(730, 14);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(235, 25);
            label1.TabIndex = 21;
            label1.Text = "Formulario Capítulos";
            // 
            // txtNombreCapitulo
            // 
            txtNombreCapitulo.Location = new Point(89, 90);
            txtNombreCapitulo.Name = "txtNombreCapitulo";
            txtNombreCapitulo.Size = new Size(180, 23);
            txtNombreCapitulo.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(24, 90);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 23;
            label2.Text = "Nombre ";
            // 
            // btnAgregarTemporada
            // 
            btnAgregarTemporada.Font = new Font("Century Gothic", 9F);
            btnAgregarTemporada.Location = new Point(338, 84);
            btnAgregarTemporada.Margin = new Padding(3, 2, 3, 2);
            btnAgregarTemporada.Name = "btnAgregarTemporada";
            btnAgregarTemporada.Size = new Size(152, 33);
            btnAgregarTemporada.TabIndex = 27;
            btnAgregarTemporada.Text = "Agregar temporada";
            btnAgregarTemporada.UseVisualStyleBackColor = true;
            // 
            // txtTemporada
            // 
            txtTemporada.Enabled = false;
            txtTemporada.Location = new Point(509, 90);
            txtTemporada.Name = "txtTemporada";
            txtTemporada.Size = new Size(180, 23);
            txtTemporada.TabIndex = 28;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(88, 167, 57);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Century Gothic", 9F);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(626, 142);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 37);
            btnGuardar.TabIndex = 32;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmFormCapitulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 191);
            Controls.Add(btnGuardar);
            Controls.Add(txtTemporada);
            Controls.Add(btnAgregarTemporada);
            Controls.Add(txtNombreCapitulo);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFormCapitulos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormCapitulos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label1;
        private TextBox txtNombreCapitulo;
        private Label label2;
        private Button btnAgregarTemporada;
        private TextBox txtTemporada;
        private Button btnGuardar;
    }
}