namespace SistemaProyectoMDB
{
    partial class FrmFormUsuarios
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 19);
            label1.Name = "label1";
            label1.Size = new Size(272, 34);
            label1.TabIndex = 0;
            label1.Text = "Formulario Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 87);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombres :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 26);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(409, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(180, 26);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(321, 85);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Apellidos :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(768, 85);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(152, 26);
            dateTimePicker1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(611, 85);
            label4.Name = "label4";
            label4.Size = new Size(151, 20);
            label4.TabIndex = 6;
            label4.Text = "Fecha Nacimiento :";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(115, 157);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(180, 26);
            textBox3.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 157);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 7;
            label5.Text = "Correo :";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(409, 157);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(180, 26);
            textBox4.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(321, 157);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 9;
            label6.Text = "Cuenta :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(729, 157);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(191, 28);
            comboBox1.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(620, 160);
            label7.Name = "label7";
            label7.Size = new Size(103, 20);
            label7.TabIndex = 12;
            label7.Text = "Tipo Usuario :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 223);
            label8.Name = "label8";
            label8.Size = new Size(109, 20);
            label8.TabIndex = 14;
            label8.Text = "Subscripcion :";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(143, 220);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(191, 28);
            comboBox2.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(88, 167, 57);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(795, 332);
            button1.Name = "button1";
            button1.Size = new Size(138, 37);
            button1.TabIndex = 15;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(909, 9);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 16;
            label9.Click += label9_Click;
            // 
            // FrmFormUsuarios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 399);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(comboBox2);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFormUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormUsuarios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private ComboBox comboBox1;
        private Label label7;
        private Label label8;
        private ComboBox comboBox2;
        private Button button1;
        private Label label9;
    }
}