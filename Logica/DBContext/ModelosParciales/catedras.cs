using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class catedras
    {
        // Métodos míos
        public override string ToString()
        {
            return materias.ToString() + " (" + docentes.ToString() + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    catedras c = (catedras)obj;

                    return c.idCatedra == idCatedra;
                }
            }

            return false;
        }
    }
}
