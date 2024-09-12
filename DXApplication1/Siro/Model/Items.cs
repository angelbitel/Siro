namespace Siro.Model
{
    public class Items
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
    }
    public class ConfiguracionHoras
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}
