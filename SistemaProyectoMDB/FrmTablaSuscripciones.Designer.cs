namespace SistemaProyectoMDB
{
    partial class FrmTablaSuscripciones
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
            DgSuscripciones = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgSuscripciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 27);
            label1.Name = "label1";
            label1.Size = new Size(264, 44);
            label1.TabIndex = 5;
            label1.Text = "Suscripciones";
            // 
            // DgSuscripciones
            // 
            DgSuscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgSuscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgSuscripciones.Location = new Point(47, 97);
            DgSuscripciones.Margin = new Padding(3, 4, 3, 4);
            DgSuscripciones.Name = "DgSuscripciones";
            DgSuscripciones.ReadOnly = true;
            DgSuscripciones.RowHeadersWidth = 51;
            DgSuscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgSuscripciones.Size = new Size(1029, 557);
            DgSuscripciones.TabIndex = 6;
            // 
            // FrmTablaSuscripciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 715);
            Controls.Add(DgSuscripciones);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaSuscripciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaSuscripciones";
            ((System.ComponentModel.ISupportInitialize)DgSuscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView DgSuscripciones;
    }
}