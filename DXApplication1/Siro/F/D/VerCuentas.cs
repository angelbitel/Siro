using DevExpress.XtraEditors;
using Siro.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class VerCuentas : DevExpress.XtraEditors.XtraForm
    {
        public VerCuentas()
        {
            InitializeComponent();
        }

        private void VerCuentas_Load(object sender, EventArgs e)
        {
            var lst = new Controller.Lst();
            vAsientosBindingSource.DataSource = lst.LstAsientos(Principal.Bariables.PeridoContable.Year, Principal.Bariables.PeridoContable.Month, Principal.Bariables.IdEmpresa.Id);
        }
        private VAsientos Asiento { get; set; }
        public BindingList<AsientoContable> Asientos { get; set; }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Asiento = gridView1.GetFocusedRow() as VAsientos;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = (vAsientosBindingSource.DataSource) as List<VAsientos>;
            if (Asiento == null) return;
            var rowF = row.Where(o => o.IdAsiento == Asiento.IdAsiento);
            Asientos = new BindingList<AsientoContable>();
            if (rowF != null)
            {
                rowF.ToList().ForEach(f =>
                {
                    Asientos.Add(new AsientoContable
                    {
                        Comentario = f.Entidad,
                        Credito = f.Credito,
                        CuentaContable = f.Cuenta,
                        //CuentasCombinadas = f.Id,
                        Debito = f.Debito,
                        Fecha = f.Fecha,
                        //IdAsiento = f.IdAsiento,
                        IdBanco = f.IdBanco,
                        IdCliente = f.IdCliente,
                        IdCuentaContable = f.IdCuentaContable,
                        IdProveedor = f.idProvedor,
                        //IdDetalleAsiento =f.IdDetalleAsiento
                    });
                });
                var eje = new Controller.Diario();
                eje.EliminarAsiento(Asiento.IdAsiento);
                this.Close();
            }
        }

        private void btnQuitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var eje = new Controller.Diario();
            if (XtraMessageBox.Show("Seguro Que Deseas Eliminar Asiento", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (Asiento == null)
                {
                    XtraMessageBox.Show("Seleccione un asiento");
                    return;
                }
                   
                eje.EliminarAsiento(Asiento.IdAsiento);
                var lst = new Controller.Lst();
                gridControl1.DataSource = lst.LstAsientos(Principal.Bariables.PeridoContable.Year, Principal.Bariables.PeridoContable.Month, Principal.Bariables.IdEmpresa.Id);
            }

        }
    }
}