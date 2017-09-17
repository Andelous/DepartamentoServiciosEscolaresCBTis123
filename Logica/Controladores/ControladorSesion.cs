using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
    public class ControladorSesion
    {
        public static Usuario usuarioActivo { get; set; }

        public static DAOUsuarios daoUsuarios
        {
            get
            {
                return DAOSingleton.daoUsuarios;
            }
        }

        public static bool isSesionIniciada {
            get
            {
                return usuarioActivo != null;
            }
        }

        public static ResultadoOperacion iniciarSesion(string usuario, string contrasena)
        {
            // Si hay algún error durante la ejecución de la operación
            // se devolverá el respectivo resultado de operación.
            try
            {
                usuarioActivo = 
                    daoUsuarios.
                    seleccionarUsuarioPorUsuarioContrasena(
                        usuario,
                        contrasena);
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
                usuarioActivo != null ?
                new ResultadoOperacion(
                    EstadoOperacion.Correcto,
                    "Login")
                :
                new ResultadoOperacion(
                    EstadoOperacion.ErrorCredencialesIncorrectas,
                    "Login");
        }

        public static void cerrarSesion()
        {
            usuarioActivo = null;
        }
    }
}
