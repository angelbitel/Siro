using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Siro.F.P
{
    public partial class AgregarHoras : DevExpress.XtraEditors.XtraForm
    {
        private int IdColaborador { get; set; }
        public AgregarHoras(int? idColaborador)
        {
            IdColaborador = idColaborador??0;
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = bindingSource1.Current as HorasTrabajadas;
            var save = new Controller.Colaborador();
            
            row.Año = row.FechaProceso.Value.Year;
            row.Año = row.FechaProceso.Value.Month;
            row.IdColaborador = IdColaborador;
            row.Procesado = false;
            row.IdEmpresa = Settings.Default.DIdEmpresa;
            bool rest = save.Guardar(row);
            if (rest)
            {
                this.Close();
            }
            else
            {
                lblMsg.Caption = save.MSG;
            }
        }

        private void AgregarHoras_Load(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            var row = bindingSource1.Current as HorasTrabajadas;
            row.FechaProceso = DateTime.Now;
            row.IdColaborador = IdColaborador;
            using(var db = new slPlanilla())
            {
                var lst = new List<Model.Factor>();
                db.Factores.ToList().ForEach(f=>lst.Add(new Model.Factor { IdFactor = f.IdFactor, TipoFactor= f.TiposFactor.Factor, Factor1 = f.Factor, DescripcionFactor = f.DescripcionFactor  }));
                factoresBindingSource.DataSource = lst;
            }
        }
    }
}