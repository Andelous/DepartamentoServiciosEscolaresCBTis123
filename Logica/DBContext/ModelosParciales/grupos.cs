using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class grupos
    {
        // Propiedades mías 
        public string nombreCompleto
        {
            get
            {
                return semestre.ToString() + letra + turno + "-" + especialidad;
            }
        }

        // Métodos míos
        public override string ToString()
        {
            return nombreCompleto;
        }
    }
}
