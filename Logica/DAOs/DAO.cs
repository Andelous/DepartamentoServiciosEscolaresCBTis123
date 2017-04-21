using MySqlDataSource;
using MySqlUtilerias.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public abstract class DAO
    {
        public IMySqlDataSource dataSource { get; set; }

        public DAO(IMySqlDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public DAO()
        {
            dataSource = new MySqlDataSourceLocal();
        }
    }
}
