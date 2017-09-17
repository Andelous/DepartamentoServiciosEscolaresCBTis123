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
        private static string separadorRegistro
        {
            get
            {
                return "|";
            }
        }
        private static string separadorCampo
        {
            get
            {
                return "_:_";
            }
        }


        // SELECTS
        public static List<grupos> seleccionarGrupos(
            semestres periodo,
            string turno,
            int semestre,
            carreras carrera
        ) {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

            List<grupos> listaGrupos = new List<grupos>();

            try
            {
                turno = turno.ToUpper()[0].ToString();

                listaGrupos = dbContext.grupos.Where(
                    g => 
                    g.idSemestre == periodo.idSemestre &&
                    g.turno == turno &&
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
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

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
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

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

        public static List<HistorialCalificacionSemestral> seleccionarHistorial(calificaciones_semestrales calificacion_semestral)
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

            List<HistorialCalificacionSemestral> listaHistorial = new List<HistorialCalificacionSemestral>();

            try
            {
                historial_calificaciones_semestrales historialBruto = 
                    dbContext.
                    historial_calificaciones_semestrales.
                    SingleOrDefault(
                        h => 
                        h.idCalificacion_Semestral == calificacion_semestral.idCalificacion_Semestral
                    );

                if (historialBruto != null)
                {
                    string s1 = historialBruto.cambios;
                    string[] s2 = s1.Split(new string[] { separadorRegistro }, StringSplitOptions.RemoveEmptyEntries);

                    string[][] valoresFinales = new string[s2.Length][];

                    for (int i = 0; i < s2.Length; i++)
                    {
                        string s = s2[i];

                        valoresFinales[i] = s.Split(new string[] { separadorCampo }, StringSplitOptions.None);
                    }

                    foreach (string[] sArr in valoresFinales)
                    {
                        HistorialCalificacionSemestral h = new HistorialCalificacionSemestral();

                        int posicion = 0;

                        h.nombreDeCampo = sArr[posicion++];
                        h.valorAnterior = sArr[posicion++];
                        h.valorNuevo = sArr[posicion++];
                        h.fuenteDeCambio = sArr[posicion++];
                        h.fecha = sArr[posicion++];

                        int idUsuario = Convert.ToInt32(sArr[posicion++]);
                        usuarios u = dbContext.usuarios.SingleOrDefault(u1 => u1.idUsuario == idUsuario);

                        h.usuarioAutor = u;

                        listaHistorial.Add(h);
                    }
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaHistorial;
        }

        // INSERTS
        public static ResultadoOperacion insertarCalificacion()
        {
            return null;
        }


        // UPDATES
        public static ResultadoOperacion actualizarCalificaciones(IList<calificaciones_semestrales> listaCalificaciones, string razon)
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

            // Setteamos variables necesarias para el método
            int calificacionesModificadas = 0;
            ResultadoOperacion innerRO = null;

            bool cambios = false;

            try
            {
                // Iteramos sobre la lista que nos pasaron
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    // Creamos un StringBuilder para guardar cualquier cambio
                    StringBuilder logCambios = new StringBuilder();

                    // Obtenemos las calificaciones que hay en la DB
                    calificaciones_semestrales cUpdated = dbContext.calificaciones_semestrales.SingleOrDefault(
                        c1 => c1.idCatedra == c.idCatedra && c1.idEstudiante == c.idEstudiante
                    );

                    // Si hay algún cambio en cualquiera de los campos, 
                    // se agregará el registro al StringBuilder, y se
                    // encenderá la bandera de que hubo cambio

                    // PRIMERO, las asistencias
                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.asistenciasParcial1, c.asistenciasParcial1) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Asistencias parcial 1", 
                                cUpdated.asistenciasParcial1.ToString(),
                                c.asistenciasParcial1.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.asistenciasParcial1 = c.asistenciasParcial1;
                        cambios = true;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.asistenciasParcial2, c.asistenciasParcial2) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Asistencias parcial 2",
                                cUpdated.asistenciasParcial2.ToString(),
                                c.asistenciasParcial2.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.asistenciasParcial2 = c.asistenciasParcial2;
                        cambios = true;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.asistenciasParcial3, c.asistenciasParcial3) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Asistencias parcial 3",
                                cUpdated.asistenciasParcial3.ToString(),
                                c.asistenciasParcial3.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.asistenciasParcial3 = c.asistenciasParcial3;
                        cambios = true;
                    }


                    // SEGUNDO, las calificaciones
                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.calificacionParcial1, c.calificacionParcial1) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Calificación parcial 1",
                                cUpdated.calificacionParcial1.ToString(),
                                c.calificacionParcial1.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.calificacionParcial1 = c.calificacionParcial1;
                        cambios = true;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.calificacionParcial2, c.calificacionParcial2) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Calificación parcial 2",
                                cUpdated.calificacionParcial2.ToString(),
                                c.calificacionParcial2.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.calificacionParcial2 = c.calificacionParcial2;
                        cambios = true;
                    }

                    if (ControladorMiscelaneo.compararNullableDouble(cUpdated.calificacionParcial3, c.calificacionParcial3) != 0)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Calificación parcial 3",
                                cUpdated.calificacionParcial3.ToString(),
                                c.calificacionParcial3.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.calificacionParcial3 = c.calificacionParcial3;
                        cambios = true;
                    }


                    //TERCERO, otros datos que se pueden modificar en el DGV
                    if (cUpdated.firmado != c.firmado)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Firmado",
                                cUpdated.firmado.ToString(),
                                c.firmado.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.firmado = c.firmado;
                        cambios = true;
                    }

                    if (cUpdated.tipoDeAcreditacion != c.tipoDeAcreditacion)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Tipo de acreditación",
                                cUpdated.tipoDeAcreditacion,
                                c.tipoDeAcreditacion,
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.tipoDeAcreditacion = c.tipoDeAcreditacion;
                        cambios = true;
                    }

                    if (cUpdated.recursamiento != c.recursamiento)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Firmado",
                                cUpdated.recursamiento.ToString(),
                                c.recursamiento.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.recursamiento = c.recursamiento;
                        cambios = true;
                    }

                    if (cUpdated.verificado != c.verificado)
                    {
                        logCambios.Append(
                            crearLogCambios(
                                "Tipo de acreditación",
                                cUpdated.verificado.ToString(),
                                c.verificado.ToString(),
                                razon,
                                ControladorSesion.usuarioActivo.idUsuario
                            )
                        );

                        cUpdated.verificado = c.verificado;
                        cambios = true;
                    }

                    // Ahora, para guardar en el historial,
                    // comprobamos que exista. Si no existe,
                    // lo creamos y agregmos los cambios del StringBuilder.
                    // Si ya existe, simplemente agregamos los
                    // cambios al final de la cadena.
                    historial_calificaciones_semestrales historial = dbContext.historial_calificaciones_semestrales.SingleOrDefault(h => h.idCalificacion_Semestral == cUpdated.idCalificacion_Semestral);

                    if (historial == null)
                    {
                        historial = new historial_calificaciones_semestrales()
                        {
                            idCalificacion_Semestral = cUpdated.idCalificacion_Semestral,
                            cambios = logCambios.ToString()
                        };

                        dbContext.historial_calificaciones_semestrales.Add(historial);
                    }
                    else
                    {
                        historial.cambios += logCambios.ToString();
                    }
                }

                // Si hubo cambios, se guardan
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
                !cambios
                ?
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "No se guardó ninguna calificación - " + razon,
                    null,
                    innerRO)
                :
                calificacionesModificadas > 0
                ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Calificaciones actualizadas - " + razon,
                    null,
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "No se han actualizado las calificaciones - " + razon,
                    "CalAct " + calificacionesModificadas.ToString(),
                    innerRO);
        }

        public static ResultadoOperacion actualizarCalificacionesDesdeSiseems(IList<calificaciones_semestrales> listaCalificaciones, string clase = "Desconocida")
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();
            bool cambios = false;

            try
            {
                // Iteramos sobre las calificaciones que nos pasaron para registrar a los estudiantes
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    // Si su estudiante no existe, lo agregamos a la base de datos
                    if (c.idEstudiante == -1)
                    {
                        estudiantes estudianteC = c.estudiantes;

                        estudianteC.idEstudiante = 0;
                        //estudianteC.ncontrol = estudianteC.ncontrol.Substring(0, 18);
                        //estudianteC.nombrecompleto = estudianteC.nombrecompleto.Substring(0, 60);
                        //estudianteC.nombres = estudianteC.nombres.Substring(0, 30);
                        estudianteC.curp = "";
                        estudianteC.apellido1 = "";
                        estudianteC.apellido2 = "";
                        estudianteC.nss = "";
                        estudianteC.verificado = false;

                        c.estudiantes = dbContext.estudiantes.Add(estudianteC);
                        cambios = true;
                    }
                }

                // Si hubo cambios en la base de datos los guardamos
                if (cambios)
                {
                    dbContext.SaveChanges();
                }

                cambios = false;

                // Iteramos sobre las calificaciones que nos pasaron
                // y si no existe alguna, creamos una temporal antes de 
                // que registremos los verdaderos valores
                foreach (calificaciones_semestrales c in listaCalificaciones)
                {
                    calificaciones_semestrales cUpdated = dbContext.calificaciones_semestrales.SingleOrDefault(
                        c1 => c1.idCatedra == c.idCatedra && c1.idEstudiante == c.idEstudiante
                    );

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
                        cambios = true;
                    }
                }

                if (cambios)
                {
                    dbContext.SaveChanges();
                }

                // Finalmente registramos el bonche de calificaciones
                return actualizarCalificaciones(listaCalificaciones, "Importación de SISEEMS");
            }
            catch (Exception e)
            {
                return ControladorExcepciones.crearResultadoOperacionException(e);
            }
        }

        // Métodos misceláneos
        public static void inicializarCatedras(grupos grupo)
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

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

                    dbContext = Vinculo_DB.generarContexto();
                    listaCatedras = dbContext.catedras.Where(
                        c =>
                        c.idGrupo == grupo.idGrupo
                    ).ToList();

                    foreach (catedras c in listaCatedras)
                    {
                        inicializarCalificaciones(c);
                    }
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
        }

        public static void inicializarCatedras(Grupo grupo)
        {
            inicializarCatedras(new grupos() { idGrupo = grupo.idGrupo });
        }

        public static void inicializarCalificaciones(catedras catedra)
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

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
                
                // De los estudiantes que restan, agregamos una calificación por default
                foreach (estudiantes e in listaEstudiantes)
                {
                    calificaciones_semestrales c = new calificaciones_semestrales
                    {
                        firmado = false,
                        idCatedra = catedra.idCatedra,
                        idEstudiante = e.idEstudiante,
                        recursamiento = false,
                        verificado = true
                    };

                    dbContext.calificaciones_semestrales.Add(c);
                }
                
                // Si hubo estudiantes sin calificación, guardamos los cambios
                if (listaEstudiantes.Count > 0)
                {
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
        }

        public static List<calificaciones_semestrales> crearListaCalificaciones(string[][] tabla, int idCatedra = -1, catedras catedra = null)
        {
            // Código necesario para los métodos que 
            // utilicen la base de datos
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();

            List<calificaciones_semestrales> listaCalificaciones = new List<calificaciones_semestrales>();

            foreach (string[] row in tabla)
            {
                if (row.Length < 13)
                    continue;

                calificaciones_semestrales c = new calificaciones_semestrales();

                string ncontrol = row[1];
                string nombres = row[2];

                // ASISTENCIAS
                if (row[6] != null && row[6] != "")
                {
                    c.asistenciasParcial1 = Convert.ToInt32(row[6]);
                }
                else
                {
                    c.asistenciasParcial1 = null;
                }

                if (row[7] != null && row[7] != "")
                {
                    c.asistenciasParcial2 = Convert.ToInt32(row[7]);
                }
                else
                {
                    c.asistenciasParcial2 = null;
                }

                if (row[8] != null && row[8] != "")
                {
                    c.asistenciasParcial3 = Convert.ToInt32(row[8]);
                }
                else
                {
                    c.asistenciasParcial3 = null;
                }


                // CALIFICACIONES PARCIALES
                if (row[3] != null && row[3] != "")
                {
                    c.calificacionParcial1 = Convert.ToDouble(row[3]);
                }
                else
                {
                    c.calificacionParcial1 = null;
                }

                if (row[4] != null && row[4] != "")
                {
                    c.calificacionParcial2 = Convert.ToDouble(row[4]);
                }
                else
                {
                    c.calificacionParcial2 = null;
                }

                if (row[5] != null && row[5] != "")
                {
                    c.calificacionParcial3 = Convert.ToDouble(row[5]);
                }
                else
                {
                    c.calificacionParcial3 = null;
                }

                estudiantes estudianteDeCalificacion = dbContext.estudiantes.SingleOrDefault(e => e.ncontrol == ncontrol);

                if (estudianteDeCalificacion == null)
                {
                    estudianteDeCalificacion = new estudiantes() { idEstudiante = -1, nombrecompleto = nombres, nombres = nombres, ncontrol = ncontrol};
                }

                c.estudiantes = estudianteDeCalificacion;


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

        public static string crearLogCambios(string nombreDeCampo, string valorAnterior, string valorNuevo, string fuenteDeCambio, int idUsuarioAutor)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(separadorRegistro);
            sb.Append(nombreDeCampo);
            sb.Append(separadorCampo);
            sb.Append(valorAnterior);
            sb.Append(separadorCampo);
            sb.Append(valorNuevo);
            sb.Append(separadorCampo);
            sb.Append(fuenteDeCambio);
            sb.Append(separadorCampo);
            sb.Append(DateTime.Now.ToString());
            sb.Append(separadorCampo);
            sb.Append(idUsuarioAutor.ToString());

            return sb.ToString();
        }

        public static IList<estudiantes> seleccionarEstudiantesRecursamiento(IList<calificaciones_semestrales>[] arrListasCalificaciones)
        {
            // Creamos la lista que contendrá los estudiantes que existen en todas las listas...
            IList<estudiantes> listaEstudiantes = new List<estudiantes>();

            IList<calificaciones_semestrales> listaBase = arrListasCalificaciones[0];

            foreach (calificaciones_semestrales cs in listaBase)
            {
                bool flag = true;

                foreach (IList<calificaciones_semestrales> lista in arrListasCalificaciones)
                {
                    calificaciones_semestrales csI = lista.FirstOrDefault(cs1 => cs1.nControl == cs.nControl);
                    flag = csI != null;

                    if (!flag) break;
                }

                if (flag) listaEstudiantes.Add(cs.estudiantes);
            }

            return listaEstudiantes;
        }
    }
}

