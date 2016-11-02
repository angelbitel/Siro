using System;
namespace Siro.Model
{
    public class Vacacion
    {
        public int IdRegistroVacacion { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public string TipoDeduccion { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> Desde { get; set; }
        public Nullable<System.DateTime> Hasta { get; set; }
        public Nullable<decimal> Brutas { get; set; }
        public Nullable<decimal> Descuentos { get; set; }
        public Nullable<decimal> Social { get; set; }
        public Nullable<decimal> Educativo { get; set; }
        public Nullable<decimal> ISR { get; set; }
        public Nullable<decimal> Neto { get; set; }
    }
}
