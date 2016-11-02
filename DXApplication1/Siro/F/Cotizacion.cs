using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Siro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F
{
    public partial class Cotizacion : DevExpress.XtraEditors.XtraForm
    {
        List<Model.DetalleCotizacion> LstCotizaciones = new List<Model.DetalleCotizacion>();
        List<ClienteMini> lstClientes = new List<ClienteMini>();
        Siro.slEntities dbContext = new Siro.slEntities();
        public Cotizacion()
        {
            InitializeComponent();
            layoutControlGroup2.Enabled = false;
        }

        private void splitContainerControl1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool EndEdit { get; set; }
        private void Cotizacion_Load(object sender, EventArgs e)
        {
            detalleCotizacionBindingSource.DataSource = LstCotizaciones;
            dbContext.Servicios.ToList().ForEach(f =>
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = f.IdServicio,
                    Description = f.Servicios1
                };
                repositoryItemImageComboBoxServicios.Items.Add(item);
                imageComboBoxEditServicios.Properties.Items.Add(item);
            });

            lstClientes = new Controller.Cliente().lstClientes;
            clienteMiniBindingSource.DataSource = lstClientes;            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            detalleCotizacionBindingSource.AddNew();
            layoutControlGroup2.Expanded = true;
            layoutControlGroup2.Enabled = true;
        }
        int IdCliente { get; set; }
        int IdServicio { get; set; }
        string Servicio { get; set; }

        private void imageComboBoxEditServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imageComboBoxEditServicios.EditValue.ToString()))
            {
                IdServicio = int.Parse(imageComboBoxEditServicios.EditValue.ToString());
                Servicio = imageComboBoxEditServicios.Text;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            LstCotizaciones.Clear();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void detalleCotizacionBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.Reset)
                if (detalleCotizacionBindingSource.Current as Model.DetalleCotizacion == null)
                    return;
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.Reset )
            {
                var fila = detalleCotizacionBindingSource.Current as Model.DetalleCotizacion;
                if (fila.Cantidad == 0)
                    fila.Cantidad = 1;
                if(checkEdit1.Checked)
                    (detalleCotizacionBindingSource.Current as Model.DetalleCotizacion).ITBM = (fila.Monto*fila.Cantidad??0) * 0.07M;

                (detalleCotizacionBindingSource.Current as Model.DetalleCotizacion).Total = (fila.Monto * fila.Cantidad ??0) + fila.ITBM;
                (detalleCotizacionBindingSource.Current as Model.DetalleCotizacion).Descripcion = Servicio;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detalle = new List<DetalleCotizacion>();
            LstCotizaciones.ForEach(f =>
                {
                    detalle.Add(new DetalleCotizacion
                    {
                        Cantidad = f.Cantidad,
                        Detalle = f.Detalle,
                        IdServicio = f.IdServicio,
                        Itbm = f.ITBM,
                        Monto = f.Monto,
                        Total = f.Total,
                        Descripcion = f.Descripcion
                    });
                });
            var datos = new Cotizaciones
            {
                idCliente = IdCliente,
                Cotizacion = tCotizacion.Text,
                 DetalleCotizacion = detalle
            };
            var eject = new Controller.Cotizacion();
            var ejecucion = eject.Agregar(datos);
            lblMsg.Caption = eject.MSG;
            if (ejecucion)
            {
                IdCotizacion = eject.NuevoId??0;
                GenerarReporte("rptCotizacion", false);

            }
        }
        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            IdCliente = int.Parse(gridLookUpEdit1.EditValue.ToString());
        }

        private int IdCotizacion { get; set; }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool noSumar = true;

            if (IdCotizacion == 0)
            {
                var id = dbContext.Cotizaciones.Where(s => s.idCliente == IdCliente);
                if(id.Any())
                    IdCotizacion = id.Where(s => s.idCliente == IdCliente).Max(m => m.IdCotizacion);
                noSumar = false;
            }
            else
            {
                if (dbContext.Cotizaciones.Where(s => s.idCliente == IdCliente).Max(m => m.IdCotizacion) == IdCotizacion)
                    noSumar = false;
            }
            if(noSumar)
                IdCotizacion++;
            btnEditar.Enabled = true;
            GenerarReporte("rptCotizacion", false);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdCotizacion == 0)
            {
                var id = dbContext.Cotizaciones.Where(s => s.idCliente == IdCliente);
                if (id.Any())
                    IdCotizacion = id.Where(s => s.idCliente == IdCliente).Max(m => m.IdCotizacion);
            }
                btnEditar.Enabled = true;
            if (IdCotizacion > 0)
                IdCotizacion--;
            GenerarReporte("rptCotizacion",false);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdCliente != 0)
                GenerarReporte("rptCotizacion", true);
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var factura = new F.D.Factura();
            factura.detalle = new Controller.Cotizacion().BuscarCotizacion(IdCotizacion);
            factura.ShowDialog();
        }
        private void GenerarReporte(string reporte, bool imprimir)
        {

            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\\Facturacion\\{0}.repx", reporte));
            report.Parameters["parameter1"].Value = IdCotizacion;
            if (imprimir)
            {
                var printTool3 = new ReportPrintTool(report);
                printTool3.PreviewForm.MdiParent = this.MdiParent;
                printTool3.PreviewForm.Text = reporte;
                printTool3.ShowPreview();
            }

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cotizacion = dbContext.Cotizaciones.SingleOrDefault(w => w.IdCotizacion == IdCotizacion);
            if(cotizacion != null)
            {
                LstCotizaciones.Clear();
                cotizacion.DetalleCotizacion.ToList().ForEach(f => {
                    LstCotizaciones.Add(new Model.DetalleCotizacion {
                        Cantidad = f.Cantidad,
                        Detalle = f.Detalle,
                        IdServicio = f.IdServicio,
                        ITBM = f.Itbm??0,
                        Monto = f.Monto??0,
                        Total = f.Total??0,
                        Descripcion = f.Descripcion
                    });
                });
                IdCliente = cotizacion.idCliente??0;
                tCotizacion.Text = cotizacion.Cotizacion;
                IdCotizacion = cotizacion.IdCotizacion;
                detalleCotizacionBindingSource.DataSource = LstCotizaciones;
            }

        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdCotizacion = 0;
            btnEditar.Enabled = false;
        }
    }
}