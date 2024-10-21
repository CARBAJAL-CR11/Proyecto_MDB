namespace SistemaProyectoMDB
{
    partial class FrmDashboard
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
            panel1 = new Panel();
            BtnCerrarSesion = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            BtnUsuarios = new Button();
            panel2 = new Panel();
            label1 = new Label();
            PnlContenido = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            PnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 112, 232);
            panel1.Controls.Add(BtnCerrarSesion);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(BtnUsuarios);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(225, 748);
            panel1.TabIndex = 0;
            // 
            // BtnCerrarSesion
            // 
            BtnCerrarSesion.Location = new Point(0, 648);
            BtnCerrarSesion.Name = "BtnCerrarSesion";
            BtnCerrarSesion.Size = new Size(225, 44);
            BtnCerrarSesion.TabIndex = 5;
            BtnCerrarSesion.Text = "Cerrar sesión";
            BtnCerrarSesion.UseVisualStyleBackColor = true;
            BtnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // button8
            // 
            button8.Location = new Point(0, 472);
            button8.Name = "button8";
            button8.Size = new Size(225, 43);
            button8.TabIndex = 1;
            button8.Text = "Comentarios";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(1, 276);
            button7.Name = "button7";
            button7.Size = new Size(225, 42);
            button7.TabIndex = 1;
            button7.Text = "Subscripciones";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(1, 224);
            button6.Name = "button6";
            button6.Size = new Size(225, 46);
            button6.TabIndex = 1;
            button6.Text = "Perfiles";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(1, 323);
            button5.Name = "button5";
            button5.Size = new Size(225, 43);
            button5.TabIndex = 4;
            button5.Text = "Productoras";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(-3, 421);
            button4.Name = "button4";
            button4.Size = new Size(229, 45);
            button4.TabIndex = 3;
            button4.Text = "Series";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(0, 372);
            button3.Name = "button3";
            button3.Size = new Size(225, 43);
            button3.TabIndex = 2;
            button3.Text = "Peliculas";
            button3.UseVisualStyleBackColor = true;
            // 
            // BtnUsuarios
            // 
            BtnUsuarios.Location = new Point(1, 173);
            BtnUsuarios.Name = "BtnUsuarios";
            BtnUsuarios.Size = new Size(225, 46);
            BtnUsuarios.TabIndex = 1;
            BtnUsuarios.Text = "Usuarios";
            BtnUsuarios.UseVisualStyleBackColor = true;
            BtnUsuarios.Click += BtnUsuarios_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(65, 112, 232);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(223, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1116, 38);
            panel2.TabIndex = 1;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
            // 
            // label1
            // 
            label1.Image = Properties.Resources.x_regular_24__3_;
            label1.Location = new Point(1060, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 38);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // PnlContenido
            // 
            PnlContenido.Controls.Add(pictureBox1);
            PnlContenido.Location = new Point(223, 31);
            PnlContenido.Name = "PnlContenido";
            PnlContenido.Size = new Size(1113, 715);
            PnlContenido.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Operating_system_rafiki;
            pictureBox1.Location = new Point(260, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(563, 475);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 745);
            Controls.Add(PnlContenido);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDashboard";
            Load += FrmDashboard_Load;
            MouseDown += FrmDashboard_MouseDown;
            MouseMove += FrmDashboard_MouseMove;
            MouseUp += FrmDashboard_MouseUp;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            PnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button BtnUsuarios;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button BtnCerrarSesion;
        private Button button8;
        private Panel panel2;
        private Label label1;
        private Panel PnlContenido;
        private PictureBox pictureBox1;
    }
}