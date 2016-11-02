using System;

namespace Siro.Model
{
    public class Colaborador
    {

        public int IdColaborador { get; set; }
        public string Colaborador1 { get; set; }
        public Nullable<int> IdEstadoColaborador { get; set; }
        public Nullable<int> IdContratoColaborador { get; set; }
        public Nullable<decimal> SalarioQuincenal { get; set; }
        public Nullable<decimal> CTORepresentacion { get; set; }
        public string EstadoCivil { get; set; }
        public string IdentificacionPersonal { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public string Sexo { get; set; }
        public Nullable<int> IdEntidadFinanciera { get; set; }
        public Nullable<System.TimeSpan> HoraEntrada { get; set; }
        public Nullable<System.TimeSpan> HoraSalida { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdPosicion { get; set; }
        public Nullable<decimal> RataPorHora { get; set; }
        public Nullable<decimal> Bonificaciones { get; set; }
        public string SeguroSocial { get; set; }
        public string Sangre { get; set; }
        public Nullable<int> IdRenta { get; set; }
        public byte[] Img { get; set; }
    }
}
