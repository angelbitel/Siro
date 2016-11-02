namespace Siro.F.D
{
    partial class ShowEmpleados
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
            this.colIdColaborador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColaborador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentificacionPersonal = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gluProveedor.Properties.DisplayMember = "Colaborador";
            this.gluProveedor.Properties.ValueMember = "IdColaborador";
            this.gluProveedor.Properties.View = this.gridLookUpEdit1View;
            this.gluProveedor.Size = new System.Drawing.Size(284, 20);
            this.gluProveedor.TabIndex = 7;
            this.gluProveedor.EditValueChanged += new System.EventHandler(this.gluProveedor_EditValueChanged);
            this.gluProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gluProveedor_KeyUp);
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataSource = typeof(Siro.Colaboradores);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdColaborador,
            this.colColaborador,
            this.colIdentificacionPersonal});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIdColaborador
            // 
            this.colIdColaborador.FieldName = "IdColaborador";
            this.colIdColaborador.Name = "colIdColaborador";
            this.colIdColaborador.Visible = true;
            this.colIdColaborador.VisibleIndex = 2;
            // 
            // colColaborador
            // 
            this.colColaborador.FieldName = "Colaborador";
            this.colColaborador.Name = "colColaborador";
            this.colColaborador.Visible = true;
            this.colColaborador.VisibleIndex = 0;
            // 
            // colIdentificacionPersonal
            // 
            this.colIdentificacionPersonal.FieldName = "IdentificacionPersonal";
            this.colIdentificacionPersonal.Name = "colIdentificacionPersonal";
            this.colIdentificacionPersonal.Visible = true;
            this.colIdentificacionPersonal.VisibleIndex = 1;
            // 
            // ShowEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 20);
            this.Controls.Add(this.gluProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowEmpleados";
            this.Load += new System.EventHandler(this.ShowEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gluProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit gluProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdColaborador;
        private DevExpress.XtraGrid.Columns.GridColumn colColaborador;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificacionPersonal;
    }
}