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
            this.dgvCalificacionesActuales.RowHeadersWidth = 60;
            this.dgvCalificacionesActuales.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCalificacionesActuales.Size = new System.Drawing.Size(334, 391);
            this.dgvCalificacionesActuales.TabIndex = 14;
            // 
            // dgvCalificacionesSiseems
            // 
            this.dgvCalificacionesSiseems.AllowUserToAddRows = false;
            this.dgvCalificacionesSiseems.AllowUserToDeleteRows = false;
            this.dgvCalificacionesSiseems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCalificacionesSiseems.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvCalificacionesSiseems.Location = new System.Drawing.Point(597, 0);
            this.dgvCalificacionesSiseems.MultiSelect = false;
            this.dgvCalificacionesSiseems.Name = "dgvCalificacionesSiseems";
            this.dgvCalificacionesSiseems.RowHeadersWidth = 60;
            this.dgvCalificacionesSiseems.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCalificacionesSiseems.Size = new System.Drawing.Size(334, 391);
            this.dgvCalificacionesSiseems.TabIndex = 15;
            // 
            // FrmDiferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 391);
            this.Controls.Add(this.dgvCalificacionesSiseems);
            this.Controls.Add(this.dgvCalificacionesActuales);
            this.Name = "FrmDiferencias";
            this.Text = "FrmDiferencias";
            this.Load += new System.EventHandler(this.FrmDiferencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesSiseems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalificacionesActuales;
        private System.Windows.Forms.DataGridView dgvCalificacionesSiseems;
    }
}