namespace DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion
{
    partial class FrmDiferencias
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
            this.dgvCalificacionesActuales = new System.Windows.Forms.DataGridView();
            this.dgvCalificacionesSiseems = new System.Windows.Forms.DataGridView();
            this.lblActuales = new System.Windows.Forms.Label();
            this.lblSiseems = new System.Windows.Forms.Label();
            this.cmdGuardarDiferencias = new System.Windows.Forms.Button();
            this.cmdSeleccionarTodos = new System.Windows.Forms.Button();
            this.cmdSeleccionarNinguno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesSiseems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalificacionesActuales
            // 
            this.dgvCalificacionesActuales.AllowUserToAddRows = false;
            this.dgvCalificacionesActuales.AllowUserToDeleteRows = false;
            this.dgvCalificacionesActuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCalificacionesActuales.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCalificacionesActuales.Location = new System.Drawing.Point(0, 0);
            this.dgvCalificacionesActuales.MultiSelect = false;
            this.dgvCalificacionesActuales.Name = "dgvCalificacionesActuales";
            this.dgvCalificacionesActuales.ReadOnly = true;
            this.dgvCalificacionesActuales.RowHeadersWidth = 60;
            this.dgvCalificacionesActuales.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCalificacionesActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalificacionesActuales.Size = new System.Drawing.Size(380, 561);
            this.dgvCalificacionesActuales.TabIndex = 14;
            this.dgvCalificacionesActuales.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollDGVActuales);
            // 
            // dgvCalificacionesSiseems
            // 
            this.dgvCalificacionesSiseems.AllowUserToAddRows = false;
            this.dgvCalificacionesSiseems.AllowUserToDeleteRows = false;
            this.dgvCalificacionesSiseems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCalificacionesSiseems.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvCalificacionesSiseems.Location = new System.Drawing.Point(628, 0);
            this.dgvCalificacionesSiseems.MultiSelect = false;
            this.dgvCalificacionesSiseems.Name = "dgvCalificacionesSiseems";
            this.dgvCalificacionesSiseems.RowHeadersWidth = 60;
            this.dgvCalificacionesSiseems.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCalificacionesSiseems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalificacionesSiseems.Size = new System.Drawing.Size(380, 561);
            this.dgvCalificacionesSiseems.TabIndex = 15;
            this.dgvCalificacionesSiseems.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollDGVSiseems);
            // 
            // lblActuales
            // 
            this.lblActuales.AutoSize = true;
            this.lblActuales.Location = new System.Drawing.Point(12, 9);
            this.lblActuales.Name = "lblActuales";
            this.lblActuales.Size = new System.Drawing.Size(48, 13);
            this.lblActuales.TabIndex = 16;
            this.lblActuales.Text = "Actuales";
            // 
            // lblSiseems
            // 
            this.lblSiseems.AutoSize = true;
            this.lblSiseems.Location = new System.Drawing.Point(642, 9);
            this.lblSiseems.Name = "lblSiseems";
            this.lblSiseems.Size = new System.Drawing.Size(46, 13);
            this.lblSiseems.TabIndex = 17;
            this.lblSiseems.Text = "Siseems";
            // 
            // cmdGuardarDiferencias
            // 
            this.cmdGuardarDiferencias.Enabled = false;
            this.cmdGuardarDiferencias.Location = new System.Drawing.Point(386, 522);
            this.cmdGuardarDiferencias.Name = "cmdGuardarDiferencias";
            this.cmdGuardarDiferencias.Size = new System.Drawing.Size(236, 27);
            this.cmdGuardarDiferencias.TabIndex = 21;
            this.cmdGuardarDiferencias.Text = "Guardar diferencias";
            this.cmdGuardarDiferencias.UseVisualStyleBackColor = true;
            this.cmdGuardarDiferencias.Click += new System.EventHandler(this.cmdGuardarDiferencias_Click);
            // 
            // cmdSeleccionarTodos
            // 
            this.cmdSeleccionarTodos.Enabled = false;
            this.cmdSeleccionarTodos.Location = new System.Drawing.Point(386, 76);
            this.cmdSeleccionarTodos.Name = "cmdSeleccionarTodos";
            this.cmdSeleccionarTodos.Size = new System.Drawing.Size(236, 27);
            this.cmdSeleccionarTodos.TabIndex = 19;
            this.cmdSeleccionarTodos.Text = "Seleccionar todos";
            this.cmdSeleccionarTodos.UseVisualStyleBackColor = true;
            this.cmdSeleccionarTodos.Click += new System.EventHandler(this.cmdSeleccionarTodos_Click);
            // 
            // cmdSeleccionarNinguno
            // 
            this.cmdSeleccionarNinguno.Enabled = false;
            this.cmdSeleccionarNinguno.Location = new System.Drawing.Point(386, 109);
            this.cmdSeleccionarNinguno.Name = "cmdSeleccionarNinguno";
            this.cmdSeleccionarNinguno.Size = new System.Drawing.Size(236, 27);
            this.cmdSeleccionarNinguno.TabIndex = 20;
            this.cmdSeleccionarNinguno.Text = "Seleccionar ninguno";
            this.cmdSeleccionarNinguno.UseVisualStyleBackColor = true;
            this.cmdSeleccionarNinguno.Click += new System.EventHandler(this.cmdSeleccionarNinguno_Click);
            // 
            // FrmDiferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.cmdSeleccionarNinguno);
            this.Controls.Add(this.cmdSeleccionarTodos);
            this.Controls.Add(this.cmdGuardarDiferencias);
            this.Controls.Add(this.lblSiseems);
            this.Controls.Add(this.lblActuales);
            this.Controls.Add(this.dgvCalificacionesSiseems);
            this.Controls.Add(this.dgvCalificacionesActuales);
            this.Name = "FrmDiferencias";
            this.Text = "FrmDiferencias";
            this.Load += new System.EventHandler(this.FrmDiferencias_Load);
            this.Resize += new System.EventHandler(this.FrmDiferencias_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesSiseems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalificacionesActuales;
        private System.Windows.Forms.DataGridView dgvCalificacionesSiseems;
        private System.Windows.Forms.Label lblActuales;
        private System.Windows.Forms.Label lblSiseems;
        private System.Windows.Forms.Button cmdGuardarDiferencias;
        private System.Windows.Forms.Button cmdSeleccionarTodos;
        private System.Windows.Forms.Button cmdSeleccionarNinguno;
    }
}