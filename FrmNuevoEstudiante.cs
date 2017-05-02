using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
    public partial class FrmNuevoEstudiante : Form
    {
        private ControladorSesion controladorSesion;

        public FrmNuevoEstudiante(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
        }

        private void FrmNuevoEstudiante_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            /*
            if (txtNombres.Text != "" &&
                txtApellidoMaterno.Text != "" &&
                txtApellidoPaterno.Text != "" &&
                txtNumeroDeControl.Text != "" &&
                txtCurp.Text != "")
            {
                string nombres = txtNombres.Text.ToUpper().Trim();
                string apellidoPaterno = txtApellidoPaterno.Text.ToUpper().Trim();
                string apellidoMaterno = txtApellidoMaterno.Text.ToUpper().Trim();

                string nombreCompleto = 
                    nombres + " " +
                    apellidoPaterno + " " +
                    apellidoMaterno;

                if (
                    controladorSesion.
                    daoEstudiantes.
                    insertarEstudiante(
                        txtNumeroDeControl.Text,
                        txtCurp.Text,
                        nombreCompleto,
                        nombres,
                        apellidoPaterno,
                        apellidoMaterno,
                        ""
                    ) == 1
                    )
                {
                    MessageBox.Show("Estudiante registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error al registrar el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }
    }
}
