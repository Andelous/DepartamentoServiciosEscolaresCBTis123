using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOCatedras : DAO
    {
        // SELECTS
        public List<Catedra> seleccionarCatedrasPorGrupo(Grupo g)
        {
            string query = "SELECT C.*, M.*, D.*, G.* FROM " + 
                "catedras C, materias M, docentes D, grupos G WHERE " + 
                "C.idGrupo = " + g.idGrupo + " AND " + 
                "C.idDocente = D.idDocente AND " + 
                "C.idGrupo = G.idGrupo AND " + 
                "C.idMateria = M.idMateria;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCatedrasMySqlDataReader(dr);
        }

        public List<Catedra> seleccionarCatedrasPorDocente(Docente d)
        {
            string query = "SELECT C.*, M.*, D.*, G.* FROM " +
                "catedras C, materias M, docentes D, grupos G WHERE " +
                "C.idDocente = " + d.idDocente + " AND " +
                "C.idDocente = D.idDocente AND " +
                "C.idGrupo = G.idGrupo AND " +
                "C.idMateria = M.idMateria;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaCatedrasMySqlDataReader(dr);
        }

        // INSERTS
        public int insertarCatedra(Catedra c)
        {
            string query = "INSERT INTO catedras " +
                    "(idDocente, idMateria, idGrupo) " +
                    "VALUES (" +
                    c.idDocente + ", " +
                    c.idMateria + ", " +
                    c.idGrupo + ");";

            return dataSource.ejecutarActualizacion(query);
        }

        
        // UPDATES
        public int modificarCatedra(Catedra c)
        {
            string query = "UPDATE catedras " + 
                "SET " + 
                "idDocente = " + c.idDocente + ", " +
                "idMateria = " + c.idMateria + ", " + 
                "idGrupo = " + c.idGrupo + " " +
                "WHERE idCatedra = " + c.idCatedra + ";";

            return dataSource.ejecutarActualizacion(query);
        }

        // MISC
        public static Catedra crearCatedra(
            int idCatedra,
            int idDocente,
            int idMateria,
            int idGrupo,
            Docente docenteObj,
            Materia materiaObj,
            Grupo grupoObj
            )
        {
            Catedra c = new Catedra();

            c.docenteObj = docenteObj;
            c.grupoObj = grupoObj;
            c.idCatedra = idCatedra;
            c.idDocente = idDocente;
            c.idGrupo = idGrupo;
            c.idMateria = idMateria;
            c.materiaObj = materiaObj;

            return c;
        }

        public static List<Catedra> crearListaCatedrasMySqlDataReader(MySqlDataReader dr)
        {
            List<Catedra> listaCatedras = new List<Catedra>();

            while (dr.Read())
            {
                Docente docenteObj = DAODocentes.crearDocente(
                    Convert.ToInt32(dr["idDocente"]),
                    dr["genero"].ToString(),
                    Convert.ToInt32(dr["tarjeta"]),
                    dr["curp"].ToString(),
                    dr["rfc"].ToString(),
                    dr["nombres"].ToString(),
                    dr["apellidop"].ToString(),
                    dr["apellidom"].ToString(),
                    dr["estado"].ToString(),
                    dr["correoi"].ToString(),
                    dr["correop"].ToString(),
                    dr["nivelmedioTit"].ToString(),
                    dr["nivelmedio"].ToString(),
                    dr["dnivelmedio"].ToString(),
                    dr["tecnicosuperiorTit"].ToString(),
                    dr["tecnicosuperior"].ToString(),
                    dr["dtecnicosuperior"].ToString(),
                    dr["licenciatura1Tit"].ToString(),
                    dr["licenciatura1"].ToString(),
                    dr["dlicenciatura1"].ToString(),
                    dr["licenciatura2Tit"].ToString(),
                    dr["licenciatura2"].ToString(),
                    dr["dlicenciatura2"].ToString(),
                    dr["especialidad1"].ToString(),
                    dr["despecialidad1"].ToString(),
                    dr["especialidad2"].ToString(),
                    dr["despecialidad2"].ToString(),
                    dr["maestria1Tit"].ToString(),
                    dr["maestria1"].ToString(),
                    dr["dmaestria1"].ToString(),
                    dr["maestria2Tit"].ToString(),
                    dr["maestria2"].ToString(),
                    dr["dmaestria2"].ToString(),
                    dr["doctoradoTit"].ToString(),
                    dr["doctorado"].ToString(),
                    dr["ddoctorado"].ToString(),
                    dr["telefonoCelular"].ToString(),
                    dr["telefono"].ToString(),
                    dr["paisNacimiento"].ToString(),
                    dr["estadoNacimiento"].ToString(),
                    Convert.ToDateTime(dr["fechaNacimiento"]),
                    dr["auxRevision"].ToString()
                );

                Materia materiaObj = DAOMaterias.crearMateria(
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

                Grupo grupoObj = DAOGrupos.crearGrupo(
                    Convert.ToInt32(dr["idGrupo"]),
                    Convert.ToInt32(dr["idSemestre"]),
                    Convert.ToInt32(dr["semestre"]),
                    dr["letra"].ToString(),
                    dr["turno"].ToString(),
                    dr["especialidad"].ToString(),
                    null,
                    null);

                Catedra c = crearCatedra(
                    Convert.ToInt32(dr["idCatedra"]),
                    Convert.ToInt32(dr["idDocente"]),
                    Convert.ToInt32(dr["idMateria"]),
                    Convert.ToInt32(dr["idGrupo"]),
                    docenteObj,
                    materiaObj,
                    grupoObj
                );

                listaCatedras.Add(c);
            }

            dr.Close();

            return listaCatedras;
        }
    }
}
