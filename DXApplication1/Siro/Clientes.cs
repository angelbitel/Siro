//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public Clientes()
        {
            this.RegistrosBanco = new HashSet<RegistrosBanco>();
            this.Cotizaciones = new HashSet<Cotizaciones>();
        }
    
        public int idCliente { get; set; }
        public string CedulaRuc { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<int> IdTipoCliente { get; set; }
        public Nullable<int> IdClaseCliente { get; set; }
        public Nullable<int> IdRepresentanteLegal { get; set; }
        public Nullable<int> IdProvincia { get; set; }
        public Nullable<int> IdDistrito { get; set; }
        public Nullable<int> IdCorregimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string TelefonoOficina { get; set; }
        public string TelefonoMovil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> FechaCumpleaño { get; set; }
        public Nullable<int> idContacto { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public Nullable<int> DiasMorosidad { get; set; }
        public string Comentarios { get; set; }
        public byte[] img { get; set; }
        public string Titulo { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<bool> EsDiplomatico { get; set; }
        public Nullable<bool> EsProvedor { get; set; }
        public Nullable<int> IdPrecio { get; set; }
    
        public virtual ClasesCliente ClasesCliente { get; set; }
        public virtual Clientes Clientes1 { get; set; }
        public virtual Clientes Clientes2 { get; set; }
        public virtual Clientes Clientes11 { get; set; }
        public virtual Clientes Clientes3 { get; set; }
        public virtual TiposCliente TiposCliente { get; set; }
        public virtual ICollection<RegistrosBanco> RegistrosBanco { get; set; }
        public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }
        public virtual Precios Precios { get; set; }
    }
}