namespace Siro.F.D
{
    partial class VerCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerCuentas));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vAsientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdAsiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuitar = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.lblDiferencia = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.btnCuentas = new DevExpress.XtraBars.BarButtonItem();
            this.btnLstAsientos = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAsientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vAsientosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(786, 499);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // vAsientosBindingSource
            // 
            this.vAsientosBindingSource.DataSource = typeof(Siro.VAsientos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdAsiento,
            this.colusuario,
            this.colFecha,
            this.colComentario,
            this.colDebito,
            this.colCredito,
            this.colCuenta,
            this.colEntidad});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", null, "(Debito: {0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", null, "(Credito: {0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIdAsiento, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colIdAsiento
            // 
            this.colIdAsiento.Caption = "# Asiento";
            this.colIdAsiento.FieldName = "IdAsiento";
            this.colIdAsiento.Name = "colIdAsiento";
            this.colIdAsiento.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", "{0:0.##}"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", "{0:0.##}")});
            this.colIdAsiento.Visible = true;
            this.colIdAsiento.VisibleIndex = 0;
            // 
            // colusuario
            // 
            this.colusuario.Caption = "Usuario";
            this.colusuario.FieldName = "usuario";
            this.colusuario.Name = "colusuario";
            this.colusuario.Visible = true;
            this.colusuario.VisibleIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            // 
            // colComentario
            // 
            this.colComentario.FieldName = "Comentario";
            this.colComentario.Name = "colComentario";
            this.colComentario.Visible = true;
            this.colComentario.VisibleIndex = 2;
            // 
            // colDebito
            // 
            this.colDebito.FieldName = "Debito";
            this.colDebito.Name = "colDebito";
            this.colDebito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debito", "{0:0.##}")});
            this.colDebito.Visible = true;
            this.colDebito.VisibleIndex = 3;
            // 
            // colCredito
            // 
            this.colCredito.FieldName = "Credito";
            this.colCredito.Name = "colCredito";
            this.colCredito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credito", "{0:0.##}")});
            this.colCredito.Visible = true;
            this.colCredito.VisibleIndex = 4;
            // 
            // colCuenta
            // 
            this.colCuenta.FieldName = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 5;
            // 
            // colEntidad
            // 
            this.colEntidad.FieldName = "Entidad";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.Visible = true;
            this.colEntidad.VisibleIndex = 6;
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
            this.btnQuitar,
            this.lblMsg,
            this.btnGuardar,
            this.barStaticItemEmpresa,
            this.barToolbarsListItem1,
            this.barStaticItem1,
            this.lblDiferencia,
            this.barStaticItemFecha,
            this.btnCuentas,
            this.btnLstAsientos});
            this.barManager1.MaxItemId = 19;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuardar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnQuitar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar1.Text = "Tools";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Modificar Asiento";
            this.btnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Glyph")));
            this.btnGuardar.Id = 2;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Caption = "Eliminar Asiento";
            this.btnQuitar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Glyph")));
            this.btnQuitar.Id = 0;
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuitar_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 14;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemEmpresa),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemFecha),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblDiferencia)});
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
            // barStaticItemEmpresa
            // 
            this.barStaticItemEmpresa.Id = 5;
            this.barStaticItemEmpresa.Name = "barStaticItemEmpresa";
            this.barStaticItemEmpresa.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemFecha
            // 
            this.barStaticItemFecha.Id = 16;
            this.barStaticItemFecha.Name = "barStaticItemFecha";
            this.barStaticItemFecha.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Id = 15;
            this.lblDiferencia.ItemAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.lblDiferencia.ItemAppearance.Normal.Options.UseBackColor = true;
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(786, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 543);
            this.barDockControlBottom.Size = new System.Drawing.Size(786, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 499);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(786, 44);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 499);
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "Reportes";
            this.barToolbarsListItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barToolbarsListItem1.Glyph")));
            this.barToolbarsListItem1.Id = 6;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // btnCuentas
            // 
            this.btnCuentas.Caption = "Lista De Cuentas";
            this.btnCuentas.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCuentas.Glyph")));
            this.btnCuentas.Id = 17;
            this.btnCuentas.Name = "btnCuentas";
            // 
            // btnLstAsientos
            // 
            this.btnLstAsientos.Caption = "Asientos";
            this.btnLstAsientos.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLstAsientos.Glyph")));
            this.btnLstAsientos.Id = 18;
            this.btnLstAsientos.Name = "btnLstAsientos";
            // 
            // VerCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 569);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "VerCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VerCuentas";
            this.Load += new System.EventHandler(this.VerCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAsientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource vAsientosBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdAsiento;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colComentario;
        private DevExpress.XtraGrid.Columns.GridColumn colDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnQuitar;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lblMsg;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpresa;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFecha;
        private DevExpress.XtraBars.BarStaticItem lblDiferencia;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarButtonItem btnCuentas;
        private DevExpress.XtraBars.BarButtonItem btnLstAsientos;
        private DevExpress.XtraGrid.Columns.GridColumn colusuario;
    }
}