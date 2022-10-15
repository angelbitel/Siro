using System;
using System.Collections.Generic;

namespace Siro.F.P
{
    public partial class AgregarDeduccion : DevExpress.XtraEditors.XtraForm
    {
        private List<Colaboradores> LstColaborador = new List<Colaboradores>();
        public AgregarDeduccion( List<Colaboradores> lst)
        {
            LstColaborador = lst;
            InitializeComponent();
            if (lst.Count == 1)
            {
                this.searchLookUpEdit1.Enabled = false;
            }
        }

        private void AgregarDeduccion_Load(object sender, EventArgs e)
        {
            colaboradorBindingSource.DataSource = LstColaborador;
            bindingSource1.AddNew();
            if (LstColaborador.Count == 1)
            {
                searchLookUpEdit1.EditValue = LstColaborador[0].IdColaborador;
                (bindingSource1.Current as Deducciones).IdColaborador = LstColaborador[0].IdColaborador;
            }
            var result = new Controller.Acredor().LstAcredores();
            this.acredoresBindingSource.DataSource = result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var row = bindingSource1.Current as Deducciones;
            var save = new Controller.Colaborador();
            bool rest = save.Guardar(row);
            if (rest)
            {
                this.Close();
            }
            else
            {
                lblMsg.Caption = save.MSG;
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxEditTipo.Text == "Descuento Unico")
            {
                this.searchLookUpEdit2.Enabled = false;
                textEdit3.Enabled = false;
                textEdit4.Enabled = false;
                textEdit1.Enabled = true;
            }
            else if (comboBoxEditTipo.Text == "Recurrente CXC")
            {
                this.searchLookUpEdit2.Enabled = false;
                textEdit3.Enabled = true;
                textEdit4.Enabled = true;
                textEdit1.Enabled = false;
            }
            else
            {
                this.searchLookUpEdit2.Enabled = true;
                textEdit3.Enabled = true;
                textEdit4.Enabled = true;
                textEdit1.Enabled = false;
            }
        }
    }
}