namespace SistemaProyectoMDB
{
    partial class FrmTablaProductora
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
            dgvProductoras = new DataGridView();
            label1 = new Label();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductoras).BeginInit();
            SuspendLayout();
            // 
            // dgvProductoras
            // 
            dgvProductoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductoras.Location = new Point(37, 66);
            dgvProductoras.Margin = new Padding(3, 2, 3, 2);
            dgvProductoras.Name = "dgvProductoras";
            dgvProductoras.RowHeadersWidth = 51;
            dgvProductoras.Size = new Size(899, 447);
            dgvProductoras.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 19);
            label1.Name = "label1";
            label1.Size = new Size(191, 37);
            label1.TabIndex = 24;
            label1.Text = "Productoras";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(835, 23);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(101, 33);
            btnAgregar.TabIndex = 26;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // FrmTablaProductora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 536);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductoras);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaProductora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaProductora";
            ((System.ComponentModel.ISupportInitialize)dgvProductoras).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductoras;
        private Label label1;
        private Button btnAgregar;
    }
}