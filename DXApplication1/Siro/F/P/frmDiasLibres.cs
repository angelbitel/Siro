using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.P
{
    public partial class frmDiasLibres : DevExpress.XtraEditors.XtraForm
    {
        internal BindingList<Model.DiasFeriados> LstDiasFeriados { get; set; }
        internal bool Aceptar { get; set; }
        public frmDiasLibres()
        {
            InitializeComponent();
        }

        private void frmDiasLibres_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = LstDiasFeriados;
        }

        private void simpleButtonAceptar_Click(object sender, EventArgs e)
        {
            Aceptar = true;
            this.Close();
        }

        private void simpleButtonQuitarFecha_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRow() is Model.DiasFeriados row)
            {
                LstDiasFeriados.Remove(row);
            }
        }
    }
}