﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca_de_Clases.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NotariaEntities : DbContext
    {
        public NotariaEntities()
            : base("name=NotariaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<comuna> comuna { get; set; }
        public virtual DbSet<doc_emitido> doc_emitido { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<info_notaria> info_notaria { get; set; }
        public virtual DbSet<kpi_atencion_clientes> kpi_atencion_clientes { get; set; }
        public virtual DbSet<kpi_tramites_realizados> kpi_tramites_realizados { get; set; }
        public virtual DbSet<perfil> perfil { get; set; }
        public virtual DbSet<region> region { get; set; }
        public virtual DbSet<reserva> reserva { get; set; }
        public virtual DbSet<template_documento> template_documento { get; set; }
        public virtual DbSet<tipo_tramite> tipo_tramite { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<ventas_online> ventas_online { get; set; }
        public virtual DbSet<ventas_presencial> ventas_presencial { get; set; }
    }
}
