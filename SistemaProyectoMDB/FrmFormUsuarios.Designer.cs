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
            TxtNombres = new TextBox();
            TxtApellidos = new TextBox();
            label3 = new Label();
            DtNacimiento = new DateTimePicker();
            label4 = new Label();
            TxtCorreo = new TextBox();
            label5 = new Label();
            TxtCuenta = new TextBox();
            label6 = new Label();
            CmbTipos = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            CmbSubs = new ComboBox();
            BtnGuardar = new Button();
            label9 = new Label();
            txtCodigo = new TextBox();
            label10 = new Label();
            BtnELiminar = new Button();
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
            // TxtNombres
            // 
            TxtNombres.Location = new Point(115, 87);
            TxtNombres.Name = "TxtNombres";
            TxtNombres.Size = new Size(180, 26);
            TxtNombres.TabIndex = 2;
            // 
            // TxtApellidos
            // 
            TxtApellidos.Location = new Point(409, 85);
            TxtApellidos.Name = "TxtApellidos";
            TxtApellidos.Size = new Size(180, 26);
            TxtApellidos.TabIndex = 4;
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
            // DtNacimiento
            // 
            DtNacimiento.CustomFormat = "yyyy-MM-dd";
            DtNacimiento.Format = DateTimePickerFormat.Custom;
            DtNacimiento.Location = new Point(184, 161);
            DtNacimiento.Name = "DtNacimiento";
            DtNacimiento.Size = new Size(152, 26);
            DtNacimiento.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 161);
            label4.Name = "label4";
            label4.Size = new Size(151, 20);
            label4.TabIndex = 6;
            label4.Text = "Fecha Nacimiento :";
            // 
            // TxtCorreo
            // 
            TxtCorreo.Location = new Point(447, 161);
            TxtCorreo.Name = "TxtCorreo";
            TxtCorreo.Size = new Size(180, 26);
            TxtCorreo.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(359, 161);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 7;
            label5.Text = "Correo :";
            // 
            // TxtCuenta
            // 
            TxtCuenta.Location = new Point(741, 161);
            TxtCuenta.Name = "TxtCuenta";
            TxtCuenta.Size = new Size(180, 26);
            TxtCuenta.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(653, 161);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 9;
            label6.Text = "Cuenta :";
            // 
            // CmbTipos
            // 
            CmbTipos.FormattingEnabled = true;
            CmbTipos.Location = new Point(136, 236);
            CmbTipos.Name = "CmbTipos";
            CmbTipos.Size = new Size(191, 28);
            CmbTipos.TabIndex = 11;
            CmbTipos.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 239);
            label7.Name = "label7";
            label7.Size = new Size(103, 20);
            label7.TabIndex = 12;
            label7.Text = "Tipo Usuario :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(359, 239);
            label8.Name = "label8";
            label8.Size = new Size(109, 20);
            label8.TabIndex = 14;
            label8.Text = "Subscripcion :";
            // 
            // CmbSubs
            // 
            CmbSubs.FormattingEnabled = true;
            CmbSubs.Location = new Point(475, 236);
            CmbSubs.Name = "CmbSubs";
            CmbSubs.Size = new Size(191, 28);
            CmbSubs.TabIndex = 13;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(88, 167, 57);
            BtnGuardar.FlatStyle = FlatStyle.Popup;
            BtnGuardar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = SystemColors.Control;
            BtnGuardar.Location = new Point(795, 332);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(138, 37);
            BtnGuardar.TabIndex = 15;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
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
            // txtCodigo
            // 
            txtCodigo.Location = new Point(741, 87);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(180, 26);
            txtCodigo.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(609, 90);
            label10.Name = "label10";
            label10.Size = new Size(126, 20);
            label10.TabIndex = 17;
            label10.Text = "Codigo Usuario:";
            // 
            // BtnELiminar
            // 
            BtnELiminar.BackColor = Color.Brown;
            BtnELiminar.FlatStyle = FlatStyle.Popup;
            BtnELiminar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnELiminar.ForeColor = SystemColors.Control;
            BtnELiminar.Location = new Point(635, 332);
            BtnELiminar.Name = "BtnELiminar";
            BtnELiminar.Size = new Size(138, 37);
            BtnELiminar.TabIndex = 19;
            BtnELiminar.Text = "Eliminar";
            BtnELiminar.UseVisualStyleBackColor = false;
            BtnELiminar.Click += BtnELiminar_Click;
            // 
            // FrmFormUsuarios
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 399);
            Controls.Add(BtnELiminar);
            Controls.Add(txtCodigo);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(BtnGuardar);
            Controls.Add(label8);
            Controls.Add(CmbSubs);
            Controls.Add(label7);
            Controls.Add(CmbTipos);
            Controls.Add(TxtCuenta);
            Controls.Add(label6);
            Controls.Add(TxtCorreo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(DtNacimiento);
            Controls.Add(TxtApellidos);
            Controls.Add(label3);
            Controls.Add(TxtNombres);
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
        private TextBox TxtNombres;
        private TextBox TxtApellidos;
        private Label label3;
        private DateTimePicker DtNacimiento;
        private Label label4;
        private TextBox TxtCorreo;
        private Label label5;
        private TextBox TxtCuenta;
        private Label label6;
        private ComboBox CmbTipos;
        private Label label7;
        private Label label8;
        private ComboBox CmbSubs;
        private Button BtnGuardar;
        private Label label9;
        private TextBox txtCodigo;
        private Label label10;
        private Button BtnELiminar;
    }
}