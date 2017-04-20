using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
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
            try
            {
                usuarioActivo = 
                    daoUsuarios.
                    seleccionarUsuarioPorUsuarioContrasena
                    (
                        usuario,
                        contrasena
                    );
            }
            catch (MySqlException e)
            {
                TipoError te = MySqlExceptionHandler.obtenerTipoError(e);

                switch (te)
                {
                    case TipoError.ErrorConexionServidor:
                        return ResultadoOperacion.ErrorConexionServidor;
                    case TipoError.ErrorDesconocido:
                        return ResultadoOperacion.ErrorDesconocido;
                    case TipoError.ErrorEnServidor:
                        return ResultadoOperacion.ErrorEnServidor;
                    case TipoError.ErrorAcceso_SintaxisSQL:
                        return ResultadoOperacion.ErrorAcceso_SintaxisSQL;
                    case TipoError.ErrorAjenoMySql:
                        return ResultadoOperacion.ErrorAplicacion;
                    default:
                        return ResultadoOperacion.Error;
                }
            }
            catch (Exception)
            {
                return ResultadoOperacion.ErrorAplicacion;
            }

            return 
                usuarioActivo != null ? 
                ResultadoOperacion.Correcto : 
                ResultadoOperacion.ErrorCredencialesIncorrectas;
        }

        public void cerrarSesion()
        {
            usuarioActivo = null;
        }
    }
}
