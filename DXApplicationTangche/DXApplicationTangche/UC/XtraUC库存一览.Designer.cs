namespace DXApplicationTangche.UC
{
    partial class XtraUC库存一览
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
            this.components = new System.ComponentModel.Container();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldfuzhong = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldage = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldseason = new DevExpress.XtraPivotGrid.PivotGridField();
            this.filestyle_id = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldmianliao_no = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldamount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldchima = new DevExpress.XtraPivotGrid.PivotGridField();
            this.filedsex = new DevExpress.XtraPivotGrid.PivotGridField();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colstock_type = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colmaterial_no = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colchima = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colcreate_date = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colamount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colstyle_id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colseason = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colsex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colfuzhong = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colmianliao_no = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pivotGridControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pivotGridControl.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldfuzhong,
            this.fieldage,
            this.fieldseason,
            this.filestyle_id,
            this.fieldmianliao_no,
            this.fieldamount,
            this.fieldchima,
            this.filedsex});
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.OptionsCustomization.AllowDragInCustomizationForm = false;
            this.pivotGridControl.OptionsCustomization.AllowFilterBySummary = false;
            this.pivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Never;
            this.pivotGridControl.OptionsCustomization.AllowSortBySummary = false;
            this.pivotGridControl.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl.Size = new System.Drawing.Size(876, 197);
            this.pivotGridControl.TabIndex = 3;
            this.pivotGridControl.TabStop = false;
            this.pivotGridControl.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl_CellDoubleClick);
            // 
            // fieldfuzhong
            // 
            this.fieldfuzhong.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldfuzhong.AreaIndex = 0;
            this.fieldfuzhong.Caption = "服装品种";
            this.fieldfuzhong.FieldName = "fuzhong";
            this.fieldfuzhong.Name = "fieldfuzhong";
            // 
            // fieldage
            // 
            this.fieldage.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldage.AreaIndex = 2;
            this.fieldage.Caption = "年份";
            this.fieldage.FieldName = "age";
            this.fieldage.Name = "fieldage";
            // 
            // fieldseason
            // 
            this.fieldseason.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldseason.AreaIndex = 3;
            this.fieldseason.Caption = "季节";
            this.fieldseason.FieldName = "season";
            this.fieldseason.Name = "fieldseason";
            // 
            // filestyle_id
            // 
            this.filestyle_id.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.filestyle_id.AreaIndex = 5;
            this.filestyle_id.Caption = "款式";
            this.filestyle_id.FieldName = "style_id";
            this.filestyle_id.Name = "filestyle_id";
            this.filestyle_id.Width = 200;
            // 
            // fieldmianliao_no
            // 
            this.fieldmianliao_no.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldmianliao_no.AreaIndex = 6;
            this.fieldmianliao_no.Caption = "面料";
            this.fieldmianliao_no.FieldName = "mianliao_no";
            this.fieldmianliao_no.Name = "fieldmianliao_no";
            this.fieldmianliao_no.Width = 200;
            // 
            // fieldamount
            // 
            this.fieldamount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldamount.AreaIndex = 0;
            this.fieldamount.Caption = "数量";
            this.fieldamount.FieldName = "amount";
            this.fieldamount.Name = "fieldamount";
            // 
            // fieldchima
            // 
            this.fieldchima.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldchima.AreaIndex = 4;
            this.fieldchima.Caption = "尺码";
            this.fieldchima.FieldName = "chima";
            this.fieldchima.Name = "fieldchima";
            // 
            // filedsex
            // 
            this.filedsex.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.filedsex.AreaIndex = 1;
            this.filedsex.Caption = "性别";
            this.filedsex.FieldName = "sex";
            this.filedsex.Name = "filedsex";
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
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.ID = new System.Guid("dd0c0764-fd52-4fe2-aa4c-1a51d234acbf");
            this.dockPanel1.Location = new System.Drawing.Point(0, 197);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(876, 200);
            this.dockPanel1.Text = "库存明细账";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeList1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(868, 157);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colstock_type,
            this.colid,
            this.colmaterial_no,
            this.colchima,
            this.colcreate_date,
            this.colamount,
            this.colstyle_id,
            this.colage,
            this.colseason,
            this.colsex,
            this.colfuzhong,
            this.colmianliao_no});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(868, 157);
            this.treeList1.TabIndex = 0;
            // 
            // colstock_type
            // 
            this.colstock_type.Caption = "出入库类型";
            this.colstock_type.FieldName = "stock_type";
            this.colstock_type.Name = "colstock_type";
            this.colstock_type.Visible = true;
            this.colstock_type.VisibleIndex = 0;
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colmaterial_no
            // 
            this.colmaterial_no.Caption = "物料编码";
            this.colmaterial_no.FieldName = "material_no";
            this.colmaterial_no.Name = "colmaterial_no";
            this.colmaterial_no.Visible = true;
            this.colmaterial_no.VisibleIndex = 1;
            // 
            // colchima
            // 
            this.colchima.Caption = "尺码";
            this.colchima.FieldName = "chima";
            this.colchima.Name = "colchima";
            this.colchima.Visible = true;
            this.colchima.VisibleIndex = 2;
            // 
            // colcreate_date
            // 
            this.colcreate_date.Caption = "创建时间";
            this.colcreate_date.FieldName = "create_date";
            this.colcreate_date.Name = "colcreate_date";
            this.colcreate_date.Visible = true;
            this.colcreate_date.VisibleIndex = 3;
            // 
            // colamount
            // 
            this.colamount.Caption = "数量";
            this.colamount.FieldName = "amount";
            this.colamount.Name = "colamount";
            this.colamount.Visible = true;
            this.colamount.VisibleIndex = 4;
            // 
            // colstyle_id
            // 
            this.colstyle_id.Caption = "款式";
            this.colstyle_id.FieldName = "style_id";
            this.colstyle_id.Name = "colstyle_id";
            this.colstyle_id.Visible = true;
            this.colstyle_id.VisibleIndex = 5;
            // 
            // colage
            // 
            this.colage.Caption = "年份";
            this.colage.FieldName = "age";
            this.colage.Name = "colage";
            this.colage.Visible = true;
            this.colage.VisibleIndex = 6;
            // 
            // colseason
            // 
            this.colseason.Caption = "季节";
            this.colseason.FieldName = "season";
            this.colseason.Name = "colseason";
            this.colseason.Visible = true;
            this.colseason.VisibleIndex = 7;
            // 
            // colsex
            // 
            this.colsex.Caption = "性别";
            this.colsex.FieldName = "sex";
            this.colsex.Name = "colsex";
            this.colsex.Visible = true;
            this.colsex.VisibleIndex = 8;
            // 
            // colfuzhong
            // 
            this.colfuzhong.Caption = "服装种类";
            this.colfuzhong.FieldName = "fuzhong";
            this.colfuzhong.Name = "colfuzhong";
            this.colfuzhong.Visible = true;
            this.colfuzhong.VisibleIndex = 9;
            // 
            // colmianliao_no
            // 
            this.colmianliao_no.Caption = "面料号";
            this.colmianliao_no.FieldName = "mianliao_no";
            this.colmianliao_no.Name = "colmianliao_no";
            this.colmianliao_no.Visible = true;
            this.colmianliao_no.VisibleIndex = 10;
            // 
            // XtraUC库存一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl);
            this.Controls.Add(this.dockPanel1);
            this.Name = "XtraUC库存一览";
            this.Size = new System.Drawing.Size(876, 397);
            this.Load += new System.EventHandler(this.XtraUC库存一览_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        private DevExpress.XtraPivotGrid.PivotGridField fieldfuzhong;
        private DevExpress.XtraPivotGrid.PivotGridField fieldage;
        private DevExpress.XtraPivotGrid.PivotGridField fieldseason;
        private DevExpress.XtraPivotGrid.PivotGridField filestyle_id;
        private DevExpress.XtraPivotGrid.PivotGridField fieldmianliao_no;
        private DevExpress.XtraPivotGrid.PivotGridField fieldamount;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldchima;
        private DevExpress.XtraPivotGrid.PivotGridField filedsex;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colstock_type;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colmaterial_no;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colchima;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colcreate_date;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colamount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colstyle_id;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colseason;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colsex;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colfuzhong;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colmianliao_no;
    }
}
