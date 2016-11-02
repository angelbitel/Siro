using System;

namespace Siro.Model
{
    public class CuentasMaestras
    {
        public int ID { get; set; }
        public int IdMaestroCuenta { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string Text { get; set; }
        public int ParentID { get; set; }
        public int Nivel { get; set; }
        public int Id { get; set; }
        public int Tipo { get; set; }
    }
}
