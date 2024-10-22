namespace SistemaProyectoMDB
{
    partial class FrmTablaPerfiles
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
            DgPerfiles = new DataGridView();
            label1 = new Label();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)DgPerfiles).BeginInit();
            SuspendLayout();
            // 
            // DgPerfiles
            // 
            DgPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgPerfiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgPerfiles.Location = new Point(47, 97);
            DgPerfiles.Margin = new Padding(3, 4, 3, 4);
            DgPerfiles.Name = "DgPerfiles";
            DgPerfiles.ReadOnly = true;
            DgPerfiles.RowHeadersWidth = 51;
            DgPerfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgPerfiles.Size = new Size(1029, 557);
            DgPerfiles.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 27);
            label1.Name = "label1";
            label1.Size = new Size(144, 44);
            label1.TabIndex = 4;
            label1.Text = "Perfiles";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(961, 32);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 44);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Visible = false;
            // 
            // FrmTablaPerfiles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 715);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(DgPerfiles);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTablaPerfiles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTablaPerfiles";
            ((System.ComponentModel.ISupportInitialize)DgPerfiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgPerfiles;
        private Label label1;
        private Button btnAgregar;
    }
}