namespace SistemaProyectoMDB
{
    partial class FrmTablaSeries
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
            btnAgregarSerie = new Button();
            label1 = new Label();
            dgvSeries = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSeries).BeginInit();
            SuspendLayout();
            // 
            // btnAgregarSerie
            // 
            btnAgregarSerie.Location = new Point(722, 21);
            btnAgregarSerie.Margin = new Padding(3, 2, 3, 2);
            btnAgregarSerie.Name = "btnAgregarSerie";
            btnAgregarSerie.Size = new Size(101, 33);
            btnAgregarSerie.TabIndex = 4;
            btnAgregarSerie.Text = "Agregar";
            btnAgregarSerie.UseVisualStyleBackColor = true;
            btnAgregarSerie.Click += btnAgregarSerie_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 17);
            label1.Name = "label1";
            label1.Size = new Size(101, 37);
            label1.TabIndex = 3;
            label1.Text = "Series";
            // 
            // dgvSeries
            // 
            dgvSeries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeries.Location = new Point(33, 75);
            dgvSeries.Name = "dgvSeries";
            dgvSeries.ReadOnly = true;
            dgvSeries.RowHeadersWidth = 51;
            dgvSeries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeries.Size = new Size(790, 507);
            dgvSeries.TabIndex = 7;
            // 
            // FrmTablaSeries
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 594);
            Controls.Add(dgvSeries);
            Controls.Add(btnAgregarSerie);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaSeries";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaSeries";
            ((System.ComponentModel.ISupportInitialize)dgvSeries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAgregarSerie;
        private Label label1;
        private DataGridView dgvSeries;
    }
}