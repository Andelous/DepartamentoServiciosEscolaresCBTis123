using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmModificarGrupo : Form
    {
        private ControladorSesion controladorSesion;
        private Grupo grupo;

        public FrmModificarGrupo(ControladorSesion controladorSesion, Grupo grupo)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.grupo = grupo;
        }

        private void FrmModificarGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = controladorSesion.daoSemestres.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorSesion.daoCarreras.seleccionarCarrerasPorAcuerdo("653");

            comboSemestres.SelectedItem = grupo.semestreObj;
            comboGrado.SelectedIndex = grupo.semestre - 1;
            txtLetra.Text = grupo.letra;
            comboTurno.SelectedItem = grupo.turno;
            comboEspecialidad.SelectedItem = grupo.especialidadObj;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (txtLetra.Text.Length > 0)
            {
                char letra = txtLetra.Text.ToUpper()[0];

                if (letra >= 65 && letra <= 90)
                {
                    Semestre s = (Semestre)comboSemestres.SelectedItem;

                    if (controladorSesion.
                        daoGrupos.
                        modificarGrupo(
                            grupo.idGrupo,
                            s.idSemestre,
                            comboGrado.SelectedIndex + 1,
                            letra.ToString(),
                            comboTurno.Text[0].ToString(),
                            ((Carrera)comboEspecialidad.SelectedItem).abreviatura
                        ) == 1)
                    {
                        MessageBox.Show("Grupo modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
