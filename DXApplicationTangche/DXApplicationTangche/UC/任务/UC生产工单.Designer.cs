namespace DXApplicationTangche.UC.任务
{
    partial class UC生产工单
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel任务一览 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl任务一览 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colORDER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMPLATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_ITEM_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel任务 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel任务一览.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务一览)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel任务一览});
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
            // dockPanel任务一览
            // 
            this.dockPanel任务一览.Controls.Add(this.dockPanel1_Container);
            this.dockPanel任务一览.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel任务一览.ID = new System.Guid("a2b2c751-902f-4737-b65e-958365b1a017");
            this.dockPanel任务一览.Location = new System.Drawing.Point(453, 0);
            this.dockPanel任务一览.Name = "dockPanel任务一览";
            this.dockPanel任务一览.OriginalSize = new System.Drawing.Size(383, 200);
            this.dockPanel任务一览.Size = new System.Drawing.Size(383, 633);
            this.dockPanel任务一览.Text = "已办任务一览";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl任务一览);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(376, 600);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControl任务一览
            // 
            this.gridControl任务一览.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl任务一览.Location = new System.Drawing.Point(0, 0);
            this.gridControl任务一览.MainView = this.gridView1;
            this.gridControl任务一览.Name = "gridControl任务一览";
            this.gridControl任务一览.Size = new System.Drawing.Size(376, 600);
            this.gridControl任务一览.TabIndex = 0;
            this.gridControl任务一览.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colORDER_ID,
            this.colSTYLE_NAME_CN,
            this.colTEMPLATE_NAME,
            this.colSTATUS_ITEM_NAME_CN,
            this.colDate});
            this.gridView1.GridControl = this.gridControl任务一览;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colORDER_ID
            // 
            this.colORDER_ID.Caption = "订单id";
            this.colORDER_ID.FieldName = "ORDER_ID";
            this.colORDER_ID.Name = "colORDER_ID";
            this.colORDER_ID.Visible = true;
            this.colORDER_ID.VisibleIndex = 0;
            // 
            // colSTYLE_NAME_CN
            // 
            this.colSTYLE_NAME_CN.Caption = "款式名称";
            this.colSTYLE_NAME_CN.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Name = "colSTYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Visible = true;
            this.colSTYLE_NAME_CN.VisibleIndex = 1;
            // 
            // colTEMPLATE_NAME
            // 
            this.colTEMPLATE_NAME.Caption = "任务类型";
            this.colTEMPLATE_NAME.FieldName = "TEMPLATE_NAME";
            this.colTEMPLATE_NAME.Name = "colTEMPLATE_NAME";
            this.colTEMPLATE_NAME.Visible = true;
            this.colTEMPLATE_NAME.VisibleIndex = 2;
            // 
            // colSTATUS_ITEM_NAME_CN
            // 
            this.colSTATUS_ITEM_NAME_CN.Caption = "任务状态";
            this.colSTATUS_ITEM_NAME_CN.FieldName = "STATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.Name = "colSTATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.Visible = true;
            this.colSTATUS_ITEM_NAME_CN.VisibleIndex = 3;
            // 
            // colDate
            // 
            this.colDate.Caption = "创建时间";
            this.colDate.FieldName = "CREATE_DATE";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;
            // 
            // panel任务
            // 
            this.panel任务.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel任务.Location = new System.Drawing.Point(0, 0);
            this.panel任务.Name = "panel任务";
            this.panel任务.Size = new System.Drawing.Size(453, 633);
            this.panel任务.TabIndex = 2;
            // 
            // UC生产工单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel任务);
            this.Controls.Add(this.dockPanel任务一览);
            this.Name = "UC生产工单";
            this.Size = new System.Drawing.Size(836, 633);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel任务一览.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务一览)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel任务一览;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControl任务一览;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMPLATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_ITEM_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        public System.Windows.Forms.Panel panel任务;
    }
}
