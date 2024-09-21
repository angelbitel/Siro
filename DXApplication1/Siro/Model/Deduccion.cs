using System;

namespace Siro.Model
{
    public class Deduccion
    {
        public int IdDeduccion { get; set; }
        public string Deducciones { get; set; }
        public string TipoDeduccion { get; set; }
        public string Acredor { get; set; }
        public int? IdAcredor{ get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> MontoPagado { get; set; }
        public Nullable<decimal> ArregloRecurrente { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Año {
            get
            {
                return FechaIngreso.Value.Year;
            }
        }
        public int? Mes
        {
            get
            {
                return FechaIngreso.Value.Month;
            }
        }
        public int? Dia
        {
            get
            {
                return FechaIngreso.Value.Day;
            }
        }
    }
}
