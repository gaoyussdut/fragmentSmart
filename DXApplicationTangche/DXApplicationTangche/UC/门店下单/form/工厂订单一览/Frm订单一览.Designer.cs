namespace DXApplicationTangche.UC.门店下单.form
{
    partial class Frm订单一览
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
            this.gridControl订单一览 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colORDER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTOM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREMARKS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORDER_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_SIZE_GROUP_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_SIZE_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_CATEGORY_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_FIT_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTOMER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORDER_STATUS_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colITEM_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl订单一览)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl订单一览
            // 
            this.gridControl订单一览.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl订单一览.Location = new System.Drawing.Point(0, 0);
            this.gridControl订单一览.MainView = this.gridView1;
            this.gridControl订单一览.Name = "gridControl订单一览";
            this.gridControl订单一览.Size = new System.Drawing.Size(916, 462);
            this.gridControl订单一览.TabIndex = 0;
            this.gridControl订单一览.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colORDER_ID,
            this.colCUSTOM_NAME,
            this.colSTYLE_NAME_CN,
            this.colREMARKS,
            this.colORDER_DATE,
            this.colPAYMENT_DATE,
            this.colSTYLE_SIZE_GROUP_CD,
            this.colSTYLE_SIZE_CD,
            this.colSTYLE_CATEGORY_CD,
            this.colSTYLE_FIT_CD,
            this.colCUSTOMER_ID,
            this.colORDER_STATUS_CD,
            this.colITEM_NAME_CN});
            this.gridView1.GridControl = this.gridControl订单一览;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colORDER_DATE, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colORDER_ID
            // 
            this.colORDER_ID.Caption = "ORDER_ID";
            this.colORDER_ID.FieldName = "ORDER_ID";
            this.colORDER_ID.MinWidth = 25;
            this.colORDER_ID.Name = "colORDER_ID";
            this.colORDER_ID.Width = 94;
            // 
            // colCUSTOM_NAME
            // 
            this.colCUSTOM_NAME.Caption = "客户名";
            this.colCUSTOM_NAME.FieldName = "CUSTOM_NAME";
            this.colCUSTOM_NAME.MinWidth = 25;
            this.colCUSTOM_NAME.Name = "colCUSTOM_NAME";
            this.colCUSTOM_NAME.Visible = true;
            this.colCUSTOM_NAME.VisibleIndex = 0;
            this.colCUSTOM_NAME.Width = 94;
            // 
            // colSTYLE_NAME_CN
            // 
            this.colSTYLE_NAME_CN.Caption = "款式名称";
            this.colSTYLE_NAME_CN.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN.MinWidth = 25;
            this.colSTYLE_NAME_CN.Name = "colSTYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Visible = true;
            this.colSTYLE_NAME_CN.VisibleIndex = 1;
            this.colSTYLE_NAME_CN.Width = 94;
            // 
            // colREMARKS
            // 
            this.colREMARKS.Caption = "备注";
            this.colREMARKS.FieldName = "REMARKS";
            this.colREMARKS.MinWidth = 25;
            this.colREMARKS.Name = "colREMARKS";
            this.colREMARKS.Visible = true;
            this.colREMARKS.VisibleIndex = 2;
            this.colREMARKS.Width = 94;
            // 
            // colORDER_DATE
            // 
            this.colORDER_DATE.Caption = "订单日期";
            this.colORDER_DATE.FieldName = "ORDER_DATE";
            this.colORDER_DATE.MinWidth = 25;
            this.colORDER_DATE.Name = "colORDER_DATE";
            this.colORDER_DATE.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colORDER_DATE.Visible = true;
            this.colORDER_DATE.VisibleIndex = 4;
            this.colORDER_DATE.Width = 94;
            // 
            // colPAYMENT_DATE
            // 
            this.colPAYMENT_DATE.Caption = "下单时间";
            this.colPAYMENT_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPAYMENT_DATE.FieldName = "PAYMENT_DATE";
            this.colPAYMENT_DATE.MinWidth = 25;
            this.colPAYMENT_DATE.Name = "colPAYMENT_DATE";
            this.colPAYMENT_DATE.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colPAYMENT_DATE.Visible = true;
            this.colPAYMENT_DATE.VisibleIndex = 3;
            this.colPAYMENT_DATE.Width = 94;
            // 
            // colSTYLE_SIZE_GROUP_CD
            // 
            this.colSTYLE_SIZE_GROUP_CD.Caption = "STYLE_SIZE_GROUP_CD";
            this.colSTYLE_SIZE_GROUP_CD.FieldName = "STYLE_SIZE_GROUP_CD";
            this.colSTYLE_SIZE_GROUP_CD.MinWidth = 25;
            this.colSTYLE_SIZE_GROUP_CD.Name = "colSTYLE_SIZE_GROUP_CD";
            this.colSTYLE_SIZE_GROUP_CD.Width = 94;
            // 
            // colSTYLE_SIZE_CD
            // 
            this.colSTYLE_SIZE_CD.Caption = "STYLE_SIZE_CD";
            this.colSTYLE_SIZE_CD.FieldName = "STYLE_SIZE_CD";
            this.colSTYLE_SIZE_CD.MinWidth = 25;
            this.colSTYLE_SIZE_CD.Name = "colSTYLE_SIZE_CD";
            this.colSTYLE_SIZE_CD.Width = 94;
            // 
            // colSTYLE_CATEGORY_CD
            // 
            this.colSTYLE_CATEGORY_CD.Caption = "STYLE_CATEGORY_CD";
            this.colSTYLE_CATEGORY_CD.FieldName = "STYLE_CATEGORY_CD";
            this.colSTYLE_CATEGORY_CD.MinWidth = 25;
            this.colSTYLE_CATEGORY_CD.Name = "colSTYLE_CATEGORY_CD";
            this.colSTYLE_CATEGORY_CD.Width = 94;
            // 
            // colSTYLE_FIT_CD
            // 
            this.colSTYLE_FIT_CD.Caption = "STYLE_FIT_CD";
            this.colSTYLE_FIT_CD.FieldName = "STYLE_FIT_CD";
            this.colSTYLE_FIT_CD.MinWidth = 25;
            this.colSTYLE_FIT_CD.Name = "colSTYLE_FIT_CD";
            this.colSTYLE_FIT_CD.Width = 94;
            // 
            // colCUSTOMER_ID
            // 
            this.colCUSTOMER_ID.Caption = "CUSTOMER_ID";
            this.colCUSTOMER_ID.FieldName = "CUSTOMER_ID";
            this.colCUSTOMER_ID.MinWidth = 25;
            this.colCUSTOMER_ID.Name = "colCUSTOMER_ID";
            this.colCUSTOMER_ID.Width = 94;
            // 
            // colORDER_STATUS_CD
            // 
            this.colORDER_STATUS_CD.Caption = "STATUS_CD";
            this.colORDER_STATUS_CD.FieldName = "ORDER_STATUS_CD";
            this.colORDER_STATUS_CD.MinWidth = 25;
            this.colORDER_STATUS_CD.Name = "colORDER_STATUS_CD";
            this.colORDER_STATUS_CD.Width = 94;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
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
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("3a21b113-5d3f-4f9f-b0d8-7784915953fa");
            this.dockPanel1.Location = new System.Drawing.Point(916, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(327, 200);
            this.dockPanel1.Size = new System.Drawing.Size(327, 462);
            this.dockPanel1.Text = "筛选项";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(6, 37);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(317, 421);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(317, 421);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(75, 12);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(230, 24);
            this.searchLookUpEdit1.StyleController = this.layoutControl1;
            this.searchLookUpEdit1.TabIndex = 7;
            this.searchLookUpEdit1.Popup += new System.EventHandler(this.searchLookUpEdit1_Popup);
            this.searchLookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.searchLookUpEdit1_CustomDisplayText);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.Click += new System.EventHandler(this.searchLookUpEdit1View_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(317, 421);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(297, 373);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.searchLookUpEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(297, 28);
            this.layoutControlItem1.Text = "订单状态";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // colITEM_NAME_CN
            // 
            this.colITEM_NAME_CN.Caption = "状态";
            this.colITEM_NAME_CN.FieldName = "ITEM_NAME_CN";
            this.colITEM_NAME_CN.MinWidth = 25;
            this.colITEM_NAME_CN.Name = "colITEM_NAME_CN";
            this.colITEM_NAME_CN.Visible = true;
            this.colITEM_NAME_CN.VisibleIndex = 4;
            this.colITEM_NAME_CN.Width = 94;
            // 
            // Frm订单一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 462);
            this.Controls.Add(this.gridControl订单一览);
            this.Controls.Add(this.dockPanel1);
            this.Name = "Frm订单一览";
            this.Text = "Frm订单一览";
            this.Load += new System.EventHandler(this.Frm已付款订单一览_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl订单一览)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl订单一览;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTOM_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colREMARKS;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_SIZE_GROUP_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_SIZE_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_CATEGORY_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_FIT_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTOMER_ID;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_STATUS_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colITEM_NAME_CN;
    }
}