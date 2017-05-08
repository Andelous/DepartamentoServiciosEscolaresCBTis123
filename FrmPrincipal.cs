using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoServiciosEscolaresCBTis123
{
    public partial class FrmPrincipal : Form
    {
        private ControladorSesion controladorSesion { get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();

            this.controladorSesion = ControladorSingleton.controladorSesion;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = controladorSesion.usuarioActivo.ToString();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FrmLogin)Application.OpenForms["FrmLogin"]).Show();
        }

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
            ((FrmLogin)Application.OpenForms["FrmLogin"]).Show();
        }

        private void cmdSemestres_Click(object sender, EventArgs e)
        {
            (new FrmSemestres(controladorSesion)).ShowDialog();
        }

        private void cmdGrupos_Click(object sender, EventArgs e)
        {
            (new FrmGrupos()).ShowDialog();
        }

        private void cmdEstudiantes_Click(object sender, EventArgs e)
        {
            new FrmEstudiantes().ShowDialog();
        }

        private void cmdDocentes_Click(object sender, EventArgs e)
        {
            (new FrmDocentes(controladorSesion)).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmPruebas().Show();
        }
    }
}
