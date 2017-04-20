using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmNuevoDocente : Form
    {
        private ControladorSesion controladorSesion;

        public FrmNuevoDocente(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" &&
                txtApellidoMaterno.Text != "" &&
                txtApellidoPaterno.Text != "" &&
                txtRfc.Text != "" &&
                txtCurp.Text != "")
            {
                string nombres = txtNombres.Text.Trim();
                string apellidoPaterno = txtApellidoPaterno.Text.Trim();
                string apellidoMaterno = txtApellidoMaterno.Text.Trim();

                Docente d = DAODocentes.crearDocente(
                    0,
                    ".",
                    0,
                    txtCurp.Text.Trim(),
                    txtRfc.Text.Trim(),
                    nombres,
                    apellidoPaterno,
                    apellidoMaterno,
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    new DateTime(2000, 01, 01),
                    "."
                );

                if (
                    controladorSesion.daoDocentes.insertarDocente(d) == 1
                    )
                {
                    MessageBox.Show("Docente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error al registrar el docente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
