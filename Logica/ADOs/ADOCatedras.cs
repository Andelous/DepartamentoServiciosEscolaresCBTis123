using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.ADOs
{
    public class ADOCatedras : ADO
    {
        // SELECTS
        public List<catedras> seleccionarCatedrasPorGrupo(grupos g)
        {
            /*
            string query = "SELECT C.*, M.*, D.*, G.* FROM " +
                "catedras C, materias M, docentes D, grupos G WHERE " +
                "C.idGrupo = " + g.idGrupo + " AND " +
                "C.idDocente = D.idDocente AND " +
                "C.idGrupo = G.idGrupo AND " +
                "C.idMateria = M.idMateria;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCatedrasMySqlDataReader(dr);
            */

            return dataContext.catedras.Where(c => c.grupos.idGrupo == g.idGrupo).ToList();
        }

        public List<Catedra> seleccionarCatedrasPorDocente(docentes d)
        {
            /*
            string query = "SELECT C.*, M.*, D.*, G.* FROM " +
                "catedras C, materias M, docentes D, grupos G WHERE " +
                "C.idDocente = " + d.idDocente + " AND " +
                "C.idDocente = D.idDocente AND " +
                "C.idGrupo = G.idGrupo AND " +
                "C.idMateria = M.idMateria;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCatedrasMySqlDataReader(dr);
            */
        }

        // INSERTS
        public int insertarCatedra(Catedra c)
        {
            /*
            string query = "INSERT INTO catedras " +
                    "(idDocente, idMateria, idGrupo) " +
                    "VALUES (" +
                    c.idDocente + ", " +
                    c.idMateria + ", " +
                    c.idGrupo + ");";

            return dataSource.ejecutarActualizacion(query);
            */
        }


        // UPDATES
        public int modificarCatedra(Catedra c)
        {
            /*
            string query = "UPDATE catedras " +
                "SET " +
                "idDocente = " + c.idDocente + ", " +
                "idMateria = " + c.idMateria + ", " +
                "idGrupo = " + c.idGrupo + " " +
                "WHERE idCatedra = " + c.idCatedra + ";";

            return dataSource.ejecutarActualizacion(query);
            */
        }

        // MISC
        public static catedras crearCatedra(
            int idCatedra,
            int idDocente,
            int idMateria,
            int idGrupo
        ) {
            catedras c = new catedras();
            
            c.idCatedra = idCatedra;
            c.idDocente = idDocente;
            c.idGrupo = idGrupo;
            c.idMateria = idMateria;

            return c;
        }
    }
}
