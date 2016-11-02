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

namespace Siro.F.D
{
    public partial class ShowEmpleados : DevExpress.XtraEditors.XtraForm
    {
        public ShowEmpleados()
        {
            InitializeComponent();
        }
        public int IdColaborador { get; set; }
        public string Colaborador { get; set; }
        List<Colaboradores> lstClientes = new List<Colaboradores>();
        private void CargarDatosClientes()
        {
            lstClientes.Clear();
            new Controller.Colaborador().ListaColaboradores(false,Principal.Bariables.IdEmpresa.Id).OrderBy(o=> o.IdColaborador).ToList().ForEach(f =>
            {
                lstClientes.Add(new Colaboradores
                {
                   IdColaborador = f.IdColaborador,
                    Colaborador = f.Colaborador,
                     IdentificacionPersonal = f.IdentificacionPersonal
                });
            });
        }
        bool fromLoad { get; set; }
        private void ShowEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatosClientes();
            clientesBindingSource.DataSource = lstClientes;
            this.gluProveedor.Focus();
            fromLoad = true;
        }

        private void gluProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdColaborador = int.Parse(gluProveedor.EditValue.ToString());
            Colaborador = gluProveedor.Text;
        }
        private void gluProveedor_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (!fromLoad)
                    this.Close();
            }
            else
                fromLoad = false;
        }
    }
}