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
        private ControladorSesion controladorSesion;
        private bool ultimoCambioBusqueda;

        public FrmEstudiantes(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;

            ultimoCambioBusqueda = false;
        }

        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = 
                controladorSesion.
                daoSemestres.
                seleccionarSemestres();

            comboSemestres.SelectedIndex = 0;
        }

        private void comboSemestres_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            comboGrupos.DataSource =
                controladorSesion.
                daoGrupos.
                seleccionarGruposPorSemestre(
                    ((Semestre)comboSemestres.SelectedItem).idSemestre
                );
            */
            
            //comboGrupos.SelectedIndex = 0;
        }

        private void comboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ultimoCambioBusqueda)
            {

            }
            else
            {
                configurarDGVEstudiantes(
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantesPorGrupo(
                        ((Grupo)comboGrupos.SelectedItem).idGrupo
                    )
                );
            }
        }

        private void radioTodos_CheckedChanged(object sender, EventArgs e)
        {
            configurarVentana();
            configurarBusqueda();
        }

        private void radioGrupoSemestre_CheckedChanged(object sender, EventArgs e)
        {
            configurarVentana();
            configurarBusqueda();
        }

        private void configurarVentana()
        {
            if (radioTodos.Checked)
            {
                comboGrupos.Enabled = false;
                comboSemestres.Enabled = false;
            }
            else if (radioGrupoSemestre.Checked)
            {
                comboGrupos.Enabled = true;
                comboSemestres.Enabled = true;
            }
        }

        private void configurarBusqueda()
        {
            if (ultimoCambioBusqueda)
            {
                cmdBuscar_Click(null, null);
            }
            else
            {
                if (radioTodos.Checked)
                {
                    configurarDGVEstudiantes(
                        controladorSesion.
                        daoEstudiantes.
                        seleccionarEstudiantes()
                    );
                }
                else if (radioGrupoSemestre.Checked)
                {
                    comboGrupos_SelectedIndexChanged(null, null);
                }
            }
        }

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

            configurarVentana();
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
                int idEstudiante = Convert.ToInt32(dgvEstudiantes.SelectedRows[0].Cells["idEstudiante"].Value);

                // LISTA GRUPOS A LOS QUE PERTENECE

                if (// FALTA CONDICIÓN DE LOS GRUPOS A LOS QUE PERTENECE
                    controladorSesion.
                    daoEstudiantes.
                    eliminarEstudiante(
                        idEstudiante
                    ) == 1)
                {
                    MessageBox.Show("Estudiante eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configurarVentana();
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
            configurarVentana();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (
                chkApellidoMaterno.Checked ||
                chkApellidoPaterno.Checked ||
                chkCurp.Checked ||
                chkNcontrol.Checked ||
                chkNombreCompleto.Checked ||
                chkNombres.Checked
                )
            {
                if (radioGrupoSemestre.Checked)
                {
                    configurarDGVEstudiantes(
                        controladorSesion.
                        daoEstudiantes.
                        seleccionarEstudiantesPorGrupoCondicional(
                            ((Grupo)comboGrupos.SelectedItem).idGrupo,
                            chkNcontrol.Checked,
                            chkCurp.Checked,
                            chkNombreCompleto.Checked,
                            chkNombres.Checked,
                            chkApellidoPaterno.Checked,
                            chkApellidoMaterno.Checked,
                            txtBusqueda.Text
                        )
                    );
                }
                else if (radioTodos.Checked)
                {
                    configurarDGVEstudiantes(
                        controladorSesion.
                        daoEstudiantes.
                        seleccionarEstudiantesCondicional(
                            chkNcontrol.Checked,
                            chkCurp.Checked,
                            chkNombreCompleto.Checked,
                            chkNombres.Checked,
                            chkApellidoPaterno.Checked,
                            chkApellidoMaterno.Checked,
                            txtBusqueda.Text
                        )
                    );
                }

                ultimoCambioBusqueda = true;
                lblAdvertencia.Visible = false;
            }
            else
            {
                MessageBox.Show(
                    "Seleccione por lo menos un campo de búsqueda.", 
                    "Aviso", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdBuscar_Click(sender, e);
            }
        }

        private void cambioDeCriterio(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = true;
        }
    }
}
