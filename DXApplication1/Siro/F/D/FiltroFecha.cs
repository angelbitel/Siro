using System;

namespace Siro.F.D
{
    public partial class FiltroFecha : DevExpress.XtraEditors.XtraForm
    {
        public FiltroFecha()
        {
            InitializeComponent();
            this.dateEdit1.DateTime = DateTime.Now.AddDays(-30);
            this.dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = Principal.Bariables.Desde;
            dateEdit2.DateTime = Principal.Bariables.Hasta;
        }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Desde = this.dateEdit1.DateTime;
            Hasta = this.dateEdit2.DateTime;
            this.Close();
        }

        private void FiltroFecha_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Principal.Bariables.Desde = dateEdit1.DateTime;
            Principal.Bariables.Hasta = dateEdit2.DateTime;
        }
    }
}