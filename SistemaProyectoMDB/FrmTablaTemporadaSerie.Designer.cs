namespace SistemaProyectoMDB
{
    partial class FrmTablaTemporadaSerie
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
            dgvTemporadas = new DataGridView();
            label1 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTemporadas).BeginInit();
            SuspendLayout();
            // 
            // dgvTemporadas
            // 
            dgvTemporadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemporadas.Location = new Point(22, 65);
            dgvTemporadas.Margin = new Padding(3, 2, 3, 2);
            dgvTemporadas.Name = "dgvTemporadas";
            dgvTemporadas.RowHeadersWidth = 51;
            dgvTemporadas.Size = new Size(683, 242);
            dgvTemporadas.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 13);
            label1.Name = "label1";
            label1.Size = new Size(199, 37);
            label1.TabIndex = 24;
            label1.Text = "Temporadas";
            // 
            // label9
            // 
            label9.Image = Properties.Resources.x_regular_24__3_;
            label9.Location = new Point(659, 13);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 23;
            // 
            // FrmTablaTemporadaSerie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 333);
            Controls.Add(dgvTemporadas);
            Controls.Add(label1);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaTemporadaSerie";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaTemporadaSeries";
            ((System.ComponentModel.ISupportInitialize)dgvTemporadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTemporadas;
        private Label label1;
        private Label label9;
    }
}