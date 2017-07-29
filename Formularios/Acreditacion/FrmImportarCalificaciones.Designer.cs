namespace DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion
{
    partial class FrmImportarCalificaciones
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
            this.cmdImportar = new System.Windows.Forms.Button();
            this.webSiseems = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // cmdImportar
            // 
            this.cmdImportar.Location = new System.Drawing.Point(837, 516);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(146, 33);
            this.cmdImportar.TabIndex = 0;
            this.cmdImportar.Text = "Importar";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // webSiseems
            // 
            this.webSiseems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSiseems.Location = new System.Drawing.Point(0, 0);
            this.webSiseems.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSiseems.Name = "webSiseems";
            this.webSiseems.Size = new System.Drawing.Size(1008, 561);
            this.webSiseems.TabIndex = 1;
            this.webSiseems.Url = new System.Uri("http://www.siseems.sems.gob.mx/produccion/", System.UriKind.Absolute);
            // 
            // FrmImportarCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.webSiseems);
            this.Name = "FrmImportarCalificaciones";
            this.Text = "FrmImportarCalificaciones";
            this.Load += new System.EventHandler(this.FrmImportarCalificaciones_Load);
            this.Resize += new System.EventHandler(this.FrmImportarCalificaciones_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.WebBrowser webSiseems;
    }
}