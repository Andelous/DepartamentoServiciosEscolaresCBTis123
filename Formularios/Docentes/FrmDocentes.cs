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
    public partial class FrmDocentes : Form
    {
        // Controladores 
        private ControladorDocentes controladorDocentes
        {
            get
            {
                return ControladorSingleton.controladorDocentes;
            }
        }

        private Docente docenteSeleccionado
        {
            get
            {
                return (Docente)dgvDocentes.SelectedRows[0].DataBoundItem;
            }
        }

        // Métodos de iniciación.
        public FrmDocentes()
        {
            InitializeComponent();
        }

        private void FrmDocentes_Load(object sender, EventArgs e)
        {
            configurarDGVDocentes(controladorDocentes.seleccionarDocentes());
        }

        // Métodos de eventos de controles
        private void cmdNuevoDocente_Click(object sender, EventArgs e)
        {
            (new FrmNuevoDocente()).ShowDialog();
            configurarDGVDocentes(controladorDocentes.seleccionarDocentes());
        }

        private void cmdEliminarDocente_Click(object sender, EventArgs e)
        {
            DialogResult dr =
                MessageBox.Show(
                    "¿Está seguro que desea eliminar al docente " +
                    docenteSeleccionado.ToString() + "?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                ResultadoOperacion resultadoOperacion = controladorDocentes.eliminarDocente(docenteSeleccionado);

                ControladorVisual.mostrarMensaje(resultadoOperacion);
                configurarDGVDocentes(controladorDocentes.seleccionarDocentes());
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            configurarDGVDocentes(controladorDocentes.seleccionarDocentes(txtBusqueda.Text));
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdBuscar_Click(sender, e);
            }
        }

        private void cmdEditarDocente_Click(object sender, EventArgs e)
        {
            (new FrmModificarDocente(docenteSeleccionado)).ShowDialog();
            configurarDGVDocentes(controladorDocentes.seleccionarDocentes());
        }

        // Métodos vinculados con algo visual.

        private void FrmDocentes_Resize(object sender, EventArgs e)
        {
            Point p1 = new Point(
                Width - 196,
                cmdNuevoDocente.Location.Y
            );
            cmdNuevoDocente.Location = p1;

            dgvDocentes.Width = Width - 40;
            dgvDocentes.Height = Height - 160;

            Point p2 = new Point(
                cmdEditarDocente.Location.X,
                Height - 85
            );
            cmdEditarDocente.Location = p2;

            Point p3 = new Point(
                Width - 196,
                Height - 85
            );
            cmdEliminarDocente.Location = p3;
        }

        private void configurarDGVDocentes(List<Docente> lista)
        {
            dgvDocentes.DataSource = lista;

            DataGridViewColumnCollection columnas = dgvDocentes.Columns;

            foreach (DataGridViewColumn columna in columnas)
            {
                columna.Visible = false;
            }

            columnas["nombres"].Visible = true;
            columnas["nombres"].HeaderText = "Nombres";
            columnas["apellidop"].Visible = true;
            columnas["apellidop"].HeaderText = "Apellido paterno";
            columnas["apellidom"].Visible = true;
            columnas["apellidom"].HeaderText = "Apellido Materno";
            columnas["curp"].Visible = true;
            columnas["curp"].HeaderText = "CURP";
            columnas["rfc"].Visible = true;
            columnas["rfc"].HeaderText = "RFC";

            lblResultados.Text = "(" + lista.Count +" resultados)";
        }
    }
}
