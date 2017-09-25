using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOMisc : DAO
    {
        public DateTime seleccionarFechaServidor()
        {
            string query = "SELECT NOW();";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            DateTime dt = new DateTime(2010, 1, 1);

            if (dr.Read())
            {
                dt = dr.GetDateTime(0);
            }

            return dt;
        }
    }
}
