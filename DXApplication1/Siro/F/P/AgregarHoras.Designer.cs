namespace Siro.F.P
{
    partial class AgregarHoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarHoras));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.factoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcionFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(355, 180);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEdit1
            // 
            this.dateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "FechaProceso", true));
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(95, 38);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit1.MenuManager = this.barManager1;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(248, 22);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 34;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Siro.HorasTrabajadas);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.lblMsg,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barStaticItemFecha,
            this.barStaticItemEmpresa});
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblMsg)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lblMsg
            // 
            this.lblMsg.Id = 1;
            this.lblMsg.Name = "lblMsg";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(355, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 180);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(355, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 180);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(355, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 180);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Nuevo Cliente";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Ocultar Panel Edición";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Mostrar Panel Edición";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barStaticItemFecha
            // 
            this.barStaticItemFecha.Id = 4;
            this.barStaticItemFecha.Name = "barStaticItemFecha";
            // 
            // barStaticItemEmpresa
            // 
            this.barStaticItemEmpresa.Id = 5;
            this.barStaticItemEmpresa.Name = "barStaticItemEmpresa";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(147, 90);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(196, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 33;
            this.simpleButton1.Text = "Guardar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "HoraTrabajada", true));
            this.textEdit1.Location = new System.Drawing.Point(95, 64);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(248, 22);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 32;
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IdFactor", true));
            this.searchLookUpEdit1.EditValue = "Seleccione Tipo Hora";
            this.searchLookUpEdit1.Location = new System.Drawing.Point(95, 12);
            this.searchLookUpEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.DataSource = this.factoresBindingSource;
            this.searchLookUpEdit1.Properties.DisplayMember = "DescripcionFactor";
            this.searchLookUpEdit1.Properties.PopupView = this.gridView1;
            this.searchLookUpEdit1.Properties.ValueMember = "IdFactor";
            this.searchLookUpEdit1.Size = new System.Drawing.Size(248, 22);
            this.searchLookUpEdit1.StyleController = this.layoutControl1;
            this.searchLookUpEdit1.TabIndex = 30;
            // 
            // factoresBindingSource
            // 
            this.factoresBindingSource.DataSource = typeof(Siro.Model.Factor);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcionFactor,
            this.colFactor1,
            this.colTipoFactor});
            this.gridView1.DetailHeight = 431;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDescripcionFactor
            // 
            this.colDescripcionFactor.Caption = "Tipo Dia";
            this.colDescripcionFactor.FieldName = "DescripcionFactor";
            this.colDescripcionFactor.MinWidth = 23;
            this.colDescripcionFactor.Name = "colDescripcionFactor";
            this.colDescripcionFactor.Visible = true;
            this.colDescripcionFactor.VisibleIndex = 0;
            this.colDescripcionFactor.Width = 87;
            // 
            // colFactor1
            // 
            this.colFactor1.Caption = "Factor";
            this.colFactor1.FieldName = "Factor1";
            this.colFactor1.MinWidth = 23;
            this.colFactor1.Name = "colFactor1";
            this.colFactor1.Visible = true;
            this.colFactor1.VisibleIndex = 1;
            this.colFactor1.Width = 87;
            // 
            // colTipoFactor
            // 
            this.colTipoFactor.FieldName = "TipoFactor";
            this.colTipoFactor.MinWidth = 23;
            this.colTipoFactor.Name = "colTipoFactor";
            this.colTipoFactor.Visible = true;
            this.colTipoFactor.VisibleIndex = 2;
            this.colTipoFactor.Width = 87;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(355, 180);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.searchLookUpEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(335, 26);
            this.layoutControlItem1.Text = "Tipo De Hora:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(335, 26);
            this.layoutControlItem3.Text = "Cantidad:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton1;
            this.layoutControlItem4.Location = new System.Drawing.Point(135, 78);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 82);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 78);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(135, 82);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(335, 26);
            this.layoutControlItem5.Text = "Feha:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 16);
            // 
            // AgregarHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 207);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AgregarHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AgregarHoras";
            this.Load += new System.EventHandler(this.AgregarHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private System.Windows.Forms.BindingSource factoresBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lblMsg;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFecha;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionFactor;
        private DevExpress.XtraGrid.Columns.GridColumn colFactor1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoFactor;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}