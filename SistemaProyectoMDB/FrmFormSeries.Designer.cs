namespace SistemaProyectoMDB
{
    partial class FrmFormSeries
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
            txtNombreSerie = new TextBox();
            label2 = new Label();
            label4 = new Label();
            dtFechaInicio = new DateTimePicker();
            dtFechaFin = new Label();
            dateTimePicker2 = new DateTimePicker();
            btnGuardar = new Button();
            btnAgregarProductora = new Button();
            txtDescripcion = new TextBox();
            label3 = new Label();
            label5 = new Label();
            cmbClasificacion = new ComboBox();
            txtProductora = new TextBox();
            label6 = new Label();
            txtCodigoSerie = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(894, 9);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 18;
            label9.Click += label9_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 21);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 17;
            label1.Text = "Formulario series";
            // 
            // txtNombreSerie
            // 
            txtNombreSerie.Location = new Point(165, 148);
            txtNombreSerie.Name = "txtNombreSerie";
            txtNombreSerie.Size = new Size(180, 23);
            txtNombreSerie.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(39, 148);
            label2.Name = "label2";
            label2.Size = new Size(120, 17);
            label2.TabIndex = 19;
            label2.Text = "Nombre de la serie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(34, 84);
            label4.Name = "label4";
            label4.Size = new Size(166, 17);
            label4.TabIndex = 22;
            label4.Text = "Fecha de inicio de emisión";
            // 
            // dtFechaInicio
            // 
            dtFechaInicio.CustomFormat = "yyyy-MM-dd";
            dtFechaInicio.Format = DateTimePickerFormat.Custom;
            dtFechaInicio.Location = new Point(206, 84);
            dtFechaInicio.Name = "dtFechaInicio";
            dtFechaInicio.Size = new Size(152, 23);
            dtFechaInicio.TabIndex = 21;
            // 
            // dtFechaFin
            // 
            dtFechaFin.AutoSize = true;
            dtFechaFin.Font = new Font("Century Gothic", 9F);
            dtFechaFin.Location = new Point(393, 84);
            dtFechaFin.Name = "dtFechaFin";
            dtFechaFin.Size = new Size(159, 17);
            dtFechaFin.TabIndex = 24;
            dtFechaFin.Text = "Fecha de final de emisión";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(555, 84);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(152, 23);
            dateTimePicker2.TabIndex = 23;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(88, 167, 57);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Century Gothic", 9F);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(785, 306);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 37);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAgregarProductora
            // 
            btnAgregarProductora.Font = new Font("Century Gothic", 9F);
            btnAgregarProductora.Location = new Point(32, 222);
            btnAgregarProductora.Margin = new Padding(3, 2, 3, 2);
            btnAgregarProductora.Name = "btnAgregarProductora";
            btnAgregarProductora.Size = new Size(152, 33);
            btnAgregarProductora.TabIndex = 26;
            btnAgregarProductora.Text = "Agregar productora";
            btnAgregarProductora.UseVisualStyleBackColor = true;
            btnAgregarProductora.Click += btnAgregarProductora_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(558, 146);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(361, 130);
            txtDescripcion.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(405, 154);
            label3.Name = "label3";
            label3.Size = new Size(143, 17);
            label3.TabIndex = 28;
            label3.Text = "Descripción de la serie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F);
            label5.Location = new Point(732, 87);
            label5.Name = "label5";
            label5.Size = new Size(85, 17);
            label5.TabIndex = 29;
            label5.Text = "Clasificación";
            // 
            // cmbClasificacion
            // 
            cmbClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasificacion.FormattingEnabled = true;
            cmbClasificacion.Items.AddRange(new object[] { "PG-13", "PG", "G", "R", "TV-14", "TV-MA" });
            cmbClasificacion.Location = new Point(823, 87);
            cmbClasificacion.Name = "cmbClasificacion";
            cmbClasificacion.Size = new Size(100, 23);
            cmbClasificacion.TabIndex = 30;
            // 
            // txtProductora
            // 
            txtProductora.Enabled = false;
            txtProductora.Location = new Point(193, 228);
            txtProductora.Name = "txtProductora";
            txtProductora.Size = new Size(180, 23);
            txtProductora.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(388, 232);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 32;
            label6.Text = "idInvisible";
            label6.Visible = false;
            // 
            // txtCodigoSerie
            // 
            txtCodigoSerie.Location = new Point(372, 27);
            txtCodigoSerie.Name = "txtCodigoSerie";
            txtCodigoSerie.Size = new Size(128, 23);
            txtCodigoSerie.TabIndex = 34;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F);
            label7.Location = new Point(246, 27);
            label7.Name = "label7";
            label7.Size = new Size(116, 17);
            label7.TabIndex = 33;
            label7.Text = "Codigo de la serie";
            // 
            // FrmFormSeries
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 360);
            Controls.Add(txtCodigoSerie);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtProductora);
            Controls.Add(cmbClasificacion);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(btnAgregarProductora);
            Controls.Add(btnGuardar);
            Controls.Add(dtFechaFin);
            Controls.Add(dateTimePicker2);
            Controls.Add(label4);
            Controls.Add(dtFechaInicio);
            Controls.Add(txtNombreSerie);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFormSeries";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSeries";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label1;
        private TextBox txtNombreSerie;
        private Label label2;
        private Label label4;
        private DateTimePicker dtFechaInicio;
        private Label dtFechaFin;
        private DateTimePicker dateTimePicker2;
        private Button btnGuardar;
        private Button btnAgregarProductora;
        private TextBox txtDescripcion;
        private Label label3;
        private Label label5;
        private ComboBox cmbClasificacion;
        private Label label6;
        private TextBox txtCodigoSerie;
        private Label label7;
        public TextBox txtProductora;
    }
}