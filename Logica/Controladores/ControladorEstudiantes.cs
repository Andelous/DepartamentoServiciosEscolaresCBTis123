using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
using MySql.Data.MySqlClient;
using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorEstudiantes
    {
        // Propiedades
        // DAOs
        private DAOEstudiantes daoEstudiantes { get; set; }
        private DAOGrupo_Estudiante daoGrupo_Estudiante { get; set; }

        // Controladores adicionales.
        public ControladorSemestres controladorSemestres
        {
            get
            {
                return ControladorSingleton.controladorSemestres;
            }
        }
        public ControladorGrupos controladorGrupos
        {
            get
            {
                return ControladorSingleton.controladorGrupos;
            }
        }

        // Métodos de inicialización
        public ControladorEstudiantes()
        {
            this.daoEstudiantes = new DAOEstudiantes();
            this.daoGrupo_Estudiante = new DAOGrupo_Estudiante();
        }

        // Métodos de manipulación de los modelos
        // Selección
        public List<Semestre> seleccionarSemestres()
        {
            return controladorSemestres.seleccionarSemestresLista();
        }

        public List<Grupo> seleccionarGrupos(Semestre s)
        {
            return controladorGrupos.seleccionarGrupos(s);
        }

        public List<estudiantes> seleccionarEstudiantesADO()
        {
            List<estudiantes> listaEstudiantes = new List<estudiantes>();

            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                listaEstudiantes = db.estudiantes.ToList();
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaEstudiantes;
        }

        public List<Estudiante> seleccionarEstudiantes()
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // Si algo sale mal, se lo notificaremos al usuario.
            try
            {
                listaEstudiantes = daoEstudiantes.seleccionarEstudiantes();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaEstudiantes;
        }

        public List<estudiantes> seleccionarEstudiantesPorGrupo(grupos g)
        {
            if (g == null) return seleccionarEstudiantesADO();

            List<estudiantes> listaEstudiantes = new List<estudiantes>();

            // Si algo sale mal, se lo notificaremos al usuario.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();
                g = db.grupos.Single(g1 => g1.idGrupo == g.idGrupo);

                List<grupos_estudiantes> listaGE = g.grupos_estudiantes.ToList();

                foreach (grupos_estudiantes ge in listaGE)
                {
                    listaEstudiantes.Add(ge.estudiantes);
                }
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }


            return listaEstudiantes;
        }

        public List<Estudiante> seleccionarEstudiantesPorGrupo(Grupo g)
        {
            if (g == null) return seleccionarEstudiantes();

            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            // Si algo sale mal, se lo notificaremos al usuario.
            try
            {
                listaEstudiantes = daoEstudiantes.seleccionarEstudiantesPorGrupo(g);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }
            

            return listaEstudiantes;
        }

        public List<Estudiante> seleccionarEstudiantesParametros(
            string coincidencia,
            bool nombrecompleto,
            bool nombres,
            bool apellidoPaterno,
            bool apellidoMaterno,
            bool curp,
            bool nss,
            bool numeroDeControl,
            Grupo g
        ) {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            try
            {
                if (g == null)
                    listaEstudiantes = 
                        daoEstudiantes.
                        seleccionarEstudiantesCondicional(
                            numeroDeControl,
                            curp,
                            nombrecompleto,
                            nombres,
                            apellidoPaterno,
                            apellidoMaterno,
                            nss,
                            coincidencia);
                else
                    listaEstudiantes = 
                        daoEstudiantes.
                        seleccionarEstudiantesPorGrupoCondicional(
                            g,
                            numeroDeControl,
                            curp,
                            nombrecompleto,
                            nombres,
                            apellidoPaterno,
                            apellidoMaterno,
                            nss,
                            coincidencia);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
                throw;
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
                throw;
            }

            return listaEstudiantes;
        }

        public List<estudiantes> seleccionarEstudiantesParametrosADO(
            string coincidencia,
            bool nombrecompleto,
            bool nombres,
            bool apellidoPaterno,
            bool apellidoMaterno,
            bool curp,
            bool nss,
            bool numeroDeControl,
            Grupo g
        ) {
            List<Estudiante> listaEstudiantesOriginal = seleccionarEstudiantesParametros(
                coincidencia,
                nombrecompleto,
                nombres,
                apellidoPaterno,
                apellidoMaterno,
                curp,
                nss,
                numeroDeControl,
                g
            );
            List<estudiantes> listaEstudiantesADO = convertirLista(listaEstudiantesOriginal);

            return listaEstudiantesADO;
        }

        // Inserción
        public ResultadoOperacion registrarEstudiante(
            string nombres,
            string apellidoPaterno,
            string apellidoMaterno,
            string curp,
            string numeroDeControl,
            string nss
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombres) ||
                !ValidadorDeTexto.esValido(apellidoPaterno) ||
                !ValidadorDeTexto.esValido(apellidoMaterno) ||
                !ValidadorDeTexto.esValido(curp) ||
                // Se comentó la línea, porque aún no se implementa
                // el campo en la vista.
                //!ValidadorDeTexto.esValido(nss) ||
                !ValidadorDeTexto.esValido(numeroDeControl)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Estudiante e =
                DAOEstudiantes.
                crearEstudiante(
                    -1,
                    numeroDeControl,
                    curp,
                    nombres.Trim() + " " + apellidoPaterno.Trim() + " " + apellidoMaterno.Trim(),
                    nombres.Trim(),
                    apellidoPaterno.Trim(),
                    apellidoMaterno.Trim(),
                    nss,
                    false
                );

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                registrado = daoEstudiantes.insertarEstudiante(e);
            }
            catch (MySqlException ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(ex);
                throw;
            }
            catch (Exception ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(ex);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                registrado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Estudiante registrado")
                :
                registrado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más estudiantes",
                    "EstReg " + registrado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Estudiante no registrado",
                    null,
                    innerRO);
        }

        // Modificación
        public ResultadoOperacion modificarEstudiante(
            int idEstudiante,
            string nombres,
            string apellidoPaterno,
            string apellidoMaterno,
            string curp,
            string numeroDeControl,
            string nss,
            bool verificado
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombres) ||
                !ValidadorDeTexto.esValido(apellidoPaterno) ||
                !ValidadorDeTexto.esValido(apellidoMaterno) ||
                !ValidadorDeTexto.esValido(curp) ||
                // Se comentó la línea de abajo, porque
                // la vista aún no implementa el campo
                //!ValidadorDeTexto.esValido(nss) ||
                !ValidadorDeTexto.esValido(numeroDeControl)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Estudiante e =
                DAOEstudiantes.
                crearEstudiante(
                    idEstudiante,
                    numeroDeControl,
                    curp,
                    nombres.Trim() + " " + apellidoPaterno.Trim() + " " + apellidoMaterno.Trim(),
                    nombres.Trim(),
                    apellidoPaterno.Trim(),
                    apellidoMaterno.Trim(),
                    nss,
                    verificado
                );

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                modificado = daoEstudiantes.modificarEstudiante(e);
            }
            catch (MySqlException ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(ex);
            }
            catch (Exception ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(ex);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                modificado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Estudiante modificado")
                :
                modificado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han modificado dos o más estudiantes",
                    "EstMod " + modificado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Estudiante no modificado",
                    null,
                    innerRO);
        }

        // Eliminación
        public ResultadoOperacion eliminarEstudiante(Estudiante e)
        {
            ResultadoOperacion innerRO = null;

            int eliminado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                // Validamos que no pertenezca a grupos...
                if (daoGrupo_Estudiante.seleccionarGrupos_Estudiantes(e).Count > 0)
                {
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorDependenciaDeDatos,
                            "El estudiante pertenece a uno o más grupos");
                }

                eliminado = daoEstudiantes.eliminarEstudiante(e);
            }
            catch (MySqlException ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(ex);
            }
            catch (Exception ex)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(ex);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                eliminado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Estudiante eliminado")
                :
                eliminado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han eliminado dos o más estudiantes",
                    "SemElim " + eliminado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Estudiante no eliminado",
                    null,
                    innerRO);
        }

        // Misceláneos

        public List<estudiantes> convertirLista(List<Estudiante> listaOriginal)
        {
            List<estudiantes> listaNueva = new List<estudiantes>();

            foreach (Estudiante estudiante in listaOriginal)
            {
                listaNueva.Add(
                    new estudiantes()
                    {
                        apellido1 = estudiante.apellido1,
                        apellido2 = estudiante.apellido2,
                        curp = estudiante.curp,
                        idEstudiante = estudiante.idEstudiante,
                        ncontrol = estudiante.ncontrol,
                        nombrecompleto = estudiante.nombreCompleto,
                        nombres = estudiante.nombres,
                        nss = estudiante.nss,
                        verificado = estudiante.verificado
                    }
                );
            }

            return listaNueva;
        }

        public List<Estudiante> convertirLista(List<estudiantes> listaOriginal)
        {
            List<Estudiante> listaNueva = new List<Estudiante>();

            foreach (estudiantes estudiante in listaOriginal)
            {
                listaNueva.Add(
                    new Estudiante()
                    {
                        apellido1 = estudiante.apellido1,
                        apellido2 = estudiante.apellido2,
                        curp = estudiante.curp,
                        idEstudiante = estudiante.idEstudiante,
                        ncontrol = estudiante.ncontrol,
                        nombres = estudiante.nombres,
                        nss = estudiante.nss,
                        verificado = estudiante.verificado,
                        nombreCompleto = estudiante.nombrecompleto
                    }
                );
            }

            return listaNueva;
        }
    }
}
 