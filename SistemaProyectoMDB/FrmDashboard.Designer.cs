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
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            PnlContenido = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
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
            button8.Location = new Point(1, 519);
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
            button4.Location = new Point(-3, 467);
            button4.Name = "button4";
            button4.Size = new Size(229, 45);
            button4.TabIndex = 3;
            button4.Text = "Series";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1, 417);
            button3.Name = "button3";
            button3.Size = new Size(225, 43);
            button3.TabIndex = 2;
            button3.Text = "Peliculas";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1, 173);
            button2.Name = "button2";
            button2.Size = new Size(225, 46);
            button2.TabIndex = 1;
            button2.Text = "Usuarios";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1, 372);
            button1.Name = "button1";
            button1.Size = new Size(225, 40);
            button1.TabIndex = 0;
            button1.Text = "Categorias";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(65, 112, 232);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(223, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1116, 38);
            panel2.TabIndex = 1;
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
            PnlContenido.Location = new Point(223, 31);
            PnlContenido.Name = "PnlContenido";
            PnlContenido.Size = new Size(1113, 715);
            PnlContenido.TabIndex = 2;
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
            Text = "FrmDashboard";
            Load += FrmDashboard_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button BtnCerrarSesion;
        private Button button8;
        private Panel panel2;
        private Label label1;
        private Panel PnlContenido;
    }
}