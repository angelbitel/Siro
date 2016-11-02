using System;
namespace Siro.Model
{
    public class DetalleCotizacion
    {
        public int IdDetalleCotizacion { get; set; }
        public Nullable<int> IdCotizacion { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public decimal Monto { get; set; }
        public decimal ITBM { get; set; }
        public decimal Total { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdServicio { get; set; }
    }
}
