using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartamentoServiciosEscolaresCBTis123.Logica.Modelos
{
    public class Calificacion
    {
        // ID
        public int idCalificaciones { get; set; }
        // FK's
        public int idEstudiante { get; set; }
        public int idCatedra { get; set; }

        // Datos de calificación de parciales
        public double calificacionParcial1 { get; set; }
        public double calificacionParcial2 { get; set; }
        public double calificacionParcial3 { get; set; }

        // Datos de asistencia de parciales
        public int asistenciasParcial1 { get; set; }
        public int asistenciasParcial2 { get; set; }
        public int asistenciasParcial3 { get; set; }
        
        // Datos extras
        public string tipoDeAcreditacion { get; set; }
        public bool firmado { get; set; }
        public bool recursamiento { get; set; }

        // Datos calculados automaticamente
        public double promedio
        {
            get
            {
                return (calificacionParcial1 + calificacionParcial2 + calificacionParcial3) / 3;
            }
        }
        public int asistenciasTotales
        {
            get
            {
                return asistenciasParcial1 + asistenciasParcial2 + asistenciasParcial3;
            }
        }
        
        public string ncontrol
        {
            get
            {
                return estudianteObj.ncontrol;
            }
        }
        public string nombre
        {
            get
            {
                return estudianteObj.nombreCompleto;
            }
        }

        /*
         * 
         * Propiedades experimentales
         * 
         */

        // Objetos
        public Estudiante estudianteObj { get; set; }
        public Catedra catedraObj { get; set; }
    }
}
