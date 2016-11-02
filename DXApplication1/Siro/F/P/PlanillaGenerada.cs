using DevExpress.XtraEditors.Controls;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Siro.F.P
{
    public partial class PlanillaGenerada : DevExpress.XtraEditors.XtraForm
    {
        public PlanillaGenerada()
        {
            InitializeComponent();
            this.Text += string.Format(" [{0}]", Settings.Default.DEmpresa);
            Year = Principal.Bariables.PeridoContable.Year;
            Month = Principal.Bariables.PeridoContable.Month;
            int dia = 1;
            if (Principal.Bariables.PeridoContable.Day > 15)
                dia = 2;
            moiety = dia;
            FillList();
        }

        private void FillList()
        {                     
            using (var db = new slPlanilla())
            {  
                var lst = new List<PlanillaColaborador>();
                db.Colaboradores.Where(w => w.IdEstadoColaborador != 2).ToList().ForEach(f =>
                    {
                        ImageComboBoxItem item = new ImageComboBoxItem
                        {
                            Value = f.IdColaborador,
                            Description = f.Colaborador
                        };
                        this.repositoryItemImageComboBox1.Items.Add(item);
                    });

                db.PlanillaColaborador.Where(w => w.Año == Year && w.Mes == Month && w.Quincena == moiety && w.IdEmpresa == Settings.Default.DIdEmpresa).ToList().ForEach(f => lst.Add(f));
                planillaColaboradorBindingSource.DataSource = lst;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillList();
        }
        private int Year { get; set; }
        private int Month { get; set; }
        private int moiety { get; set; }
        private void btnAtras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var db = new slPlanilla())
            {
                var lst = new List<PlanillaColaborador>();
                db.Colaboradores.Where(w => w.IdEstadoColaborador != 2).ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdColaborador,
                        Description = f.Colaborador
                    };
                    this.repositoryItemImageComboBox1.Items.Add(item);
                });

                db.PlanillaColaborador.Where(w => w.Año == Year && w.IdEmpresa == Settings.Default.DIdEmpresa).OrderByDescending(o => new {o.Mes, o.Quincena }).ToList().ForEach(f => lst.Add(f));
                planillaColaboradorBindingSource.DataSource = lst;
            }
        }

        private void btnAdelante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Month = Principal.Bariables.PeridoContable.Month + 1;
            FillList();
        }

        private void repositoryItemTextEdit3_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
            }
        }

        private void repositoryItemTextEdit3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colSalarioQuincenal) return;
            var row = gridView1.GetFocusedRow() as PlanillaColaborador;
            if (row != null)
            {
                using (var db = new slPlanilla())
                {
                    db.PlanillaColaborador.SingleOrDefault(s => s.Id == row.Id).SalarioQuincenal = row.SalarioQuincenal;
                    db.SaveChanges();
                    db.MaestroPlanillaIndividual(Principal.Bariables.IdUsuario, Principal.Bariables.IdEmpresa.Id, new DateTime(row.Año, row.Mes, row.Quincena == 1 ? 14 : 28), row.IdColaborador, row.SalarioQuincenal);
                    lblMsg.Caption = "Colaborador Actualizado " + row.IdColaborador + " Salario Quincenal: " + row.SalarioQuincenal.ToString();
                }
            }
        }
    }
}