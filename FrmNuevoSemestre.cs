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
    public partial class FrmNuevoSemestre : Form
    {
        private ControladorSesion controladorSesion { get; set; }
        private ControladorSemestres controladorSemestres { get; set; }

        public FrmNuevoSemestre(ControladorSesion controladorSesion, ControladorSemestres controladorSemestres)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.controladorSemestres = controladorSemestres;
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && 
                txtNombreCorto.Text != "" && 
                txtNombreCorto2.Text != "")
            {
                ResultadoOperacion ro =
                    controladorSemestres.
                    registrarSemestre(
                        txtNombre.Text,
                        txtNombreCorto.Text,
                        txtNombreCorto2.Text,
                        txtNombreCorto3.Text
                    );

                if (ro.estadoOperacion == EstadoOperacion.Correcto) {
                    MessageBox.Show("Semestre registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el semestre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
