using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.P
{
    public partial class PlanillaGenerada : DevExpress.XtraEditors.XtraForm
    {
        public PlanillaGenerada()
        {
            InitializeComponent();
            ActualizarMetodos();
            FillList();
        }

        private void ActualizarMetodos()
        {
            this.Text = string.Format(" PLANILLA DE: [{0}]", Settings.Default.DEmpresa);
            Year = Principal.Bariables.PeridoContable.Year;
            Month = Principal.Bariables.PeridoContable.Month;
            int dia = 1;
            if (Principal.Bariables.PeridoContable.Day > 15)
                dia = 2;
            moiety = dia;
        }

        private void FillList()
        {                     
            using (var db = new slPlanilla())
            {  
                var lst = new List<Model.Planilla>();

                db.PlanillaColaborador.Where(w => w.Año == Year && w.Mes == Month && w.Quincena == moiety && w.IdEmpresa == Settings.Default.DIdEmpresa).ToList().ForEach(f =>
                {
                    lst.Add(new Model.Planilla
                    {
                        Id = f.Id,
                        IdColaborador = f.IdColaborador,
                        IdEmpresa = f.IdEmpresa,
                        IdUser = f.IdUser,
                        FechaProceso = f.FechaProceso,
                        Año = f.Año,
                        Mes = f.Mes,
                        Quincena = f.Quincena,
                        RataPorHora = f.RataPorHora,
                        SalarioQuincenal = f.SalarioQuincenal,
                        TotalHoras = f.TotalHoras,
                        SalarioBruto = f.SalarioBruto,
                        OtrasDeducciones = f.OtrasDeducciones,
                        CXCRecurrentes = f.CXCRecurrentes,
                        CXC = f.CXC,
                        SeguroSocial = f.SeguroSocial,
                        SeguroEducativo = f.SeguroEducativo,
                        ISR = f.ISR,
                        SeguroSocialPatronal = f.SeguroSocialPatronal,
                        SeguroEducativoPatronal = f.SeguroEducativoPatronal,
                        Decimo = f.Decimo,
                        Vacacciones = f.Vacacciones,
                        SalarioNeto = f.SalarioNeto,
                        indemnizacion = f.indemnizacion,
                        Antiguedad = f.Antiguedad,
                        Recerva = f.Recerva,
                        Riesgo = f.Riesgo,
                        PeriodDecimo = f.PeriodDecimo,
                        SeguroSocialDecimo = f.SeguroSocialDecimo,
                        SeguroSocialDecimoPatrono = f.SeguroSocialDecimoPatrono,
                        Bonificaciones = f.Bonificaciones,
                        TipoContrato = f.Colaboradores.ContratosColaborador.ContratoColaborador??"",
                        Estado = f.Colaboradores.EstadosColaborador.EstadoColaborador??""
                    });
                });
                if(repositoryItemImageComboBoxEstado.Items.Count == 0)
                {
                    db.EstadosColaborador.ToList().ForEach(f => repositoryItemImageComboBoxEstado.Items.Add(T.Item(f.EstadoColaborador, f.EstadoColaborador)));
                }
                db.Colaboradores.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdColaborador,
                        Description = f.Colaborador
                    };
                    this.repositoryItemImageComboBox1.Items.Add(item);
                    //if (f.IdEstadoColaborador == 2)
                    //    lst.Add(new Model.Planilla
                    //    {
                    //        IdColaborador = f.IdColaborador,
                    //        IdEmpresa = f.IdEmpresa ?? 0,
                    //        Quincena = (int)f.SalarioQuincenal,
                    //        RataPorHora = f.RataPorHora,
                    //        SalarioQuincenal = f.SalarioQuincenal,
                    //        SalarioBruto = (int)f.SalarioQuincenal,
                    //        SalarioNeto = (int)f.SalarioQuincenal,
                    //        Bonificaciones = f.Bonificaciones,
                    //        TipoContrato = f.ContratosColaborador.ContratoColaborador ?? "",
                    //        Estado = f.EstadosColaborador.EstadoColaborador ?? ""
                    //    });
                });
                planillaColaboradorBindingSource.DataSource = lst;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActualizarMetodos();
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
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var row = gridView1.GetFocusedRow() as PlanillaColaborador;
                if (row != null)
                {
                    using (var db = new slPlanilla())
                    {
                        db.PlanillaColaborador.Remove(db.PlanillaColaborador.SingleOrDefault(s => s.Id == row.Id));
                        db.SaveChanges();
                        lblMsg.Caption = "Registro Eliminado = " + row.Id;
                    }
                }
            }
        }
        private void CalculosDeduccionesAcredores()
        {
            var proces = new Controller.Colaborador();
            lblMsg.Caption = "Ejecutando Procedo De Deducciones Acredores!!";
            if (proces.ProcesarDeduccionesAcredores())
            {
                lblMsg.Caption = string.Format("Se Procesaron Deducciones Correctamente!!");
            }
        }
        public void CalculosHoras()
        {
            BuscarRegistrosHoras();
            var proces = new Controller.Colaborador();
            proces.CalculosHoras();

            lblMsg.Caption = proces.MSG;
        }
        private void BuscarRegistrosHoras()
        {
            lblMsg.Caption = System.IO.File.Exists(Settings.Default.ArchivoPlanilla).ToString();
            if (!System.IO.File.Exists(Settings.Default.ArchivoPlanilla))
                return;
            var lines = System.IO.File.ReadAllLines(Settings.Default.ArchivoPlanilla);
            var lstHoras = new List<HorasTrabajadas>();
            foreach (var line in lines)
            {
                var str = Utility.SplitFixedWidth(line, false, new int[] { 2, 3, 2, 6, 2, 4 });
                lstHoras.Add(new HorasTrabajadas
                {
                    Año = int.Parse(str[5]),
                    HoraTrabajada = decimal.Parse(str[3]),
                    IdColaborador = int.Parse(str[1]),
                    IdEmpresa = int.Parse(str[0]),
                    IdFactor = int.Parse(str[2]),
                    Mes = int.Parse(str[4])
                });
            }
            using (var db = new slPlanilla())
            {
                lstHoras.ForEach(f =>
                {
                    var row = db.HorasTrabajadas.Count(s => s.Año == f.Año && s.Mes == f.Mes && s.IdColaborador == f.IdColaborador && s.HoraTrabajada == f.HoraTrabajada);
                    if (row == 0)
                    {
                        new Controller.HoraTrabjada().Guardar(f);
                    }
                    this.lblMsg.Caption = string.Format("Procesando La Hora {0} del codigo colaborador {1}:", f.IdColaborador, f.HoraTrabajada);
                });
                this.lblMsg.Caption = "Proceso Terminado";
            }
        }

        private void btnGenerarAsientos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BuscarRegistrosHoras();
                var proces = new Controller.Colaborador();
                proces.GenerarAsientos();
                lblMsg.Caption = proces.MSG;
            }
        }

        private void btnActualizarPlanilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CalculosDeduccionesAcredores();
                CalculosHoras();
                lblMsg.Caption = "Planilla Generada!.....";
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = XtraReport.FromFile(string.Format(@"Reportes\\Planilla\\{0}.repx", "ResumenPlanilla"));
            report.Parameters["prmIdEmpresa"].Value = Settings.Default.DIdEmpresa;
            report.Parameters["prmAnio"].Value = Year;
            report.Parameters["prmMes"].Value = Month;
            report.Parameters["prmQuincena"].Value = moiety;
            var printTool3 = new ReportPrintTool(report, true); 
            
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "PLANILLA";
            printTool3.ShowPreview();
        }
    }
}