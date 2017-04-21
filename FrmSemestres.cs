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
    public partial class FrmSemestres : Form
    {
        private ControladorSesion controladorSesion { get; set; }
        private ControladorSemestres controladorSemestres { get; set; }

        private Semestre semestreSeleccionado {
            get {
                return (Semestre)dgvSemestres.SelectedRows[0].DataBoundItem;
            }
        }

        public FrmSemestres(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.controladorSemestres = new ControladorSemestres();
        }

        private void FrmSemestres_Load(object sender, EventArgs e)
        {
            configurarDGVSemestres();
        }

        private void cmdNuevoSemestre_Click(object sender, EventArgs e)
        {
            new FrmNuevoSemestre(controladorSesion, controladorSemestres).ShowDialog();
            configurarDGVSemestres();
        }

        private void cmdEliminarSemestre_Click(object sender, EventArgs e)
        {
            DialogResult dr = 
                MessageBox.Show(
                    "¿Está seguro que desea eliminar el semestre " +
                    semestreSeleccionado.ToString() + "?",
                    "Aviso",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                ResultadoOperacion resultadoOperacion = controladorSemestres.eliminarSemestre(semestreSeleccionado);
                ControladorVisual.mostrarMensaje(resultadoOperacion);

                if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
                    configurarDGVSemestres();
            }
        }

        private void cmdEditarSemestre_Click(object sender, EventArgs e)
        {
            new FrmModificarSemestre(controladorSesion, controladorSemestres, semestreSeleccionado).ShowDialog();
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

            dgvSemestres.Columns["idSemestre"].Visible = false;
            dgvSemestres.Columns["nombre"].HeaderText = "Nombre";
            dgvSemestres.Columns["nombrecorto"].HeaderText = "Nombre corto";
            dgvSemestres.Columns["nombrecorto2"].HeaderText = "Nombre corto (2)";
            dgvSemestres.Columns["nombrecorto3"].HeaderText = "Nombre corto (3)";
        }
    }
}
