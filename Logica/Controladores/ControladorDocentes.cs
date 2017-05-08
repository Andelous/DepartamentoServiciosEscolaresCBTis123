using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorDocentes
    {
        private DAODocentes daoDocentes { get; set; }

        public ControladorDocentes()
        {
            this.daoDocentes = new DAODocentes();
        }
    }
}
