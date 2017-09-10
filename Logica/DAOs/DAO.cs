using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
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
            dataSource = new MySqlDataSourceGeneric(Vinculo_DB.server, Vinculo_DB.puerto, Vinculo_DB.userID, Vinculo_DB.password, Vinculo_DB.database);
        }
    }
}
