﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notaria.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PortafolioEntities : DbContext
    {
        public PortafolioEntities()
            : base("name=PortafolioEntities")
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
    
        public virtual ObjectResult<buscar_documento_Result> buscar_documento(string rut)
        {
            var rutParameter = rut != null ?
                new ObjectParameter("rut", rut) :
                new ObjectParameter("rut", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_documento_Result>("buscar_documento", rutParameter);
        }
    
        public virtual ObjectResult<buscar_reservas_Result> buscar_reservas(string rut)
        {
            var rutParameter = rut != null ?
                new ObjectParameter("rut", rut) :
                new ObjectParameter("rut", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_reservas_Result>("buscar_reservas", rutParameter);
        }
    
        public virtual ObjectResult<buscar_ventas_pendientes_Result> buscar_ventas_pendientes(string estado)
        {
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_ventas_pendientes_Result>("buscar_ventas_pendientes", estadoParameter);
        }
    
        public virtual ObjectResult<buscar_ventas_pres_Result> buscar_ventas_pres(string rut)
        {
            var rutParameter = rut != null ?
                new ObjectParameter("rut", rut) :
                new ObjectParameter("rut", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscar_ventas_pres_Result>("buscar_ventas_pres", rutParameter);
        }
    
        public virtual ObjectResult<filtrar_rut_Result> filtrar_rut(string rut)
        {
            var rutParameter = rut != null ?
                new ObjectParameter("rut", rut) :
                new ObjectParameter("rut", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<filtrar_rut_Result>("filtrar_rut", rutParameter);
        }
    
        public virtual ObjectResult<llenarComboComuna_Result> llenarComboComuna(string cod_region)
        {
            var cod_regionParameter = cod_region != null ?
                new ObjectParameter("cod_region", cod_region) :
                new ObjectParameter("cod_region", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<llenarComboComuna_Result>("llenarComboComuna", cod_regionParameter);
        }
    }
}
