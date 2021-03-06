﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmImportarEstudiantes : Form
    {
        private ControladorSesion controladorSesion;

        private Grupo grupo;
        private BindingList<Estudiante> estudiantesActuales;
        private List<Estudiante> estudiantesOriginales;

        public FrmImportarEstudiantes(ControladorSesion controladorSesion, Grupo grupo)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.grupo = grupo;

            estudiantesOriginales = new List<Estudiante>();
        }

        private void FrmImportarEstudiantes_Load(object sender, EventArgs e)
        {
            // Agregamos los semestres al comboSemestres
            comboSemestres.DataSource = 
                controladorSesion.
                daoSemestres.
                seleccionarSemestres();

            // Seleccionamos el semestre actual en el combo...
            comboSemestres.SelectedItem = grupo.semestreObj;

            // Lógica para que se seleccione el grupo anterior 
            int selectedIndex = comboSemestres.SelectedIndex;
            try
            {
                comboSemestres.SelectedIndex = selectedIndex + 1;
            }
            catch (Exception) { }

            try
            {
                if (grupo.semestre > 1)
                {
                    List<Grupo> grupos = (List<Grupo>)comboGrupos.DataSource;

                    Grupo grupoSeleccionado = grupos[0];
                    List<Grupo> gruposPosibles = grupos.Where(
                        g => g.especialidad.Equals(grupo.especialidad) &&
                             g.semestre == grupo.semestre - 1 &&
                             g.turno.Equals(grupo.turno)
                    ).ToList();

                    if (gruposPosibles.Count == 0)
                    {
                        gruposPosibles = grupos.Where(
                            g => g.especialidad.Equals(grupo.especialidad) &&
                                 g.semestre == grupo.semestre - 1
                        ).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Mostramos las propiedades del grupo en los Txts de arriba
            txtSemestre.Text = grupo.semestreObj.ToString();
            txtEspecialidad.Text = grupo.especialidadObj.ToString();
            txtGrado.Text = grupo.semestre.ToString() + "° Semestre | Turno: " + grupo.turno;

            // Mostramos los alumnos actuales del grupo...
            estudiantesOriginales = 
                controladorSesion.
                daoEstudiantes.
                seleccionarEstudiantesPorGrupo(grupo.idGrupo);

            estudiantesActuales = new BindingList<Estudiante>(
                estudiantesOriginales
            );

            dgvEstudiantesImportados.DataSource = estudiantesActuales;

            configurarDGVEstudiantesVisualmente(dgvEstudiantesImportados);
        }

        private void UpdateFont(DataGridView dgv)
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Open Sans", 9.75F, GraphicsUnit.Pixel);
            }
        }

        private void chkTodosLosEstudiantes_CheckedChanged(object sender, EventArgs e)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            comboGrupos.Enabled = !chkTodosLosEstudiantes.Checked;
            comboSemestres.Enabled = !chkTodosLosEstudiantes.Checked;

            if (chkTodosLosEstudiantes.Checked)
                estudiantes =
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantes();
            else
                estudiantes =
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantesPorGrupo(
                        ((Grupo)comboGrupos.SelectedItem).idGrupo
                    );

            configurarDGVEstudiantes(estudiantes, dgvEstudiantesImportar, lblResultados);
        }

        private void comboSemestres_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboGrupos.DataSource =
                controladorSesion.
                daoGrupos.
                seleccionarGruposPorSemestre(
                    ((Semestre)comboSemestres.SelectedItem).idSemestre
                );
        }

        private void comboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Estudiante> estudiantes =
                controladorSesion.
                daoEstudiantes.
                seleccionarEstudiantesPorGrupo(
                    ((Grupo)comboGrupos.SelectedItem).idGrupo
                );

            configurarDGVEstudiantes(estudiantes, dgvEstudiantesImportar, lblResultados);
        }

        private void configurarDGVEstudiantes(List<Estudiante> estudiantes, DataGridView dgv, Label lbl)
        {
            dgv.DataSource = estudiantes;
            lbl.Text = "Resultados - " + estudiantes.Count;
            configurarDGVEstudiantesVisualmente(dgv);
        }

        private void configurarDGVEstudiantesVisualmente(DataGridView dgv)
        {
            dgv.Columns["idEstudiante"].Visible = false;
            dgv.Columns["ncontrol"].HeaderText = "No. de control";
            dgv.Columns["curp"].HeaderText = "CURP";
            dgv.Columns["nombrecompleto"].Visible = false;
            dgv.Columns["nombres"].HeaderText = "Nombre(s)";
            dgv.Columns["apellido1"].HeaderText = "Apellido p.";
            dgv.Columns["apellido2"].HeaderText = "Apellido m.";

            dgv.Columns["apellido1"].DisplayIndex = 1;
            dgv.Columns["apellido2"].DisplayIndex = 2;
            dgv.Columns["nombres"].DisplayIndex = 3;

            UpdateFont(dgv);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            List<Estudiante> estudiantesResultado = new List<Estudiante>();

            if (chkTodosLosEstudiantes.Checked)
            {
                estudiantesResultado =
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantesCondicional(
                        false, 
                        false,
                        true,
                        true,
                        true,
                        true,
                        txtBusqueda.Text
                    );
            }
            else
            {
                estudiantesResultado =
                    controladorSesion.
                    daoEstudiantes.
                    seleccionarEstudiantesPorGrupoCondicional(
                        ((Grupo)comboGrupos.SelectedItem).idGrupo,
                        false, 
                        false,
                        true, 
                        true,
                        true,
                        true, 
                        txtBusqueda.Text);
            }

            configurarDGVEstudiantes(estudiantesResultado, dgvEstudiantesImportar, lblResultados);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdBuscar_Click(sender, e);
            }
        }

        private void cmdAgregarSeleccion_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantesImportar.SelectedRows.Count > 0)
            {
                List<Estudiante> estudiantesSeleccionados =
                    controladorSesion.
                    daoEstudiantes.
                    crearListaEstudiantesDataGridViewSelectedRowCollection(
                        dgvEstudiantesImportar.SelectedRows
                    );

                MessageBox.Show("Se filtró la lista... contiene " + estudiantesSeleccionados.Count);
                agregarEstudiantes(estudiantesSeleccionados);
            }
        }

        private void cmdAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantesImportar.Rows.Count > 0)
            {
                MessageBox.Show("Entramos");
                agregarEstudiantes(((List<Estudiante>)dgvEstudiantesImportar.DataSource).ToList());
            }
        }

        //private List<Estudiante> filtrarAlumnos(DataGridViewSelectedRowCollection dgvSRC, List<Estudiante> listaOriginal)
        //{
        //    List<Estudiante> listaFiltrada = new List<Estudiante>();
        //    List<Estudiante> copiaListaOriginal = listaOriginal.ToList();

        //    foreach (DataGridViewRow dgvR in dgvSRC)
        //    {
        //        int idEstudiante = Convert.ToInt32(dgvR.Cells["idEstudiante"].Value);
        //        listaFiltrada.Add(
        //            copiaListaOriginal.Single(e => e.idEstudiante == idEstudiante)
        //        );
        //    }

        //    return listaFiltrada;
        //}

        private void agregarEstudiantes(List<Estudiante> estudiantesNuevos)
        {
            foreach (Estudiante e in estudiantesNuevos)
            {
                if (!estudiantesActuales.Contains(e))
                {
                    estudiantesActuales.Add(e);
                }
            }
        }

        private void cmdEliminarSeleccion_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantesImportados.SelectedRows.Count > 0)
            {
                List<Estudiante> estudiantesSeleccionados =
                    controladorSesion.
                    daoEstudiantes.
                    crearListaEstudiantesDataGridViewSelectedRowCollection(
                        dgvEstudiantesImportados.SelectedRows
                    );

                foreach (Estudiante est in estudiantesSeleccionados)
                {
                    estudiantesActuales.Remove(est);
                }
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            controladorSesion.
            daoEstudiantes.
            insertarEstudiantesEnGrupo(estudiantesOriginales, grupo);

            MessageBox.Show("Se guardaron los cambios");
        }
    }
}
