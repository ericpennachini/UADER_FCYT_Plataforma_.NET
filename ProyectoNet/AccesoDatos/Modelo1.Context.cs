﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Modelo1Container : DbContext
    {
        public Modelo1Container()
            : base("name=Modelo1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Factor> FactorSet { get; set; }
        public virtual DbSet<Caracteristica> CaracteristicaSet { get; set; }
        public virtual DbSet<Proyecto> ProyectoSet { get; set; }
        public virtual DbSet<Gerente> GerenteSet { get; set; }
        public virtual DbSet<Caracterizacion> CaracterizacionSet { get; set; }
    }
}
