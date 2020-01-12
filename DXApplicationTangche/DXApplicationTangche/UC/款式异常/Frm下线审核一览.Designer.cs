namespace DXApplicationTangche.UC.款式异常
{
    partial class Frm下线审核一览
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
            this.gridControl待办 = new DevExpress.XtraGrid.GridControl();
            this.gridView待办 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSYS_STYLE_ID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_PUBLISH_CATEGORY_CD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_YEAR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_SEASON1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl待办)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView待办)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl待办
            // 
            this.gridControl待办.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl待办.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl待办.Location = new System.Drawing.Point(0, 0);
            this.gridControl待办.MainView = this.gridView待办;
            this.gridControl待办.Name = "gridControl待办";
            this.gridControl待办.Size = new System.Drawing.Size(1185, 421);
            this.gridControl待办.TabIndex = 2;
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
            // Frm下线审核一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 421);
            this.Controls.Add(this.gridControl待办);
            this.Name = "Frm下线审核一览";
            this.Text = "Frm下线审核一览";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl待办)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView待办)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl待办;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView待办;
        private DevExpress.XtraGrid.Columns.GridColumn colSYS_STYLE_ID1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_PUBLISH_CATEGORY_CD1;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_YEAR1;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_SEASON1;
    }
}