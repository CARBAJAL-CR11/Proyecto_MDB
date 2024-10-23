namespace SistemaProyectoMDB
{
    partial class FrmTablaUsuario
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
            btnAgregar = new Button();
            DgUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 27);
            label1.Name = "label1";
            label1.Size = new Size(166, 44);
            label1.TabIndex = 0;
            label1.Text = "Usuarios";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(961, 32);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 44);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // DgUsuarios
            // 
            DgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgUsuarios.Location = new Point(47, 97);
            DgUsuarios.Margin = new Padding(3, 4, 3, 4);
            DgUsuarios.Name = "DgUsuarios";
            DgUsuarios.RowHeadersWidth = 51;
            DgUsuarios.Size = new Size(1029, 557);
            DgUsuarios.TabIndex = 2;
            DgUsuarios.CellDoubleClick += DgUsuarios_CellDoubleClick;
            // 
            // FrmTablaUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 715);
            Controls.Add(DgUsuarios);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaUsuario";
            Load += FrmTablaUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)DgUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAgregar;
        private DataGridView DgUsuarios;
    }
}