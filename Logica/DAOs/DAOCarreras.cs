using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOCarreras : DAO
    {
        // SELECTS
        public List<Carrera> seleccionarCarrerasPorAcuerdo(string acuerdo)
        {
            string query = "SELECT * FROM carreras WHERE acuerdo = '" + acuerdo + "'";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCarrerasMySqlDataReader(dr);
        }


        // MISC

        public static Carrera crearCarrera(
            int idCarrera,
            string nombre,
            string abreviatura,
            string acuerdo,
            string bachilleratoCiencias)
        {
            Carrera c = new Carrera();

            c.abreviatura = abreviatura;
            c.acuerdo = acuerdo;
            c.bachilleratoCiencias = bachilleratoCiencias;
            c.idCarrera = idCarrera;
            c.nombre = nombre;

            return c;
        }

        public static List<Carrera> crearListaCarrerasMySqlDataReader(MySqlDataReader dr)
        {
            List<Carrera> listaCarreras = new List<Carrera>();

            while (dr.Read())
            {
                Carrera c = crearCarrera(
                    Convert.ToInt32(dr["idCarrera"]),
                    dr["nombre"].ToString(),
                    dr["abreviatura"].ToString(),
                    dr["acuerdo"].ToString(),
                    dr["bachilleratociencias"].ToString()
                );

                listaCarreras.Add(c);
            }

            dr.Close();

            return listaCarreras;
        }
    }
}
