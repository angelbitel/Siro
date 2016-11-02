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

namespace Siro.F.D
{
    public partial class ShortProveedores : DevExpress.XtraEditors.XtraForm
    {
        public ShortProveedores()
        {
            InitializeComponent();
        }
        public Siro.provedores Proveedor { get; set; }
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Siro.slContabilidad db = new Siro.slContabilidad();
            var pr = new Siro.provedores {
                Proveedor = txtEmpresa.Text,
                Ruc = string.Format("{0} ",txtRuc.Text)
            };
            db.provedores.Add(pr);
            db.SaveChanges();
            Proveedor = pr;
            this.Close();
        }
    }
}