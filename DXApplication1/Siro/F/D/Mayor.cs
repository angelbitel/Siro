using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Siro.F.D
{
    public partial class Mayor : DevExpress.XtraEditors.XtraForm
    {
        List<Model.Mayor> Mayores = new List<Model.Mayor>();
        BindingList<Model.ResumenCreditos> lstCredito = new BindingList<Model.ResumenCreditos>();
        BindingList<Model.Resumen> Resumen = new BindingList<Model.Resumen>();
        slContabilidad dbContext = new slContabilidad();
        public Mayor() => InitializeComponent();
        private void Mayor_Load(object sender, EventArgs e)
        {
            var db = new Controller.VMContabilidad();
            gridControl3.DataSource = db.CuentaMayorNomayorResumen.ToList();
            resumenCreditosBindingSource.DataSource = lstCredito;
            resumenBindingSource.DataSource = Resumen;
            if (lstCredito.Count() > 0)
            {
                AgregarSumatoria();
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        string cuenta { get; set; }
        private void cmbCuentas_EditValueChanged(object sender, EventArgs e)
        {
            var cmb = sender as ImageComboBoxEdit;
            cuenta = cmb.EditValue.ToString();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            var r = gridView2.GetFocusedRow() as Model.MaestroCuentas;
            var db = new Controller.VMContabilidad();
            lstCredito.Clear();
            db.TransaccionesMayor(Principal.Bariables.Desde, Principal.Bariables.Hasta, r.IdMaestroCuenta).ForEach(f => lstCredito.Add(f));
            if (lstCredito.Count() > 0)
            {
                AgregarSumatoria();
                Resumen.Clear();
                Resumen.Add(new Model.Resumen { PrimeraTransaccion = lstCredito.Min(m => m.Fecha), UltimaTransaccion = lstCredito.Max(m => m.Fecha), Balance = lstCredito[lstCredito.Count - 1].TotalMoroso, Creditos = lstCredito.Sum(s => s.Deuda), Debitos = lstCredito.Sum(s => s.Pago), CantidadAsientos = lstCredito.Count() });
            }
        }

        private void simpleButtonRefrescar_Click(object sender, EventArgs e)
        {
            int año = Principal.Bariables.PeridoContable.Year;
            int mes = Principal.Bariables.PeridoContable.Month;
            int id = Principal.Bariables.IdEmpresa.Id;
            var r = gridView2.GetFocusedRow() as Model.MaestroCuentas;
            var db = new Controller.VMContabilidad();
            lstCredito.Clear();
            db.TransaccionesMayor(Principal.Bariables.Desde, Principal.Bariables.Hasta, r.IdMaestroCuenta).ForEach(f => lstCredito.Add(f));
            if (lstCredito.Count() > 0)
            {
                AgregarSumatoria();
                Resumen.Clear();
                Resumen.Add(new Model.Resumen { PrimeraTransaccion = lstCredito[0].Fecha, UltimaTransaccion = lstCredito[lstCredito.Count - 1].Fecha, Balance = lstCredito[lstCredito.Count - 1].TotalMoroso, Creditos = lstCredito.Sum(s => s.Deuda), Debitos = lstCredito.Sum(s => s.Pago), CantidadAsientos = lstCredito.Count() });
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var frm = new F.D.FiltroFecha();
            frm.ShowDialog();
            if (!frm.Cancelar)
            {
                var r = gridView2.GetFocusedRow() as Model.MaestroCuentas;
                var db = new Controller.VMContabilidad();
                lstCredito.Clear();
                db.TransaccionesMayor(Principal.Bariables.Desde, Principal.Bariables.Hasta, r.IdMaestroCuenta).ForEach(f => lstCredito.Add(f));
                if (lstCredito.Count() > 0)
                {
                    AgregarSumatoria();
                    Resumen.Clear();
                    Resumen.Add(new Model.Resumen { PrimeraTransaccion = lstCredito[0].Fecha, UltimaTransaccion = lstCredito[lstCredito.Count - 1].Fecha, Balance = lstCredito[lstCredito.Count - 1].TotalMoroso, Creditos = lstCredito.Sum(s => s.Deuda), Debitos = lstCredito.Sum(s => s.Pago), CantidadAsientos = lstCredito.Count() });
               
                }
            }
            else
                lblMsg.Caption = "SE CANCELO LA TRANSACCION..!!!";
        }

        private void AgregarSumatoria()
        {
            gridView1.Columns["TotalMoroso"].Summary.Clear();
            GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TotalMoroso", $"{lstCredito[lstCredito.Count - 1].TotalMoroso.ToString()}");
            gridView1.Columns["TotalMoroso"].Summary.Add(item1);

            gridView1.Columns["Deuda"].Summary.Clear();
            gridView1.Columns["Deuda"].Summary.Add(new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Deuda", "{0:N2}"));
            gridView1.Columns["Pago"].Summary.Clear();
            gridView1.Columns["Pago"].Summary.Add(new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pago", "{0:N2}"));
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {

        }
    }
}