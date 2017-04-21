using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
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
            ResultadoOperacion resultadoOperacion =
                controladorSemestres.
                registrarSemestre(
                    txtNombre.Text,
                    txtNombreCorto.Text,
                    txtNombreCorto2.Text,
                    txtNombreCorto3.Text);

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
