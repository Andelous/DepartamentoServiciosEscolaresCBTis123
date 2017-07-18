using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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

        // Métodos de inicialización
        public FrmAcreditacion()
        {
            InitializeComponent();
        }

        private void FrmAcreditacion_Load(object sender, EventArgs e)
        {
            comboCarrera.DataSource = ControladorSingleton.dbContext.carreras.Where(c => c.acuerdo == "653").ToList();
            comboPeriodo.DataSource = ControladorSingleton.dbContext.semestres.OrderByDescending(s => s.idSemestre).ToList();
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
            }
        }

        public void cargarAlumnos(object sender, EventArgs e)
        {
            catedras asignatura = asignaturaSeleccionada;

            if (asignatura != null)
            {
                List<calificaciones> listaCalificaciones = ControladorAcreditacion.seleccionarCalificaciones(asignatura).OrderBy(c => c.estudiantes.apellido1 + c.estudiantes.apellido2 + c.estudiantes.nombres).ToList();
                BindingList<calificaciones> listaCalificacionesBinding = new BindingList<calificaciones>(listaCalificaciones);

                configurarDGVCalificaciones(listaCalificacionesBinding);
            }
            else
            {
                dgvCalificaciones.DataSource = null;
            }
        }


        // Métodos visuales
        private void configurarDGVCalificaciones(BindingList<calificaciones> listaCalificacionesBinding)
        {
            dgvCalificaciones.DataSource = listaCalificacionesBinding;

            DataGridViewColumnCollection columnas = dgvCalificaciones.Columns;

            foreach (DataGridViewColumn c in columnas)
            {
                c.Visible = false;
            }

            columnas["nControl"].Visible = true;
            columnas["calificacionParcial1"].Visible = true;
            columnas["calificacionParcial2"].Visible = true;
            columnas["calificacionParcial3"].Visible = true;
            columnas["asistenciasParcial1"].Visible = true;
            columnas["asistenciasParcial2"].Visible = true;
            columnas["asistenciasParcial3"].Visible = true;
            columnas["tipoDeAcreditacion"].Visible = true;
            columnas["recursamiento"].Visible = true;
            columnas["firmado"].Visible = true;
            columnas["estudiantes"].Visible = true;
            columnas["promedio"].Visible = true;
            columnas["asistenciasTotales"].Visible = true;

            columnas["nControl"].HeaderText = "Núm. control";
            columnas["calificacionParcial1"].HeaderText = "Cal. P1";
            columnas["calificacionParcial2"].HeaderText = "Cal. P2";
            columnas["calificacionParcial3"].HeaderText = "Cal. P3";
            columnas["asistenciasParcial1"].HeaderText = "Asis. P1";
            columnas["asistenciasParcial2"].HeaderText = "Asis. P2";
            columnas["asistenciasParcial3"].HeaderText = "Asis. P3";
            columnas["tipoDeAcreditacion"].HeaderText = "Tipo de Acreditación";
            columnas["recursamiento"].HeaderText = "Recursamiento";
            columnas["firmado"].HeaderText = "Firmado";
            columnas["estudiantes"].HeaderText = "Estudiante";
            columnas["promedio"].HeaderText = "Promedio";
            columnas["asistenciasTotales"].HeaderText = "Asistencias totales";

            columnas["nControl"].DisplayIndex = 0;
            columnas["estudiantes"].DisplayIndex = 0;
            columnas["promedio"].DisplayIndex = columnas["tipoDeAcreditacion"].DisplayIndex;
            columnas["asistenciasTotales"].DisplayIndex = columnas["tipoDeAcreditacion"].DisplayIndex;

            foreach (DataGridViewRow row in dgvCalificaciones.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
    }
}
