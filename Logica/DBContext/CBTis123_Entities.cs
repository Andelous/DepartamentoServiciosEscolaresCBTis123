using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class CBTis123_Entities : DbContext
    {
        public CBTis123_Entities(string connectionString) : base(connectionString) { }
    }
}
