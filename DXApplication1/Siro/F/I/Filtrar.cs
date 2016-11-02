using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;

namespace Siro.F.I
{
    public partial class Filtrar : DevExpress.XtraEditors.XtraForm
    {
        public Filtrar()
        {
            InitializeComponent();
            QuitarColumnas();
        }
        public string Filtro { get; set; }
        private void filterControl1_FilterChanged(object sender, FilterChangedEventArgs e)
        {
        }

        private void QuitarColumnas()
        {
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdRecibido"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdUser"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdTipoArroz"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdProveedor"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdTipoFlete"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdConductor"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdEmpresa"]);
            this.filterControl1.FilterColumns.Remove(filterControl1.FilterColumns["IdProductor"]);
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            CriteriaOperator op = filterControl1.FilterCriteria;
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetMsSqlWhere(op);
            Filtro = filterString;
            this.Close();
        }
    }
}