using System;
using System.ComponentModel;
using System.Linq;

namespace Siro.F
{
    public partial class VMaestroCuentas : DevExpress.XtraEditors.XtraForm
    {
        public VMaestroCuentas() => InitializeComponent();
        BindingList<Model.MaestroCuentas> lstCuentas = new BindingList<Model.MaestroCuentas>();
        private void VMaestroCuentas_Load(object sender, EventArgs e)
        {
            new Controller.Contabilidad().Cuentas.ForEach(f=> {
                lstCuentas.Add(f);
            });
            barButtonItem1.Caption = "SE ESTAN CARGANDO LAS CUENTAS...";
            backgroundWorker1.RunWorkerAsync();
            maestroCuentasBindingSource.DataSource = lstCuentas;
        }
        private string Cuenta(Model.MaestroCuentas cuenta, int nivel)
        {
            string cuen = string.Empty;
            var r = cuenta;
            switch (nivel)
            {
                case 1:
                    var l1 = lstCuentas.Where(s => s.Codigo1 == r.Codigo.Substring(0, 1)).ToList();
                    if (l1.Count > 0)
                        cuen = l1[0].Nivel1;
                    break;
                case 2:
                    if (cuenta.Codigo.Length >= 2)
                    {
                        var l2 = lstCuentas.Where(s => s.Codigo2 == r.Codigo.Substring(0, 2)).ToList();
                        if (l2.Count > 0)
                            cuen = l2[0].Nivel2;
                    }
                    break;
                case 3:
                    if (cuenta.Codigo.Length >= 3)
                    {
                        var l3 = lstCuentas.Where(s => s.Codigo3 == r.Codigo.Substring(0, 3)).ToList();
                        if (l3.Count > 0)
                            cuen = l3[0].Nivel3;
                    }
                    break;
                case 4:
                    if (cuenta.Codigo.Length >= 5)
                    {
                        var l4 = lstCuentas.Where(s => s.Codigo4 == r.Codigo.Substring(0, 5)).ToList();
                        if (l4.Count> 0)
                            cuen = l4[0].Nivel4;
                    }
                    break;
            }
            return cuen;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Model.MaestroCuentas v in lstCuentas)
            {
                if (v.Nivel2 != null && v.Nivel3 == null)
                {
                    v.Nivel1 = Cuenta(v, 1);
                }
                if (v.Nivel3 != null && v.Nivel4 == null)
                {
                    v.Nivel1 = Cuenta(v, 1);
                    v.Nivel2 = Cuenta(v, 2);
                }
                if (v.Nivel4 != null && v.Nivel5 == null)
                {
                    v.Nivel1 = Cuenta(v, 1);
                    v.Nivel2 = Cuenta(v, 2);
                    v.Nivel3 = Cuenta(v, 3);
                }
                if (v.Nivel5 != null)
                {
                    v.Nivel1 = Cuenta(v, 1);
                    v.Nivel2 = Cuenta(v, 2);
                    v.Nivel3 = Cuenta(v, 3);
                    v.Nivel4 = Cuenta(v, 4);
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) => barStaticItem1.Caption = e.ProgressPercentage.ToString();
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)=> barButtonItem1.Caption = "OPERACION COMPLETA...";
    }
}