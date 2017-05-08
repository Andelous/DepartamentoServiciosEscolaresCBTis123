using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;

namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmEstudiantes
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
            this.comboSemestres = new System.Windows.Forms.ComboBox();
            this.lblEstudiantes = new System.Windows.Forms.Label();
            this.cmdNuevoEstudiante = new System.Windows.Forms.Button();
            this.cmdEliminarEstudiante = new System.Windows.Forms.Button();
            this.cmdEditarEstudiante = new System.Windows.Forms.Button();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNcontrol = new System.Windows.Forms.CheckBox();
            this.chkCurp = new System.Windows.Forms.CheckBox();
            this.chkNombres = new System.Windows.Forms.CheckBox();
            this.chkNombreCompleto = new System.Windows.Forms.CheckBox();
            this.chkApellidoMaterno = new System.Windows.Forms.CheckBox();
            this.chkApellidoPaterno = new System.Windows.Forms.CheckBox();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.chkNss = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSemestres
            // 
            this.comboSemestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestres.FormattingEnabled = true;
            this.comboSemestres.Location = new System.Drawing.Point(530, 12);
            this.comboSemestres.Name = "comboSemestres";
            this.comboSemestres.Size = new System.Drawing.Size(284, 30);
            this.comboSemestres.TabIndex = 18;
            this.comboSemestres.SelectedIndexChanged += new System.EventHandler(this.mostrarGrupos);
            this.comboSemestres.MouseWheel += new System.Windows.Forms.MouseEventHandler(ControladorVisual.evitarScroll);
            // 
            // lblEstudiantes
            // 
            this.lblEstudiantes.AutoSize = true;
            this.lblEstudiantes.Location = new System.Drawing.Point(12, 9);
            this.lblEstudiantes.Name = "lblEstudiantes";
            this.lblEstudiantes.Size = new System.Drawing.Size(99, 22);
            this.lblEstudiantes.TabIndex = 17;
            this.lblEstudiantes.Text = "Estudiantes";
            // 
            // cmdNuevoEstudiante
            // 
            this.cmdNuevoEstudiante.Location = new System.Drawing.Point(646, 146);
            this.cmdNuevoEstudiante.Name = "cmdNuevoEstudiante";
            this.cmdNuevoEstudiante.Size = new System.Drawing.Size(168, 34);
            this.cmdNuevoEstudiante.TabIndex = 16;
            this.cmdNuevoEstudiante.Text = "Nuevo estudiante...";
            this.cmdNuevoEstudiante.UseVisualStyleBackColor = true;
            this.cmdNuevoEstudiante.Click += new System.EventHandler(this.cmdNuevoEstudiante_Click);
            // 
            // cmdEliminarEstudiante
            // 
            this.cmdEliminarEstudiante.Location = new System.Drawing.Point(646, 486);
            this.cmdEliminarEstudiante.Name = "cmdEliminarEstudiante";
            this.cmdEliminarEstudiante.Size = new System.Drawing.Size(168, 34);
            this.cmdEliminarEstudiante.TabIndex = 15;
            this.cmdEliminarEstudiante.Text = "Eliminar";
            this.cmdEliminarEstudiante.UseVisualStyleBackColor = true;
            this.cmdEliminarEstudiante.Click += new System.EventHandler(this.cmdEliminarEstudiante_Click);
            // 
            // cmdEditarEstudiante
            // 
            this.cmdEditarEstudiante.Location = new System.Drawing.Point(12, 486);
            this.cmdEditarEstudiante.Name = "cmdEditarEstudiante";
            this.cmdEditarEstudiante.Size = new System.Drawing.Size(168, 34);
            this.cmdEditarEstudiante.TabIndex = 14;
            this.cmdEditarEstudiante.Text = "Editar estudiante...";
            this.cmdEditarEstudiante.UseVisualStyleBackColor = true;
            this.cmdEditarEstudiante.Click += new System.EventHandler(this.cmdEditarEstudiante_Click);
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.AllowUserToAddRows = false;
            this.dgvEstudiantes.AllowUserToDeleteRows = false;
            this.dgvEstudiantes.AllowUserToResizeRows = false;
            this.dgvEstudiantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantes.Location = new System.Drawing.Point(12, 186);
            this.dgvEstudiantes.MultiSelect = false;
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.ReadOnly = true;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(802, 294);
            this.dgvEstudiantes.TabIndex = 13;
            // 
            // comboGrupos
            // 
            this.comboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(530, 48);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(284, 30);
            this.comboGrupos.TabIndex = 19;
            this.comboGrupos.SelectedIndexChanged += new System.EventHandler(this.mostrarEstudiantes);
            this.comboGrupos.MouseWheel += new System.Windows.Forms.MouseEventHandler(ControladorVisual.evitarScroll);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(442, 15);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(82, 22);
            this.lblSemestre.TabIndex = 20;
            this.lblSemestre.Text = "Semestre";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(465, 51);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(59, 22);
            this.lblGrupo.TabIndex = 21;
            this.lblGrupo.Text = "Grupo";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 40);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(251, 29);
            this.txtBusqueda.TabIndex = 22;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.cambioDeCriterio);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(269, 40);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(93, 29);
            this.cmdBuscar.TabIndex = 23;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 22);
            this.label4.TabIndex = 24;
            this.label4.Text = "Criterios de búsqueda";
            // 
            // chkNcontrol
            // 
            this.chkNcontrol.AutoSize = true;
            this.chkNcontrol.Location = new System.Drawing.Point(12, 154);
            this.chkNcontrol.Name = "chkNcontrol";
            this.chkNcontrol.Size = new System.Drawing.Size(152, 26);
            this.chkNcontrol.TabIndex = 29;
            this.chkNcontrol.Text = "Núm. de control";
            this.chkNcontrol.UseVisualStyleBackColor = true;
            this.chkNcontrol.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkCurp
            // 
            this.chkCurp.AutoSize = true;
            this.chkCurp.Location = new System.Drawing.Point(186, 154);
            this.chkCurp.Name = "chkCurp";
            this.chkCurp.Size = new System.Drawing.Size(71, 26);
            this.chkCurp.TabIndex = 30;
            this.chkCurp.Text = "CURP";
            this.chkCurp.UseVisualStyleBackColor = true;
            this.chkCurp.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkNombres
            // 
            this.chkNombres.AutoSize = true;
            this.chkNombres.Location = new System.Drawing.Point(186, 106);
            this.chkNombres.Name = "chkNombres";
            this.chkNombres.Size = new System.Drawing.Size(100, 26);
            this.chkNombres.TabIndex = 32;
            this.chkNombres.Text = "Nombres";
            this.chkNombres.UseVisualStyleBackColor = true;
            this.chkNombres.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkNombreCompleto
            // 
            this.chkNombreCompleto.AutoSize = true;
            this.chkNombreCompleto.Location = new System.Drawing.Point(12, 106);
            this.chkNombreCompleto.Name = "chkNombreCompleto";
            this.chkNombreCompleto.Size = new System.Drawing.Size(168, 26);
            this.chkNombreCompleto.TabIndex = 31;
            this.chkNombreCompleto.Text = "Nombre completo";
            this.chkNombreCompleto.UseVisualStyleBackColor = true;
            this.chkNombreCompleto.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkApellidoMaterno
            // 
            this.chkApellidoMaterno.AutoSize = true;
            this.chkApellidoMaterno.Location = new System.Drawing.Point(186, 130);
            this.chkApellidoMaterno.Name = "chkApellidoMaterno";
            this.chkApellidoMaterno.Size = new System.Drawing.Size(160, 26);
            this.chkApellidoMaterno.TabIndex = 34;
            this.chkApellidoMaterno.Text = "Apellido materno";
            this.chkApellidoMaterno.UseVisualStyleBackColor = true;
            this.chkApellidoMaterno.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkApellidoPaterno
            // 
            this.chkApellidoPaterno.AutoSize = true;
            this.chkApellidoPaterno.Location = new System.Drawing.Point(12, 130);
            this.chkApellidoPaterno.Name = "chkApellidoPaterno";
            this.chkApellidoPaterno.Size = new System.Drawing.Size(155, 26);
            this.chkApellidoPaterno.TabIndex = 33;
            this.chkApellidoPaterno.Text = "Apellido paterno";
            this.chkApellidoPaterno.UseVisualStyleBackColor = true;
            this.chkApellidoPaterno.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAdvertencia.Location = new System.Drawing.Point(136, 12);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(210, 18);
            this.lblAdvertencia.TabIndex = 35;
            this.lblAdvertencia.Text = "Criterios de búsqueda cambiados.";
            this.lblAdvertencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdvertencia.Visible = false;
            // 
            // chkNss
            // 
            this.chkNss.AutoSize = true;
            this.chkNss.Location = new System.Drawing.Point(263, 154);
            this.chkNss.Name = "chkNss";
            this.chkNss.Size = new System.Drawing.Size(59, 26);
            this.chkNss.TabIndex = 36;
            this.chkNss.Text = "NSS";
            this.chkNss.UseVisualStyleBackColor = true;
            this.chkNss.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // FrmEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 532);
            this.Controls.Add(this.chkNss);
            this.Controls.Add(this.lblAdvertencia);
            this.Controls.Add(this.chkApellidoMaterno);
            this.Controls.Add(this.chkApellidoPaterno);
            this.Controls.Add(this.chkNombres);
            this.Controls.Add(this.chkNombreCompleto);
            this.Controls.Add(this.chkCurp);
            this.Controls.Add(this.chkNcontrol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblSemestre);
            this.Controls.Add(this.comboGrupos);
            this.Controls.Add(this.comboSemestres);
            this.Controls.Add(this.lblEstudiantes);
            this.Controls.Add(this.cmdNuevoEstudiante);
            this.Controls.Add(this.cmdEliminarEstudiante);
            this.Controls.Add(this.cmdEditarEstudiante);
            this.Controls.Add(this.dgvEstudiantes);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(842, 571);
            this.Name = "FrmEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estudiantes - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmEstudiantes_Load);
            this.Resize += new System.EventHandler(this.FrmEstudiantes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSemestres;
        private System.Windows.Forms.Label lblEstudiantes;
        private System.Windows.Forms.Button cmdNuevoEstudiante;
        private System.Windows.Forms.Button cmdEliminarEstudiante;
        private System.Windows.Forms.Button cmdEditarEstudiante;
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.ComboBox comboGrupos;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNcontrol;
        private System.Windows.Forms.CheckBox chkCurp;
        private System.Windows.Forms.CheckBox chkNombres;
        private System.Windows.Forms.CheckBox chkNombreCompleto;
        private System.Windows.Forms.CheckBox chkApellidoMaterno;
        private System.Windows.Forms.CheckBox chkApellidoPaterno;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.CheckBox chkNss;
    }
}