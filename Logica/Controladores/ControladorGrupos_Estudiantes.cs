using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorGrupos_Estudiantes
    {
        //  UPDATES
        public static ResultadoOperacion actualizarGrupos_Estudiantes(IList<Estudiante> listaEstudiantes, Grupo g)
        {
            ResultadoOperacion innerRO = null;
            CBTis123_Entities db = Vinculo_DB.generarContexto();
            int actualizadas = 0;

            try
            {
                List<grupos_estudiantes> listaPreliminar = db.grupos_estudiantes.Where(ge => ge.idGrupo == g.idGrupo).ToList();

                foreach (grupos_estudiantes ge in listaPreliminar)
                {
                    db.grupos_estudiantes.Remove(ge);
                }

                foreach (Estudiante e in listaEstudiantes)
                {
                    grupos_estudiantes ge = new grupos_estudiantes();
                    ge.idEstudiante = e.idEstudiante;
                    ge.idGrupo = g.idGrupo;

                    db.grupos_estudiantes.Add(ge);
                }

                actualizadas = db.SaveChanges();

            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }
            
            return
                actualizadas > 0 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Estudiantes del grupo modificados")
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Estudiantes del grupo no modificados",
                    null,
                    innerRO);
        }
    }
}
