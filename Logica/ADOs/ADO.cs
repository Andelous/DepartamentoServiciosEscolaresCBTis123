using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.ADOs
{
    public class ADO
    {
        protected cbtislocalEntities dataContext
        {
            get
            {
                return ADOSingleton.cbtislocal;
            }
        }
    }
}
