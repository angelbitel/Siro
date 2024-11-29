
namespace Siro.F.P
{
    partial class frmDiasLibres
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonQuitarFecha = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.diasFeriadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDiaLibre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasFeriadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButtonQuitarFecha);
            this.layoutControl1.Controls.Add(this.simpleButtonAceptar);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(451, 380);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButtonQuitarFecha
            // 
            this.simpleButtonQuitarFecha.Location = new System.Drawing.Point(12, 341);
            this.simpleButtonQuitarFecha.Name = "simpleButtonQuitarFecha";
            this.simpleButtonQuitarFecha.Size = new System.Drawing.Size(211, 27);
            this.simpleButtonQuitarFecha.StyleController = this.layoutControl1;
            this.simpleButtonQuitarFecha.TabIndex = 6;
            this.simpleButtonQuitarFecha.Text = "QUITAR REGISTRO";
            this.simpleButtonQuitarFecha.Click += new System.EventHandler(this.simpleButtonQuitarFecha_Click);
            // 
            // simpleButtonAceptar
            // 
            this.simpleButtonAceptar.Location = new System.Drawing.Point(227, 341);
            this.simpleButtonAceptar.Name = "simpleButtonAceptar";
            this.simpleButtonAceptar.Size = new System.Drawing.Size(212, 27);
            this.simpleButtonAceptar.StyleController = this.layoutControl1;
            this.simpleButtonAceptar.TabIndex = 5;
            this.simpleButtonAceptar.Text = "ACEPTAR";
            this.simpleButtonAceptar.Click += new System.EventHandler(this.simpleButtonAceptar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.diasFeriadosBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(427, 325);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // diasFeriadosBindingSource
            // 
            this.diasFeriadosBindingSource.DataSource = typeof(Siro.Model.DiasFeriados);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDiaLibre});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colDiaLibre
            // 
            this.colDiaLibre.DisplayFormat.FormatString = "dddd dd MMM yyyy";
            this.colDiaLibre.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDiaLibre.FieldName = "DiaLibre";
            this.colDiaLibre.MinWidth = 25;
            this.colDiaLibre.Name = "colDiaLibre";
            this.colDiaLibre.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DiaLibre", "CANTIDAD DE DIAS FERIADOS ({0})")});
            this.colDiaLibre.Visible = true;
            this.colDiaLibre.VisibleIndex = 0;
            this.colDiaLibre.Width = 94;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(451, 380);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(431, 329);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButtonQuitarFecha;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 329);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(215, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonAceptar;
            this.layoutControlItem2.Location = new System.Drawing.Point(215, 329);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(216, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmDiasLibres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 380);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmDiasLibres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DIAS LIBRES DEL MES";
            this.Load += new System.EventHandler(this.frmDiasLibres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasFeriadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuitarFecha;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAceptar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource diasFeriadosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaLibre;
    }
}