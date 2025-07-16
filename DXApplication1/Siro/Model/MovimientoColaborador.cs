using System;

namespace Siro.Model
{
    public class MovimientoColaborador
    {
        public int IdHoraTrabjada { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? MontoXHoras { get; set; }
        public DateTime Fecha { get; set; }
        public string Quincena { 
            get {
                if (Fecha.Day > 15)
                    return "Segunda Quincena";
                else
                    return "Primera Quincena";
            } 
        }
        public DateTime FechaProceso { get; set; }
        public int Año { get { return this.Fecha.Year; } }
        public int Mes { get { return this.Fecha.Month; } }
        public string TipoHora { get; set; }
        public int? IdFactor { get; set; }
        public string Comentario { get; set; }
    }
}
