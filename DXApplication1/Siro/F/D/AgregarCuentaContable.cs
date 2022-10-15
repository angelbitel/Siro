using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Siro.F.D
{
    public partial class AgregarCuentaContable : DevExpress.XtraEditors.XtraForm
    {
        private List<Model.MaestroCuentas> lstCuentas = new List<Model.MaestroCuentas>();

        public AgregarCuentaContable() => InitializeComponent();
        internal Model.MaestroCuentas Maestro { get; set; }
        internal bool PasarInformacion { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = MaestroCuentaBindingSource.Current as Model.MaestroCuentas;
            if (lstCuentas.Where(w => w.Codigo.Trim() == row.Codigo.Trim()).Count() > 0)
            {
                MessageBox.Show("ESTA CUENTA YA EXISTE, NO SE PUEDE AGREGAR");
                return;
            }
            if (lstCuentas.Where(w => w.Cuenta == row.Cuenta.Trim()).Count() > 0)
            {
                MessageBox.Show("ESTE NOMBRE DE CUENTA YA EXISTE, NO SE PUEDE AGREGAR");
                return;
            }

            var db = new Controller.VMContabilidad();
            if (db.Guardar(new MaestroCuentas { CuentaContable = row.Codigo, Text = row.Cuenta }))
            {
                row.IdMaestroCuenta = db.Id;
                var f = new Controller.VMContabilidad().BuscarCuenta(row.IdMaestroCuenta);
                var lstCUentas = db.LstCuentasMadres;
                Cuenta = new Model.Cuentas
                {
                    ParentID = f.ParentID ?? 0,
                    Text = f.CuentaContable,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo ?? 0,
                    Id = f.Id ?? 0,
                    CuentaContable = f.CuentaContable,
                    Nivel = f.Nivel ?? 0,
                    Nivel0 = f.Nivel0,
                    Nivel1 = f.Nivel1,
                    Nivel2 = f.Nivel2,
                    Nivel3 = f.Nivel3,
                    Habilitar = f.Habilitar,
                    SumaResta = f.SumaResta,
                    CuentaMadre = Buscar(f.Tipo ?? 0, lstCUentas)
                };
                MessageBox.Show("CUENTA AGREGADA CORRECTAMETE..!!!!!");
            }
            else
                MessageBox.Show(db.Mensaje);
            this.Close();
        }
        private string Buscar(int tipo, List<VCuentasPrimarias> lst)
        {
            return lst.SingleOrDefault(s => s.Tipo.Equals(tipo)) == null ? "" : lst.SingleOrDefault(s => s.Tipo.Equals(tipo)).Text;
        }
        public Model.Cuentas Cuenta { get; set; }
        private void AgregarCuentaContable_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Maestro.Cuenta != null && Maestro.Codigo != null)
                PasarInformacion = true;
            else
                PasarInformacion = false;
        }

        private void AgregarCuentaContable_Load(object sender, EventArgs e)
        {
            Maestro = new Model.MaestroCuentas { };
            MaestroCuentaBindingSource.DataSource = Maestro;
            new Controller.VMContabilidad().Cuenta.ForEach(f => lstCuentas.Add(f));
        }
    }
}