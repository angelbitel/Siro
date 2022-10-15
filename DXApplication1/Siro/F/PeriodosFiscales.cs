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

namespace Siro.F
{
    public partial class PeriodosFiscales : DevExpress.XtraEditors.XtraForm
    {
        public PeriodosFiscales()
        {
            InitializeComponent();
        }

        private void barButtonItemActualizarSaldos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("ESTASEGURO QUE DESA REALIZAR ESTE PROCESO", "ALERTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var db = new Controller.MVSubtotalesCuentas();
                var row = gridView1.GetFocusedRow() as Model.PeriodoFiscal;
                if (row != null)
                {
                    Task.Run(async () =>
                    {
                        lbl.Caption = "SE ESTAN PROCESANDO LOS SALDOS POR FAVOR ESPERE......";
                        barButtonItemActualizarSaldos.Enabled = false;
                        await db.ReiniciarTablas(row.IdPeriodoFiscal);
                    }).ContinueWith(c =>
                    {
                        db.Calcular(row.IdPeriodoFiscal);
                        barButtonItemActualizarSaldos.Enabled = true;
                        XtraMessageBox.Show("PROCESO TERMINADO.........");
                    });
                }
            }
        }

        private void PeriodosFiscales_Load(object sender, EventArgs e)
        {
            var db = new Controller.MVSubtotalesCuentas();
            gridControl1.DataSource = db.LstPeriodoFiscal;
        }
    }
}