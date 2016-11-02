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
using DevExpress.XtraEditors.Controls;
using Siro.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Siro.F.D
{
    public partial class FormaPago : DevExpress.XtraEditors.XtraForm
    {
        Siro.slEntities dbContext = new Siro.slEntities();

        private bool cerrarCancelar = true;
        private decimal Total { get; set; }
        public static int IdCertificado { get; set; }
        public static decimal MontoCertificado { get; set; }
        public decimal MntRestante { get; set; }
        private BindingList<FPago> fPagos = new BindingList<FPago>();
        public FormaPago(decimal total)
        {
            Total = total;
            InitializeComponent();
            this.cmbFormaPago.EditValueChanged += new EventHandler(this.CmbFormaPagoEditValueChanged);
            LlenarCombos();
            this.cmbFormaPago.KeyDown += new KeyEventHandler(this.RepositoryItemImageComboBox1_KeyDown);
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridControl1KeyDown);
            this.gridView1.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.GridView1CustomDrawFooterCell);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridView1CellValueChanged);
            Cancelar = true;
        }
        private void LlenarCombos()
        {
            foreach (FormasPago current in
                from x in dbContext.FormasPago
                where x.habilitar == (bool?)true
                select x)
            {
                this.cmbFormaPago.Items.Add(new ImageComboBoxItem
                {
                    Value = current.IdFormaPago,
                    ImageIndex = current.IdFormaPago,
                    Description = current.FormaPago
                });
            }
        }

        private void CmbFormaPagoEditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit imageComboBoxEdit = sender as ImageComboBoxEdit;
            int num = int.Parse(imageComboBoxEdit.EditValue.ToString());
            this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, this.colIdFormaPago, num);
            if (num != 1)
            {
                if (this.Total - (
                    from a in this.fPagos
                    select a.Monto).DefaultIfEmpty(0m).Sum() != 0m)
                {
                    this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, this.colMonto, this.Total - (
                        from a in this.fPagos
                        select a.Monto).DefaultIfEmpty(0m).Sum());
                }
                else
                {
                    this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, this.colMonto, this.Total);
                }
            }
            this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, this.colFormaPago, imageComboBoxEdit.Text);
            this.gridView1.UpdateCurrentRow();
        }

        private void RepositoryItemImageComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ImageComboBoxEdit imageComboBoxEdit = sender as ImageComboBoxEdit;
                if (imageComboBoxEdit != null)
                {
                    imageComboBoxEdit.ShowPopup();
                    e.Handled = true;
                }
            }
        }

        private void FormaPago_Load(object sender, EventArgs e)
        {
            this.fPagos.Add(new FPago
            {
                FormaPago = "Efectivo",
                IdFormaPago = 1,
                Monto = this.Total,
                Restante = 0m,
                SecuenciaTransaccion = 0
            });
            this.gridControl1.DataSource = this.fPagos;
        }
        private void GridControl1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                this.gridView1.DeleteRow(this.gridView1.FocusedRowHandle);
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Modifiers == Keys.Control)
            {
                this.gridView1.AddNewRow();
            }
        }
        private void GridView1CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column == this.colMonto)
            {
                if (this.Total > Convert.ToDecimal(this.colMonto.SummaryItem.SummaryValue))
                {
                    e.Info.Appearance.ForeColor = Color.Red;
                    e.Info.DisplayText = string.Format("Monto menor que el total: {0}", e.Info.SummaryItem.SummaryValue);
                    this.btnPagado.Caption = string.Format("Pagado: {0}", e.Info.SummaryItem.SummaryValue);
                }
                else
                {
                    e.Info.Appearance.ForeColor = Color.Black;
                }
                if (this.Total < Convert.ToDecimal(this.colMonto.SummaryItem.SummaryValue))
                {
                    this.btnRegresar.Caption = string.Format("Regresar a cliente : {0}", (Convert.ToDecimal(this.colMonto.SummaryItem.SummaryValue) - this.Total).ToString("N"));
                    return;
                }
                this.btnRegresar.Caption = string.Empty;
            }
        }
        private void GridView1CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            this.gridView1.UpdateCurrentRow();
            if (this.Total < Convert.ToDecimal(this.colMonto.SummaryItem.SummaryValue))
            {
                this.btnRegresar.Caption = string.Format("Regresar a cliente : {0}", (Convert.ToDecimal(this.colMonto.SummaryItem.SummaryValue) - this.Total).ToString("N"));
            }
        }
        private void btnAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.AddNewRow();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fPagos.Where(w => w.IdFormaPago == 8).Count() > 0)
            {
                if (fPagos.Count() >= 2)
                {
                    Cancelar = true;
                    btnPagado.Caption = "Tiene más de una forma de pago seleccionada....";
                    return;
                }
            }
            var fp = new List<FPagoUilizada>();
            fPagos.ToList().ForEach(f =>
            {
                fp.Add(new FPagoUilizada {
                     Monto = f.Monto,
                      IdFormaPago=f.IdFormaPago
                });
            });
            Cancelar = false;
            Factura.FDb.FPagoUilizada = fp;
            this.Close();
        }
        public bool Cancelar { get; set; }
    }
}