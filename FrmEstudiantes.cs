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
        public FrmEstudiantes()
        {
            InitializeComponent();

            this.controladorSesion = ControladorSingleton.controladorSesion;
            this.controladorEstudiantes = ControladorSingleton.controladorEstudiantes;

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
                //comboGrupos.Text = "Ninguno.";
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
            // Se decide si el evento proviene del combo, además de comprobar
            // si el combo tiene grupos...
            if (sender.Equals(comboGrupos) && comboGrupos.Enabled)
            {
                configurarDGVEstudiantes(controladorEstudiantes.seleccionarEstudiantesPorGrupo(grupoSeleccionado));
            }
            // Si el evento proviene del combo, sabemos que no tiene grupos,
            // Ya que hubiera entrado en el apartado anterior.
            else if (sender.Equals(comboGrupos))
            {
                configurarDGVEstudiantes(controladorEstudiantes.seleccionarEstudiantes());
            }
            // Si proviene de otro control, sabemos
            // que fue click de búsqueda o enter en 
            // el txtBusqueda
            else
            {
                configurarDGVEstudiantes(
                    controladorEstudiantes.
                    seleccionarEstudiantesParametros(
                        txtBusqueda.Text,
                        chkNombreCompleto.Checked,
                        chkNombres.Checked,
                        chkApellidoPaterno.Checked,
                        chkApellidoMaterno.Checked,
                        chkCurp.Checked,
                        chkNss.Checked,
                        chkNcontrol.Checked,
                        grupoSeleccionado));

                lblAdvertencia.Visible = false;
            }
        }

        // Métodos de evento de controles
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mostrarEstudiantes(sender, e);
            }
        }

        private void cmdNuevoEstudiante_Click(object sender, EventArgs e)
        {
            new FrmNuevoEstudiante(controladorSesion).ShowDialog();
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
            new FrmModificarEstudiante(controladorSesion, estudianteSeleccionado).ShowDialog();
            mostrarEstudiantes(sender, e);
        }

        private void cambioDeCriterio(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = true;

            if (
                chkApellidoMaterno.Checked || 
                chkApellidoPaterno.Checked || 
                chkCurp.Checked ||
                chkNcontrol.Checked ||
                chkNombres.Checked ||
                chkNss.Checked)
            {
                chkNombreCompleto.Enabled = true;
            }
            else
            {
                chkNombreCompleto.Enabled = false;
                chkNombreCompleto.Checked = true;
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
            dgvEstudiantes.Columns["nss"].HeaderText = "NSS";
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
    }
}
