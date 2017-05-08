using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOEstudiantes : DAO
    {
        // SELECTS

        public List<Estudiante> seleccionarEstudiantes()
        {
            string query = "SELECT * FROM estudiantes";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }

        public List<Estudiante> seleccionarEstudiantesPorGrupo(Grupo g)
        {
            string query = "SELECT E.* FROM " + 
                "estudiantes E, grupos_estudiantes G WHERE " + 
                "E.idEstudiante = G.idEstudiante AND " + 
                "G.idGrupo = " + g.idGrupo;

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }

        public List<Estudiante> seleccionarEstudiantesCondicional(
            bool ncontrol,
            bool curp,
            bool nombrecompleto,
            bool nombres,
            bool apellido1,
            bool apellido2,
            bool nss,
            string parametro
        ) {
            string query = "SELECT * FROM estudiantes WHERE ";

            query += crearCondiciones(
                ncontrol,
                curp,
                nombrecompleto,
                nombres,
                apellido1,
                apellido2,
                nss,
                parametro);

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }

        public List<Estudiante> seleccionarEstudiantesPorGrupoCondicional(
            Grupo g,
            bool ncontrol,
            bool curp,
            bool nombrecompleto,
            bool nombres,
            bool apellido1,
            bool apellido2,
            bool nss,
            string parametro
        ) {
            string query = "SELECT E.* FROM " +
                "estudiantes E, grupos_estudiantes G WHERE " +
                "E.idEstudiante = G.idEstudiante AND " +
                "G.idGrupo = " + g.idGrupo + " AND ";

            query += crearCondiciones(
                ncontrol,
                curp,
                nombrecompleto,
                nombres,
                apellido1,
                apellido2,
                nss,
                parametro);

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }

        // INSERTS

        public int insertarEstudiante(Estudiante e)
        {
            string query = "INSERT INTO estudiantes " +
                "(ncontrol, curp, nombrecompleto, nombres, apellido1, apellido2, nss) " + 
                "VALUES (" + 
                "'" + e.ncontrol + "', " +
                "'" + e.curp + "', " +
                "'" + e.nombreCompleto + "', " +
                "'" + e.nombres + "', " +
                "'" + e.apellido1 + "', " +
                "'" + e.apellido2 + "', " +
                "'" + e.nss + "');";

            return dataSource.ejecutarActualizacion(query);
        }

        // DELETES

        public int eliminarEstudiante(Estudiante e)
        {
            string query = "DELETE FROM estudiantes " + 
                "WHERE idEstudiante = " + e.idEstudiante + ";";

            return dataSource.ejecutarActualizacion(query);
        }

        // UPDATES

        public int modificarEstudiante(Estudiante e)
        {
            string query = "UPDATE estudiantes " +
                "SET " +
                "ncontrol = '" + e.ncontrol + "', " +
                "curp = '" + e.curp + "', " +
                "nombrecompleto = '" + e.nombreCompleto + "', " +
                "nombres = '" + e.nombres + "', " +
                "apellido1 = '" + e.apellido1 + "', " +
                "apellido2 = '" + e.apellido2 + "', " +
                "nss = '" + e.nss + "' " +
                "WHERE idEstudiante = " + e.idEstudiante;

            return dataSource.ejecutarActualizacion(query);
        }
        
        // MISC

        private static string crearCondiciones(
            bool ncontrol,
            bool curp,
            bool nombrecompleto,
            bool nombres,
            bool apellido1,
            bool apellido2,
            bool nss,
            string parametro
        ) {
            bool primero = true;
            string query = "(";

            // Debe ser así la estructura de la consulta
            //string query = "SELECT * FROM estudiantes " +
            //"WHERE ";

            if (ncontrol)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "ncontrol LIKE '%" + parametro + "%' ";
            }

            if (curp)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "curp LIKE '%" + parametro + "%' ";
            }

            if (nombrecompleto)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "nombrecompleto LIKE '%" + parametro + "%' ";
            }

            if (nombres)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "nombres LIKE '%" + parametro + "%' ";
            }

            if (apellido1)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "apellido1 LIKE '%" + parametro + "%' ";
            }

            if (apellido2)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "apellido2 LIKE '%" + parametro + "%' ";
            }

            if (nss)
            {
                if (primero)
                {
                    primero = !primero;
                }
                else
                {
                    query += "OR ";
                }

                query += "nss LIKE '%" + parametro + "%' ";
            }

            query += ")";

            return query.Equals("()") ? "FALSE" : query;
        }

        public static Estudiante crearEstudiante(
            int idEstudiante,
            string ncontrol,
            string curp,
            string nombrecompleto,
            string nombres,
            string apellido1,
            string apellido2
        ) {
            Estudiante e = new Estudiante();

            e.apellido1 = apellido1;
            e.apellido2 = apellido2;
            e.curp = curp;
            e.idEstudiante = idEstudiante;
            e.ncontrol = ncontrol;
            e.nombreCompleto = nombrecompleto;
            e.nombres = nombres;

            return e;
        }

        public static List<Estudiante> crearListaEstudiantesMySqlDataReader(MySqlDataReader dr)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            while (dr.Read())
            {
                Estudiante e = crearEstudiante(
                    Convert.ToInt32(dr["idEstudiante"]),
                    dr["ncontrol"].ToString(),
                    dr["curp"].ToString(),
                    dr["nombrecompleto"].ToString(),
                    dr["nombres"].ToString(),
                    dr["apellido1"].ToString(),
                    dr["apellido2"].ToString()
                );

                listaEstudiantes.Add(e);
            }

            dr.Close();

            return listaEstudiantes;
        }
    }
}
