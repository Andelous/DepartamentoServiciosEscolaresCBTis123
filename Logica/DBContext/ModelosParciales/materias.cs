using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class materias
    {
        // Métodos míos
        public override string ToString()
        {
            return nombre + " " + abreviatura;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    materias m = (materias)obj;

                    return m.idMateria == idMateria;
                }
            }

            return false;
        }
    }
}
