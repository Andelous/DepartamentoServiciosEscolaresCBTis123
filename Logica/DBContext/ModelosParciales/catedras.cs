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
    }
}
