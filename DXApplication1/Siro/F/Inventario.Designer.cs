namespace Siro.F
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.navBarGroup6 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem31 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem33 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup8 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem28 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem23 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem24 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem26 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem32 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem27 = new DevExpress.XtraNavBar.NavBarItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblMsg = new DevExpress.XtraBars.BarStaticItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnRegistroArroz = new DevExpress.XtraBars.BarButtonItem();
            this.btnAjusteInventario = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrarCicloArroz = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnMovil = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemFecha = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // navBarGroup6
            // 
            this.navBarGroup6.Caption = "Tareas Comunes";
            this.navBarGroup6.Expanded = true;
            this.navBarGroup6.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem31),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem33),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.navBarGroup6.Name = "navBarGroup6";
            // 
            // navBarItem31
            // 
            this.navBarItem31.Caption = "Registro De RA";
            this.navBarItem31.Name = "navBarItem31";
            // 
            // navBarItem33
            // 
            this.navBarItem33.Caption = "Ajustes Inventario";
            this.navBarItem33.Name = "navBarItem33";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Cerrar Ciclo Almacenaje";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarGroup8
            // 
            this.navBarGroup8.Caption = "Reportes";
            this.navBarGroup8.Expanded = true;
            this.navBarGroup8.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem28)});
            this.navBarGroup8.Name = "navBarGroup8";
            this.navBarGroup8.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup8.SmallImage")));
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Inventario Silos";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Inventario Productos";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem28
            // 
            this.navBarItem28.Caption = "Tablero";
            this.navBarItem28.Name = "navBarItem28";
            // 
            // navBarItem23
            // 
            this.navBarItem23.Caption = "Deducciones";
            this.navBarItem23.Name = "navBarItem23";
            // 
            // navBarItem24
            // 
            this.navBarItem24.Caption = "Departamentos";
            this.navBarItem24.Name = "navBarItem24";
            // 
            // navBarItem25
            // 
            this.navBarItem25.Caption = "Acredores";
            this.navBarItem25.Name = "navBarItem25";
            // 
            // navBarItem26
            // 
            this.navBarItem26.Caption = "Estados";
            this.navBarItem26.Name = "navBarItem26";
            // 
            // navBarItem32
            // 
            this.navBarItem32.Caption = "Probar Impuestos";
            this.navBarItem32.Name = "navBarItem32";
            // 
            // navBarItem27
            // 
            this.navBarItem27.Caption = "Factores";
            this.navBarItem27.Name = "navBarItem27";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.lblMsg,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barStaticItemFecha,
            this.barStaticItemEmpresa,
            this.btnRegistroArroz,
            this.btnAjusteInventario,
            this.btnCerrarCicloArroz,
            this.barSubItem1,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.btnMovil});
            this.barManager1.MaxItemId = 14;
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
            this.lblMsg.Id = 1;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRegistroArroz, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAjusteInventario, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCerrarCicloArroz, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnMovil, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Custom 2";
            // 
            // btnRegistroArroz
            // 
            this.btnRegistroArroz.Caption = "Registro RA";
            this.btnRegistroArroz.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRegistroArroz.Glyph")));
            this.btnRegistroArroz.Id = 6;
            this.btnRegistroArroz.Name = "btnRegistroArroz";
            this.btnRegistroArroz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegistroArroz_ItemClick);
            // 
            // btnAjusteInventario
            // 
            this.btnAjusteInventario.Caption = "Ajuste Inventario";
            this.btnAjusteInventario.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAjusteInventario.Glyph")));
            this.btnAjusteInventario.Id = 7;
            this.btnAjusteInventario.Name = "btnAjusteInventario";
            this.btnAjusteInventario.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAjusteInventario_ItemClick);
            // 
            // btnCerrarCicloArroz
            // 
            this.btnCerrarCicloArroz.Caption = "Cerrar Ciclo";
            this.btnCerrarCicloArroz.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCerrarCicloArroz.Glyph")));
            this.btnCerrarCicloArroz.Id = 8;
            this.btnCerrarCicloArroz.Name = "btnCerrarCicloArroz";
            this.btnCerrarCicloArroz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCerrarCicloArroz_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Reportes";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 9;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Inventario Silos";
            this.barButtonItem7.Id = 10;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Inventario Productos";
            this.barButtonItem8.Id = 11;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Tablero";
            this.barButtonItem9.Id = 12;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // btnMovil
            // 
            this.btnMovil.Caption = "Ventas Moviles";
            this.btnMovil.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMovil.Glyph")));
            this.btnMovil.Id = 13;
            this.btnMovil.Name = "btnMovil";
            this.btnMovil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMovil_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1129, 56);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 884);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1129, 35);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 56);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 828);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1129, 56);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 828);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Nuevo Cliente";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Ocultar Panel Edición";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Mostrar Panel Edición";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barStaticItemFecha
            // 
            this.barStaticItemFecha.Id = 4;
            this.barStaticItemFecha.Name = "barStaticItemFecha";
            this.barStaticItemFecha.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemEmpresa
            // 
            this.barStaticItemEmpresa.Id = 5;
            this.barStaticItemEmpresa.Name = "barStaticItemEmpresa";
            this.barStaticItemEmpresa.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = global::Siro.Properties.Resources.silo3;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 56);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureEdit1.MenuManager = this.barManager1;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(1129, 828);
            this.pictureEdit1.TabIndex = 7;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 919);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Inventario";
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lblMsg;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemFecha;
        private DevExpress.XtraBars.BarStaticItem barStaticItemEmpresa;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem31;
        private DevExpress.XtraNavBar.NavBarItem navBarItem33;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem28;
        private DevExpress.XtraNavBar.NavBarItem navBarItem23;
        private DevExpress.XtraNavBar.NavBarItem navBarItem24;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem26;
        private DevExpress.XtraNavBar.NavBarItem navBarItem32;
        private DevExpress.XtraNavBar.NavBarItem navBarItem27;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnRegistroArroz;
        private DevExpress.XtraBars.BarButtonItem btnAjusteInventario;
        private DevExpress.XtraBars.BarButtonItem btnCerrarCicloArroz;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem btnMovil;
    }
}