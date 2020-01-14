namespace DXApplicationTangche.UC.面料
{
    partial class Frm门店面料一览
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControl面料打码 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATERIAL_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_SOURCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_SPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_GRAM_WEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_THREAD_COUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_COMPOSITION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_OTHER1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_FILE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSHOP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl面料打码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barEditItem1,
            this.barEditItem2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1246, 206);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "门店面料上新";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "扫码";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barEditItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "销售组织";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 486);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1246, 32);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "扫码上新";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.EditWidth = 300;
            this.barEditItem1.Id = 1;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "选择门店";
            this.barEditItem2.Edit = this.repositoryItemLookUpEdit1;
            this.barEditItem2.EditWidth = 100;
            this.barEditItem2.Id = 2;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // gridControl面料打码
            // 
            this.gridControl面料打码.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl面料打码.Location = new System.Drawing.Point(0, 206);
            this.gridControl面料打码.MainView = this.gridView1;
            this.gridControl面料打码.Name = "gridControl面料打码";
            this.gridControl面料打码.Size = new System.Drawing.Size(1246, 280);
            this.gridControl面料打码.TabIndex = 2;
            this.gridControl面料打码.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMATERIAL_CODE,
            this.colMATERIAL_NAME_CN,
            this.colMATERIAL_SOURCE,
            this.colMATERIAL_SPEC,
            this.colMATERIAL_GRAM_WEIGHT,
            this.colMATERIAL_THREAD_COUNT,
            this.colMATERIAL_COMPOSITION,
            this.colMATERIAL_OTHER1,
            this.colMATERIAL_FILE_ID,
            this.colSHOP_NAME});
            this.gridView1.GridControl = this.gridControl面料打码;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSHOP_NAME, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMATERIAL_CODE
            // 
            this.colMATERIAL_CODE.Caption = "面料号";
            this.colMATERIAL_CODE.MinWidth = 25;
            this.colMATERIAL_CODE.Name = "colMATERIAL_CODE";
            this.colMATERIAL_CODE.Visible = true;
            this.colMATERIAL_CODE.VisibleIndex = 0;
            this.colMATERIAL_CODE.Width = 94;
            // 
            // colMATERIAL_NAME_CN
            // 
            this.colMATERIAL_NAME_CN.Caption = "面料名称";
            this.colMATERIAL_NAME_CN.MinWidth = 25;
            this.colMATERIAL_NAME_CN.Name = "colMATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.Visible = true;
            this.colMATERIAL_NAME_CN.VisibleIndex = 1;
            this.colMATERIAL_NAME_CN.Width = 94;
            // 
            // colMATERIAL_SOURCE
            // 
            this.colMATERIAL_SOURCE.Caption = "原辅料来源";
            this.colMATERIAL_SOURCE.MinWidth = 25;
            this.colMATERIAL_SOURCE.Name = "colMATERIAL_SOURCE";
            this.colMATERIAL_SOURCE.Visible = true;
            this.colMATERIAL_SOURCE.VisibleIndex = 2;
            this.colMATERIAL_SOURCE.Width = 94;
            // 
            // colMATERIAL_SPEC
            // 
            this.colMATERIAL_SPEC.Caption = "物料幅宽";
            this.colMATERIAL_SPEC.MinWidth = 25;
            this.colMATERIAL_SPEC.Name = "colMATERIAL_SPEC";
            this.colMATERIAL_SPEC.Visible = true;
            this.colMATERIAL_SPEC.VisibleIndex = 3;
            this.colMATERIAL_SPEC.Width = 94;
            // 
            // colMATERIAL_GRAM_WEIGHT
            // 
            this.colMATERIAL_GRAM_WEIGHT.Caption = "原辅料克重";
            this.colMATERIAL_GRAM_WEIGHT.MinWidth = 25;
            this.colMATERIAL_GRAM_WEIGHT.Name = "colMATERIAL_GRAM_WEIGHT";
            this.colMATERIAL_GRAM_WEIGHT.Visible = true;
            this.colMATERIAL_GRAM_WEIGHT.VisibleIndex = 4;
            this.colMATERIAL_GRAM_WEIGHT.Width = 94;
            // 
            // colMATERIAL_THREAD_COUNT
            // 
            this.colMATERIAL_THREAD_COUNT.Caption = "原辅料纱支密度";
            this.colMATERIAL_THREAD_COUNT.MinWidth = 25;
            this.colMATERIAL_THREAD_COUNT.Name = "colMATERIAL_THREAD_COUNT";
            this.colMATERIAL_THREAD_COUNT.Visible = true;
            this.colMATERIAL_THREAD_COUNT.VisibleIndex = 5;
            this.colMATERIAL_THREAD_COUNT.Width = 94;
            // 
            // colMATERIAL_COMPOSITION
            // 
            this.colMATERIAL_COMPOSITION.Caption = "物料成分";
            this.colMATERIAL_COMPOSITION.MinWidth = 25;
            this.colMATERIAL_COMPOSITION.Name = "colMATERIAL_COMPOSITION";
            this.colMATERIAL_COMPOSITION.Visible = true;
            this.colMATERIAL_COMPOSITION.VisibleIndex = 6;
            this.colMATERIAL_COMPOSITION.Width = 94;
            // 
            // colMATERIAL_OTHER1
            // 
            this.colMATERIAL_OTHER1.Caption = "面料供应商名称";
            this.colMATERIAL_OTHER1.MinWidth = 25;
            this.colMATERIAL_OTHER1.Name = "colMATERIAL_OTHER1";
            this.colMATERIAL_OTHER1.Visible = true;
            this.colMATERIAL_OTHER1.VisibleIndex = 7;
            this.colMATERIAL_OTHER1.Width = 94;
            // 
            // colMATERIAL_FILE_ID
            // 
            this.colMATERIAL_FILE_ID.Caption = "面料图片";
            this.colMATERIAL_FILE_ID.MinWidth = 25;
            this.colMATERIAL_FILE_ID.Name = "colMATERIAL_FILE_ID";
            this.colMATERIAL_FILE_ID.Visible = true;
            this.colMATERIAL_FILE_ID.VisibleIndex = 8;
            this.colMATERIAL_FILE_ID.Width = 94;
            // 
            // colSHOP_NAME
            // 
            this.colSHOP_NAME.Caption = "门店名称";
            this.colSHOP_NAME.MinWidth = 25;
            this.colSHOP_NAME.Name = "colSHOP_NAME";
            this.colSHOP_NAME.Visible = true;
            this.colSHOP_NAME.VisibleIndex = 9;
            this.colSHOP_NAME.Width = 94;
            // 
            // Frm门店面料一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 518);
            this.Controls.Add(this.gridControl面料打码);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm门店面料一览";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Frm门店面料一览";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl面料打码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.GridControl gridControl面料打码;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_SOURCE;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_SPEC;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_GRAM_WEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_THREAD_COUNT;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_COMPOSITION;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_OTHER1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_FILE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSHOP_NAME;
    }
}