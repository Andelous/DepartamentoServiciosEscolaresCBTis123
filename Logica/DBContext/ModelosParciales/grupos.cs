using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    public partial class grupos
    {
        // Propiedades mías 
        public string nombreCompleto
        {
            get
            {
                return semestre.ToString() + letra + turno + "-" + especialidad;
            }
        }

        public string turnoCompleto
        {
            get
            {
                string t = turno.ToUpper();

                switch (t)
                {
                    case "M":
                        return "Matutino";
                    case "V":
                        return "Vespertino";
                }

                return "Desconocido";
            }
        }
        public string especialidadCompleta
        {
            get
            {
                string esp = especialidad;

                switch (esp)
                {
                    default:
                        break;
                }

                return esp;
            }
        }

        // Métodos míos
        public override string ToString()
        {
            return nombreCompleto;
        }
    }
}
