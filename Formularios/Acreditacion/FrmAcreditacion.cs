﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
        private calificaciones_semestrales calificacionSeleccionada
        {
            get
            {
                return (calificaciones_semestrales)dgvCalificaciones.Rows[dgvCalificaciones.SelectedCells[0].RowIndex].DataBoundItem;
            }
        }
        private string nombrePropiedadSeleccionada
        {
            get
            {
                return dgvCalificaciones.Columns[dgvCalificaciones.SelectedCells[0].ColumnIndex].Name;
            }
        }

        private IList<catedras> asignaturas
        {
            get
            {
                return (List<catedras>)comboAsignatura.DataSource;
            }
        }
        
        // Propiedad pública para uso del importador
        public List<calificaciones_semestrales> calificacionesDeDGV
        {
            get
            {
                BindingList<calificaciones_semestrales> calificaciones = (BindingList<calificaciones_semestrales>)dgvCalificaciones.DataSource;

                int count = 0;
                foreach (DataGridViewRow row in dgvCalificaciones.Rows)
                {
                    calificaciones_semestrales c = calificaciones[count];

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
            comboCarrera.DataSource = ControladorSingleton.dbContext.carreras.Where(c => (c.estado == 1 || c.estado == 0) && c.abreviatura != "BGRAL" && c.abreviatura != "Todas").ToList();
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

                if (listaGrupos.Count == 0)
                {
                    comboGrupo.DataSource = null;
                    comboAsignatura.DataSource = null;
                    cmdImportar.Enabled = false;
                    configurarDGVCalificaciones(null);
                }
            }
            else
            {
                comboGrupo.DataSource = null;
                comboAsignatura.DataSource = null;
                cmdImportar.Enabled = false;
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
                cmdImportar.Enabled = false;
                configurarDGVCalificaciones(null);
            }
        }

        public void cargarAlumnos(object sender, EventArgs e)
        {
            catedras asignatura = asignaturaSeleccionada;

            if (asignatura != null)
            {
                List<calificaciones_semestrales> listaCalificaciones = ControladorAcreditacion.seleccionarCalificaciones(asignatura);
                BindingList<calificaciones_semestrales> listaCalificacionesBinding = new BindingList<calificaciones_semestrales>(listaCalificaciones);
            
                configurarDGVCalificaciones(listaCalificacionesBinding);
            }
            else
            {
                configurarDGVCalificaciones(null);
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            List<calificaciones_semestrales> calif = calificacionesDeDGV;

            ResultadoOperacion resultadoOperacion = ControladorAcreditacion.actualizarCalificaciones(calif, "Captura manual");
            ControladorVisual.mostrarMensaje(resultadoOperacion);
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            //new FrmImportarCalificaciones(asignaturaSeleccionada).ShowDialog();
            new FrmImportarCalificacionesM(asignaturas, grupoSeleccionado).ShowDialog();
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

            dgvCalificaciones_CellValueChanged(sender, null);
        }

        private void dgvCalificaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvCalificaciones.Invalidate();
        }

        private void cmdVerHistorial_Click(object sender, EventArgs e)
        {
            new FrmHistorialDeCambios(calificacionSeleccionada).ShowDialog();
        }



















        // Métodos visuales
        private void configurarDGVCalificaciones(BindingList<calificaciones_semestrales> listaCalificacionesBinding)
        {
            cmdImportar.Enabled = listaCalificacionesBinding != null;

            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificaciones.DataSource = null;
                dgvCalificaciones.Columns["tipoDeAcreditacion1"].Visible = false;

                configurarBotones(false);

                return;
            }

            // Ordenamos la binding list...
            listaCalificacionesBinding = new BindingList<calificaciones_semestrales>(
                listaCalificacionesBinding.
                OrderBy(
                    c => 
                    c.estudiantes.ToString()).
                ToList()
            );

            // Agregamos todos los datos al dgv
            dgvCalificaciones.DataSource = listaCalificacionesBinding;

            // Ahora, obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificaciones.Columns;

            // Iteramos sobre todas las columnas para hacerlas invisibles
            foreach (DataGridViewColumn c in columnas)
            {
                c.Visible = false;
            }

            // Itero sobre las filas para agregar algunas cosas
            foreach (DataGridViewRow row in dgvCalificaciones.Rows)
            {
                calificaciones_semestrales cActual = (calificaciones_semestrales)row.DataBoundItem;

                // Primero, el número de lista
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

                // Segundo, el color de fondo para mostrar a los de recursamiento
                if (cActual.recursamiento)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // Tercero, seleccionamos el tipo de acreditación
                // A NP NA RV R
                DataGridViewCell cell = row.Cells["tipoDeAcreditacion1"];
                cell.Value = cActual.tipoDeAcreditacion;
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
            //columnas["recursamiento"].Visible = true;
            columnas["firmado"].Visible = true;
            columnas["estudiantes"].Visible = true;
            columnas["promedio"].Visible = true;
            columnas["asistenciasTotales"].Visible = true;
            //columnas["verificado"].Visible = true;

            // Cambio el título
            columnas["nControl"].HeaderText = "Núm. control";
            columnas["calificacionParcial1"].HeaderText = "Cal. P1";
            columnas["calificacionParcial2"].HeaderText = "Cal. P2";
            columnas["calificacionParcial3"].HeaderText = "Cal. P3";
            columnas["asistenciasParcial1"].HeaderText = "Asis. P1";
            columnas["asistenciasParcial2"].HeaderText = "Asis. P2";
            columnas["asistenciasParcial3"].HeaderText = "Asis. P3";
            columnas["tipoDeAcreditacion"].HeaderText = "Tipo de Acreditación";
            columnas["tipoDeAcreditacion1"].HeaderText = "Tipo de Acreditación";
            columnas["recursamiento"].HeaderText = "Recursamiento";
            columnas["firmado"].HeaderText = "Firmado";
            columnas["estudiantes"].HeaderText = "Estudiante";
            columnas["promedio"].HeaderText = "Promedio";
            columnas["asistenciasTotales"].HeaderText = "Asistencias totales";
            columnas["verificado"].HeaderText = "Verificado";

            // Las muestro en un orden particular
            int intOrden = 0;
            columnas["nControl"].DisplayIndex = intOrden++;
            columnas["estudiantes"].DisplayIndex = intOrden++;
            columnas["calificacionParcial1"].DisplayIndex = intOrden++;
            columnas["calificacionParcial2"].DisplayIndex = intOrden++;
            columnas["calificacionParcial3"].DisplayIndex = intOrden++;
            columnas["asistenciasParcial1"].DisplayIndex = intOrden++;
            columnas["asistenciasParcial2"].DisplayIndex = intOrden++;
            columnas["asistenciasParcial3"].DisplayIndex = intOrden++;
            columnas["promedio"].DisplayIndex = intOrden++;
            columnas["asistenciasTotales"].DisplayIndex = intOrden++;
            columnas["tipoDeAcreditacion"].DisplayIndex = intOrden++;
            columnas["tipoDeAcreditacion1"].DisplayIndex = intOrden++;
            columnas["firmado"].DisplayIndex = intOrden++;
            columnas["recursamiento"].DisplayIndex = intOrden++;
            columnas["verificado"].DisplayIndex = intOrden++;

            // Limito la edición de los campos
            columnas["nControl"].ReadOnly = true;
            columnas["estudiantes"].ReadOnly = true;
            columnas["recursamiento"].ReadOnly = true;
            columnas["verificado"].ReadOnly = true;

            // Y finalmente, le doy formato a las columnas de calificaciones, 
            // para que sólo acepten dos decimales, y otras cosas más...
            columnas["calificacionParcial1"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial2"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial3"].DefaultCellStyle.Format = "N2";
            columnas["promedio"].DefaultCellStyle.Format = "N2";

            columnas["recursamiento"].DefaultCellStyle.ForeColor = Color.LightGray;

            columnas["nControl"].Width = 100;
            columnas["estudiantes"].Width = 220;
            columnas["tipoDeAcreditacion1"].Width = 100;
            columnas["firmado"].Width = 40;

            // Botones que sólo funcionan si hay DataSource
            configurarBotones(true);
        }

        private void agregarColumnaCombos()
        {
            // Obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificaciones.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna.DataSource = calificaciones_semestrales.tiposDeAcreditacion.ToList();
            columna.Visible = false;

            dgvCalificaciones.Columns.Add(columna);
        }

        private void configurarBotones(bool b)
        {
            cmdGuardar.Enabled = b;
            //cmdImportar.Enabled = b;
            cmdReestablecer.Enabled = b;
            cmdVerHistorial.Enabled = b;
        }
    }
}
