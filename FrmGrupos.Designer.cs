namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmGrupos
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
            this.lblGrupos = new System.Windows.Forms.Label();
            this.cmdNuevoGrupo = new System.Windows.Forms.Button();
            this.cmdEliminarGrupo = new System.Windows.Forms.Button();
            this.cmdEditarGrupo = new System.Windows.Forms.Button();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.comboSemestres = new System.Windows.Forms.ComboBox();
            this.cmdAsignarDocentes = new System.Windows.Forms.Button();
            this.cmdImportarEstudiantes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGrupos
            // 
            this.lblGrupos.AutoSize = true;
            this.lblGrupos.Location = new System.Drawing.Point(12, 44);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(67, 22);
            this.lblGrupos.TabIndex = 11;
            this.lblGrupos.Text = "Grupos";
            // 
            // cmdNuevoGrupo
            // 
            this.cmdNuevoGrupo.Location = new System.Drawing.Point(584, 29);
            this.cmdNuevoGrupo.Name = "cmdNuevoGrupo";
            this.cmdNuevoGrupo.Size = new System.Drawing.Size(168, 34);
            this.cmdNuevoGrupo.TabIndex = 10;
            this.cmdNuevoGrupo.Text = "Nuevo grupo...";
            this.cmdNuevoGrupo.UseVisualStyleBackColor = true;
            this.cmdNuevoGrupo.Click += new System.EventHandler(this.cmdNuevoGrupo_Click);
            // 
            // cmdEliminarGrupo
            // 
            this.cmdEliminarGrupo.Location = new System.Drawing.Point(584, 396);
            this.cmdEliminarGrupo.Name = "cmdEliminarGrupo";
            this.cmdEliminarGrupo.Size = new System.Drawing.Size(168, 34);
            this.cmdEliminarGrupo.TabIndex = 9;
            this.cmdEliminarGrupo.Text = "Eliminar";
            this.cmdEliminarGrupo.UseVisualStyleBackColor = true;
            this.cmdEliminarGrupo.Click += new System.EventHandler(this.cmdEliminarGrupo_Click);
            // 
            // cmdEditarGrupo
            // 
            this.cmdEditarGrupo.Location = new System.Drawing.Point(12, 396);
            this.cmdEditarGrupo.Name = "cmdEditarGrupo";
            this.cmdEditarGrupo.Size = new System.Drawing.Size(168, 34);
            this.cmdEditarGrupo.TabIndex = 7;
            this.cmdEditarGrupo.Text = "Editar grupo...";
            this.cmdEditarGrupo.UseVisualStyleBackColor = true;
            this.cmdEditarGrupo.Click += new System.EventHandler(this.cmdEditarGrupo_Click);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.AllowUserToResizeRows = false;
            this.dgvGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Location = new System.Drawing.Point(12, 69);
            this.dgvGrupos.MultiSelect = false;
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.Size = new System.Drawing.Size(740, 321);
            this.dgvGrupos.TabIndex = 6;
            // 
            // comboSemestres
            // 
            this.comboSemestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestres.FormattingEnabled = true;
            this.comboSemestres.Location = new System.Drawing.Point(294, 32);
            this.comboSemestres.Name = "comboSemestres";
            this.comboSemestres.Size = new System.Drawing.Size(284, 30);
            this.comboSemestres.TabIndex = 12;
            this.comboSemestres.SelectedIndexChanged += new System.EventHandler(this.iniciarTemporizador);
            // 
            // cmdAsignarDocentes
            // 
            this.cmdAsignarDocentes.Location = new System.Drawing.Point(186, 396);
            this.cmdAsignarDocentes.Name = "cmdAsignarDocentes";
            this.cmdAsignarDocentes.Size = new System.Drawing.Size(168, 34);
            this.cmdAsignarDocentes.TabIndex = 13;
            this.cmdAsignarDocentes.Text = "Asignar docentes...";
            this.cmdAsignarDocentes.UseVisualStyleBackColor = true;
            this.cmdAsignarDocentes.Click += new System.EventHandler(this.cmdAsignarDocentes_Click);
            // 
            // cmdImportarEstudiantes
            // 
            this.cmdImportarEstudiantes.Location = new System.Drawing.Point(360, 396);
            this.cmdImportarEstudiantes.Name = "cmdImportarEstudiantes";
            this.cmdImportarEstudiantes.Size = new System.Drawing.Size(190, 34);
            this.cmdImportarEstudiantes.TabIndex = 14;
            this.cmdImportarEstudiantes.Text = "Importar estudiantes";
            this.cmdImportarEstudiantes.UseVisualStyleBackColor = true;
            this.cmdImportarEstudiantes.Click += new System.EventHandler(this.cmdImportarEstudiantes_Click);
            // 
            // FrmGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 442);
            this.Controls.Add(this.cmdImportarEstudiantes);
            this.Controls.Add(this.cmdAsignarDocentes);
            this.Controls.Add(this.comboSemestres);
            this.Controls.Add(this.lblGrupos);
            this.Controls.Add(this.cmdNuevoGrupo);
            this.Controls.Add(this.cmdEliminarGrupo);
            this.Controls.Add(this.cmdEditarGrupo);
            this.Controls.Add(this.dgvGrupos);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(733, 481);
            this.Name = "FrmGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmGrupos_Load);
            this.Resize += new System.EventHandler(this.FrmGrupos_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrupos;
        private System.Windows.Forms.Button cmdNuevoGrupo;
        private System.Windows.Forms.Button cmdEliminarGrupo;
        private System.Windows.Forms.Button cmdEditarGrupo;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.ComboBox comboSemestres;
        private System.Windows.Forms.Button cmdAsignarDocentes;
        private System.Windows.Forms.Button cmdImportarEstudiantes;
    }
}