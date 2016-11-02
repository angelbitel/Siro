namespace Siro.F
{
    partial class Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Producto));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLstPrecio = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxEmpresa = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colIdCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxCategoria = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colProductos1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditCodBar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoReorden = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCodBar)).BeginInit();
            this.SuspendLayout();
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
            this.lblMsg,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barStaticItemFecha,
            this.barStaticItemEmpresa,
            this.btnLstPrecio});
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLstPrecio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Eliminar Producto";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Imprimir";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnLstPrecio
            // 
            this.btnLstPrecio.Caption = "ListaPrecio";
            this.btnLstPrecio.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLstPrecio.Glyph")));
            this.btnLstPrecio.Id = 6;
            this.btnLstPrecio.Name = "btnLstPrecio";
            this.btnLstPrecio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLstPrecio_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblMsg),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFecha),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemEmpresa)});
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(729, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 625);
            this.barDockControlBottom.Size = new System.Drawing.Size(729, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 581);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(729, 44);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 581);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Mayorizar";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBoxEmpresa,
            this.repositoryItemImageComboBoxCategoria,
            this.repositoryItemTextEditCodBar});
            this.gridControl1.Size = new System.Drawing.Size(729, 581);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataSource = typeof(Siro.Productos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdProducto,
            this.colIdEmpresa,
            this.colIdCategoria,
            this.colProductos1,
            this.colCodigoBarras,
            this.colCantidad,
            this.colPrecioCompra,
            this.colPrecioVenta,
            this.colPuntoReorden});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colIdProducto
            // 
            this.colIdProducto.FieldName = "IdProducto";
            this.colIdProducto.Name = "colIdProducto";
            this.colIdProducto.OptionsColumn.AllowEdit = false;
            this.colIdProducto.Visible = true;
            this.colIdProducto.VisibleIndex = 0;
            // 
            // colIdEmpresa
            // 
            this.colIdEmpresa.ColumnEdit = this.repositoryItemImageComboBoxEmpresa;
            this.colIdEmpresa.FieldName = "IdEmpresa";
            this.colIdEmpresa.Name = "colIdEmpresa";
            // 
            // repositoryItemImageComboBoxEmpresa
            // 
            this.repositoryItemImageComboBoxEmpresa.AutoHeight = false;
            this.repositoryItemImageComboBoxEmpresa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxEmpresa.Name = "repositoryItemImageComboBoxEmpresa";
            // 
            // colIdCategoria
            // 
            this.colIdCategoria.ColumnEdit = this.repositoryItemImageComboBoxCategoria;
            this.colIdCategoria.FieldName = "IdCategoria";
            this.colIdCategoria.Name = "colIdCategoria";
            this.colIdCategoria.Visible = true;
            this.colIdCategoria.VisibleIndex = 1;
            // 
            // repositoryItemImageComboBoxCategoria
            // 
            this.repositoryItemImageComboBoxCategoria.AutoHeight = false;
            this.repositoryItemImageComboBoxCategoria.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxCategoria.Name = "repositoryItemImageComboBoxCategoria";
            // 
            // colProductos1
            // 
            this.colProductos1.Caption = "Producto";
            this.colProductos1.FieldName = "Productos1";
            this.colProductos1.Name = "colProductos1";
            this.colProductos1.Visible = true;
            this.colProductos1.VisibleIndex = 2;
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.ColumnEdit = this.repositoryItemTextEditCodBar;
            this.colCodigoBarras.FieldName = "CodigoBarras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.Visible = true;
            this.colCodigoBarras.VisibleIndex = 3;
            // 
            // repositoryItemTextEditCodBar
            // 
            this.repositoryItemTextEditCodBar.AutoHeight = false;
            this.repositoryItemTextEditCodBar.Name = "repositoryItemTextEditCodBar";
            this.repositoryItemTextEditCodBar.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 4;
            // 
            // colPrecioCompra
            // 
            this.colPrecioCompra.DisplayFormat.FormatString = "{0:0.00}";
            this.colPrecioCompra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioCompra.FieldName = "PrecioCompra";
            this.colPrecioCompra.Name = "colPrecioCompra";
            this.colPrecioCompra.Visible = true;
            this.colPrecioCompra.VisibleIndex = 5;
            // 
            // colPrecioVenta
            // 
            this.colPrecioVenta.DisplayFormat.FormatString = "{0:0.00}";
            this.colPrecioVenta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioVenta.FieldName = "PrecioVenta";
            this.colPrecioVenta.Name = "colPrecioVenta";
            this.colPrecioVenta.Visible = true;
            this.colPrecioVenta.VisibleIndex = 6;
            // 
            // colPuntoReorden
            // 
            this.colPuntoReorden.FieldName = "PuntoReorden";
            this.colPuntoReorden.Name = "colPuntoReorden";
            this.colPuntoReorden.Visible = true;
            this.colPuntoReorden.VisibleIndex = 7;
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 651);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Producto";
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCodBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lblMsg;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFecha;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpresa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colIdEmpresa;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCategoria;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colProductos1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoReorden;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditCodBar;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnLstPrecio;
    }
}