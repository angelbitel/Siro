namespace Siro.F.D
{
    partial class Proveedores
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
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedores));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.provedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidProvedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactoTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHomePage = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.itbcrumbCuentas = new DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.rpsBreadCrumb1 = new DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit();
            this.colEsProductor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itbcrumbCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBreadCrumb1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.provedoresBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(663, 588);
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
            this.colRuc,
            this.colContacto,
            this.colContactoTitulo,
            this.colDireccion,
            this.colEmail,
            this.colTelefono,
            this.colMovil,
            this.colFax,
            this.colHomePage,
            this.colEsProductor});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colidProvedor
            // 
            this.colidProvedor.Caption = "# Id";
            this.colidProvedor.FieldName = "idProvedor";
            this.colidProvedor.Name = "colidProvedor";
            this.colidProvedor.OptionsColumn.AllowEdit = false;
            this.colidProvedor.Visible = true;
            this.colidProvedor.VisibleIndex = 0;
            this.colidProvedor.Width = 32;
            // 
            // colProveedor
            // 
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 1;
            this.colProveedor.Width = 60;
            // 
            // colRuc
            // 
            this.colRuc.FieldName = "Ruc";
            this.colRuc.Name = "colRuc";
            this.colRuc.Visible = true;
            this.colRuc.VisibleIndex = 2;
            this.colRuc.Width = 60;
            // 
            // colContacto
            // 
            this.colContacto.FieldName = "Contacto";
            this.colContacto.Name = "colContacto";
            this.colContacto.Visible = true;
            this.colContacto.VisibleIndex = 3;
            this.colContacto.Width = 60;
            // 
            // colContactoTitulo
            // 
            this.colContactoTitulo.FieldName = "ContactoTitulo";
            this.colContactoTitulo.Name = "colContactoTitulo";
            this.colContactoTitulo.Visible = true;
            this.colContactoTitulo.VisibleIndex = 4;
            this.colContactoTitulo.Width = 60;
            // 
            // colDireccion
            // 
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 5;
            this.colDireccion.Width = 60;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 6;
            this.colEmail.Width = 60;
            // 
            // colTelefono
            // 
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 7;
            this.colTelefono.Width = 60;
            // 
            // colMovil
            // 
            this.colMovil.FieldName = "Movil";
            this.colMovil.Name = "colMovil";
            this.colMovil.Visible = true;
            this.colMovil.VisibleIndex = 8;
            this.colMovil.Width = 60;
            // 
            // colFax
            // 
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 9;
            this.colFax.Width = 60;
            // 
            // colHomePage
            // 
            this.colHomePage.FieldName = "HomePage";
            this.colHomePage.Name = "colHomePage";
            this.colHomePage.Visible = true;
            this.colHomePage.VisibleIndex = 10;
            this.colHomePage.Width = 70;
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
            this.barButtonItem2,
            this.lblMsg,
            this.barButtonItem3,
            this.barMdiChildrenListItem1,
            this.barWorkspaceMenuItem1,
            this.barButtonItem4,
            this.barEditItem1,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7});
            this.barManager1.MaxItemId = 11;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsBreadCrumb1,
            this.itbcrumbCuentas});
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
            this.lblMsg.Id = 2;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(663, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 588);
            this.barDockControlBottom.Size = new System.Drawing.Size(663, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 588);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(663, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 588);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Archivo";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 4;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // barWorkspaceMenuItem1
            // 
            this.barWorkspaceMenuItem1.Caption = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.Id = 5;
            this.barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.WorkspaceManager = this.workspaceManager1;
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.itbcrumbCuentas;
            this.barEditItem1.EditWidth = 271;
            this.barEditItem1.Id = 7;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // itbcrumbCuentas
            // 
            this.itbcrumbCuentas.AutoHeight = false;
            this.itbcrumbCuentas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itbcrumbCuentas.Name = "itbcrumbCuentas";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Nuevo Perfil";
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Modificar Perfiles";
            this.barButtonItem6.Id = 9;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Guardar Perfil";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 10;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // rpsBreadCrumb1
            // 
            this.rpsBreadCrumb1.AutoHeight = false;
            this.rpsBreadCrumb1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpsBreadCrumb1.Name = "rpsBreadCrumb1";
            // 
            // colEsProductor
            // 
            this.colEsProductor.FieldName = "EsProductor";
            this.colEsProductor.Name = "colEsProductor";
            this.colEsProductor.Visible = true;
            this.colEsProductor.VisibleIndex = 11;
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 614);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Proveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.Proveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itbcrumbCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBreadCrumb1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource provedoresBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidProvedor;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colContacto;
        private DevExpress.XtraGrid.Columns.GridColumn colContactoTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colMovil;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colHomePage;
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
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit itbcrumbCuentas;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit rpsBreadCrumb1;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colEsProductor;
    }
}