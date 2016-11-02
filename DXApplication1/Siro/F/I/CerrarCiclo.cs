using System;

namespace Siro.F.I
{
    public partial class CerrarCiclo : DevExpress.XtraEditors.XtraForm
    {
        public CerrarCiclo()
        {
            InitializeComponent();
        }

        int idSilo = 0;
        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int.TryParse(searchLookUpEdit1.EditValue.ToString(), out idSilo);
            var eje= new Controller.RA();
            var res = eje.ValoresAlmacenaje(idSilo);
            if(res != null)
                bindingSource1.DataSource = res;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var r = almacenesBindingSource.Current as VValoresAlmacenaje;
            var eje = new Controller.RA();
            if(r == null)
            {
                lblMsg.Caption = "No Existe Ciclo Producción Por Cerrar";
                return;
            }
            var entidad = new CicloAlmacenaje
            {
                CostoTotal = r.Costo,
                IdAlmacen = idSilo,
                LLenadoDesde = r.FechaLLenadoDesde,
                LLenadoHasta = r.FechaLLenadoHasta,
                PorcentajeEnteroE = r.PorcentajeEnteroE,
                PorcentajeQuebradoE = r.PorcentajeQuebradoE,
                PorcentajeEnteroF = r.PorcentajeEnteroF,
                PorcentajeQuebradoF = r.PorcentajeQuebradoF,
                RendimientoEstimado = r.RendimientoE,
                RendimientoFinal = r.RendimientoF,
                TotalBruto = r.TotalBruto,
                TotalNeto = r.TotalNeto,
                TotalPilado = r.TotalPilado,
                VaciadoDesde = r.FechaPiladoDesde,
                VaciadoHasta = r.FechaPiladoHasta
            };
            eje.Guardar(entidad);
        }

        private void CerrarCiclo_Load(object sender, EventArgs e)
        {
            var lst = new Controller.Lst();
            almacenesBindingSource.DataSource = lst.AlmacenesProduccion;
        }
    }
}