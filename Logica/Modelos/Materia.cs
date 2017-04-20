using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Materia
    {
        public int idMateria { get; set; }
        public int idAreacampo { get; set; }
        public int idAcademia { get; set; }
        public int idCarrera { get; set; }
        public int idModulo { get; set; }

        public short subModulo { get; set; }
        public int semestre { get; set; }

        public string nombre { get; set; }
        public string abreviatura { get; set; }
        public string componenteF { get; set; }
        public string propedeutica { get; set; }

        public int hrsSemana { get; set; }
        public int hrsSemestre { get; set; }

        public override string ToString()
        {
            return nombre + " " + abreviatura;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Materia))
            {
                Materia m = (Materia)obj;

                if (m.idMateria == idMateria)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
