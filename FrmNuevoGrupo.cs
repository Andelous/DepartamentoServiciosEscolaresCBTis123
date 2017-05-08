using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmNuevoGrupo : Form
    {
        private ControladorSesion controladorSesion { get; set; }
        private ControladorGrupos controladorGrupos { get; set; }

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

        public FrmNuevoGrupo(Semestre semestreDefault)
        {
            InitializeComponent();

            this.controladorSesion = ControladorSingleton.controladorSesion;
            this.controladorGrupos = ControladorSingleton.controladorGrupos;

            this.semestreDefault = semestreDefault;
        }

        private void FrmNuevoGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = controladorGrupos.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorGrupos.seleccionarCarreras();

            semestreSeleccionado = semestreDefault;

            comboEspecialidad.SelectedIndex = 0;
            comboGrado.SelectedIndex = 0;
            comboTurno.SelectedIndex = 0;
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = controladorGrupos.registrarGrupo(
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
