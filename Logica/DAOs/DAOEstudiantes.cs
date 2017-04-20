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

        public List<Estudiante> seleccionarEstudiantesPorGrupo(int idGrupo)
        {
            string query = "SELECT E.* FROM " + 
                "estudiantes E, grupos_estudiantes G WHERE " + 
                "E.idEstudiante = G.idEstudiante AND " + 
                "G.idGrupo = " + idGrupo;

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
            string parametro)
        {
            string query = "SELECT * FROM estudiantes WHERE (";

            query = agregarCondiciones(
                query,
                ncontrol,
                curp,
                nombrecompleto,
                nombres,
                apellido1,
                apellido2,
                parametro);

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }

        public List<Estudiante> seleccionarEstudiantesPorGrupoCondicional(
            int idGrupo,
            bool ncontrol,
            bool curp,
            bool nombrecompleto,
            bool nombres,
            bool apellido1,
            bool apellido2,
            string parametro)
        {
            string query = "SELECT E.* FROM " +
                "estudiantes E, grupos_estudiantes G WHERE " +
                "E.idEstudiante = G.idEstudiante AND " +
                "G.idGrupo = " + idGrupo + " AND (";

            query = agregarCondiciones(
                query,
                ncontrol,
                curp,
                nombrecompleto,
                nombres,
                apellido1,
                apellido2,
                parametro);

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaEstudiantesMySqlDataReader(dr);
        }


        // INSERTS

        public int insertarEstudiante(
            string ncontrol,
            string curp,
            string nombrecompleto,
            string nombres,
            string apellido1,
            string apellido2,
            string nss
            )
        {
            string query = "INSERT INTO estudiantes " +
                "(ncontrol, curp, nombrecompleto, nombres, apellido1, apellido2, nss) " + 
                "VALUES (" + 
                "'" + ncontrol + "', " +
                "'" + curp + "', " +
                "'" + nombrecompleto + "', " +
                "'" + nombres + "', " +
                "'" + apellido1 + "', " +
                "'" + apellido2 + "', " +
                "'" + nss + "');";

            return dataSource.ejecutarActualizacion(query);
        }

        public int insertarEstudianteEnGrupo(Estudiante e, Grupo g)
        {
            string query =
                "INSERT INTO grupos_estudiantes " +
                "(idGrupo, idEstudiante) " +
                "VALUES " +
                "(" + g.idGrupo + ", " + e.idEstudiante +");";

            return dataSource.ejecutarActualizacion(query);
        }

        public int insertarEstudiantesEnGrupo(List<Estudiante> estudiantes, Grupo g)
        {
            int acum = 0;

            foreach (Estudiante e in estudiantes)
            {
                acum += insertarEstudianteEnGrupo(e, g);
            }

            return acum;
        }


        // DELETES

        public int eliminarEstudiante(int idEstudiante)
        {
            string query = "DELETE FROM estudiantes " + 
                "WHERE idEstudiante = " + idEstudiante + ";";

            return dataSource.ejecutarActualizacion(query);
        }


        // UPDATES

        public int modificarEstudiante(
            int idEstudiante,
            string ncontrol,
            string curp,
            string nombrecompleto,
            string nombres,
            string apellido1,
            string apellido2
            )
        {
            string query = "UPDATE estudiantes " +
                "SET " +
                "ncontrol = '" + ncontrol + "', " +
                "curp = '" + curp + "', " +
                "nombrecompleto = '" + nombrecompleto + "', " +
                "nombres = '" + nombres + "', " +
                "apellido1 = '" + apellido1 + "', " +
                "apellido2 = '" + apellido2 + "' " +
                "WHERE idEstudiante = " + idEstudiante;

            return dataSource.ejecutarActualizacion(query);
        }


        // MISC

        private static string agregarCondiciones(
            string query,
            bool ncontrol,
            bool curp,
            bool nombrecompleto,
            bool nombres,
            bool apellido1,
            bool apellido2,
            string parametro
            )
        {
            bool primero = true;

            // Debe ser así la estructura de la consulta
            //string query = "SELECT * FROM estudiantes " +
                //"WHERE (";

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

            query += ")";

            return query;
        }

        public static Estudiante crearEstudiante(
            int idEstudiante,
            string ncontrol,
            string curp,
            string nombrecompleto,
            string nombres,
            string apellido1,
            string apellido2
            )
        {
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

        public Estudiante crearEstudianteDataGridViewCellCollection(System.Windows.Forms.DataGridViewCellCollection cells)
        {
            Estudiante e = crearEstudiante(
                Convert.ToInt32(cells["idEstudiante"].Value),
                cells["ncontrol"].Value.ToString(),
                cells["curp"].Value.ToString(),
                cells["nombrecompleto"].Value.ToString(),
                cells["nombres"].Value.ToString(),
                cells["apellido1"].Value.ToString(),
                cells["apellido2"].Value.ToString()
            );

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

        public List<Estudiante> crearListaEstudiantesDataGridViewRowCollection(System.Windows.Forms.DataGridViewRowCollection dgvSRC)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            foreach (System.Windows.Forms.DataGridViewRow row in dgvSRC)
            {
                Estudiante e = crearEstudianteDataGridViewCellCollection(row.Cells);
                listaEstudiantes.Add(e);
            }

            return listaEstudiantes;
        }

        public List<Estudiante> crearListaEstudiantesDataGridViewSelectedRowCollection(System.Windows.Forms.DataGridViewSelectedRowCollection dgvSRC)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            foreach (System.Windows.Forms.DataGridViewRow row in dgvSRC)
            {
                Estudiante e = crearEstudianteDataGridViewCellCollection(row.Cells);
                listaEstudiantes.Add(e);
            }

            return listaEstudiantes;
        }
    }
}
