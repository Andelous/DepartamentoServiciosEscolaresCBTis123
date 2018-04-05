using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Carrera
    {
        public int idCarrera { get; set; }

        public string nombre { get; set; }
        public string abreviatura { get; set; }
        public string acuerdo { get; set; }
        public string bachilleratoCiencias { get; set; }

        public override string ToString()
        {
            return acuerdo + " - " + nombre + " (" + abreviatura + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Carrera))
                {
                    Carrera carrera = (Carrera)obj;

                    if (carrera.idCarrera == idCarrera)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
