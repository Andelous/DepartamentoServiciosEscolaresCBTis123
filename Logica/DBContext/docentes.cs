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
    
    public partial class docentes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public docentes()
        {
            this.catedras = new HashSet<catedras>();
        }
    
        public int idDocente { get; set; }
        public string genero { get; set; }
        public short tarjeta { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public string nombres { get; set; }
        public string apellidop { get; set; }
        public string apellidom { get; set; }
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
        public System.DateTime fechaNacimiento { get; set; }
        public string auxRevision { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catedras> catedras { get; set; }
    }
}
