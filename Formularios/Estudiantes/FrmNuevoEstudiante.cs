using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using ResultadosOperacion;
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
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }
        private ControladorEstudiantes controladorEstudiantes
        {
            get
            {
                return ControladorSingleton.controladorEstudiantes;
            }
        }

        public FrmNuevoEstudiante()
        {
            InitializeComponent();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion =
                controladorEstudiantes.
                registrarEstudiante(
                    txtNombres.Text,
                    txtApellidoPaterno.Text,
                    txtApellidoMaterno.Text,
                    txtCurp.Text,
                    txtNumeroDeControl.Text,
                    "");

            ControladorVisual.mostrarMensaje(resultadoOperacion);

            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
        }
    }
}
