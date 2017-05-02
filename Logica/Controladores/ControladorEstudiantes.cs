using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorEstudiantes
    {
        private DAOEstudiantes daoEstudiantes { get; set; }

        public ControladorEstudiantes()
        {
            this.daoEstudiantes = new DAOEstudiantes();
        }
    }
}
