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
    public partial class FrmImportarCalificacionesM : Form
    {
        // Propiedades
        private IList<catedras> catedras { get; set; }
        private IList<calificaciones_semestrales>[] calificacionesCatedras { get; set; }
        private RadioButton[] radiosCatedras { get; set; }

        private Button cmdGuardar { get; set; }

        private int radioSeleccionado
        {
            get
            {
                for (int i = 0; i < radiosCatedras.Length; i++)
                {
                    if (radiosCatedras[i].Checked)
                        return i;
                }

                return -1;
            }
        }
        private catedras catedraActual
        {
            get
            {
                return catedras[radioSeleccionado];
            }
        }

        private grupos grupo { get; set; }

        // Métodos de inicialización 
        public FrmImportarCalificacionesM(IList<catedras> catedras, grupos grupo)
        {
            InitializeComponent();

            this.catedras = catedras;
            this.calificacionesCatedras = new IList<calificaciones_semestrales>[this.catedras.Count];
            this.radiosCatedras = new RadioButton[this.catedras.Count];

            this.grupo = grupo;
        }

        private void FrmImportarCalificacionesM_Load(object sender, EventArgs e)
        {
            // Mostramos los datos del grupo actual
            txtSemestre.Text = grupo.semestres.ToString();
            txtGrado.Text = grupo.semestre + "° Semestre";
            txtTurno.Text = grupo.turnoCompleto;
            txtEspecialidad.Text = grupo.especialidadCompleta;
            txtLetra.Text = grupo.ToString();

            // Inicializamos los Radios
            inicializarPanelIzq();

            // Verificación de las catedras.
            verificarCatedras();
        }

        private void inicializarPanelIzq()
        {
            // Ahora, creamos el panel lateral...
            for (int i = 0; i < radiosCatedras.Length; i++)
            {
                RadioButton rb = new RadioButton();

                // Contenido del radio
                rb.Text = catedras[i].ToString();

                // Check el primer radio
                if (i == 0)
                {
                    rb.Checked = true;
                    rb.Font = new Font(rb.Font, FontStyle.Bold);
                }

                // Prueba para iluminar la posición 5...
                //if (i == 5) { calificacionesCatedras[i] = new List<calificaciones_semestrales>(); calificacionesCatedras[i].Add(null); }

                // Tamaño del radio
                rb.AutoSize = false;
                rb.Width = pnlIzquierdo.Width;
                rb.Height = (int)(rb.Height * 1.5);

                // Evento
                rb.CheckedChanged += cambio;

                radiosCatedras[i] = rb;
            }

            // Agregamos todos los radios
            pnlIzquierdo.Controls.AddRange(radiosCatedras);

            cmdGuardar = new Button();
            cmdGuardar.Text = "Guardar todos";
            cmdGuardar.Width = pnlIzquierdo.Width - 7;
            cmdGuardar.Enabled = false;

            cmdGuardar.Click += cmdGuardar_Click;

            pnlIzquierdo.Controls.Add(cmdGuardar);
        }


        // Métodos de eventos
        private void cmdImportar_Click(object sender, EventArgs e)
        {
            string html = webSiseems.Document.Body.InnerHtml;
            string[][] tabla = ControladorMiscelaneo.crearTablaDeHtml(html);

            List<calificaciones_semestrales> calificacionesSiseems = ControladorAcreditacion.crearListaCalificaciones(tabla, catedraActual.idCatedra, catedraActual);

            List<calificaciones_semestrales> calificacionesActuales = catedraActual.calificaciones_semestrales.ToList();

            new FrmDiferencias(calificacionesActuales, calificacionesSiseems, radioSeleccionado).ShowDialog();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            // Obtenemos los estudiantes de todo el grupo
            IList<estudiantes> listaEstudiantes = ControladorAcreditacion.seleccionarEstudiantesRecursamiento(calificacionesCatedras);

            // Los registramos en la base de datos
            ResultadoOperacion resultadoOperacion = ControladorGrupos_Estudiantes.insertarEstudiantes(listaEstudiantes, grupo);
            //ControladorVisual.mostrarMensaje(resultadoOperacion);

            // Si el estudiante de la calificacion no existe en los alumnos del grupo, se agrega
            // automáticamente como recursamiento.
            foreach (IList<calificaciones_semestrales> listaCs in calificacionesCatedras)
            {
                foreach (calificaciones_semestrales cs in listaCs)
                {
                    estudiantes est = listaEstudiantes.FirstOrDefault(e1 => e1.ncontrol == cs.nControl);

                    if (est == null)
                    {
                        cs.recursamiento = true;
                        cs.verificado = false;
                        MessageBox.Show(cs.estudiantes.ToString());
                    }
                    else
                    {
                        cs.verificado = true;
                    }
                }
            }

            // Aquí finalmente registramos las calificaciones
            int count = 0;
            foreach (IList<calificaciones_semestrales> listaCs in calificacionesCatedras)
            {
                ResultadoOperacion resultadoOperacion1 =
                    ControladorAcreditacion.
                    actualizarCalificacionesDesdeSiseems(listaCs, catedras[count++].ToString());

                ControladorVisual.mostrarMensaje(resultadoOperacion1);
            }
        }

        private void cambio(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                rb.Font = new Font(rb.Font, FontStyle.Bold);
            }
            else
            {
                rb.Font = new Font(rb.Font, FontStyle.Regular);
            }
        }

        // Métodos lógicos
        private void verificarCatedras()
        {
            int count = 0;
            int registradas = 0;
            foreach (IList<calificaciones_semestrales> lista in calificacionesCatedras)
            {
                if (lista == null)
                {
                    radiosCatedras[count++].BackColor = Color.FromArgb(30, 255, 0, 0);
                }
                else
                {
                    radiosCatedras[count++].BackColor = Color.FromArgb(30, 0, 255, 0);
                    registradas++;
                }
            }

            lblCalificacionesRegistradas.Text = registradas + " de " + calificacionesCatedras.Length + " calificaciones importadas.";

            cmdGuardar.Enabled = !(registradas < calificacionesCatedras.Length);
        }

        public void agregarCalificaciones(int pos, IList<calificaciones_semestrales> lista)
        {
            calificacionesCatedras[pos] = lista;
            verificarCatedras();
        }

        private void FrmImportarCalificacionesM_Resize(object sender, EventArgs e)
        {
            Point p = new Point(Width - 187, Height - 84);
            cmdImportar.Location = p;
        }
    }
}
