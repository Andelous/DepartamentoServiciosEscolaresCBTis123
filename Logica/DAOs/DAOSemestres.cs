using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOSemestres : DAO
    {
        // SELECTS

        public List<Semestre> seleccionarSemestres()
        {
            string query = "SELECT * FROM semestres ORDER BY nombrecorto2 DESC";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaSemestresMySqlDataReader(dr);
        }

        public Semestre seleccionarSemestrePorID(int idSemestre)
        {
            Semestre s = null;

            string query = 
                "SELECT * FROM semestres WHERE " + 
                "idSemestre = " + idSemestre + " ORDER BY nombrecorto2 DESC";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            if (dr.Read())
            {
                s = crearSemestre(
                    Convert.ToInt32(dr["idSemestre"]),
                    dr["nombre"].ToString(),
                    dr["nombrecorto"].ToString(),
                    dr["nombrecorto2"].ToString(),
                    dr["nombrecorto3"].ToString()
                );
            }

            dr.Close();
            return s;
        }


        // INSERTS

        public int insertarSemestre(Semestre s)
        {
            string query = 
                "INSERT INTO semestres " +
                "(nombre, nombrecorto, nombrecorto2, nombrecorto3) " +
                "VALUES " +
                "('" + s.nombre + "', '" + s.nombreCorto + "', '" + s.nombreCorto2 + "', '" + s.nombreCorto3 + "');";

            return dataSource.ejecutarActualizacion(query);
        }


        // DELETES

        public int eliminarSemestre(Semestre s)
        {
            string query = 
                "DELETE FROM semestres " + 
                "WHERE idSemestre = " + s.idSemestre;

            return dataSource.ejecutarActualizacion(query);
        }


        // UPDATES

        public int modificarSemestre(Semestre s) {
            string query = "UPDATE semestres " + 
                "SET " + 
                "nombre = '" + s.nombre + "', " +
                "nombrecorto = '" + s.nombreCorto + "', " +
                "nombrecorto2 = '" + s.nombreCorto2 + "', " +
                "nombrecorto3 = '" + s.nombreCorto3 + "' " +
                "WHERE idSemestre = " + s.idSemestre;

            return dataSource.ejecutarActualizacion(query);
        }


        // MISC

        public static Semestre crearSemestre(
            int idSemestre, 
            string nombre, 
            string nombrecorto, 
            string nombrecorto2, 
            string nombrecorto3
        ) {
            Semestre s = new Semestre();

            s.idSemestre = idSemestre;
            s.nombre = nombre;
            s.nombreCorto = nombrecorto;
            s.nombreCorto2 = nombrecorto2;
            s.nombreCorto3 = nombrecorto3;

            return s;
        }

        public static List<Semestre> crearListaSemestresMySqlDataReader(MySqlDataReader dr)
        {
            List<Semestre> listaSemestres = new List<Semestre>();

            while (dr.Read())
            {
                Semestre s = crearSemestre(
                    Convert.ToInt32(dr["idSemestre"]),
                    dr["nombre"].ToString(),
                    dr["nombrecorto"].ToString(),
                    dr["nombrecorto2"].ToString(),
                    dr["nombrecorto3"].ToString()
                );

                listaSemestres.Add(s);
            }

            dr.Close();

            return listaSemestres;
        }
    }
}
