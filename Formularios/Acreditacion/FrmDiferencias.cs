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
    public partial class FrmDiferencias : Form
    {
        private List<calificaciones> calificacionesActuales { get; set; }
        private List<calificaciones> calificacionesSiseems { get; set; }

        // Métodos de inicialización
        public FrmDiferencias(List<calificaciones> calificacionesActuales, List<calificaciones> calificacionesSiseems)
        {
            InitializeComponent();

            this.calificacionesActuales = calificacionesActuales;
            this.calificacionesSiseems = calificacionesSiseems;

            agregarColumnasCombos();
        }

        private void FrmDiferencias_Load(object sender, EventArgs e)
        {
            BindingList<calificaciones> calificacionesActuales = new BindingList<calificaciones>(this.calificacionesActuales);
            configurarDGVCalificacionesActuales(calificacionesActuales);

            BindingList<calificaciones> calificacionesSiseems = new BindingList<calificaciones>(this.calificacionesSiseems);
            configurarDGVCalificacionesSiseems(calificacionesSiseems);
        }

        // Métodos de eventos
        private void ScrollDGVActuales(object sender, ScrollEventArgs e)
        {
            dgvCalificacionesSiseems.FirstDisplayedScrollingRowIndex = dgvCalificacionesActuales.FirstDisplayedScrollingRowIndex;
            dgvCalificacionesSiseems.FirstDisplayedScrollingColumnIndex = dgvCalificacionesActuales.FirstDisplayedScrollingColumnIndex;
        }

        private void ScrollDGVSiseems(object sender, ScrollEventArgs e)
        {
            dgvCalificacionesActuales.FirstDisplayedScrollingRowIndex = dgvCalificacionesSiseems.FirstDisplayedScrollingRowIndex;
            dgvCalificacionesActuales.FirstDisplayedScrollingColumnIndex = dgvCalificacionesSiseems.FirstDisplayedScrollingColumnIndex;
        }

        // Métodos visuales
        private void configurarDGVCalificacionesActuales(BindingList<calificaciones> listaCalificacionesBinding)
        {
            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificacionesActuales.DataSource = null;
                dgvCalificacionesActuales.Columns["tipoDeAcreditacion1"].Visible = false;

                return;
            }

            // Agregamos todos los datos al dgv
            dgvCalificacionesActuales.DataSource = listaCalificacionesBinding;

            // Ahora, obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificacionesActuales.Columns;





            /*
             * 
             * Código únicamente para pruebas
             * 
             */

            //StringBuilder nombres = new StringBuilder("");
            //int count = 0;
            //foreach (DataGridViewColumn col in dgvCalificacionesActuales.Columns)
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
            foreach (DataGridViewRow row in dgvCalificacionesActuales.Rows)
            {
                // Primero, el número de lista
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

                // Segundo, el color de fondo para mostrar a los de recursamiento
                if (((calificaciones)row.DataBoundItem).recursamiento)
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
        }

        private void configurarDGVCalificacionesSiseems(BindingList<calificaciones> listaCalificacionesBinding)
        {
            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificacionesSiseems.DataSource = null;
                dgvCalificacionesSiseems.Columns["tipoDeAcreditacion1"].Visible = false;

                return;
            }

            // Agregamos todos los datos al dgv
            dgvCalificacionesSiseems.DataSource = listaCalificacionesBinding;

            // Ahora, obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificacionesSiseems.Columns;





            /*
             * 
             * Código únicamente para pruebas
             * 
             */

            //StringBuilder nombres = new StringBuilder("");
            //int count = 0;
            //foreach (DataGridViewColumn col in dgvCalificacionesSiseems.Columns)
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
            foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
            {
                // Primero, el número de lista
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

                calificaciones cFila = ((calificaciones)row.DataBoundItem);

                // Segundo, el color de fondo para mostrar a los de recursamiento
                // (Probablemente en este DGV nunca se muestren)
                if (cFila.recursamiento)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // Tercero, seleccionamos el tipo de acreditación
                // A NP NA RV R
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells["tipoDeAcreditacion1"];
                cell.Value = listaCalificacionesBinding[i].tipoDeAcreditacion;
                i++;



                // ESTO ES ADICIONAL PARA RESALTAR LAS DIFERENCIAS
                calificaciones cEquivalente = calificacionesActuales.SingleOrDefault(c => c.idEstudiante == cFila.idEstudiante);
                // -- Ya existen, pero las calificaciones son diferentes (LIGHT BLUE)

                if (cEquivalente != null)
                {
                    if (
                        cFila.calificacionParcial1 != cEquivalente.calificacionParcial1 ||
                        cFila.calificacionParcial2 != cEquivalente.calificacionParcial2 ||
                        cFila.calificacionParcial3 != cEquivalente.calificacionParcial3 ||
                        
                        cFila.asistenciasParcial1 != cEquivalente.asistenciasParcial1 ||
                        cFila.asistenciasParcial2 != cEquivalente.asistenciasParcial2 ||
                        cFila.asistenciasParcial3 != cEquivalente.asistenciasParcial3 ||

                        cFila.tipoDeAcreditacion != cEquivalente.tipoDeAcreditacion ||
                        cFila.firmado != cEquivalente.firmado
                    ) {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 255);
                    }
                }
                // -- No existe en nuestro registro (LIGHT RED)
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }
                
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
        }

        private void agregarColumnasCombos()
        {
            // Obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificacionesActuales.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna1 = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna1.DataSource = new string[] { "A", "NA", "NP", "RV", "R" };
            columna1.Visible = false;

            dgvCalificacionesActuales.Columns.Add(columna1);

            // Obtenemos la colección de columnas...
            columnas = dgvCalificacionesSiseems.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna2 = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna2.DataSource = new string[] { "A", "NA", "NP", "RV", "R" };
            columna2.Visible = false;

            dgvCalificacionesSiseems.Columns.Add(columna2);
        }
    }
}
