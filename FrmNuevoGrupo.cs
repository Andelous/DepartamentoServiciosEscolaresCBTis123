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
    public partial class FrmNuevoGrupo : Form
    {
        private ControladorSesion controladorSesion;

        public FrmNuevoGrupo(ControladorSesion controladorSesion)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
        }

        private void FrmNuevoGrupo_Load(object sender, EventArgs e)
        {
            comboSemestres.DataSource = controladorSesion.daoSemestres.seleccionarSemestres();
            comboEspecialidad.DataSource = controladorSesion.daoCarreras.seleccionarCarrerasPorAcuerdo("653");

            comboEspecialidad.SelectedIndex = 0;
            comboGrado.SelectedIndex = 0;
            comboTurno.SelectedIndex = 0;
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            if (txtLetra.Text.Length > 0)
            {
                char letra = txtLetra.Text.ToUpper()[0];

                if (letra >= 65 && letra <= 90)
                {
                    Semestre s = (Semestre)comboSemestres.SelectedItem;

                    if (controladorSesion.
                        daoGrupos.
                        insertarGrupo(
                            s.idSemestre,
                            comboGrado.SelectedIndex + 1,
                            letra.ToString(),
                            comboTurno.Text[0].ToString(),
                            ((Carrera)comboEspecialidad.SelectedItem).abreviatura
                        ) == 1)
                    {
                        // HACER INSERCION DE CATEDRAS
                        Grupo g = DAOGrupos.crearGrupo(
                            (int)controladorSesion.daoGrupos.dataSource.ultimoIDInsertado,
                            s.idSemestre,
                            comboGrado.SelectedIndex + 1,
                            letra.ToString(),
                            comboTurno.Text[0].ToString(),
                            ((Carrera)comboEspecialidad.SelectedItem).abreviatura,
                            (Semestre)comboSemestres.SelectedItem,
                            (Carrera)comboEspecialidad.SelectedItem
                        );

                        List<Materia> listaMaterias = controladorSesion.daoMaterias.seleccionarMateriasSegunGrupo(g);

                        if (controladorSesion.daoCatedras.insertarCatedrasGrupoMaterias(g, listaMaterias) == 0)
                        {
                            MessageBox.Show("Error al registrar las materias del grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        MessageBox.Show("Grupo registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Rellene los campos de forma correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
