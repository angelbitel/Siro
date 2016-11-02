namespace Siro.F.D
{
    partial class ShowBanco2
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
            this.gluProveedor = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bancosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gluProveedor
            // 
            this.gluProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gluProveedor.Location = new System.Drawing.Point(0, 0);
            this.gluProveedor.Name = "gluProveedor";
            this.gluProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluProveedor.Properties.DataSource = this.bancosBindingSource;
            this.gluProveedor.Properties.DisplayMember = "Banco";
            this.gluProveedor.Properties.ValueMember = "IdBanco";
            this.gluProveedor.Properties.View = this.gridLookUpEdit1View;
            this.gluProveedor.Size = new System.Drawing.Size(284, 20);
            this.gluProveedor.TabIndex = 7;
            this.gluProveedor.EditValueChanged += new System.EventHandler(this.gluProveedor_EditValueChanged);
            this.gluProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gluProveedor_KeyUp);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBanco,
            this.colNumeroCuenta});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // bancosBindingSource
            // 
            this.bancosBindingSource.DataSource = typeof(Siro.Bancos);
            // 
            // colBanco
            // 
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 0;
            // 
            // colNumeroCuenta
            // 
            this.colNumeroCuenta.FieldName = "NumeroCuenta";
            this.colNumeroCuenta.Name = "colNumeroCuenta";
            this.colNumeroCuenta.Visible = true;
            this.colNumeroCuenta.VisibleIndex = 1;
            // 
            // ShowBanco2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 20);
            this.Controls.Add(this.gluProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowBanco2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Banco";
            this.Load += new System.EventHandler(this.ShowBanco2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gluProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.BindingSource bancosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroCuenta;
    }
}