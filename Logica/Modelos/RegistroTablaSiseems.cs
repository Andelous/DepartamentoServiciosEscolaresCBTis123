using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class RegistroTablaSiseems
    {
        // Datos alumno
        public int noLista { get; set; }
        public string noControl { get; set; }
        public string nombre { get; set; }

        // Datos de calificación de parciales
        public int parcial1 { get; set; }
        public int parcial2 { get; set; }
        public int parcial3 { get; set; }

        // Datos de asistencia de parciales
        public int asistenciasParcial1 { get; set; }
        public int asistenciasParcial2 { get; set; }
        public int asistenciasParcial3 { get; set; }

        // Datos extras
        public int promedio { get; set; }
        public int asistencias { get; set; }
        public string tipoDeAcreditacion { get; set; }
        public bool firmado { get; set; }
    }
}
