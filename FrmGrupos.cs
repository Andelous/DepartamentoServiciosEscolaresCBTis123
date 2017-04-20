using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
        private ControladorSesion controladorSesion;

        public FrmGrupos(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
        }

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            List<Semestre> listaSemestres = controladorSesion.daoSemestres.seleccionarSemestres();

            Semestre s = new Semestre();
            s.idSemestre = -1;
            s.nombre = "Todos";
            s.nombreCorto2 = "*";

            listaSemestres.Add(s);

            comboSemestres.DataSource = listaSemestres;
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

            lblGrupos.Text = "Grupos (" + listaGrupos.Count + ")";
        }

        private void comboSemestres_SelectedIndexChanged(object sender, EventArgs e)
        {
            Semestre s = (Semestre)comboSemestres.SelectedItem;
            List<Grupo> listaGrupos = null;

            if (s.idSemestre == -1)
            {
                listaGrupos = controladorSesion.daoGrupos.seleccionarGrupos();
            }
            else
            {
                listaGrupos = controladorSesion.daoGrupos.seleccionarGruposPorSemestre(s.idSemestre);
            }

            configurarDGVGrupos(listaGrupos);
        }

        private void cmdNuevoGrupo_Click(object sender, EventArgs e)
        {
            (new FrmNuevoGrupo(controladorSesion)).ShowDialog();
            comboSemestres_SelectedIndexChanged(sender, e);
        }

        private void cmdEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (
                dgvGrupos.SelectedRows.Count > 0 &&
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el grupo " +
                    dgvGrupos.SelectedRows[0].Cells["nombreCompleto"].Value.ToString() +
                    "?",
                    "Aviso",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) == DialogResult.OK
                )
            {
                int idGrupo = Convert.ToInt32(dgvGrupos.SelectedRows[0].Cells["idGrupo"].Value);

                List<Estudiante> listaEstudiantes = 
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantesPorGrupo(
                        idGrupo
                    );

                if (listaEstudiantes.Count == 0 &&
                    controladorSesion.
                    daoGrupos.
                    eliminarGrupo(
                        idGrupo
                    ) == 1)
                {
                    MessageBox.Show("Grupo eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboSemestres_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdEditarGrupo_Click(object sender, EventArgs e)
        {
            Grupo g = new Grupo();

            DataGridViewCellCollection dgvCells = dgvGrupos.SelectedRows[0].Cells;

            g.especialidad = dgvCells["especialidad"].Value.ToString();
            g.idGrupo = Convert.ToInt32(dgvCells["idGrupo"].Value);
            g.idSemestre = Convert.ToInt32(dgvCells["idSemestre"].Value);
            g.letra = dgvCells["letra"].Value.ToString();
            g.semestre = Convert.ToInt32(dgvCells["semestre"].Value);
            g.semestreObj = new Semestre();
            g.semestreObj.idSemestre = g.idSemestre;
            g.turno = dgvCells["turno"].Value.ToString();
            g.especialidadObj = (Carrera)dgvCells["especialidadObj"].Value;

            (new FrmModificarGrupo(controladorSesion, g)).ShowDialog();

            comboSemestres_SelectedIndexChanged(sender, e);
        }

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

        private void cmdAsignarDocentes_Click(object sender, EventArgs e)
        {
            Grupo grupo = 
                DAOGrupos.
                crearGrupoDataGridViewCellCollection(
                    dgvGrupos.SelectedRows[0].Cells
                );

            (new FrmAsignacionDeDocentes(controladorSesion, grupo)).ShowDialog();
        }

        private void cmdImportarEstudiantes_Click(object sender, EventArgs e)
        {
            Grupo grupo = 
                DAOGrupos.
                crearGrupoDataGridViewCellCollection(
                    dgvGrupos.SelectedRows[0].Cells
                );

            (new FrmImportarEstudiantes(controladorSesion, grupo)).ShowDialog();
        }
    }
}