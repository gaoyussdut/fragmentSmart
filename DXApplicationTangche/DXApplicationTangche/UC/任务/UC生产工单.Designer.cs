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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel任务一览 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl任务一览 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colORDER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEMPLATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_ITEM_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItemOrderid = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel任务一览.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务一览)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barEditItemOrderid});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.ribbonControl1.Size = new System.Drawing.Size(836, 162);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemTextEdit1_KeyDown);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemOrderid);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "扫描订单id";
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
            this.dockPanel任务一览.Location = new System.Drawing.Point(533, 162);
            this.dockPanel任务一览.Name = "dockPanel任务一览";
            this.dockPanel任务一览.OriginalSize = new System.Drawing.Size(303, 200);
            this.dockPanel任务一览.Size = new System.Drawing.Size(303, 471);
            this.dockPanel任务一览.Text = "任务一览";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl任务一览);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(296, 438);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControl任务一览
            // 
            this.gridControl任务一览.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl任务一览.Location = new System.Drawing.Point(0, 0);
            this.gridControl任务一览.MainView = this.gridView1;
            this.gridControl任务一览.MenuManager = this.ribbonControl1;
            this.gridControl任务一览.Name = "gridControl任务一览";
            this.gridControl任务一览.Size = new System.Drawing.Size(296, 438);
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
            this.colSTATUS_ITEM_NAME_CN});
            this.gridView1.GridControl = this.gridControl任务一览;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.colSTYLE_NAME_CN.VisibleIndex = 2;
            // 
            // colTEMPLATE_NAME
            // 
            this.colTEMPLATE_NAME.Caption = "任务类型";
            this.colTEMPLATE_NAME.FieldName = "TEMPLATE_NAME";
            this.colTEMPLATE_NAME.Name = "colTEMPLATE_NAME";
            this.colTEMPLATE_NAME.Visible = true;
            this.colTEMPLATE_NAME.VisibleIndex = 1;
            // 
            // colSTATUS_ITEM_NAME_CN
            // 
            this.colSTATUS_ITEM_NAME_CN.Caption = "任务状态";
            this.colSTATUS_ITEM_NAME_CN.FieldName = "STATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.Name = "colSTATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.Visible = true;
            this.colSTATUS_ITEM_NAME_CN.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barEditItemOrderid
            // 
            this.barEditItemOrderid.Caption = "订单id";
            this.barEditItemOrderid.Edit = this.repositoryItemTextEdit3;
            this.barEditItemOrderid.EditValue = "";
            this.barEditItemOrderid.EditWidth = 150;
            this.barEditItemOrderid.Id = 3;
            this.barEditItemOrderid.Name = "barEditItemOrderid";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            this.repositoryItemTextEdit3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemTextEdit1_KeyDown);
            // 
            // UC生产工单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel任务一览);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "UC生产工单";
            this.Size = new System.Drawing.Size(836, 633);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel任务一览.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务一览)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel任务一览;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControl任务一览;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colORDER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_ITEM_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colTEMPLATE_NAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItemOrderid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
    }
}
