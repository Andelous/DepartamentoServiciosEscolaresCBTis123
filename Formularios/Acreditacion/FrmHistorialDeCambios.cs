using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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

namespace DepartamentoServiciosEscolaresCBTis123.Formularios.Acreditacion
{
    public partial class FrmHistorialDeCambios : Form
    {
        // Propiedades privadas
        private calificaciones_semestrales calificacion { get; set; }


        // Métodos de inicialización
        public FrmHistorialDeCambios(calificaciones_semestrales calificacion)
        {
            InitializeComponent();

            this.calificacion = calificacion;
        }

        private void FrmHistorialDeCambios_Load(object sender, EventArgs e)
        {
            List<HistorialCalificacionSemestral> historial = ControladorAcreditacion.seleccionarHistorial(calificacion);
            
            if (historial.Count > 0)
            {
                configurarDGVHistorial(historial);
            }
            else
            {
                MessageBox.Show("No existen cambios para esta calificación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            txtParcial1.Text = calificacion.calificacionParcial1.ToString();
            txtParcial2.Text = calificacion.calificacionParcial2.ToString();
            txtParcial3.Text = calificacion.calificacionParcial3.ToString();

            txtAsistencias1.Text = calificacion.asistenciasParcial1.ToString();
            txtAsistencias2.Text = calificacion.asistenciasParcial2.ToString();
            txtAsistencias3.Text = calificacion.asistenciasParcial3.ToString();

            txtDocente.Text = calificacion.catedras.docentes.ToString();
            txtGrupo.Text = calificacion.catedras.grupos.ToString();
            txtMateria.Text = calificacion.catedras.materias.ToString();
            txtSemestre.Text = calificacion.catedras.grupos.semestres.ToString();

            lblTitulo.Text = "Historial de cambios - " + calificacion.estudiantes.ToString();
        }

        private void configurarDGVHistorial(List<HistorialCalificacionSemestral> historial)
        {
            historial.Reverse();

            dgvHistorial.DataSource = historial;

            DataGridViewColumnCollection columnas = dgvHistorial.Columns;

            columnas["nombreDeCampo"].HeaderText = "Nombre de campo modificado";
            columnas["valorAnterior"].HeaderText = "Valor anterior";
            columnas["valorNuevo"].HeaderText = "Valor nuevo";
            columnas["fuenteDeCambio"].HeaderText = "Fuente de cambio";
            columnas["fecha"].HeaderText = "Fecha y hora del cambio";
            columnas["usuarioAutor"].HeaderText = "Usuario responsable del cambio";
        }
    }
}
