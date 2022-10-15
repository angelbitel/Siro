using System.Linq;
namespace Siro.Model
{
    public class MaestroCuentas
    {
        private string _nivel1;
        private string _nivel2;
        private string _nivel3;
        private string _nivel4;

        public int IdMaestroCuenta { get; set; }
        public string Cuenta { get; set; }
        public string Codigo { get; set; }
        public bool? EsBanco { get; set; }
        public int? Tipo
        {
            get
            {
                var tipo = L == 1 ? int.Parse(Codigo.Substring(0, 1)) : (int?)null;
                if (tipo == null)
                {
                    if (Codigo.Trim().Length > 2)
                    {
                        int i = 0;
                        if (int.TryParse(Codigo.Substring(0, 1), out i))
                            tipo = i;
                    }
                }
                return tipo;
            }
        }
        public string Nivel1
        {
            set => _nivel1 = value;
            get
            {
                if (_nivel1 == null)
                    _nivel1 = (L == 1 ? Cuenta : null);
                return _nivel1;
            }
        }
        public string Nivel2
        {
            set => _nivel2 = value;
            get
            {
                if (_nivel2 == null)
                    _nivel2 = (L == 2 ? Cuenta : null);
                return _nivel2;
            }
        }
        public string Nivel3
        {
            set => _nivel3 = value;
            get
            {
                if (_nivel3 == null)
                    _nivel3 = (L == 3 ? Cuenta : null);
                return _nivel3;
            }
        }
        public string Nivel4
        {
            set => _nivel4 = value;
            get
            {
                if (_nivel4 == null)
                    _nivel4 = new int[] { 4, 5 }.Contains(L) ? Cuenta : null;
                return _nivel4;
            }
        }
        public string Nivel5 { get { return L > 5 ? Cuenta : null; } }
        private int L
        {
            get
            {
                if (Numero != null)
                    return Numero.Length;
                else
                    return 0;
            }
        }
        private string Numero
        {
            get
            {
                if (Codigo != null)
                    return Codigo.Trim().EndsWith("0") ? Codigo.Trim().TrimEnd('0') : Codigo.Trim();
                else
                    return Codigo;
            }
        }
        public string Codigo1
        {
            get
            {
                if (Nivel1 != null)
                    return Codigo.Substring(0, 1);
                else
                    return null;
            }
        }
        public string Codigo2
        {
            get
            {
                if (Nivel2 != null)
                    return Codigo.Substring(0, 2);
                else
                    return null;
            }
        }
        public string Codigo3
        {
            get
            {
                if (Nivel3 != null)
                    return Codigo.Substring(0, 3);
                else
                    return null;
            }
        }
        public string Codigo4
        {
            get
            {
                if (Nivel4 != null)
                    return Codigo.Substring(0, 5);
                else
                    return null;
            }
        }
        public bool Negrita
        {
            get
            {
                return (this.Nivel3 == null && this.Nivel4 == null && this.Nivel5 == null);
            }
        }
        public int? Nivel
        {
            get
            {
                if (Nivel2 == null && Nivel3 == null)
                    return 0;
                else if (Nivel3 == null && Nivel4 == null)
                    return 1;
                else if (Nivel3 == null && Nivel4 == null)
                    return 2;
                else if (Nivel4 == null && Nivel5 == null)
                    return 3;
                else if (Nivel5 == null)
                    return 4;
                else
                    return 5;
            }
        }
        public int? C1 { get; set; }
        public int? C2 { get; set; }
        public int? C3 { get; set; }
        public int? C4 { get; set; }
        public bool EsCLiente { get; set; }
        public bool EsProveedor { get; set; }
        public string CuentaCombinada
        {
            get
            {
                return string.Format("{0} =>{1}", Codigo.ToString().Trim(), Cuenta.ToString().Trim());
            }
        }
    }
}
