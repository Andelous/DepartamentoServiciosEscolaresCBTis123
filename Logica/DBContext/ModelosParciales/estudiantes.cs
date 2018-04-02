using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class estudiantes
    {
        // Métodos míos

        public override string ToString()
        {
            return apellido1.Trim() + " " + apellido2.Trim() + " " + nombres;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    estudiantes e = (estudiantes)obj;

                    return e.idEstudiante == idEstudiante;
                }
            }

            return false;
        }
    }
}
