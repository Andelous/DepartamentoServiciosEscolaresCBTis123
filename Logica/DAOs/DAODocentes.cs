using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAODocentes : DAO
    {
        // SELECTS
        public List<Docente> seleccionarDocentes()
        {
            string query = "SELECT * FROM docentes WHERE genero != '' AND idDocente != 100 ORDER BY apellidop, apellidom, nombres;";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaDocentesMySqlDataReader(dr);
        }

        public List<Docente> seleccionarDocentesPorCoincidencia(string criterio)
        {
            string query = "SELECT * FROM docentes WHERE " + 
                "genero != '' AND idDocente != 100 AND (" + 
                "nombres LIKE '%" + criterio + "%' OR " +
                "apellidop LIKE '%" + criterio + "%' OR " +
                "apellidom LIKE '%" + criterio + "%'" +
                ");";

            MySqlDataReader dr = dataSource.ejecutarConsulta(query);

            return crearListaDocentesMySqlDataReader(dr);
        }


        // INSERTS
        public int insertarDocente(Docente d)
        {
            string query = "INSERT INTO docentes " +
                "(genero, tarjeta, curp, rfc, nombres, apellidop, apellidom, " +
                "estado, correoi, correop, nivelmedioTit, nivelmedio, dnivelmedio, " +
                "tecnicosuperiorTit, tecnicosuperior, dtecnicosuperior, licenciatura1Tit, " +
                "licenciatura1, dlicenciatura1, licenciatura2Tit, licenciatura2, " +
                "dlicenciatura2, especialidad1, despecialidad1, especialidad2, despecialidad2, " +
                "maestria1Tit, maestria1, dmaestria1, maestria2Tit, maestria2, dmaestria2, " +
                "doctoradoTit, doctorado, ddoctorado, telefonoCelular, telefono, " +
                "paisNacimiento, estadoNacimiento, fechaNacimiento, auxRevision) " +
                "VALUES " +
                "('" + d.genero + "', " +
                "" + d.tarjeta.ToString() + ", " +
                "'" + d.curp + "', " +
                "'" + d.rfc + "', " +
                "'" + d.nombres + "', " +
                "'" + d.apellidop + "', " +
                "'" + d.apellidom + "', " +
                "'" + d.estado + "', " +
                "'" + d.correoi + "', " +
                "'" + d.correop + "', " +
                "'" + d.nivelmedioTit + "', " +
                "'" + d.nivelmedio + "', " +
                "'" + d.dnivelmedio + "', " +
                "'" + d.tecnicosuperiorTit + "', " +
                "'" + d.tecnicosuperior + "', " +
                "'" + d.dtecnicosuperior + "', " +
                "'" + d.licenciatura1Tit + "', " +
                "'" + d.licenciatura1 + "', " +
                "'" + d.dlicenciatura1 + "', " +
                "'" + d.licenciatura2Tit + "', " +
                "'" + d.licenciatura2 + "', " +
                "'" + d.dlicenciatura2 + "', " +
                "'" + d.especialidad1 + "', " +
                "'" + d.despecialidad1 + "', " +
                "'" + d.especialidad2 + "', " +
                "'" + d.despecialidad2 + "', " +
                "'" + d.maestria1Tit + "', " +
                "'" + d.maestria1 + "', " +
                "'" + d.dmaestria1 + "', " +
                "'" + d.maestria2Tit + "', " +
                "'" + d.maestria2 + "', " +
                "'" + d.dmaestria2 + "', " +
                "'" + d.doctoradoTit + "', " +
                "'" + d.doctorado + "', " +
                "'" + d.ddoctorado + "', " +
                "'" + d.telefonoCelular + "', " +
                "'" + d.telefono + "', " +
                "'" + d.paisNacimiento + "', " +
                "'" + d.estadoNacimiento + "', " +
                "'" + 
                    d.fechaNacimiento.Year + "-" + 
                    d.fechaNacimiento.Month + "-" + 
                    d.fechaNacimiento.Day + 
                "', " +
                "'" + d.auxRevision + "')";

            return dataSource.ejecutarActualizacion(query);
        }


        // UPDATES
        public int modificarDocente(Docente d)
        {
            string query = "UPDATE docentes SET " +
                "genero = '" + d.genero + "', " +
                "tarjeta = " + d.tarjeta + ", " +
                "curp = '" + d.curp + "', " +
                "rfc = '" + d.rfc + "', " +
                "nombres = '" + d.nombres + "', " +
                "apellidop = '" + d.apellidop + "', " +
                "apellidom = '" + d.apellidom + "', " +
                "estado = '" + d.estado + "', " +
                "correoi = '" + d.correoi + "', " +
                "correop = '" + d.correop + "', " +
                "nivelmedioTit = '" + d.nivelmedioTit + "', " +
                "nivelmedio = '" + d.nivelmedio + "', " +
                "dnivelmedio = '" + d.dnivelmedio + "', " +
                "tecnicosuperiorTit = '" + d.tecnicosuperiorTit + "', " +
                "tecnicosuperior = '" + d.tecnicosuperior + "', " +
                "dtecnicosuperior = '" + d.dtecnicosuperior + "', " +
                "licenciatura1Tit = '" + d.licenciatura1Tit + "', " +
                "licenciatura1 = '" + d.licenciatura1 + "', " +
                "dlicenciatura1 = '" + d.dlicenciatura1 + "', " +
                "licenciatura2Tit = '" + d.licenciatura2Tit + "', " +
                "licenciatura2 = '" + d.licenciatura2 + "', " +
                "dlicenciatura2 = '" + d.dlicenciatura2 + "', " +
                "especialidad1 = '" + d.especialidad1 + "', " +
                "despecialidad1 = '" + d.despecialidad1 + "', " +
                "especialidad2 = '" + d.especialidad2 + "', " +
                "despecialidad2 = '" + d.despecialidad2 + "', " +
                "maestria1Tit = '" + d.maestria1Tit + "', " +
                "maestria1 = '" + d.maestria1 + "', " +
                "dmaestria1 = '" + d.dmaestria1 + "', " +
                "maestria2Tit = '" + d.maestria2Tit + "', " +
                "maestria2 = '" + d.maestria2 + "', " +
                "dmaestria2 = '" + d.dmaestria2 + "', " +
                "doctoradoTit = '" + d.doctoradoTit + "', " +
                "doctorado = '" + d.doctorado + "', " +
                "ddoctorado = '" + d.ddoctorado + "', " +
                "telefonoCelular = '" + d.telefonoCelular + "', " +
                "telefono = '" + d.telefono + "', " +
                "paisNacimiento = '" + d.paisNacimiento + "', " +
                "estadoNacimiento = '" + d.estadoNacimiento + "', " +
                "fechaNacimiento = '" +
                    d.fechaNacimiento.Year + "-" +
                    d.fechaNacimiento.Month + "-" +
                    d.fechaNacimiento.Day +
                "', " +
                "auxRevision = '" + d.auxRevision + "' " +
                "WHERE idDocente = " + d.idDocente;

            return dataSource.ejecutarActualizacion(query);
        }


        // DELETES
        public int eliminarDocente(Docente d)
        {
            string query = "DELETE FROM docentes WHERE idDocente = " + d.idDocente.ToString();

            return dataSource.ejecutarActualizacion(query);
        }


        // MISC

        public static Docente crearDocente(
            int idDocente,
            string genero,
            int tarjeta,
            string curp,
            string rfc,
            string nombres,
            string apellidop,
            string apellidom,
            string estado,
            string correoi,
            string correop,
            string nivelmedioTit,
            string nivelmedio,
            string dnivelmedio,
            string tecnicosuperiorTit,
            string tecnicosuperior,
            string dtecnicosuperior,
            string licenciatura1Tit,
            string licenciatura1,
            string dlicenciatura1,
            string licenciatura2Tit,
            string licenciatura2,
            string dlicenciatura2,
            string especialidad1,
            string despecialidad1,
            string especialidad2,
            string despecialidad2,
            string maestria1Tit,
            string maestria1,
            string dmaestria1,
            string maestria2Tit,
            string maestria2,
            string dmaestria2,
            string doctoradoTit,
            string doctorado,
            string ddoctorado,
            string telefonoCelular,
            string telefono,
            string paisNacimiento,
            string estadoNacimiento,
            DateTime fechaNacimiento,
            string auxRevision
            )
        {
            Docente d = new Docente();

            d.apellidom = apellidom;
            d.apellidop = apellidop;
            d.auxRevision = auxRevision;
            d.correoi = correoi;
            d.correop = correop;
            d.curp = curp;
            d.ddoctorado = ddoctorado;
            d.despecialidad1 = despecialidad1;
            d.despecialidad2 = despecialidad2;
            d.dlicenciatura1 = dlicenciatura1;
            d.dlicenciatura2 = dlicenciatura2;
            d.dmaestria1 = dmaestria1;
            d.dmaestria2 = dmaestria2;
            d.dnivelmedio = dnivelmedio;
            d.doctorado = doctorado;
            d.doctoradoTit = doctoradoTit;
            d.dtecnicosuperior = dtecnicosuperior;
            d.especialidad1 = especialidad1;
            d.especialidad2 = especialidad2;
            d.estado = estado;
            d.estadoNacimiento = estadoNacimiento;
            d.fechaNacimiento = fechaNacimiento;
            d.genero = genero;
            d.idDocente = idDocente;
            d.licenciatura1 = licenciatura1;
            d.licenciatura1Tit = licenciatura1Tit;
            d.licenciatura2 = licenciatura2;
            d.licenciatura2Tit = licenciatura2Tit;
            d.maestria1 = maestria1;
            d.maestria1Tit = maestria1Tit;
            d.maestria2 = maestria2;
            d.maestria2Tit = maestria2Tit;
            d.nivelmedio = nivelmedio;
            d.nivelmedioTit = nivelmedioTit;
            d.nombres = nombres;
            d.paisNacimiento = paisNacimiento;
            d.rfc = rfc;
            d.tarjeta = tarjeta;
            d.tecnicosuperior = tecnicosuperior;
            d.tecnicosuperiorTit = tecnicosuperiorTit;
            d.telefono = telefono;
            d.telefonoCelular = telefonoCelular;

            return d;
        }

        public static List<Docente> crearListaDocentesMySqlDataReader(MySqlDataReader dr)
        {
            List<Docente> listaDocentes = new List<Docente>();

            while (dr.Read())
            {
                //string FNS = dr["fechaNacimiento"].ToString();
                //System.Windows.Forms.MessageBox.Show(FNS);
                //DateTime fechaNacimiento = new DateTime(
                //    Convert.ToInt32(FNS.Substring(6, 4)),
                //    Convert.ToInt32(FNS.Substring(3,2)),
                //    Convert.ToInt32(FNS.Substring(0, 2)));

                Docente d = crearDocente(
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

                listaDocentes.Add(d);
            }

            dr.Close();

            return listaDocentes;
        }
    }
}
