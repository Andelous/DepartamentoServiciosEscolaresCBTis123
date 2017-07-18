namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmModificarGrupo
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
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboGrado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSemestres = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(12, 353);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(282, 35);
            this.cmdCancelar.TabIndex = 38;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Location = new System.Drawing.Point(12, 312);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(282, 35);
            this.cmdModificar.TabIndex = 37;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidad.Enabled = false;
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Items.AddRange(new object[] {
            "ADMRH",
            "ELE",
            "EXTRA",
            "LOG",
            "MAU",
            "MEC",
            "PRO",
            "SMEC"});
            this.comboEspecialidad.Location = new System.Drawing.Point(12, 255);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(282, 30);
            this.comboEspecialidad.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 22);
            this.label6.TabIndex = 35;
            this.label6.Text = "Especialidad";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Items.AddRange(new object[] {
            "Matutino",
            "Vespertino"});
            this.comboTurno.Location = new System.Drawing.Point(12, 197);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(282, 30);
            this.comboTurno.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Turno";
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(219, 139);
            this.txtLetra.MaxLength = 1;
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(75, 29);
            this.txtLetra.TabIndex = 32;
            this.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 22);
            this.label4.TabIndex = 31;
            this.label4.Text = "Letra";
            // 
            // comboGrado
            // 
            this.comboGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrado.FormattingEnabled = true;
            this.comboGrado.Items.AddRange(new object[] {
            "1 - Primer semestre",
            "2 - Segundo semestre",
            "3 - Tercer semestre",
            "4 - Cuarto semestre",
            "5 - Quinto semestre",
            "6 - Sexto semestre"});
            this.comboGrado.Location = new System.Drawing.Point(12, 139);
            this.comboGrado.Name = "comboGrado";
            this.comboGrado.Size = new System.Drawing.Size(201, 30);
            this.comboGrado.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Grado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Semestre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Modificar grupo";
            // 
            // comboSemestres
            // 
            this.comboSemestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestres.FormattingEnabled = true;
            this.comboSemestres.Location = new System.Drawing.Point(12, 71);
            this.comboSemestres.Name = "comboSemestres";
            this.comboSemestres.Size = new System.Drawing.Size(282, 30);
            this.comboSemestres.TabIndex = 26;
            // 
            // FrmModificarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(306, 400);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.comboEspecialidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboGrado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSemestres);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar grupo - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmModificarGrupo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboGrado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSemestres;
    }
}