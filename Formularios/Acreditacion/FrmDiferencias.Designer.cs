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
            this.pnlMedio = new System.Windows.Forms.Panel();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblNoEncontradosDB = new System.Windows.Forms.Label();
            this.lblComodin4 = new System.Windows.Forms.Label();
            this.lblNoEncontradosGrupo = new System.Windows.Forms.Label();
            this.lblComodin2 = new System.Windows.Forms.Label();
            this.lblDiferencias = new System.Windows.Forms.Label();
            this.lblComodin1 = new System.Windows.Forms.Label();
            this.lblEncontrados = new System.Windows.Forms.Label();
            this.lblComodin3 = new System.Windows.Forms.Label();
            this.txtResumenTitulo = new System.Windows.Forms.TextBox();
            this.cmdGuardarDiferencias = new System.Windows.Forms.Button();
            this.pnlArriba = new System.Windows.Forms.Panel();
            this.cmdSeleccionarNinguno = new System.Windows.Forms.Button();
            this.cmdSeleccionarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesSiseems)).BeginInit();
            this.pnlMedio.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlArriba.SuspendLayout();
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
            // pnlMedio
            // 
            this.pnlMedio.Controls.Add(this.pnlResumen);
            this.pnlMedio.Controls.Add(this.cmdGuardarDiferencias);
            this.pnlMedio.Controls.Add(this.pnlArriba);
            this.pnlMedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMedio.Location = new System.Drawing.Point(380, 0);
            this.pnlMedio.Name = "pnlMedio";
            this.pnlMedio.Size = new System.Drawing.Size(248, 561);
            this.pnlMedio.TabIndex = 18;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Controls.Add(this.lblNoEncontradosDB);
            this.pnlResumen.Controls.Add(this.lblComodin4);
            this.pnlResumen.Controls.Add(this.lblNoEncontradosGrupo);
            this.pnlResumen.Controls.Add(this.lblComodin2);
            this.pnlResumen.Controls.Add(this.lblDiferencias);
            this.pnlResumen.Controls.Add(this.lblComodin1);
            this.pnlResumen.Controls.Add(this.lblEncontrados);
            this.pnlResumen.Controls.Add(this.lblComodin3);
            this.pnlResumen.Controls.Add(this.txtResumenTitulo);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumen.Location = new System.Drawing.Point(0, 302);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(248, 219);
            this.pnlResumen.TabIndex = 29;
            // 
            // lblNoEncontradosDB
            // 
            this.lblNoEncontradosDB.AutoSize = true;
            this.lblNoEncontradosDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoEncontradosDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEncontradosDB.Location = new System.Drawing.Point(0, 146);
            this.lblNoEncontradosDB.MaximumSize = new System.Drawing.Size(248, 0);
            this.lblNoEncontradosDB.Name = "lblNoEncontradosDB";
            this.lblNoEncontradosDB.Size = new System.Drawing.Size(45, 16);
            this.lblNoEncontradosDB.TabIndex = 8;
            this.lblNoEncontradosDB.Text = "label1";
            // 
            // lblComodin4
            // 
            this.lblComodin4.AutoSize = true;
            this.lblComodin4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComodin4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComodin4.Location = new System.Drawing.Point(0, 130);
            this.lblComodin4.MaximumSize = new System.Drawing.Size(248, 0);
            this.lblComodin4.Name = "lblComodin4";
            this.lblComodin4.Size = new System.Drawing.Size(0, 16);
            this.lblComodin4.TabIndex = 7;
            // 
            // lblNoEncontradosGrupo
            // 
            this.lblNoEncontradosGrupo.AutoSize = true;
            this.lblNoEncontradosGrupo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoEncontradosGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEncontradosGrupo.Location = new System.Drawing.Point(0, 114);
            this.lblNoEncontradosGrupo.MaximumSize = new System.Drawing.Size(248, 0);
            this.lblNoEncontradosGrupo.Name = "lblNoEncontradosGrupo";
            this.lblNoEncontradosGrupo.Size = new System.Drawing.Size(45, 16);
            this.lblNoEncontradosGrupo.TabIndex = 4;
            this.lblNoEncontradosGrupo.Text = "label1";
            // 
            // lblComodin2
            // 
            this.lblComodin2.AutoSize = true;
            this.lblComodin2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComodin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComodin2.Location = new System.Drawing.Point(0, 94);
            this.lblComodin2.Name = "lblComodin2";
            this.lblComodin2.Size = new System.Drawing.Size(0, 20);
            this.lblComodin2.TabIndex = 3;
            // 
            // lblDiferencias
            // 
            this.lblDiferencias.AutoSize = true;
            this.lblDiferencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDiferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencias.Location = new System.Drawing.Point(0, 78);
            this.lblDiferencias.MaximumSize = new System.Drawing.Size(248, 0);
            this.lblDiferencias.Name = "lblDiferencias";
            this.lblDiferencias.Size = new System.Drawing.Size(45, 16);
            this.lblDiferencias.TabIndex = 1;
            this.lblDiferencias.Text = "label1";
            // 
            // lblComodin1
            // 
            this.lblComodin1.AutoSize = true;
            this.lblComodin1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComodin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComodin1.Location = new System.Drawing.Point(0, 58);
            this.lblComodin1.Name = "lblComodin1";
            this.lblComodin1.Size = new System.Drawing.Size(0, 20);
            this.lblComodin1.TabIndex = 2;
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.AutoSize = true;
            this.lblEncontrados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEncontrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncontrados.Location = new System.Drawing.Point(0, 42);
            this.lblEncontrados.MaximumSize = new System.Drawing.Size(248, 0);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(45, 16);
            this.lblEncontrados.TabIndex = 0;
            this.lblEncontrados.Text = "label1";
            // 
            // lblComodin3
            // 
            this.lblComodin3.AutoSize = true;
            this.lblComodin3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComodin3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComodin3.Location = new System.Drawing.Point(0, 22);
            this.lblComodin3.Name = "lblComodin3";
            this.lblComodin3.Size = new System.Drawing.Size(0, 20);
            this.lblComodin3.TabIndex = 5;
            // 
            // txtResumenTitulo
            // 
            this.txtResumenTitulo.BackColor = System.Drawing.Color.White;
            this.txtResumenTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResumenTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResumenTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResumenTitulo.Location = new System.Drawing.Point(0, 0);
            this.txtResumenTitulo.Name = "txtResumenTitulo";
            this.txtResumenTitulo.ReadOnly = true;
            this.txtResumenTitulo.Size = new System.Drawing.Size(248, 22);
            this.txtResumenTitulo.TabIndex = 27;
            this.txtResumenTitulo.Text = "Resumen de diferencias";
            this.txtResumenTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdGuardarDiferencias
            // 
            this.cmdGuardarDiferencias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdGuardarDiferencias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdGuardarDiferencias.FlatAppearance.BorderSize = 0;
            this.cmdGuardarDiferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGuardarDiferencias.Location = new System.Drawing.Point(0, 521);
            this.cmdGuardarDiferencias.Name = "cmdGuardarDiferencias";
            this.cmdGuardarDiferencias.Size = new System.Drawing.Size(248, 40);
            this.cmdGuardarDiferencias.TabIndex = 26;
            this.cmdGuardarDiferencias.Text = "Guardar diferencias";
            this.cmdGuardarDiferencias.UseVisualStyleBackColor = false;
            this.cmdGuardarDiferencias.Click += new System.EventHandler(this.cmdGuardarDiferencias_Click);
            // 
            // pnlArriba
            // 
            this.pnlArriba.Controls.Add(this.cmdSeleccionarNinguno);
            this.pnlArriba.Controls.Add(this.cmdSeleccionarTodos);
            this.pnlArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArriba.Location = new System.Drawing.Point(0, 0);
            this.pnlArriba.Name = "pnlArriba";
            this.pnlArriba.Size = new System.Drawing.Size(248, 124);
            this.pnlArriba.TabIndex = 28;
            // 
            // cmdSeleccionarNinguno
            // 
            this.cmdSeleccionarNinguno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSeleccionarNinguno.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdSeleccionarNinguno.FlatAppearance.BorderSize = 0;
            this.cmdSeleccionarNinguno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeleccionarNinguno.Location = new System.Drawing.Point(0, 40);
            this.cmdSeleccionarNinguno.Name = "cmdSeleccionarNinguno";
            this.cmdSeleccionarNinguno.Size = new System.Drawing.Size(248, 40);
            this.cmdSeleccionarNinguno.TabIndex = 25;
            this.cmdSeleccionarNinguno.Text = "Seleccionar ninguno";
            this.cmdSeleccionarNinguno.UseVisualStyleBackColor = false;
            this.cmdSeleccionarNinguno.Click += new System.EventHandler(this.cmdSeleccionarNinguno_Click);
            // 
            // cmdSeleccionarTodos
            // 
            this.cmdSeleccionarTodos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSeleccionarTodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdSeleccionarTodos.FlatAppearance.BorderSize = 0;
            this.cmdSeleccionarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeleccionarTodos.Location = new System.Drawing.Point(0, 0);
            this.cmdSeleccionarTodos.Name = "cmdSeleccionarTodos";
            this.cmdSeleccionarTodos.Size = new System.Drawing.Size(248, 40);
            this.cmdSeleccionarTodos.TabIndex = 24;
            this.cmdSeleccionarTodos.Text = "Seleccionar todos";
            this.cmdSeleccionarTodos.UseVisualStyleBackColor = false;
            this.cmdSeleccionarTodos.Click += new System.EventHandler(this.cmdSeleccionarTodos_Click);
            // 
            // FrmDiferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.pnlMedio);
            this.Controls.Add(this.lblSiseems);
            this.Controls.Add(this.lblActuales);
            this.Controls.Add(this.dgvCalificacionesSiseems);
            this.Controls.Add(this.dgvCalificacionesActuales);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FrmDiferencias";
            this.Text = "FrmDiferencias";
            this.Load += new System.EventHandler(this.FrmDiferencias_Load);
            this.Resize += new System.EventHandler(this.FrmDiferencias_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacionesSiseems)).EndInit();
            this.pnlMedio.ResumeLayout(false);
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlArriba.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalificacionesActuales;
        private System.Windows.Forms.DataGridView dgvCalificacionesSiseems;
        private System.Windows.Forms.Label lblActuales;
        private System.Windows.Forms.Label lblSiseems;
        private System.Windows.Forms.Panel pnlMedio;
        private System.Windows.Forms.Button cmdSeleccionarNinguno;
        private System.Windows.Forms.Button cmdSeleccionarTodos;
        private System.Windows.Forms.Button cmdGuardarDiferencias;
        private System.Windows.Forms.Panel pnlArriba;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblEncontrados;
        private System.Windows.Forms.Label lblDiferencias;
        private System.Windows.Forms.Label lblComodin1;
        private System.Windows.Forms.Label lblComodin2;
        private System.Windows.Forms.Label lblNoEncontradosGrupo;
        private System.Windows.Forms.Label lblComodin3;
        private System.Windows.Forms.Label lblNoEncontradosDB;
        private System.Windows.Forms.Label lblComodin4;
        private System.Windows.Forms.TextBox txtResumenTitulo;
    }
}