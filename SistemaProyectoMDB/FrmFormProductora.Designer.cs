namespace SistemaProyectoMDB
{
    partial class FrmFormProductora
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
            txtNombreProductora = new TextBox();
            label2 = new Label();
            txtDirección = new TextBox();
            label3 = new Label();
            txtCorreo = new TextBox();
            label4 = new Label();
            mtxtTelefono = new MaskedTextBox();
            label5 = new Label();
            btnGuardar = new Button();
            txtCodigo = new TextBox();
            label6 = new Label();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(736, 12);
            label9.Name = "label9";
            label9.Size = new Size(71, 33);
            label9.TabIndex = 20;
            label9.Click += label9_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 36);
            label1.Name = "label1";
            label1.Size = new Size(327, 34);
            label1.TabIndex = 19;
            label1.Text = "Formulario Productoras";
            // 
            // txtNombreProductora
            // 
            txtNombreProductora.Location = new Point(98, 120);
            txtNombreProductora.Margin = new Padding(3, 4, 3, 4);
            txtNombreProductora.Name = "txtNombreProductora";
            txtNombreProductora.Size = new Size(205, 27);
            txtNombreProductora.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(27, 120);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 21;
            label2.Text = "Nombre";
            // 
            // txtDirección
            // 
            txtDirección.Location = new Point(472, 120);
            txtDirección.Margin = new Padding(3, 4, 3, 4);
            txtDirección.Multiline = true;
            txtDirección.Name = "txtDirección";
            txtDirección.Size = new Size(205, 76);
            txtDirección.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(365, 120);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 23;
            label3.Text = "Dirección";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(98, 277);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(205, 27);
            txtCorreo.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(27, 277);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 25;
            label4.Text = "Correo";
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Location = new Point(455, 277);
            mtxtTelefono.Margin = new Padding(3, 4, 3, 4);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(109, 27);
            mtxtTelefono.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F);
            label5.Location = new Point(365, 277);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 28;
            label5.Text = "Teléfono";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(88, 167, 57);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Century Gothic", 9F);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(600, 353);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(158, 49);
            btnGuardar.TabIndex = 29;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(98, 196);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(205, 27);
            txtCodigo.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F);
            label6.Location = new Point(27, 196);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 30;
            label6.Text = "Codigo";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Brown;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Century Gothic", 9F);
            btnEliminar.ForeColor = SystemColors.Control;
            btnEliminar.Location = new Point(424, 353);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(158, 49);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmFormProductora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 427);
            Controls.Add(btnEliminar);
            Controls.Add(txtCodigo);
            Controls.Add(label6);
            Controls.Add(btnGuardar);
            Controls.Add(label5);
            Controls.Add(mtxtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(label4);
            Controls.Add(txtDirección);
            Controls.Add(label3);
            Controls.Add(txtNombreProductora);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFormProductora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFormProductora";
            Load += FrmFormProductora_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label1;
        private TextBox txtNombreProductora;
        private Label label2;
        private TextBox txtDirección;
        private Label label3;
        private TextBox txtCorreo;
        private Label label4;
        private MaskedTextBox mtxtTelefono;
        private Label label5;
        private Button btnGuardar;
        private TextBox txtCodigo;
        private Label label6;
        private Button btnEliminar;
    }
}