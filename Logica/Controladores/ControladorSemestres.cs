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
    public class ControladorSemestres
    {
        // Propiedades
        // DAOs
        private DAOSemestres daoSemestres { get; set; }

        // Controladores necesarios
        private ControladorGrupos controladorGrupos
        {
            get
            {
                return ControladorSingleton.controladorGrupos;
            }
        }

        // Inicialización
        public ControladorSemestres()
        {
            this.daoSemestres = new DAOSemestres();
        }

        // Métodos de manipulación del modelo.
        // Selección
        public List<semestres> seleccionarSemestres()
        {
            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();
            List<semestres> listaSemestres = new List<semestres>();

            // Si hay algún error durante la ejecución de la operación
            // se mostrará el respectivo resultado de operación.
            try
            {
                listaSemestres = dbContext.semestres.ToList();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            return listaSemestres;
        }

        public List<Semestre> seleccionarSemestresLista()
        {
            List<Semestre> listaSemestres = new List<Semestre>();

            // Creamos el semestre de ningún semestre
            Semestre s = new Semestre();
            s.idSemestre = -1;
            s.nombre = "Ningún semestre";
            s.nombreCorto2 = "-";

            // Si hay algún error durante la ejecución de la operación
            // se mostrará el respectivo resultado de operación.
            try
            {
                listaSemestres = daoSemestres.seleccionarSemestres();
            }
            catch (MySqlException e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionMySqlException(e));
            }
            catch (Exception e)
            {
                ControladorVisual.mostrarMensaje(ControladorExcepciones.crearResultadoOperacionException(e));
            }

            if (listaSemestres.Count > 0)
            {
                s = new Semestre();
                s.idSemestre = 0;
                s.nombre = "Todos";
                s.nombreCorto2 = "*";
            }

            // Agregamos el semestre comodín
            listaSemestres.Add(s);

            return listaSemestres;
        }

        // Registro
        public ResultadoOperacion registrarSemestre(
            string nombre,
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3,
            DateTime fechai_p1,
            DateTime fechaf_p1,
            DateTime fechai_p2,
            DateTime fechaf_p2,
            DateTime fechai_p3,
            DateTime fechaf_p3
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombre) ||
                !ValidadorDeTexto.esValido(nombreCorto) ||
                !ValidadorDeTexto.esValido(nombreCorto2) ||
                !ValidadorDeTexto.esValido(nombreCorto3) ||
                fechaf_p1 < fechai_p1 ||
                fechai_p2 <= fechaf_p1 ||
                fechaf_p2 < fechai_p2 ||
                fechai_p3 <= fechaf_p2 ||
                fechaf_p3 < fechai_p3
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos. Verifique sus fechas.");
            }

            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();
            ResultadoOperacion innerRO = null;

            semestres s = new semestres()
            {
                nombre = nombre,
                nombrecorto = nombreCorto,
                nombrecorto2 = nombreCorto2,
                nombrecorto3 = nombreCorto3,
                fechaf_p1 = fechaf_p1,
                fechaf_p2 = fechaf_p2,
                fechaf_p3 = fechaf_p3,
                fechai_p1 = fechai_p1,
                fechai_p2 = fechai_p2,
                fechai_p3 = fechai_p3
            };

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                dbContext.semestres.Add(s);
                registrado = dbContext.SaveChanges();
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
                    "Semestre registrado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no registrado",
                    null,
                    innerRO);
        }

        // Modificación
        public ResultadoOperacion modificarSemestre(
            int idSemestre, 
            string nombre, 
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3,
            DateTime fechai_p1,
            DateTime fechaf_p1,
            DateTime fechai_p2,
            DateTime fechaf_p2,
            DateTime fechai_p3,
            DateTime fechaf_p3
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombre) ||
                !ValidadorDeTexto.esValido(nombreCorto) ||
                !ValidadorDeTexto.esValido(nombreCorto2) ||
                !ValidadorDeTexto.esValido(nombreCorto3) ||
                fechaf_p1 < fechai_p1 ||
                fechai_p2 <= fechaf_p1 ||
                fechaf_p2 < fechai_p2 ||
                fechai_p3 <= fechaf_p2 ||
                fechaf_p3 < fechai_p3
            )
            {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos. Verifique sus fechas.");
            }

            CBTis123_Entities dbContext = Vinculo_DB.generarContexto();
            ResultadoOperacion innerRO = null;

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                semestres s = dbContext.semestres.Single(s1 => s1.idSemestre == idSemestre);

                s.nombre = nombre;
                s.nombrecorto = nombreCorto;
                s.nombrecorto2 = nombreCorto2;
                s.nombrecorto3 = nombreCorto3;
                s.fechaf_p1 = fechaf_p1;
                s.fechaf_p2 = fechaf_p2;
                s.fechaf_p3 = fechaf_p3;
                s.fechai_p1 = fechai_p1;
                s.fechai_p2 = fechai_p2;
                s.fechai_p3 = fechai_p3;

                modificado = dbContext.SaveChanges();
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
                    "Semestre modificado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no modificado",
                    null,
                    innerRO);
        }

        // Eliminación
        public ResultadoOperacion eliminarSemestre(Semestre s)
        {
            // Validamos que no tenga grupos dependientes
            if (controladorGrupos.seleccionarGrupos(s).Count > 0)
            {
                return
                    new ResultadoOperacion(
                        EstadoOperacion.ErrorDependenciaDeDatos,
                        "El semestre contiene grupos");
            }

            ResultadoOperacion innerRO = null;

            int eliminado = 0;
            
            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                eliminado = daoSemestres.eliminarSemestre(s);
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
                    "Semestre eliminado")
                :
                eliminado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han eliminado dos o más semestres",
                    "SemElim " + eliminado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no eliminado",
                    null,
                    innerRO);
        }

        public ResultadoOperacion eliminarSemestre(semestres s)
        {
            CBTis123_Entities db = Vinculo_DB.generarContexto();

            // Validamos que no tenga grupos dependientes
            if (db.grupos.Where(g => g.idSemestre == s.idSemestre).Count() > 0)
            {
                return
                    new ResultadoOperacion(
                        EstadoOperacion.ErrorDependenciaDeDatos,
                        "El semestre contiene grupos");
            }

            ResultadoOperacion innerRO = null;

            int eliminado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                s = db.semestres.Single(s1 => s1.idSemestre == s.idSemestre);
                db.semestres.Remove(s);

                eliminado = db.SaveChanges();
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
                eliminado > 0 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Semestre eliminado")
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no eliminado",
                    null,
                    innerRO);
        }

        // Métodos misceláneos
        public bool validarSemestre(Semestre s)
        {
            throw new NotImplementedException();
        }
    }
}
