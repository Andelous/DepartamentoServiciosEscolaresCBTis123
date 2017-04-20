namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmImportarEstudiantes
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEstudiantesImportar = new System.Windows.Forms.DataGridView();
            this.dgvEstudiantesImportados = new System.Windows.Forms.DataGridView();
            this.cmdAgregarSeleccion = new System.Windows.Forms.Button();
            this.cmdAgregarTodos = new System.Windows.Forms.Button();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.comboSemestres = new System.Windows.Forms.ComboBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.chkTodosLosEstudiantes = new System.Windows.Forms.CheckBox();
            this.txtGrado = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipCmdAgregarSeleccion = new System.Windows.Forms.ToolTip(this.components);
            this.cmdEliminarSeleccion = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesImportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesImportados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Importar Estudiantes";
            // 
            // dgvEstudiantesImportar
            // 
            this.dgvEstudiantesImportar.AllowUserToAddRows = false;
            this.dgvEstudiantesImportar.AllowUserToDeleteRows = false;
            this.dgvEstudiantesImportar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantesImportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantesImportar.Location = new System.Drawing.Point(12, 228);
            this.dgvEstudiantesImportar.Name = "dgvEstudiantesImportar";
            this.dgvEstudiantesImportar.ReadOnly = true;
            this.dgvEstudiantesImportar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantesImportar.Size = new System.Drawing.Size(445, 294);
            this.dgvEstudiantesImportar.TabIndex = 20;
            // 
            // dgvEstudiantesImportados
            // 
            this.dgvEstudiantesImportados.AllowUserToAddRows = false;
            this.dgvEstudiantesImportados.AllowUserToDeleteRows = false;
            this.dgvEstudiantesImportados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantesImportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantesImportados.Location = new System.Drawing.Point(519, 228);
            this.dgvEstudiantesImportados.Name = "dgvEstudiantesImportados";
            this.dgvEstudiantesImportados.ReadOnly = true;
            this.dgvEstudiantesImportados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantesImportados.Size = new System.Drawing.Size(445, 294);
            this.dgvEstudiantesImportados.TabIndex = 23;
            // 
            // cmdAgregarSeleccion
            // 
            this.cmdAgregarSeleccion.Location = new System.Drawing.Point(463, 318);
            this.cmdAgregarSeleccion.Name = "cmdAgregarSeleccion";
            this.cmdAgregarSeleccion.Size = new System.Drawing.Size(50, 30);
            this.cmdAgregarSeleccion.TabIndex = 34;
            this.cmdAgregarSeleccion.Text = ">";
            this.toolTipCmdAgregarSeleccion.SetToolTip(this.cmdAgregarSeleccion, "Alumnos seleccionados");
            this.cmdAgregarSeleccion.UseVisualStyleBackColor = true;
            this.cmdAgregarSeleccion.Click += new System.EventHandler(this.cmdAgregarSeleccion_Click);
            // 
            // cmdAgregarTodos
            // 
            this.cmdAgregarTodos.Location = new System.Drawing.Point(463, 354);
            this.cmdAgregarTodos.Name = "cmdAgregarTodos";
            this.cmdAgregarTodos.Size = new System.Drawing.Size(50, 30);
            this.cmdAgregarTodos.TabIndex = 35;
            this.cmdAgregarTodos.Text = ">>";
            this.toolTipCmdAgregarSeleccion.SetToolTip(this.cmdAgregarTodos, "Todos los alumnos en la lista");
            this.cmdAgregarTodos.UseVisualStyleBackColor = true;
            this.cmdAgregarTodos.Click += new System.EventHandler(this.cmdAgregarTodos_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(12, 100);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(59, 22);
            this.lblGrupo.TabIndex = 39;
            this.lblGrupo.Text = "Grupo";
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(12, 42);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(82, 22);
            this.lblSemestre.TabIndex = 38;
            this.lblSemestre.Text = "Semestre";
            // 
            // comboGrupos
            // 
            this.comboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(12, 125);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(284, 30);
            this.comboGrupos.TabIndex = 37;
            this.comboGrupos.SelectedIndexChanged += new System.EventHandler(this.comboGrupos_SelectedIndexChanged);
            // 
            // comboSemestres
            // 
            this.comboSemestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestres.FormattingEnabled = true;
            this.comboSemestres.Location = new System.Drawing.Point(12, 67);
            this.comboSemestres.Name = "comboSemestres";
            this.comboSemestres.Size = new System.Drawing.Size(284, 30);
            this.comboSemestres.TabIndex = 36;
            this.comboSemestres.SelectedIndexChanged += new System.EventHandler(this.comboSemestres_SelectedIndexChanged);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(319, 193);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(93, 29);
            this.cmdBuscar.TabIndex = 41;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 193);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(301, 29);
            this.txtBusqueda.TabIndex = 40;
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // chkTodosLosEstudiantes
            // 
            this.chkTodosLosEstudiantes.AutoSize = true;
            this.chkTodosLosEstudiantes.Location = new System.Drawing.Point(12, 161);
            this.chkTodosLosEstudiantes.Name = "chkTodosLosEstudiantes";
            this.chkTodosLosEstudiantes.Size = new System.Drawing.Size(195, 26);
            this.chkTodosLosEstudiantes.TabIndex = 42;
            this.chkTodosLosEstudiantes.Text = "Todos los estudiantes";
            this.chkTodosLosEstudiantes.UseVisualStyleBackColor = true;
            this.chkTodosLosEstudiantes.CheckedChanged += new System.EventHandler(this.chkTodosLosEstudiantes_CheckedChanged);
            // 
            // txtGrado
            // 
            this.txtGrado.AcceptsReturn = true;
            this.txtGrado.BackColor = System.Drawing.SystemColors.Control;
            this.txtGrado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrado.Enabled = false;
            this.txtGrado.Location = new System.Drawing.Point(473, 200);
            this.txtGrado.Name = "txtGrado";
            this.txtGrado.Size = new System.Drawing.Size(242, 22);
            this.txtGrado.TabIndex = 46;
            this.txtGrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.AcceptsReturn = true;
            this.txtEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.txtEspecialidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEspecialidad.Enabled = false;
            this.txtEspecialidad.Location = new System.Drawing.Point(473, 176);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(242, 22);
            this.txtEspecialidad.TabIndex = 45;
            this.txtEspecialidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSemestre
            // 
            this.txtSemestre.AcceptsReturn = true;
            this.txtSemestre.BackColor = System.Drawing.SystemColors.Control;
            this.txtSemestre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSemestre.Enabled = false;
            this.txtSemestre.Location = new System.Drawing.Point(473, 152);
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.Size = new System.Drawing.Size(242, 22);
            this.txtSemestre.TabIndex = 44;
            this.txtSemestre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(467, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 33);
            this.label2.TabIndex = 43;
            this.label2.Text = "Grupo";
            // 
            // toolTipCmdAgregarSeleccion
            // 
            this.toolTipCmdAgregarSeleccion.ToolTipTitle = "Agregar a grupo...";
            // 
            // cmdEliminarSeleccion
            // 
            this.cmdEliminarSeleccion.Location = new System.Drawing.Point(483, 414);
            this.cmdEliminarSeleccion.Name = "cmdEliminarSeleccion";
            this.cmdEliminarSeleccion.Size = new System.Drawing.Size(30, 30);
            this.cmdEliminarSeleccion.TabIndex = 48;
            this.cmdEliminarSeleccion.Text = "x";
            this.toolTipCmdAgregarSeleccion.SetToolTip(this.cmdEliminarSeleccion, "Todos los alumnos en la lista");
            this.cmdEliminarSeleccion.UseVisualStyleBackColor = true;
            this.cmdEliminarSeleccion.Click += new System.EventHandler(this.cmdEliminarSeleccion_Click);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(315, 165);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(94, 22);
            this.lblResultados.TabIndex = 47;
            this.lblResultados.Text = "Resultados";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Location = new System.Drawing.Point(847, 188);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(117, 34);
            this.cmdGuardar.TabIndex = 49;
            this.cmdGuardar.Text = "Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // FrmImportarEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 534);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdEliminarSeleccion);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.txtGrado);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.txtSemestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkTodosLosEstudiantes);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblSemestre);
            this.Controls.Add(this.comboGrupos);
            this.Controls.Add(this.comboSemestres);
            this.Controls.Add(this.cmdAgregarTodos);
            this.Controls.Add(this.cmdAgregarSeleccion);
            this.Controls.Add(this.dgvEstudiantesImportados);
            this.Controls.Add(this.dgvEstudiantesImportar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmImportarEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar estudiantes - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmImportarEstudiantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesImportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesImportados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEstudiantesImportar;
        private System.Windows.Forms.DataGridView dgvEstudiantesImportados;
        private System.Windows.Forms.Button cmdAgregarSeleccion;
        private System.Windows.Forms.Button cmdAgregarTodos;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.ComboBox comboGrupos;
        private System.Windows.Forms.ComboBox comboSemestres;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.CheckBox chkTodosLosEstudiantes;
        private System.Windows.Forms.TextBox txtGrado;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox txtSemestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTipCmdAgregarSeleccion;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Button cmdEliminarSeleccion;
        private System.Windows.Forms.Button cmdGuardar;
    }
}