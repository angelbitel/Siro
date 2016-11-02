using System;
using System.Linq;

namespace Siro.Model
{
    public class Prmts
    {
        private int IdEmpresa { get; set; }
        public int IdCuentaProveedor { get; set; }
        public int IdCuentaCliente { get; set; }
        public int IdCuentaEmpleado { get; set; }
        public int IdCuentaItbm { get; set; }
        public int IdCuentaBanco { get; set; }
        public int IdCaja { get; set; }
        public int IdBancoCXC { get; set; }
        public Prmts(int idEmpresa)
        {
            IdEmpresa = idEmpresa;
            CargaParametros();
        }
        private void CargaParametros()
        {
            db = new slEntities();
            var row = db.Empresas.SingleOrDefault(s => s.IdEmpresa == IdEmpresa);
            if(row != null)
            {
               IdCuentaProveedor=row.IdProveedor??0;
               IdCuentaCliente = row.IdCliente ?? 0;
               IdCuentaEmpleado = row.IdEmpleado ?? 0;
               IdCuentaItbm = row.IdItbms ?? 0;
               IdCuentaBanco = row.IdBanco ?? 0;
               IdCaja = row.IdCaja ?? 0;
               IdBancoCXC = row.IdEfectivoBanco ?? 0;
            }
        }
        slEntities db;
        public bool UsaFiscal { get; set; }
        public string ImpresoraFiscal { get; set; }
        public string PatchFile { get; set; }
        public string PatchBat { get; set; }
        public Prmts()
        {
            db = new slEntities();
            db.Parametros.ToList().ForEach(f=> {
                switch (f.IdParametro)
                {
                    case 1:
                        UsaFiscal = Convert.ToBoolean(f.Valor);
                        break;
                    case 2:
                        ImpresoraFiscal = f.Valor;
                        break;
                    case 3:
                        PatchFile = f.Valor;
                        break;
                    case 4:
                        PatchBat = f.Valor;
                        break;
                }
            });
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
