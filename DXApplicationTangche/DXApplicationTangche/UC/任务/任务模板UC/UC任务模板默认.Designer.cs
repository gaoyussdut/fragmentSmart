namespace DXApplicationTangche.UC.门店下单.form.订单修改.任务模板UC
{
    partial class UC任务模板默认
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl任务模板 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookUpEditUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem负责人 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.colFIRST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_USER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl任务模板)).BeginInit();
            this.layoutControl任务模板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem负责人)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl任务模板
            // 
            this.layoutControl任务模板.Controls.Add(this.searchLookUpEditUser);
            this.layoutControl任务模板.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl任务模板.Location = new System.Drawing.Point(0, 0);
            this.layoutControl任务模板.Name = "layoutControl任务模板";
            this.layoutControl任务模板.Root = this.Root;
            this.layoutControl任务模板.Size = new System.Drawing.Size(728, 524);
            this.layoutControl任务模板.TabIndex = 0;
            this.layoutControl任务模板.Text = "layoutControl1";
            // 
            // searchLookUpEditUser
            // 
            this.searchLookUpEditUser.EditValue = "";
            this.searchLookUpEditUser.Location = new System.Drawing.Point(60, 12);
            this.searchLookUpEditUser.Name = "searchLookUpEditUser";
            this.searchLookUpEditUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditUser.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditUser.Size = new System.Drawing.Size(656, 24);
            this.searchLookUpEditUser.StyleController = this.layoutControl任务模板;
            this.searchLookUpEditUser.TabIndex = 4;
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
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem负责人,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(728, 524);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem负责人
            // 
            this.layoutControlItem负责人.Control = this.searchLookUpEditUser;
            this.layoutControlItem负责人.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem负责人.Name = "layoutControlItem负责人";
            this.layoutControlItem负责人.Size = new System.Drawing.Size(708, 28);
            this.layoutControlItem负责人.Text = "负责人";
            this.layoutControlItem负责人.TextSize = new System.Drawing.Size(45, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(708, 476);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            // colLOGIN_USER_ID
            // 
            this.colLOGIN_USER_ID.Caption = "LOGIN_USER_ID";
            this.colLOGIN_USER_ID.FieldName = "LOGIN_USER_ID";
            this.colLOGIN_USER_ID.Name = "colLOGIN_USER_ID";
            // 
            // UC任务模板默认
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl任务模板);
            this.Name = "UC任务模板默认";
            this.Size = new System.Drawing.Size(728, 524);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl任务模板)).EndInit();
            this.layoutControl任务模板.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem负责人)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl任务模板;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem负责人;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colFIRST_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_USER_ID;
    }
}
