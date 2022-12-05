using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace Siro.F.P
{
    public partial class Cumpleaños : DevExpress.XtraEditors.XtraForm
    {
        public Cumpleaños()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowPrintPreview();
        }
        private string colaboradores(int d)
        {
            var lstCu = new List<string>();
            lstC.Where(w => w.FechaNacimiento.Value.Day == d).ToList().ForEach(f =>
                {
                    lstCu.Add(f.Colaborador);
                });
            return d.ToString() + " " + String.Join(" • ", lstCu);
        }
        private List<Colaboradores> lstC { get; set; }
        private void Cumpleaños_Load(object sender, EventArgs e)
        {
            var lst = new Controller.Lst();
            lstC = lst.CumpleañosMes;
            int maxdt = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1)).Day;
            string month = DateTime.Now.ToString("MMM");// should be in the format of Jan, Feb, Mar, Apr, etc...
            int yearofMonth = DateTime.Now.Year;
            DateTime dateTime = Convert.ToDateTime("01-" + month + "-" + yearofMonth);
            DataRow dr;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lunes");
            dt.Columns.Add("Martes");
            dt.Columns.Add("Miercoles");
            dt.Columns.Add("Jueves");
            dt.Columns.Add("Viernes");
            dt.Columns.Add("Sabado");
            dt.Columns.Add("Domingo");
            dr = dt.NewRow();
            for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i += 1)
            {
                //txtMonth.Text = Convert.ToDateTime(dateTime.AddDays(0)).ToString("dddd");
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "lunes" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "monday")
                {
                    dr["Lunes"] = colaboradores(i + 1);
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "martes" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "tuesday")
                {
                    dr["Martes"] = colaboradores(i + 1);
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "miercoles" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "wednesday")
                {
                    dr["Miercoles"] = colaboradores(i + 1);

                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "jueves" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "thursday")
                {
                    dr["Jueves"] = colaboradores(i + 1);
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "viernes" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "friday")
                {
                    dr["Viernes"] = colaboradores(i + 1);
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "sabado" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "saturday")
                {
                    dr["Sabado"] = colaboradores(i + 1);
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "domingo" || Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "sunday")
                {
                    dr["Domingo"] = colaboradores(i + 1);
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    continue;
                }
                if (i == DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - 1)
                {
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();

                }
            }
            gridControl1.DataSource = dt;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.RowHandle == currentView.FocusedRowHandle) return;
            int d= 0;
            int.TryParse(e.CellValue.ToString(), out d);
            if(d!= 0)
            {
                string colaborador = string.Empty;
                Rectangle r = e.Bounds;
                lstC.Where(w => w.FechaNacimiento.Value.Day == d).ToList().ForEach(f =>
                {
                    colaborador += f.Colaborador;
                    e.Appearance.DrawString(e.Cache, e.DisplayText + " "+ f.Colaborador, r);
                    e.Handled = true;
                    e.DefaultDraw();
                    e.Graphics.DrawImage(DevExpress.Images.ImageResourceCache.Default.GetImage("images/maps/geopoint_16x16.png"), e.Bounds.Location);
                });
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            //if (e.SelectedControl != gridControl1) return;

            //ToolTipControlInfo info = null;
            ////Get the view at the current mouse position
            //GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            //if (view == null) return;
            ////Get the view's element information that resides at the current position
            //GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            ////Display a hint for row indicator cells
            //if (hi.HitTest == GridHitTest.RowIndicator)
            //{
            //    //An object that uniquely identifies a row indicator cell
            //    object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
            //    string text = "Row " + hi.RowHandle.ToString();
            //    info = new ToolTipControlInfo(o, text);
            //}
            ////Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
            //if (info != null)
            //    e.Info = info;
        }

    }
}