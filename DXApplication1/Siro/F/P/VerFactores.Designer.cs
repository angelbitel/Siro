namespace Siro.F.P
{
    partial class VerFactores
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.factorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colIdFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcionFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestaSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.factorBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(745, 649);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdFactor,
            this.colDescripcionFactor,
            this.colFactor1,
            this.colTipoFactor,
            this.colRestaSaldo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // factorBindingSource
            // 
            this.factorBindingSource.DataSource = typeof(Siro.Model.Factor);
            // 
            // colIdFactor
            // 
            this.colIdFactor.FieldName = "IdFactor";
            this.colIdFactor.Name = "colIdFactor";
            this.colIdFactor.Visible = true;
            this.colIdFactor.VisibleIndex = 0;
            // 
            // colDescripcionFactor
            // 
            this.colDescripcionFactor.FieldName = "DescripcionFactor";
            this.colDescripcionFactor.Name = "colDescripcionFactor";
            this.colDescripcionFactor.Visible = true;
            this.colDescripcionFactor.VisibleIndex = 1;
            // 
            // colFactor1
            // 
            this.colFactor1.Caption = "Factor";
            this.colFactor1.FieldName = "Factor1";
            this.colFactor1.Name = "colFactor1";
            this.colFactor1.Visible = true;
            this.colFactor1.VisibleIndex = 2;
            // 
            // colTipoFactor
            // 
            this.colTipoFactor.FieldName = "TipoFactor";
            this.colTipoFactor.Name = "colTipoFactor";
            this.colTipoFactor.Visible = true;
            this.colTipoFactor.VisibleIndex = 3;
            // 
            // colRestaSaldo
            // 
            this.colRestaSaldo.FieldName = "RestaSaldo";
            this.colRestaSaldo.Name = "colRestaSaldo";
            this.colRestaSaldo.Visible = true;
            this.colRestaSaldo.VisibleIndex = 4;
            // 
            // VerFactores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 649);
            this.Controls.Add(this.gridControl1);
            this.Name = "VerFactores";
            this.Text = "VerFactores";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource factorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdFactor;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionFactor;
        private DevExpress.XtraGrid.Columns.GridColumn colFactor1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoFactor;
        private DevExpress.XtraGrid.Columns.GridColumn colRestaSaldo;
    }
}