using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Grupo_Estudiante
    {
        public int idGrupo_Estudiante { get; set; }
        public int idGrupo { get; set; }
        public int idEstudiante { get; set; }
        
        public Grupo grupoObj { get; set; }
        public Estudiante estudianteObj { get; set; }

        public override string ToString()
        {
            return estudianteObj.ToString() + " pertenece a " + grupoObj.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Grupo_Estudiante))
                {
                    Grupo_Estudiante ge = (Grupo_Estudiante)obj;

                    if (ge.idGrupo_Estudiante == idGrupo_Estudiante)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
