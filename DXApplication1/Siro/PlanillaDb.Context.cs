﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Siro
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class slPlanilla : DbContext
    {
        public slPlanilla()
            : base("name=slPlanilla")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acredores> Acredores { get; set; }
        public virtual DbSet<ContratosColaborador> ContratosColaborador { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Descuentos> Descuentos { get; set; }
        public virtual DbSet<EntedidadesFinanciera> EntedidadesFinanciera { get; set; }
        public virtual DbSet<EstadosColaborador> EstadosColaborador { get; set; }
        public virtual DbSet<Posiciones> Posiciones { get; set; }
        public virtual DbSet<Rentas> Rentas { get; set; }
        public virtual DbSet<DetallesDescuento> DetallesDescuento { get; set; }
        public virtual DbSet<Colaboradores> Colaboradores { get; set; }
        public virtual DbSet<HorasTrabajadas> HorasTrabajadas { get; set; }
        public virtual DbSet<TiposFactor> TiposFactor { get; set; }
        public virtual DbSet<Factores> Factores { get; set; }
        public virtual DbSet<Deducciones> Deducciones { get; set; }
        public virtual DbSet<IngresosDeducciones> IngresosDeducciones { get; set; }
        public virtual DbSet<IngresosDeduccionesHoras> IngresosDeduccionesHoras { get; set; }
        public virtual DbSet<RegistroOtrosDeducciones> RegistroOtrosDeducciones { get; set; }
        public virtual DbSet<RegistroVacaciones> RegistroVacaciones { get; set; }
        public virtual DbSet<RegistroLiquidaciones> RegistroLiquidaciones { get; set; }
        public virtual DbSet<PlanillaColaborador> PlanillaColaborador { get; set; }
        public virtual DbSet<HistorialHoras> HistorialHoras { get; set; }
    
        public virtual int MaestroPlanilla(Nullable<int> idUser, Nullable<int> idEmpresa, Nullable<System.DateTime> getDate)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var getDateParameter = getDate.HasValue ?
                new ObjectParameter("GetDate", getDate) :
                new ObjectParameter("GetDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MaestroPlanilla", idUserParameter, idEmpresaParameter, getDateParameter);
        }
    
        public virtual int MaestroPlanillaCuentas(Nullable<int> idUser, Nullable<int> idEmpresa, Nullable<System.DateTime> getDate)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var getDateParameter = getDate.HasValue ?
                new ObjectParameter("GetDate", getDate) :
                new ObjectParameter("GetDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MaestroPlanillaCuentas", idUserParameter, idEmpresaParameter, getDateParameter);
        }
    
        public virtual int MaestroPlanillaIndividual(Nullable<int> idUser, Nullable<int> idEmpresa, Nullable<System.DateTime> getDate, Nullable<int> idColaborador, Nullable<decimal> salarioQ)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var getDateParameter = getDate.HasValue ?
                new ObjectParameter("GetDate", getDate) :
                new ObjectParameter("GetDate", typeof(System.DateTime));
    
            var idColaboradorParameter = idColaborador.HasValue ?
                new ObjectParameter("IdColaborador", idColaborador) :
                new ObjectParameter("IdColaborador", typeof(int));
    
            var salarioQParameter = salarioQ.HasValue ?
                new ObjectParameter("SalarioQ", salarioQ) :
                new ObjectParameter("SalarioQ", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MaestroPlanillaIndividual", idUserParameter, idEmpresaParameter, getDateParameter, idColaboradorParameter, salarioQParameter);
        }
    }
}
