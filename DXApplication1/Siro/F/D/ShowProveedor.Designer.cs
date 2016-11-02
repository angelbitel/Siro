namespace Siro.F.D
{
    partial class ShowProveedor
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
            this.provedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gluProveedor
            // 
            this.gluProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gluProveedor.Location = new System.Drawing.Point(0, 0);
            this.gluProveedor.Name = "gluProveedor";
            this.gluProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluProveedor.Properties.DataSource = this.provedoresBindingSource;
            this.gluProveedor.Properties.DisplayMember = "Proveedor";
            this.gluProveedor.Properties.ValidateOnEnterKey = true;
            this.gluProveedor.Properties.ValueMember = "idProvedor";
            this.gluProveedor.Properties.View = this.gridLookUpEdit1View;
            this.gluProveedor.Size = new System.Drawing.Size(284, 20);
            this.gluProveedor.TabIndex = 5;
            this.gluProveedor.EditValueChanged += new System.EventHandler(this.gluProveedor_EditValueChanged);
            this.gluProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gluProveedor_KeyUp);
            // 
            // provedoresBindingSource
            // 
            this.provedoresBindingSource.DataSource = typeof(Siro.provedores);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProveedor,
            this.colTelefono,
            this.colEmail});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colProveedor
            // 
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 0;
            // 
            // colTelefono
            // 
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 1;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 2;
            // 
            // ShowProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 27);
            this.Controls.Add(this.gluProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.ShowProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gluProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private System.Windows.Forms.BindingSource provedoresBindingSource;
    }
}