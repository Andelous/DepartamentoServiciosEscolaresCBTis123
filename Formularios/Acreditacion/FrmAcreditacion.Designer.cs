﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;

namespace DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion
{
    partial class FrmAcreditacion
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
            this.comboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblAcreditacionPorGrupo = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.comboCarrera = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.comboGrupo = new System.Windows.Forms.ComboBox();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.comboAsignatura = new System.Windows.Forms.ComboBox();
            this.dgvCalificaciones = new System.Windows.Forms.DataGridView();
            this.cmdImportar = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdReestablecer = new System.Windows.Forms.Button();
            this.pnlArriba = new System.Windows.Forms.Panel();
            this.pnlBotonesTopRight = new System.Windows.Forms.Panel();
            this.cmdVerHistorial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificaciones)).BeginInit();
            this.pnlArriba.SuspendLayout();
            this.pnlBotonesTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPeriodo
            // 
            this.comboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPeriodo.FormattingEnabled = true;
            this.comboPeriodo.Location = new System.Drawing.Point(100, 37);
            this.comboPeriodo.Name = "comboPeriodo";
            this.comboPeriodo.Size = new System.Drawing.Size(303, 21);
            this.comboPeriodo.TabIndex = 0;
            this.comboPeriodo.SelectedIndexChanged += new System.EventHandler(this.cargarGrupos);
            // 
            // lblAcreditacionPorGrupo
            // 
            this.lblAcreditacionPorGrupo.AutoSize = true;
            this.lblAcreditacionPorGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcreditacionPorGrupo.Location = new System.Drawing.Point(12, 9);
            this.lblAcreditacionPorGrupo.Name = "lblAcreditacionPorGrupo";
            this.lblAcreditacionPorGrupo.Size = new System.Drawing.Size(166, 16);
            this.lblAcreditacionPorGrupo.TabIndex = 1;
            this.lblAcreditacionPorGrupo.Text = "Acreditación por grupo";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(33, 40);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(43, 13);
            this.lblPeriodo.TabIndex = 2;
            this.lblPeriodo.Text = "Periodo";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(33, 67);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(35, 13);
            this.lblTurno.TabIndex = 4;
            this.lblTurno.Text = "Turno";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Items.AddRange(new object[] {
            "Matutino",
            "Vespertino"});
            this.comboTurno.Location = new System.Drawing.Point(100, 64);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(303, 21);
            this.comboTurno.TabIndex = 3;
            this.comboTurno.SelectedIndexChanged += new System.EventHandler(this.cargarGrupos);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(33, 94);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(51, 13);
            this.lblSemestre.TabIndex = 6;
            this.lblSemestre.Text = "Semestre";
            // 
            // comboSemestre
            // 
            this.comboSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Items.AddRange(new object[] {
            "Primer semestre",
            "Segundo semestre",
            "Tercer semestre",
            "Cuarto semestre",
            "Quinto semestre",
            "Sexto semestre",
            "Séptimo semestre",
            "Octavo semestre"});
            this.comboSemestre.Location = new System.Drawing.Point(100, 91);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(303, 21);
            this.comboSemestre.TabIndex = 5;
            this.comboSemestre.SelectedIndexChanged += new System.EventHandler(this.cargarGrupos);
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Location = new System.Drawing.Point(409, 40);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(41, 13);
            this.lblCarrera.TabIndex = 8;
            this.lblCarrera.Text = "Carrera";
            // 
            // comboCarrera
            // 
            this.comboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCarrera.FormattingEnabled = true;
            this.comboCarrera.Location = new System.Drawing.Point(476, 37);
            this.comboCarrera.Name = "comboCarrera";
            this.comboCarrera.Size = new System.Drawing.Size(303, 21);
            this.comboCarrera.TabIndex = 7;
            this.comboCarrera.SelectedIndexChanged += new System.EventHandler(this.cargarGrupos);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(409, 67);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 10;
            this.lblGrupo.Text = "Grupo";
            // 
            // comboGrupo
            // 
            this.comboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrupo.FormattingEnabled = true;
            this.comboGrupo.Location = new System.Drawing.Point(476, 64);
            this.comboGrupo.Name = "comboGrupo";
            this.comboGrupo.Size = new System.Drawing.Size(303, 21);
            this.comboGrupo.TabIndex = 9;
            this.comboGrupo.SelectedIndexChanged += new System.EventHandler(this.cargarCatedras);
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.Location = new System.Drawing.Point(409, 94);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(57, 13);
            this.lblAsignatura.TabIndex = 12;
            this.lblAsignatura.Text = "Asignatura";
            // 
            // comboAsignatura
            // 
            this.comboAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAsignatura.FormattingEnabled = true;
            this.comboAsignatura.Location = new System.Drawing.Point(476, 91);
            this.comboAsignatura.Name = "comboAsignatura";
            this.comboAsignatura.Size = new System.Drawing.Size(303, 21);
            this.comboAsignatura.TabIndex = 11;
            this.comboAsignatura.SelectedIndexChanged += new System.EventHandler(this.cargarAlumnos);
            // 
            // dgvCalificaciones
            // 
            this.dgvCalificaciones.AllowUserToAddRows = false;
            this.dgvCalificaciones.AllowUserToDeleteRows = false;
            this.dgvCalificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalificaciones.Location = new System.Drawing.Point(0, 128);
            this.dgvCalificaciones.MultiSelect = false;
            this.dgvCalificaciones.Name = "dgvCalificaciones";
            this.dgvCalificaciones.RowHeadersWidth = 60;
            this.dgvCalificaciones.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCalificaciones.Size = new System.Drawing.Size(1030, 388);
            this.dgvCalificaciones.TabIndex = 13;
            this.dgvCalificaciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalificaciones_CellValueChanged);
            // 
            // cmdImportar
            // 
            this.cmdImportar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdImportar.Enabled = false;
            this.cmdImportar.Location = new System.Drawing.Point(0, 32);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(201, 32);
            this.cmdImportar.TabIndex = 14;
            this.cmdImportar.Text = "Importar de SISEEMS";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdGuardar.Enabled = false;
            this.cmdGuardar.Location = new System.Drawing.Point(0, 0);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(201, 32);
            this.cmdGuardar.TabIndex = 15;
            this.cmdGuardar.Text = "Guardar calificaciones";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdReestablecer
            // 
            this.cmdReestablecer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdReestablecer.Enabled = false;
            this.cmdReestablecer.Location = new System.Drawing.Point(0, 64);
            this.cmdReestablecer.Name = "cmdReestablecer";
            this.cmdReestablecer.Size = new System.Drawing.Size(201, 32);
            this.cmdReestablecer.TabIndex = 16;
            this.cmdReestablecer.Text = "Reestablecer valor";
            this.cmdReestablecer.UseVisualStyleBackColor = true;
            this.cmdReestablecer.Click += new System.EventHandler(this.cmdReestablecer_Click);
            // 
            // pnlArriba
            // 
            this.pnlArriba.Controls.Add(this.pnlBotonesTopRight);
            this.pnlArriba.Controls.Add(this.lblAcreditacionPorGrupo);
            this.pnlArriba.Controls.Add(this.comboPeriodo);
            this.pnlArriba.Controls.Add(this.lblPeriodo);
            this.pnlArriba.Controls.Add(this.comboTurno);
            this.pnlArriba.Controls.Add(this.lblAsignatura);
            this.pnlArriba.Controls.Add(this.lblTurno);
            this.pnlArriba.Controls.Add(this.comboAsignatura);
            this.pnlArriba.Controls.Add(this.comboSemestre);
            this.pnlArriba.Controls.Add(this.lblGrupo);
            this.pnlArriba.Controls.Add(this.lblSemestre);
            this.pnlArriba.Controls.Add(this.comboGrupo);
            this.pnlArriba.Controls.Add(this.comboCarrera);
            this.pnlArriba.Controls.Add(this.lblCarrera);
            this.pnlArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArriba.Location = new System.Drawing.Point(0, 0);
            this.pnlArriba.Name = "pnlArriba";
            this.pnlArriba.Size = new System.Drawing.Size(1030, 128);
            this.pnlArriba.TabIndex = 17;
            // 
            // pnlBotonesTopRight
            // 
            this.pnlBotonesTopRight.Controls.Add(this.cmdVerHistorial);
            this.pnlBotonesTopRight.Controls.Add(this.cmdReestablecer);
            this.pnlBotonesTopRight.Controls.Add(this.cmdImportar);
            this.pnlBotonesTopRight.Controls.Add(this.cmdGuardar);
            this.pnlBotonesTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotonesTopRight.Location = new System.Drawing.Point(829, 0);
            this.pnlBotonesTopRight.Name = "pnlBotonesTopRight";
            this.pnlBotonesTopRight.Size = new System.Drawing.Size(201, 128);
            this.pnlBotonesTopRight.TabIndex = 17;
            // 
            // cmdVerHistorial
            // 
            this.cmdVerHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdVerHistorial.Enabled = false;
            this.cmdVerHistorial.Location = new System.Drawing.Point(0, 96);
            this.cmdVerHistorial.Name = "cmdVerHistorial";
            this.cmdVerHistorial.Size = new System.Drawing.Size(201, 32);
            this.cmdVerHistorial.TabIndex = 17;
            this.cmdVerHistorial.Text = "Ver historial de cambios";
            this.cmdVerHistorial.UseVisualStyleBackColor = true;
            this.cmdVerHistorial.Click += new System.EventHandler(this.cmdVerHistorial_Click);
            // 
            // FrmAcreditacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 516);
            this.Controls.Add(this.dgvCalificaciones);
            this.Controls.Add(this.pnlArriba);
            this.MinimumSize = new System.Drawing.Size(1046, 555);
            this.Name = "FrmAcreditacion";
            this.Text = "FrmAcreditacion";
            this.Load += new System.EventHandler(this.FrmAcreditacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificaciones)).EndInit();
            this.pnlArriba.ResumeLayout(false);
            this.pnlArriba.PerformLayout();
            this.pnlBotonesTopRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPeriodo;
        private System.Windows.Forms.Label lblAcreditacionPorGrupo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.ComboBox comboCarrera;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox comboGrupo;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.ComboBox comboAsignatura;
        private System.Windows.Forms.DataGridView dgvCalificaciones;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdReestablecer;
        private System.Windows.Forms.Panel pnlArriba;
        private System.Windows.Forms.Panel pnlBotonesTopRight;
        private System.Windows.Forms.Button cmdVerHistorial;
    }
}