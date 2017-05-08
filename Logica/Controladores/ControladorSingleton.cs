using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Controladores
{
    public class ControladorSingleton
    {
        private static ControladorSemestres _controladorSemestres = new ControladorSemestres();
        public static ControladorSemestres controladorSemestres
        {
            get
            {
                return _controladorSemestres;
            }
        }

        private static ControladorGrupos _controladorGrupos = new ControladorGrupos();
        public static ControladorGrupos controladorGrupos
        {
            get
            {
                return _controladorGrupos;
            }
        }

        private static ControladorEstudiantes _controladorEstudiantes = new ControladorEstudiantes();
        public static ControladorEstudiantes controladorEstudiantes
        {
            get
            {
                return _controladorEstudiantes;
            }
        }

        private static ControladorSesion _controladorSesion = new ControladorSesion();
        public static ControladorSesion controladorSesion
        {
            get
            {
                return _controladorSesion;
            }
        }
    }
}
