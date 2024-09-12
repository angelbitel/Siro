using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    internal class Horas
    {
        public Horas()
        {
            db = new slContabilidad();
            dbE = new slEntities();
            dbP = new slPlanilla();
        }
        slContabilidad db;
        slEntities dbE;
        slPlanilla dbP;
        internal List<Model.ConfiguracionHoras> LstColumnaOrigen => dbP.Database.SqlQuery<Model.ConfiguracionHoras>(
             "SELECT IdCampo As Id, Origen, Destino from [Planilla].[ConfiguracionArchivoReloj]").ToList();
        public string Mensaje { get; private set; }

        private string Buscar(int tipo, List<VCuentasPrimarias> lst) => lst.SingleOrDefault(s => s.Tipo.Equals(tipo)) == null ? "" : lst.SingleOrDefault(s => s.Tipo.Equals(tipo)).Text;
        public bool Guardar(MaestroCuentas inf)
        {
            try
            {
                if (inf.IdMaestroCuenta != 0)
                    db.Entry(db.MaestroCuentas.Find(inf.IdMaestroCuenta)).CurrentValues.SetValues(inf);
                else
                    db.MaestroCuentas.Add(inf);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        internal List<Model.Factor> LstFactura
        {
            get
            {
                var lst = new List<Model.Factor>();
                dbP.Factores.ToList().ForEach(f => lst.Add(new Model.Factor { IdFactor = f.IdFactor, TipoFactor = f.TiposFactor.Factor, Factor1 = f.Factor, DescripcionFactor = f.DescripcionFactor }));
                return lst;
            }
        }
    }
}
