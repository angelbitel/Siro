using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using Siro.Properties;
using System;
using System.Collections.Generic;

namespace Siro.F.D
{
    public partial class Periodo : DevExpress.XtraEditors.XtraForm
    {
        public Periodo()
        {
            InitializeComponent();
        }

        private void Periodo_Load(object sender, EventArgs e)
        {
            Siro.slEntities dbContext = new Siro.slEntities();
            foreach (var current in (IEnumerable<Empresas>)dbContext.Empresas)
            {
                ImageComboBoxItem item = new ImageComboBoxItem
                {
                    Value = current.IdEmpresa,
                    Description = current.Empresa
                };
                this.imageComboBoxEdit1.Properties.Items.Add(item);
            }
            if(Settings.Default.DFecha.Year > 2015)
                this.dateEdit1.DateTime = Settings.Default.DFecha;
            if (Settings.Default.DIdEmpresa != 0)
                imageComboBoxEdit1.EditValue = Settings.Default.DIdEmpresa;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (imageComboBoxEdit1.EditValue != null)
                Principal.Bariables.IdEmpresa.Id = int.Parse(imageComboBoxEdit1.EditValue.ToString());
            Principal.Bariables.IdEmpresa.Nombre = imageComboBoxEdit1.Text;
            Principal.Bariables.PeridoContable = dateEdit1.DateTime;

            Settings.Default.DEmpresa = Principal.Bariables.IdEmpresa.Nombre;
            Settings.Default.DIdEmpresa = Principal.Bariables.IdEmpresa.Id;
            Settings.Default.DFecha = Principal.Bariables.PeridoContable;

            var prm = new Model.Prmts(Principal.Bariables.IdEmpresa.Id);
            Principal.Bariables.IdCuentaCliente = prm.IdCuentaCliente;
            Principal.Bariables.IdCuentaEmpleado = prm.IdCuentaEmpleado;
            Principal.Bariables.IdCuentaItbm = prm.IdCuentaItbm;
            Principal.Bariables.IdCuentaProveedor = prm.IdCuentaProveedor;
            Principal.Bariables.IdCuentaBanco = prm.IdCuentaBanco;
            Principal.Bariables.IdCaja = prm.IdCaja;
            Principal.Bariables.IdBancoCXC = prm.IdBancoCXC;
            Settings.Default.Save();
            this.Close();
        }

        private void dateEdit1_Popup(object sender, EventArgs e)
        {
            DateEdit edit = sender as DateEdit;
            PopupDateEditForm form = (edit as IPopupControl).PopupWindow as PopupDateEditForm;
            form.Calendar.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.YearInfo;
        }
    }
}