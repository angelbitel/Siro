using System;

namespace Siro.Model
{
    public class HoraReloj
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public int IdUser { get; set; }
        public string Time { get; set; }
        public TimeSpan TimeConverter
        {
            get
            {
                if (string.IsNullOrEmpty(Time))
                    return TimeSpan.Zero;
                return TimeSpan.Parse(Time);
            }
        }
        public bool Habilitar { get; set; }
        public string Colaborador { get; set; }
        public TimeSpan Delay { get; set; }
        public decimal TotalHours
        {
            get
            {
                return (decimal)Delay.TotalHours;
            }
        }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraEntradaSabado { get; set; }
        public TimeSpan? EntroALas { get; set; }
        public string DayOfWeek
        {
            get
            {
                return Date.ToString("dddd");
            }
        }
        public string Quitar
        {
            get
            {
                return "Quitar";
            }
        }
    }
}
