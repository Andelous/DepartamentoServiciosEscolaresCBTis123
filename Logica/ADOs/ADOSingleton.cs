using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.ADOs
{
    public class ADOSingleton
    {
        private static cbtislocalEntities _cbtislocal = new cbtislocalEntities();
        public static cbtislocalEntities cbtislocal
        {
            get
            {
                return _cbtislocal;
            }
        }
    }
}
