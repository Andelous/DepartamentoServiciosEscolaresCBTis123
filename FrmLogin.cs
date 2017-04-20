﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmLogin : Form
    {
        public ControladorSesion controladorSesion { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
            controladorSesion = new ControladorSesion();
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion inicioDeSesion = controladorSesion.iniciarSesion(txtUsuario.Text, txtContrasena.Text);

            switch (inicioDeSesion)
            {
                case ResultadoOperacion.Correcto:
                    txtUsuario.Focus();
                    txtContrasena.Text = "";

                    Hide();
                    (new FrmPrincipal(controladorSesion)).Show();
                    break;

                default:
                    ControladorVisual.mostrarMensaje(inicioDeSesion);
                    break;
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdIngresar_Click(sender, e);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
