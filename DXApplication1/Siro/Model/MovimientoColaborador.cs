using System;

namespace Siro.Model
{
    public class MovimientoColaborador
    {
        public int IdHoraTrabjada { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? MontoXHoras { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaProceso { get; set; }
        public int Año { get { return this.FechaProceso.Year; } }
        public int Mes { get { return this.FechaProceso.Month; } }
        public string TipoHora { get; set; }
    }
}
