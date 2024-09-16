using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet.Export;
using Siro.Properties;

namespace Siro.F.P
{
    public partial class ArchivosHoras : DevExpress.XtraEditors.XtraForm
    {
        private List<Model.ConfiguracionHoras> Columnas { get; set; }
        private BindingList<Model.HoraReloj> LstHoraTrajadas = new BindingList<Model.HoraReloj>();
        private List<Colaboradores> LstColaboradores = new List<Colaboradores>();
        private readonly Controller.Horas dbH;
        public ArchivosHoras()
        {
            InitializeComponent();
            dbH = new Controller.Horas();
        }

        private void barButtonItemProcesar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void ArchivosHoras_Load(object sender, EventArgs e)
        {
            Columnas = dbH.LstColumnaOrigen;
            LstColaboradores = new Controller.Colaborador().ListaColaboradores(Settings.Default.DIdEmpresa);
            gridControl1.DataSource = LstHoraTrajadas;
        }

        private void barButtonItemVerificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                datos.Add(hora);
            }
            datos.Where(w => w.Habilitar == true).ToList().ForEach(f => LstHoraTrajadas.Add(f));
            LstHoraTrajadas.ToList().ForEach(f =>
            {
                var colaborador = LstColaboradores.SingleOrDefault(s => s.Reloj == f.User);
                if (colaborador != null)
                {
                    f.Colaborador = colaborador.Colaborador;
                    f.Delay = GetTimeAttended(colaborador.HoraEntrada ?? new TimeSpan(8, 0, 0), f.TimeConverter);
                }
            });
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
            TimeSpan timeAttended = endTime - startTime;
            return timeAttended;
        }

        private void spreadsheetControl1_DocumentLoaded(object sender, EventArgs e)
        {
            //for (int i = 0; i < currentTable.Columns.Count; i++)
            //{
            //    for (int j = 0; j < currentTable.Rows.Count; j++)
            //    {
            //        workSheet.Cells[j, i].Value = currentTable.Rows[j][i].ToString();
            //    }
            //}
        }
    }
}