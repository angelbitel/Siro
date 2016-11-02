using System;
using System.Collections.Generic;
using System.Linq;

namespace Siro.F.D
{
    public partial class Mayor : DevExpress.XtraEditors.XtraForm
    {
        List<Model.Mayor> Mayores = new List<Model.Mayor>();
        Siro.slContabilidad dbContext = new Siro.slContabilidad();
        public Mayor()
        {
            InitializeComponent();
        }
        private void Mayor_Load(object sender, EventArgs e)
        {
            int año= Principal.Bariables.PeridoContable.Year;
            int mes= Principal.Bariables.PeridoContable.Month;
            int id = Principal.Bariables.IdEmpresa.Id;
            GenerarDatos(año, mes, id);
        }
        private void GenerarDatos(int año, int mes, int id)
        {
            decimal currentTotal = 0;

            var rest = dbContext.VMayorAsientos.Where(w => w.Año == año && w.Mes == mes && w.IdEmpresa == id).Select(s => new
            {
                s.Comentario,
                s.Entidad,
                s.Credito,
                s.Cuenta,
                s.Debito,
                s.Fecha,
                s.IdAsiento,
                s.IdCuentaContable,
                s.IdEmpresa,
                Balance = currentTotal,
                s.Nivel2,
                s.IdDetalleAsiento
            }).OrderBy(o => o.Cuenta);
            rest.ToList().ForEach(f =>
            {
                Mayores.Add(new Model.Mayor
                {
                    Comentario = string.Format("{0} {1}", f.Cuenta, f.Entidad != null ? "[" + f.Entidad + "]":""),
                    Credito = f.Credito??0,
                    Cuenta = f.Nivel2,
                    Debito = f.Debito??0,
                    Fecha = f.Fecha,
                    IdDetalleAsiento =f.IdDetalleAsiento,
                    IdAsiento = f.IdAsiento,
                    IdCuentaContable = f.IdCuentaContable,
                    IdEmpresa = f.IdEmpresa,
                    Balance = currentTotal += f.Debito == 0M || f.Debito == null ? -f.Credito ?? 0M : f.Debito ?? 0M
                });
            });
            gridControl1.DataSource = Mayores;
            gridView1.ExpandAllGroups();
            this.barStaticItemFecha.Caption = Principal.Bariables.PeridoContable.ToString("yyyy MMMM");
            this.barStaticItemEmpresa.Caption = Principal.Bariables.IdEmpresa.Nombre;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowPrintPreview();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int año = Principal.Bariables.PeridoContable.Year;
            int mes = Principal.Bariables.PeridoContable.Month;
            int id = Principal.Bariables.IdEmpresa.Id;
            GenerarDatos(año, mes, id);
        }
    }
}