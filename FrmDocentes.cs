using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public partial class FrmDocentes : Form
    {
        private ControladorSesion controladorSesion;

        public FrmDocentes(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
        }

        private void FrmDocentes_Load(object sender, EventArgs e)
        {
            configurarDGVDocentes(controladorSesion.daoDocentes.seleccionarDocentes());
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
        }

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

        private void cmdNuevoDocente_Click(object sender, EventArgs e)
        {
            (new FrmNuevoDocente(controladorSesion)).ShowDialog();
            configurarDGVDocentes(controladorSesion.daoDocentes.seleccionarDocentes());
        }

        private void cmdEliminarDocente_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "¿Está seguro que desea eliminar al docente " +
                    dgvDocentes.SelectedRows[0].Cells["nombrecompleto"].Value.ToString() +
                    "?",
                    "Aviso",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) == DialogResult.OK
                )
            {
                int idDocente = Convert.ToInt32(dgvDocentes.SelectedRows[0].Cells["idDocente"].Value);

                // LISTA CATEDRAS A LAS QUE PERTENECE

                if (// FALTA CONDICIÓN DE LAS CATEDRAS A LAS QUE PERTENECE
                    controladorSesion.
                    daoDocentes.
                    eliminarDocente(
                        idDocente
                    ) == 1)
                {
                    MessageBox.Show("Docente eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configurarDGVDocentes(controladorSesion.daoDocentes.seleccionarDocentes());
                }
                else
                {
                    MessageBox.Show("Error al eliminar el docente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            configurarDGVDocentes(
                controladorSesion.
                daoDocentes.
                seleccionarDocentesPorCoincidencia(txtBusqueda.Text)
            );
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
            DataGridViewCellCollection cells = dgvDocentes.SelectedRows[0].Cells;

            Docente d = DAODocentes.crearDocente(
                Convert.ToInt32(cells["idDocente"].Value.ToString()),
                ".",
                0,
                cells["curp"].Value.ToString(),
                cells["rfc"].Value.ToString(),
                cells["nombres"].Value.ToString(),
                cells["apellidop"].Value.ToString(),
                cells["apellidom"].Value.ToString(),
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                ".",
                Convert.ToDateTime(cells["fechaNacimiento"].Value),
                "."
            );

            (new FrmModificarDocente(controladorSesion, d)).ShowDialog();
            configurarDGVDocentes(
                controladorSesion.
                daoDocentes.
                seleccionarDocentes()
            );
        }
    }
}
