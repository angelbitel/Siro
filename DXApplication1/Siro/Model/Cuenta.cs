namespace Siro.Model
{
    public class Cuentas
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public int ParentID { get; set; }
        public string Text { get; set; }
        public int Id { get; set; }
        public string CuentaContable { get; set; }
        public int Nivel { get; internal set; }
        public string Nivel0 { get; internal set; }
        public string Nivel1 { get; internal set; }
        public string Nivel2 { get; internal set; }
        public string Nivel3 { get; internal set; }
        public int? SumaResta { get; internal set; }
        public bool? Habilitar { get; internal set; }
        public string CuentaMadre{ get; set; }
    }
}
