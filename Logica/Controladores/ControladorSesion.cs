using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using DepartamentoServiciosEscolaresCBTis123.Logica.Utilerias;
using MySql.Data.MySqlClient;
using MySqlUtilerias.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorSesion
    {
        public Usuario usuarioActivo { get; set; }

        public DAOUsuarios daoUsuarios { get; set; }

        public DAOSemestres daoSemestres { get; set; }
        public DAOGrupos daoGrupos { get; set; }
        public DAOEstudiantes daoEstudiantes { get; set; }
        public DAOCarreras daoCarreras { get; set; }
        public DAOMaterias daoMaterias { get; set; }
        public DAOCatedras daoCatedras { get; set; }
        public DAODocentes daoDocentes { get; set; }

        public bool isSesionIniciada {
            get
            {
                return usuarioActivo != null;
            }
        }

        public ControladorSesion()
        {
            daoUsuarios = new DAOUsuarios();
            
            daoGrupos = new DAOGrupos();
            daoEstudiantes = new DAOEstudiantes();
            daoCarreras = new DAOCarreras();
            daoMaterias = new DAOMaterias();
            daoCatedras = new DAOCatedras();
            daoDocentes = new DAODocentes();
            
        }

        public ResultadoOperacion iniciarSesion(string usuario, string contrasena)
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

        public void cerrarSesion()
        {
            usuarioActivo = null;
        }
    }
}
