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
    
    public partial class grupos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupos()
        {
            this.catedras = new HashSet<catedras>();
            this.grupos_estudiantes = new HashSet<grupos_estudiantes>();
        }
    
        public int idGrupo { get; set; }
        public int idSemestre { get; set; }
        public int semestre { get; set; }
        public string letra { get; set; }
        public string turno { get; set; }
        public string especialidad { get; set; }
        public int idCarrera { get; set; }
    
        public virtual carreras carreras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catedras> catedras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupos_estudiantes> grupos_estudiantes { get; set; }
        public virtual semestres semestres { get; set; }
    }
}
