namespace Siro.Model
{
    public class HorasTrabajadas
    {
        public int IdEmpresa { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFactor { get; set; }
        public decimal HoraTrabajada { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }

    }
}
