//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartamentoServiciosEscolaresCBTis123.Logica.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class calificaciones_semestrales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calificaciones_semestrales()
        {
            this.historial_calificaciones_semestrales = new HashSet<historial_calificaciones_semestrales>();
        }
    
        public int idCalificacion_Semestral { get; set; }
        public bool recursamiento { get; set; }
        public bool firmado { get; set; }
        public bool verificado { get; set; }
        public int idEstudiante { get; set; }
        public int idCatedra { get; set; }
    
        public virtual estudiantes estudiantes { get; set; }
        public virtual catedras catedras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historial_calificaciones_semestrales> historial_calificaciones_semestrales { get; set; }
    }
}
