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
    public partial class MantenimientoCuentas : DevExpress.XtraEditors.XtraForm
    {
        BindingList<Model.MaestroContable> lstCuentas = new BindingList<Model.MaestroContable>();
        public MantenimientoCuentas() => InitializeComponent();

        private void MantenimientoCuentas_Load(object sender, EventArgs e)
        {
            var db = new Controller.VMContabilidad();
            db.CuentaIntegras.ForEach(f => {
                lstCuentas.Add(f);
                cmbNivel1.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel2.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel3.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel4.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
            });
            maestroContableBindingSource.DataSource = lstCuentas;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var db = new Controller.VMContabilidad();
            var r = gridView1.GetFocusedRow() as Model.MaestroContable;
            r.IdEmpresa = 1;
            if (db.Guardar(r))
            {
                r.IdMaestroCuenta = db.Id;
                lbl.Caption = "CUENTAS MODIFICADAS CORRECTAMENTE";
            }
            else
            {
                lbl.Caption = "Error:" + db.Mensaje;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new EditarCuentas();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.LstCuentas = new List<Model.MaestroContable>();
            lstCuentas.ToList().ForEach(f => frm.LstCuentas.Add(f));
            frm.ShowDialog();
            if (frm.PasarInformacion)
                frm.Maestro.ToList().ForEach(r => lstCuentas.Add(new Model.MaestroContable { C1 = r.C1, C2 = r.C2, C3 = r.C3, C4 = r.C4, CuentaContable = r.Codigo, EsBanco = r.EsBanco, Habilitar = true, Text = r.Cuenta, IdMaestroCuenta = r.IdMaestroCuenta }));
        }

        private void MantenimientoCuentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            lbl.Caption = "SE ESTAN ACTUALIZANDO LAS CUENTAS";
            Principal.LstCuentas.Clear();
            Task.Run(async () =>
            {
                var cont = new Controller.VMContabilidad();
                var resCuentas = await cont.CuentasContables();
                resCuentas.ForEach(f => Principal.LstCuentas.Add(new Model.MaestroContable { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.CuentaContable, Text = f.Text }));
            });
        }
    }
}