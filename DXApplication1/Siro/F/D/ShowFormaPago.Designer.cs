namespace Siro.F.D
{
    partial class ShowFormaPago
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
            this.cmbTerminoPago = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerminoPago.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTerminoPago
            // 
            this.cmbTerminoPago.Location = new System.Drawing.Point(1, 0);
            this.cmbTerminoPago.Name = "cmbTerminoPago";
            this.cmbTerminoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTerminoPago.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 7 Dias", "3", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 15 Dias", "4", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 30 Dias", "5", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 45 Dias", "6", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 60 Dias", "7", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Neto 90 Dias", "8", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Mas 120 Dias", "9", -1)});
            this.cmbTerminoPago.Size = new System.Drawing.Size(193, 20);
            this.cmbTerminoPago.TabIndex = 18;
            this.cmbTerminoPago.SelectedIndexChanged += new System.EventHandler(this.cmbTerminoPago_SelectedIndexChanged);
            // 
            // ShowFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 20);
            this.Controls.Add(this.cmbTerminoPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowFormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dias Crédito";
            this.Load += new System.EventHandler(this.ShowFormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerminoPago.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit cmbTerminoPago;
    }
}