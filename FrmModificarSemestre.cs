using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
    public partial class FrmModificarSemestre : Form
    {
        private ControladorSesion controladorSesion { get; set; }
        private ControladorSemestres controladorSemestres { get; set; }
        private Semestre semestre { get; set; }

        public FrmModificarSemestre(ControladorSesion controladorSesion, ControladorSemestres controladorSemestres, Semestre semestre)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.controladorSemestres = controladorSemestres;
            this.semestre = semestre;
        }

        private void FrmModificarSemestre_Load(object sender, EventArgs e)
        {
            txtNombre.Text = semestre.nombre;
            txtNombreCorto.Text = semestre.nombreCorto;
            txtNombreCorto2.Text = semestre.nombreCorto2;
            txtNombreCorto3.Text = semestre.nombreCorto3;
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = 
                controladorSemestres.
                modificarSemestre(
                    semestre.idSemestre,
                    txtNombre.Text,
                    txtNombreCorto.Text,
                    txtNombreCorto2.Text,
                    txtNombreCorto3.Text
                );

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
