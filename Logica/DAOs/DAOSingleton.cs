using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DAOs
{
    public class DAOSingleton
    {
        private static DAOCarreras _daoCarreras;
        public static DAOCarreras daoCarreras
        {
            get
            {
                return _daoCarreras;
            }
        }

        private static DAOCatedras _daoCatedras;
        public static DAOCatedras daoCatedras
        {
            get
            {
                return _daoCatedras;
            }
        }

        private static DAODocentes _daoDocentes;
        public static DAODocentes daoDocentes
        {
            get
            {
                return _daoDocentes;
            }
        }

        private static DAOEstudiantes _daoEstudiantes;
        public static DAOEstudiantes daoEstudiantes
        {
            get
            {
                return _daoEstudiantes;
            }
        }

        private static DAOGrupo_Estudiante _daoGrupo_Estudiante;
        public static DAOGrupo_Estudiante daoGrupo_Estudiante
        {
            get
            {
                return _daoGrupo_Estudiante;
            }
        }

        private static DAOGrupos _daoGrupos;
        public static DAOGrupos daoGrupos
        {
            get
            {
                return _daoGrupos;
            }
        }

        private static DAOMaterias _daoMaterias;
        public static DAOMaterias daoMaterias
        {
            get
            {
                return _daoMaterias;
            }
        }

        private static DAOSemestres _daoSemestres;
        public static DAOSemestres daoSemestres
        {
            get
            {
                return _daoSemestres;
            }
        }

        private static DAOUsuarios _daoUsuarios;
        public static DAOUsuarios daoUsuarios
        {
            get
            {
                return _daoUsuarios;
            }
        }
    }
}
