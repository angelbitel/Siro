using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
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
        bool EsLoad { get; set; }
        private void SelectorCuentas_Load(object sender, EventArgs e)
        {
            var control = new Controller.Contabilidad().CuentasMaestras(Principal.Bariables.IdEmpresa.Id);
            cuentasBindingSource.DataSource = control;
            EsLoad = true;
            
            var formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            var iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet { ValueType = FormatConditionValueType.Number, };

            var lstIcons = new List<FormatConditionIconSetIcon>();
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_1.png", Value = 1, ValueComparison= FormatConditionComparisonType.GreaterOrEqual});
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_3.png", Value = 2, ValueComparison= FormatConditionComparisonType.GreaterOrEqual});
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_2.png", Value = 3, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_1.png", Value = 4, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_2.png", Value = 5, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_3.png", Value = 6, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "RedToBlack4_4.png", Value = 9, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });

            iconSet.Icons.AddRange(lstIcons);

            treeList1.FormatRules.Add(new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule { Rule = formatConditionRuleIconSet, ColumnApplyTo = null, Column = colTipo });
        }
        public int Id { get; set; }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            Id = int.Parse(e.Node.GetValue("Id").ToString());
            Cuenta = e.Node.GetValue("Text").ToString();
        }
        public string Cuenta { get; set; }

        private void treeList1_MouseEnter(object sender, EventArgs e)
        {
            EsLoad = false;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.ShowPrintPreview();
        }

        private void treeList1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Id != 0)
                this.Close();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (Id != 0)
                this.Close();
        }
    }
}