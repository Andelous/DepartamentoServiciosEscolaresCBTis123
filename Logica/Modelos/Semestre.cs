using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Semestre
    {
        public int idSemestre { get; set; }
        public string nombre { get; set; }
        public string nombreCorto { get; set; }
        public string nombreCorto2 { get; set; }
        public string nombreCorto3 { get; set; }

        public override string ToString()
        {
            return nombre + " (" + nombreCorto2 + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Semestre))
            {
                Semestre s = (Semestre)obj;

                if (s.idSemestre == idSemestre)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
