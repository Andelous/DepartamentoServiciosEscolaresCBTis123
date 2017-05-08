using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOGrupo_Estudiante : DAO
    {
        // SELECTS
        public List<Grupo_Estudiante> seleccionarGrupos_Estudiantes(Estudiante e)
        {
            String query = "SELECT * FROM grupos_estudiantes WHERE idEstudiante = " + e.idEstudiante;

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaGruposEstudiantesMySqlDataReader(dr);
        }

        // INSERTS
        public int insertarEstudianteEnGrupo(Estudiante e, Grupo g)
        {
            string query =
                "INSERT INTO grupos_estudiantes " +
                "(idGrupo, idEstudiante) " +
                "VALUES " +
                "(" + g.idGrupo + ", " + e.idEstudiante + ");";

            return dataSource.ejecutarActualizacion(query);
        }

        // MISC
        public static Grupo_Estudiante crearGrupoEstudiante(
            int idGrupo_Estudiante,
            int idGrupo,
            int idEstudiante,
            Grupo grupoObj,
            Estudiante estudianteObj
        ){
            Grupo_Estudiante ge = new Grupo_Estudiante();

            ge.estudianteObj = estudianteObj;
            ge.grupoObj = grupoObj;
            ge.idEstudiante = idEstudiante;
            ge.idGrupo = idGrupo;
            ge.idGrupo_Estudiante = idGrupo_Estudiante;

            return ge;
        }
        
        public List<Grupo_Estudiante> crearListaGruposEstudiantesMySqlDataReader(MySqlDataReader dr)
        {
            List<Grupo_Estudiante> listaGruposEstudiantes = new List<Grupo_Estudiante>();

            while (dr.Read())
            {
                Grupo_Estudiante ge = crearGrupoEstudiante(
                    Convert.ToInt32(dr["idGrupo_Estudiante"]),
                    Convert.ToInt32(dr["idGrupo"]),
                    Convert.ToInt32(dr["idEstudiante"]),
                    null,
                    null);

                listaGruposEstudiantes.Add(ge);
            }

            dr.Close();

            return listaGruposEstudiantes;
        }
    }
}
