namespace Siro.Model
{
    internal class EstadoHoras
    {
        public string Estado { get; set; }
        public bool DescuentaHora { get; set; }
    }
    internal class ColaboradorItem
    {
        public string Colaborador { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ColaboradorItem item && Colaborador == item.Colaborador;
        }

        public override int GetHashCode()
        {
            return Colaborador?.GetHashCode() ?? 0;
        }
    }
}