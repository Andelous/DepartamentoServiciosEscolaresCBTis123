namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmPrincipal
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmdCerrarSesion = new System.Windows.Forms.Button();
            this.cmdSemestres = new System.Windows.Forms.Button();
            this.cmdGrupos = new System.Windows.Forms.Button();
            this.cmdEstudiantes = new System.Windows.Forms.Button();
            this.cmdDocentes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdAcreditacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido,";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(108, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 22);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // cmdCerrarSesion
            // 
            this.cmdCerrarSesion.Location = new System.Drawing.Point(490, 12);
            this.cmdCerrarSesion.Name = "cmdCerrarSesion";
            this.cmdCerrarSesion.Size = new System.Drawing.Size(167, 32);
            this.cmdCerrarSesion.TabIndex = 2;
            this.cmdCerrarSesion.Text = "Cerrar sesión";
            this.cmdCerrarSesion.UseVisualStyleBackColor = true;
            this.cmdCerrarSesion.Click += new System.EventHandler(this.cmdCerrarSesion_Click);
            // 
            // cmdSemestres
            // 
            this.cmdSemestres.Location = new System.Drawing.Point(103, 115);
            this.cmdSemestres.Name = "cmdSemestres";
            this.cmdSemestres.Size = new System.Drawing.Size(119, 35);
            this.cmdSemestres.TabIndex = 3;
            this.cmdSemestres.Text = "Semestres";
            this.cmdSemestres.UseVisualStyleBackColor = true;
            this.cmdSemestres.Click += new System.EventHandler(this.cmdSemestres_Click);
            // 
            // cmdGrupos
            // 
            this.cmdGrupos.Location = new System.Drawing.Point(228, 115);
            this.cmdGrupos.Name = "cmdGrupos";
            this.cmdGrupos.Size = new System.Drawing.Size(119, 35);
            this.cmdGrupos.TabIndex = 4;
            this.cmdGrupos.Text = "Grupos";
            this.cmdGrupos.UseVisualStyleBackColor = true;
            this.cmdGrupos.Click += new System.EventHandler(this.cmdGrupos_Click);
            // 
            // cmdEstudiantes
            // 
            this.cmdEstudiantes.Location = new System.Drawing.Point(353, 115);
            this.cmdEstudiantes.Name = "cmdEstudiantes";
            this.cmdEstudiantes.Size = new System.Drawing.Size(119, 35);
            this.cmdEstudiantes.TabIndex = 5;
            this.cmdEstudiantes.Text = "Estudiantes";
            this.cmdEstudiantes.UseVisualStyleBackColor = true;
            this.cmdEstudiantes.Click += new System.EventHandler(this.cmdEstudiantes_Click);
            // 
            // cmdDocentes
            // 
            this.cmdDocentes.Location = new System.Drawing.Point(103, 156);
            this.cmdDocentes.Name = "cmdDocentes";
            this.cmdDocentes.Size = new System.Drawing.Size(119, 35);
            this.cmdDocentes.TabIndex = 6;
            this.cmdDocentes.Text = "Docentes";
            this.cmdDocentes.UseVisualStyleBackColor = true;
            this.cmdDocentes.Click += new System.EventHandler(this.cmdDocentes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdAcreditacion
            // 
            this.cmdAcreditacion.Location = new System.Drawing.Point(228, 156);
            this.cmdAcreditacion.Name = "cmdAcreditacion";
            this.cmdAcreditacion.Size = new System.Drawing.Size(119, 35);
            this.cmdAcreditacion.TabIndex = 8;
            this.cmdAcreditacion.Text = "Acreditación";
            this.cmdAcreditacion.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 366);
            this.Controls.Add(this.cmdAcreditacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdDocentes);
            this.Controls.Add(this.cmdEstudiantes);
            this.Controls.Add(this.cmdGrupos);
            this.Controls.Add(this.cmdSemestres);
            this.Controls.Add(this.cmdCerrarSesion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal - Control Escolar CBTis 123";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button cmdCerrarSesion;
        private System.Windows.Forms.Button cmdSemestres;
        private System.Windows.Forms.Button cmdGrupos;
        private System.Windows.Forms.Button cmdEstudiantes;
        private System.Windows.Forms.Button cmdDocentes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdAcreditacion;
    }
}