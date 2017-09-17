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
        // Propiedades
        private catedras catedraActual { get; set; }

        // Métodos de inicialización
        public FrmImportarCalificaciones(catedras catedraActual)
        {
            InitializeComponent();

            this.catedraActual = catedraActual;
        }

        private void FrmImportarCalificaciones_Load(object sender, EventArgs e)
        {

        }

        // Métodos de eventos
        private void cmdImportar_Click(object sender, EventArgs e)
        {
            string html = webSiseems.Document.Body.InnerHtml;
            string[][] tabla = ControladorMiscelaneo.crearTablaDeHtml(html);

            List<calificaciones_semestrales> calificacionesSiseems = ControladorAcreditacion.crearListaCalificaciones(tabla, catedraActual.idCatedra, catedraActual);

            FrmAcreditacion frmAcreditacion = (FrmAcreditacion)Application.OpenForms["FrmAcreditacion"];

            new FrmDiferencias(frmAcreditacion.calificacionesDeDGV, calificacionesSiseems).ShowDialog();
            Close();
        }
        
        private void FrmImportarCalificaciones_Resize(object sender, EventArgs e)
        {
            Point p = new Point(Width - 187, Height - 84);
            cmdImportar.Location = p;
        }
    }
}
