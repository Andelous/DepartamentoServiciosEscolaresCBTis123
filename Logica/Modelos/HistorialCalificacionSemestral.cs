using DepartamentoServiciosEscolaresCBTis123.Logica.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class HistorialCalificacionSemestral
    {
        public string nombreDeCampo { get; set; }
        public string valorAnterior { get; set; }
        public string valorNuevo { get; set; }
        public string fecha { get; set; }
        public usuarios usuarioAutor { get; set; }
    }
}
