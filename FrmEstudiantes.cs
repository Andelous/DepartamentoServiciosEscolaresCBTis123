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
    public partial class FrmEstudiantes : Form
    {
        // Propiedades
        // Controladores
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }
        private ControladorEstudiantes controladorEstudiantes
        {
            get
            {
                return ControladorSingleton.controladorEstudiantes;
            }
        }

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
                List<Grupo> listaGrupos = 
                    controladorEstudiantes.
                    seleccionarGrupos(semestreSeleccionado);

                if (listaGrupos.Count > 0)
                {
                    comboGrupos.Enabled = true;
                    comboGrupos.DataSource = listaGrupos;
                }
                else
                {
                    comboSemestres.SelectedIndex = comboSemestres.Items.Count - 1;
                    MessageBox.Show("El semestre no contiene grupos. Se muestran los alumnos de todos los semestres y grupos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboGrupos.Enabled = false;

                    mostrarEstudiantes(sender, e);
                }
            }
        }

        private void mostrarEstudiantes(object sender, EventArgs e)
        {
            // Se decide si el evento proviene de los combos.
            // Si es así, significa que no fue una búsqueda.
            if (sender.Equals(comboGrupos) || sender.Equals(comboSemestres))
            {
                configurarDGVEstudiantes(
                    controladorEstudiantes.
                    seleccionarEstudiantesPorGrupo(
                        grupoSeleccionado));

                ultimoCambioBusqueda = false;
            }
            // Si proviene de otro control, sabemos
            // que fue click de búsqueda o enter en 
            // el txtBusqueda, o alguna operación de
            // inserción, modificación o eliminación.
            else
            {
                // Si fue una búsqueda, se oculta la advertencia 
                // y se pone que el último cambio fue una búsqueda.
                if (sender.Equals(txtBusqueda) || sender.Equals(cmdBuscar))
                {
                    ultimoCambioBusqueda = true;
                    lblAdvertencia.Visible = false;
                }

                // Si lo último que se hizo fue una búsqueda,
                // se repetirá la búsqueda para actualizar los registros.
                if (ultimoCambioBusqueda)
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
                }
                // Si lo último no fue una búsqueda,
                // se actualiza a la lista de grupo.
                else
                {
                    configurarDGVEstudiantes(
                        controladorEstudiantes.
                        seleccionarEstudiantesPorGrupo(
                            grupoSeleccionado));
                }
            }
        }

        private void reiniciarBusqueda()
        {
            chkApellidoMaterno.Checked = false;
            chkApellidoPaterno.Checked = false;
            chkCurp.Checked = false;
            chkNcontrol.Checked = false;
            chkNombres.Checked = false;
            chkNss.Checked = false;

            txtBusqueda.Text = "";
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
            new FrmNuevoEstudiante().ShowDialog();
            mostrarEstudiantes(sender, e);
        }

        private void cmdEliminarEstudiante_Click(object sender, EventArgs e)
        {
            DialogResult dr = 
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el estudiante " + 
                    estudianteSeleccionado.ToString() + "?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ResultadoOperacion resultadoOperacion = 
                    controladorEstudiantes.
                    eliminarEstudiante(estudianteSeleccionado);

                ControladorVisual.mostrarMensaje(resultadoOperacion);
                mostrarEstudiantes(sender, e);
            }
        }

        private void cmdEditarEstudiante_Click(object sender, EventArgs e)
        {
            new FrmModificarEstudiante(estudianteSeleccionado).ShowDialog();
            mostrarEstudiantes(sender, e);
        }

        private void cambioDeCriterio(object sender, EventArgs e)
        {
            lblAdvertencia.Visible = true;

            if (chkApellidoMaterno.Checked || 
                chkApellidoPaterno.Checked || 
                chkCurp.Checked ||
                chkNcontrol.Checked ||
                chkNombres.Checked ||
                chkNss.Checked
            ) {
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

            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                cmdEditarEstudiante.Enabled = false;
                cmdEliminarEstudiante.Enabled = false;
            }
            else
            {
                cmdEditarEstudiante.Enabled = true;
                cmdEliminarEstudiante.Enabled = true;
            }
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
