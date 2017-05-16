using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
    public partial class FrmModificarEstudiante : Form
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

        private Estudiante estudiante { get; set; }

        public FrmModificarEstudiante(Estudiante estudiante)
        {
            InitializeComponent();

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
            ResultadoOperacion resultadoOperacion =
                controladorEstudiantes.
                modificarEstudiante(
                    estudiante.idEstudiante,
                    txtNombres.Text,
                    txtApellidoPaterno.Text,
                    txtApellidoMaterno.Text,
                    txtCurp.Text,
                    txtNumeroDeControl.Text,
                    "Not implem");

            ControladorVisual.mostrarMensaje(resultadoOperacion);

            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
