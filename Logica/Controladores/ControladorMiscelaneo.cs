using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public static class ControladorMiscelaneo
    {
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
    }
}
