using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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

namespace DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion
{
    public partial class FrmAcreditacion : Form
    {
        // Propiedades privadas
        private semestres periodoSeleccionado
        {
            get
            {
                return (semestres)comboPeriodo.SelectedItem;
            }
        }
        private string turnoSeleccionado
        {
            get
            {
                return comboTurno.SelectedItem != null ? comboTurno.SelectedItem.ToString() : "";
            }
        }
        private int semestreSeleccionado
        {
            get
            {
                return comboSemestre.SelectedIndex + 1;
            }
        }
        private carreras carreraSeleccionada
        {
            get
            {
                return (carreras)comboCarrera.SelectedItem;
            }
        }
        private grupos grupoSeleccionado
        {
            get
            {
                return (grupos)comboGrupo.SelectedItem;
            }
        }
        private catedras asignaturaSeleccionada
        {
            get
            {
                return (catedras)comboAsignatura.SelectedItem;
            }
        }
        private calificacionessemestrales calificacionSeleccionada
        {
            get
            {
                return (calificacionessemestrales)dgvCalificaciones.Rows[dgvCalificaciones.SelectedCells[0].RowIndex].DataBoundItem;
            }
        }
        private string nombrePropiedadSeleccionada
        {
            get
            {
                return dgvCalificaciones.Columns[dgvCalificaciones.SelectedCells[0].ColumnIndex].Name;
            }
        }
        
        // Propiedad pública para uso del importador
        public List<calificacionessemestrales> calificacionesDeDGV
        {
            get
            {
                BindingList<calificacionessemestrales> calificaciones = (BindingList<calificacionessemestrales>)dgvCalificaciones.DataSource;

                int count = 0;
                foreach (DataGridViewRow row in dgvCalificaciones.Rows)
                {
                    calificacionessemestrales c = calificaciones[count];

                    object valor = row.Cells["tipoDeAcreditacion1"].Value;
                    c.tipoDeAcreditacion = valor != null ? row.Cells["tipoDeAcreditacion1"].Value.ToString() : null;

                    count++;
                }

                return calificaciones.ToList();
            }
        }












        // Métodos de inicialización
        public FrmAcreditacion()
        {
            InitializeComponent();

            comboAsignatura.MouseWheel += ControladorVisual.evitarScroll;
            comboCarrera.MouseWheel += ControladorVisual.evitarScroll;
            comboGrupo.MouseWheel += ControladorVisual.evitarScroll;
            comboPeriodo.MouseWheel += ControladorVisual.evitarScroll;
            comboSemestre.MouseWheel += ControladorVisual.evitarScroll;
            comboTurno.MouseWheel += ControladorVisual.evitarScroll;

            agregarColumnaCombos();
        }

        private void FrmAcreditacion_Load(object sender, EventArgs e)
        {
            comboCarrera.DataSource = ControladorSingleton.dbContext.carreras.Where(c => c.acuerdo == "653").ToList();
            comboPeriodo.DataSource = ControladorSingleton.dbContext.semestres.ToList().OrderByDescending(s => s.idSemestre).ToList();
        }
















        // Métodos de evento
        public void cargarGrupos(object sender, EventArgs e)
        {
            semestres periodo = periodoSeleccionado;
            string turno = turnoSeleccionado;
            int semestre = semestreSeleccionado;
            carreras carrera = carreraSeleccionada;

            if (
                periodo != null &&
                turno != "" &&
                semestre > 0 &&
                carrera != null
            ) {
                List<grupos> listaGrupos = 
                    ControladorAcreditacion.
                    seleccionarGrupos(
                        periodo,
                        turno,
                        semestre,
                        carrera);

                comboGrupo.DataSource = listaGrupos;

                if (listaGrupos.Count < 1)
                {
                    comboGrupo.DataSource = null;
                    comboAsignatura.DataSource = null;
                    configurarDGVCalificaciones(null);
                }
            }
            else
            {
                comboGrupo.DataSource = null;
                comboAsignatura.DataSource = null;
                configurarDGVCalificaciones(null);
            }
        }

        public void cargarCatedras(object sender, EventArgs e)
        {
            grupos grupo = grupoSeleccionado;

            if (grupo != null)
            {
                List<catedras> listaCatedras = ControladorAcreditacion.seleccionarCatedras(grupo);

                comboAsignatura.DataSource = listaCatedras;
            }
            else
            {
                comboAsignatura.DataSource = null;
                configurarDGVCalificaciones(null);
            }
        }

        public void cargarAlumnos(object sender, EventArgs e)
        {
            catedras asignatura = asignaturaSeleccionada;
            if (asignatura != null)
            {
                List<calificacionessemestrales> listaCalificaciones = ControladorAcreditacion.seleccionarCalificaciones(asignatura);
                BindingList<calificacionessemestrales> listaCalificacionesBinding = new BindingList<calificacionessemestrales>(listaCalificaciones);
            
                configurarDGVCalificaciones(listaCalificacionesBinding);
            }
            else
            {
                configurarDGVCalificaciones(null);
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            List<calificacionessemestrales> calif = calificacionesDeDGV;

            /*
             * 
             * Código únicamente para pruebas
             * 
             */

            //foreach (calificaciones c in calif)
            //{
            //    DialogResult dr = MessageBox.Show(
            //        "P1 - " + c.calificacionParcial1 + "\n" +
            //        "A1 - " + c.asistenciasParcial1 + "\n" +
            //        "TA - " + c.tipoDeAcreditacion + "\n" +
            //        "Re - " + c.recursamiento.ToString() + "\n",

            //        "Hola desde guardar",
            //        MessageBoxButtons.OKCancel);

            //    if (dr == DialogResult.Cancel)
            //    {
            //        break;
            //    }
            //}

            /*
             * 
             * Termina código únicamente para pruebas
             * 
             */

            ResultadoOperacion resultadoOperacion = ControladorAcreditacion.actualizarCalificaciones(calif);
            ControladorVisual.mostrarMensaje(resultadoOperacion);
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            new FrmImportarCalificaciones(asignaturaSeleccionada).ShowDialog();
            cargarAlumnos(sender, e);
        }

        private void cmdReestablecer_Click(object sender, EventArgs e)
        {
            // Solución sencilla
            //dgvCalificaciones.SelectedCells[0].Value = null;

            // Solución específica
            switch (nombrePropiedadSeleccionada)
            {
                case "calificacionParcial1":
                    calificacionSeleccionada.calificacionParcial1 = null;
                    break;
                case "calificacionParcial2":
                    calificacionSeleccionada.calificacionParcial2 = null;
                    break;
                case "calificacionParcial3":
                    calificacionSeleccionada.calificacionParcial3 = null;
                    break;
                case "asistenciasParcial1":
                    calificacionSeleccionada.asistenciasParcial1 = null;
                    break;
                case "asistenciasParcial2":
                    calificacionSeleccionada.asistenciasParcial2 = null;
                    break;
                case "asistenciasParcial3":
                    calificacionSeleccionada.asistenciasParcial3 = null;
                    break;
                case "tipoDeAcreditacion1":
                    calificacionSeleccionada.tipoDeAcreditacion = null;
                    dgvCalificaciones.SelectedCells[0].Value = null;
                    break;
                default:
                    MessageBox.Show("No se puede reestablecer el valor de esta propiedad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void dgvCalificaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvCalificaciones.Invalidate();
        }



















        // Métodos visuales
        private void configurarDGVCalificaciones(BindingList<calificacionessemestrales> listaCalificacionesBinding)
        {
            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificaciones.DataSource = null;
                dgvCalificaciones.Columns["tipoDeAcreditacion1"].Visible = false;

                cmdGuardar.Enabled = false;
                cmdImportar.Enabled = false;
                cmdReestablecer.Enabled = false;

                return;
            }

            // Ordenamos la binding list...
            listaCalificacionesBinding = new BindingList<calificacionessemestrales>(
                listaCalificacionesBinding.
                OrderBy(
                    c => 
                    c.estudiantes.apellido1 + 
                    c.estudiantes.apellido2 + 
                    c.estudiantes.nombres).
                ToList()
            );

            // Agregamos todos los datos al dgv
            dgvCalificaciones.DataSource = listaCalificacionesBinding;

            // Ahora, obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificaciones.Columns;





            /*
             * 
             * Código únicamente para pruebas
             * 
             */

            //StringBuilder nombres = new StringBuilder("");
            //int count = 0;
            //foreach (DataGridViewColumn col in dgvCalificaciones.Columns)
            //{
            //    nombres.AppendLine(count + " - " + col.Name);
            //    count++;
            //}

            //MessageBox.Show(nombres.ToString());

            /*
             * 
             * Termina código únicamente para pruebas
             * 
             */





            // Iteramos sobre todas las columnas para hacerlas invisibles
            foreach (DataGridViewColumn c in columnas)
            {
                c.Visible = false;
            }

            // Itero sobre las filas para agregar algunas cosas
            int i = 0;
            foreach (DataGridViewRow row in dgvCalificaciones.Rows)
            {
                // Primero, el número de lista
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

                // Segundo, el color de fondo para mostrar a los de recursamiento
                if (((calificacionessemestrales)row.DataBoundItem).recursamiento)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // Tercero, seleccionamos el tipo de acreditación
                // A NP NA RV R
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells["tipoDeAcreditacion1"];
                cell.Value = listaCalificacionesBinding[i].tipoDeAcreditacion;
                i++;
            }

            // Muestro únicamente las que me interesan
            columnas["nControl"].Visible = true;
            columnas["calificacionParcial1"].Visible = true;
            columnas["calificacionParcial2"].Visible = true;
            columnas["calificacionParcial3"].Visible = true;
            columnas["asistenciasParcial1"].Visible = true;
            columnas["asistenciasParcial2"].Visible = true;
            columnas["asistenciasParcial3"].Visible = true;
            columnas["tipoDeAcreditacion"].Visible = false;
            columnas["tipoDeAcreditacion1"].Visible = true;
            columnas["recursamiento"].Visible = true;
            columnas["firmado"].Visible = true;
            columnas["estudiantes"].Visible = true;
            columnas["promedio"].Visible = true;
            columnas["asistenciasTotales"].Visible = true;

            // Cambio el título
            columnas["nControl"].HeaderText = "Núm. control";
            columnas["calificacionParcial1"].HeaderText = "Cal. P1";
            columnas["calificacionParcial2"].HeaderText = "Cal. P2";
            columnas["calificacionParcial3"].HeaderText = "Cal. P3";
            columnas["asistenciasParcial1"].HeaderText = "Asis. P1";
            columnas["asistenciasParcial2"].HeaderText = "Asis. P2";
            columnas["asistenciasParcial3"].HeaderText = "Asis. P3";
            columnas["tipoDeAcreditacion"].HeaderText = "Tipo de Acreditación";
            columnas["tipoDeAcreditacion1"].HeaderText = "Tipo de Acreditación (Combo)";
            columnas["recursamiento"].HeaderText = "Recursamiento";
            columnas["firmado"].HeaderText = "Firmado";
            columnas["estudiantes"].HeaderText = "Estudiante";
            columnas["promedio"].HeaderText = "Promedio";
            columnas["asistenciasTotales"].HeaderText = "Asistencias totales";

            // Las muestro en un orden particular
            columnas["nControl"].DisplayIndex = 0;
            columnas["estudiantes"].DisplayIndex = 1;
            columnas["calificacionParcial1"].DisplayIndex = 2;
            columnas["calificacionParcial2"].DisplayIndex = 3;
            columnas["calificacionParcial3"].DisplayIndex = 4;
            columnas["asistenciasParcial1"].DisplayIndex = 5;
            columnas["asistenciasParcial2"].DisplayIndex = 6;
            columnas["asistenciasParcial3"].DisplayIndex = 7;
            columnas["promedio"].DisplayIndex = 8;
            columnas["asistenciasTotales"].DisplayIndex = 9;
            columnas["tipoDeAcreditacion"].DisplayIndex = 10;
            columnas["tipoDeAcreditacion1"].DisplayIndex = 11;
            columnas["firmado"].DisplayIndex = 12;
            columnas["recursamiento"].DisplayIndex = 13;

            // Limito la edición de los campos
            columnas["nControl"].ReadOnly = true;
            columnas["estudiantes"].ReadOnly = true;
            columnas["recursamiento"].ReadOnly = true;

            // Y finalmente, le doy formato a las columnas de calificaciones, 
            // para que sólo acepten dos decimales, y otras cosas más...
            columnas["calificacionParcial1"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial2"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial3"].DefaultCellStyle.Format = "N2";
            columnas["promedio"].DefaultCellStyle.Format = "N2";

            columnas["recursamiento"].DefaultCellStyle.ForeColor = Color.LightGray;

            // Botones que sólo funcionan si hay DataSource
            cmdGuardar.Enabled = true;
            cmdImportar.Enabled = true;
            cmdReestablecer.Enabled = true;
        }

        private void agregarColumnaCombos()
        {
            // Obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificaciones.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna.DataSource = new string[] { "A", "NA", "NP", "RV", "R" };
            columna.Visible = false;

            dgvCalificaciones.Columns.Add(columna);
        }
    }
}
