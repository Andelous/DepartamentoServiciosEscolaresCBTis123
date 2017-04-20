using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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

namespace DepartamentoServiciosEscolaresCBTis123
{
    public partial class FrmAsignacionDeDocentes : Form
    {
        private ControladorSesion controladorSesion;
        private Grupo grupo;
        private List<Catedra> catedras;
        private List<TextBox> txtsCatedras;
        private List<ComboBox> combosDocentes;

        public FrmAsignacionDeDocentes(ControladorSesion controladorSesion, Grupo grupo)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.grupo = grupo;
        }

        private void FrmAsignacionDeDocentes_Load(object sender, EventArgs e)
        {
            // Mostramos el nombre del grupo en el Label rojo
            lblGrupo.Text = grupo.ToString();

            // Mostramos las propiedades del grupo en los Txts de arriba
            txtSemestre.Text = grupo.semestreObj.ToString();
            txtEspecialidad.Text = grupo.especialidadObj.ToString();
            txtGrado.Text = grupo.semestre.ToString() + "° Semestre | Turno: " + grupo.turno;

            // Agregamos el DataSource del comboDocente MODELO
            comboDocentes.DataSource = controladorSesion.daoDocentes.seleccionarDocentes();

            // Agregamos las cátedras que se mostrarán
            catedras = controladorSesion.daoCatedras.seleccionarCatedrasPorGrupo(grupo);

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
                txtNuevo.Location = new Point(11, 129 + i * 67);
                comboNuevo.Location = new Point(241, 146 + i * 67);

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
            Height = 129 + (catedras.Count - 1) * 67 + 150;

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

            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < catedras.Count; i++)
            {
                catedras[i].docenteObj = (Docente)combosDocentes[i].SelectedItem;
                catedras[i].idDocente = catedras[i].docenteObj.idDocente;
            }

            int modificadas = controladorSesion.daoCatedras.modificarListaDeCatedras(catedras);

            if (modificadas == catedras.Count)
            {
                MessageBox.Show("Todas las cátedras modificadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al modificar una o varias cátedras (" + modificadas + " correctas).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
