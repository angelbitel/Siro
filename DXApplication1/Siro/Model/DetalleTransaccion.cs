using System;

namespace Siro.Model
{
    public class DetalleTransaccion
    {
        public string Descripcion { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> IdServicio { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> ITBM { get; set; }
        public Nullable<decimal> IngresoSubsidio { get; set; }
        public Nullable<decimal> itbm { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public int IdCliente { get; set; }
        public Nullable<int> IdPrecioProducto { get; set; }
    }
}
