using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOCalificaciones : DAO
    {

        // SELECT
        public List<Calificacion> seleccionarCalificaciones(Catedra c)
        {
            string query = "SELECT * FROM calificaciones WHERE idCatedra = " + c.idCatedra;

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCalificacionesMySqlDataReader(dr);
        }




        // MISC

        public static List<Calificacion> crearListaCalificacionesMySqlDataReader(MySqlDataReader dr)
        {
            List<Calificacion> lista = new List<Calificacion>();

            while (dr.Read())
            {

            }

            dr.Close();

            return lista;
        }
    }
}
