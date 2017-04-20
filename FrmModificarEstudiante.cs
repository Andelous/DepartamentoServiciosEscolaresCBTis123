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
    public partial class FrmModificarEstudiante : Form
    {
        private ControladorSesion controladorSesion;
        private Estudiante estudiante;

        public FrmModificarEstudiante(ControladorSesion controladorSesion, Estudiante estudiante)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.estudiante = estudiante;
        }

        private void FrmModificarEstudiante_Load(object sender, EventArgs e)
        {
            txtNombres.Text = estudiante.nombres;
            txtApellidoPaterno.Text = estudiante.apellido1;
            txtApellidoMaterno.Text = estudiante.apellido2;

            txtCurp.Text = estudiante.curp;
            txtNumeroDeControl.Text = estudiante.ncontrol;
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
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
                    modificarEstudiante(
                        estudiante.idEstudiante,
                        txtNumeroDeControl.Text,
                        txtCurp.Text,
                        nombreCompleto,
                        nombres,
                        apellidoPaterno,
                        apellidoMaterno
                    ) == 1
                    )
                {
                    MessageBox.Show("Estudiante modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error al modificar el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
