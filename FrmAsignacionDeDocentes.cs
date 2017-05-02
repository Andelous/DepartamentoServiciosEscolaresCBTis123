using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
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
    public partial class FrmAsignacionDeDocentes : Form
    {
        // Propiedades
        // Controladores
        private ControladorSesion controladorSesion { get; set; }
        private ControladorGrupos controladorGrupos { get; set; }
        
        // Elementos lógicos
        private Grupo grupo { get; set; }
        private List<Catedra> catedras { get; set; }
        private List<TextBox> txtsCatedras { get; set; }
        private List<ComboBox> combosDocentes { get; set; }

        // Métodos de inicialización
        public FrmAsignacionDeDocentes(ControladorSesion controladorSesion, ControladorGrupos controladorGrupos, Grupo grupo)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.controladorGrupos = controladorGrupos;

            this.grupo = grupo;
        }

        private void FrmAsignacionDeDocentes_Load(object sender, EventArgs e)
        {
            // Antes que nada, agregamos las cátedras que se mostrarán
            catedras = controladorGrupos.seleccionarCatedrasPorGrupo(grupo);

            // Si las catedras no existen, se le preguntará al usuario para que
            // se creen en ese momento
            if (catedras.Count == 0)
            {
                DialogResult dr =
                    MessageBox.Show(
                        "Las clases de este grupo no se han registrado aún. ¿Desea registrarlas ahora?",
                        "Aviso",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    ResultadoOperacion resultadoOperacion = 
                        controladorGrupos.
                        registrarCatedras(
                            controladorGrupos.
                            crearListaCatedrasGrupo(grupo));

                    ControladorVisual.mostrarMensaje(resultadoOperacion);

                    catedras = controladorGrupos.seleccionarCatedrasPorGrupo(grupo);
                }
            }

            // Mostramos el nombre del grupo en el Label rojo
            lblGrupo.Text = grupo.ToString();

            // Mostramos las propiedades del grupo en los Txts de arriba
            txtSemestre.Text = grupo.semestreObj.ToString();
            txtEspecialidad.Text = grupo.especialidadObj.ToString();
            txtGrado.Text = grupo.semestre.ToString() + "° Semestre | Turno: " + grupo.turno;

            // Agregamos el DataSource del comboDocente MODELO
            comboDocentes.DataSource = controladorGrupos.seleccionarDocentes();

            // Creamos la lista de Txts y Combos de las cátedras.
            txtsCatedras = new List<TextBox>();
            combosDocentes = new List<ComboBox>();

            // Iteramos la lista de cátedras para mostrar de forma dinámica
            // los componentes de cada cátedra. Cada cátedra en la posición i
            // de la lista de cátedras, tendrá un un TextBox en la lista de TextBoxes
            // en la posición i. De igual forma, para los combos, tendrá un combo en la lista
            // de combos en la posición i.
            for (int i = 0; i < catedras.Count; i++)
            {
                // Creamos el textbox decidiendo qué tipo de cátedra es.
                TextBox txtNuevo =
                    ControladorVisual.clonarTextBox(
                        catedras[i].materiaObj.componenteF.Contains("omplementari") ?
                        txtComplementarioM :
                        catedras[i].materiaObj.idCarrera != 16 ?
                        txtEspecialidadM :
                        catedras[i].materiaObj.propedeutica.Length >= 4 ?
                        txtPropedeuticoM : txtBasicoM
                    );
                // Creamos el combo de la cátedra.
                ComboBox comboNuevo = ControladorVisual.clonarCombo(comboDocentes);
                comboNuevo.MouseWheel += new MouseEventHandler(ControladorVisual.evitarScroll);

                // ESTO TAMBIEN ES FUNCIONAL, PERO LO CAMBIE POR EL
                // OPERADOR TERNARIO DE ARRIBA
                //if (catedras[i].materiaObj.idCarrera != 16)
                //{
                //    txtNuevo = ControladorVisual.clonarTextBox(txtEspecialidadM);
                //}
                //else if (catedras[i].materiaObj.propedeutica.Length >= 4)
                //{
                //    txtNuevo = ControladorVisual.clonarTextBox(txtPropedeuticoM);
                //}
                //else
                //{
                //    txtNuevo = ControladorVisual.clonarTextBox(txtBasicoM);
                //}

                // Calculamos la posición en la pantalla que tendrán los componentes.
                // VER EL LABEL OCULTO DEL FORMULARIO FrmAsignacionDeDocentes.cs
                txtNuevo.Location = new Point(11, 129 + i * 48);
                comboNuevo.Location = new Point(302, 136 + i * 48);

                // Mostramos el nombre de la materia en el TextBox correspondiente.
                txtNuevo.Text = catedras[i].materiaObj.ToString();
                // Agregamos una nueva lista al combo de la cátedra
                comboNuevo.DataSource = ((List<Docente>)comboDocentes.DataSource).ToList();

                // Agregamos el evento que mostrará qué docente está seleccionado para
                // qué materia. SÓLO DEBUGGING
                //comboNuevo.SelectedIndexChanged += comboDocentes_SelectedIndexChanged;

                // Agregamos los componentes a las listas
                txtsCatedras.Add(txtNuevo);
                combosDocentes.Add(comboNuevo);
            }

            // Se calcula el nuevo tamaño de la ventana y la posición del botón
            Height = 129 + (catedras.Count) * 48 + 87;

            Point p1 = new Point(
                cmdGuardar.Location.X,
                Height - 81
            );
            cmdGuardar.Location = p1;

            // Agregamos a la ventana los componentes que creamos
            Controls.AddRange(combosDocentes.ToArray());
            Controls.AddRange(txtsCatedras.ToArray());

            for (int i = 0; i < combosDocentes.Count; i++)
            {
                // Hacemos que el docente seleccionado sea el correspondiente de la cátedra
                combosDocentes[i].SelectedItem = catedras[i].docenteObj;
            }
        }

        // Eventos de controles
        private void comboDocentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < catedras.Count; i++)
                {
                    MessageBox.Show(
                        txtsCatedras[i].Text + "\n" +
                        combosDocentes[i].SelectedItem.ToString()
                    );
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < catedras.Count; i++)
            {
                catedras[i].docenteObj = (Docente)combosDocentes[i].SelectedItem;
                catedras[i].idDocente = catedras[i].docenteObj.idDocente;
            }

            ResultadoOperacion resultadoOperacion = controladorGrupos.modificarListaDeCatedras(catedras);
            ControladorVisual.mostrarMensaje(resultadoOperacion);
        }
    }
}
