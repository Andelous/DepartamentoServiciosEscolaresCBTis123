using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Docente
    {
        public int idDocente { get; set; }
        public string genero { get; set; }
        public int tarjeta { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public string nombres { get; set; }
        public string apellidop { get; set; }
        public string apellidom { get; set; }

        public string nombrecompleto {
            get
            {
                return apellidop.Trim() + " " + apellidom.Trim() + " " + nombres.Trim();
            }
        }

        public string estado { get; set; }
        public string correoi { get; set; }
        public string correop { get; set; }
        public string nivelmedioTit { get; set; }
        public string nivelmedio { get; set; }
        public string dnivelmedio { get; set; }
        public string tecnicosuperiorTit { get; set; }
        public string tecnicosuperior { get; set; }
        public string dtecnicosuperior { get; set; }
        public string licenciatura1Tit { get; set; }
        public string licenciatura1 { get; set; }
        public string dlicenciatura1 { get; set; }
        public string licenciatura2Tit { get; set; }
        public string licenciatura2 { get; set; }
        public string dlicenciatura2 { get; set; }
        public string especialidad1 { get; set; }
        public string despecialidad1 { get; set; }
        public string especialidad2 { get; set; }
        public string despecialidad2 { get; set; }
        public string maestria1Tit { get; set; }
        public string maestria1 { get; set; }
        public string dmaestria1 { get; set; }
        public string maestria2Tit { get; set; }
        public string maestria2 { get; set; }
        public string dmaestria2 { get; set; }
        public string doctoradoTit { get; set; }
        public string doctorado { get; set; }
        public string ddoctorado { get; set; }
        public string telefonoCelular { get; set; }
        public string telefono { get; set; }
        public string paisNacimiento { get; set; }
        public string estadoNacimiento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string auxRevision { get; set; }

        public override string ToString()
        {
            return nombrecompleto;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Docente))
            {
                Docente d = (Docente)obj;

                if (d.idDocente == idDocente)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
