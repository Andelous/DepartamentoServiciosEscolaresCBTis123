using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.ADOs
{
    public class ADOCarreras : ADO
    {
        // SELECTS
        public List<carreras> seleccionarCarrerasPorAcuerdo(string acuerdo)
        {
            return dataContext.carreras.Where(c => c.acuerdo.Equals(acuerdo)).ToList();
        }

        // MISC

        public static carreras crearCarrera(
            int idCarrera,
            string nombre,
            string abreviatura,
            string acuerdo,
            string bachilleratoCiencias)
        {
            carreras c = new carreras();

            c.abreviatura = abreviatura;
            c.acuerdo = acuerdo;
            c.bachilleratociencias = bachilleratoCiencias;
            c.idCarrera = idCarrera;
            c.nombre = nombre;

            return c;
        }
    }
}
