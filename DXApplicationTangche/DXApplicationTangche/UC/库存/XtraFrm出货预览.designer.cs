namespace DXApplicationTangche.UC.库存.门店出库
{
    partial class XtraFrm出货预览
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
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.colSTYLE_PUBLISH_CATEGORY_CD = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colSYTLE_YEAR = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colSYTLE_SEASON = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colSTYLE_NAME_CN = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colMATERIAL_NAME_CN = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colId = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pivotGridControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pivotGridControl.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.colSTYLE_PUBLISH_CATEGORY_CD,
            this.colSYTLE_YEAR,
            this.colSYTLE_SEASON,
            this.colSTYLE_NAME_CN,
            this.colMATERIAL_NAME_CN,
            this.colId});
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.pivotGridControl.Size = new System.Drawing.Size(1017, 491);
            this.pivotGridControl.TabIndex = 4;
            this.pivotGridControl.TabStop = false;
            // 
            // colSTYLE_PUBLISH_CATEGORY_CD
            // 
            this.colSTYLE_PUBLISH_CATEGORY_CD.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colSTYLE_PUBLISH_CATEGORY_CD.AreaIndex = 0;
            this.colSTYLE_PUBLISH_CATEGORY_CD.Caption = "服装种类";
            this.colSTYLE_PUBLISH_CATEGORY_CD.FieldName = "STYLE_PUBLISH_CATEGORY_CD";
            this.colSTYLE_PUBLISH_CATEGORY_CD.Name = "colSTYLE_PUBLISH_CATEGORY_CD";
            this.colSTYLE_PUBLISH_CATEGORY_CD.Width = 150;
            // 
            // colSYTLE_YEAR
            // 
            this.colSYTLE_YEAR.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colSYTLE_YEAR.AreaIndex = 1;
            this.colSYTLE_YEAR.Caption = "年份";
            this.colSYTLE_YEAR.FieldName = "SYTLE_YEAR";
            this.colSYTLE_YEAR.Name = "colSYTLE_YEAR";
            // 
            // colSYTLE_SEASON
            // 
            this.colSYTLE_SEASON.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colSYTLE_SEASON.AreaIndex = 2;
            this.colSYTLE_SEASON.Caption = "季节";
            this.colSYTLE_SEASON.FieldName = "SYTLE_SEASON";
            this.colSYTLE_SEASON.Name = "colSYTLE_SEASON";
            // 
            // colSTYLE_NAME_CN
            // 
            this.colSTYLE_NAME_CN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colSTYLE_NAME_CN.AreaIndex = 3;
            this.colSTYLE_NAME_CN.Caption = "款式";
            this.colSTYLE_NAME_CN.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Name = "colSTYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Width = 300;
            // 
            // colMATERIAL_NAME_CN
            // 
            this.colMATERIAL_NAME_CN.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colMATERIAL_NAME_CN.AreaIndex = 4;
            this.colMATERIAL_NAME_CN.Caption = "面料";
            this.colMATERIAL_NAME_CN.FieldName = "MATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.Name = "colMATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.Width = 300;
            // 
            // colId
            // 
            this.colId.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colId.AreaIndex = 0;
            this.colId.Caption = "数量";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            // 
            // XtraFrm出货预览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 491);
            this.Controls.Add(this.pivotGridControl);
            this.Name = "XtraFrm出货预览";
            this.Text = "XtraFrm出货预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        private DevExpress.XtraPivotGrid.PivotGridField colSTYLE_PUBLISH_CATEGORY_CD;
        private DevExpress.XtraPivotGrid.PivotGridField colSYTLE_YEAR;
        private DevExpress.XtraPivotGrid.PivotGridField colSYTLE_SEASON;
        private DevExpress.XtraPivotGrid.PivotGridField colSTYLE_NAME_CN;
        private DevExpress.XtraPivotGrid.PivotGridField colMATERIAL_NAME_CN;
        private DevExpress.XtraPivotGrid.PivotGridField colId;
    }
}