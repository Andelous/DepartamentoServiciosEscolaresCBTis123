using DepartamentoServiciosEscolaresCBTis123.Logica.DAOs;
using DepartamentoServiciosEscolaresCBTis123.Logica.Modelos;
using MySql.Data.MySqlClient;
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
                    seleccionarUsuarioPorUsuarioContrasena(
                        usuario,
                        contrasena
                    );
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042:
                        return ResultadoOperacion.ErrorConexionServidor;
                    case 1105:
                        return ResultadoOperacion.Error;
                    default:
                        return ResultadoOperacion.ErrorSintaxisSQL;
                }
            }
            catch (Exception)
            {
                return ResultadoOperacion.ErrorAplicacion;
            }

            return 
                usuarioActivo != null ? 
                ResultadoOperacion.Correcto : 
                ResultadoOperacion.ErrorDatosIncorrectos;
        }

        public void cerrarSesion()
        {
            usuarioActivo = null;
        }
    }
}
