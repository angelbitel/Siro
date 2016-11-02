using System;

namespace Siro.Model
{
    public class Factor
    {
        public int IdFactor { get; set; }
        //public Nullable<int> IdEmpresa { get; set; }
        public string DescripcionFactor { get; set; }
        public Nullable<decimal> Factor1 { get; set; }
        public string TipoFactor { get; set; }
        public Nullable<bool> RestaSaldo { get; set; }
    
    }
}
