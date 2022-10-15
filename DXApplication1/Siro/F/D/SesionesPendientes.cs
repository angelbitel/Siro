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
    public partial class SesionesPendientes : DevExpress.XtraEditors.XtraForm
    {
        public SesionesPendientes() => InitializeComponent();
        BindingList<SesionesAplicacion> lstSesiones = new BindingList<SesionesAplicacion>();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var db = new Controller.VMSesiones();
            lstSesiones.ToList().ForEach(f => db.ActualizarSesion(f.IdSesion));
            lstSesiones.Clear();
            new Controller.VMSesiones().SesionesAbiertas.ForEach(f => lstSesiones.Add(f));
            sesionesAplicacionBindingSource.DataSource = lstSesiones;
            lbl.Caption = "SE ACTUALIZO CORRECTAENTE LA SESION";
        }
        private void SesionesPendientes_Load(object sender, EventArgs e)
        {
            new Controller.VMSesiones().SesionesAbiertas.ForEach(f => lstSesiones.Add(f));
            sesionesAplicacionBindingSource.DataSource = lstSesiones;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as SesionesAplicacion;
            if (new Controller.VMSesiones().ActualizarSesion(row.IdSesion))
            {
                lstSesiones.Clear();
                new Controller.VMSesiones().SesionesAbiertas.ForEach(f => lstSesiones.Add(f));
                sesionesAplicacionBindingSource.DataSource = lstSesiones;
                lbl.Caption = "SE ACTUALIZO CORRECTAENTE LA SESION";
            }
        }
        internal SesionesAplicacion Sesion { get; set; }
        internal int CantidadPendientes { get; set; }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as SesionesAplicacion;
            if(row != null)
            {
                Sesion = row;
                this.Close();
            }
        }

        private void SesionesPendientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            CantidadPendientes = lstSesiones.Count;
        }
    }
}