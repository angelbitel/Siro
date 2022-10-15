using System;

namespace Siro.Model
{
    public class MaestroContable
    {
        public int IdMaestroCuenta { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string Text { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> Nivel { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<bool> Habilitar { get; set; }
        public Nullable<int> SumaResta { get; set; }
        public string Nivel0 { get; set; }
        public string Nivel1 { get; set; }
        public string Nivel2 { get; set; }
        public string Nivel3 { get; set; }
        public string CuentaContable { get; set; }
        public string Nivel4 { get; set; }
        public Nullable<bool> EsBanco { get; set; }
        public Nullable<int> C1 { get; set; }
        public Nullable<int> C2 { get; set; }
        public Nullable<int> C3 { get; set; }
        public Nullable<int> C4 { get; set; }
    }
}
