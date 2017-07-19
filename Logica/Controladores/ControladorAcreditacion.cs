﻿using System;
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

        public static List<calificaciones> seleccionarCalificaciones(catedras asignatura)
        {
            List<calificaciones> listaCalificaciones = new List<calificaciones>();

            try
            {
                inicializarCalificaciones(asignatura);
                listaCalificaciones = dbContext.calificaciones.Where(c => c.idCatedra == asignatura.idCatedra).ToList();
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaCalificaciones;
        }

        // UPDATES
        public static ResultadoOperacion actualizarCalificaciones(List<calificaciones> listaCalificaciones)
        {
            int calificacionesModificadas = 0;
            ResultadoOperacion innerRO = null;

            try
            {
                foreach (calificaciones c in listaCalificaciones)
                {
                    calificaciones cUpdated = dbContext.calificaciones.SingleOrDefault(c1 => c1.idCalificaciones == c.idCalificaciones);

                    cUpdated.asistenciasParcial1 = c.asistenciasParcial1;
                    cUpdated.asistenciasParcial2 = c.asistenciasParcial2;
                    cUpdated.asistenciasParcial3 = c.asistenciasParcial3;

                    cUpdated.calificacionParcial1 = c.calificacionParcial1;
                    cUpdated.calificacionParcial2 = c.calificacionParcial2;
                    cUpdated.calificacionParcial3 = c.calificacionParcial3;

                    cUpdated.firmado = c.firmado;
                    cUpdated.recursamiento = c.recursamiento;
                    cUpdated.tipoDeAcreditacion = c.tipoDeAcreditacion;
                }

                calificacionesModificadas = dbContext.SaveChanges();
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
                List<calificaciones> listaCalificaciones = new List<calificaciones>();

                listaCalificaciones = dbContext.calificaciones.Where(c => c.idCatedra == catedra.idCatedra).ToList();


                // Ya que tenemos las calificaciones, iteramos
                // sobre la lista para saber qué alumnos tienen 
                // ya un registro. Si no tienen registro, lo agregamos
                
                // Eliminación de los alumnos que ya tienen calificación
                foreach (calificaciones c in listaCalificaciones)
                {
                    listaEstudiantes.RemoveAll(e => e.idEstudiante == c.idEstudiante);
                }

                foreach (estudiantes e in listaEstudiantes)
                {
                    calificaciones c = new calificaciones
                    {
                        asistenciasParcial1 = 0,
                        asistenciasParcial2 = 0,
                        asistenciasParcial3 = 0,
                        calificacionParcial1 = 0,
                        calificacionParcial2 = 0,
                        calificacionParcial3 = 0,
                        firmado = true,
                        tipoDeAcreditacion = "A",
                        idCatedra = catedra.idCatedra,
                        idEstudiante = e.idEstudiante,
                        recursamiento = false
                    };

                    dbContext.calificaciones.Add(c);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
        }
    }
}
