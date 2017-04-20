using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOMaterias : DAO
    {
        public List<Materia> seleccionarMateriasSegunGrupo(Grupo g)
        {
            string query = "SELECT * FROM materias WHERE " +
                "semestre = " + g.semestre + " AND " +
                "(" +
                    "(idCarrera = " + g.especialidadObj.idCarrera + " OR idCarrera = 16 AND " +
                    "(propedeutica = '' OR propedeutica = 'asignatura')) " +
                    "OR " +
                    "(idCarrera = 16 AND propedeutica LIKE '" + g.especialidadObj.bachilleratoCiencias.Substring(0, 5) + "%')" +
                    "OR " +
                    "componenteF = 'Complementaria'" +
                ");";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaMateriasMySqlDataReader(dr);
        }

        // MISC

        public static Materia crearMateria(
            int idMateria,
            int idAreacampo,
            int idAcademia,
            int idCarrera,
            int idModulo,
            short subModulo,
            int semestre,
            string nombre,
            string abreviatura,
            string componenteF,
            string propedeutica,
            int hrsSemana,
            int hrsSemestre
        ) {
            Materia m = new Materia();

            m.idMateria = idMateria;
            m.idAreacampo = idAreacampo;
            m.idAcademia = idAcademia;
            m.idCarrera = idCarrera;
            m.idModulo = idModulo;

            m.subModulo = subModulo;
            m.semestre = semestre;

            m.nombre = nombre;
            m.abreviatura = abreviatura;
            m.componenteF = componenteF;
            m.propedeutica = propedeutica;

            m.hrsSemana = hrsSemana;
            m.hrsSemestre = hrsSemestre;

            return m;
        }

        public static List<Materia> crearListaMateriasMySqlDataReader(MySqlDataReader dr)
        {
            List<Materia> listaMaterias = new List<Materia>();

            while (dr.Read())
            {
                Materia m = crearMateria(
                    Convert.ToInt32(dr["idMateria"]),
                    Convert.ToInt32(dr["idAreacampo"]),
                    Convert.ToInt32(dr["idAcademia"]),
                    Convert.ToInt32(dr["idCarrera"]),
                    Convert.ToInt32(dr["idModulo"]),
                    Convert.ToInt16(dr["subModulo"]),
                    Convert.ToInt32(dr["semestre"]),
                    dr["nombre"].ToString(),
                    dr["abreviatura"].ToString(),
                    dr["componenteF"].ToString(),
                    dr["propedeutica"].ToString(),
                    Convert.ToInt32(dr["hrsSemana"]),
                    Convert.ToInt32(dr["hrsSemestre"])
                );

                listaMaterias.Add(m);
            }

            dr.Close();

            return listaMaterias;
        }
    }
}
