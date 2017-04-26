﻿using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
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
    public class ControladorSemestres
    {
        // Propiedades
        private DAOSemestres daoSemestres { get; set; }
        private ControladorGrupos controladorGrupos { get; set; }

        // Inicialización
        public ControladorSemestres(ControladorGrupos controladorGrupos = null)
        {
            daoSemestres = new DAOSemestres();
            this.controladorGrupos =
                controladorGrupos != null
                ?
                controladorGrupos
                :
                new ControladorGrupos(this);
        }


        // Métodos de manipulación del modelo.
        // Selección
        public List<Semestre> seleccionarSemestres()
        {
            List<Semestre> listaSemestres = new List<Semestre>();

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

            return listaSemestres;
        }

        // Registro
        public ResultadoOperacion registrarSemestre(
            string nombre, 
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombre) ||
                !ValidadorDeTexto.esValido(nombreCorto) ||
                !ValidadorDeTexto.esValido(nombreCorto2) ||
                !ValidadorDeTexto.esValido(nombreCorto3)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            Semestre s = 
                DAOSemestres.
                crearSemestre(
                    -1,
                    nombre,
                    nombreCorto,
                    nombreCorto2,
                    nombreCorto3
                );

            int registrado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                registrado = daoSemestres.insertarSemestre(s);
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
                    "Semestre registrado")
                :
                registrado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han registrado dos o más semestres",
                    "SemReg " + registrado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no registrado");
        }

        // Modificación
        public ResultadoOperacion modificarSemestre(
            int idSemestre, 
            string nombre, 
            string nombreCorto, 
            string nombreCorto2, 
            string nombreCorto3
        ) {
            // Verificamos que los datos introducidos
            // sean válidos para la base de datos.
            if (
                !ValidadorDeTexto.esValido(nombre) ||
                !ValidadorDeTexto.esValido(nombreCorto) ||
                !ValidadorDeTexto.esValido(nombreCorto2) ||
                !ValidadorDeTexto.esValido(nombreCorto3)
            ) {
                // Devolvemos un error si es que no son válidos.
                return new ResultadoOperacion(
                    EstadoOperacion.ErrorDatosIncorrectos,
                    "No utilice caracteres especiales o inválidos");
            }

            Semestre s =
                DAOSemestres.
                crearSemestre(
                    idSemestre,
                    nombre,
                    nombreCorto,
                    nombreCorto2,
                    nombreCorto3
                );

            int modificado = 0;

            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                modificado = daoSemestres.modificarSemestre(s);
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
                    "Semestre modificado")
                :
                modificado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han modificado dos o más semestres",
                    "SemMod " + modificado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no modificado");
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

            int eliminado = 0;
            
            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                eliminado = daoSemestres.eliminarSemestre(s);
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
                    "Semestre eliminado")
                :
                eliminado > 1 ?
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    "Se han eliminado dos o más semestres",
                    "SemElim " + eliminado.ToString())
                :
                new ResultadoOperacion(
                    EstadoOperacion.NingunResultado,
                    "Semestre no eliminado");
        }


        // Métodos misceláneos
        public bool validarSemestre(Semestre s)
        {
            throw new NotImplementedException();
        }
    }
}