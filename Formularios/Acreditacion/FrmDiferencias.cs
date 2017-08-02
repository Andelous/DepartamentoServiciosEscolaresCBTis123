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
    public partial class FrmDiferencias : Form
    {
        private List<calificaciones_semestrales> calificacionesActuales { get; set; }
        private List<calificaciones_semestrales> calificacionesSiseems { get; set; }

        public int encontrados { get; set; }
        public int diferencias { get; set; }
        public int noEncontradosGrupo { get; set; }
        public int noEncontradosDB { get; set; }


        // Colores
        private Color colorDiferencias { get; set; }
        private Color colorDiferenciasResaltado { get; set; }
        private Color colorNoEncontradosGrupo { get; set; }
        private Color colorNoEncontradosGrupoResaltado { get; set; }
        private Color colorNoEncontradosDB { get; set; }
        private Color colorNoEncontradosDBResaltado { get; set; }

        // Propiedad pública para uso del importador
        public List<calificaciones_semestrales> calificacionesDeDGVSiseems
        {
            get
            {
                BindingList<calificaciones_semestrales> calificaciones = (BindingList<calificaciones_semestrales>)dgvCalificacionesSiseems.DataSource;

                int count = 0;
                foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
                {
                    calificaciones_semestrales c = calificaciones[count];

                    c.tipoDeAcreditacion = row.Cells["tipoDeAcreditacion1"].Value.ToString();

                    count++;
                }

                return calificaciones.ToList();
            }
        }
        public List<calificaciones_semestrales> calificacionesDeDGVSiseemsActualizables
        {
            get
            {
                BindingList<calificaciones_semestrales> calificaciones = (BindingList<calificaciones_semestrales>)dgvCalificacionesSiseems.DataSource;
                List<calificaciones_semestrales> listaNueva = new List<calificaciones_semestrales>();

                int count = 0;
                foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
                {
                    calificaciones_semestrales c = calificaciones[count];

                    c.tipoDeAcreditacion = row.Cells["tipoDeAcreditacion1"].Value.ToString();

                    count++;


                    bool actualizable = Convert.ToBoolean(row.Cells["actualizar"].Value);
                    if (actualizable)
                        listaNueva.Add(c);
                }

                return listaNueva.ToList();
            }
        }

        // Métodos de inicialización
        public FrmDiferencias(List<calificaciones_semestrales> calificacionesActuales, List<calificaciones_semestrales> calificacionesSiseems)
        {
            InitializeComponent();

            this.calificacionesActuales = calificacionesActuales;
            this.calificacionesSiseems = calificacionesSiseems;

            agregarColumnasCombos();

            encontrados = 0;
            diferencias = 0;
            noEncontradosGrupo = 0;
            noEncontradosDB = 0;

            colorDiferencias = Color.FromArgb(220, 220, 255);
            colorDiferenciasResaltado = Color.FromArgb(170, 170, 255);

            colorNoEncontradosGrupo = Color.FromArgb(255, 255, 170);
            colorNoEncontradosGrupoResaltado = Color.FromArgb(255, 255, 120);

            colorNoEncontradosDB = Color.FromArgb(255, 220, 220);
            colorNoEncontradosDBResaltado = Color.FromArgb(255, 170, 170);
        }

        private void FrmDiferencias_Load(object sender, EventArgs e)
        {
            BindingList<calificaciones_semestrales> calificacionesActuales = new BindingList<calificaciones_semestrales>(this.calificacionesActuales);
            configurarDGVCalificacionesActuales(calificacionesActuales);

            BindingList<calificaciones_semestrales> calificacionesSiseems = new BindingList<calificaciones_semestrales>(this.calificacionesSiseems);
            configurarDGVCalificacionesSiseems(calificacionesSiseems);

            DoubleBuffered = true;

            lblDiferencias.BackColor = colorDiferencias;
            lblNoEncontradosGrupo.BackColor = colorNoEncontradosGrupo;
            lblNoEncontradosDB.BackColor = colorNoEncontradosDB;
        }

        // Métodos de eventos
        private void ScrollDGVActuales(object sender, ScrollEventArgs e)
        {
            dgvCalificacionesSiseems.FirstDisplayedScrollingRowIndex = dgvCalificacionesActuales.FirstDisplayedScrollingRowIndex;
            //dgvCalificacionesSiseems.FirstDisplayedScrollingColumnIndex = dgvCalificacionesActuales.FirstDisplayedScrollingColumnIndex;

        }

        private void ScrollDGVSiseems(object sender, ScrollEventArgs e)
        {
            dgvCalificacionesActuales.FirstDisplayedScrollingRowIndex = dgvCalificacionesSiseems.FirstDisplayedScrollingRowIndex;
            //dgvCalificacionesActuales.FirstDisplayedScrollingColumnIndex = dgvCalificacionesSiseems.FirstDisplayedScrollingColumnIndex;
        }

        private void cmdSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
            {
                if (!row.Cells["actualizar"].ReadOnly)
                    row.Cells["actualizar"].Value = true;
            }
        }

        private void cmdSeleccionarNinguno_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
            {
                if (!row.Cells["actualizar"].ReadOnly)
                    row.Cells["actualizar"].Value = false;
            }
        }

        private void cmdGuardarDiferencias_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = 
                ControladorAcreditacion.
                actualizarCalificacionesDesdeSiseems(
                    calificacionesDeDGVSiseemsActualizables);

            ControladorVisual.mostrarMensaje(resultadoOperacion);
            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
        }

        private void FrmDiferencias_Resize(object sender, EventArgs e)
        {
            int finalWidth = (int)((Width - 260) / (double)2);

            dgvCalificacionesActuales.Width = finalWidth;
            dgvCalificacionesSiseems.Width = finalWidth;

            Point pLbl = new Point(Width - finalWidth, lblSiseems.Location.Y);
            lblSiseems.Location = pLbl;

            //Point p1 = new Point(finalWidth + 6, cmdGuardarDiferencias.Location.Y);
            //cmdGuardarDiferencias.Location = p1;

            //Point p2 = new Point(finalWidth + 6, cmdSeleccionarNinguno.Location.Y);
            //cmdSeleccionarNinguno.Location = p2;

            //Point p3 = new Point(finalWidth + 6, cmdSeleccionarTodos.Location.Y);
            //cmdSeleccionarTodos.Location = p3;
        }

        // Métodos visuales
        private void configurarDGVCalificacionesActuales(BindingList<calificaciones_semestrales> listaCalificacionesBinding)
        {
            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificacionesActuales.DataSource = null;
                dgvCalificacionesActuales.Columns["tipoDeAcreditacion1"].Visible = false;

                return;
            }

            // Ordenamos la binding list...
            listaCalificacionesBinding = new BindingList<calificaciones_semestrales>(
                listaCalificacionesBinding.
                OrderBy(
                    c =>
                    c.estudiantes.apellido1 +
                    c.estudiantes.apellido2 +
                    c.estudiantes.nombres).
                ToList()
            );

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
                if (((calificaciones_semestrales)row.DataBoundItem).recursamiento)
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

            // Y finalmente, le doy formato a las columnas de calificaciones, 
            // para que sólo acepten dos decimales, y otras cosas más...
            columnas["calificacionParcial1"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial2"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial3"].DefaultCellStyle.Format = "N2";
            columnas["promedio"].DefaultCellStyle.Format = "N2";
        }

        private void configurarDGVCalificacionesSiseems(BindingList<calificaciones_semestrales> listaCalificacionesBinding)
        {
            // Si la colección es originalmente nula, o vacía, salimos.
            if (listaCalificacionesBinding == null || listaCalificacionesBinding.Count < 1)
            {
                dgvCalificacionesSiseems.DataSource = null;
                dgvCalificacionesSiseems.Columns["tipoDeAcreditacion1"].Visible = false;
                dgvCalificacionesSiseems.Columns["actualizar"].Visible = false;

                return;
            }

            // Ordenamos la binding list...
            listaCalificacionesBinding = new BindingList<calificaciones_semestrales>(
                listaCalificacionesBinding.
                OrderBy(
                    c =>
                    c.estudiantes.apellido1 +
                    c.estudiantes.apellido2 +
                    c.estudiantes.nombres).
                ToList()
            );

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
            // y de sólo lectura
            foreach (DataGridViewColumn c in columnas)
            {
                c.Visible = false;
                c.ReadOnly = true;
            }

            // Volvemos editable la columna de actualizar
            columnas["actualizar"].ReadOnly = false;

            // Itero sobre las filas para agregar algunas cosas
            int i = 0;
            foreach (DataGridViewRow row in dgvCalificacionesSiseems.Rows)
            {
                // Primero, el número de lista
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

                calificaciones_semestrales cFila = ((calificaciones_semestrales)row.DataBoundItem);

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
                calificaciones_semestrales cEquivalente = calificacionesActuales.SingleOrDefault(c => c.idEstudiante == cFila.idEstudiante);
                // -- Ya existen, pero las calificaciones son diferentes (LIGHT BLUE)
                // -- Además de que se pone como default el valor TRUE para actualizar
                // -- y los botones se desactivarán
                if (cEquivalente != null)
                {
                    encontrados++;
                    bool flag = false;


                    if (ControladorMiscelaneo.compararNullableDouble(cFila.calificacionParcial1, cEquivalente.calificacionParcial1) != 0)
                    {
                        flag = true;

                        row.Cells["calificacionParcial1"].Style.BackColor = colorDiferenciasResaltado;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cFila.calificacionParcial2, cEquivalente.calificacionParcial2) != 0)
                    {
                        flag = true;

                        row.Cells["calificacionParcial2"].Style.BackColor = colorDiferenciasResaltado;
                    }


                    if (ControladorMiscelaneo.compararNullableDouble(cFila.calificacionParcial3, cEquivalente.calificacionParcial3) != 0)
                    {
                        flag = true;

                        row.Cells["calificacionParcial3"].Style.BackColor = colorDiferenciasResaltado;
                    }





                    if (ControladorMiscelaneo.compararNullableDouble(cFila.asistenciasParcial1, cEquivalente.asistenciasParcial1) != 0)
                    {
                        flag = true;

                        row.Cells["asistenciasParcial1"].Style.BackColor = colorDiferenciasResaltado;
                    }
                    
                    if (ControladorMiscelaneo.compararNullableDouble(cFila.asistenciasParcial2, cEquivalente.asistenciasParcial2) != 0)
                    {
                        flag = true;

                        row.Cells["asistenciasParcial2"].Style.BackColor = colorDiferenciasResaltado;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cFila.asistenciasParcial3, cEquivalente.asistenciasParcial3) != 0)
                    {
                        flag = true;

                        row.Cells["asistenciasParcial3"].Style.BackColor = colorDiferenciasResaltado;
                    }





                    if (cFila.tipoDeAcreditacion != cEquivalente.tipoDeAcreditacion)
                    {
                        flag = true;

                        row.Cells["tipoDeAcreditacion"].Style.BackColor = colorDiferenciasResaltado;
                    }

                    if (cFila.firmado != cEquivalente.firmado)
                    {
                        flag = true;

                        row.Cells["firmado"].Style.BackColor = colorDiferenciasResaltado;
                    }



                    if (flag)
                    {
                        diferencias++;

                        row.DefaultCellStyle.BackColor = colorDiferencias;
                        row.Cells["actualizar"].Value = true;

                        cmdGuardarDiferencias.Enabled = true;
                        cmdSeleccionarNinguno.Enabled = true;
                        cmdSeleccionarTodos.Enabled = true;
                    }
                    // -- Si no, entonces no se pondrá color, y se hará inactualizable
                    // -- tal registro, y los botones se desactivarán
                    else
                    {
                        row.Cells["actualizar"].Value = false;
                        row.Cells["actualizar"].ReadOnly = true;

                        cmdGuardarDiferencias.Enabled = true;
                        cmdSeleccionarNinguno.Enabled = true;
                        cmdSeleccionarTodos.Enabled = true;
                    }
                }
                // -- No existe en nuestro registro (LIGHT RED)
                else
                {
                    if (cFila.idEstudiante != -1)
                    {
                        noEncontradosGrupo++;

                        row.DefaultCellStyle.BackColor = colorNoEncontradosGrupo;
                    }
                    else
                    {
                        noEncontradosDB++;

                        row.DefaultCellStyle.BackColor = colorNoEncontradosDB;
                    }

                    row.Cells["recursamiento"].Value = true;
                    row.Cells["actualizar"].Value = true;
                    row.Cells["verificado"].Value = false;
                }
            }

            // Muestro únicamente las que me interesan
            columnas["actualizar"].Visible = true;
            columnas["nControl"].Visible = true;
            columnas["calificacionParcial1"].Visible = true;
            columnas["calificacionParcial2"].Visible = true;
            columnas["calificacionParcial3"].Visible = true;
            columnas["asistenciasParcial1"].Visible = true;
            columnas["asistenciasParcial2"].Visible = true;
            columnas["asistenciasParcial3"].Visible = true;
            columnas["tipoDeAcreditacion"].Visible = false;
            columnas["tipoDeAcreditacion1"].Visible = true;
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
            columnas["firmado"].HeaderText = "Firmado";
            columnas["estudiantes"].HeaderText = "Estudiante";
            columnas["promedio"].HeaderText = "Promedio";
            columnas["asistenciasTotales"].HeaderText = "Asistencias totales";

            // Las muestro en un orden particular
            int intOrden = 0;
            columnas["actualizar"].DisplayIndex = intOrden++;
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

            // Y finalmente, le doy formato a las columnas de calificaciones, 
            // para que sólo acepten dos decimales, y otras cosas más...
            columnas["calificacionParcial1"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial2"].DefaultCellStyle.Format = "N2";
            columnas["calificacionParcial3"].DefaultCellStyle.Format = "N2";
            columnas["promedio"].DefaultCellStyle.Format = "N2";

            // Construcción del resumen
            lblEncontrados.Text = "Se encontraron " + encontrados + " alumno(s) pertenecientes al grupo.";
            lblDiferencias.Text = diferencias + " alumnos tienen diferencias en sus calificaciones.";
            lblNoEncontradosGrupo.Text = noEncontradosGrupo + " alumnos no pertenecen al grupo.";
            lblNoEncontradosDB.Text = noEncontradosDB + " alumnos no se encuentran en la base de datos.";

            // Si las diferencias y los alumnos no pertenecientes son 0
            // entonces deshabilitamos el botón de guardar diferencias
        }

        private void agregarColumnasCombos()
        {
            // DGV Actual
            // Obtenemos la colección de columnas...
            DataGridViewColumnCollection columnas = dgvCalificacionesActuales.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna1 = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna1.DataSource = calificaciones_semestrales.tiposDeAcreditacion.ToList();
            columna1.Visible = false;

            dgvCalificacionesActuales.Columns.Add(columna1);

            // DGV Siseems
            // Obtenemos la colección de columnas...
            columnas = dgvCalificacionesSiseems.Columns;

            // Agrego a la tabla, los combos de A NP NA RV R
            DataGridViewComboBoxColumn columna2 = new DataGridViewComboBoxColumn() { Name = "tipoDeAcreditacion1" };
            columna2.DataSource = calificaciones_semestrales.tiposDeAcreditacion.ToList();
            columna2.Visible = false;

            dgvCalificacionesSiseems.Columns.Add(columna2);

            // Esta siguiente columna es para decidir si 
            // agregamos las modificaciones a la base de datos

            DataGridViewCheckBoxColumn columna3 = new DataGridViewCheckBoxColumn() { Name = "actualizar", HeaderText = "Actualizar"};
            columna3.Visible = false;
            columnas.Add(columna3);
        }
    }
}

