using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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

        private grupos grupo { get; set; }
        private semestres semestreDefault { get; set; }

        private semestres semestreSeleccionado
        {
            set
            {
                comboSemestres.SelectedItem = value;
            }
            get
            {
                return (semestres)comboSemestres.SelectedItem;
            }
        }
        private carreras especialidadSeleccionada
        {
            set
            {
                comboEspecialidad.SelectedItem = value;
            }
            get
            {
                return (carreras)comboEspecialidad.SelectedItem;
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

        public FrmModificarGrupo(grupos grupo, semestres semestreDefault)
        {
            InitializeComponent();

            this.grupo = grupo;
            this.semestreDefault = semestreDefault;
        }

        private void FrmModificarGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = ControladorSingleton.controladorSemestres.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorGrupos.seleccionarCarrerasADO();

            semestreSeleccionado = grupo.semestres;
            especialidadSeleccionada = grupo.carreras;
            gradoSeleccionado = grupo.semestre;
            turnoSeleccionado = grupo.turnoCompleto;

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
