using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.D
{
    public partial class EditarCuentas : DevExpress.XtraEditors.XtraForm
    {
        public EditarCuentas() => InitializeComponent();
        internal BindingList<Model.MaestroCuentas> Maestro = new BindingList<Model.MaestroCuentas>();
        internal List<Model.MaestroCuentas> LstMaestro { get; set; }
        internal List<Model.MaestroContable> LstCuentas { get; set; }
        internal bool PasarInformacion { get; set; }
        private void EditarCuentas_Load(object sender, EventArgs e)
        {
            var cont = new Controller.VMContabilidad();
            Maestro.Add(new Model.MaestroCuentas { });
            bindingSource1.DataSource = Maestro;
            new Controller.AutoSugestTextBox(ref textEdit2, LstCuentas.Select(s => s.Text).ToList());
            Principal.LstCuentas.ForEach(f =>
            {
                cmbNivel1.Properties.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel2.Properties.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel3.Properties.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
                cmbNivel4.Properties.Items.Add(T.Item(f.IdMaestroCuenta, $"{f.CuentaContable} => {f.Text}"));
            });
        }
        private void EditarCuentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            var row = bindingSource1.Current as Model.MaestroContable;
            if (row != null)
            {
                if (row.CuentaContable != null && row.Text != null)
                    PasarInformacion = true;
                else
                    PasarInformacion = false;
            }
        }
        Model.Notificacion validar()
        {
            var not = new Model.Notificacion();
            var row = bindingSource1.Current as Model.MaestroCuentas;
            int cntChek = 0;
            if (row.EsBanco ?? false)
                cntChek++;
            if (row.EsCLiente)
                cntChek++;
            if (row.EsProveedor)
                cntChek++;
            if (cntChek > 1)
            {
                not.Existe = true;
                not.Titulo = "LA CUENTA SOLO PUEDE SER UNO DE ESTOS ATRIBUTOS A LA VEZ ES BANCO, ES CLIENTE O ES PROVEEDOR";
            }
            if (string.IsNullOrEmpty(row.Cuenta))
            {
                not.Existe = true;
                not.Titulo = "DEBE ESCRIBIR UN NUMERO DE CUENTA";
            }
            if (string.IsNullOrEmpty(row.Codigo))
            {
                not.Existe = true;
                not.Titulo = "DEBE ESCRIBIR UN NOMBRE PARA LA CUENTA";
            }
            return not;
        }
        private string Cuenta(Model.MaestroCuentas cuenta, int nivel)
        {
            string cuen = string.Empty;
            switch (nivel)
            {
                case 1:
                    var l1 = LstMaestro.Where(s => s.Codigo1 == cuenta.Codigo.Substring(0, 1)).ToList();
                    if (l1.Count > 0)
                        cuen = l1[0].Nivel1;
                    break;
                case 2:
                    if (cuenta.Codigo.Length >= 2)
                    {
                        var l2 = LstMaestro.Where(s => s.Codigo2 == cuenta.Codigo.Substring(0, 2)).ToList();
                        if (l2.Count > 0)
                            cuen = l2[0].Nivel2;
                    }
                    break;
                case 3:
                    if (cuenta.Codigo.Length >= 3)
                    {
                        var l3 = LstMaestro.Where(s => s.Codigo3 == cuenta.Codigo.Substring(0, 3)).ToList();
                        if (l3.Count > 0)
                            cuen = l3[0].Nivel3;
                    }
                    break;
                case 4:
                    if (cuenta.Codigo.Length >= 5)
                    {
                        var l4 = LstMaestro.Where(s => s.Codigo4 == cuenta.Codigo.Substring(0, 5)).ToList();
                        if (l4.Count > 0)
                            cuen = l4[0].Nivel4;
                    }
                    break;
            }
            return cuen;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var db = new Controller.VMContabilidad();
            var row = bindingSource1.Current as Model.MaestroCuentas;
            var val = validar();
            if (val.Existe == true)
            {
                lblLay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lbl.Text = val.Titulo;
                return;
            }
            if (db.Guardar(row))
            {
                row.IdMaestroCuenta = db.Id;
                if (row.C4 == null)
                {
                    row.C4 = db.Id;
                    Maestro[0].C4 = db.Id;
                }
                PasarInformacion = true;
                this.Close();
            }
            else
            {
                lblLay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lbl.Text = "NO SE PUEDE CREAR LA CUENTA...............";
            }

        }
        string cuentaVieja { get; set; }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var db = new Controller.VMContabilidad();
            var row = bindingSource1.Current as Model.MaestroCuentas;
            if (row != null)
            {
                var notifi = db.ExisteNuevaCuenta(textEdit1.Text);
                if (notifi.Existe)
                {
                    lblLay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lbl.Text = $"{notifi.Titulo} : {notifi.Mensaje}";
                }
                else
                {
                    lblLay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lbl.Text = "";
                }
            }
        }
        private void textEdit1_Leave(object sender, EventArgs e)
        {
            if (LstCuentas.Where(w => w.CuentaContable.Trim() == textEdit1.Text.Trim()).Count() > 0)
            {
                lblLay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lbl.Text = "ESTE NUMERO DE CUENTA YA EXISTE EN EL MAESTRO DE CUENTA";
            }
        }
    }
}