using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOSingleton
    {
        private static DAOCarreras _daoCarreras = new DAOCarreras();
        public static DAOCarreras daoCarreras
        {
            get
            {
                return _daoCarreras;
            }
        }

        private static DAOCatedras _daoCatedras = new DAOCatedras();
        public static DAOCatedras daoCatedras
        {
            get
            {
                return _daoCatedras;
            }
        }

        private static DAODocentes _daoDocentes = new DAODocentes();
        public static DAODocentes daoDocentes
        {
            get
            {
                return _daoDocentes;
            }
        }

        private static DAOEstudiantes _daoEstudiantes = new DAOEstudiantes();
        public static DAOEstudiantes daoEstudiantes
        {
            get
            {
                return _daoEstudiantes;
            }
        }

        private static DAOGrupo_Estudiante _daoGrupo_Estudiante = new DAOGrupo_Estudiante();
        public static DAOGrupo_Estudiante daoGrupo_Estudiante
        {
            get
            {
                return _daoGrupo_Estudiante;
            }
        }

        private static DAOGrupos _daoGrupos = new DAOGrupos();
        public static DAOGrupos daoGrupos
        {
            get
            {
                return _daoGrupos;
            }
        }

        private static DAOMaterias _daoMaterias = new DAOMaterias();
        public static DAOMaterias daoMaterias
        {
            get
            {
                return _daoMaterias;
            }
        }

        private static DAOSemestres _daoSemestres = new DAOSemestres();
        public static DAOSemestres daoSemestres
        {
            get
            {
                return _daoSemestres;
            }
        }

        private static DAOUsuarios _daoUsuarios = new DAOUsuarios();
        public static DAOUsuarios daoUsuarios
        {
            get
            {
                return _daoUsuarios;
            }
        }
    }
}
