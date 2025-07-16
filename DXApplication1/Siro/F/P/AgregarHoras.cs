using Siro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace Siro.F.P
{
    public partial class AgregarHoras : DevExpress.XtraEditors.XtraForm
    {
        BindingList<HorasTrabajadas> LstHoraTrabjada = new BindingList<HorasTrabajadas>();
        private int IdColaborador { get; set; }
        public Model.MovimientoColaborador MovimientoColaborador { get; internal set; }

        public AgregarHoras(int? idColaborador)
        {
            IdColaborador = idColaborador??0;
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = bindingSource1.Current as HorasTrabajadas;
            var save = new Controller.Colaborador();
            
            row.Año = row.Fecha.Value.Year;
            row.Año = row.Fecha.Value.Month;
            row.FechaProceso = Principal.Bariables.PeridoContable;

            if (row.Fecha.Value.Day > 15)
                row.Quincena = 2;
            else
                row.Quincena = 1;

            row.IdColaborador = IdColaborador;
            row.Procesado = false;
            row.IdEmpresa = Settings.Default.DIdEmpresa;

            bool rest = false;
            if (MovimientoColaborador == null)
                rest = save.Guardar(row);
            else
                rest = save.ModificarHora(row);
            if (rest)
            {
                this.Close();
            }
            else
            {
                lblMsg.Caption = save.MSG;
            }
        }

        private void AgregarHoras_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = LstHoraTrabjada;
            var row = new HorasTrabajadas();
            row.FechaProceso = DateTime.Now;
            row.IdColaborador = IdColaborador;
            if(MovimientoColaborador != null)
            {
                row.IdHoraTrabjada = MovimientoColaborador.IdHoraTrabjada;
                row.Fecha = MovimientoColaborador.Fecha;
                row.FechaProceso = MovimientoColaborador.FechaProceso;
                row.IdFactor = MovimientoColaborador.IdFactor;
                row.HoraTrabajada = MovimientoColaborador.Cantidad;
            }
            LstHoraTrabjada.Add(row);

            using (var db = new slPlanilla())
            {
                var lst = new List<Model.Factor>();
                db.Factores.ToList().ForEach(f=>lst.Add(new Model.Factor { IdFactor = f.IdFactor, TipoFactor= f.TiposFactor.Factor, Factor1 = f.Factor, DescripcionFactor = f.DescripcionFactor }));
                factoresBindingSource.DataSource = lst;
            }
        }
    }
}