namespace SistemaProyectoMDB
{
    partial class FrmTablaComentarios
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
            DgComentarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgComentarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 27);
            label1.Name = "label1";
            label1.Size = new Size(249, 44);
            label1.TabIndex = 5;
            label1.Text = "Comentarios";
            // 
            // DgComentarios
            // 
            DgComentarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgComentarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgComentarios.Location = new Point(47, 97);
            DgComentarios.Margin = new Padding(3, 4, 3, 4);
            DgComentarios.Name = "DgComentarios";
            DgComentarios.ReadOnly = true;
            DgComentarios.RowHeadersWidth = 51;
            DgComentarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgComentarios.Size = new Size(1029, 557);
            DgComentarios.TabIndex = 6;
            // 
            // FrmTablaComentarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 715);
            Controls.Add(DgComentarios);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaComentarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaComentarios";
            ((System.ComponentModel.ISupportInitialize)DgComentarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView DgComentarios;
    }
}