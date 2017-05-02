using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOGrupo_Estudiante : DAO
    {
        // INSERTAR
        public int insertarEstudianteEnGrupo(Estudiante e, Grupo g)
        {
            string query =
                "INSERT INTO grupos_estudiantes " +
                "(idGrupo, idEstudiante) " +
                "VALUES " +
                "(" + g.idGrupo + ", " + e.idEstudiante + ");";

            return dataSource.ejecutarActualizacion(query);
        }
    }
}
