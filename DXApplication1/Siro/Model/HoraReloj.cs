using System;

namespace Siro.Model
{
    public class HoraReloj
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Time { get; set; }
        public TimeSpan TimeConverter
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Time))
                    return TimeSpan.Zero;

                if (TimeSpan.TryParse(Time, out TimeSpan resultado))
                    return resultado;

                return TimeSpan.Zero; // o lanza una excepción si prefieres
            }
        }
        public bool Habilitar { get; set; }
        public string Colaborador { get; set; }
        public TimeSpan Delay { get; set; }
        public string DelayFormat
        {
            get
            {
                return Delay.ToString((@"hh\:mm"));
            }
        }
        public decimal TotalHours
        {
            get
            {
                return (decimal)Delay.TotalHours;
            }
        }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public TimeSpan? HoraEntradaSabado { get; set; }
        public TimeSpan? EntroALas { get; set; }
        public TimeSpan? SalioALas { get; set; }
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
        public bool EsAusenciaJustificada { get; set; }
        public string Comentario { get; set; }
    }
}
