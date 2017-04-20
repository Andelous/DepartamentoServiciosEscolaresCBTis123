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
                case ResultadoOperacion.Error:
                    MessageBox.Show("Error desconocido. Póngase en contacto con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ResultadoOperacion.Correcto:
                    txtUsuario.Focus();
                    txtContrasena.Text = "";

                    Hide();
                    (new FrmPrincipal(controladorSesion)).Show();
                    break;
                case ResultadoOperacion.ErrorAplicacion:
                    MessageBox.Show("Error de la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ResultadoOperacion.ErrorConexionServidor:
                    MessageBox.Show("Error al intentar conectar al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ResultadoOperacion.ErrorDatosIncorrectos:
                    MessageBox.Show("Usuario y/o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case ResultadoOperacion.ErrorSintaxisSQL:
                    MessageBox.Show("Error de SQL. Póngase en contacto con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
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
