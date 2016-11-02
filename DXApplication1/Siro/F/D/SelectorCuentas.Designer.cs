namespace Siro.F.D
{
    partial class SelectorCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorCuentas));
            this.colTipo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cuentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colTipo
            // 
            this.colTipo.Caption = "T";
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ToolTip = "Tipo De Cuenta";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 0;
            this.colTipo.Width = 55;
            // 
            // colText
            // 
            this.colText.Caption = "Nombre De Cuenta";
            this.colText.FieldName = "Text";
            this.colText.MinWidth = 32;
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 1;
            this.colText.Width = 488;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTipo,
            this.colText,
            this.colId});
            this.treeList1.DataSource = this.cuentasBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 44);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowIncrementalSearch = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeList1.OptionsFilter.ShowAllValuesInFilterPopup = true;
            this.treeList1.OptionsFind.AllowFindPanel = true;
            this.treeList1.OptionsFind.AlwaysVisible = true;
            this.treeList1.OptionsFind.ShowClearButton = false;
            this.treeList1.OptionsFind.ShowFindButton = false;
            this.treeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
            this.treeList1.Size = new System.Drawing.Size(612, 446);
            this.treeList1.TabIndex = 5;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            this.treeList1.MouseEnter += new System.EventHandler(this.treeList1_MouseEnter);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 2;
            this.colId.Width = 48;
            // 
            // cuentasBindingSource
            // 
            this.cuentasBindingSource.DataSource = typeof(Siro.Model.Cuentas);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barStaticItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.lblMsg,
            this.barStaticItem3,
            this.barToolbarsListItem1,
            this.barButtonItem4,
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barSubItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9});
            this.barManager1.MaxItemId = 17;
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Status bar";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblMsg),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem9, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblMsg
            // 
            this.lblMsg.Id = 4;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Id = 5;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem9.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.barButtonItem9.Caption = "Seleccionar Cuenta";
            this.barButtonItem9.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.Glyph")));
            this.barButtonItem9.Id = 16;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7)});
            this.bar2.Text = "Custom 2";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Imprimir";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 14;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(612, 44);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 490);
            this.barDockControl2.Size = new System.Drawing.Size(612, 44);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 44);
            this.barDockControl3.Size = new System.Drawing.Size(0, 446);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(612, 44);
            this.barDockControl4.Size = new System.Drawing.Size(0, 446);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Periodo";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Mayorizar";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Mayorizar";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "Reportes";
            this.barToolbarsListItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barToolbarsListItem1.Glyph")));
            this.barToolbarsListItem1.Id = 6;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Estado Situación";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Reportes";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 8;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Diario";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Estado Situación";
            this.barButtonItem6.Id = 13;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Diario";
            this.barSubItem2.Id = 9;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Mayorizar";
            this.barSubItem3.Id = 10;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Estado Situación";
            this.barSubItem4.Id = 11;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Seleccionar Cuenta";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 15;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // SelectorCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 534);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectorCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectorCuentas";
            this.Load += new System.EventHandler(this.SelectorCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTipo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colText;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private System.Windows.Forms.BindingSource cuentasBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblMsg;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
    }
}