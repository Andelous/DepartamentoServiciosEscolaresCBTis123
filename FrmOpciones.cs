using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoServiciosEscolaresCBTis123
{
    public partial class FrmOpciones : Form
    {
        public FrmOpciones()
        {
            InitializeComponent();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            string[] host = { txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtServidor.Text.Trim(), txtDefaultDB.Text.Trim(), txtPuerto.Text.Trim() };

            File.WriteAllLines("host.sys", host);

            MessageBox.Show("Guardado");
            Close();
        }

        private void FrmOpciones_Load(object sender, EventArgs e)
        {
            string[] datos = new string[5];

            if (File.Exists("host.sys"))
            {
                datos = File.ReadAllLines("host.sys");
            }
            else
            {
                datos = new string[] { "Sin especificar", "Sin especificar", "Sin especificar", "Sin especificar", "Sin especificar" };
            }

            try
            {
                txtUsuario.Text = datos[0];
            }
            catch (Exception)
            {
                txtUsuario.Text = "Sin especificar";
            }

            //try
            //{
            //    txtContrasena.Text = datos[1];
            //}
            //catch (Exception)
            //{
            //    txtContrasena.Text = "Sin especificar";
            //}

            try
            {
                txtServidor.Text = datos[2];
            }
            catch (Exception)
            {
                txtServidor.Text = "Sin especificar";
            }

            try
            {
                txtDefaultDB.Text = datos[3];
            }
            catch (Exception)
            {
                txtDefaultDB.Text = "Sin especificar";
            }

            try
            {
                txtPuerto.Text = datos[4];
            }
            catch (Exception)
            {
                txtPuerto.Text = "Sin especificar";
            }
        }
    }
}
