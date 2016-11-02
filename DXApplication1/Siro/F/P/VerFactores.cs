using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Siro.F.P
{
    public partial class VerFactores : DevExpress.XtraEditors.XtraForm
    {
        public VerFactores()
        {
            InitializeComponent();
            using (var db = new slPlanilla())
            {
                var lst = new List<Model.Factor>();
                db.Factores.ToList().ForEach(f =>
                {
                    lst.Add(new Model.Factor
                    {
                        DescripcionFactor = f.DescripcionFactor,
                        Factor1 = f.Factor,
                        IdFactor = f.IdFactor,
                        RestaSaldo = f.RestaSaldo,
                        TipoFactor = f.TiposFactor.Factor
                    });
                });
                factorBindingSource.DataSource = lst;
            }
        }
    }
}