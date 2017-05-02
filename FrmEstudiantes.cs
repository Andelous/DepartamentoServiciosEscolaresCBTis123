using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmEstudiantes : Form
    {
        // Propiedades
        // Controladores
        private ControladorSesion controladorSesion { get; set; }
        private ControladorEstudiantes controladorEstudiantes { get; set; }

        // Lógicas
        private bool ultimoCambioBusqueda { get; set; }

        private Estudiante estudianteSeleccionado
        {
            get
            {
                return (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;
            }
        }
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
                return (Grupo)comboGrupos.SelectedItem;
            }
        }

        // Métodos de inicialización
        public FrmEstudiantes(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.controladorEstudiantes = new ControladorEstudiantes();

            ultimoCambioBusqueda = false;
        }

        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = 
                controladorEstudiantes.
                seleccionarSemestres();
        }


        // Funciones lógicas
        private void mostrarGrupos(object sender, EventArgs e)
        {
            if (comboSemestres.Text.Contains("Todos"))
            {
                comboGrupos.Enabled = false;
                comboGrupos.DataSource = null;
                comboGrupos.Text = comboSemestres.Text;
            }
            else
            {
                comboGrupos.Enabled = true;
                comboGrupos.DataSource =
                    controladorEstudiantes.
                    seleccionarGrupos(semestreSeleccionado);
            }
        }

        private void mostrarEstudiantes(object sender, EventArgs e)
        {
            
        }

        // Métodos de evento de controles
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            mostrarEstudiantes(sender, e);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdBuscar_Click(sender, e);
            }
        }


        // Métodos visuales
        private void configurarDGVEstudiantes(List<Estudiante> listaEstudiantes)
        {
            lblEstudiantes.Text = "Estudiantes - (" + listaEstudiantes.Count + " resultados)";
            dgvEstudiantes.DataSource = listaEstudiantes;

            dgvEstudiantes.Columns["idEstudiante"].Visible = false;
            dgvEstudiantes.Columns["ncontrol"].HeaderText = "No. de control";
            dgvEstudiantes.Columns["curp"].HeaderText = "CURP";
            dgvEstudiantes.Columns["nombrecompleto"].Visible = false;
            dgvEstudiantes.Columns["nombres"].HeaderText = "Nombre(s)";
            dgvEstudiantes.Columns["apellido1"].HeaderText = "Apellido p.";
            dgvEstudiantes.Columns["apellido2"].HeaderText = "Apellido m.";
        }

        private void FrmEstudiantes_Resize(object sender, EventArgs e)
        {
            Point pLblSemestre = new Point(
                Width - 400,
                lblSemestre.Location.Y
            );
            lblSemestre.Location = pLblSemestre;

            Point pLblGrupo = new Point(
                Width - 377,
                lblGrupo.Location.Y
            );
            lblGrupo.Location = pLblGrupo;

            Point pComboSemestres = new Point(
                Width - 312,
                comboSemestres.Location.Y
            );
            comboSemestres.Location = pComboSemestres;

            Point pComboGrupos = new Point(
                Width - 312,
                comboGrupos.Location.Y
            );
            comboGrupos.Location = pComboGrupos;

            dgvEstudiantes.Width = Width - 40;
            dgvEstudiantes.Height = Height - 310;

            Point pCmdNuevoEstudiante = new Point(
                Width - 196,
                cmdNuevoEstudiante.Location.Y
            );
            cmdNuevoEstudiante.Location = pCmdNuevoEstudiante;

            Point pCmdEditarEstudiante = new Point(
                cmdEditarEstudiante.Location.X,
                Height - 85
            );
            cmdEditarEstudiante.Location = pCmdEditarEstudiante;

            Point pCmdEliminarEstudiante = new Point(
                Width - 196,
                Height - 85
            );
            cmdEliminarEstudiante.Location = pCmdEliminarEstudiante;
        }

        private void cmdNuevoEstudiante_Click(object sender, EventArgs e)
        {
            (new FrmNuevoEstudiante(controladorSesion)).ShowDialog();
            mostrarEstudiantes(sender, e);
        }

        private void cmdEliminarEstudiante_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el estudiante " +
                    dgvEstudiantes.SelectedRows[0].Cells["nombrecompleto"].Value.ToString() +
                    "?",
                    "Aviso",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) == DialogResult.OK
                )
            {
                // LISTA GRUPOS A LOS QUE PERTENECE

                if (// FALTA CONDICIÓN DE LOS GRUPOS A LOS QUE PERTENECE
                    controladorSesion.
                    daoEstudiantes.
                    eliminarEstudiante(estudianteSeleccionado) == 1)
                {
                    MessageBox.Show("Estudiante eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdEditarEstudiante_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante();

            DataGridViewCellCollection cells = dgvEstudiantes.SelectedRows[0].Cells;

            estudiante.idEstudiante = Convert.ToInt32(cells["idEstudiante"].Value);
            estudiante.apellido1 = cells["apellido1"].Value.ToString();
            estudiante.apellido2 = cells["apellido2"].Value.ToString();
            estudiante.curp = cells["curp"].Value.ToString();
            estudiante.ncontrol = cells["ncontrol"].Value.ToString();
            estudiante.nombreCompleto = cells["nombrecompleto"].Value.ToString();
            estudiante.nombres = cells["nombres"].Value.ToString();

            (new FrmModificarEstudiante(controladorSesion, estudiante)).ShowDialog();
        }

        private void cambioDeCriterio(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = true;
        }
    }
}
