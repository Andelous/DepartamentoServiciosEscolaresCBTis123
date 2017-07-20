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
    public partial class FrmImportarCalificaciones : Form
    {
        // Métodos de inicialización
        public FrmImportarCalificaciones()
        {
            InitializeComponent();
        }



        // Métodos de eventos
        private void cmdImportar_Click(object sender, EventArgs e)
        {
            string html = webSiseems.Document.Body.InnerHtml;
            string[][] tabla = ControladorMiscelaneo.crearTablaDeHtml(html);

            List<calificaciones> calificacionesSiseems = ControladorAcreditacion.crearListaCalificaciones(tabla);

            /*
             * 
             * Código únicamente para pruebas
             * 
             */

            //foreach (calificaciones c in calificacionesSiseems)
            //{
            //    DialogResult dr = MessageBox.Show(
            //        "P1 - " + c.calificacionParcial1 + "\n" +
            //        "P2 - " + c.calificacionParcial2 + "\n" +
            //        "AT - " + c.asistenciasTotales + "\n" +
            //        "TA - " + c.tipoDeAcreditacion + "\n" +
            //        "Re - " + c.recursamiento.ToString() + "\n" +
            //        "Fi - " + c.firmado.ToString() + "\n" +
            //        "Es - " + c.estudiantes.ToString(),

            //        "Hola desde importar",
            //        MessageBoxButtons.OKCancel);

            //    if (dr == DialogResult.Cancel)
            //    {
            //        break;
            //    }
            //}

            /*
             * 
             * Termina código únicamente para pruebas
             * 
             */
        }
    }
}
