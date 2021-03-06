﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoServiciosEscolaresCBTis123
{
    public partial class FrmLogin : Form
    {
        // Métodos de inicialziación
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        // Métodos de eventos
        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            if (ControladorMiscelaneo.validarVersion() == true)
            {
                ResultadoOperacion inicioDeSesion = ControladorSesion.iniciarSesion(txtUsuario.Text, txtContrasena.Text);

                switch (inicioDeSesion.estadoOperacion)
                {
                    case EstadoOperacion.Correcto:
                        txtUsuario.Focus();
                        txtContrasena.Text = "";

                        Hide();
                        new FrmPrincipal().Show();
                        break;

                    default:
                        ControladorVisual.mostrarMensaje(inicioDeSesion);
                        break;
                }
            }
        }

        private void enterTxt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdIngresar_Click(sender, e);
            }
        }

        public new void Show()
        {
            base.Show();
            ControladorSesion.cerrarSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmPruebas().Show();
        }

        private void cmdOpciones_Click(object sender, EventArgs e)
        {
            new FrmOpciones().Show();
        }
    }
}
