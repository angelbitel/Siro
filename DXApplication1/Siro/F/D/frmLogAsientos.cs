using DevExpress.XtraEditors;
using Siro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class frmLogAsientos : DevExpress.XtraEditors.XtraForm
    {
        public BindingList<AsientoContable> Asientos { get; set; }
        public frmLogAsientos()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void Refrescar()
        {
            if (Asientos == null)
                Asientos = new BindingList<AsientoContable>();
            var lst = new Controller.Lst();
            Asientos.Clear();
            lst.LstAsientosResumenLog(dateEditdesde.DateTime, dateEditHasta.DateTime, Principal.Bariables.IdEmpresa.Id).ToList().ForEach(f =>
            {
                Asientos.Add(new AsientoContable
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = f.CuentaContable,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detlle = f.Detalle,
                    IdOrigen = f.IdOrigen,
                     FechaOperacion = f.FechaOperacion
                });
            });
            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {Asientos.ToList().GroupBy(g => g.IdAsiento).Select(s => s.Key).Count()}";
            var asientosDesba = Asientos.GroupBy(g => new { g.IdAsiento }).Select(s => new { s.Key.IdAsiento, Debito = s.Sum(su => su.Debito), Credito = s.Sum(su => su.Credito) }).ToList();
            asientosDesba.ToList().Where(w => w.Debito - w.Credito != 0).ToList().ForEach(f =>
            {
                Asientos.Where(w => w.IdAsiento == f.IdAsiento).ToList().ForEach(g =>
                {
                    g.Desbalanceado = true;
                });
            });

            lblMsg.Caption = $"CANTIDAD DE ASIENTOS: {asientosDesba.Count()};";
            gridControl1.DataSource = Asientos;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void frmLogAsientos_Load(object sender, EventArgs e)
        {
            dateEditdesde.EditValue = DateTime.Now.AddMonths(-1);
            dateEditHasta.EditValue = DateTime.Now;
        }
    }
}