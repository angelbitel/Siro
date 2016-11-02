using System;

namespace Siro.Model
{
    public class EntradasSalidas
    {
        public EntradasSalidas() { 
            this.Cantidad = 1;
        }
        public int IdInventario { get; set; }
        public int IdUser { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdTipoAlmacen { get; set; }
        public int IdAlmacen { get; set; }
        public string Comentario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PorcentajeDesCuentoSilo { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public decimal PorcentajeEntero { get; set; }
        public decimal PorcentajeQuebrado { get; set; }
        public DateTime Fecha { get; set; }
        public bool Modificado { get; set; }
    }
}
