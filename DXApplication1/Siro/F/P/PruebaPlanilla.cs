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
    public partial class PruebaPlanilla : DevExpress.XtraEditors.XtraForm
    {
        public PruebaPlanilla()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
             var re=new Controller.DescuentosGobierno();
                labelControl1.Text = "Resultados =" + re.Renta(double.Parse(textEdit2.Text), int.Parse(textEdit1.Text)) + " social =" + re.SeguroSocial(double.Parse(textEdit2.Text)) + " educativo=" + re.SeguroEducativo(double.Parse(textEdit2.Text));
        }
    }
}