﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CBTis123_Entities : DbContext
    {
        public CBTis123_Entities()
            : base("name=CBTis123_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<academias> academias { get; set; }
        public DbSet<areascampos> areascampos { get; set; }
        public DbSet<calificacionessemestrales> calificacionessemestrales { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<catedras> catedras { get; set; }
        public DbSet<docentes> docentes { get; set; }
        public DbSet<estudiantes> estudiantes { get; set; }
        public DbSet<fichas> fichas { get; set; }
        public DbSet<grupos> grupos { get; set; }
        public DbSet<grupos_estudiantes> grupos_estudiantes { get; set; }
        public DbSet<localidades> localidades { get; set; }
        public DbSet<materias> materias { get; set; }
        public DbSet<modulos> modulos { get; set; }
        public DbSet<municipios> municipios { get; set; }
        public DbSet<planea_d16_2017> planea_d16_2017 { get; set; }
        public DbSet<planea_mate16_d1_2017> planea_mate16_d1_2017 { get; set; }
        public DbSet<prefichas> prefichas { get; set; }
        public DbSet<prefichas2016> prefichas2016 { get; set; }
        public DbSet<prefichas2017> prefichas2017 { get; set; }
        public DbSet<semestres> semestres { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
