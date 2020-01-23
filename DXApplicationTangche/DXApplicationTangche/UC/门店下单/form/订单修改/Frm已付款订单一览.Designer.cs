namespace DXApplicationTangche.UC.门店下单.form
{
    partial class Frm已付款订单一览
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl订单一览)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl订单一览
            // 
            this.gridControl订单一览.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl订单一览.Location = new System.Drawing.Point(0, 0);
            this.gridControl订单一览.MainView = this.gridView1;
            this.gridControl订单一览.Name = "gridControl订单一览";
            this.gridControl订单一览.Size = new System.Drawing.Size(1243, 462);
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
            this.colSTYLE_FIT_CD});
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
            this.colORDER_DATE.Visible = true;
            this.colORDER_DATE.VisibleIndex = 4;
            this.colORDER_DATE.Width = 94;
            // 
            // colPAYMENT_DATE
            // 
            this.colPAYMENT_DATE.Caption = "付款时间";
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
            // Frm已付款订单一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 462);
            this.Controls.Add(this.gridControl订单一览);
            this.Name = "Frm已付款订单一览";
            this.Text = "Frm已付款订单一览";
            this.Load += new System.EventHandler(this.Frm已付款订单一览_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl订单一览)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
    }
}