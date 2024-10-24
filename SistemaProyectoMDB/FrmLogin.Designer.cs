﻿namespace SistemaProyectoMDB
{
    partial class FrmLogin
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
            txtCorreo = new TextBox();
            txtClave = new TextBox();
            label3 = new Label();
            BtnSesion = new Button();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(155, 19);
            label1.Name = "label1";
            label1.Size = new Size(206, 37);
            label1.TabIndex = 0;
            label1.Text = "Iniciar Sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(102, 301);
            label2.Name = "label2";
            label2.Size = new Size(89, 27);
            label2.TabIndex = 1;
            label2.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(107, 332);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(305, 27);
            txtCorreo.TabIndex = 2;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(107, 447);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(305, 27);
            txtClave.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(102, 417);
            label3.Name = "label3";
            label3.Size = new Size(142, 27);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // BtnSesion
            // 
            BtnSesion.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSesion.Location = new Point(151, 511);
            BtnSesion.Name = "BtnSesion";
            BtnSesion.Size = new Size(213, 46);
            BtnSesion.TabIndex = 5;
            BtnSesion.Text = "Iniciar sesión";
            BtnSesion.UseVisualStyleBackColor = true;
            BtnSesion.Click += BtnSesion_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.rb_3180;
            pictureBox1.Location = new Point(151, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(192, 582);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(120, 20);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Crear una cuenta";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.x_regular_24__3_;
            pictureBox2.Location = new Point(462, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(518, 656);
            Controls.Add(pictureBox2);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
            Controls.Add(BtnSesion);
            Controls.Add(txtClave);
            Controls.Add(label3);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCorreo;
        private TextBox txtClave;
        private Label label3;
        private Button BtnSesion;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
    }
}