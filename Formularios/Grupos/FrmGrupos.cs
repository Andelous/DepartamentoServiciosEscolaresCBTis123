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
    public partial class FrmGrupos : Form
    {
        // Variables del formulario
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

        private semestres semestreSeleccionado
        {
            get
            {
                return (semestres)comboSemestres.SelectedItem;
            }
        }
        private grupos grupoSeleccionado
        {
            get
            {
                return (grupos)dgvGrupos.SelectedRows[0].DataBoundItem;
            }
        }

        // Métodos de iniciación
        public FrmGrupos()
        {
            InitializeComponent();
        }

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            /*List<Semestre> listaSemestres = controladorGrupos.seleccionarSemestres();
            comboSemestres.DataSource = listaSemestres;*/

            List<semestres> listaSemestres = ControladorSingleton.controladorSemestres.seleccionarSemestres();
            comboSemestres.DataSource = listaSemestres;

            comboSemestres.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);
        }

        // Métodos lógicos
        private void mostrarGrupos(object sender, EventArgs e)
        {
            /*List<Grupo> listaGrupos = controladorGrupos.seleccionarGrupos(semestreSeleccionado);
            configurarDGVGrupos(listaGrupos);*/

            List<grupos> listaGrupos = controladorGrupos.seleccionarGrupos(semestreSeleccionado);
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
            //new FrmImportarEstudiantes(grupoSeleccionado).ShowDialog();
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

        private void configurarDGVGrupos(List<grupos> listaGrupos)
        {
            dgvGrupos.DataSource = listaGrupos;

            foreach (DataGridViewColumn columna in dgvGrupos.Columns)
            {
                columna.Visible = false;
            }

            dgvGrupos.Columns["nombreCompleto"].Visible = true;
            dgvGrupos.Columns["semestre"].Visible = true;
            dgvGrupos.Columns["letra"].Visible = true;
            dgvGrupos.Columns["turnoCompleto"].Visible = true;
            dgvGrupos.Columns["carreras"].Visible = true;

            dgvGrupos.Columns["nombreCompleto"].HeaderText = "Nombre completo";
            dgvGrupos.Columns["semestre"].HeaderText = "Grado";
            dgvGrupos.Columns["letra"].HeaderText = "Letra";
            dgvGrupos.Columns["turnoCompleto"].HeaderText = "Turno";
            dgvGrupos.Columns["carreras"].HeaderText = "Especialidad";

            dgvGrupos.Columns["nombreCompleto"].Width = 140;
            dgvGrupos.Columns["semestre"].Width = 40;
            dgvGrupos.Columns["letra"].Width = 40;

            int pos = 1;

            dgvGrupos.Columns["nombreCompleto"].DisplayIndex = pos++;
            dgvGrupos.Columns["semestre"].DisplayIndex = pos++;
            dgvGrupos.Columns["letra"].DisplayIndex = pos++;
            dgvGrupos.Columns["turnoCompleto"].DisplayIndex = pos++;
            dgvGrupos.Columns["carreras"].DisplayIndex = pos++;

            lblGrupos.Text = "Grupos (" + listaGrupos.Count + " resultados)";

            if (dgvGrupos.SelectedRows.Count < 1)
            {
                cmdEditarGrupo.Enabled = false;
                cmdEliminarGrupo.Enabled = false;
                cmdAsignarDocentes.Enabled = false;
                cmdImportarEstudiantes.Enabled = false;
            }
            else
            {
                cmdEditarGrupo.Enabled = true;
                cmdEliminarGrupo.Enabled = true;
                cmdAsignarDocentes.Enabled = true;
                cmdImportarEstudiantes.Enabled = true;
            }
        }
    }
}