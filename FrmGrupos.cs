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
    public partial class FrmGrupos : Form
    {
        // Variables del formulario
        private ControladorSesion controladorSesion { get; set; }
        private ControladorGrupos controladorGrupos { get; set; }

        private Semestre semestreSeleccionado
        {
            get
            {
                return (Semestre)comboSemestres.SelectedItem;
            }
        }
        private Grupo grupoSeleccionado
        {
            get
            {
                return (Grupo)dgvGrupos.SelectedRows[0].DataBoundItem;
            }
        }

        // Métodos de iniciación
        public FrmGrupos()
        {
            InitializeComponent();

            this.controladorSesion = ControladorSingleton.controladorSesion;
            this.controladorGrupos = ControladorSingleton.controladorGrupos;
        }

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            List<Semestre> listaSemestres = controladorGrupos.seleccionarSemestres();
            comboSemestres.DataSource = listaSemestres;

            comboSemestres.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);
        }

        // Métodos lógicos
        private void mostrarGrupos(object sender, EventArgs e)
        {
            List<Grupo> listaGrupos = controladorGrupos.seleccionarGrupos(semestreSeleccionado);
            configurarDGVGrupos(listaGrupos);
        }

        // Eventos de los controles
        private void cmdNuevoGrupo_Click(object sender, EventArgs e)
        {
            new FrmNuevoGrupo(semestreSeleccionado).ShowDialog();
            mostrarGrupos(sender, e);
        }

        private void cmdEliminarGrupo_Click(object sender, EventArgs e)
        {
            DialogResult dr = 
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el grupo " +
                    grupoSeleccionado.ToString() + "?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ResultadoOperacion resultadoOperacion = controladorGrupos.eliminarGrupo(grupoSeleccionado);
                ControladorVisual.mostrarMensaje(resultadoOperacion);

                mostrarGrupos(sender, e);
            }
        }

        private void cmdEditarGrupo_Click(object sender, EventArgs e)
        {
            new FrmModificarGrupo(grupoSeleccionado, semestreSeleccionado).ShowDialog();
            mostrarGrupos(sender, e);
        }

        private void cmdAsignarDocentes_Click(object sender, EventArgs e)
        {
            new FrmAsignacionDeDocentes(grupoSeleccionado).ShowDialog();
        }

        private void cmdImportarEstudiantes_Click(object sender, EventArgs e)
        {
            new FrmImportarEstudiantes(grupoSeleccionado).ShowDialog();
        }

        // Métodos para controlar algo visual
        private void FrmGrupos_Resize(object sender, EventArgs e)
        {
            dgvGrupos.Width = Width - 40;
            dgvGrupos.Height = Height - 160;

            Point p1 = new Point(
                Width - 486,
                comboSemestres.Location.Y
            );
            comboSemestres.Location = p1;

            Point p2 = new Point(
                Width - 196,
                cmdNuevoGrupo.Location.Y
            );
            cmdNuevoGrupo.Location = p2;

            Point p3 = new Point(
                cmdEditarGrupo.Location.X,
                Height - 85
            );
            cmdEditarGrupo.Location = p3;

            Point p4 = new Point(
                Width - 196,
                Height - 85
            );
            cmdEliminarGrupo.Location = p4;

            Point p5 = new Point(
                cmdAsignarDocentes.Location.X,
                Height - 85
            );
            cmdAsignarDocentes.Location = p5;

            Point p6 = new Point(
                cmdImportarEstudiantes.Location.X,
                Height - 85
            );
            cmdImportarEstudiantes.Location = p6;
        }

        private void configurarDGVGrupos(List<Grupo> listaGrupos)
        {
            dgvGrupos.DataSource = listaGrupos;

            dgvGrupos.Columns["nombreCompleto"].HeaderText = "Nombre completo";
            dgvGrupos.Columns["idGrupo"].Visible = false;
            dgvGrupos.Columns["idSemestre"].Visible = false;
            dgvGrupos.Columns["semestre"].HeaderText = "Grado";
            dgvGrupos.Columns["semestre"].Width = 40;
            dgvGrupos.Columns["letra"].HeaderText = "Letra";
            dgvGrupos.Columns["letra"].Width = 40;
            dgvGrupos.Columns["turno"].HeaderText = "Turno";
            dgvGrupos.Columns["especialidad"].Visible = false;
            dgvGrupos.Columns["semestreObj"].HeaderText = "Semestre";
            dgvGrupos.Columns["semestreObj"].Visible = false;
            dgvGrupos.Columns["especialidadObj"].HeaderText = "Especialidad";

            //int diLetra = dgvGrupos.Columns["letra"].DisplayIndex;
            //int diTurno = dgvGrupos.Columns["turno"].DisplayIndex;
            //int diEspecialidad = dgvGrupos.Columns["especialidadObj"].DisplayIndex;

            //MessageBox.Show("Test " + diLetra + " " + diTurno + " " + diEspecialidad);

            dgvGrupos.Columns["turno"].DisplayIndex = 4;
            dgvGrupos.Columns["especialidadObj"].DisplayIndex = 5;
            dgvGrupos.Columns["letra"].DisplayIndex = 8;

            lblGrupos.Text = "Grupos (" + listaGrupos.Count + " resultados)";
        }
    }
}