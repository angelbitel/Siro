using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.P
{
    public partial class ColaboradorEm : DevExpress.XtraEditors.XtraForm
    {
        public ColaboradorEm()
        {
            InitializeComponent();
        }
        List<Colaboradores> LstColaborador = new List<Colaboradores>();
        List<Colaboradores> LstColaborador2 = new List<Colaboradores>();
        private void ColaboradorEm_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(() => FillList1(), () => FillList2());
            colaboradorBindingSource.DataSource = LstColaborador;
            this.Text += string.Format(" [{0}]",Settings.Default.DEmpresa);
        }
        private void FillList1()
        {
            using (var db = new slPlanilla())
            {
                db.EstadosColaborador.ToList().ForEach(f =>
                    {
                        ImageComboBoxItem item = new ImageComboBoxItem
                        {
                            Value = f.IdEstadoColaborador,
                            Description = f.EstadoColaborador
                        };
                        this.IdEstadoColaboradorComboBoxEdit.Properties.Items.Add(item);
                    });
                db.ContratosColaborador.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdContratoColaborador,
                        Description = f.ContratoColaborador
                    };
                    this.IdContratoColaboradorCmb.Properties.Items.Add(item);
                });
                db.Departamentos.ToList().ForEach(f =>
                {
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdDepartamento,
                        Description = f.Departamento
                    };
                    this.IdDepartamentoCmb.Properties.Items.Add(item);
                });
                db.Posiciones.ToList().ForEach(f => {                    
                    ImageComboBoxItem item = new ImageComboBoxItem
                    {
                        Value = f.IdPosicion,
                        Description = f.Posicion
                    };
                    this.IdPosicionComboBoxEdit.Properties.Items.Add(item);                    
                });
            }
        }
        private void FillList2()
        {
            LstColaborador = new Controller.Colaborador().ListaColaboradores(false, Settings.Default.DIdEmpresa);
            LstColaborador2 = new Controller.Colaborador().ListaColaboradores(Settings.Default.DIdEmpresa);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue.ToString() != "")
            {
                int idColaborador = int.Parse(searchLookUpEdit1.EditValue.ToString());
                int newPos=0, oldPos = colaboradorBindingSource.Position;
                bool entro = false;
                for (int i = 0; i <= LstColaborador.Count(); i++)
                {
                    if ((colaboradorBindingSource.Current as Colaboradores).IdColaborador == idColaborador)
                    {
                        entro = true;
                        newPos = colaboradorBindingSource.Position;
                        break;
                    }
                    colaboradorBindingSource.Position = i;
                }
                if(entro )
                    colaboradorBindingSource.Position=newPos;
                else
                    colaboradorBindingSource.Position=oldPos;
            }
            LimpiarActividades();
        }
        private void LimpiarActividades()
        {
            lblMsg.Caption = "";
            if((colaboradorBindingSource.Current as Colaboradores).IdEstadoColaborador==2)
            {
                lblMsg.Caption = "Colaborador Esta Inactivo";
                this.Colaborador1TextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            }
            else
                this.Colaborador1TextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Settings.Default.DIdEmpresa == 0)
            {
                lblMsg.Caption = "Seleccione una empresa!";
                new D.Periodo().ShowDialog(this);
            }
            if (Settings.Default.DIdEmpresa != 0)
            {
                var row = colaboradorBindingSource.Current as Colaboradores;
                var save = new Controller.Colaborador();
                if (row.IdEmpresa == 0)
                    row.IdEmpresa = Settings.Default.DIdEmpresa;
                save.Guardar(row);
                (colaboradorBindingSource.Current as Colaboradores).IdColaborador = (save.NuevoId ?? 0);
                lblMsg.Caption = "Los Datos Fueron Guardados Correctamente";
            }
            else
            {
                lblMsg.Caption = "Debe Seleccionar una empresa!!!";
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            colaboradorBindingSource.AddNew();
            (colaboradorBindingSource.Current as Colaboradores).FechaIngreso = DateTime.Now;
            (colaboradorBindingSource.Current as Colaboradores).IdEstadoColaborador = 1;
            (colaboradorBindingSource.Current as Colaboradores).IdEmpresa = Settings.Default.DIdEmpresa;
        }
        private void btnAdelante_Click(object sender, EventArgs e)
        {
            colaboradorBindingSource.MovePrevious();
            LimpiarActividades();
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            colaboradorBindingSource.MoveNext();
            LimpiarActividades();
        }
        private void btnfirst_Click(object sender, EventArgs e)
        {
            colaboradorBindingSource.MoveFirst();
            LimpiarActividades();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            colaboradorBindingSource.MoveLast();
            LimpiarActividades();
        }
        private void DeduccionesColaborador()
        {
            var row = colaboradorBindingSource.Current as Colaboradores;
            var col=new Controller.Colaborador();
            deduccionesBindingSource.DataSource = col.DeduccionesColaboradores(row.IdColaborador);
            deduccionesBindingSource.Filter = string.Format("[Año]={0} AND [Mes]={1} AND [Dia]> {2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day > 15 ? 15 : 1);
            movimientoColaboradorBindingSource.DataSource = col.MovimentoColaboradores(row);
            ItemForColaborador1.Text = string.Format("Colaborador [{0}]", row.IdColaborador);
            planillaColaboradorBindingSource.DataSource = col.Planilla(row.IdColaborador);

            GridView View = gridView1;
            bool expanded = View.GetRowExpanded(View.FocusedRowHandle);
            View.SetRowExpanded(View.FocusedRowHandle, !expanded);
        }
        private void btnNuevaDeduccion_Click(object sender, EventArgs e)
        {
             var row = colaboradorBindingSource.Current as Colaboradores;
             new P.AgregarDeduccion(LstColaborador.Where(w => w.IdColaborador == row.IdColaborador).ToList()).ShowDialog(this);
             deduccionesBindingSource.DataSource = new Controller.Colaborador().DeduccionesColaboradores(row.IdColaborador);
        }
        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            string filter = string.Empty;
            switch (e.Node.Name)
            {
                case "NdF1":
                    filter = "[TipoDeduccion]= 'Educativo'";
                    break;
                case "NdF2":
                    filter = "[TipoDeduccion]= 'Social'";
                    break;
                case "NdF3":
                    filter = "[TipoDeduccion]= 'Renta'";
                    break;
                case "Nd2":
                    filter = "[TipoDeduccion] != 'Salario Bruto' AND [TipoDeduccion] != 'Renta' AND [TipoDeduccion] != 'Social' AND [TipoDeduccion] != 'Educativo'";
                    break;
                case "Nd3":
                    filter = string.Format("[Mes]= {0}", DateTime.Now.Month);
                    break;
                case "Nd4":
                    filter = string.Format("[Año]={0} AND [Mes]={1} AND [Dia]> {2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day > 15?15:1);
                    break;
                case "Nd5":
                    filter = string.Format("[Año]= {0}", DateTime.Now.Year);
                    break;
                case "Nd6":
                    filter = "[TipoDeduccion]= 'Salario Bruto'";
                    break;
                default:
                    break;
            }
            gridView2.ActiveFilterString = filter;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var row = colaboradorBindingSource.Current as Colaboradores;
            new F.P.AgregarHoras(row.IdColaborador).ShowDialog(this);
            movimientoColaboradorBindingSource.DataSource = new Controller.Colaborador().MovimentoColaboradores(row);
        }
        private void btnAgrgarVacaciones_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Mensaje De Alerta", "Seguro Que Desea Realizar La Operación", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var vac = vacacionbindingSource.DataSource as Model.Vacacion;

                var save = new Controller.Colaborador();
                save.Guardar(vac);
                lblMsg.Caption = "Los Datos Fueron Guardados Correctamente";
            }
        }
        private void btnVacaciones_Click(object sender, EventArgs e)
        {
            LstColaborador = new Controller.Colaborador().ListaColaboradores(true, Settings.Default.DIdEmpresa);
            colaboradorBindingSource.DataSource = LstColaborador;
        }
        private void btnCalcularVacaciones_Click(object sender, EventArgs e)
        {
            var rowCol = colaboradorBindingSource.Current as Colaboradores;
            var lst = new List<Model.TiposCalculos>();
            lst = new Controller.Colaborador().CalculosVacaciones(rowCol.IdColaborador, true);
            tiposCalculosBindingSource.DataSource = lst;

            vacacionbindingSource.AddNew();
            var row = new Model.Vacacion();
            decimal bruto = lst.Where(w=> w.Monto>0).Sum(s => s.Monto)??0;
            bruto= (bruto)/11;
            decimal desc = lst.Where(w=> w.Monto<0).Sum(s => s.Monto)??0;
            row.Brutas = bruto;
            row.Descuentos = desc*-1;
            row.Desde = DateTime.Now;
            row.Hasta = DateTime.Now.AddDays(15);
            row.IdColaborador = rowCol.IdColaborador;

            var descGob = new Controller.DescuentosGobierno();
            row.ISR = Convert.ToDecimal(descGob.Renta(Convert.ToDouble(bruto), rowCol.Dependientes ?? 0));
            row.Social = Convert.ToDecimal(descGob.SeguroSocial(Convert.ToDouble(bruto)));
            row.Educativo = Convert.ToDecimal(descGob.SeguroEducativo(Convert.ToDouble(bruto)));
            row.FechaIngreso = DateTime.Now;
            row.Neto = (row.Brutas) - ((row.Descuentos)+(row.Educativo)+(row.Social)+(row.ISR));
            vacacionbindingSource.DataSource = row;
            btnAgrgarVacaciones.Enabled = true;
        }
        private void btnVerVacacion_Click(object sender, EventArgs e)
        {
            GenerarReporte("Vacacion");
        }
        private void GenerarReporte(string reporte)
        {
            XtraReport report = new XtraReport();
            report.LoadLayout(string.Format(@"Reportes\\Planilla\\{0}.repx",reporte));
            var row = colaboradorBindingSource.Current as Colaboradores;
            report.Parameters[0].Value = row.IdColaborador;
            var printTool3 = new ReportPrintTool(report);
            printTool3.PreviewForm.MdiParent = this.MdiParent;
            printTool3.PreviewForm.Text = "Vacacciones de " + row.Colaborador;
            printTool3.ShowPreview();
        }
        private void btnCalcularLiquidacion_Click(object sender, EventArgs e)
        {
            decimal isr=0, noReintegro=0, liquidacion=0;
            var rowCol = colaboradorBindingSource.Current as Colaboradores;
            var cola = new Controller.Colaborador();
            var row = cola.CalculosLiquidacion(rowCol.IdColaborador)[0];
            liquidacion = row.Antigudad+row.DecimoProporcinal+row.VacacionesProporcionales+row.Indemnizacion-(row.SeguroDecimoProporcinal+row.SeguroDecimoProporcinal+row.Social+row.Educativo);
            var liq = new RegistroLiquidaciones
            {
                Antiguedad = row.Antigudad,
                DecimoProporcional = row.DecimoProporcinal,
                Desde = rowCol.FechaIngreso,
                FechaIngreso = DateTime.Now,
                Hasta = DateTime.Now,
                Educativo = row.Social,
                IdColaborador = rowCol.IdColaborador,
                Indemnizacion = row.Indemnizacion,
                ISR = isr,
                NoReintegro = noReintegro,
                Social = row.Social+row.SeguroDecimoProporcinal,
                Liquidacion = liquidacion,
                VacacionesProporcionales = row.VacacionesProporcionales
            };
            LiquidacionBindingSource.DataSource = liq;
            btnProcesarLiquidacion.Enabled = true;
        }
        private void btnVerLiquidacion_Click(object sender, EventArgs e)
        {
            GenerarReporte("Liquidacion");
        }
        private void btnProcesarLiquidacion_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Seguro Que Desea Realizar La Operación", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var liq = LiquidacionBindingSource.DataSource as RegistroLiquidaciones;

                var save = new Controller.Colaborador();
                save.Guardar(liq);
                lblMsg.Caption = "Los Datos Fueron Guardados Correctamente";
            }
        }
        private void colaboradorBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            DeduccionesColaborador();
            try
            {
                if ((vacacionbindingSource.DataSource as Model.Vacacion)!= null)
                    vacacionbindingSource.DataSource = new Model.Vacacion();

                if ((tiposCalculosbindingSource2.DataSource as Model.TiposCalculos) != null)
                    tiposCalculosbindingSource2.DataSource = new Model.TiposCalculos();

                if ((LiquidacionBindingSource.DataSource as RegistroLiquidaciones) != null)
                    LiquidacionBindingSource.DataSource = new RegistroLiquidaciones();

                if ((tiposCalculosBindingSource.DataSource as Model.TiposCalculos) != null)
                    tiposCalculosBindingSource.DataSource = new Model.TiposCalculos();
                
                if ((planillaColaboradorBindingSource.DataSource as PlanillaColaborador) != null)
                    tiposCalculosBindingSource.DataSource = new PlanillaColaborador();
            }
            catch(Exception ex)
            { 
                lblMsg.Caption = ex.Message; 
            }
        }
        private void Colaborador1TextEdit_Click(object sender, EventArgs e)
        {
            if ((colaboradorBindingSource.Current as Colaboradores) == null)
            {
                colaboradorBindingSource.AddNew();
                (colaboradorBindingSource.Current as Colaboradores).FechaIngreso = DateTime.Now;
                (colaboradorBindingSource.Current as Colaboradores).IdEstadoColaborador = 1;
                (colaboradorBindingSource.Current as Colaboradores).IdEmpresa = Settings.Default.DIdEmpresa;
            }
        }
        private void btnQuitarDeduccion_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Estas Seguro Que Deseas Eliminar La Deduccion", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var liq = deduccionesBindingSource.Current as Model.Deduccion;

                var save = new Controller.Colaborador();
                if(liq == null)
                {
                    lblMsg.Caption = "Seleccione un registro.....................";
                    return;
                }
                if (save.Eliminar(liq.IdDeduccion))
                {
                    lblMsg.Caption = "Se Elimino la deducción correctamente!!....";
                    deduccionesBindingSource.Remove(liq);
                }
                else
                    lblMsg.Caption = save.MSG;
            }
        }
        private void btnEliminarHora_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Seguro Que Desea Eliminar Hora Selecionada!!", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var row = movimientoColaboradorBindingSource.Current as Siro.Model.MovimientoColaborador;
                if (row == null)
                {
                    lblMsg.Caption = "Seleccione un registro.....................";
                    return;
                }
                var col = new Controller.Colaborador();
                if (col.EliminarHora(row.IdHoraTrabjada))
                {
                    lblMsg.Caption = "Se Elimino la deducción correctamente!!....";
                    movimientoColaboradorBindingSource.Remove(row);
                }
                else
                    lblMsg.Caption = col.MSG;
            }
        }
        private void gridView1_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {

        }
    }
}