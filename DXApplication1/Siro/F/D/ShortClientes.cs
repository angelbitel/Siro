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
    public partial class ShortClientes : DevExpress.XtraEditors.XtraForm
    {
        public ShortClientes()
        {
            InitializeComponent();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Siro.slEntities db = new Siro.slEntities();
            var pr = new Siro.Clientes
            {
                NombreCompleto = txtEmpresa.Text,
                CedulaRuc = string.Format("{0}", txtRuc.Text)
            };
            db.Clientes.Add(pr);
            db.SaveChanges();
            this.Close();
        }
    }
}