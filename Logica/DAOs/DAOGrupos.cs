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

        public Grupo seleccionarGrupo(int idGrupo)
        {
            string query = "SELECT *, C.nombre AS carrera_nombre FROM grupos G, semestres S, carreras C " +
                "WHERE G.idGrupo = " + idGrupo + " AND G.idSemestre = S.idSemestre AND G.idCarrera = C.idCarrera " +
                "ORDER BY semestre, turno, especialidad, letra;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            List<Grupo> listaGrupo = crearListaGruposMySqlDataReader(dr);

            return listaGrupo[0];
        }

        public List<Grupo> seleccionarGrupos()
        {
            string query = "SELECT *, C.nombre AS carrera_nombre FROM grupos G, semestres S, carreras C " +
                "WHERE G.idSemestre = S.idSemestre AND G.idCarrera = C.idCarrera " +
                "ORDER BY semestre, turno, especialidad, letra;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaGruposMySqlDataReader(dr);
        }

        public List<Grupo> seleccionarGruposPorSemestre(Semestre s)
        {
            string query = "SELECT *, C.nombre AS carrera_nombre FROM grupos G, semestres S, carreras C " +
                "WHERE G.idSemestre = " + s.idSemestre + " AND " +
                "G.idSemestre = S.idSemestre AND G.idCarrera = C.idCarrera " +
                "ORDER BY semestre, turno, especialidad, letra;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaGruposMySqlDataReader(dr);
        }

        // INSERTS

        public int insertarGrupo(Grupo g)
        {
            string query = "INSERT INTO grupos " + 
                "(idSemestre, semestre, letra, turno, especialidad) " +
                "VALUES " + 
                "(" + g.idSemestre + 
                ", " + g.semestre + 
                ", '" + g.letra + 
                "', '" + g.turno[0] + 
                "', '" + g.especialidad + 
                "');";

            return dataSource.ejecutarActualizacion(query);
        }


        // DELETES

        public int eliminarGrupo(Grupo g)
        {
            string query =
                "DELETE FROM grupos " +
                "WHERE idGrupo = " + g.idGrupo;

            return dataSource.ejecutarActualizacion(query);
        }


        // UPDATES

        public int modificarGrupo(Grupo g)
        {
            string query = "UPDATE grupos " + 
                "SET " +
                "idSemestre = " + g.idSemestre + ", " +
                "semestre = " + g.semestre + ", " +
                "letra = '" + g.letra + "', " +
                "turno = '" + g.turno[0] + "', " +
                "especialidad = '" + g.especialidad + "' " +
                "WHERE idGrupo = " + g.idGrupo;

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
        ) {
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
        
        public static List<Grupo> crearListaGruposMySqlDataReader(MySqlDataReader dr)
        {
            List<Grupo> listaGrupos = new List<Grupo>();

            while (dr.Read())
            {
                Semestre s = 
                    DAOSemestres.crearSemestre(
                        Convert.ToInt32(dr["idSemestre"]),
                        dr["nombre"].ToString(),
                        dr["nombrecorto"].ToString(),
                        dr["nombrecorto2"].ToString(),
                        dr["nombrecorto3"].ToString());

                Carrera c = 
                    DAOCarreras.crearCarrera(
                        Convert.ToInt32(dr["idCarrera"]),
                        dr["carrera_nombre"].ToString(),
                        dr["abreviatura"].ToString(),
                        dr["acuerdo"].ToString(),
                        dr["bachilleratociencias"].ToString());

                Grupo g = crearGrupo(
                    Convert.ToInt32(dr["idGrupo"]),
                    Convert.ToInt32(dr["idSemestre"]),
                    Convert.ToInt32(dr["semestre"]),
                    dr["letra"].ToString(),
                    dr["turno"].ToString(),
                    dr["especialidad"].ToString(),
                    s,
                    c);

                listaGrupos.Add(g);
            }

            dr.Close();

            return listaGrupos;
        }
    }
}
