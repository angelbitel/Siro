//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Siro
{
    using System;
    using System.Collections.Generic;
    
    public partial class Procedencias
    {
        public int IdProcedencia { get; set; }
        public Nullable<int> IdCorregimiento { get; set; }
        public string Procedencia { get; set; }
    
        public virtual Procedencias Procedencias1 { get; set; }
        public virtual Procedencias Procedencias2 { get; set; }
    }
}