namespace DepartamentoServiciosEscolaresCBTis123
{
    partial class FrmModificarSemestre
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
            this.label9 = new System.Windows.Forms.Label();
            this.nudAnofP3 = new System.Windows.Forms.NumericUpDown();
            this.nudMesfP3 = new System.Windows.Forms.NumericUpDown();
            this.nudDiafP3 = new System.Windows.Forms.NumericUpDown();
            this.nudAnoiP3 = new System.Windows.Forms.NumericUpDown();
            this.nudMesiP3 = new System.Windows.Forms.NumericUpDown();
            this.nudDiaiP3 = new System.Windows.Forms.NumericUpDown();
            this.lblParcial3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudAnofP2 = new System.Windows.Forms.NumericUpDown();
            this.nudMesfP2 = new System.Windows.Forms.NumericUpDown();
            this.nudDiafP2 = new System.Windows.Forms.NumericUpDown();
            this.nudAnoiP2 = new System.Windows.Forms.NumericUpDown();
            this.nudMesiP2 = new System.Windows.Forms.NumericUpDown();
            this.nudDiaiP2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblParcial2 = new System.Windows.Forms.Label();
            this.nudAnofP1 = new System.Windows.Forms.NumericUpDown();
            this.nudMesfP1 = new System.Windows.Forms.NumericUpDown();
            this.nudDiafP1 = new System.Windows.Forms.NumericUpDown();
            this.nudAnoiP1 = new System.Windows.Forms.NumericUpDown();
            this.nudMesiP1 = new System.Windows.Forms.NumericUpDown();
            this.nudDiaiP1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblParcial1 = new System.Windows.Forms.Label();
            this.txtNombreCorto3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.txtNombreCorto2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreCorto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 71;
            this.label9.Text = "a";
            // 
            // nudAnofP3
            // 
            this.nudAnofP3.Location = new System.Drawing.Point(337, 328);
            this.nudAnofP3.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnofP3.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP3.Name = "nudAnofP3";
            this.nudAnofP3.Size = new System.Drawing.Size(75, 26);
            this.nudAnofP3.TabIndex = 70;
            this.nudAnofP3.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP3.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesfP3
            // 
            this.nudMesfP3.Location = new System.Drawing.Point(281, 328);
            this.nudMesfP3.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesfP3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP3.Name = "nudMesfP3";
            this.nudMesfP3.Size = new System.Drawing.Size(50, 26);
            this.nudMesfP3.TabIndex = 69;
            this.nudMesfP3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP3.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiafP3
            // 
            this.nudDiafP3.Location = new System.Drawing.Point(225, 328);
            this.nudDiafP3.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiafP3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiafP3.Name = "nudDiafP3";
            this.nudDiafP3.Size = new System.Drawing.Size(50, 26);
            this.nudDiafP3.TabIndex = 68;
            this.nudDiafP3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudAnoiP3
            // 
            this.nudAnoiP3.Location = new System.Drawing.Point(128, 328);
            this.nudAnoiP3.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnoiP3.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP3.Name = "nudAnoiP3";
            this.nudAnoiP3.Size = new System.Drawing.Size(75, 26);
            this.nudAnoiP3.TabIndex = 67;
            this.nudAnoiP3.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP3.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesiP3
            // 
            this.nudMesiP3.Location = new System.Drawing.Point(72, 328);
            this.nudMesiP3.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesiP3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP3.Name = "nudMesiP3";
            this.nudMesiP3.Size = new System.Drawing.Size(50, 26);
            this.nudMesiP3.TabIndex = 66;
            this.nudMesiP3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP3.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiaiP3
            // 
            this.nudDiaiP3.Location = new System.Drawing.Point(16, 328);
            this.nudDiaiP3.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiaiP3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaiP3.Name = "nudDiaiP3";
            this.nudDiaiP3.Size = new System.Drawing.Size(50, 26);
            this.nudDiaiP3.TabIndex = 65;
            this.nudDiaiP3.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblParcial3
            // 
            this.lblParcial3.AutoSize = true;
            this.lblParcial3.Location = new System.Drawing.Point(12, 303);
            this.lblParcial3.Name = "lblParcial3";
            this.lblParcial3.Size = new System.Drawing.Size(69, 20);
            this.lblParcial3.TabIndex = 64;
            this.lblParcial3.Text = "Parcial 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 63;
            this.label8.Text = "a";
            // 
            // nudAnofP2
            // 
            this.nudAnofP2.Location = new System.Drawing.Point(337, 271);
            this.nudAnofP2.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnofP2.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP2.Name = "nudAnofP2";
            this.nudAnofP2.Size = new System.Drawing.Size(75, 26);
            this.nudAnofP2.TabIndex = 62;
            this.nudAnofP2.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP2.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesfP2
            // 
            this.nudMesfP2.Location = new System.Drawing.Point(281, 271);
            this.nudMesfP2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesfP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP2.Name = "nudMesfP2";
            this.nudMesfP2.Size = new System.Drawing.Size(50, 26);
            this.nudMesfP2.TabIndex = 61;
            this.nudMesfP2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP2.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiafP2
            // 
            this.nudDiafP2.Location = new System.Drawing.Point(225, 271);
            this.nudDiafP2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiafP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiafP2.Name = "nudDiafP2";
            this.nudDiafP2.Size = new System.Drawing.Size(50, 26);
            this.nudDiafP2.TabIndex = 60;
            this.nudDiafP2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudAnoiP2
            // 
            this.nudAnoiP2.Location = new System.Drawing.Point(128, 271);
            this.nudAnoiP2.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnoiP2.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP2.Name = "nudAnoiP2";
            this.nudAnoiP2.Size = new System.Drawing.Size(75, 26);
            this.nudAnoiP2.TabIndex = 59;
            this.nudAnoiP2.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP2.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesiP2
            // 
            this.nudMesiP2.Location = new System.Drawing.Point(72, 271);
            this.nudMesiP2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesiP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP2.Name = "nudMesiP2";
            this.nudMesiP2.Size = new System.Drawing.Size(50, 26);
            this.nudMesiP2.TabIndex = 58;
            this.nudMesiP2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP2.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiaiP2
            // 
            this.nudDiaiP2.Location = new System.Drawing.Point(16, 271);
            this.nudDiaiP2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiaiP2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaiP2.Name = "nudDiaiP2";
            this.nudDiaiP2.Size = new System.Drawing.Size(50, 26);
            this.nudDiaiP2.TabIndex = 57;
            this.nudDiaiP2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "a";
            // 
            // lblParcial2
            // 
            this.lblParcial2.AutoSize = true;
            this.lblParcial2.Location = new System.Drawing.Point(12, 246);
            this.lblParcial2.Name = "lblParcial2";
            this.lblParcial2.Size = new System.Drawing.Size(69, 20);
            this.lblParcial2.TabIndex = 55;
            this.lblParcial2.Text = "Parcial 2";
            // 
            // nudAnofP1
            // 
            this.nudAnofP1.Location = new System.Drawing.Point(337, 214);
            this.nudAnofP1.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnofP1.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP1.Name = "nudAnofP1";
            this.nudAnofP1.Size = new System.Drawing.Size(75, 26);
            this.nudAnofP1.TabIndex = 54;
            this.nudAnofP1.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnofP1.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesfP1
            // 
            this.nudMesfP1.Location = new System.Drawing.Point(281, 214);
            this.nudMesfP1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesfP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP1.Name = "nudMesfP1";
            this.nudMesfP1.Size = new System.Drawing.Size(50, 26);
            this.nudMesfP1.TabIndex = 53;
            this.nudMesfP1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesfP1.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiafP1
            // 
            this.nudDiafP1.Location = new System.Drawing.Point(225, 214);
            this.nudDiafP1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiafP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiafP1.Name = "nudDiafP1";
            this.nudDiafP1.Size = new System.Drawing.Size(50, 26);
            this.nudDiafP1.TabIndex = 52;
            this.nudDiafP1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudAnoiP1
            // 
            this.nudAnoiP1.Location = new System.Drawing.Point(128, 214);
            this.nudAnoiP1.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.nudAnoiP1.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP1.Name = "nudAnoiP1";
            this.nudAnoiP1.Size = new System.Drawing.Size(75, 26);
            this.nudAnoiP1.TabIndex = 51;
            this.nudAnoiP1.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.nudAnoiP1.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudMesiP1
            // 
            this.nudMesiP1.Location = new System.Drawing.Point(72, 214);
            this.nudMesiP1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesiP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP1.Name = "nudMesiP1";
            this.nudMesiP1.Size = new System.Drawing.Size(50, 26);
            this.nudMesiP1.TabIndex = 50;
            this.nudMesiP1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesiP1.ValueChanged += new System.EventHandler(this.configurarDias);
            // 
            // nudDiaiP1
            // 
            this.nudDiaiP1.Location = new System.Drawing.Point(16, 214);
            this.nudDiaiP1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudDiaiP1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaiP1.Name = "nudDiaiP1";
            this.nudDiaiP1.Size = new System.Drawing.Size(50, 26);
            this.nudDiaiP1.TabIndex = 49;
            this.nudDiaiP1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Fechas de captura de calificaciones";
            // 
            // lblParcial1
            // 
            this.lblParcial1.AutoSize = true;
            this.lblParcial1.Location = new System.Drawing.Point(12, 189);
            this.lblParcial1.Name = "lblParcial1";
            this.lblParcial1.Size = new System.Drawing.Size(69, 20);
            this.lblParcial1.TabIndex = 47;
            this.lblParcial1.Text = "Parcial 1";
            // 
            // txtNombreCorto3
            // 
            this.txtNombreCorto3.Location = new System.Drawing.Point(215, 126);
            this.txtNombreCorto3.MaxLength = 16;
            this.txtNombreCorto3.Name = "txtNombreCorto3";
            this.txtNombreCorto3.Size = new System.Drawing.Size(197, 26);
            this.txtNombreCorto3.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nombre corto (3)";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(225, 378);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(187, 35);
            this.cmdCancelar.TabIndex = 44;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Location = new System.Drawing.Point(16, 378);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(187, 35);
            this.cmdModificar.TabIndex = 43;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // txtNombreCorto2
            // 
            this.txtNombreCorto2.Location = new System.Drawing.Point(12, 126);
            this.txtNombreCorto2.MaxLength = 5;
            this.txtNombreCorto2.Name = "txtNombreCorto2";
            this.txtNombreCorto2.Size = new System.Drawing.Size(197, 26);
            this.txtNombreCorto2.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Nombre corto (2)";
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Location = new System.Drawing.Point(215, 72);
            this.txtNombreCorto.MaxLength = 15;
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(197, 26);
            this.txtNombreCorto.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Nombre corto";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 72);
            this.txtNombre.MaxLength = 24;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(197, 26);
            this.txtNombre.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nuevo semestre";
            // 
            // FrmModificarSemestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 425);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudAnofP3);
            this.Controls.Add(this.nudMesfP3);
            this.Controls.Add(this.nudDiafP3);
            this.Controls.Add(this.nudAnoiP3);
            this.Controls.Add(this.nudMesiP3);
            this.Controls.Add(this.nudDiaiP3);
            this.Controls.Add(this.lblParcial3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudAnofP2);
            this.Controls.Add(this.nudMesfP2);
            this.Controls.Add(this.nudDiafP2);
            this.Controls.Add(this.nudAnoiP2);
            this.Controls.Add(this.nudMesiP2);
            this.Controls.Add(this.nudDiaiP2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblParcial2);
            this.Controls.Add(this.nudAnofP1);
            this.Controls.Add(this.nudMesfP1);
            this.Controls.Add(this.nudDiafP1);
            this.Controls.Add(this.nudAnoiP1);
            this.Controls.Add(this.nudMesiP1);
            this.Controls.Add(this.nudDiaiP1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblParcial1);
            this.Controls.Add(this.txtNombreCorto3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.txtNombreCorto2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreCorto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarSemestre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar semestre - Control Escolar CBTis 123";
            this.Load += new System.EventHandler(this.FrmModificarSemestre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnofP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesfP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiafP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnoiP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesiP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaiP1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudAnofP3;
        private System.Windows.Forms.NumericUpDown nudMesfP3;
        private System.Windows.Forms.NumericUpDown nudDiafP3;
        private System.Windows.Forms.NumericUpDown nudAnoiP3;
        private System.Windows.Forms.NumericUpDown nudMesiP3;
        private System.Windows.Forms.NumericUpDown nudDiaiP3;
        private System.Windows.Forms.Label lblParcial3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudAnofP2;
        private System.Windows.Forms.NumericUpDown nudMesfP2;
        private System.Windows.Forms.NumericUpDown nudDiafP2;
        private System.Windows.Forms.NumericUpDown nudAnoiP2;
        private System.Windows.Forms.NumericUpDown nudMesiP2;
        private System.Windows.Forms.NumericUpDown nudDiaiP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblParcial2;
        private System.Windows.Forms.NumericUpDown nudAnofP1;
        private System.Windows.Forms.NumericUpDown nudMesfP1;
        private System.Windows.Forms.NumericUpDown nudDiafP1;
        private System.Windows.Forms.NumericUpDown nudAnoiP1;
        private System.Windows.Forms.NumericUpDown nudMesiP1;
        private System.Windows.Forms.NumericUpDown nudDiaiP1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblParcial1;
        private System.Windows.Forms.TextBox txtNombreCorto3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.TextBox txtNombreCorto2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreCorto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}