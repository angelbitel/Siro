﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Siro
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class slSiroCon : DbContext
    {
        public slSiroCon()
            : base("name=slSiroCon")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Almacenaje> Almacenaje { get; set; }
        public virtual DbSet<CicloAlmacenaje> CicloAlmacenaje { get; set; }
        public virtual DbSet<ClasesRA> ClasesRA { get; set; }
        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<DetalleVentasMovil> DetalleVentasMovil { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Procedencias> Procedencias { get; set; }
        public virtual DbSet<Productores> Productores { get; set; }
        public virtual DbSet<RA> RA { get; set; }
        public virtual DbSet<Recibidos> Recibidos { get; set; }
        public virtual DbSet<TiposAlmacen> TiposAlmacen { get; set; }
        public virtual DbSet<TiposArroz> TiposArroz { get; set; }
        public virtual DbSet<TiposMovimiento> TiposMovimiento { get; set; }
        public virtual DbSet<TiposVenta> TiposVenta { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentasMoviles> VentasMoviles { get; set; }
        public virtual DbSet<VValoresAlmacenaje> VValoresAlmacenaje { get; set; }
        public virtual DbSet<VRA> VRA { get; set; }
    }
}