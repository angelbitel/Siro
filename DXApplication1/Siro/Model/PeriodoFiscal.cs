using System;

namespace Siro.Model
{
    public class PeriodoFiscal
    {
        public int IdPeriodoFiscal { get; set;}
        public DateTime Desde { get; set;}
        public DateTime Hasta { get; set;}
        public string Comentario { get; set; }
    }
}
