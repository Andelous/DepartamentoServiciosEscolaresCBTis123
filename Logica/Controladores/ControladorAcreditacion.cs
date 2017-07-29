using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using ResultadosOperacion;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorAcreditacion
    {
        // Variables lógicas privadas
        private static CBTis123_Entities dbContext
        {
            get
            {
                return ControladorSingleton.dbContext;
            }
        }


        // SELECTS
        public static List<grupos> seleccionarGrupos(
            semestres periodo,
            string turno,
            int semestre,
            carreras carrera
        ) {
            List<grupos> listaGrupos = new List<grupos>();

            try
            {
                listaGrupos = dbContext.grupos.ToList().Where(
                    g => 
                    g.idSemestre == periodo.idSemestre &&
                    g.turno == turno.ToUpper()[0].ToString() &&
                    g.semestre == semestre &&
                    g.especialidad == carrera.abreviatura
                ).ToList();
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaGrupos;
        }

        public static List<catedras> seleccionarCatedras(grupos g)
        {
            List<catedras> listaCatedras = new List<catedras>();

            try
            {
                inicializarCatedras(g);
                listaCatedras = dbContext.catedras.Where(
                    c =>
                    c.idGrupo == g.idGrupo
                ).ToList();
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaCatedras;
        }

        public static List<calificaciones_semestrales> seleccionarCalificaciones(catedras asignatura)
        {
            List<calificaciones_semestrales> listaCalificaciones = new List<calificaciones_semestrales>();

            try
            {
                inicializarCalificaciones(asignatura);
                listaCalificaciones = dbContext.calificaciones_semestrales.Where(c => c.idCatedra == asignatura.idCatedra).ToList();
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaCalificaciones;
        }


        // INSERTS
        public static ResultadoOperacion insertarCalificacion()
        {
            return null;
        }


        // UPDATES
        public static ResultadoOperacion actualizarCalificaciones(List<calificaciones_semestrales> listaCalificaciones)
        {
            int calificacionesModificadas = 0;
            ResultadoOperacion innerRO = null;

            try
            {
                bool cambios = false;
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    calificaciones_semestrales cUpdated = dbContext.calificaciones_semestrales.SingleOrDefault(c1 => c1.idCalificacion_Semestral == c.idCalificacion_Semestral);

                    cUpdated.asistenciasParcial1 = c.asistenciasParcial1;
                    cUpdated.asistenciasParcial2 = c.asistenciasParcial2;
                    cUpdated.asistenciasParcial3 = c.asistenciasParcial3;

                    cUpdated.calificacionParcial1 = c.calificacionParcial1;
                    cUpdated.calificacionParcial2 = c.calificacionParcial2;
                    cUpdated.calificacionParcial3 = c.calificacionParcial3;

                    cUpdated.firmado = c.firmado;
                    cUpdated.recursamiento = c.recursamiento;
                    cUpdated.tipoDeAcreditacion = c.tipoDeAcreditacion;

                    cambios = true;
                }
                if (cambios)
                {
                    calificacionesModificadas = dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            int listaCalificacionesCount = listaCalificaciones.Count;

            return
                calificacionesModificadas > 0?
                    new ResultadoOperacion(
                        EstadoOperacion.Correcto,
                        "Calificaciones actualizadas")
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "No se han actualizado todas las calificaciones,\no más de las debidas fueron actualizadas",
                    "CalAct " + calificacionesModificadas.ToString(),
                    innerRO);
        }

        public static ResultadoOperacion actualizarCalificacionesDesdeSiseems(List<calificaciones_semestrales> listaCalificaciones)
        {
            int calificacionesModificadas = 0;
            ResultadoOperacion innerRO = null;

            try
            {
                bool cambios = false;
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    calificaciones_semestrales cUpdated = dbContext.calificaciones_semestrales.SingleOrDefault(c1 => c1.idEstudiante == c.idEstudiante && c1.idCatedra == c.idCatedra);

                    if (cUpdated == null)
                    {
                        cUpdated = new calificaciones_semestrales()
                        {
                            firmado = false,
                            idCatedra = c.idCatedra,
                            idEstudiante = c.idEstudiante,
                            recursamiento = true
                        };

                        dbContext.calificaciones_semestrales.Add(cUpdated);
                        dbContext.SaveChanges();
                    }

                    cUpdated.asistenciasParcial1 = c.asistenciasParcial1;
                    cUpdated.asistenciasParcial2 = c.asistenciasParcial2;
                    cUpdated.asistenciasParcial3 = c.asistenciasParcial3;

                    cUpdated.calificacionParcial1 = c.calificacionParcial1;
                    cUpdated.calificacionParcial2 = c.calificacionParcial2;
                    cUpdated.calificacionParcial3 = c.calificacionParcial3;

                    cUpdated.firmado = c.firmado;
                    cUpdated.tipoDeAcreditacion = c.tipoDeAcreditacion;
                    cambios = true;
                }

                if (cambios)
                {
                    calificacionesModificadas = dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            int listaCalificacionesCount = listaCalificaciones.Count;

            return
                calificacionesModificadas > 0 ?
                    new ResultadoOperacion(
                        EstadoOperacion.Correcto,
                        "Calificaciones importadas desde el SISEEMS")
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "No se han importado todas las calificaciones,\no más de las debidas fueron actualizadas",
                    "CalAct " + calificacionesModificadas.ToString(),
                    innerRO);
        }

        // Métodos misceláneos
        private static void inicializarCatedras(grupos grupo)
        {
            try
            {
                List<catedras> listaCatedras = dbContext.catedras.Where(
                    c =>
                    c.idGrupo == grupo.idGrupo
                ).ToList();

                if (listaCatedras.Count == 0)
                {
                    Grupo g1 = ControladorSingleton.controladorGrupos.seleccionarGrupo(grupo.idGrupo);

                    ControladorSingleton.controladorGrupos.
                    registrarCatedras(
                        ControladorSingleton.controladorGrupos.
                        crearListaCatedrasGrupo(g1));
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
        }

        public static void inicializarCalificaciones(catedras catedra)
        {
            try
            {
                // Primero, obtenemos todos los estudiantes 
                // que pertenecen al grupo de la cátedra
                List<grupos_estudiantes> listaEstudiantesFK =
                    dbContext.
                    grupos_estudiantes.
                    Where(
                        ge =>
                        ge.idGrupo == catedra.idGrupo
                    ).ToList();

                List<estudiantes> listaEstudiantes = new List<estudiantes>();

                foreach (grupos_estudiantes ge in listaEstudiantesFK)
                {
                    listaEstudiantes.Add(ge.estudiantes);
                }


                // Ahora, obtendremos todas las calificaciones
                // que ya existen en la base de datos.
                List<calificaciones_semestrales> listaCalificaciones = new List<calificaciones_semestrales>();

                listaCalificaciones = dbContext.calificaciones_semestrales.Where(c => c.idCatedra == catedra.idCatedra).ToList();


                // Ya que tenemos las calificaciones, iteramos
                // sobre la lista para saber qué alumnos tienen 
                // ya un registro. Si no tienen registro, lo agregamos
                
                // Eliminación de los alumnos que ya tienen calificación
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    listaEstudiantes.RemoveAll(e => e.idEstudiante == c.idEstudiante);
                }

                bool cambios = false;
                foreach (estudiantes e in listaEstudiantes)
                {
                    calificaciones_semestrales c = new calificaciones_semestrales
                    {
                        firmado = false,
                        idCatedra = catedra.idCatedra,
                        idEstudiante = e.idEstudiante,
                        recursamiento = false
                    };

                    dbContext.calificaciones_semestrales.Add(c);
                    cambios = true;
                }
                if (cambios)
                {
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
        }


        // Métodos misceláneos
        public static List<calificaciones_semestrales> crearListaCalificaciones(string[][] tabla, int idCatedra = -1, catedras catedra = null)
        {
            List<calificaciones_semestrales> listaCalificaciones = new List<calificaciones_semestrales>();

            foreach (string[] row in tabla)
            {
                if (row.Length < 13)
                    continue;

                calificaciones_semestrales c = new calificaciones_semestrales();

                string ncontrol = row[1];

                c.asistenciasParcial1 = Convert.ToInt32(row[6]);
                c.asistenciasParcial2 = Convert.ToInt32(row[7]);
                c.asistenciasParcial3 = Convert.ToInt32(row[8]);
                c.calificacionParcial1 = Convert.ToDouble(row[3]);
                c.calificacionParcial2 = Convert.ToDouble(row[4]);
                c.calificacionParcial3 = Convert.ToDouble(row[5]);
                c.estudiantes = dbContext.estudiantes.SingleOrDefault(e => e.ncontrol == ncontrol);
                c.idEstudiante = c.estudiantes.idEstudiante;
                c.firmado = Convert.ToBoolean(row[12]);
                c.idCalificacion_Semestral = -1;
                c.recursamiento = false;
                c.tipoDeAcreditacion = row[11];
                c.catedras = catedra;
                c.idCatedra = idCatedra;


                listaCalificaciones.Add(c);
            }

            return listaCalificaciones;
        }
    }
}
