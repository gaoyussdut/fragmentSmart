namespace DXApplicationTangche.UC.门店下单.form
{
    partial class Frm门店统一下单
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem2 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarGroup3 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem1 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem3 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colorder_type = new DevExpress.XtraGrid.Columns.TileViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("7cd503d1-be70-46f1-9956-e5f11519aba4");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 689);
            this.dockPanel1.Text = "订单详情";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 37);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(190, 648);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.ID = new System.Guid("4e785f30-87ac-43c5-81b9-8e5122346d70");
            this.dockPanel2.Location = new System.Drawing.Point(1008, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(200, 689);
            this.dockPanel2.Text = "款式预览";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(6, 37);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(190, 648);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // tileBar1
            // 
            this.tileBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.Groups.Add(this.tileBarGroup2);
            this.tileBar1.Groups.Add(this.tileBarGroup3);
            this.tileBar1.Location = new System.Drawing.Point(200, 0);
            this.tileBar1.MaxId = 4;
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar1.Size = new System.Drawing.Size(808, 138);
            this.tileBar1.TabIndex = 2;
            this.tileBar1.Text = "tileBar1";
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.tileBarItem2);
            this.tileBarGroup2.Name = "tileBarGroup2";
            this.tileBarGroup2.Text = "标准款下单";
            // 
            // tileBarItem2
            // 
            this.tileBarItem2.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "标准款下单";
            this.tileBarItem2.Elements.Add(tileItemElement1);
            this.tileBarItem2.Id = 1;
            this.tileBarItem2.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem2.Name = "tileBarItem2";
            // 
            // tileBarGroup3
            // 
            this.tileBarGroup3.Items.Add(this.tileBarItem1);
            this.tileBarGroup3.Items.Add(this.tileBarItem3);
            this.tileBarGroup3.Name = "tileBarGroup3";
            this.tileBarGroup3.Text = "定制下单";
            // 
            // tileBarItem1
            // 
            this.tileBarItem1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Text = "选择面料下单";
            this.tileBarItem1.Elements.Add(tileItemElement2);
            this.tileBarItem1.Id = 2;
            this.tileBarItem1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem1.Name = "tileBarItem1";
            // 
            // tileBarItem3
            // 
            this.tileBarItem3.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Text = "上传面料图片下单";
            this.tileBarItem3.Elements.Add(tileItemElement3);
            this.tileBarItem3.Id = 3;
            this.tileBarItem3.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem3.Name = "tileBarItem3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(200, 138);
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(808, 551);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3,
            this.tileViewColumn4,
            this.colorder_type});
            this.tileView1.ColumnSet.GroupColumn = this.colorder_type;
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.tileView1.OptionsTiles.IndentBetweenGroups = 0;
            this.tileView1.OptionsTiles.IndentBetweenItems = 0;
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.RowCount = 0;
            this.tileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colorder_type, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "tileViewColumn1";
            this.tileViewColumn1.MinWidth = 25;
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            this.tileViewColumn1.Width = 94;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.Caption = "tileViewColumn2";
            this.tileViewColumn2.MinWidth = 25;
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            this.tileViewColumn2.Width = 94;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.Caption = "tileViewColumn3";
            this.tileViewColumn3.MinWidth = 25;
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            this.tileViewColumn3.Width = 94;
            // 
            // tileViewColumn4
            // 
            this.tileViewColumn4.Caption = "tileViewColumn4";
            this.tileViewColumn4.MinWidth = 25;
            this.tileViewColumn4.Name = "tileViewColumn4";
            this.tileViewColumn4.Visible = true;
            this.tileViewColumn4.VisibleIndex = 3;
            this.tileViewColumn4.Width = 94;
            // 
            // colorder_type
            // 
            this.colorder_type.Caption = "order_type";
            this.colorder_type.FieldName = "order_type";
            this.colorder_type.MinWidth = 25;
            this.colorder_type.Name = "colorder_type";
            this.colorder_type.Visible = true;
            this.colorder_type.VisibleIndex = 4;
            this.colorder_type.Width = 94;
            // 
            // Frm门店统一下单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 689);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.tileBar1);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "Frm门店统一下单";
            this.Text = "Frm门店统一下单";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem2;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup3;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem1;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem3;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn4;
        private DevExpress.XtraGrid.Columns.TileViewColumn colorder_type;
    }
}