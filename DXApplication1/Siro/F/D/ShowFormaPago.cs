using System;

namespace Siro.F.D
{
    public partial class ShowFormaPago : DevExpress.XtraEditors.XtraForm
    {
        public ShowFormaPago()
        {
            InitializeComponent();
        }
        public DateTime FechaVencimiento { get; set; }
        public string FormaPago { get; set; }
        private void cmbTerminoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dias = 0;
            switch (cmbTerminoPago.SelectedIndex)
            {
                case 0:
                    dias = 7;
                    break;
                case 1:
                    dias = 15;
                    break;
                case 2:
                    dias = 30;
                    break;
                case 3:
                    dias = 45;
                    break;
                case 4:
                    dias = 60;
                    break;
                case 5:
                    dias = 90;
                    break;
                case 6:
                    dias = 120;
                    break;
            }
            FechaVencimiento = DateTime.Now.AddDays(dias);
            FormaPago = cmbTerminoPago.Text;
        }

        private void ShowFormaPago_Load(object sender, EventArgs e)
        {
            cmbTerminoPago.SelectedIndex = 0;
        }
    }
}