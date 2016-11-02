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
        public IngresosRA()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGuadar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
            lstConductores = lst.Conductores;
            lstTiposArroz = lst.Productos;
            lstprovedores = lst.Proveedores;
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
        }

        private void toolStripButtonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void textEdit5_KeyUp(object sender, KeyEventArgs e)
        {            
            var txt = sender as TextEdit;
            decimal bruto=0, humedad=0, precio=0, impureza=0, neto=0, total=0;
            decimal totalImpureza = 0, totalHumedad = 0;
            decimal porcentajeImpureza = 0, porcentajeHumedad = 0;
                decimal.TryParse(txtBruto.Text, out bruto);
                decimal.TryParse(txtHumedad.Text, out humedad);
                decimal.TryParse(txtPrecio.Text, out precio);
                decimal.TryParse(txtImpurezas.Text, out impureza);
                if (impureza > 4)
                {
                    totalImpureza = impureza - 4;
                    porcentajeImpureza = bruto * totalImpureza / 100;
                }
                if (humedad > 24)
                {
                    totalHumedad = (humedad-24)*1.2M;
                    porcentajeHumedad = bruto * totalHumedad / 100;
                }


                    neto = bruto-porcentajeHumedad-porcentajeImpureza;
                    
            
            total = neto * precio;
            var row=bindingSource1.Current as Model.RegistroArroz;
            if(row == null)
            {
                bindingSource1.AddNew();
                row = bindingSource1.Current as Model.RegistroArroz;
            }
            row.Neto = neto;
            row.Total = total;
            row.Apach = bruto * 0.05M;
            row.Precio = precio;
            row.Seco = ((row.PorcentajeAjusteSeco ?? 1) * row.Neto / 100) + row.Neto;
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var crit = new string[] { "Move previous", "Move first", "Move next","Move last" };
            if (crit.Contains(e.ClickedItem.Text))
            {
            }else if(e.ClickedItem.Text=="Guardar")
            {
                var row = bindingSource1.Current as Model.RegistroArroz;
                var entidad = new Siro.RA
                {
                    IdEntradaArroz = row.IdEntradaArroz,
                    Apach = row.Apach,
                    Fecha = row.Fecha,
                    FehaProceso = DateTime.Now,
                    IdAlmacen = row.IdAlmacen,
                    IdConductor = row.IdConductor,
                    IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                    IdProductor = row.IdProductor,
                    IdProveedor = row.IdProveedor,
                    IdRecibido = row.IdRecibido,
                    IdTipoArroz = row.IdTipoArroz,
                    IdTipoFlete = row.IdTipoFlete,
                    IdUser = Principal.Bariables.IdUsuario,
                    Matricula = row.Matricula,
                    Neto = row.Neto,
                    NumeroBoleta = row.NumeroBoleta,
                    PesoBruto = row.PesoBruto,
                    PorcentajeHumedad = row.PorcentajeHumedad,
                    PorcentajeImpurezas = row.PorcentajeImpurezas,
                    Precio = row.Precio,
                    Total = row.Total,
                    PorcentajeEntero = row.PorcentajeEntero,
                    PorcentajeQuebrado = row.PorcentajeQuebrado,
                    PorcentajeAjusteSeco = row.PorcentajeAjusteSeco,
                    Seco = row.Seco
                };
                var eje=new Controller.RA();
                if (eje.Guardar(entidad))
                {
                    lblMsg.Caption = eje.MSG;
                    if (row.IdEntradaArroz == 0)
                        row.IdEntradaArroz = eje.NuevoId;
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

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            var row = bindingSource1.Current as Model.RegistroArroz;
            //if (row != null)
            //    if (row.Fecha == null)
            //        row.Fecha = Principal.Bariables.PeridoContable;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
        }

        private void textEdit4_KeyUp(object sender, KeyEventArgs e)
        {
            var row = bindingSource1.Current as Model.RegistroArroz;
            row.Rendimiento = row.PorcentajeQuebrado + row.PorcentajeImpurezas;
            gridView1.SetFocusedRowCellValue(colRendimiento, row.Rendimiento);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Model.RegistroArroz;
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
                slueProveedor.EditValue = f.IdConductor;
            }
        }
    }
}