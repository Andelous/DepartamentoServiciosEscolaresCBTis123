using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmModificarDocente : Form
    {
        // Controladores y variables lógicas
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }
        private ControladorDocentes controladorDocentes
        {
            get
            {
                return ControladorSingleton.controladorDocentes;
            }
        }

        private Docente d;

        // Métodos de inicialización
        public FrmModificarDocente(Docente d)
        {
            InitializeComponent();

            this.d = d;
        }
        
        private void FrmModificarDocente_Load(object sender, EventArgs e)
        {
            txtNombres.Text = d.nombres;
            txtApellidoMaterno.Text = d.apellidom;
            txtApellidoPaterno.Text = d.apellidop;
            txtCurp.Text = d.curp;
            txtRfc.Text = d.rfc;
        }

        // Métodos de eventos de controles
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion =
                controladorDocentes.
                modificarDocente(
                    d.idDocente,
                    ".",
                    0,
                    txtCurp.Text.Trim(),
                    txtRfc.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtApellidoPaterno.Text.Trim(),
                    txtApellidoMaterno.Text.Trim(),
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
                    ".");

            ControladorVisual.mostrarMensaje(resultadoOperacion);

            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
        }
    }
}
