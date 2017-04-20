using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Grupo
    {

        public string nombreCompleto
        {
            get
            {
                return semestre.ToString() + letra + _turno + "-" +especialidad;
            }
        }

        public int idGrupo { get; set; }
        public int idSemestre { get; set; }
        public int semestre { get; set; }
        public string letra { get; set; }

        private string _turno;
        public string turno {
            get
            {
                return _turno == "V" ? "Vespertino" : _turno == "M" ? "Matutino" : "Desconocido (" + _turno + ")";
            }

            set
            {
                _turno = value[0].ToString().ToUpper();
            }
        }

        public string especialidad { get; set; }
        public Semestre semestreObj { get; set; }
        public Carrera especialidadObj { get; set; }

        public override string ToString()
        {
            return nombreCompleto;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Grupo))
            {
                Grupo g = (Grupo)obj;

                if (g.idGrupo == idGrupo)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
