namespace DXApplicationTangche.UC.任务
{
    partial class Frm待办任务
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm待办任务));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookUpEditUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFIRST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comboBoxEditStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl任务 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLOGIN_USER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(1332, 206);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "新增任务";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "任务一览";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "新建";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 641);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1332, 32);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.searchLookUpEditUser);
            this.layoutControl1.Controls.Add(this.comboBoxEditStatus);
            this.layoutControl1.Controls.Add(this.dateTimePickerEnd);
            this.layoutControl1.Controls.Add(this.dateTimePickerStart);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 206);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1332, 120);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // searchLookUpEditUser
            // 
            this.searchLookUpEditUser.Location = new System.Drawing.Point(75, 12);
            this.searchLookUpEditUser.MenuManager = this.ribbonControl1;
            this.searchLookUpEditUser.Name = "searchLookUpEditUser";
            this.searchLookUpEditUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditUser.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditUser.Size = new System.Drawing.Size(1245, 24);
            this.searchLookUpEditUser.StyleController = this.layoutControl1;
            this.searchLookUpEditUser.TabIndex = 8;
            this.searchLookUpEditUser.Popup += new System.EventHandler(this.searchLookUpEditUser_Popup);
            this.searchLookUpEditUser.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.searchLookUpEditUser_CustomDisplayText);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFIRST_NAME,
            this.colLAST_NAME,
            this.colLOGIN_NAME,
            this.colLOGIN_USER_ID});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.Click += new System.EventHandler(this.searchLookUpEdit1View_Click);
            // 
            // colFIRST_NAME
            // 
            this.colFIRST_NAME.Caption = "姓";
            this.colFIRST_NAME.FieldName = "FIRST_NAME";
            this.colFIRST_NAME.Name = "colFIRST_NAME";
            this.colFIRST_NAME.Visible = true;
            this.colFIRST_NAME.VisibleIndex = 0;
            // 
            // colLAST_NAME
            // 
            this.colLAST_NAME.Caption = "名";
            this.colLAST_NAME.FieldName = "LAST_NAME";
            this.colLAST_NAME.Name = "colLAST_NAME";
            this.colLAST_NAME.Visible = true;
            this.colLAST_NAME.VisibleIndex = 1;
            // 
            // colLOGIN_NAME
            // 
            this.colLOGIN_NAME.Caption = "用户名";
            this.colLOGIN_NAME.FieldName = "LOGIN_NAME";
            this.colLOGIN_NAME.Name = "colLOGIN_NAME";
            this.colLOGIN_NAME.Visible = true;
            this.colLOGIN_NAME.VisibleIndex = 2;
            // 
            // comboBoxEditStatus
            // 
            this.comboBoxEditStatus.Location = new System.Drawing.Point(75, 79);
            this.comboBoxEditStatus.MenuManager = this.ribbonControl1;
            this.comboBoxEditStatus.Name = "comboBoxEditStatus";
            this.comboBoxEditStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditStatus.Size = new System.Drawing.Size(1245, 24);
            this.comboBoxEditStatus.StyleController = this.layoutControl1;
            this.comboBoxEditStatus.TabIndex = 7;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(731, 40);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(589, 26);
            this.dateTimePickerEnd.TabIndex = 6;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(75, 40);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(589, 26);
            this.dateTimePickerStart.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItemUser});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1332, 120);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(656, 57);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(656, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateTimePickerStart;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(656, 39);
            this.layoutControlItem2.Text = "开始时间";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateTimePickerEnd;
            this.layoutControlItem3.Location = new System.Drawing.Point(656, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(656, 29);
            this.layoutControlItem3.Text = "结束时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.comboBoxEditStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1312, 33);
            this.layoutControlItem4.Text = "状态";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItemUser
            // 
            this.layoutControlItemUser.Control = this.searchLookUpEditUser;
            this.layoutControlItemUser.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemUser.Name = "layoutControlItemUser";
            this.layoutControlItemUser.Size = new System.Drawing.Size(1312, 28);
            this.layoutControlItemUser.Text = "负责人";
            this.layoutControlItemUser.TextSize = new System.Drawing.Size(60, 18);
            // 
            // gridControl任务
            // 
            this.gridControl任务.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl任务.Location = new System.Drawing.Point(0, 326);
            this.gridControl任务.MainView = this.gridView1;
            this.gridControl任务.MenuManager = this.ribbonControl1;
            this.gridControl任务.Name = "gridControl任务";
            this.gridControl任务.Size = new System.Drawing.Size(1332, 315);
            this.gridControl任务.TabIndex = 3;
            this.gridControl任务.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl任务;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colLOGIN_USER_ID
            // 
            this.colLOGIN_USER_ID.Caption = "LOGIN_USER_ID";
            this.colLOGIN_USER_ID.FieldName = "LOGIN_USER_ID";
            this.colLOGIN_USER_ID.Name = "colLOGIN_USER_ID";
            // 
            // Frm待办任务
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 673);
            this.Controls.Add(this.gridControl任务);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm待办任务";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Frm待办任务";
            this.Load += new System.EventHandler(this.Frm待办任务_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControl任务;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemUser;
        private DevExpress.XtraGrid.Columns.GridColumn colFIRST_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_USER_ID;
    }
}