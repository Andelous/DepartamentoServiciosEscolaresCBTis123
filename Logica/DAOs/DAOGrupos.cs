using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOGrupos : DAO
    {
        // SELECTS

        public List<Grupo> seleccionarGrupos()
        {
            List<Grupo> listaGrupos = new List<Grupo>();
            string query = "SELECT * FROM grupos G, semestres S, carreras C " +
                "WHERE G.idSemestre = S.idSemestre AND G.especialidad = C.abreviatura AND C.acuerdo = '653' " +
                "ORDER BY semestre, turno, especialidad, letra;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaGruposMySqlDataReader(dr);
        }

        public List<Grupo> seleccionarGruposPorSemestre(int idSemestre)
        {
            List<Grupo> listaGrupos = new List<Grupo>();
            string query = "SELECT * FROM grupos G, semestres S, carreras C " +
                "WHERE G.idSemestre = " + idSemestre + " AND " +
                "G.idSemestre = S.idSemestre AND G.especialidad = C.abreviatura AND C.acuerdo = '653' " +
                "ORDER BY semestre, turno, especialidad, letra;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaGruposMySqlDataReader(dr);
        }

        // INSERTS

        public int insertarGrupo(
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad
            )
        {
            string query = "INSERT INTO grupos " + 
                "(idSemestre, semestre, letra, turno, especialidad) " +
                "VALUES " + 
                "(" + idSemestre + 
                ", " + semestre + 
                ", '" + letra + 
                "', '" + turno + 
                "', '" + especialidad + 
                "');";

            return dataSource.ejecutarActualizacion(query);
        }


        // DELETES

        public int eliminarGrupo(int idGrupo)
        {
            string query =
                "DELETE FROM grupos " +
                "WHERE idGrupo = " + idGrupo;

            return dataSource.ejecutarActualizacion(query);
        }


        // UPDATES

        public int modificarGrupo(
            int idGrupo,
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad
            )
        {
            string query = "UPDATE grupos " + 
                "SET " +
                "idSemestre = " + idSemestre + ", " +
                "semestre = " + semestre + ", " +
                "letra = '" + letra + "', " +
                "turno = '" + turno + "', " +
                "especialidad = '" + especialidad + "' " +
                "WHERE idGrupo = " + idGrupo;

            return dataSource.ejecutarActualizacion(query);
        }
        
        
        // MISC

        public static Grupo crearGrupo(
            int idGrupo,
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad,
            Semestre semestreObj,
            Carrera especialidadObj
            )
        {
            Grupo g = new Grupo();

            g.idGrupo = idGrupo;
            g.idSemestre = idSemestre;
            g.semestre = semestre;
            g.letra = letra;
            g.turno = turno;
            g.especialidad = especialidad;
            g.semestreObj = semestreObj;
            g.especialidadObj = especialidadObj;

            return g;
        }

        public static Grupo crearGrupoDataGridViewCellCollection(System.Windows.Forms.DataGridViewCellCollection cells)
        {
            Grupo g = crearGrupo(
                Convert.ToInt32(cells["idGrupo"].Value),
                Convert.ToInt32(cells["idSemestre"].Value),
                Convert.ToInt32(cells["semestre"].Value),
                cells["letra"].Value.ToString(),
                cells["turno"].Value.ToString(),
                cells["especialidad"].Value.ToString(),
                (Semestre)cells["semestreObj"].Value,
                (Carrera)cells["especialidadObj"].Value
            );

            return g;
        }

        public static List<Grupo> crearListaGruposMySqlDataReader(MySqlDataReader dr)
        {
            List<Grupo> listaGrupos = new List<Grupo>();

            while (dr.Read())
            {
                Semestre s = new Semestre();
                Carrera c = new Carrera();

                s.idSemestre = Convert.ToInt32(dr["idSemestre"]);
                s.nombre = dr["nombre"].ToString();
                s.nombreCorto = dr["nombrecorto"].ToString();
                s.nombreCorto2 = dr["nombrecorto2"].ToString();

                c = DAOCarreras.crearCarrera(
                    Convert.ToInt32(dr["idCarrera"]),
                    dr[11].ToString(),
                    dr["abreviatura"].ToString(),
                    dr["acuerdo"].ToString(),
                    dr["bachilleratociencias"].ToString()
                );

                Grupo g = crearGrupo(
                    Convert.ToInt32(dr["idGrupo"]),
                    Convert.ToInt32(dr["idSemestre"]),
                    Convert.ToInt32(dr["semestre"]),
                    dr["letra"].ToString(),
                    dr["turno"].ToString(),
                    dr["especialidad"].ToString(),
                    s,
                    c
                );

                listaGrupos.Add(g);
            }

            dr.Close();

            return listaGrupos;
        }
    }
}
