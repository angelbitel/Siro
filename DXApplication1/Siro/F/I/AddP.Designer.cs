namespace Siro.F.I
{
    partial class AddP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddP));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.provedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidProvedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEsProductor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.btnBackWard = new DevExpress.XtraBars.BarButtonItem();
            this.btnFordware = new DevExpress.XtraBars.BarButtonItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuadar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.provedoresBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(430, 253);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // provedoresBindingSource
            // 
            this.provedoresBindingSource.DataSource = typeof(Siro.provedores);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidProvedor,
            this.colProveedor,
            this.colEsProductor});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colidProvedor
            // 
            this.colidProvedor.Caption = "Id";
            this.colidProvedor.FieldName = "idProvedor";
            this.colidProvedor.Name = "colidProvedor";
            this.colidProvedor.Visible = true;
            this.colidProvedor.VisibleIndex = 0;
            this.colidProvedor.Width = 30;
            // 
            // colProveedor
            // 
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 1;
            this.colProveedor.Width = 379;
            // 
            // colEsProductor
            // 
            this.colEsProductor.FieldName = "EsProductor";
            this.colEsProductor.Name = "colEsProductor";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar1});
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
            this.barStaticItemEmpresa,
            this.btnBackWard,
            this.btnFordware,
            this.btnNew,
            this.btnGuadar,
            this.btnGuardar,
            this.barButtonItem5});
            this.barManager1.MaxItemId = 12;
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
            this.lblMsg.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardar)});
            this.bar1.Text = "Custom 2";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "barButtonItem4";
            this.btnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Glyph")));
            this.btnGuardar.Id = 10;
            this.btnGuardar.Name = "btnGuardar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(430, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 297);
            this.barDockControlBottom.Size = new System.Drawing.Size(430, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 253);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(430, 44);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 253);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Nuevo Cliente";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Ocultar Panel Edición";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Mostrar Panel Edición";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barStaticItemFecha
            // 
            this.barStaticItemFecha.Id = 4;
            this.barStaticItemFecha.Name = "barStaticItemFecha";
            this.barStaticItemFecha.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemEmpresa
            // 
            this.barStaticItemEmpresa.Id = 5;
            this.barStaticItemEmpresa.Name = "barStaticItemEmpresa";
            this.barStaticItemEmpresa.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnBackWard
            // 
            this.btnBackWard.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBackWard.Glyph")));
            this.btnBackWard.Id = 6;
            this.btnBackWard.Name = "btnBackWard";
            // 
            // btnFordware
            // 
            this.btnFordware.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFordware.Glyph")));
            this.btnFordware.Id = 7;
            this.btnFordware.Name = "btnFordware";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Nuevo";
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 8;
            this.btnNew.Name = "btnNew";
            // 
            // btnGuadar
            // 
            this.btnGuadar.Caption = "Guardar";
            this.btnGuadar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuadar.Glyph")));
            this.btnGuadar.Id = 9;
            this.btnGuadar.Name = "btnGuadar";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 11;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // AddP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 323);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddP";
            this.Text = "Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
        private DevExpress.XtraBars.BarButtonItem btnBackWard;
        private DevExpress.XtraBars.BarButtonItem btnFordware;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnGuadar;
        private System.Windows.Forms.BindingSource provedoresBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidProvedor;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colEsProductor;
    }
}