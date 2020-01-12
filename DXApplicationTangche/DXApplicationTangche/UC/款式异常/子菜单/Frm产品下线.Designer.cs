namespace DXApplicationTangche.UC.款式异常.子菜单
{
    partial class Frm产品下线
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm产品下线));
            this.gridControl待办 = new DevExpress.XtraGrid.GridControl();
            this.gridView待办 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSYS_STYLE_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_PUBLISH_CATEGORY_CD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_YEAR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_SEASON1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl待办)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView待办)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl待办
            // 
            this.gridControl待办.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl待办.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl待办.Location = new System.Drawing.Point(0, 206);
            this.gridControl待办.MainView = this.gridView待办;
            this.gridControl待办.Name = "gridControl待办";
            this.gridControl待办.Size = new System.Drawing.Size(1106, 140);
            this.gridControl待办.TabIndex = 1;
            this.gridControl待办.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView待办});
            // 
            // gridView待办
            // 
            this.gridView待办.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSYS_STYLE_ID1,
            this.colSTYLE_NAME_CN1,
            this.colSTYLE_PUBLISH_CATEGORY_CD1,
            this.colSYTLE_YEAR1,
            this.colSYTLE_SEASON1});
            this.gridView待办.GridControl = this.gridControl待办;
            this.gridView待办.Name = "gridView待办";
            this.gridView待办.OptionsBehavior.Editable = false;
            this.gridView待办.OptionsView.ShowGroupPanel = false;
            // 
            // colSYS_STYLE_ID1
            // 
            this.colSYS_STYLE_ID1.Caption = "gridColumn1";
            this.colSYS_STYLE_ID1.FieldName = "SYS_STYLE_ID";
            this.colSYS_STYLE_ID1.MinWidth = 25;
            this.colSYS_STYLE_ID1.Name = "colSYS_STYLE_ID1";
            this.colSYS_STYLE_ID1.Width = 94;
            // 
            // colSTYLE_NAME_CN1
            // 
            this.colSTYLE_NAME_CN1.Caption = "款式名称";
            this.colSTYLE_NAME_CN1.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN1.MinWidth = 25;
            this.colSTYLE_NAME_CN1.Name = "colSTYLE_NAME_CN1";
            this.colSTYLE_NAME_CN1.Visible = true;
            this.colSTYLE_NAME_CN1.VisibleIndex = 0;
            this.colSTYLE_NAME_CN1.Width = 230;
            // 
            // colSTYLE_PUBLISH_CATEGORY_CD1
            // 
            this.colSTYLE_PUBLISH_CATEGORY_CD1.Caption = "服装种类";
            this.colSTYLE_PUBLISH_CATEGORY_CD1.FieldName = "STYLE_PUBLISH_CATEGORY_CD";
            this.colSTYLE_PUBLISH_CATEGORY_CD1.MinWidth = 25;
            this.colSTYLE_PUBLISH_CATEGORY_CD1.Name = "colSTYLE_PUBLISH_CATEGORY_CD1";
            this.colSTYLE_PUBLISH_CATEGORY_CD1.Visible = true;
            this.colSTYLE_PUBLISH_CATEGORY_CD1.VisibleIndex = 1;
            this.colSTYLE_PUBLISH_CATEGORY_CD1.Width = 71;
            // 
            // colSYTLE_YEAR1
            // 
            this.colSYTLE_YEAR1.Caption = "年份";
            this.colSYTLE_YEAR1.FieldName = "SYTLE_YEAR";
            this.colSYTLE_YEAR1.MinWidth = 25;
            this.colSYTLE_YEAR1.Name = "colSYTLE_YEAR1";
            this.colSYTLE_YEAR1.Visible = true;
            this.colSYTLE_YEAR1.VisibleIndex = 2;
            this.colSYTLE_YEAR1.Width = 55;
            // 
            // colSYTLE_SEASON1
            // 
            this.colSYTLE_SEASON1.Caption = "季节";
            this.colSYTLE_SEASON1.FieldName = "SYTLE_SEASON";
            this.colSYTLE_SEASON1.MinWidth = 25;
            this.colSYTLE_SEASON1.Name = "colSYTLE_SEASON1";
            this.colSYTLE_SEASON1.Visible = true;
            this.colSYTLE_SEASON1.VisibleIndex = 3;
            this.colSYTLE_SEASON1.Width = 47;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1106, 206);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "提交审核";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "提交审核";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 346);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1106, 32);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // Frm产品下线
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 378);
            this.Controls.Add(this.gridControl待办);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm产品下线";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "产品下线送审";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl待办)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView待办)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl待办;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView待办;
        private DevExpress.XtraGrid.Columns.GridColumn colSYS_STYLE_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_PUBLISH_CATEGORY_CD1;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_YEAR1;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_SEASON1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}