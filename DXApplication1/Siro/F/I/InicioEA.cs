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

namespace Siro.F.I
{
    public partial class InicioEA : DevExpress.XtraEditors.XtraForm
    {
        public InicioEA()
        {
            InitializeComponent();
        }
        public int IdAlmacen { get; set; }
        public int IdTipoMovimiento { get; set; }
        public Decimal Porcentaje { get; set; }
        public DateTime Fecha { get; set; }
        List<TiposMovimiento> lstTMovimiento = new List<TiposMovimiento>();
        List<Almacenaje> lstAlmacenes = new List<Almacenaje>();

        private void InicioEA_Load(object sender, EventArgs e)
        {
            CrearListas();
            tiposMovimientoBindingSource.DataSource = lstTMovimiento;
            almacenesBindingSource.DataSource = lstAlmacenes;

            var ra = new Controller.RA();
            IdAlmacen = ra.MaxSilo();
            Fecha = Principal.Bariables.PeridoContable;
            dateEdit1.DateTime = Fecha;
            searchLookUpEdit1.EditValue = IdAlmacen;
            searchLookUpEdit2.EditValue = 3;
        }

        private void CrearListas()
        {
            var lst = new Controller.Lst();
            lstTMovimiento = lst.TiposMovimientos;
            lstAlmacenes = lst.AlmacenesProduccion;
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Fecha = dateEdit1.DateTime;
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue != null)
                IdAlmacen = int.Parse(searchLookUpEdit1.EditValue.ToString());
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            IdTipoMovimiento = int.Parse(searchLookUpEdit2.EditValue.ToString());
        }

        private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            decimal o = 0m;
            if (decimal.TryParse(textEdit1.Text, out o))
            {
                Porcentaje = o;
            }
            else
                MessageBox.Show("No se pudo convertir el porcentaje; escriba nuevamente!! ");
        }
    }
}