namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmDocentes
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNuevoDocente = new System.Windows.Forms.Button();
            this.cmdEliminarDocente = new System.Windows.Forms.Button();
            this.cmdEditarDocente = new System.Windows.Forms.Button();
            this.dgvDocentes = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Docentes";
            // 
            // cmdNuevoDocente
            // 
            this.cmdNuevoDocente.Location = new System.Drawing.Point(452, 29);
            this.cmdNuevoDocente.Name = "cmdNuevoDocente";
            this.cmdNuevoDocente.Size = new System.Drawing.Size(168, 34);
            this.cmdNuevoDocente.TabIndex = 9;
            this.cmdNuevoDocente.Text = "Nuevo docente...";
            this.cmdNuevoDocente.UseVisualStyleBackColor = true;
            this.cmdNuevoDocente.Click += new System.EventHandler(this.cmdNuevoDocente_Click);
            // 
            // cmdEliminarDocente
            // 
            this.cmdEliminarDocente.Location = new System.Drawing.Point(452, 396);
            this.cmdEliminarDocente.Name = "cmdEliminarDocente";
            this.cmdEliminarDocente.Size = new System.Drawing.Size(168, 34);
            this.cmdEliminarDocente.TabIndex = 8;
            this.cmdEliminarDocente.Text = "Eliminar";
            this.cmdEliminarDocente.UseVisualStyleBackColor = true;
            this.cmdEliminarDocente.Click += new System.EventHandler(this.cmdEliminarDocente_Click);
            // 
            // cmdEditarDocente
            // 
            this.cmdEditarDocente.Location = new System.Drawing.Point(12, 396);
            this.cmdEditarDocente.Name = "cmdEditarDocente";
            this.cmdEditarDocente.Size = new System.Drawing.Size(168, 34);
            this.cmdEditarDocente.TabIndex = 7;
            this.cmdEditarDocente.Text = "Editar docente...";
            this.cmdEditarDocente.UseVisualStyleBackColor = true;
            this.cmdEditarDocente.Click += new System.EventHandler(this.cmdEditarDocente_Click);
            // 
            // dgvDocentes
            // 
            this.dgvDocentes.AllowUserToAddRows = false;
            this.dgvDocentes.AllowUserToDeleteRows = false;
            this.dgvDocentes.AllowUserToResizeRows = false;
            this.dgvDocentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes.Location = new System.Drawing.Point(12, 69);
            this.dgvDocentes.MultiSelect = false;
            this.dgvDocentes.Name = "dgvDocentes";
            this.dgvDocentes.ReadOnly = true;
            this.dgvDocentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocentes.Size = new System.Drawing.Size(608, 321);
            this.dgvDocentes.TabIndex = 6;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 34);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(271, 29);
            this.txtBusqueda.TabIndex = 11;
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(289, 34);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(113, 29);
            this.cmdBuscar.TabIndex = 12;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(91, 9);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(104, 22);
            this.lblResultados.TabIndex = 13;
            this.lblResultados.Text = "(Resultados)";
            // 
            // FrmDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 442);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNuevoDocente);
            this.Controls.Add(this.cmdEliminarDocente);
            this.Controls.Add(this.cmdEditarDocente);
            this.Controls.Add(this.dgvDocentes);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(648, 481);
            this.Name = "FrmDocentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docentes - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmDocentes_Load);
            this.Resize += new System.EventHandler(this.FrmDocentes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNuevoDocente;
        private System.Windows.Forms.Button cmdEliminarDocente;
        private System.Windows.Forms.Button cmdEditarDocente;
        private System.Windows.Forms.DataGridView dgvDocentes;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label lblResultados;
    }
}