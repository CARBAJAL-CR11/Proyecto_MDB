namespace SistemaProyectoMDB
{
    partial class FrmFormTemporadas
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
            txtNombreTemporada = new TextBox();
            label2 = new Label();
            dtFechaFin = new Label();
            dateTimePicker2 = new DateTimePicker();
            label4 = new Label();
            dtFechaInicio = new DateTimePicker();
            txtSerie = new TextBox();
            label3 = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(761, 21);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(268, 25);
            label1.TabIndex = 19;
            label1.Text = "Formulario Temporadas";
            // 
            // txtNombreTemporada
            // 
            txtNombreTemporada.Location = new Point(87, 80);
            txtNombreTemporada.Name = "txtNombreTemporada";
            txtNombreTemporada.Size = new Size(180, 23);
            txtNombreTemporada.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(22, 80);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 21;
            label2.Text = "Nombre ";
            // 
            // dtFechaFin
            // 
            dtFechaFin.AutoSize = true;
            dtFechaFin.Font = new Font("Century Gothic", 9F);
            dtFechaFin.Location = new Point(385, 140);
            dtFechaFin.Name = "dtFechaFin";
            dtFechaFin.Size = new Size(159, 17);
            dtFechaFin.TabIndex = 28;
            dtFechaFin.Text = "Fecha de final de emisión";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(547, 140);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(152, 23);
            dateTimePicker2.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(26, 140);
            label4.Name = "label4";
            label4.Size = new Size(166, 17);
            label4.TabIndex = 26;
            label4.Text = "Fecha de inicio de emisión";
            // 
            // dtFechaInicio
            // 
            dtFechaInicio.CustomFormat = "yyyy-MM-dd";
            dtFechaInicio.Format = DateTimePickerFormat.Custom;
            dtFechaInicio.Location = new Point(198, 140);
            dtFechaInicio.Name = "dtFechaInicio";
            dtFechaInicio.Size = new Size(152, 23);
            dtFechaInicio.TabIndex = 25;
            // 
            // txtSerie
            // 
            txtSerie.Enabled = false;
            txtSerie.Location = new Point(385, 80);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(180, 23);
            txtSerie.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(320, 80);
            label3.Name = "label3";
            label3.Size = new Size(38, 17);
            label3.TabIndex = 29;
            label3.Text = "Serie";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(88, 167, 57);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Century Gothic", 9F);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(651, 214);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 37);
            btnGuardar.TabIndex = 31;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmFormTemporadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 278);
            Controls.Add(btnGuardar);
            Controls.Add(txtSerie);
            Controls.Add(label3);
            Controls.Add(dtFechaFin);
            Controls.Add(dateTimePicker2);
            Controls.Add(label4);
            Controls.Add(dtFechaInicio);
            Controls.Add(txtNombreTemporada);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFormTemporadas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormTemporadas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label1;
        private TextBox txtNombreTemporada;
        private Label label2;
        private Label dtFechaFin;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private DateTimePicker dtFechaInicio;
        private TextBox txtSerie;
        private Label label3;
        private Button btnGuardar;
    }
}