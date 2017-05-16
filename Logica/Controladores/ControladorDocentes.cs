using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public class ControladorDocentes
    {
        // DAOs necesarios
        private DAODocentes daoDocentes { get; set; }
        private DAOCatedras daoCatedras { get; set; }

        // Controladores necesarios

        // Métodos de iniciación
        public ControladorDocentes()
        {
            this.daoDocentes = new DAODocentes();
            this.daoCatedras = new DAOCatedras();
        }

        // Métodos de manipulación del modelo
        // Selección
        public List<Docente> seleccionarDocentes()
        {
            List<Docente> listaDocentes = new List<Docente>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
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

            // Devolvemos resultado
            return listaDocentes;
        }

        public List<Docente> seleccionarDocentes(string s)
        {
            List<Docente> listaDocentes = new List<Docente>();

            // Intentamos realizar la operación. Si hubo algún error,
            // el controlador visual mostrará el mensaje correspondiente.
            try
            {
                listaDocentes = daoDocentes.seleccionarDocentesPorCoincidencia(s);
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
            return listaDocentes;
        }

        // Registro
        public ResultadoOperacion registrarDocente(
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
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(genero) ||
                !ValidadorDeTexto.esValido(curp) ||
                !ValidadorDeTexto.esValido(rfc) ||
                !ValidadorDeTexto.esValido(nombres) ||
                !ValidadorDeTexto.esValido(apellidop) ||
                !ValidadorDeTexto.esValido(apellidom) ||
                !ValidadorDeTexto.esValido(estado) ||
                !ValidadorDeTexto.esValido(correoi) ||
                !ValidadorDeTexto.esValido(correop) ||
                !ValidadorDeTexto.esValido(nivelmedioTit) ||
                !ValidadorDeTexto.esValido(nivelmedio) ||
                !ValidadorDeTexto.esValido(dnivelmedio) ||
                !ValidadorDeTexto.esValido(tecnicosuperiorTit) ||
                !ValidadorDeTexto.esValido(tecnicosuperior) ||
                !ValidadorDeTexto.esValido(dtecnicosuperior) ||
                !ValidadorDeTexto.esValido(licenciatura1Tit) ||
                !ValidadorDeTexto.esValido(licenciatura1) ||
                !ValidadorDeTexto.esValido(dlicenciatura1) ||
                !ValidadorDeTexto.esValido(licenciatura2Tit) ||
                !ValidadorDeTexto.esValido(licenciatura2) ||
                !ValidadorDeTexto.esValido(dlicenciatura2) ||
                !ValidadorDeTexto.esValido(especialidad1) ||
                !ValidadorDeTexto.esValido(despecialidad1) ||
                !ValidadorDeTexto.esValido(especialidad2) ||
                !ValidadorDeTexto.esValido(despecialidad2) ||
                !ValidadorDeTexto.esValido(maestria1Tit) ||
                !ValidadorDeTexto.esValido(maestria1) ||
                !ValidadorDeTexto.esValido(dmaestria1) ||
                !ValidadorDeTexto.esValido(maestria2Tit) ||
                !ValidadorDeTexto.esValido(maestria2) ||
                !ValidadorDeTexto.esValido(dmaestria2) ||
                !ValidadorDeTexto.esValido(doctoradoTit) ||
                !ValidadorDeTexto.esValido(doctorado) ||
                !ValidadorDeTexto.esValido(ddoctorado) ||
                !ValidadorDeTexto.esValido(telefonoCelular) ||
                !ValidadorDeTexto.esValido(telefono) ||
                !ValidadorDeTexto.esValido(paisNacimiento) ||
                !ValidadorDeTexto.esValido(estadoNacimiento) ||
                !ValidadorDeTexto.esValido(auxRevision)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Docente d =
                DAODocentes.
                crearDocente(
                    -1,
                    genero,
                    tarjeta,
                    curp,
                    rfc,
                    nombres,
                    apellidop,
                    apellidom,
                    estado,
                    correoi,
                    correop,
                    nivelmedioTit,
                    nivelmedio,
                    dnivelmedio,
                    tecnicosuperiorTit,
                    tecnicosuperior,
                    dtecnicosuperior,
                    licenciatura1Tit,
                    licenciatura1,
                    dlicenciatura1,
                    licenciatura2Tit,
                    licenciatura2,
                    dlicenciatura2,
                    especialidad1,
                    despecialidad1,
                    especialidad2,
                    despecialidad2,
                    maestria1Tit,
                    maestria1,
                    dmaestria1,
                    maestria2Tit,
                    maestria2,
                    dmaestria2,
                    doctoradoTit,
                    doctorado,
                    ddoctorado,
                    telefonoCelular,
                    telefono,
                    paisNacimiento,
                    estadoNacimiento,
                    fechaNacimiento,
                    auxRevision);

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                registrado = daoDocentes.insertarDocente(d);
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
                registrado == 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Docente registrado")
                :
                registrado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más docentes",
                    "DocReg " + registrado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Docente no registrado",
                    null,
                    innerRO);
        }

        // Modificación
        public ResultadoOperacion modificarDocente(
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
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(genero) ||
                !ValidadorDeTexto.esValido(curp) ||
                !ValidadorDeTexto.esValido(rfc) ||
                !ValidadorDeTexto.esValido(nombres) ||
                !ValidadorDeTexto.esValido(apellidop) ||
                !ValidadorDeTexto.esValido(apellidom) ||
                !ValidadorDeTexto.esValido(estado) ||
                !ValidadorDeTexto.esValido(correoi) ||
                !ValidadorDeTexto.esValido(correop) ||
                !ValidadorDeTexto.esValido(nivelmedioTit) ||
                !ValidadorDeTexto.esValido(nivelmedio) ||
                !ValidadorDeTexto.esValido(dnivelmedio) ||
                !ValidadorDeTexto.esValido(tecnicosuperiorTit) ||
                !ValidadorDeTexto.esValido(tecnicosuperior) ||
                !ValidadorDeTexto.esValido(dtecnicosuperior) ||
                !ValidadorDeTexto.esValido(licenciatura1Tit) ||
                !ValidadorDeTexto.esValido(licenciatura1) ||
                !ValidadorDeTexto.esValido(dlicenciatura1) ||
                !ValidadorDeTexto.esValido(licenciatura2Tit) ||
                !ValidadorDeTexto.esValido(licenciatura2) ||
                !ValidadorDeTexto.esValido(dlicenciatura2) ||
                !ValidadorDeTexto.esValido(especialidad1) ||
                !ValidadorDeTexto.esValido(despecialidad1) ||
                !ValidadorDeTexto.esValido(especialidad2) ||
                !ValidadorDeTexto.esValido(despecialidad2) ||
                !ValidadorDeTexto.esValido(maestria1Tit) ||
                !ValidadorDeTexto.esValido(maestria1) ||
                !ValidadorDeTexto.esValido(dmaestria1) ||
                !ValidadorDeTexto.esValido(maestria2Tit) ||
                !ValidadorDeTexto.esValido(maestria2) ||
                !ValidadorDeTexto.esValido(dmaestria2) ||
                !ValidadorDeTexto.esValido(doctoradoTit) ||
                !ValidadorDeTexto.esValido(doctorado) ||
                !ValidadorDeTexto.esValido(ddoctorado) ||
                !ValidadorDeTexto.esValido(telefonoCelular) ||
                !ValidadorDeTexto.esValido(telefono) ||
                !ValidadorDeTexto.esValido(paisNacimiento) ||
                !ValidadorDeTexto.esValido(estadoNacimiento) ||
                !ValidadorDeTexto.esValido(auxRevision)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            ResultadoOperacion innerRO = null;

            Docente d =
                DAODocentes.
                crearDocente(
                    idDocente,
                    genero,
                    tarjeta,
                    curp,
                    rfc,
                    nombres,
                    apellidop,
                    apellidom,
                    estado,
                    correoi,
                    correop,
                    nivelmedioTit,
                    nivelmedio,
                    dnivelmedio,
                    tecnicosuperiorTit,
                    tecnicosuperior,
                    dtecnicosuperior,
                    licenciatura1Tit,
                    licenciatura1,
                    dlicenciatura1,
                    licenciatura2Tit,
                    licenciatura2,
                    dlicenciatura2,
                    especialidad1,
                    despecialidad1,
                    especialidad2,
                    despecialidad2,
                    maestria1Tit,
                    maestria1,
                    dmaestria1,
                    maestria2Tit,
                    maestria2,
                    dmaestria2,
                    doctoradoTit,
                    doctorado,
                    ddoctorado,
                    telefonoCelular,
                    telefono,
                    paisNacimiento,
                    estadoNacimiento,
                    fechaNacimiento,
                    auxRevision);

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                modificado = daoDocentes.modificarDocente(d);
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
                    "Docente modificado")
                :
                modificado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más docentes",
                    "DocMod " + modificado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Docente no modificado",
                    null,
                    innerRO);
        }

        // Eliminación
        public ResultadoOperacion eliminarDocente(Docente d)
        {
            ResultadoOperacion innerRO = null;

            int eliminado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                // Validamos que no tenga cátedras...
                if (daoCatedras.seleccionarCatedrasPorDocente(d).Count > 0)
                {
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorDependenciaDeDatos,
                            "El docente imparte clases a uno o más grupos");
                }

                eliminado = daoDocentes.eliminarDocente(d);
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
                    "Docente eliminado")
                :
                eliminado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han eliminado dos o más docentes",
                    "DocElim " + eliminado.ToString(),
                    innerRO)
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Docente no eliminado",
                    null,
                    innerRO);
        }

    }
}
