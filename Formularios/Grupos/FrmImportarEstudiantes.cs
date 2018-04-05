using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmImportarEstudiantes : Form
    {
        // Propiedades
        // Controladores
        private ControladorEstudiantes controladorEstudiantes
        {
            get
            {
                return ControladorSingleton.controladorEstudiantes;
            }
        }
        
        // Lógicas
        private bool ultimoCambioBusqueda { get; set; }

        private List<estudiantes> estudiantesSeleccionados
        {
            get
            {
                List<estudiantes> listaEstudiantes = new List<estudiantes>();

                foreach (DataGridViewRow r in dgvEstudiantes.SelectedRows)
                {
                    listaEstudiantes.Add((estudiantes)r.DataBoundItem);
                }

                return listaEstudiantes;
            }
        }
        private List<estudiantes> estudiantesActualesSeleccionados
        {
            get
            {
                List<estudiantes> listaEstudiantes = new List<estudiantes>();

                foreach (DataGridViewRow r in dgvEstudiantesActuales.SelectedRows)
                {
                    listaEstudiantes.Add((estudiantes)r.DataBoundItem);
                }

                return listaEstudiantes;
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
                return (grupos)comboGrupos.SelectedItem;
            }
        }

        private grupos grupo { get; set; }

        private List<estudiantes> listaEstudiantesActuales { get; set; }


        // Métodos de inicialización
        public FrmImportarEstudiantes(grupos grupo)
        {
            InitializeComponent();

            this.grupo = grupo;

            ultimoCambioBusqueda = false;
        }

        private void FrmImportarEstudiantes_Load(object sender, EventArgs e)
        {
            List<semestres> listaSemestres = ControladorSingleton.controladorSemestres.seleccionarSemestres();
            comboSemestres.DataSource = listaSemestres;

            comboSemestres.SelectedItem = grupo.semestres;

            comboSemestres.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);
            comboGrupos.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);

            txtEspecialidad.Text = grupo.carreras.ToString();
            txtGrado.Text = grupo.semestre.ToString() + "° Semestre \"" + grupo.letra + "\"";
            txtSemestre.Text = grupo.semestres.ToString();

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
                List<grupos> listaGrupos =
                    ControladorSingleton.
                    controladorGrupos.
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
                        seleccionarEstudiantesParametrosADO(
                            txtBusqueda.Text,
                            chkNombreCompleto.Checked,
                            chkNombres.Checked,
                            chkApellidoPaterno.Checked,
                            chkApellidoMaterno.Checked,
                            chkCurp.Checked,
                            chkNss.Checked,
                            chkNcontrol.Checked,
                            new Grupo() { idGrupo = grupoSeleccionado.idGrupo }));
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
            foreach (estudiantes est in estudiantesSeleccionados)
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
            IList<estudiantes> estudiantesDataSource = (List<estudiantes>)dgvEstudiantes.DataSource;
            foreach (estudiantes est in estudiantesDataSource)
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
            foreach (estudiantes est in estudiantesActualesSeleccionados)
            {
                estudiantes estAux = listaEstudiantesActuales.FirstOrDefault(est1 => est1.idEstudiante == est.idEstudiante);
                listaEstudiantesActuales.Remove(estAux);
            }

            listaEstudiantesActuales = listaEstudiantesActuales.OrderBy(est => est.ToString()).ToList();
            configurarDGVEstudiantesActuales(listaEstudiantesActuales);
        }

        // Métodos visuales
        private void configurarDGVEstudiantes(IList<estudiantes> listaEstudiantes)
        {
            lblEstudiantes.Text = "Estudiantes - (" + listaEstudiantes.Count + " resultados)";
            dgvEstudiantes.DataSource = listaEstudiantes;

            foreach (DataGridViewColumn col in dgvEstudiantes.Columns)
            {
                col.Visible = false;
            }

            dgvEstudiantes.Columns["ncontrol"].Visible = true;
            dgvEstudiantes.Columns["curp"].Visible = true;
            dgvEstudiantes.Columns["nss"].Visible = true;
            dgvEstudiantes.Columns["nombres"].Visible = true;
            dgvEstudiantes.Columns["apellido1"].Visible = true;
            dgvEstudiantes.Columns["apellido2"].Visible = true;

            dgvEstudiantes.Columns["ncontrol"].HeaderText = "No. de control";
            dgvEstudiantes.Columns["curp"].HeaderText = "CURP";
            dgvEstudiantes.Columns["nss"].HeaderText = "NSS";
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

        private void configurarDGVEstudiantesActuales(IList<estudiantes> listaEstudiantes)
        {
            dgvEstudiantesActuales.DataSource = listaEstudiantes;

            foreach (DataGridViewColumn col in dgvEstudiantesActuales.Columns)
            {
                col.Visible = false;
            }

            dgvEstudiantesActuales.Columns["ncontrol"].Visible = true;
            dgvEstudiantesActuales.Columns["curp"].Visible = true;
            dgvEstudiantesActuales.Columns["nss"].Visible = true;
            dgvEstudiantesActuales.Columns["nombres"].Visible = true;
            dgvEstudiantesActuales.Columns["apellido1"].Visible = true;
            dgvEstudiantesActuales.Columns["apellido2"].Visible = true;

            dgvEstudiantesActuales.Columns["ncontrol"].HeaderText = "No. de control";
            dgvEstudiantesActuales.Columns["curp"].HeaderText = "CURP";
            dgvEstudiantesActuales.Columns["nss"].HeaderText = "NSS";
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
