using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorGrupos
    {
        // Propiedades
        // DAOs
        private DAOGrupos daoGrupos { get; set; }
        private DAOCarreras daoCarreras { get; set; }
        private DAOCatedras daoCatedras { get; set; }
        private DAOMaterias daoMaterias { get; set; }

        // Controladores
        private ControladorDocentes controladorDocentes
        {
            get
            {
                return ControladorSingleton.controladorDocentes;
            }
        }
        private ControladorEstudiantes controladorEstudiantes
        {
            get
            {
                return ControladorSingleton.controladorEstudiantes;
            }
        }
        private ControladorSemestres controladorSemestres
        {
            get
            {
                return ControladorSingleton.controladorSemestres;
            }
        }

        // Métodos de iniciación
        public ControladorGrupos()
        {
            daoGrupos = new DAOGrupos();
            daoCarreras = new DAOCarreras();
            daoCatedras = new DAOCatedras();
            daoMaterias = new DAOMaterias();
        }
        
        // Métodos de manipulación del modelo
        // Selección
        public List<Semestre> seleccionarSemestres()
        {
            return controladorSemestres.seleccionarSemestresLista();
        }

        public List<Grupo> seleccionarGrupos(Semestre s)
        {
            // Creamos lista vacía en caso de Excepcion
            List<Grupo> listaGrupos = new List<Grupo>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                if (s.idSemestre == 0)
                {
                    listaGrupos = daoGrupos.seleccionarGrupos();
                }
                else if (s.idSemestre > 0)
                {
                    listaGrupos = daoGrupos.seleccionarGruposPorSemestre(s);
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

            // Devolvemos resultado
            return listaGrupos;
        }

        public List<Carrera> seleccionarCarreras(string acuerdo = "653")
        {
            // Creamos lista vacía en caso de Excepcion
            List<Carrera> listaCarreras = new List<Carrera>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                listaCarreras = daoCarreras.seleccionarCarrerasPorAcuerdo(acuerdo);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaCarreras;
        }

        public List<Docente> seleccionarDocentes()
        {
            List<Docente> listaDocentes = new List<Docente>();

            // Realizamos la operación, y damos manejo a las excepciones
            try
            {
                listaDocentes = controladorDocentes.seleccionarDocentes();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaDocentes;
        }

        public List<Catedra> seleccionarCatedrasPorGrupo(Grupo g)
        {
            List<Catedra> listaCatedras = new List<Catedra>();

            try
            {
                listaCatedras = daoCatedras.seleccionarCatedrasPorGrupo(g);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaCatedras;
        }

        private List<Materia> seleccionarMateriasPorGrupo(Grupo g)
        {
            List<Materia> listaMaterias = new List<Materia>();

            try
            {
                listaMaterias = daoMaterias.seleccionarMateriasPorGrupo(g);
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaMaterias;
        }

        // Registro
        public ResultadoOperacion registrarGrupo(
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad,
            Semestre semestreObj,
            Carrera especialidadObj
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(letra) ||
                !ValidadorDeTexto.esValido(turno) ||
                !ValidadorDeTexto.esValido(especialidad)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Grupo g =
                DAOGrupos.crearGrupo(
                    -1,
                    idSemestre,
                    semestre,
                    letra,
                    turno,
                    especialidad,
                    semestreObj,
                    especialidadObj);

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                registrado = daoGrupos.insertarGrupo(g);
            }
            catch (MySqlException e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                registrado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo registrado")
                :
                registrado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más grupos",
                    "GroupReg " + registrado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Grupo no registrado",
                    null,
                    innerRO);
        }

        public ResultadoOperacion registrarCatedras(List<Catedra> listaCatedras)
        {
            ResultadoOperacion innerRO = null;
            int registradas = 0;

            // Si hay algún error durante la ejecución, se mostrará
            // resultado de la operación.
            try
            {
                foreach (Catedra c in listaCatedras)
                {
                    registradas += daoCatedras.insertarCatedra(c);
                }
            }
            catch (MySqlException e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            // Se devolverá el estado de las materias insertadas.
            return
                registradas == listaCatedras.Count ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Clases registradas")
                :
                registradas > listaCatedras.Count ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado " + (listaCatedras.Count + 1) + " o más clases",
                    "CateReg " + registradas.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Error al registrar una o más cátedras", 
                    "CateReg " + registradas.ToString(),
                    innerRO);
        }

        // Modificación
        public ResultadoOperacion modificarGrupo(
            int idGrupo,
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad,
            Semestre semestreObj,
            Carrera especialidadObj
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(letra) ||
                !ValidadorDeTexto.esValido(turno) ||
                !ValidadorDeTexto.esValido(especialidad)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Grupo g =
                DAOGrupos.crearGrupo(
                    idGrupo,
                    idSemestre,
                    semestre,
                    letra,
                    turno,
                    especialidad,
                    semestreObj,
                    especialidadObj);

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                modificado = daoGrupos.modificarGrupo(g);
            }
            catch (MySqlException e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                innerRO =  ControladorExcepciones.crearResultadoOperacionException(e);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                modificado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo modificado")
                :
                modificado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han modificado dos o más grupos",
                    "GroupReg " + modificado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Grupo no modificado",
                    null,
                    innerRO);
        }

        public ResultadoOperacion modificarListaDeCatedras(List<Catedra> listaCatedras)
        {
            ResultadoOperacion innerRO = null;
            int modificadas = 0;

            // Realizamos la operación, y si hay algún error, se mostrará al usuario.
            try
            {
                foreach (Catedra c in listaCatedras)
                {
                    modificadas += daoCatedras.modificarCatedra(c);
                }
            }
            catch (MySqlException e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            // Devolvemos los resultados.
            return
                modificadas == listaCatedras.Count
                ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Catedras guardadas")
                :
                modificadas > listaCatedras.Count
                ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han modificado " + (listaCatedras.Count + 1) + " o más cátedras",
                    "CatMod " + modificadas,
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Error al modificar una o todas las cátedras",
                    "CatMod " + modificadas,
                    innerRO);
        }

        // Eliminación
        public ResultadoOperacion eliminarGrupo(Grupo g)
        {
            // Validamos que no tenga alumnos dependientes
            if (controladorEstudiantes.seleccionarEstudiantesPorGrupo(g).Count > 0)
            {
                return
                    new ResultadoOperacion(
                        EstadoOperacion.ErrorDependenciaDeDatos,
                        "El grupo contiene estudiantes");
            }

            ResultadoOperacion innerRO = null;

            int eliminado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                eliminado = daoGrupos.eliminarGrupo(g);
            }
            catch (MySqlException e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                innerRO = ControladorExcepciones.crearResultadoOperacionException(e);
            }

            // Si no hubo problema, se devolverá el resultado correspondiente.
            return
                eliminado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo eliminado")
                :
                eliminado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han eliminado dos o más grupos",
                    "GrupElim " + eliminado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Grupo no eliminado",  
                    null,
                    innerRO);
        }

        // Métodos misceláneos
        public List<Catedra> crearListaCatedrasGrupo(Grupo g)
        {
            List<Catedra> listaCatedras = new List<Catedra>();

            // Intentamos llevar a cabo la operación.
            // Si algo sale mal, se le notificará al usuario.
            try
            {
                List<Materia> listaMaterias = daoMaterias.seleccionarMateriasPorGrupo(g);

                foreach (Materia m in listaMaterias)
                {
                    Catedra c = 
                        DAOCatedras.
                        crearCatedra(
                            -1,
                            100, 
                            m.idMateria, 
                            g.idGrupo, 
                            null, 
                            m, 
                            g);

                    listaCatedras.Add(c);
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

            // Devolvemos resultados
            return listaCatedras;
        }
    }
}
