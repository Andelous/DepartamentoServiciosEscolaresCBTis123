using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
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
    public partial class FrmSemestres : Form
    {
        private ControladorSesion controladorSesion
        {
            get
            {
                return ControladorSingleton.controladorSesion;
            }
        }
        private ControladorSemestres controladorSemestres
        {
            get
            {
                return ControladorSingleton.controladorSemestres;
            }
        }

        private semestres semestreSeleccionado
        {
            get
            {
                return (semestres)dgvSemestres.SelectedRows[0].DataBoundItem;
            }
        }

        public FrmSemestres()
        {
            InitializeComponent();
        }

        private void FrmSemestres_Load(object sender, EventArgs e)
        {
            configurarDGVSemestres();
        }

        private void cmdNuevoSemestre_Click(object sender, EventArgs e)
        {
            new FrmNuevoSemestre().ShowDialog();
            configurarDGVSemestres();
        }

        private void cmdEliminarSemestre_Click(object sender, EventArgs e)
        {
            DialogResult dr = 
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el semestre " +
                    semestreSeleccionado.ToString() + "?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ResultadoOperacion resultadoOperacion = controladorSemestres.eliminarSemestre(semestreSeleccionado);
                ControladorVisual.mostrarMensaje(resultadoOperacion);

                configurarDGVSemestres();
            }
        }

        private void cmdEditarSemestre_Click(object sender, EventArgs e)
        {
            new FrmModificarSemestre(semestreSeleccionado).ShowDialog();
            configurarDGVSemestres();
        }

        private void FrmSemestres_Resize(object sender, EventArgs e)
        {
            dgvSemestres.Width = Width - 40;
            dgvSemestres.Height = Height - 160;

            Point p1 = new Point(
                Width - 196,
                cmdNuevoSemestre.Location.Y
            );
            cmdNuevoSemestre.Location = p1;

            Point p2 = new Point(
                cmdEditarSemestre.Location.X,
                Height - 85
            );
            cmdEditarSemestre.Location = p2;

            Point p5 = new Point(
                cmdMatricula.Location.X,
                Height - 85
            );
            cmdMatricula.Location = p5;

            Point p3 = new Point(
                //cmdAgregarGrupos.Location.X,
                Height - 85
            );
            //cmdAgregarGrupos.Location = p3;

            Point p4 = new Point(
                Width - 196,
                Height - 85
            );
            cmdEliminarSemestre.Location = p4;
        }

        private void configurarDGVSemestres()
        {
            dgvSemestres.DataSource = controladorSemestres.seleccionarSemestres();

            foreach (DataGridViewColumn col in dgvSemestres.Columns)
            {
                col.Visible = false;
            }

            dgvSemestres.Columns["nombre"].HeaderText = "Nombre";
            dgvSemestres.Columns["nombrecorto"].HeaderText = "Nombre corto";
            dgvSemestres.Columns["nombrecorto2"].HeaderText = "Nombre corto (2)";
            dgvSemestres.Columns["nombrecorto3"].HeaderText = "Nombre corto (3)";

            dgvSemestres.Columns["nombre"].Visible = true;
            dgvSemestres.Columns["nombrecorto"].Visible = true;
            dgvSemestres.Columns["nombrecorto2"].Visible = true;
            dgvSemestres.Columns["nombrecorto3"].Visible = true;

            if (dgvSemestres.SelectedRows.Count < 1)
            {
                cmdEditarSemestre.Enabled = false;
                cmdEliminarSemestre.Enabled = false;
                cmdMatricula.Enabled = false;
            }
            else
            {
                cmdEditarSemestre.Enabled = true;
                cmdEliminarSemestre.Enabled = true;
                cmdMatricula.Enabled = true;
            }
        }

        private void cmdMatricula_Click(object sender, EventArgs e)
        {
            string[][] matricula = ControladorMiscelaneo.matricularSemestre(semestreSeleccionado);
            ControladorMiscelaneo.mostrarExcel(matricula);
        }
    }
}
