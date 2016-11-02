namespace Siro.F.D
{
    partial class ShowClientes
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
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombreCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
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
            this.gluProveedor.Properties.DataSource = this.clientesBindingSource;
            this.gluProveedor.Properties.DisplayMember = "NombreCompleto";
            this.gluProveedor.Properties.ValueMember = "idCliente";
            this.gluProveedor.Properties.View = this.gridLookUpEdit1View;
            this.gluProveedor.Size = new System.Drawing.Size(284, 20);
            this.gluProveedor.TabIndex = 6;
            this.gluProveedor.EditValueChanged += new System.EventHandler(this.gluProveedor_EditValueChanged);
            this.gluProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gluProveedor_KeyUp);
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataSource = typeof(Siro.Clientes);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombreCompleto,
            this.colCedulaRuc});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.FieldName = "NombreCompleto";
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.Visible = true;
            this.colNombreCompleto.VisibleIndex = 0;
            // 
            // colCedulaRuc
            // 
            this.colCedulaRuc.FieldName = "CedulaRuc";
            this.colCedulaRuc.Name = "colCedulaRuc";
            this.colCedulaRuc.Visible = true;
            this.colCedulaRuc.VisibleIndex = 1;
            // 
            // ShowClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 21);
            this.Controls.Add(this.gluProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.ShowClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gluProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRuc;
    }
}