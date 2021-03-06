﻿using DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion;
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
        // Métodos de inicialización
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = ControladorSesion.usuarioActivo.ToString();
        }



        // Métodos de eventos
        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((FrmLogin)Application.OpenForms["FrmLogin"]).Show();
        }

        private void cmdCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSemestres_Click(object sender, EventArgs e)
        {
            (new FrmSemestres()).ShowDialog();
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
            (new FrmDocentes()).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmPruebas().Show();
        }

        private void cmdAcreditacion_Click(object sender, EventArgs e)
        {
            new FrmAcreditacion().Show();
        }
    }
}
