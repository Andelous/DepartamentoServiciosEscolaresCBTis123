//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class estudiantes
    {
        public estudiantes()
        {
            this.calificaciones_semestrales = new HashSet<calificaciones_semestrales>();
            this.grupos_estudiantes = new HashSet<grupos_estudiantes>();
        }
    
        public int idEstudiante { get; set; }
        public string ncontrol { get; set; }
        public string curp { get; set; }
        public string nombrecompleto { get; set; }
        public string nombres { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nss { get; set; }
    
        public virtual ICollection<calificaciones_semestrales> calificaciones_semestrales { get; set; }
        public virtual ICollection<grupos_estudiantes> grupos_estudiantes { get; set; }


        // Métodos míos

        public override string ToString()
        {
            return nombrecompleto;
        }
    }
}
