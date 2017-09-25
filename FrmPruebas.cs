using DepartamentoServiciosEscolaresCBTis123.Logica.Controladores;
using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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
            CBTis123_Entities dbContext = ControladorSingleton.dbContext;
            dataGridView1.DataSource = dbContext.catedras.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cadena = textBox1.Text;

            MessageBox.Show(cadena.Length.ToString());

            char[] chars = cadena.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                DialogResult dr = MessageBox.Show("Posición " + i.ToString() + "\n" + ((int)(chars[i])).ToString() + " - " + chars[i], "Miau", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.Cancel)
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadena = textBox1.Text.Substring(106);
            textBox2.Text = cadena;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(((char)9));
            sb.Append(((char)13));
            sb.Append(((char)10));

            string[] separadores = new string[] { sb.ToString() };

            string[] cadenas = textBox2.Text.Split(separadores, StringSplitOptions.None);

            foreach (string cadena in cadenas)
            {
                MessageBox.Show(cadena);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string documento = webBrowser1.Document.Body.InnerHtml;

            System.IO.File.WriteAllText(@"C:\Users\angel\Desktop\Prueba.txt", documento);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string html = System.IO.File.ReadAllText(@"C:\Users\angel\Desktop\Prueba.html");

            string[][] tabla = ControladorMiscelaneo.crearTablaDeHtml(html);

            StringBuilder nuevaCadena = new StringBuilder();

            bool flag = true;

            for (int i = 0; i < tabla.Length; i++)
            {
                for (int j = 0; j < tabla[i].Length; j++)
                {
                    if (flag)
                    {
                        DialogResult dr = MessageBox.Show(i + "," + j + "\n" + tabla[i][j], "LOL", MessageBoxButtons.OKCancel);
                        flag = dr == DialogResult.OK;
                    }

                    nuevaCadena.Append(tabla[i][j]);
                    nuevaCadena.Append("   ");
                }
                nuevaCadena.Append((char)13);
                nuevaCadena.Append((char)10);
                nuevaCadena.Append((char)13);
                nuevaCadena.Append((char)10);
            }

            System.IO.File.WriteAllText(@"C:\Users\angel\Desktop\Resultado.txt", nuevaCadena.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string html = webBrowser1.Document.Body.InnerHtml;

            string[][] tabla = ControladorMiscelaneo.crearTablaDeHtml(html);

            StringBuilder nuevaCadena = new StringBuilder();

            bool flag = true;

            for (int i = 0; i < tabla.Length; i++)
            {
                for (int j = 0; j < tabla[i].Length; j++)
                {
                    if (flag)
                    {
                        DialogResult dr = MessageBox.Show(i + "," + j + "\n" + tabla[i][j], "LOL", MessageBoxButtons.OKCancel);
                        flag = dr == DialogResult.OK;
                    }

                    nuevaCadena.Append(tabla[i][j]);
                    nuevaCadena.Append("   ");
                }
                nuevaCadena.Append((char)13);
                nuevaCadena.Append((char)10);
                nuevaCadena.Append((char)13);
                nuevaCadena.Append((char)10);
            }

            System.IO.File.WriteAllText(@"C:\Users\angel\Desktop\Resultado.txt", nuevaCadena.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = textBox2.Text;
            string[] s2 = s1.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            string[][] valoresFinales = new string[s2.Length][];

            for (int i = 0; i < s2.Length; i++)
            {
                string s = s2[i];

                valoresFinales[i] = s.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string[] sArr in valoresFinales)
            {
                StringBuilder sFinal = new StringBuilder();

                foreach (string sInd in sArr)
                {
                    sFinal.Append(sInd.Trim() + " | ");
                }

                MessageBox.Show(sFinal.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show((new estudiantes()).idEstudiante.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new DAOMisc().seleccionarFechaServidor().ToString());
        }
    }
}

