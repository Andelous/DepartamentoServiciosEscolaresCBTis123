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
    public partial class FrmModificarGrupo : Form
    {
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }
        private ControladorGrupos controladorGrupos
        {
            get
            {
                return ControladorSingleton.controladorGrupos;
            }
        }

        private Grupo grupo { get; set; }
        private Semestre semestreDefault { get; set; }

        private Semestre semestreSeleccionado
        {
            set
            {
                comboSemestres.SelectedItem = value;
            }
            get
            {
                return (Semestre)comboSemestres.SelectedItem;
            }
        }
        private Carrera especialidadSeleccionada
        {
            set
            {
                comboEspecialidad.SelectedItem = value;
            }
            get
            {
                return (Carrera)comboEspecialidad.SelectedItem;
            }
        }
        private int gradoSeleccionado
        {
            set
            {
                comboGrado.SelectedIndex = value - 1;
            }
            get
            {
                return comboGrado.SelectedIndex + 1;
            }
        }
        private string turnoSeleccionado
        {
            set
            {
                comboTurno.SelectedItem = value;
            }
            get
            {
                return comboTurno.SelectedItem.ToString();
            }
        }

        public FrmModificarGrupo(Grupo grupo, Semestre semestreDefault)
        {
            InitializeComponent();

            this.grupo = grupo;
            this.semestreDefault = semestreDefault;
        }

        private void FrmModificarGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = controladorGrupos.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorGrupos.seleccionarCarreras();

            semestreSeleccionado = grupo.semestreObj;
            especialidadSeleccionada = grupo.especialidadObj;
            gradoSeleccionado = grupo.semestre;
            turnoSeleccionado = grupo.turno;

            txtLetra.Text = grupo.letra;
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = controladorGrupos.modificarGrupo(
                grupo.idGrupo,
                semestreSeleccionado.idSemestre,
                gradoSeleccionado,
                txtLetra.Text,
                turnoSeleccionado,
                especialidadSeleccionada.abreviatura,
                semestreSeleccionado,
                especialidadSeleccionada);

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
