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
    
    public partial class Servicios
    {
        public Servicios()
        {
            this.PrecioProducto = new HashSet<PrecioProducto>();
            this.DetallesTransaccione = new HashSet<DetallesTransaccione>();
        }
    
        public int IdServicio { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string Servicios1 { get; set; }
        public Nullable<decimal> Precio { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual ICollection<PrecioProducto> PrecioProducto { get; set; }
        public virtual ICollection<DetallesTransaccione> DetallesTransaccione { get; set; }
        public virtual Categorias Categorias { get; set; }
    }
}