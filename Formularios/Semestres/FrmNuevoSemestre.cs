using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmNuevoSemestre : Form
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

        public FrmNuevoSemestre()
        {
            InitializeComponent();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            DateTime fechai_p1 = new DateTime((int)nudAnoiP1.Value, (int)nudMesiP1.Value, (int)nudDiaiP1.Value);
            DateTime fechai_p2 = new DateTime((int)nudAnoiP2.Value, (int)nudMesiP2.Value, (int)nudDiaiP2.Value);
            DateTime fechai_p3 = new DateTime((int)nudAnoiP3.Value, (int)nudMesiP3.Value, (int)nudDiaiP3.Value);

            DateTime fechaf_p1 = new DateTime((int)nudAnofP1.Value, (int)nudMesfP1.Value, (int)nudDiafP1.Value);
            DateTime fechaf_p2 = new DateTime((int)nudAnofP2.Value, (int)nudMesfP2.Value, (int)nudDiafP2.Value);
            DateTime fechaf_p3 = new DateTime((int)nudAnofP3.Value, (int)nudMesfP3.Value, (int)nudDiafP3.Value);

            ResultadoOperacion resultadoOperacion =
                controladorSemestres.
                registrarSemestre(
                    txtNombre.Text,
                    txtNombreCorto.Text,
                    txtNombreCorto2.Text,
                    txtNombreCorto3.Text,
                    fechai_p1,
                    fechaf_p1,
                    fechai_p2,
                    fechaf_p2,
                    fechai_p3,
                    fechaf_p3);

            ControladorVisual.mostrarMensaje(resultadoOperacion);

            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
        }

        private void FrmNuevoSemestre_Load(object sender, EventArgs e)
        {
            nudAnoiP1.Maximum = DateTime.Today.Year + 1;
            nudAnofP1.Maximum = DateTime.Today.Year + 1;
            nudAnoiP2.Maximum = DateTime.Today.Year + 1;
            nudAnofP2.Maximum = DateTime.Today.Year + 1;
            nudAnoiP3.Maximum = DateTime.Today.Year + 1;
            nudAnofP3.Maximum = DateTime.Today.Year + 1;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configurarDias(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;

            string opcion = nud.Name.Substring(6);

            NumericUpDown nudAno = (NumericUpDown)Controls["nudAno" + opcion];
            NumericUpDown nudMes = (NumericUpDown)Controls["nudMes" + opcion];
            NumericUpDown nudDia = (NumericUpDown)Controls["nudDia" + opcion];

            nudDia.Maximum = diaMaximo((int)nudMes.Value, (int)nudAno.Value);
        }

        private int diaMaximo(int mes, int ano)
        {
            bool bisiesto = ano % 4 == 0;

            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28 + (bisiesto ? 1 : 0);
                default:
                    return 30;
            }
        }
    }
}
