using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class docentes
    {
        // Propiedades mías
        public string nombrecompleto
        {
            get
            {
                return apellidop.Trim() + " " + apellidom.Trim() + " " + nombres.Trim();
            }
        }

        // Métodos míos
        public override string ToString()
        {
            return nombrecompleto;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == GetType())
                {
                    docentes d = (docentes)obj;

                    return d.idDocente == idDocente;
                }
            }

            return false;
        }
    }
}
