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
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            if (ControladorMiscelaneo.validarVersion() == true)
            {
                ResultadoOperacion inicioDeSesion = controladorSesion.iniciarSesion(txtUsuario.Text, txtContrasena.Text);

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
            controladorSesion.cerrarSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmPruebas().Show();
        }

        private void cmdOpciones_Click(object sender, EventArgs e)
        {
            new FrmOpciones().Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //ControladorMiscelaneo.validarVersion();
        }
    }
}
