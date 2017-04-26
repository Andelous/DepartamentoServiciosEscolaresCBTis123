﻿using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
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
    public partial class FrmModificarDocente : Form
    {
        private ControladorSesion controladorSesion;
        private Docente d;

        public FrmModificarDocente(ControladorSesion controladorSesion, Docente d)
        {
            InitializeComponent();

            this.controladorSesion = controladorSesion;
            this.d = d;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "" &&
                txtApellidoMaterno.Text != "" &&
                txtApellidoPaterno.Text != "" &&
                txtRfc.Text != "" &&
                txtCurp.Text != "")
            {
                string nombres = txtNombres.Text.Trim();
                string apellidoPaterno = txtApellidoPaterno.Text.Trim();
                string apellidoMaterno = txtApellidoMaterno.Text.Trim();

                Docente d = DAODocentes.crearDocente(
                    this.d.idDocente,
                    ".",
                    0,
                    txtCurp.Text.Trim(),
                    txtRfc.Text.Trim(),
                    nombres,
                    apellidoPaterno,
                    apellidoMaterno,
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    ".",
                    new DateTime(2000, 01, 01),
                    "."
                );

                if (
                    controladorSesion.daoDocentes.modificarDocente(d) == 1
                    )
                {
                    MessageBox.Show("Docente modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error al modificar el docente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos de forma correcta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmModificarDocente_Load(object sender, EventArgs e)
        {
            txtNombres.Text = d.nombres;
            txtApellidoMaterno.Text = d.apellidom;
            txtApellidoPaterno.Text = d.apellidop;
            txtCurp.Text = d.curp;
            txtRfc.Text = d.rfc;
        }
    }
}