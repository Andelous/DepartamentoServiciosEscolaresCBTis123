using DepartamentoServiciosEscolaresCBTis123.Logica.ADOs;
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
    public partial class FrmPruebas : Form
    {
        public FrmPruebas()
        {
            InitializeComponent();
        }

        private void FrmPruebas_Load(object sender, EventArgs e)
        {
            ADOCarreras adoCarreras = new ADOCarreras();

            dataGridView1.DataSource = adoCarreras.seleccionarCarrerasPorAcuerdo("653");
        }
    }
}
