using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class ShowCuentas : DevExpress.XtraEditors.XtraForm
    {
        public bool HabilitarEdicion { get; set; }
        public ShowCuentas() => InitializeComponent();

        private void ShowCuentas_Load(object sender, EventArgs e)
        {
            if (!HabilitarEdicion)
                barButtonItem11.Enabled = false;
            else
                bar1.Visible = false;
            var control = new Controller.Contabilidad().CuentasMaestras(Principal.Bariables.IdEmpresa.Id).OrderBy(o=>o.Tipo).ThenBy(t=> t.Text).ToList();
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
            new Controller.CuentasM().Padres.ForEach(f => cmbParentId.Items.Add(T.Item(f.IdMaestroCuenta, f.Text)));
        }

        public int Id { get; set; }
        public string Cuenta { get; set; }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as Model.Cuentas;
            Id = int.Parse(row.Id.ToString());
            Cuenta = row.Text.ToString();
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)=> gridView1.PrintDialog();
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Id != 0)
                this.Close();
        }
        bool modificar = false;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!modificar)
            {
                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                modificar = true;
                lblMsg.Caption = "SE PUEDE HABILITAR LA ZONA DE LAS CUENTAS...!!!!";
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.Default;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                modificar = false;
                lblMsg.Caption = "NO SE PUEDE HABILITAR LA ZONA DE LAS CUENTAS...!!!!";
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var r = gridView1.GetFocusedRow() as Model.Cuentas;
            var db = new Controller.CuentasM();
            var fila = new MaestroCuentas
            {
                CuentaContable = r.CuentaContable,
                Id = r.Id,
                IdEmpresa = Principal.Bariables.IdEmpresa.Id,
                Habilitar = r.Habilitar,
                IdMaestroCuenta = r.ID,
                Nivel = r.Nivel,
                Nivel0 = r.Nivel0,
                Nivel1 = r.Nivel1,
                Nivel2 = r.Nivel2,
                Nivel3 = r.Nivel3,
                ParentID = r.ParentID,
                SumaResta = r.SumaResta,
                Text = r.Text,
                Tipo = r.Tipo
            };
            if (db.Guardar(fila))
            {
                lblMsg.Caption = "CUENTA GUARDADA CORRECTAMENTE!......";
            }
            else
            {
                lblMsg.Caption = string.Format("NO SE PUDO GUARDAR LA CUENTA:{0}", arg0: db.Mensaje);
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DialogResult rset = XtraMessageBox.Show("DESEA AGREGAR O CAMBIAR ESTA CUENTA?".ToUpper(), "Alerta", MessageBoxButtons.YesNo);
            if (rset == DialogResult.No)
            {
                e.Valid = false;
                e.ErrorText = "SE CANCELO LA TRANSACCION";
                lblMsg.Caption = "SE CANCELA ACTUALIZACION DE CUENTA!......";
            }
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e) => e.ExceptionMode = ExceptionMode.DisplayError;
    }
}