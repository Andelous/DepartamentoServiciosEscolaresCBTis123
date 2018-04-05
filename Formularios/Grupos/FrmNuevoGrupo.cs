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
    public partial class FrmNuevoGrupo : Form
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

        private Button[] cmdCarreras
        {
            get
            {
                return new Button[] { cmdActivas, cmdEnLiquidacion, cmdLiquidadas };
            }
        }

        public FrmNuevoGrupo(semestres semestreDefault)
        {
            InitializeComponent();

            this.semestreDefault = semestreDefault;
        }

        private void FrmNuevoGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = ControladorSingleton.controladorSemestres.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorGrupos.seleccionarCarrerasADO();

            MessageBox.Show(semestreDefault.idSemestre.ToString());
            MessageBox.Show(semestreSeleccionado.idSemestre.ToString());

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

        private void carrerasCambiadas (object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            List<carreras> lista = new List<carreras>();

            switch (cmd.Name)
            {
                case "cmdActivas":
                    lista = controladorGrupos.seleccionarCarrerasADO(0);
                    cmdRegistrar.Enabled = true;
                    break;
                case "cmdEnLiquidacion":
                    lista = controladorGrupos.seleccionarCarrerasADO(1);
                    cmdRegistrar.Enabled = true;
                    break;
                case "cmdLiquidadas":
                    lista = controladorGrupos.seleccionarCarrerasADO(2);
                    cmdRegistrar.Enabled = false;
                    break;
                default:
                    break;
            }

            foreach (Button cmdC in cmdCarreras)
            {
                cmdC.Font = new Font(cmdC.Font, FontStyle.Regular);
                cmdC.ForeColor = Color.Black;
            }

            cmd.Font = new Font(cmd.Font, FontStyle.Bold);
            cmd.ForeColor = Color.DarkBlue;

            comboEspecialidad.DataSource = lista;
        }
    }
}
