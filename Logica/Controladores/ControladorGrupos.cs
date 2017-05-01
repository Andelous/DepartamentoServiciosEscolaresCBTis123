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

        // Controladores
        private DAODocentes daoDocentes { get; set; }
        private DAOEstudiantes daoEstudiantes { get; set; }
        private ControladorSemestres controladorSemestres { get; set; }

        // Métodos de iniciación
        public ControladorGrupos(ControladorSemestres controladorSemestres = null)
        {
            daoGrupos = new DAOGrupos();
            daoCarreras = new DAOCarreras();
            daoCatedras = new DAOCatedras();

            // Futuros controladores
            daoDocentes = new DAODocentes();
            daoEstudiantes = new DAOEstudiantes();

            this.controladorSemestres = 
                controladorSemestres != null 
                ? 
                controladorSemestres 
                : 
                new ControladorSemestres(this);
        }
        
        // Métodos de manipulación del modelo
        // Selección    
        public List<Semestre> seleccionarSemestres()
        {
            // Creamos una lista vacía en caso de que
            // se devuelva una excepción...
            List<Semestre> listaSemestres = new List<Semestre>();

            // Creamos el semestre de ningún semestre
            Semestre s = new Semestre();
            s.idSemestre = -1;
            s.nombre = "Ningún semestre";
            s.nombreCorto2 = "-";

            // Se intenta realizar la operación con el DAO.
            // Si hay alguna excepción, se manejará.
            try
            {
                listaSemestres = controladorSemestres.seleccionarSemestres();
                
                s = new Semestre();
                s.idSemestre = 0;
                s.nombre = "Todos";
                s.nombreCorto2 = "*";
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            // Agregamos el semestre comodín
            listaSemestres.Add(s);

            return listaSemestres;
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
                listaDocentes = daoDocentes.seleccionarDocentes();
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

        public List<Materia> seleccionarMateriasPorGrupo(Grupo g)
        {
            List<Materia> listaMaterias = new List<Materia>();

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
        )
        {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(letra) ||
                !ValidadorDeTexto.esValido(turno) ||
                !ValidadorDeTexto.esValido(especialidad)
            )
            {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

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
                return ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                return ControladorExcepciones.crearResultadoOperacionException(e);
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
                    "GroupReg " + registrado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Grupo no registrado");
        }

        public ResultadoOperacion registrarCatedras(List<Catedra> listaCatedras)
        {

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
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            // Se devolverá el estado de las materias insertadas.
            return
                registradas == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo registrado")
                :
                registradas > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más grupos",
                    "GroupReg " + registradas.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Grupo no registrado");
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
                return ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                return ControladorExcepciones.crearResultadoOperacionException(e);
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
                    "GroupReg " + modificado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Grupo no modificado");
        }

        public ResultadoOperacion modificarListaDeCatedras(List<Catedra> listaCatedras)
        {

            int modificadas = 0;

            try
            {
                modificadas = daoCatedras.modificarListaDeCatedras(listaCatedras);
            }
            catch (MySqlException e)
            {
                return ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                return ControladorExcepciones.crearResultadoOperacionException(e);
            }

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
                    "CatMod " + modificadas)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Error al modificar una o todas las cátedras",
                    "CatMod " + modificadas);
        }

        // Eliminación
        public ResultadoOperacion eliminarGrupo(Grupo g)
        {
            // Validamos que no tenga alumnos dependientes
            if (daoEstudiantes.seleccionarEstudiantesPorGrupo(g.idGrupo).Count > 0)
            {
                return
                    new ResultadoOperacion(
                        EstadoOperacion.ErrorDependenciaDeDatos,
                        "El grupo contiene estudiantes");
            }

            int eliminado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                eliminado = daoGrupos.eliminarGrupo(g);
            }
            catch (MySqlException e)
            {
                return ControladorExcepciones.crearResultadoOperacionMySqlException(e);
            }
            catch (Exception e)
            {
                return ControladorExcepciones.crearResultadoOperacionException(e);
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
                    "GrupElim " + eliminado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Grupo no eliminado");
        }
    }
}
