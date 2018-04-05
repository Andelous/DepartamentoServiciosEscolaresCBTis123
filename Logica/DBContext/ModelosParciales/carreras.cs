using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class carreras
    {
        // Métodos míos
        public override string ToString()
        {
            return acuerdo + " - " + nombre + " (" + abreviatura + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    carreras c = (carreras)obj;

                    return c.idCarrera == idCarrera;
                }
            }

            return false;
        }
    }
}
