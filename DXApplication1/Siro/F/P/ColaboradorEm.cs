using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siro.F.P
{
    public partial class ColaboradorEm : DevExpress.XtraEditors.XtraForm
    {
        List<Colaboradores> LstColaborador = new List<Colaboradores>();
        List<Colaboradores> LstColaborador2 = new List<Colaboradores>();
        BindingList<HistorialHoras> LstHistorialHoras = new BindingList<HistorialHoras>();
        public ColaboradorEm()
        {
            InitializeComponent();
        }
        private void ColaboradorEm_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(() => FillList1(), () => FillList2());
            colaboradorBindingSource.DataSource = LstColaborador;
            this.Text += string.Format(" [{0}]",Settings.Default.DEmpresa);
            gridControlHistorialHorario.DataSource = LstHistorialHoras;
        }
        private void FillList1()
        {
            using (var db = new slPlanilla())
            {
                db.EstadosColaborador.ToList().ForEach(f => 
                    this.IdEstadoColaboradorComboBoxEdit.Properties.Items.Add(T.Item(f.IdEstadoColaborador, f.EstadoColaborador)));
                db.ContratosColaborador.ToList().ForEach(f => 
                    this.IdContratoColaboradorCmb.Properties.Items.Add(T.Item(f.IdContratoColaborador, f.ContratoColaborador)));
                db.Departamentos.ToList().ForEach(f => 
                    this.IdDepartamentoCmb.Properties.Items.Add(T.Item(f.Departamento, f.IdDepartamento)));
                db.Posiciones.OrderBy(o=> o.Posicion).ToList().ForEach(f => 
                    this.IdPosicionComboBoxEdit.Properties.Items.Add(T.Item(f.IdPosicion, f.Posicion)));
                db.Acredores.OrderBy(o => o.Acredor).ToList().ForEach(f => 
                    this.repositoryItemImageComboBoxAcredor.Items.Add(T.Item(f.Acredor, f.IdAcredor)));
            }
        }
        private void FillList2()
        {
            LstColaborador = new Controller.Colaborador().ListaColaboradores(false, Settings.Default.DIdEmpresa);
            LstColaborador2 = new Controller.Colaborador().ListaColaboradores(Settings.Default.DIdEmpresa);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }
        private void LimpiarActividades()
        {
            lblMsg.Caption = "";
            var currentColaborador = colaboradorBindingSource.Current as Colaboradores; if (currentColaborador != null)
            if (currentColaborador != null)
            {
                if (currentColaborador.IdEstadoColaborador == 2)
                {
                    lblMsg.Caption = "Colaborador Esta Inactivo";
                    this.Colaborador1TextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
                }
                else
                    this.Colaborador1TextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
        }
        private void btnAdelante_Click(object sender, EventArgs e)
        {
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
        }
        private void btnfirst_Click(object sender, EventArgs e)
        {
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
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
            gridViewDeduccciones.ActiveFilterString = filter;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var row = colaboradorBindingSource.Current as Colaboradores;
            var frm = new F.P.AgregarHoras(row.IdColaborador);
            frm.ShowDialog(this);
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
        }
        private void btnCalcularVacaciones_Click(object sender, EventArgs e)
        {
            var rowCol = colaboradorBindingSource.Current as Colaboradores;
            var lst = new List<Model.TiposCalculos>();
            lst = new Controller.Colaborador().CalculosVacaciones(rowCol.IdColaborador, true);
            tiposCalculosBindingSource.DataSource = lst;

            vacacionbindingSource.AddNew();
            var row = new Model.Vacacion();
            decimal bruto = lst.Where(w => w.Tipo == "Vacaciones").Sum(s => s.Monto) ?? 0;
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

        private void tabbedControlGroupColaborador_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            var row = colaboradorBindingSource.Current as Colaboradores;
            switch (e.Page.Name)
            {
                case "layoutControlGroupHistorialHorario":
                    LstHistorialHoras.Clear();
                    new Controller.Colaborador().LstHistorialHoras(row.IdColaborador).ToList().ForEach(f => LstHistorialHoras.Add(f));
                break;
                default:
                break;
            }
        }

        private void gridViewHistorialHorario_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var db = new Controller.Colaborador();
            var rowColaborador = colaboradorBindingSource.Current as Colaboradores;
            var row = e.Row as HistorialHoras;
            if (row.IdColaborador == null)
                row.IdColaborador = rowColaborador.IdColaborador;
            if (db.Guardar(row))
            {
                lblMsg.Caption = "Se agrego historial de horas correctamente";
                row.IdHorario = db.NuevoId??0;
            }
            else
            {
                lblMsg.Caption = $"Error al tratar de agregar la hora {db.MSG}";
            }
        }

        private void gridViewHistorialHorario_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            var row = e.Row as HistorialHoras;
            if(LstHistorialHoras.Where(w=> w.Mes.Value.Year == row.Mes.Value.Year && w.Mes.Value.Month == row.Mes.Value.Month && w.IdHorario != 0 ).Any() && row.IdHorario ==0)
            {
                e.Valid = false;
                e.ErrorText = "Ya existe este registro de horas";
                lblMsg.Caption = "Ya existe este registro de horas";
            }
            if(row.Entrada == null || row.Salida == null || row.Mes==null)
            {
                e.Valid = false;
                e.ErrorText = "NO SE PUEDE DEJAR ALGUN CAMPO EN BLANCO";
                lblMsg.Caption = "NO SE PUEDE DEJAR ALGUN CAMPO EN BLANCO";
            }
        }

        private void gridViewDeduccciones_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var db = new Controller.Colaborador();
            var deduciones = deduccionesBindingSource.Current as Siro.Model.Deduccion;
            var row = e.Row as Siro.Model.Deduccion;

            if (db.Guardar(row))
            {
                lblMsg.Caption = "Se agrego historial de horas correctamente";
                row.IdDeduccion = db.NuevoId ?? 0;
            }
            else
            {
                lblMsg.Caption = $"Error al tratar de agregar la hora {db.MSG}";
            }
        }

        private void gridViewDeduccciones_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (XtraMessageBox.Show("Esta seguro que desea modificar este registro!!", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Valid = false;
                e.ErrorText = "No se va a realizar la modificacion";
            }
        }

        private void barButtonItemNuevoColaborador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colaboradorBindingSource.AddNew();
            (colaboradorBindingSource.Current as Colaboradores).FechaIngreso = DateTime.Now;
            (colaboradorBindingSource.Current as Colaboradores).IdEstadoColaborador = 1;
            (colaboradorBindingSource.Current as Colaboradores).IdEmpresa = Settings.Default.DIdEmpresa;
        }

        private void barButtonItemGuardarDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItemAlInicio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colaboradorBindingSource.MoveFirst();
            LimpiarActividades();
        }

        private void barButtonItemAtras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colaboradorBindingSource.MovePrevious();
            LimpiarActividades();
        }

        private void barButtonItemAdelante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colaboradorBindingSource.MoveNext();
            LimpiarActividades();
        }

        private void barButtonItemAlFinal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            colaboradorBindingSource.MoveLast();
            LimpiarActividades();
        }

        private void barButtonItembuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barEditItemColaboradores.EditValue != null && int.TryParse(barEditItemColaboradores.EditValue.ToString(), out int idColaborador))
            {
                int newPos = 0, oldPos = colaboradorBindingSource.Position;
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
                if (entro)
                    colaboradorBindingSource.Position = newPos;
                else
                    colaboradorBindingSource.Position = oldPos;
            }
            LimpiarActividades();
        }

        private void barButtonItemVacaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LstColaborador = new Controller.Colaborador().ListaColaboradores(true, Settings.Default.DIdEmpresa);
            colaboradorBindingSource.DataSource = LstColaborador;
        }

        private void repositoryItemHyperLinkEditEditarHora_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Seguro Que Desea Modificar Hora Selecionada!!", "Mensaje De Alerta", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var row = movimientoColaboradorBindingSource.Current as Siro.Model.MovimientoColaborador;
                var rowColaborador = colaboradorBindingSource.Current as Colaboradores;
                var col = new Controller.Colaborador();
                var frm = new F.P.AgregarHoras(rowColaborador.IdColaborador);
                frm.MovimientoColaborador = row;
                frm.ShowDialog(this);
                movimientoColaboradorBindingSource.DataSource = new Controller.Colaborador().MovimentoColaboradores(rowColaborador);
            }
        }
    }
}