using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }

        public string ncontrol { get; set; }
        public string curp { get; set; }
        public string nombreCompleto { get; set; }
        public string nombres { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nss { get; set; }

        public override string ToString()
        {
            return apellido1.Trim() + " " + apellido2.Trim() + " " + nombres.Trim();
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Estudiante))
                {
                    Estudiante estudiante = (Estudiante)obj;

                    if (estudiante.idEstudiante == idEstudiante)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
