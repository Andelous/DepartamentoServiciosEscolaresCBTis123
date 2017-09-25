using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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
    public partial class FrmModificarSemestre : Form
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

        private semestres semestre { get; set; }

        public FrmModificarSemestre(semestres semestre)
        {
            InitializeComponent();
            
            this.semestre = semestre;
        }

        private void FrmModificarSemestre_Load(object sender, EventArgs e)
        {
            txtNombre.Text = semestre.nombre;
            txtNombreCorto.Text = semestre.nombrecorto;
            txtNombreCorto2.Text = semestre.nombrecorto2;
            txtNombreCorto3.Text = semestre.nombrecorto3;

            if (semestre.fechai_p1.HasValue && semestre.fechaf_p1.HasValue)
            {
                configurarNuds(semestre.fechai_p1.Value, semestre.fechaf_p1.Value, "P1");
            }

            if (semestre.fechai_p2.HasValue && semestre.fechaf_p2.HasValue)
            {
                configurarNuds(semestre.fechai_p2.Value, semestre.fechaf_p2.Value, "P2");
            }

            if (semestre.fechai_p3.HasValue && semestre.fechaf_p3.HasValue)
            {
                configurarNuds(semestre.fechai_p3.Value, semestre.fechaf_p3.Value, "P3");
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            ResultadoOperacion resultadoOperacion = 
                controladorSemestres.
                modificarSemestre(
                    semestre.idSemestre,
                    txtNombre.Text,
                    txtNombreCorto.Text,
                    txtNombreCorto2.Text,
                    txtNombreCorto3.Text
                );

            ControladorVisual.mostrarMensaje(resultadoOperacion);

            if (resultadoOperacion.estadoOperacion == EstadoOperacion.Correcto)
            {
                Close();
            }
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

        private void configurarNuds(DateTime fechaI, DateTime fechaF, string p)
        {
            NumericUpDown diaI = (NumericUpDown)Controls["nudDiai" + p];
            NumericUpDown diaF = (NumericUpDown)Controls["nudDiaf" + p];

            NumericUpDown mesI = (NumericUpDown)Controls["nudMesi" + p];
            NumericUpDown mesF = (NumericUpDown)Controls["nudMesf" + p];

            NumericUpDown anoI = (NumericUpDown)Controls["nudAnoi" + p];
            NumericUpDown anoF = (NumericUpDown)Controls["nudAnof" + p];

            diaI.Value = fechaI.Day;
            diaF.Value = fechaF.Day;

            mesI.Value = fechaI.Month;
            mesF.Value = fechaF.Month;

            anoI.Value = fechaI.Year;
            anoF.Value = fechaF.Year;
        }
    }
}
