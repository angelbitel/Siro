using System;

namespace Siro.Model
{
    public class MovimientoColaborador
    {
        public int IdHoraTrabjada { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? MontoXHoras { get; set; }
        public DateTime Fecha { get; set; }
        public int Año { get { return this.Fecha.Year; } }
        public int Mes { get { return this.Fecha.Month; } }
        public string TipoHora { get; set; }
    }
}
