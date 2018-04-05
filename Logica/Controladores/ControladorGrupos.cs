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

        public List<grupos> seleccionarGrupos(semestres s)
        {
            // Creamos lista vacía en caso de Excepcion
            List<grupos> listaGrupos = new List<grupos>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                listaGrupos =
                    db.grupos.Where(g => g.idSemestre == s.idSemestre).
                    OrderBy(g => g.semestre).
                    ThenBy(g => g.turno).
                    ThenBy(g => g.especialidad).
                    ThenBy(g => g.letra).
                    ToList();
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

        public Grupo seleccionarGrupo(int idGrupo)
        {
            // Creamos un grupo nulo para devolverlo luego
            Grupo g = null;

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                g = daoGrupos.seleccionarGrupo(idGrupo);
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
            return g;
        }

        public List<Carrera> seleccionarCarreras(string acuerdo = "2013")
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

        public List<carreras> seleccionarCarrerasADO(int estado = 0)
        {
            // Creamos lista vacía en caso de Excepcion
            List<carreras> listaCarreras = new List<carreras>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                listaCarreras = 
                    db.carreras.Where(
                        c => c.estado == estado &&
                        c.abreviatura != "BGRAL" &&
                        c.abreviatura != "Todas").ToList();
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

        public List<catedras> seleccionarCatedrasPorGrupo(grupos g)
        {
            List<catedras> listaCatedras = new List<catedras>();

            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                listaCatedras = db.catedras.Where(c => c.idGrupo == g.idGrupo).ToList();
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

        // Registro
        public ResultadoOperacion registrarGrupo(
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad,
            semestres semestreObj,
            carreras especialidadObj
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

            grupos g = new grupos
            {
                especialidad = especialidadObj.abreviatura,
                idCarrera = especialidadObj.idCarrera,
                idSemestre = semestreObj.idSemestre,
                letra = letra,
                semestre = semestre,
                turno = turno[0].ToString().ToUpper()
            };

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                db.grupos.Add(g);

                registrado = db.SaveChanges();
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
                registrado > 0 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo registrado")
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

        public ResultadoOperacion modificarGrupo(
            int idGrupo,
            int idSemestre,
            int semestre,
            string letra,
            string turno,
            string especialidad,
            semestres semestreObj,
            carreras especialidadObj
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

            ResultadoOperacion innerRO = null;

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                grupos g = db.grupos.Single(g1 => g1.idGrupo == idGrupo);

                g.especialidad = especialidadObj.abreviatura;
                g.idCarrera = especialidadObj.idCarrera;
                g.idSemestre = semestreObj.idSemestre;
                g.letra = letra;
                g.semestre = semestre;
                g.turno = turno[0].ToString().ToUpper();

                modificado = db.SaveChanges();
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
                modificado > 0 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Grupo modificado")
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

        public ResultadoOperacion modificarListaDeCatedras(List<catedras> listaCatedras)
        {
            ResultadoOperacion innerRO = null;
            int modificadas = 0;

            // Realizamos la operación, y si hay algún error, se mostrará al usuario.
            try
            {
                CBTis123_Entities db = Vinculo_DB.generarContexto();

                foreach (catedras c in listaCatedras)
                {
                    catedras c1 = db.catedras.Single(c2 => c2.idCatedra == c.idCatedra);

                    c1.idDocente = c.idDocente;
                    c1.idGrupo = c.idGrupo;
                    c1.idMateria = c.idMateria;
                }

                modificadas = db.SaveChanges();
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
                modificadas > 0 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Catedras guardadas")
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Error al modificar una o todas las cátedras",
                    "CatMod " + modificadas,
                    innerRO);
        }

        // Eliminación
        public ResultadoOperacion eliminarGrupo(grupos g)
        {
            return eliminarGrupo(new Grupo { idGrupo = g.idGrupo });
        }

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
