using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Catedra
    {
        public int idCatedra { get; set; }
        public int idDocente { get; set; }
        public int idMateria { get; set; }
        public int idGrupo { get; set; }

        public Docente docenteObj { get; set; }
        public Materia materiaObj { get; set; }
        public Grupo grupoObj { get; set; }

        public override string ToString()
        {
            return materiaObj.ToString() + " (" + docenteObj.ToString() + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Catedra))
            {
                Catedra c = (Catedra)obj;

                if (c.idCatedra == idCatedra)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
