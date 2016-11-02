using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Siro.F.D
{
    public partial class ShowCuentas : DevExpress.XtraEditors.XtraForm
    {
        public ShowCuentas()
        {
            InitializeComponent();
        }

        private void ShowCuentas_Load(object sender, EventArgs e)
        {
            var control = new Controller.Contabilidad().CuentasMaestras(Principal.Bariables.IdEmpresa.Id).OrderBy(o=>o.Text).ToList();
            cuentasBindingSource.DataSource = control;

            var formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            var iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet { ValueType = FormatConditionValueType.Number, };

            var lstIcons = new List<FormatConditionIconSetIcon>();
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_1.png", Value = 1, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_3.png", Value = 2, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "TrafficLights23_2.png", Value = 3, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_1.png", Value = 4, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_2.png", Value = 5, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "Symbols23_3.png", Value = 6, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });
            lstIcons.Add(new FormatConditionIconSetIcon { PredefinedName = "RedToBlack4_4.png", Value = 9, ValueComparison = FormatConditionComparisonType.GreaterOrEqual });

            iconSet.Icons.AddRange(lstIcons);
            gridView1.FormatRules.Add(new DevExpress.XtraGrid.GridFormatRule { Rule = formatConditionRuleIconSet, ColumnApplyTo = null, Column = colTipo });
        }

        public int Id { get; set; }

        public string Cuenta { get; set; }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Model.Cuentas;
            Id = int.Parse(row.Id.ToString());
            Cuenta = row.Text.ToString();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PrintDialog();

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Id != 0)
                this.Close();
        }
    }
}