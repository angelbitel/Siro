using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
namespace Siro.F.D
{
    public partial class SelectorCuentas : DevExpress.XtraEditors.XtraForm
    {
        public SelectorCuentas()
        {
            InitializeComponent();
            this.BackColor = Color.Red;
            // Make the background color of form display transparently.
            this.TransparencyKey = BackColor;
        }
        BindingList<Model.Cuentas> lstCuentas = new BindingList<Model.Cuentas>();
        bool EsLoad { get; set; }
        private void SelectorCuentas_Load(object sender, EventArgs e)
        {
            new Controller.Contabilidad().CuentasMaestras().ForEach(f=> lstCuentas.Add(f));
            cuentasBindingSource.DataSource = lstCuentas;
            EsLoad = true;
            
            //var formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            //var iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet { ValueType = FormatConditionValueType.Number};

            //var lstIcons = new List<FormatConditionIconSetIcon>();
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_1.png", Value = 1, ValueComparison= FormatConditionComparisonType.GreaterOrEqual});
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_3.png", Value = 2, ValueComparison= FormatConditionComparisonType.GreaterOrEqual});
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_2.png", Value = 3, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_1.png", Value = 4, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_2.png", Value = 5, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_3.png", Value = 6, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            //lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "RedToBlack4_4.png", Value = 9, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });

            //iconSet.Icons.AddRange(lstIcons);

            //treeList1.FormatRules.Add(new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule { Rule = formatConditionRuleIconSet, ColumnApplyTo = null, Column = colTipo });
        }
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string CuentaContable { get; private set; }
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(CuentaContable))
                this.Close();
        }
        private void linkCuenta_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Model.Cuentas;
            if (row != null)
            {
                Id = row.Id;
                Cuenta = row.Text;
                CuentaContable = row.CuentaContable;
                this.Close();
            }
        }
        public Model.Cuentas MCuenta { get; set; }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new AgregarCuentaContable();
            frm.ShowDialog();
            if (frm.Maestro != null)
            {
                Id = frm.Maestro.IdMaestroCuenta;
                Cuenta = frm.Maestro.Cuenta;
                CuentaContable = frm.Maestro.Codigo;
                MCuenta = frm.Cuenta;
                if(frm.Cuenta != null)
                    lstCuentas.Add(frm.Cuenta);
                this.Close();
            }
        }
    }
}