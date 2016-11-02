namespace Siro.F.D
{
    partial class FormaPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaPago));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdFormaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbFormaPago = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colIdCertificadoEmitido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colFormaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSecuenciaTransaccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAgregar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnTotal = new DevExpress.XtraBars.BarButtonItem();
            this.btnPagado = new DevExpress.XtraBars.BarButtonItem();
            this.btnRegresar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbFormaPago,
            this.calcEdit,
            this.repositoryItemSpinEdit1});
            this.gridControl1.Size = new System.Drawing.Size(538, 208);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 10;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdFormaPago,
            this.colIdCertificadoEmitido,
            this.colMonto,
            this.colFormaPago,
            this.colSecuenciaTransaccion,
            this.colRestante});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 10;
            // 
            // colIdFormaPago
            // 
            this.colIdFormaPago.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 15F);
            this.colIdFormaPago.AppearanceHeader.Options.UseFont = true;
            this.colIdFormaPago.Caption = "Forma De Pago";
            this.colIdFormaPago.ColumnEdit = this.cmbFormaPago;
            this.colIdFormaPago.FieldName = "IdFormaPago";
            this.colIdFormaPago.Name = "colIdFormaPago";
            this.colIdFormaPago.Visible = true;
            this.colIdFormaPago.VisibleIndex = 0;
            this.colIdFormaPago.Width = 240;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.cmbFormaPago.Appearance.Options.UseFont = true;
            this.cmbFormaPago.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormaPago.AppearanceDropDown.Options.UseFont = true;
            this.cmbFormaPago.AutoHeight = false;
            this.cmbFormaPago.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFormaPago.Name = "cmbFormaPago";
            // 
            // colIdCertificadoEmitido
            // 
            this.colIdCertificadoEmitido.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 15F);
            this.colIdCertificadoEmitido.AppearanceHeader.Options.UseFont = true;
            this.colIdCertificadoEmitido.Caption = "# Certificado";
            this.colIdCertificadoEmitido.FieldName = "IdCertificadoEmitido";
            this.colIdCertificadoEmitido.Name = "colIdCertificadoEmitido";
            this.colIdCertificadoEmitido.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colIdCertificadoEmitido.OptionsFilter.AllowAutoFilter = false;
            this.colIdCertificadoEmitido.OptionsFilter.AllowFilter = false;
            this.colIdCertificadoEmitido.Width = 135;
            // 
            // colMonto
            // 
            this.colMonto.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 15F);
            this.colMonto.AppearanceHeader.Options.UseFont = true;
            this.colMonto.ColumnEdit = this.calcEdit;
            this.colMonto.DisplayFormat.FormatString = "{0:c2}";
            this.colMonto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonto.FieldName = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Monto", "{0:c2}")});
            this.colMonto.Visible = true;
            this.colMonto.VisibleIndex = 1;
            this.colMonto.Width = 134;
            // 
            // calcEdit
            // 
            this.calcEdit.AutoHeight = false;
            this.calcEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEdit.Name = "calcEdit";
            // 
            // colFormaPago
            // 
            this.colFormaPago.Caption = "gridColumn1";
            this.colFormaPago.FieldName = "FormaPago";
            this.colFormaPago.Name = "colFormaPago";
            // 
            // colSecuenciaTransaccion
            // 
            this.colSecuenciaTransaccion.Caption = "gridColumn1";
            this.colSecuenciaTransaccion.FieldName = "SecuenciaTransaccion";
            this.colSecuenciaTransaccion.Name = "colSecuenciaTransaccion";
            // 
            // colRestante
            // 
            this.colRestante.Caption = "gridColumn1";
            this.colRestante.FieldName = "Restante";
            this.colRestante.Name = "colRestante";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnGuardar,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btnAgregar,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.btnTotal,
            this.barButtonItem9,
            this.btnPagado,
            this.barButtonItem10,
            this.btnRegresar});
            this.barManager1.MaxItemId = 13;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Herramientas";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAgregar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardar)});
            this.bar1.Text = "Herramientas";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Caption = "Nueva forma de pago";
            this.btnAgregar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Glyph")));
            this.btnAgregar.Id = 4;
            this.btnAgregar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAgregar.LargeGlyph")));
            this.btnAgregar.Name = "btnAgregar";
            toolTipTitleItem1.Text = "Nuevo";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Para poder agrgar una froma de pago adicional se tiene que presionar este boton. " +
    "";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnAgregar.SuperTip = superToolTip1;
            this.btnAgregar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregar_ItemClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar Cambios";
            this.btnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Glyph")));
            this.btnGuardar.Id = 1;
            this.btnGuardar.Name = "btnGuardar";
            toolTipTitleItem2.Text = "Guardar";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Guardar cambios realizados en los clientes. Si no se presiona este boton cuando r" +
    "ealice algun cambio en cualquier cliente, el mismo no se realizara.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnGuardar.SuperTip = superToolTip2;
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bar3.BarAppearance.Disabled.Options.UseFont = true;
            this.bar3.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 15F);
            this.bar3.BarAppearance.Hovered.Options.UseFont = true;
            this.bar3.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.bar3.BarAppearance.Normal.Options.UseFont = true;
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTotal),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPagado),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRegresar)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // btnTotal
            // 
            this.btnTotal.Id = 8;
            this.btnTotal.Name = "btnTotal";
            // 
            // btnPagado
            // 
            this.btnPagado.Id = 10;
            this.btnPagado.Name = "btnPagado";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Id = 12;
            this.btnRegresar.Name = "btnRegresar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(538, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 252);
            this.barDockControlBottom.Size = new System.Drawing.Size(538, 35);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 208);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(538, 44);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 208);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Eliminar Cliente";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            toolTipTitleItem3.Text = "Eliminar";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Se tiene que seleccionar el cliente y se preciona el boton de eliminar, posterior" +
    "mente a eso se debe de guardar el cambio.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.barButtonItem3.SuperTip = superToolTip3;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Deshaser";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            toolTipTitleItem4.Text = "Deshacer";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Si realizo algun cambio a una fila o si agrego una nueva esto se puede deshacer c" +
    "on este boton. Solo si no se a precionado el boton de guardar.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.barButtonItem4.SuperTip = superToolTip4;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Imprimir";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Cerrar";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Total:";
            this.barButtonItem8.Id = 7;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Pagado:";
            this.barButtonItem9.Id = 9;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Id = 11;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // FormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 287);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccione Forma Pago";
            this.Load += new System.EventHandler(this.FormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdFormaPago;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbFormaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCertificadoEmitido;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calcEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colFormaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colSecuenciaTransaccion;
        private DevExpress.XtraGrid.Columns.GridColumn colRestante;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAgregar;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnTotal;
        private DevExpress.XtraBars.BarButtonItem btnPagado;
        private DevExpress.XtraBars.BarButtonItem btnRegresar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
    }
}