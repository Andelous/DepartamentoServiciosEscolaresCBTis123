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
    
    public partial class catedras
    {
        public catedras()
        {
            this.calificaciones_semestrales = new HashSet<calificaciones_semestrales>();
        }
    
        public int idCatedra { get; set; }
        public Nullable<int> idDocente { get; set; }
        public int idMateria { get; set; }
        public int idGrupo { get; set; }
    
        public virtual ICollection<calificaciones_semestrales> calificaciones_semestrales { get; set; }
        public virtual docentes docentes { get; set; }
        public virtual materias materias { get; set; }
        public virtual grupos grupos { get; set; }
        

        // Métodos míos
        public override string ToString()
        {
            return materias.ToString() + " (" + docentes.ToString() + ")";
        }
    }
}
