﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias
{
    public class ResultadoOperacion
    {
        public EstadoOperacion estadoOperacion { get; }
        public string descripcion { get; }
        public string errCode { get; }

        public ResultadoOperacion(EstadoOperacion estadoOperacion, string descripcion = null, string errCode = null)
        {
            this.estadoOperacion = estadoOperacion;
            this.descripcion = descripcion;
            this.errCode = errCode;
        }

        public override string ToString()
        {
            string estadoOperacion = "_" + this.estadoOperacion.ToString() + "_\n";
            string parentesis = descripcion != null ? "(" + descripcion + ")\n" : "";
            string corchetes = errCode != null ? "[ErrCode: " + errCode + "]" : "";

            return estadoOperacion + parentesis + corchetes;
        }
    }

    public enum EstadoOperacion
    {
        // Estados vinculados con el usuario

        Correcto,
        NingunResultado,
        ErrorCredencialesIncorrectas,
        ErrorDatosIncorrectos,
        ErrorDependenciaDeDatos,

        
        
        // Estados no vinculados con el usuario

        ErrorDesconocido,
        ErrorAplicacion,
        ErrorConexionServidor,
        ErrorAcceso_SintaxisSQL,
        ErrorEnServidor
    }

    public static class EstadoOperacionMetodosExtension
    {
        // Metodos de extension para el enum.
        public static string mensajePredeterminado(this EstadoOperacion estadoOperacion)
        {
            switch (estadoOperacion)
            {
                // Estados vinculados con el usuario
                case EstadoOperacion.Correcto:
                    return "Operación realizada con éxito.";

                case EstadoOperacion.NingunResultado:
                    return "Ninguna operación realizada.";

                case EstadoOperacion.ErrorCredencialesIncorrectas:
                    return "Credenciales incorrectas.";

                case EstadoOperacion.ErrorDatosIncorrectos:
                    return "Datos incorrectos.";

                case EstadoOperacion.ErrorDependenciaDeDatos:
                    return "Error al intentar procesar la operación, existen datos que dependen del elemento que trata de manipular.";

                // Estados no vinculados del usuario.
                case EstadoOperacion.ErrorDesconocido:
                    return "Error desconocido.";

                case EstadoOperacion.ErrorAplicacion:
                    return "Error de la aplicación.";

                case EstadoOperacion.ErrorConexionServidor:
                    return "Error al intentar establecer conexión con el servidor.";

                case EstadoOperacion.ErrorAcceso_SintaxisSQL:
                    return "Error de acceso o sintaxis SQL.";

                case EstadoOperacion.ErrorEnServidor:
                    return "Error en el servidor.";

                default:
                    return "Resultado no reconocido.";
            }
        }
    }
}