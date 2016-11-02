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
using System.Globalization;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

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
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd").ToLower() == "lunes")
                {
                    dr["Lunes"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "martes")
                {
                    dr["Martes"] = i + 1;
                }
                if (string.Compare(dateTime.AddDays(i).ToString("dddd"), "miercoles", CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                {
                    dr["Miercoles"] = i + 1;

                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "jueves")
                {
                    dr["Jueves"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "viernes")
                {
                    dr["Viernes"] = i + 1;
                }
                if (string.Compare(dateTime.AddDays(i).ToString("dddd"),"sabado",CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase)==0)
                {
                    dr["Sabado"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd").ToLower() == "domingo")
                {
                    dr["Domingo"] = i + 1;
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
            int d= 0;
            int.TryParse(e.CellValue.ToString(), out d);
            if(d!= 0)
            {
                string cumpleaños="";
                lstC.Where(w => w.FechaNacimiento.Value.Day == d).ToList().ForEach(f =>
                {
                    if (f.Img != null)
                    {
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        e.Graphics.DrawImage(byteArrayToImage(f.Img), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);          
                        e.Handled = false;
                    }
                    cumpleaños += " " + f.Colaborador;
                });
                e.CellValue = cumpleaños;
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridControl1) return;

            ToolTipControlInfo info = null;
            //Get the view at the current mouse position
            GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null) return;
            //Get the view's element information that resides at the current position
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            //Display a hint for row indicator cells
            if (hi.HitTest == GridHitTest.RowIndicator)
            {
                //An object that uniquely identifies a row indicator cell
                object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
                string text = "Row " + hi.RowHandle.ToString();
                info = new ToolTipControlInfo(o, text);
            }
            //Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
            if (info != null)
                e.Info = info;
        }

    }
}