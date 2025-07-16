using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Spreadsheet.Export;
using Siro.Properties;

namespace Siro.F.P
{
    public partial class ArchivosHoras : DevExpress.XtraEditors.XtraForm
    {
        private List<Model.ConfiguracionHoras> Columnas { get; set; }
        private BindingList<Model.DiasFeriados> DiasFeriados { get; set; }
        private BindingList<Model.HoraReloj> LstHoraTrajadas = new BindingList<Model.HoraReloj>();
        private List<Colaboradores> LstColaboradores = new List<Colaboradores>();
        private readonly Controller.Horas dbH;
        public ArchivosHoras()
        {
            InitializeComponent();
            barButtonItemEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemEliminar_ItemClick);
            dbH = new Controller.Horas();
            Load += new System.EventHandler(ArchivosHoras_Load);
            barButtonItemBuscarFecha.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemBuscarFecha_ItemClick);
        }

        private void ArchivosHoras_Load(object sender, EventArgs e)
        {
            Columnas = dbH.LstColumnaOrigen;
            LstColaboradores = new Controller.Colaborador().ListaColaboradoresActivo(Settings.Default.DIdEmpresa);
            gridControl1.DataSource = LstHoraTrajadas;
            barEditItemPrmDesde.EditValue = DateTime.Now.AddDays(-15).Date;
            barEditItemPrmHasta.EditValue = DateTime.Now.Date;
            gridControlResumenHorario.DataSource = LstHoraTrajadas;
        }

        private DataTable Range(CellRange range, DataTable dataTable)
        {
            for (int col = 0; col < range.ColumnCount; col++)
            {
                CellValueType cellType = range[0, col].Value.Type;
                for (int r = 1; r < range.RowCount; r++)
                {
                    if (cellType != range[r, col].Value.Type)
                    {
                        //dataTable.Columns[col].DataType = typeof(range[r, col].Value.Type);
                        //break;
                    }
                }
            }
            return dataTable;
        }
        private TimeSpan GetTimeAttended(TimeSpan startTime, TimeSpan endTime)
        {
            // Ensure that the endTime is later than startTime
            if (endTime < startTime)
            {
                //throw new ArgumentException("End time must be greater than start time.");
            }
            // Calculate the time attended
            TimeSpan timeAttended = startTime - endTime;
            return timeAttended;
        }

        private void spreadsheetControl1_DocumentLoaded(object sender, EventArgs e)
        {
            LstHoraTrajadas.Clear();
            var workSheet = spreadsheetControl1.Document.Worksheets[0];
            var range = workSheet.GetDataRange();
            DataTable dataTable = workSheet.CreateDataTable(range, true);
            dataTable = Range(range, dataTable);
            DataTableExporter exporter = workSheet.CreateDataTableExporter(range, dataTable, true);

            exporter.Export();
            var datos = new List<Model.HoraReloj>();
            string CDate = string.Empty, CUser = string.Empty, CTime = string.Empty;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var col = Columnas.SingleOrDefault(s => s.Origen == dataTable.Columns[i].ToString().Trim());
                if (col != null)
                    switch (col.Destino)
                    {
                        case "Date":
                            CDate = col.Origen;
                            break;
                        case "User":
                            CUser = col.Origen;
                            break;
                        case "Time":
                            CTime = col.Origen;
                            break;
                        default:
                            break;
                    }

            }
            foreach (DataRow item in dataTable.Rows)
            {
                var hora = new Model.HoraReloj
                {
                    Date = DateTime.Parse(item[CDate].ToString()),
                    Time = item[CTime].ToString(),
                    User = item[CUser].ToString(),
                    Habilitar = false
                };

                if (Principal.Bariables.PeridoContable.ToString("yyyyMM") == hora.Date.ToString("yyyyMM"))
                {
                    if (Principal.Bariables.PeridoContable.Day <= 15 && hora.Date.Day <= 15)
                        hora.Habilitar = true;
                    else if (Principal.Bariables.PeridoContable.Day > 15 && hora.Date.Day > 15)
                        hora.Habilitar = true;
                }
                else
                {
                    lbl.Caption = $"EL PERIDO DE  {Principal.Bariables.PeridoContable:yyyyMM}  QUE ESTA TRABAJANDO NO CONCUERDA CON EL DEL ARCHIVO { hora.Date:yyyyMM}";
                }
                var colaborador = LstColaboradores.FirstOrDefault(s => s.Reloj == item[CUser].ToString());
                //if (LstColaboradores.Where(s => s.Reloj == item[CUser].ToString()).ToList().Count > 1)
                //    colaborador = colaborador;
                if (colaborador != null)
                {
                    hora.IdUser = colaborador.IdColaborador;

                    hora.HoraEntrada = new TimeSpan(colaborador.HoraEntrada.Value.Hours, colaborador.HoraEntrada.Value.Minutes, 0);

                    TimeSpan limitTime = new TimeSpan(colaborador.HoraEntrada.Value.Hours, colaborador.HoraEntrada.Value.Minutes, 0);

                    // Verificar si es sábado
                    if (hora.Date.DayOfWeek == DayOfWeek.Saturday)
                        hora.HoraEntrada = new TimeSpan(colaborador.HoraEntradaSabado.Value.Hours, colaborador.HoraEntradaSabado.Value.Minutes, 0);
                }
                datos.Add(hora);
            }

            datos.
                Where(w => w.Habilitar == true).
                GroupBy(b => new
                {
                    b.Colaborador,
                    b.User,
                    b.Date.Date
                }).Select(s => new
                {
                    Date = s.Key.Date,
                    Colaborador = s.Key.Colaborador,
                    User = s.Key.User,
                    MinHour = s.Min(t => t.TimeConverter),
                    MaxHour = s.Max(x => x.TimeConverter)
                }).ToList().
                ForEach(f => LstHoraTrajadas.Add(new Model.HoraReloj
                {
                    Colaborador = f.Colaborador,
                    Date = f.Date,
                    User = f.User,
                    EntroALas = f.MinHour,
                    SalioALas = f.MaxHour,
                }));

            LstHoraTrajadas.ToList().ForEach(f =>
            {
                var colaborador = LstColaboradores.SingleOrDefault(s => s.Reloj == f.User);
                if (colaborador != null)
                {
                    f.Colaborador = colaborador.Colaborador;
                    f.IdUser = colaborador.IdColaborador;

                    TimeSpan enterTime = new TimeSpan(f.EntroALas.Value.Hours, f.EntroALas.Value.Minutes, 0);

                    TimeSpan limitTime = new TimeSpan(colaborador.HoraEntrada.Value.Hours, colaborador.HoraEntrada.Value.Minutes, 0);

                    // Verificar si es sábado
                    if (f.Date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        limitTime = new TimeSpan(colaborador.HoraEntradaSabado.Value.Hours, colaborador.HoraEntradaSabado.Value.Minutes, 0);
                        f.HoraEntradaSabado = colaborador.HoraEntradaSabado;
                    }
                    else
                        f.HoraEntrada = colaborador.HoraEntrada;

                    if (enterTime > limitTime)
                    {
                        f.Delay = GetTimeAttended(enterTime, limitTime);
                    }
                }
                else
                    f.Colaborador = $"ACTUALIZAR DATOS --> {f.User}";
            });


            //BUSCAR AUSENCIAS DIAS
            var ausencias = new List<Model.HoraReloj>();
            var minDay = datos.Min(m => m.Date);
            var maxDay = datos.Max(m => m.Date);
            

            //AGREGAR DIA FERIADOS DEL PERIDO
            var diasFeriadoPeriodo = dbH.DiasFeriados.Where(w => w.Date >= minDay.Date && w.Date <= maxDay.Date).ToList();
            if (diasFeriadoPeriodo.Count > 0)
            {
                DiasFeriados = new BindingList<Model.DiasFeriados>();
                diasFeriadoPeriodo.ForEach(f => DiasFeriados.Add(new Model.DiasFeriados { DiaLibre = f }));
                var frm = new frmDiasLibres();
                frm.LstDiasFeriados = DiasFeriados;
                frm.ShowDialog();
                if (frm.Aceptar)
                    DiasFeriados = frm.LstDiasFeriados;
            }

            // Group work hours by date and user
            var horaColaborador = datos
                .GroupBy(g => new { g.Date.Date, g.IdUser })
                .Select(s => new { Dia = s.Key.Date, IdUser = s.Key.IdUser })
                .ToList();
            if (DiasFeriados == null)
                DiasFeriados = new BindingList<Model.DiasFeriados>();

                // Iterate over active employees
                LstColaboradores
                    .Where(w => w.IdEstadoColaborador == 1 && !string.IsNullOrEmpty(w.Reloj))
                    .ToList()
                    .ForEach(f =>
                    {
                        // Iterate over the date range
                        foreach (var g in CreateDateArray(minDay, maxDay))
                        {
                            if (!DiasFeriados.Any(a => a.DiaLibre.Date == g.Date) && g.DayOfWeek != DayOfWeek.Sunday)
                            {
                                var horasAusencia = g.DayOfWeek == DayOfWeek.Saturday ? 4 : 8;

                                // Check if the employee worked on the current day
                                var workedOnDay = horaColaborador.Any(w => w.IdUser == f.IdColaborador && g.Date == w.Dia.Date);

                                // If no worked hours, add an absence
                                if (!workedOnDay)
                                {
                                    ausencias.Add(new Model.HoraReloj
                                    {
                                        User = f.Reloj,
                                        Colaborador = f.Colaborador,
                                        Date = g.Date,
                                        Delay = new TimeSpan(horasAusencia, 0, 0),
                                        Habilitar = true,
                                        IdUser = f.IdColaborador,
                                        EsAusenciaJustificada = false
                                    });
                                }
                            }
                        }
                    });
            ausencias.ForEach(f => LstHoraTrajadas.Add(f));
            LstHoraTrajadas.ToList().ForEach(f =>
            {
                if (f.Delay == TimeSpan.Zero)
                    LstHoraTrajadas.Remove(f);
            });
            int j = 0;
            LstHoraTrajadas.ToList().ForEach(f =>f.Id =j++);
            LstHoraTrajadas.ToList().ForEach(f =>
            {
                var colaborador = LstColaboradores.SingleOrDefault(s => s.IdColaborador == f.IdUser);
                if(colaborador != null)
                {
                    if(f.Date.DayOfWeek != DayOfWeek.Saturday)
                    {
                        f.HoraEntrada = colaborador.HoraEntrada;
                        f.HoraSalida = colaborador.HoraSalida;
                    }
                    else
                    {
                        f.HoraEntrada = colaborador.HoraEntradaSabado;
                        f.HoraSalida = colaborador.HoraSalidaSabado;
                    }
                }

                //Verificar si solo marco entrada
                if(f.EntroALas == f.SalioALas && f.EntroALas !=null)
                {
                    f.SalioALas = null;
                    f.Delay = new TimeSpan(f.Date.DayOfWeek == DayOfWeek.Saturday ? 4 : 8, 0, 0);
                    f.Comentario = "NO MARCO SALIDA..";
                }

                //Verificar si solo marco salida
                if (f.EntroALas == f.SalioALas && f.SalioALas != null)
                {
                    f.SalioALas = null;
                    f.Delay = new TimeSpan(f.Date.DayOfWeek == DayOfWeek.Saturday ? 4 : 8, 0, 0);
                    f.Comentario = "NO MARCO ENTRADA..";
                }

                //Verificar si solo marco salida
                if (f.EntroALas == null && f.SalioALas == null)
                {
                    f.Comentario = "SIN MARCACION..";
                }
                if(f.Delay < TimeSpan.FromMinutes(15))
                {
                    f.Comentario = "TARDANZA..";
                }
            });
        }
        private DateTime[] CreateDateArray(DateTime minDate, DateTime maxDate)
        {
            // Calculate the number of days between the two dates
            int totalDays = (maxDate - minDate).Days + 1; // +1 to include the maxDate

            // Create an array of days
            DateTime[] daysArray = new DateTime[totalDays];

            // Fill the array with the range of dates
            for (int i = 0; i < totalDays; i++)
            {
                daysArray[i] = minDate.AddDays(i);
            }

            return daysArray;
        }

        private void repositoryItemHyperLinkEditElimnar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("DESEA ELIMINAR ESTE REGISTRO?", "ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (gridViewMarcacion.GetFocusedRow() is Model.HoraReloj row)
                {
                    LstHoraTrajadas.Remove(row);
                }
            }
        }

        private void barButtonItemVerificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("DESEA CREAR LOS REGISTROS?", "ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LstHoraTrajadas.Where(w => w.TotalHours > 0).ToList().ForEach(f =>
                {
                    var horaTrabajada = new HorasTrabajadas
                    {
                        Año = f.Date.Year,
                        HoraTrabajada = f.TotalHours,
                        IdColaborador = f.IdUser,
                        IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                        IdFactor = !f.EsAusenciaJustificada?  1 :1001,
                        Mes = Principal.Bariables.PeridoContable.Month,
                        Fecha = f.Date,
                        Comentario = f.Comentario,
                        Quincena = Principal.Bariables.PeridoContable.Day <= 15? 1 : 2
                    };
                    new Controller.HoraTrabjada().Guardar(horaTrabajada);
                });
            }
        }
        private async void barButtonItemEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Initialize a new XtraInputBoxArgs instance
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            // Set required Input Box options
            args.Caption = "SELECCIONE LA FECHA";
            args.Prompt = "FECHA DE PROCESO";
            args.DefaultButtonIndex = 0;
            // Initialize a DateEdit editor with custom settings
            DateEdit editor = new DateEdit();
            editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            editor.Properties.Mask.EditMask = "MMMM d, yyyy";
            args.Editor = editor;
            // A default DateEdit value
            args.DefaultResponse = DateTime.Now.Date;
            // Display an Input Box with the custom editor
            var result = XtraInputBox.Show(args);
            if (result != null)
            {
                var res = await dbH.EliminarHorasProcesadas(((System.DateTime)result).Date);
                if (res)
                    lbl.Caption = $"SE ELIMNARON {dbH.Id} REGISTROS DE LA FECHA DE PROCESO {((System.DateTime)result):d}";
            }

        }

        private void barButtonItemQuitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("DESEA ELIMINAR ESTOS REGISTROS?", "ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (gridViewMarcacion.GetSelectedRows().Count() > 0)
                {
                    var idArr = new List<int>();

                    foreach (int rowHandle in gridViewMarcacion.GetSelectedRows())
                        if (rowHandle >= 0)
                            idArr.Add((gridViewMarcacion.GetRow(rowHandle) as Model.HoraReloj).Id);

                    idArr.ForEach(f =>
                            LstHoraTrajadas.Remove(LstHoraTrajadas.SingleOrDefault(s => s.Id == f)));

                    int i = 0;
                    LstHoraTrajadas.ToList().ForEach(f => f.Id = i++);
                }
            }
        }

        private void barButtonItemBuscarFecha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new DevExpress.XtraReports.UI.XtraReport();
            report.LoadLayout("Reportes\\Planilla\\ColaboradoresHoras.repx");

            for (int i = 0; i < report.Parameters.Count; i++)
            {
                if (report.Parameters[i].Name == "prmIdEmpresa")
                    report.Parameters["prmIdEmpresa"].Value = Settings.Default.DIdEmpresa;

                if (report.Parameters[i].Name == "prmDesde")
                        report.Parameters["prmDesde"].Value = (DateTime)barEditItemPrmDesde.EditValue;

                if (report.Parameters[i].Name == "prmHasta")
                    report.Parameters["prmHasta"].Value = (DateTime)barEditItemPrmHasta.EditValue;
            }
            var printTool3 = new DevExpress.XtraReports.UI.ReportPrintTool(report, true);

            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "HORAS TRABJADAS";
            printTool3.ShowPreview();
        }

        private void barButtonItemImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControlResumenHorario.ShowPrintPreview();
        }
    }
}