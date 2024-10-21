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
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            btnAgregar.Location = new Point(929, 35);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 44);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(41, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1036, 600);
            dataGridView1.TabIndex = 2;
            // 
            // FrmTablaUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 715);
            Controls.Add(dataGridView1);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaUsuario";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAgregar;
        private DataGridView dataGridView1;
    }
}