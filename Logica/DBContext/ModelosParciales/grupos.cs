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
                    case "ADMRH":
                        esp = "Administración de Recursos Humanos";
                        break;
                    case "ELE":
                        esp = "Electromecánica";
                        break;
                    case "LOG":
                        esp = "Logística";
                        break;
                    case "MAU":
                        esp = "Mantenimiento Automotriz";
                        break;
                    case "MEC":
                        esp = "Mecatrónica";
                        break;
                    case "PRO":
                        esp = "Programación";
                        break;
                    case "SMEC":
                        esp = "Soporte y Mantenimiento de Equipo de Cómputo";
                        break;
                    case "BGRAL":
                        esp = "Bachillerato General";
                        break;
                    default:
                        esp = "Desconocida";
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
