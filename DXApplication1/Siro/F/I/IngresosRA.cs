using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.I
{
    public partial class IngresosRA : DevExpress.XtraEditors.XtraForm
    {
        BindingList<RA> lstRegistroArroz = new  BindingList<RA>();
        List<Almacenaje> lstAlmacenes = new List<Almacenaje>();
        List<Conductores> lstConductores = new List<Conductores>();
        List<TiposArroz> lstTiposArroz = new List<TiposArroz>();
        List<provedores> lstprovedores = new List<provedores>();
        List<Recibidos> lstRecibidos = new List<Recibidos>();
        private RA UltimoRa {get; set;}
        public IngresosRA()
        {
            InitializeComponent();
        }

        private void IngresosRA_Load(object sender, EventArgs e)
        {
            LLenarListas();
            almacenesBindingSource.DataSource = lstAlmacenes;
            conductoresBindingSource.DataSource = lstConductores;
            tiposArrozBindingSource.DataSource = lstTiposArroz;
            provedoresBindingSource.DataSource = lstprovedores;
            recibidosBindingSource.DataSource=lstRecibidos;
        }
        private void LLenarListas()
        {
            var lst = new Controller.Lst();
            lstAlmacenes = lst.AlmacenesProduccion;
            lstConductores = lst.Conductores.OrderBy(o=> o.Conductor).ToList();
            lstTiposArroz = lst.Productos;
            lstprovedores = lst.Proveedores.OrderBy(o=> o.Proveedor).ToList();
            lstRecibidos = lst.Recibido;

            foreach (Model.TipoFlete current in lst.TiposFlete)
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = current.IdTipoFlete,
                    Description = current.TiposFlete
                };
                this.icbeTipoFlete.Properties.Items.Add(item);
            }
            foreach (Almacenaje current in lstAlmacenes)
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = current.IdAlmacen,
                    Description = current.Almacen
                };
                this.slueSilo.Properties.Items.Add(item);
            }
        }

        private void textEdit5_KeyUp(object sender, KeyEventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            decimal bruto = 0, humedad = 0, precio = 0, impureza = 0, seco = 0, total = 0, pesoPagar=0, neto=0, flete=0;
            decimal totalImpureza = 0, totalHumedad = 0, totalSeco=0, totalSecoAdic=0;
            decimal porcentajeImpureza = 0, porcentajeHumedad = 0, porcentajeSeco = 0, porcentajeAdicSeco=0;
            decimal.TryParse(txtBruto.Text, out bruto);
            decimal.TryParse(txtHumedad.Text, out humedad);
            decimal.TryParse(txtPrecio.Text, out precio);
            decimal.TryParse(txtImpurezas.Text, out impureza);
            decimal.TryParse(txtAdicSecado.Text, out totalSecoAdic);
            decimal.TryParse(txtSecado.Text, out totalSeco);
            decimal.TryParse(txtFlete.Text, out flete);
            if (impureza > 4)
            {
                totalImpureza = impureza - 4;
                porcentajeImpureza = bruto * totalImpureza / 100;
            }
            if (humedad > 24)
            {
                totalHumedad = (humedad - 24) * 1.2M;
                porcentajeHumedad = bruto * totalHumedad / 100;
            }

            porcentajeSeco = bruto * totalSeco / 100;
            porcentajeAdicSeco = bruto * totalSecoAdic / 100;

            if (checkEdit1.Checked)
                pesoPagar=bruto;
            else
                pesoPagar = bruto - porcentajeHumedad - porcentajeImpureza;

            seco = bruto - porcentajeHumedad - porcentajeImpureza-porcentajeAdicSeco-porcentajeSeco;


            total = pesoPagar * precio;
            neto = pesoPagar * precio;
            var row = bindingSource1.Current as Siro.RA;
            if (row == null)
            {
                bindingSource1.AddNew();
                row = bindingSource1.Current as Siro.RA;
            }
            else
            {
                row.Neto = neto;
                row.Total = total - row.Apach - flete;
                row.Apach = bruto * 0.05M;
                row.Precio = precio;
                row.Seco = seco;
                row.Rendimiento = row.PorcentajeQuebrado + row.PorcentajeEntero;
                row.PorcentajeAdicionalSecado = totalSecoAdic;
                row.PorcentajeSecado = totalSeco;
            }
            txtPagar.EditValue = row.Total;
            txtNeto.EditValue = row.Neto;
            textEdit6.EditValue = row.Seco;
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var crit = new string[] { "Move previous", "Move first", "Move next","Move last" };
            if (crit.Contains(e.ClickedItem.Text))
            {
            }else if(e.ClickedItem.Text=="Guardar")
            {
                var row = bindingSource1.Current as Siro.RA;
                var eje=new Controller.RA();
                if (eje.Guardar(row))
                {
                    lblMsg.Caption = eje.MSG;
                    if (row.IdEntradaArroz == 0)
                        row.IdEntradaArroz = eje.NuevoId;
                    UltimoRa = row;

                }
                else
                    lblMsg.Caption = eje.MSG;
            }
            else if (e.ClickedItem.Text == "Add new")
            {

            }
            else if (e.ClickedItem.Text == "Filtrar")
            {
                var lst = new Controller.Lst();
                var f = new I.Filtrar();
                f.ShowDialog(this);
                if(! string.IsNullOrEmpty(f.Filtro))
                    bindingSource1.DataSource = lst.LstRA(f.Filtro);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var nRa = new RA { IdTipoArroz = 1, IdRecibido = 1, PorcentajeSecado = 12, PorcentajeAdicionalSecado = 1.2M, IdTipoFlete=1 };

            if (UltimoRa != null)
            {
                nRa.IdAlmacen = UltimoRa.IdAlmacen;
                nRa.IdProveedor = UltimoRa.IdProveedor;
                nRa.Descuento = UltimoRa.Descuento;
                nRa.Fecha = UltimoRa.Fecha;
                nRa.IdRecibido = UltimoRa.IdRecibido;
                nRa.IdTipoArroz = UltimoRa.IdTipoArroz;
                nRa.IdConductor = UltimoRa.IdConductor;


                gridView1.SetFocusedRowCellValue(colIdTipoArroz, UltimoRa.IdTipoArroz);
                gridView1.SetFocusedRowCellValue(colIdRecibido, UltimoRa.IdRecibido);
                gridView1.SetFocusedRowCellValue(colIdAlmacen, UltimoRa.IdAlmacen);
                gridView1.SetFocusedRowCellValue(colIdProveedor, UltimoRa.IdProveedor);
                gridView1.SetFocusedRowCellValue(colIdConductor, UltimoRa.IdConductor);
                icbeTipoFlete.EditValue = UltimoRa.IdTipoFlete;

                dtFecha.EditValue = UltimoRa.Fecha;
                (bindingSource1.Current as RA).Fecha = UltimoRa.Fecha;
                (bindingSource1.Current as RA).IdRecibido = UltimoRa.IdRecibido;
                (bindingSource1.Current as RA).IdTipoArroz = UltimoRa.IdTipoArroz;
                (bindingSource1.Current as RA).IdAlmacen = UltimoRa.IdAlmacen;
                (bindingSource1.Current as RA).IdProveedor = UltimoRa.IdProveedor;
                (bindingSource1.Current as RA).IdTipoFlete = UltimoRa.IdTipoFlete;
                (bindingSource1.Current as RA).IdConductor = UltimoRa.IdConductor;
            }
            else
            {
                lstRegistroArroz.Add(nRa);

                gridView1.SetFocusedRowCellValue(colIdTipoArroz, 1);
                gridView1.SetFocusedRowCellValue(colIdRecibido, 1);
                dtFecha.EditValue = Principal.Bariables.PeridoContable;
                icbeTipoFlete.EditValue = 1;
                (bindingSource1.Current as RA).Fecha = Principal.Bariables.PeridoContable;
                (bindingSource1.Current as RA).IdRecibido = 1;
                (bindingSource1.Current as RA).IdTipoArroz = 1;
                (bindingSource1.Current as RA).IdTipoFlete = 1;
            }
            lblMsg.Caption = "Nuevo Registro De Arroz!!!";

        }

        private void textEdit4_KeyUp(object sender, KeyEventArgs e)
        {
            Calcular();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Siro.RA;
            if (row != null)
            {
                GenerarReporteDFecha("Registro Arroz", row.IdEntradaArroz);
            }
            else
                lblMsg.Caption = "Seleccione Algun Registro De Arroz Para Poder Imprimir!...";
        }
        private void GenerarReporteDFecha(string reporte, int idRa)
        {            
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Inventario\\{0}.repx", reporte));

            report.Parameters["prmRA"].Value = idRa;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "R. " + reporte;
            printTool3.ShowPreview();
        }

        private void textEdit5_KeyUp_1(object sender, KeyEventArgs e)
        {
            var row = bindingSource1.Current as Model.RegistroArroz;
            row.Seco = (row.PorcentajeAjusteSeco * row.PesoBruto / 100);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var f = new AddP();
            var lst = new Controller.Lst();
            f.ShowDialog();
            if (f.IdProv != 0)
            {
                lstprovedores = lst.Proveedores;
                provedoresBindingSource.DataSource = lstprovedores;
                slueProveedor.EditValue = f.IdProv;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var f = new AddC();
            var lst = new Controller.Lst();
            f.ShowDialog();
            if (f.IdConductor != 0)
            {
                lstConductores = lst.Conductores;
                conductoresBindingSource.DataSource = lstConductores;
                slueConductores.EditValue = f.IdConductor;
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void icbeTipoFlete_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBruto.Focus();
        }
        private void txtKeyCodeValue(object sender, KeyEventArgs e)
        {
            if (((TextEdit)sender).Text.Trim().Length >0)
                Calcular();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}