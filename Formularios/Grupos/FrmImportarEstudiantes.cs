using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmImportarEstudiantes : Form
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

        private List<Estudiante> estudiantesSeleccionados
        {
            get
            {
                List<Estudiante> listaEstudiantes = new List<Estudiante>();

                foreach (DataGridViewRow r in dgvEstudiantes.SelectedRows)
                {
                    listaEstudiantes.Add((Estudiante)r.DataBoundItem);
                }

                return listaEstudiantes;
            }
        }
        private List<Estudiante> estudiantesActualesSeleccionados
        {
            get
            {
                List<Estudiante> listaEstudiantes = new List<Estudiante>();

                foreach (DataGridViewRow r in dgvEstudiantesActuales.SelectedRows)
                {
                    listaEstudiantes.Add((Estudiante)r.DataBoundItem);
                }

                return listaEstudiantes;
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

        private Grupo grupo { get; set; }

        private IList<Estudiante> listaEstudiantesActuales { get; set; }


        // Métodos de inicialización
        public FrmImportarEstudiantes(Grupo grupo)
        {
            InitializeComponent();

            this.grupo = grupo;

            ultimoCambioBusqueda = false;
        }

        private void FrmImportarEstudiantes_Load(object sender, EventArgs e)
        {
            List<Semestre> listaSemestres = controladorEstudiantes.seleccionarSemestres();
            comboSemestres.DataSource = listaSemestres;

            comboSemestres.SelectedItem = grupo.semestreObj;

            comboSemestres.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);
            comboGrupos.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);

            txtEspecialidad.Text = grupo.especialidadObj.ToString();
            txtGrado.Text = grupo.semestre.ToString() + "° Semestre";
            txtSemestre.Text = grupo.semestreObj.ToString();

            listaEstudiantesActuales = controladorEstudiantes.seleccionarEstudiantesPorGrupo(grupo).OrderBy(est => est.ToString()).ToList();
            configurarDGVEstudiantesActuales(listaEstudiantesActuales);
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

        // Métodos de eventos
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mostrarEstudiantes(sender, e);
            }
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
            )
            {
                chkNombreCompleto.Enabled = true;
            }
            else
            {
                chkNombreCompleto.Enabled = false;
                chkNombreCompleto.Checked = true;
            }
        }

        private void cmdAgregarSeleccion_Click(object sender, EventArgs e)
        {
            foreach (Estudiante est in estudiantesSeleccionados)
            {
                if (listaEstudiantesActuales.FirstOrDefault(est1 => est1.idEstudiante == est.idEstudiante) == null)
                {
                    listaEstudiantesActuales.Add(est);
                }
            }

            listaEstudiantesActuales = listaEstudiantesActuales.OrderBy(est => est.ToString()).ToList();
            configurarDGVEstudiantesActuales(listaEstudiantesActuales);
        }

        private void cmdAgregarTodos_Click(object sender, EventArgs e)
        {
            IList<Estudiante> estudiantesDataSource = (List<Estudiante>)dgvEstudiantes.DataSource;
            foreach (Estudiante est in estudiantesDataSource)
            {
                if (listaEstudiantesActuales.FirstOrDefault(est1 => est1.idEstudiante == est.idEstudiante) == null)
                {
                    listaEstudiantesActuales.Add(est);
                }
            }

            listaEstudiantesActuales = listaEstudiantesActuales.OrderBy(est => est.ToString()).ToList();
            configurarDGVEstudiantesActuales(listaEstudiantesActuales);
        }

        private void cmdEliminarSeleccion_Click(object sender, EventArgs e)
        {
            foreach (Estudiante est in estudiantesActualesSeleccionados)
            {
                Estudiante estAux = listaEstudiantesActuales.FirstOrDefault(est1 => est1.idEstudiante == est.idEstudiante);
                listaEstudiantesActuales.Remove(estAux);
            }

            listaEstudiantesActuales = listaEstudiantesActuales.OrderBy(est => est.ToString()).ToList();
            configurarDGVEstudiantesActuales(listaEstudiantesActuales);
        }

        // Métodos visuales
        private void configurarDGVEstudiantes(IList<Estudiante> listaEstudiantes)
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
                cmdAgregarSeleccion.Enabled = false;
                cmdAgregarTodos.Enabled = false;
            }
            else
            {
                cmdAgregarSeleccion.Enabled = true;
                cmdAgregarTodos.Enabled = true;
            }
        }

        private void configurarDGVEstudiantesActuales(IList<Estudiante> listaEstudiantes)
        {
            dgvEstudiantesActuales.DataSource = listaEstudiantes;

            dgvEstudiantesActuales.Columns["idEstudiante"].Visible = false;
            dgvEstudiantesActuales.Columns["ncontrol"].HeaderText = "No. de control";
            dgvEstudiantesActuales.Columns["curp"].HeaderText = "CURP";
            dgvEstudiantesActuales.Columns["nss"].HeaderText = "NSS";
            dgvEstudiantesActuales.Columns["nombrecompleto"].Visible = false;
            dgvEstudiantesActuales.Columns["nombres"].HeaderText = "Nombre(s)";
            dgvEstudiantesActuales.Columns["apellido1"].HeaderText = "Apellido p.";
            dgvEstudiantesActuales.Columns["apellido2"].HeaderText = "Apellido m.";

            if (dgvEstudiantesActuales.SelectedRows.Count == 0)
            {
                cmdEliminarSeleccion.Enabled = false;
            }
            else
            {
                cmdEliminarSeleccion.Enabled = true;
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = 
                ControladorGrupos_Estudiantes.
                actualizarGrupos_Estudiantes(
                    listaEstudiantesActuales,
                    grupo);

            ControladorVisual.mostrarMensaje(resultadoOperacion);
        }
    }
}
