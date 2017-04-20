namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmSemestres
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
            this.dgvSemestres = new System.Windows.Forms.DataGridView();
            this.cmdEditarSemestre = new System.Windows.Forms.Button();
            this.cmdEliminarSemestre = new System.Windows.Forms.Button();
            this.cmdNuevoSemestre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemestres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSemestres
            // 
            this.dgvSemestres.AllowUserToAddRows = false;
            this.dgvSemestres.AllowUserToDeleteRows = false;
            this.dgvSemestres.AllowUserToResizeRows = false;
            this.dgvSemestres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSemestres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemestres.Location = new System.Drawing.Point(12, 69);
            this.dgvSemestres.MultiSelect = false;
            this.dgvSemestres.Name = "dgvSemestres";
            this.dgvSemestres.ReadOnly = true;
            this.dgvSemestres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSemestres.Size = new System.Drawing.Size(608, 321);
            this.dgvSemestres.TabIndex = 0;
            // 
            // cmdEditarSemestre
            // 
            this.cmdEditarSemestre.Location = new System.Drawing.Point(12, 396);
            this.cmdEditarSemestre.Name = "cmdEditarSemestre";
            this.cmdEditarSemestre.Size = new System.Drawing.Size(168, 34);
            this.cmdEditarSemestre.TabIndex = 1;
            this.cmdEditarSemestre.Text = "Editar semestre...";
            this.cmdEditarSemestre.UseVisualStyleBackColor = true;
            this.cmdEditarSemestre.Click += new System.EventHandler(this.cmdEditarSemestre_Click);
            // 
            // cmdEliminarSemestre
            // 
            this.cmdEliminarSemestre.Location = new System.Drawing.Point(452, 396);
            this.cmdEliminarSemestre.Name = "cmdEliminarSemestre";
            this.cmdEliminarSemestre.Size = new System.Drawing.Size(168, 34);
            this.cmdEliminarSemestre.TabIndex = 3;
            this.cmdEliminarSemestre.Text = "Eliminar";
            this.cmdEliminarSemestre.UseVisualStyleBackColor = true;
            this.cmdEliminarSemestre.Click += new System.EventHandler(this.cmdEliminarSemestre_Click);
            // 
            // cmdNuevoSemestre
            // 
            this.cmdNuevoSemestre.Location = new System.Drawing.Point(452, 29);
            this.cmdNuevoSemestre.Name = "cmdNuevoSemestre";
            this.cmdNuevoSemestre.Size = new System.Drawing.Size(168, 34);
            this.cmdNuevoSemestre.TabIndex = 4;
            this.cmdNuevoSemestre.Text = "Nuevo semestre...";
            this.cmdNuevoSemestre.UseVisualStyleBackColor = true;
            this.cmdNuevoSemestre.Click += new System.EventHandler(this.cmdNuevoSemestre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Semestres";
            // 
            // FrmSemestres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNuevoSemestre);
            this.Controls.Add(this.cmdEliminarSemestre);
            this.Controls.Add(this.cmdEditarSemestre);
            this.Controls.Add(this.dgvSemestres);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(648, 481);
            this.Name = "FrmSemestres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semestres - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmSemestres_Load);
            this.Resize += new System.EventHandler(this.FrmSemestres_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemestres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSemestres;
        private System.Windows.Forms.Button cmdEditarSemestre;
        private System.Windows.Forms.Button cmdEliminarSemestre;
        private System.Windows.Forms.Button cmdNuevoSemestre;
        private System.Windows.Forms.Label label1;
    }
}