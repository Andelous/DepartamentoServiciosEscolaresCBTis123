using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
using MySql.Data.MySqlClient;
using MySqlUtilerias.Exception;
using ResultadosOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorExcepciones
    {
        public static ResultadoOperacion crearResultadoOperacionMySqlException(MySqlException e)
        {
            TipoError tipoError = MySqlExceptionHandler.obtenerTipoError(e);

            switch (tipoError)
            {
                case TipoError.ErrorConexionServidor:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorConexionServidor,
                            "MySqlException",
                            e.Number.ToString());

                case TipoError.ErrorDesconocido:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorDesconocido,
                            "MySqlException",
                            e.Number.ToString());

                case TipoError.ErrorEnServidor:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorEnServidor,
                            "MySqlException",
                            e.Number.ToString());

                case TipoError.ErrorAcceso_SintaxisSQL:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorAcceso_SintaxisSQL,
                            "MySqlException",
                            e.Number.ToString());

                case TipoError.ErrorAjenoMySql:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorAplicacion,
                            "MySqlException/Aplicación - " + e.Message,
                            e.Number.ToString());

                default:
                    return
                        new ResultadoOperacion(
                            EstadoOperacion.ErrorEnServidor,
                            "MySqlException",
                            e.Number.ToString());
            }
        }

        public static ResultadoOperacion crearResultadoOperacionException(Exception e)
        {
            return
                new ResultadoOperacion(
                    EstadoOperacion.ErrorAplicacion,
                    e.Message);
        }
    }
}
