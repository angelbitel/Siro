using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Siro.Controller;
using Siro.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class MaestrosCuentas : DevExpress.XtraEditors.XtraForm
    {
        List<CuentasMaestras> lst = new List<CuentasMaestras>();
        CuentasM controller = new CuentasM();
        private TreeListNode Nodo { get; set; }
        int IdMaestroCuenta { get; set; }
        public MaestrosCuentas()
        {
            InitializeComponent();
            ListaMaestra();
        }

        private void btnRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListaMaestra();
        }
        public void ListaMaestra()
        {
            var lstResult = controller.LstCuentas(Principal.Bariables.IdEmpresa.Id);
            treeListCuenta.DataSource = lstResult;
            lst = lstResult;
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

            treeListCuenta.FormatRules.Add(new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule { Rule = formatConditionRuleIconSet, ColumnApplyTo = null, Column = colTipo });
        }
        private void OrdenarLista()
        {
            TreeListNode n = Nodo;
            var lstp = lst.OrderBy(o => o.Id).ToList();
            IdMaestroCuenta = int.Parse(n.GetValue("IdMaestroCuenta").ToString());
            treeListCuenta.DataSource = lstp;
            var nodeActual = int.Parse(n.GetValue("IdMaestroCuenta").ToString());
            lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual).Nivel = treeListCuenta.FindNodeByID(n.Id).Level;
            var res = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
            var cuenta = new MaestroCuentas
            {
                IdEmpresa = res.IdEmpresa,
                IdMaestroCuenta = res.IdMaestroCuenta,
                Nivel = res.Nivel,
                ParentID = res.ParentID,
                Text = res.Text,
                Tipo= res.Tipo
            };
            controller.AgregarCuenta(cuenta);

            treeListCuenta.FindNodeByFieldValue("IdMaestroCuenta", IdMaestroCuenta).Selected = true;
        }

        private void btnEliminarCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("ESta Seguro Que Desea Eliminar Cuenta?", "Eliminar Cuenta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Nodo.Nodes.Count() == 0)
                {
                    var IdMaestroCuenta = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
                    var eje=controller.Eliminar(IdMaestroCuenta);
                    if (eje)
                        lblMsg.Caption = "Cuenta Eliminada!!!";
                    else
                        lblMsg.Caption = controller.MSG;
                }
            }
        }

        private void btnAgregarCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nodo = treeListCuenta.FocusedNode;
            var IdMaestroCuenta = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            var nodeActual = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            var IdEmpresa = int.Parse(Nodo.GetValue("IdEmpresa").ToString());
            var Id = int.Parse(Nodo.GetValue("Id").ToString());
            var Tipo = int.Parse(Nodo.GetValue("Tipo").ToString());

            var nNodo = new MaestroCuentas
            {
                Text = txtCuenta.Text,
                ParentID = IdMaestroCuenta,
                IdEmpresa = IdEmpresa,
                Nivel = Nodo.Level + 1,
                Tipo = Tipo,
                Id = controller.MaxId(Principal.Bariables.IdEmpresa.Id)+1,
                Habilitar = true
            };

            if (nNodo.Text.Trim() == string.Empty)
            {
                lblMsg.Caption = "Escriba Nombre El Nombre De La Cuenta......";
                return;
            }
            int idParent = controller.AgregarCuenta(nNodo);
            controller.Empresa(Principal.Bariables.IdEmpresa.Id).ForEach(f =>
            { 
                if(XtraMessageBox.Show("Quieres Agregar esta cuenta a la empresa: " + f.Empresa, "Agregar Cuenta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var nNodoE = new MaestroCuentas
                    {
                        Text = txtCuenta.Text,
                        ParentID = controller.IdParent(nNodo.ParentID, f.IdEmpresa),
                        IdEmpresa = f.IdEmpresa,
                        Nivel = Nodo.Level + 1,
                        Tipo = Tipo,
                        Id = nNodo.Id,
                        Habilitar = true
                    };
                    controller.AgregarCuenta(nNodoE);
                }
            });
            var nNodoL = new CuentasMaestras
            {
                Text = txtCuenta.Text,
                ParentID = IdMaestroCuenta,
                IdEmpresa = IdEmpresa,
                Nivel = Nodo.Level + 1,
                Id = Id + 1,
                IdMaestroCuenta = idParent
            };
            lst.Add(nNodoL);
        }

        private void btnSubir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nodo = treeListCuenta.FocusedNode;
            var nodeActual = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            if (Nodo.PrevNode == null) return;
            var nodeAnterior = int.Parse(Nodo.PrevNode.GetValue("IdMaestroCuenta").ToString());

            var rowActual = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
            var rowAnterior = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeAnterior);
            if (rowAnterior != null)
            {
                int at = rowAnterior.Id, a = rowActual.Id;
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowActual.IdMaestroCuenta).Id = at;
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowAnterior.IdMaestroCuenta).Id = a;
                OrdenarLista();
            }
        }

        private void treeListCuenta_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            Nodo = e.Node;
        }

        private void btnBajar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nodo = treeListCuenta.FocusedNode;
            var nodeActual = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            var nodeAnterior = int.Parse(Nodo.NextNode.GetValue("IdMaestroCuenta").ToString());

            var rowActual = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
            var rowAnterior = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeAnterior);
            if (rowAnterior != null)
            {
                int at = rowAnterior.Id, a = rowActual.Id;
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowActual.IdMaestroCuenta).Id = at;
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowAnterior.IdMaestroCuenta).Id = a;
                OrdenarLista();
            }
        }

        private void btnAtras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nodo = treeListCuenta.FocusedNode;
            var nodeActual = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            var nodeAnterior = int.Parse(Nodo.ParentNode.GetValue("IdMaestroCuenta").ToString());

            var rowActual = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
            var rowAnterior = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeAnterior);
            if (rowAnterior != null)
            {
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowActual.IdMaestroCuenta).ParentID = rowAnterior.ParentID;
                controller.ActualizarPadrent(rowActual.IdMaestroCuenta, rowAnterior.ParentID);
                //OrdenarLista();
            }
        }
        private void btnAdelante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var nodeActual = int.Parse(Nodo.GetValue("IdMaestroCuenta").ToString());
            var nodeAnterior = int.Parse(Nodo.PrevNode.GetValue("IdMaestroCuenta").ToString());

            var rowActual = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
            var rowAnterior = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeAnterior);
            if (rowAnterior != null)
            {
                lst.SingleOrDefault(s => s.IdMaestroCuenta == rowActual.IdMaestroCuenta).ParentID = rowAnterior.IdMaestroCuenta;
                OrdenarLista();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeListCuenta.NodesIterator.DoOperation((n) =>
            {
                var nodeActual = int.Parse(n.GetValue("IdMaestroCuenta").ToString());
                var f = lst.SingleOrDefault(s => s.IdMaestroCuenta == nodeActual);
                var nNodo = new MaestroCuentas
                {
                    Text = f.Text,
                    ParentID = f.ParentID,
                    IdEmpresa = f.IdEmpresa,
                    Nivel = n.Level,
                    IdMaestroCuenta = f.IdMaestroCuenta
                };
                controller.AgregarCuenta(nNodo);
            });
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeListCuenta.ShowPrintPreview();
        }

        private void treeListCuenta_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            var nodo = e.Node;
            var f = lst.SingleOrDefault(s => s.IdMaestroCuenta == int.Parse(nodo.GetValue(colIdMaestroCuenta).ToString()));
            var nNodo = new MaestroCuentas
            {
                Text = nodo.GetValue(colText).ToString(),
                ParentID = f.ParentID,
                IdEmpresa = f.IdEmpresa,
                Nivel = f.Nivel,
                IdMaestroCuenta = int.Parse(nodo.GetValue(colIdMaestroCuenta).ToString()),
                Tipo = f.Tipo,
                Habilitar=true,
                Id = f.Id
            };
            controller.AgregarCuenta(nNodo);
        }
    }
}