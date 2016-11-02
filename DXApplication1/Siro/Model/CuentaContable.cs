using System;

namespace Siro.Model
{
    public class CuentaContable
    {
        public int IdCuentaContable { get; set; }
        public Nullable<int> Nivel1 { get; set; }
        public Nullable<int> Nivel2 { get; set; }
        public Nullable<int> Nivel3 { get; set; }
        public string Cuenta { get; set; }
        public string CuentaMaestra { get; set; }
        public Nullable<bool> Habilitar { get; set; }
        public Nullable<int> IdRequisito { get; set; }
    }
}
