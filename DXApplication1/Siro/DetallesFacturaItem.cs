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
    
    public partial class DetallesFacturaItem
    {
        public int IdDetalleFacturaItem { get; set; }
        public Nullable<int> IdDetalleFactura { get; set; }
        public string Producto { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> ITBMS { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<bool> ActualizaInventario { get; set; }
        public Nullable<int> IdAlmacen { get; set; }
    
        public virtual DetallesFactura DetallesFactura { get; set; }
    }
}
