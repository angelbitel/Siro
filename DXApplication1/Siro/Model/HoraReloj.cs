using System;

namespace Siro.Model
{
    public class HoraReloj
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Time { get; set; }
        public TimeSpan TimeConverter
        {
            get
            {
                return TimeSpan.Parse(Time);
            }
        }
        public bool Habilitar { get; set; }
        public string Colaborador { get; set; }
    }
}
