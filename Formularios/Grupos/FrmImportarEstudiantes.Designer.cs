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
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.dgvEstudiantesActuales = new System.Windows.Forms.DataGridView();
            this.cmdAgregarSeleccion = new System.Windows.Forms.Button();
            this.cmdAgregarTodos = new System.Windows.Forms.Button();
            this.txtGrado = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipCmdAgregarSeleccion = new System.Windows.Forms.ToolTip(this.components);
            this.cmdEliminarSeleccion = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.chkNss = new System.Windows.Forms.CheckBox();
            this.chkApellidoMaterno = new System.Windows.Forms.CheckBox();
            this.chkApellidoPaterno = new System.Windows.Forms.CheckBox();
            this.chkNombres = new System.Windows.Forms.CheckBox();
            this.chkNombreCompleto = new System.Windows.Forms.CheckBox();
            this.chkCurp = new System.Windows.Forms.CheckBox();
            this.chkNcontrol = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblEstudiantes = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.comboSemestres = new System.Windows.Forms.ComboBox();
            this.toolTipEliminarEstudiantes = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.AllowUserToAddRows = false;
            this.dgvEstudiantes.AllowUserToDeleteRows = false;
            this.dgvEstudiantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantes.Location = new System.Drawing.Point(12, 228);
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.ReadOnly = true;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(445, 294);
            this.dgvEstudiantes.TabIndex = 20;
            // 
            // dgvEstudiantesActuales
            // 
            this.dgvEstudiantesActuales.AllowUserToAddRows = false;
            this.dgvEstudiantesActuales.AllowUserToDeleteRows = false;
            this.dgvEstudiantesActuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantesActuales.Location = new System.Drawing.Point(519, 228);
            this.dgvEstudiantesActuales.Name = "dgvEstudiantesActuales";
            this.dgvEstudiantesActuales.ReadOnly = true;
            this.dgvEstudiantesActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantesActuales.Size = new System.Drawing.Size(445, 294);
            this.dgvEstudiantesActuales.TabIndex = 23;
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
            // txtGrado
            // 
            this.txtGrado.AcceptsReturn = true;
            this.txtGrado.BackColor = System.Drawing.SystemColors.Control;
            this.txtGrado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrado.Enabled = false;
            this.txtGrado.Location = new System.Drawing.Point(519, 194);
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
            this.txtEspecialidad.Location = new System.Drawing.Point(519, 170);
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
            this.txtSemestre.Location = new System.Drawing.Point(519, 146);
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
            this.label2.Location = new System.Drawing.Point(513, 110);
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
            this.toolTipEliminarEstudiantes.SetToolTip(this.cmdEliminarSeleccion, "Los alumnos seleccionados");
            this.cmdEliminarSeleccion.UseVisualStyleBackColor = true;
            this.cmdEliminarSeleccion.Click += new System.EventHandler(this.cmdEliminarSeleccion_Click);
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
            // chkNss
            // 
            this.chkNss.AutoSize = true;
            this.chkNss.Location = new System.Drawing.Point(263, 154);
            this.chkNss.Name = "chkNss";
            this.chkNss.Size = new System.Drawing.Size(59, 26);
            this.chkNss.TabIndex = 57;
            this.chkNss.Text = "NSS";
            this.chkNss.UseVisualStyleBackColor = true;
            this.chkNss.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkApellidoMaterno
            // 
            this.chkApellidoMaterno.AutoSize = true;
            this.chkApellidoMaterno.Location = new System.Drawing.Point(186, 130);
            this.chkApellidoMaterno.Name = "chkApellidoMaterno";
            this.chkApellidoMaterno.Size = new System.Drawing.Size(160, 26);
            this.chkApellidoMaterno.TabIndex = 56;
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
            this.chkApellidoPaterno.TabIndex = 55;
            this.chkApellidoPaterno.Text = "Apellido paterno";
            this.chkApellidoPaterno.UseVisualStyleBackColor = true;
            this.chkApellidoPaterno.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkNombres
            // 
            this.chkNombres.AutoSize = true;
            this.chkNombres.Location = new System.Drawing.Point(186, 106);
            this.chkNombres.Name = "chkNombres";
            this.chkNombres.Size = new System.Drawing.Size(100, 26);
            this.chkNombres.TabIndex = 54;
            this.chkNombres.Text = "Nombres";
            this.chkNombres.UseVisualStyleBackColor = true;
            this.chkNombres.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkNombreCompleto
            // 
            this.chkNombreCompleto.AutoSize = true;
            this.chkNombreCompleto.Checked = true;
            this.chkNombreCompleto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNombreCompleto.Enabled = false;
            this.chkNombreCompleto.Location = new System.Drawing.Point(12, 106);
            this.chkNombreCompleto.Name = "chkNombreCompleto";
            this.chkNombreCompleto.Size = new System.Drawing.Size(168, 26);
            this.chkNombreCompleto.TabIndex = 53;
            this.chkNombreCompleto.Text = "Nombre completo";
            this.chkNombreCompleto.UseVisualStyleBackColor = true;
            this.chkNombreCompleto.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkCurp
            // 
            this.chkCurp.AutoSize = true;
            this.chkCurp.Location = new System.Drawing.Point(186, 154);
            this.chkCurp.Name = "chkCurp";
            this.chkCurp.Size = new System.Drawing.Size(71, 26);
            this.chkCurp.TabIndex = 52;
            this.chkCurp.Text = "CURP";
            this.chkCurp.UseVisualStyleBackColor = true;
            this.chkCurp.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // chkNcontrol
            // 
            this.chkNcontrol.AutoSize = true;
            this.chkNcontrol.Location = new System.Drawing.Point(12, 154);
            this.chkNcontrol.Name = "chkNcontrol";
            this.chkNcontrol.Size = new System.Drawing.Size(152, 26);
            this.chkNcontrol.TabIndex = 51;
            this.chkNcontrol.Text = "Núm. de control";
            this.chkNcontrol.UseVisualStyleBackColor = true;
            this.chkNcontrol.CheckedChanged += new System.EventHandler(this.cambioDeCriterio);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 22);
            this.label4.TabIndex = 50;
            this.label4.Text = "Criterios de búsqueda";
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAdvertencia.Location = new System.Drawing.Point(233, 11);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(210, 18);
            this.lblAdvertencia.TabIndex = 61;
            this.lblAdvertencia.Text = "Criterios de búsqueda cambiados.";
            this.lblAdvertencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdvertencia.Visible = false;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(269, 40);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(93, 29);
            this.cmdBuscar.TabIndex = 60;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.mostrarEstudiantes);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 40);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(251, 29);
            this.txtBusqueda.TabIndex = 59;
            // 
            // lblEstudiantes
            // 
            this.lblEstudiantes.AutoSize = true;
            this.lblEstudiantes.Location = new System.Drawing.Point(12, 9);
            this.lblEstudiantes.Name = "lblEstudiantes";
            this.lblEstudiantes.Size = new System.Drawing.Size(216, 22);
            this.lblEstudiantes.TabIndex = 58;
            this.lblEstudiantes.Text = "Estudiantes - (0 resultados)";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(465, 51);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(59, 22);
            this.lblGrupo.TabIndex = 65;
            this.lblGrupo.Text = "Grupo";
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(442, 15);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(82, 22);
            this.lblSemestre.TabIndex = 64;
            this.lblSemestre.Text = "Semestre";
            // 
            // comboGrupos
            // 
            this.comboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(530, 48);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(284, 30);
            this.comboGrupos.TabIndex = 63;
            this.comboGrupos.SelectedIndexChanged += new System.EventHandler(this.mostrarEstudiantes);
            // 
            // comboSemestres
            // 
            this.comboSemestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestres.FormattingEnabled = true;
            this.comboSemestres.Location = new System.Drawing.Point(530, 12);
            this.comboSemestres.Name = "comboSemestres";
            this.comboSemestres.Size = new System.Drawing.Size(284, 30);
            this.comboSemestres.TabIndex = 62;
            this.comboSemestres.SelectedIndexChanged += new System.EventHandler(this.mostrarGrupos);
            // 
            // toolTipEliminarEstudiantes
            // 
            this.toolTipEliminarEstudiantes.ToolTipTitle = "Eliminar del grupo...";
            // 
            // FrmImportarEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 534);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblSemestre);
            this.Controls.Add(this.comboGrupos);
            this.Controls.Add(this.comboSemestres);
            this.Controls.Add(this.lblAdvertencia);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblEstudiantes);
            this.Controls.Add(this.chkNss);
            this.Controls.Add(this.chkApellidoMaterno);
            this.Controls.Add(this.chkApellidoPaterno);
            this.Controls.Add(this.chkNombres);
            this.Controls.Add(this.chkNombreCompleto);
            this.Controls.Add(this.chkCurp);
            this.Controls.Add(this.chkNcontrol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdEliminarSeleccion);
            this.Controls.Add(this.txtGrado);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.txtSemestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAgregarTodos);
            this.Controls.Add(this.cmdAgregarSeleccion);
            this.Controls.Add(this.dgvEstudiantesActuales);
            this.Controls.Add(this.dgvEstudiantes);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmImportarEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar estudiantes - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmImportarEstudiantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantesActuales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.DataGridView dgvEstudiantesActuales;
        private System.Windows.Forms.Button cmdAgregarSeleccion;
        private System.Windows.Forms.Button cmdAgregarTodos;
        private System.Windows.Forms.TextBox txtGrado;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox txtSemestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTipCmdAgregarSeleccion;
        private System.Windows.Forms.Button cmdEliminarSeleccion;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.CheckBox chkNss;
        private System.Windows.Forms.CheckBox chkApellidoMaterno;
        private System.Windows.Forms.CheckBox chkApellidoPaterno;
        private System.Windows.Forms.CheckBox chkNombres;
        private System.Windows.Forms.CheckBox chkNombreCompleto;
        private System.Windows.Forms.CheckBox chkCurp;
        private System.Windows.Forms.CheckBox chkNcontrol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblEstudiantes;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.ComboBox comboGrupos;
        private System.Windows.Forms.ComboBox comboSemestres;
        private System.Windows.Forms.ToolTip toolTipEliminarEstudiantes;
    }
}