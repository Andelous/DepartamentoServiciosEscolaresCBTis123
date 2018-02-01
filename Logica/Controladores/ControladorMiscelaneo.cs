using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using HtmlAgilityPack;
using Microsoft.Office.Interop.Excel;
using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public static class ControladorMiscelaneo
    {
        static ControladorMiscelaneo()
        {
            // Versión de la aplicación...
            versionLocal = typeof(ControladorMiscelaneo).Assembly.GetName().Version.ToString().Substring(0, 3);
            seleccionarVersionMasReciente();

            // Fecha de hoy en el servidor
            seleccionarFechaServidor();
        }

        private static string versionLocal { get; set; }
        private static string versionServidor { get; set; }

        private static DateTime _dtTest = new DateTime(2010, 1, 10);
        public static DateTime dtTest
        {
            get
            {
                return _dtTest;
            }
        }

        private static DateTime _dtServidor;
        public static DateTime dtServidor
        {
            get
            {
                return _dtServidor;
            }
        }

        public static string[][] crearTablaDeHtml(string cadenaHtml)
        {
            // Cargamos el HTML a un documento.
            HtmlDocument documento = new HtmlDocument();
            documento.LoadHtml(cadenaHtml);

            // Leemos la tabla que nos interesa, por medio de su clase.
            HtmlNodeCollection tabla = documento.DocumentNode.SelectNodes("//table[@class=\"fancy\"]");

            // Leemos las filas de la tabla.
            HtmlNodeCollection filas = tabla[tabla.Count - 1].SelectNodes(".//tr");

            // Creamos el arreglo de cadenas según el número de filas.
            string[][] tablaDeCadenas = new string[filas.Count][];


            for (int i = 0; i < filas.Count; i++)
            {
                // Iteramos sobre el arreglo de arreglos ya creado.
                // Para cada posición del arreglo, se creará un arreglo de cadenas
                // que contendrá los valores de cada una de las TD encontradas.


                // Primero sacamos todos las TD de la fila en que estamos
                HtmlNode fila = filas[i];
                HtmlNodeCollection celdas = fila.SelectNodes("./td");

                // Si posee celdas, entonces procedemos ...
                if (celdas != null)
                {
                    // ... a crear un nuevo arreglo de cadenas, que
                    // contendrá tantos datos como celdas haya habido
                    tablaDeCadenas[i] = new string[celdas.Count];

                    for (int j = 0; j < celdas.Count; j++)
                    {
                        // Decisión de en qué parte de los TD estamos.
                        switch (j)
                        {
                            // Texto plano
                            case 0:
                            case 1:
                            case 2:
                                tablaDeCadenas[i][j] = celdas[j].InnerHtml;
                                break;

                            // Inputs tipo texto <input type="text">
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                                HtmlNode input = celdas[j].SelectSingleNode("./input");
                                tablaDeCadenas[i][j] = input.GetAttributeValue("value", null);
                                break;

                            // <select> y <option>
                            case 11:
                                HtmlNode option = celdas[j].SelectSingleNode(".//option[@selected]");
                                tablaDeCadenas[i][j] = option.GetAttributeValue("value", null);
                                break;

                            // <input type="checkbox">
                            case 12:
                                HtmlNode checkbox = celdas[j].SelectSingleNode("./input[@checked]");
                                tablaDeCadenas[i][j] = (checkbox != null).ToString();
                                break;

                            default:
                                tablaDeCadenas[i][j] = celdas[j].InnerHtml;
                                break;
                        }



                        //tablaDeCadenas[i][j] = celdas[j].InnerHtml;
                    }
                }
                // Si no posee, entonces agregamos un arreglo con capacidad 0
                else
                {
                    tablaDeCadenas[i] = new string[0];
                }
            }

            return tablaDeCadenas;
        }

        public static int compararNullableDouble(double? n1, double? n2)
        {
            if (n1.HasValue ^ n2.HasValue)
            {
                return n1.HasValue ? 1 : -1;
            }

            if (!n1.HasValue && !n2.HasValue)
            {
                return 0;
            }

            if (n1.Value > n2.Value)
            {
                return 1;
            }
            else if (n2.Value > n1.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static bool? isAplicacionActualizada()
        {
            seleccionarVersionMasReciente();
            seleccionarFechaServidor();

            if (versionServidor == null)
            {
                return null;
            }

            return versionLocal == versionServidor;
        }

        public static bool? validarVersion()
        {
            bool? valor = isAplicacionActualizada();

            switch (valor)
            {
                case true:
                    break;
                case false:
                    ResultadoOperacion ro2 =
                    new ResultadoOperacion(
                        EstadoOperacion.NingunResultado,
                        "No es posible utilizar la aplicación ya que no cuenta con la última versión. " +
                        "(Versión actual " + versionLocal + " | Versión más reciente " + versionServidor + ")",
                        "VerAct " + versionLocal
                    );

                    ControladorVisual.mostrarMensaje(ro2);
                    break;
                case null:
                    ResultadoOperacion ro3 =
                    new ResultadoOperacion(
                        EstadoOperacion.ErrorAplicacion,
                        "No fue posible verificar la versión de la aplicación. Verifique la conexión al servidor.",
                        "VerAct " + versionLocal
                    );

                    ControladorVisual.mostrarMensaje(ro3);
                    break;
            }

            return valor;
        }

        public static void mostrarExcel(string[][] listaDatos)
        {
            Application xls = new Application();

            if (xls == null)
            {
                System.Windows.Forms.MessageBox.Show(
                    "No se pudo iniciar Excel. Verifique su instalación de Office.",
                    "Advertencia",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
            }
            else
            {
                xls.Visible = true;

                Workbook wb = xls.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.Worksheets[1];

                for (int i = 0; i < listaDatos.Length; i++)
                {
                    for (int j = 0; j < listaDatos[i].Length; j++)
                    {

                        ws.Cells[i + 1, j + 1] = listaDatos[i][j];
                    }
                }
            }
        }

        public static string[][] matricularSemestre(semestres s)
        {
            // Preparamos el contexto
            CBTis123_Entities db = Vinculo_DB.generarContexto();

            // Lista que contendrá todos los grupos.
            List<grupos> listaGruposOriginal = new List<grupos>();
            // Arreglo de listas que contendrán 
            // los grupos clasificados por grado
            List<grupos>[] arrGruposPorGrado = new List<grupos>[8];

            for (int i = 0; i < arrGruposPorGrado.Length; i++)
            {
                arrGruposPorGrado[i] = new List<grupos>();
            }
            
            // Arreglo de la matrícula de todos los grupos.
            string[][] matriculaSemestral = null;

            try
            {
                // Obtenemos todos los grupos
                listaGruposOriginal = db.grupos.Where(
                    g => g.idSemestre == s.idSemestre
                ).ToList();
                
                // El 8 es por los 4 posibles grados que puede
                // haber simultáneamente en un semestre.
                // Uno es una línea de espacio. El otro es una
                // línea para información general del grado
                matriculaSemestral = new string[listaGruposOriginal.Count + 9][];

                // Los clasificamos según el grado, a la posición del arreglo
                foreach (grupos g in listaGruposOriginal)
                {
                    arrGruposPorGrado[g.semestre - 1].Add(g);
                }

                // Contador de posición en la matrícula [i][]
                int i = 0;

                // Iteramos sobre todos los grados.
                foreach (List<grupos> lista in arrGruposPorGrado)
                {
                    if (lista.Count == 0)
                        continue;

                    // Primero, los ordenamos según la matrícula oficial
                    List<grupos> listaAux = lista.OrderBy(
                        g => g.especialidad
                    ).ThenBy(
                        g => g.turno
                    ).ThenBy(
                        g => g.letra
                    ).ToList();

                    // Luego declaramos los datos extra
                    int gruposM = 0;
                    int gruposV = 0;

                    int hombresM = 0;
                    int hombresV = 0;

                    int mujeresM = 0;
                    int mujeresV = 0;

                    int totalM = 0;
                    int totalV = 0;

                    // Iteramos sobre todos los grupos de un grado específico.
                    // El resultado de la matriculación de ese grupo será añadido
                    // al arreglo de la matrícula semestral.
                    foreach (grupos g in listaAux)
                    {
                        string[] matriculaGrupo = matricularGrupo(g);
                        matriculaSemestral[i] = matriculaGrupo;
                        i++;

                        // Se realizan cálculos extra para los datos extra
                        if (g.turno.ToUpper() == "M")
                        {
                            gruposM++;
                            hombresM += Convert.ToInt32(matriculaGrupo[4]);
                            mujeresM += Convert.ToInt32(matriculaGrupo[5]);
                            totalM += Convert.ToInt32(matriculaGrupo[6]);
                        }

                        if (g.turno.ToUpper() == "V")
                        {
                            gruposV++;
                            hombresV += Convert.ToInt32(matriculaGrupo[4]);
                            mujeresV += Convert.ToInt32(matriculaGrupo[5]);
                            totalV += Convert.ToInt32(matriculaGrupo[6]);
                        }
                    }

                    // Se deja un espacio al final de todos los grupos de tal grado.
                    // Se rellena con datos extras.

                    matriculaSemestral[i] = new string[7];

                    matriculaSemestral[i][2] = listaAux.Count.ToString() + " grupos";
                    matriculaSemestral[i][3] = gruposM.ToString();
                    matriculaSemestral[i][4] = hombresM.ToString();
                    matriculaSemestral[i][5] = mujeresM.ToString();
                    matriculaSemestral[i][6] = totalM.ToString();
                    
                    i++;


                    matriculaSemestral[i] = new string[8];
                    
                    matriculaSemestral[i][3] = gruposV.ToString();
                    matriculaSemestral[i][4] = hombresV.ToString();
                    matriculaSemestral[i][5] = mujeresV.ToString();
                    matriculaSemestral[i][6] = totalV.ToString();
                    matriculaSemestral[i][7] = (totalM + totalV).ToString();

                    i++;

                    matriculaSemestral[i] = new string[1];
                    i++;
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(
                    ControladorExcepciones.crearResultadoOperacionException(e)
                );
            }

            return matriculaSemestral;
        }

        public static string[] matricularGrupo(grupos g)
        {
            // Fila de matrícula
            string[] matriculaGrupo = new string[7];

            // Contador de posición
            int i = 0;
            
            matriculaGrupo[i++] = g.especialidadCompleta;
            matriculaGrupo[i++] = g.semestre + g.letra;
            matriculaGrupo[i++] = g.ToString();
            matriculaGrupo[i++] = g.turnoCompleto;

            // Seleccionamos los alumnos del grupo
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            try
            {
                // Usamos el DAO, porque es un poco
                // más fácil que con el modelo de ADO.
                Grupo g1 = new Grupo();
                g1.idGrupo = g.idGrupo;

                listaEstudiantes = 
                    ControladorSingleton.
                    controladorEstudiantes.
                    seleccionarEstudiantesPorGrupo(g1);


                // Realizamos la cuenta de cuántos
                // hombres y cuántas mujeres
                int hombres = 0;
                int mujeres = 0;

                foreach (Estudiante e in listaEstudiantes)
                {
                    string sexo = e.curp[10].ToString().ToUpper();

                    if (sexo == "H")
                        hombres++;

                    if (sexo == "M")
                        mujeres++;
                }

                matriculaGrupo[i++] = hombres.ToString();
                matriculaGrupo[i++] = mujeres.ToString();
                matriculaGrupo[i++] = (hombres + mujeres).ToString();
            }
            catch (Exception e)
            {
                matriculaGrupo[i++] = "Error al contabilizar estudiantes";
                matriculaGrupo[i++] = e.Message;
            }

            return matriculaGrupo;
        }

        private static void seleccionarVersionMasReciente()
        {
            CBTis123_Entities db = Vinculo_DB.generarContexto();
            datos_varios version = null;

            try
            {
                version = db.datos_varios.Single(dv => dv.nombre == "version");
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
                version = new datos_varios();
                version.valor = null;
            }

            versionServidor = version.valor;
        }

        private static void seleccionarFechaServidor()
        {
            try
            {
                DAOMisc dao = new DAOMisc();

                DateTime dt = dao.seleccionarFechaServidor();
                _dtServidor = dt;
            }
            catch (Exception)
            {
                _dtServidor = _dtTest;
            }
        }
    }
}
