namespace Siro.F.D
{
    partial class MantenimientoCuentas
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbl = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.maestroContableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdMaestroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHabilitar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumaResta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentaContable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNivel4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEsBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbNivel1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbNivel2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colC3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbNivel3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colC4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbNivel4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maestroContableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel4)).BeginInit();
            this.SuspendLayout();
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
            this.lbl,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbl),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // lbl
            // 
            this.lbl.Id = 0;
            this.lbl.Name = "lbl";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "AGREGAR CUENTA";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(2596, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1069);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(2596, 68);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1069);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(2596, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1069);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.maestroContableBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbNivel1,
            this.cmbNivel2,
            this.cmbNivel3,
            this.cmbNivel4});
            this.gridControl1.Size = new System.Drawing.Size(2596, 1069);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // maestroContableBindingSource
            // 
            this.maestroContableBindingSource.DataSource = typeof(Siro.Model.MaestroContable);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdMaestroCuenta,
            this.colIdEmpresa,
            this.colText,
            this.colParentID,
            this.colNivel,
            this.colTipo,
            this.colId,
            this.colHabilitar,
            this.colSumaResta,
            this.colNivel0,
            this.colNivel1,
            this.colNivel2,
            this.colNivel3,
            this.colCuentaContable,
            this.colNivel4,
            this.colEsBanco,
            this.colC1,
            this.colC2,
            this.colC3,
            this.colC4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colIdMaestroCuenta
            // 
            this.colIdMaestroCuenta.Caption = "#";
            this.colIdMaestroCuenta.FieldName = "IdMaestroCuenta";
            this.colIdMaestroCuenta.Name = "colIdMaestroCuenta";
            this.colIdMaestroCuenta.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "IdMaestroCuenta", "{0}")});
            this.colIdMaestroCuenta.Visible = true;
            this.colIdMaestroCuenta.VisibleIndex = 0;
            this.colIdMaestroCuenta.Width = 165;
            // 
            // colIdEmpresa
            // 
            this.colIdEmpresa.FieldName = "IdEmpresa";
            this.colIdEmpresa.Name = "colIdEmpresa";
            // 
            // colText
            // 
            this.colText.Caption = "Cuenta";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 440;
            // 
            // colParentID
            // 
            this.colParentID.FieldName = "ParentID";
            this.colParentID.Name = "colParentID";
            // 
            // colNivel
            // 
            this.colNivel.FieldName = "Nivel";
            this.colNivel.Name = "colNivel";
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colHabilitar
            // 
            this.colHabilitar.FieldName = "Habilitar";
            this.colHabilitar.Name = "colHabilitar";
            this.colHabilitar.Width = 234;
            // 
            // colSumaResta
            // 
            this.colSumaResta.FieldName = "SumaResta";
            this.colSumaResta.Name = "colSumaResta";
            // 
            // colNivel0
            // 
            this.colNivel0.FieldName = "Nivel0";
            this.colNivel0.Name = "colNivel0";
            // 
            // colNivel1
            // 
            this.colNivel1.FieldName = "Nivel1";
            this.colNivel1.Name = "colNivel1";
            // 
            // colNivel2
            // 
            this.colNivel2.FieldName = "Nivel2";
            this.colNivel2.Name = "colNivel2";
            // 
            // colNivel3
            // 
            this.colNivel3.FieldName = "Nivel3";
            this.colNivel3.Name = "colNivel3";
            // 
            // colCuentaContable
            // 
            this.colCuentaContable.Caption = "Codigo";
            this.colCuentaContable.FieldName = "CuentaContable";
            this.colCuentaContable.Name = "colCuentaContable";
            this.colCuentaContable.Visible = true;
            this.colCuentaContable.VisibleIndex = 1;
            this.colCuentaContable.Width = 339;
            // 
            // colNivel4
            // 
            this.colNivel4.FieldName = "Nivel4";
            this.colNivel4.Name = "colNivel4";
            // 
            // colEsBanco
            // 
            this.colEsBanco.FieldName = "EsBanco";
            this.colEsBanco.Name = "colEsBanco";
            this.colEsBanco.Visible = true;
            this.colEsBanco.VisibleIndex = 7;
            this.colEsBanco.Width = 190;
            // 
            // colC1
            // 
            this.colC1.Caption = "NVL. 1- GRUPO BASICO";
            this.colC1.ColumnEdit = this.cmbNivel1;
            this.colC1.FieldName = "C1";
            this.colC1.Name = "colC1";
            this.colC1.Visible = true;
            this.colC1.VisibleIndex = 3;
            this.colC1.Width = 338;
            // 
            // cmbNivel1
            // 
            this.cmbNivel1.AutoHeight = false;
            this.cmbNivel1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNivel1.Name = "cmbNivel1";
            // 
            // colC2
            // 
            this.colC2.Caption = "NVL. 2- GRUPO FINANCIERO";
            this.colC2.ColumnEdit = this.cmbNivel2;
            this.colC2.FieldName = "C2";
            this.colC2.Name = "colC2";
            this.colC2.Visible = true;
            this.colC2.VisibleIndex = 4;
            this.colC2.Width = 370;
            // 
            // cmbNivel2
            // 
            this.cmbNivel2.AutoHeight = false;
            this.cmbNivel2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNivel2.Name = "cmbNivel2";
            // 
            // colC3
            // 
            this.colC3.Caption = "NVL. 3- CUENTA CONTROL";
            this.colC3.ColumnEdit = this.cmbNivel3;
            this.colC3.FieldName = "C3";
            this.colC3.Name = "colC3";
            this.colC3.Visible = true;
            this.colC3.VisibleIndex = 5;
            this.colC3.Width = 349;
            // 
            // cmbNivel3
            // 
            this.cmbNivel3.AutoHeight = false;
            this.cmbNivel3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNivel3.Name = "cmbNivel3";
            // 
            // colC4
            // 
            this.colC4.Caption = "NVL. 4-  CUENTA DETALLE";
            this.colC4.ColumnEdit = this.cmbNivel4;
            this.colC4.FieldName = "C4";
            this.colC4.Name = "colC4";
            this.colC4.Visible = true;
            this.colC4.VisibleIndex = 6;
            this.colC4.Width = 349;
            // 
            // cmbNivel4
            // 
            this.cmbNivel4.AutoHeight = false;
            this.cmbNivel4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNivel4.Name = "cmbNivel4";
            // 
            // MantenimientoCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2596, 1137);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MantenimientoCuentas";
            this.Text = "MantenimientoCuentas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MantenimientoCuentas_FormClosed);
            this.Load += new System.EventHandler(this.MantenimientoCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maestroContableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNivel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbl;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMaestroCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colIdEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colParentID;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colHabilitar;
        private DevExpress.XtraGrid.Columns.GridColumn colSumaResta;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel0;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel1;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel2;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel3;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaContable;
        private DevExpress.XtraGrid.Columns.GridColumn colNivel4;
        private DevExpress.XtraGrid.Columns.GridColumn colEsBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colC1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbNivel1;
        private DevExpress.XtraGrid.Columns.GridColumn colC2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbNivel2;
        private DevExpress.XtraGrid.Columns.GridColumn colC3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbNivel3;
        private DevExpress.XtraGrid.Columns.GridColumn colC4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbNivel4;
        private System.Windows.Forms.BindingSource maestroContableBindingSource;
    }
}