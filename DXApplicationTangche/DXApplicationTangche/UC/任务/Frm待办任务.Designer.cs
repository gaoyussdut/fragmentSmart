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
            this.gridControl任务 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colORDER_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCUSTOMER_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCUSTOMER_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colORDER_STATUS_CD_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSHIPPING_DESTINATION = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTEMPLATE_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSTYLE_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colREF_STYLE_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSTYLE_NAME_CN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSTATUS_ITEM_NAME_CN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCREATE_DATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUSER_NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
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
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
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
            // gridControl任务
            // 
            this.gridControl任务.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl任务.Location = new System.Drawing.Point(0, 206);
            this.gridControl任务.MainView = this.bandedGridView1;
            this.gridControl任务.MenuManager = this.ribbonControl1;
            this.gridControl任务.Name = "gridControl任务";
            this.gridControl任务.Size = new System.Drawing.Size(1332, 435);
            this.gridControl任务.TabIndex = 3;
            this.gridControl任务.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID,
            this.colORDER_ID,
            this.colCUSTOMER_ID,
            this.colCUSTOMER_NAME,
            this.colSHIPPING_DESTINATION,
            this.colORDER_STATUS_CD_NAME,
            this.colTEMPLATE_ID,
            this.colSTYLE_ID,
            this.colSTYLE_NAME_CN,
            this.colREF_STYLE_ID,
            this.colCREATE_DATE,
            this.colUSER_NAME,
            this.colSTATUS_ITEM_NAME_CN});
            this.bandedGridView1.GridControl = this.gridControl任务;
            this.bandedGridView1.GroupCount = 1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSTATUS_ITEM_NAME_CN, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.Silver;
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.Caption = "订单状态";
            this.gridBand1.Columns.Add(this.colID);
            this.gridBand1.Columns.Add(this.colORDER_ID);
            this.gridBand1.Columns.Add(this.colCUSTOMER_ID);
            this.gridBand1.Columns.Add(this.colCUSTOMER_NAME);
            this.gridBand1.Columns.Add(this.colORDER_STATUS_CD_NAME);
            this.gridBand1.Columns.Add(this.colSHIPPING_DESTINATION);
            this.gridBand1.Columns.Add(this.colTEMPLATE_ID);
            this.gridBand1.Columns.Add(this.colSTYLE_ID);
            this.gridBand1.Columns.Add(this.colREF_STYLE_ID);
            this.gridBand1.MinWidth = 17;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 485;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 788;
            this.colID.Name = "colID";
            this.colID.Width = 805;
            // 
            // colORDER_ID
            // 
            this.colORDER_ID.Caption = "ORDER_ID";
            this.colORDER_ID.FieldName = "ORDER_ID";
            this.colORDER_ID.MinWidth = 788;
            this.colORDER_ID.Name = "colORDER_ID";
            this.colORDER_ID.Width = 805;
            // 
            // colCUSTOMER_ID
            // 
            this.colCUSTOMER_ID.Caption = "CUSTOMER_ID";
            this.colCUSTOMER_ID.FieldName = "CUSTOMER_ID";
            this.colCUSTOMER_ID.MinWidth = 59;
            this.colCUSTOMER_ID.Name = "colCUSTOMER_ID";
            this.colCUSTOMER_ID.Width = 223;
            // 
            // colCUSTOMER_NAME
            // 
            this.colCUSTOMER_NAME.Caption = "客户名称";
            this.colCUSTOMER_NAME.FieldName = "CUSTOMER_NAME";
            this.colCUSTOMER_NAME.MinWidth = 59;
            this.colCUSTOMER_NAME.Name = "colCUSTOMER_NAME";
            this.colCUSTOMER_NAME.Visible = true;
            this.colCUSTOMER_NAME.Width = 104;
            // 
            // colORDER_STATUS_CD_NAME
            // 
            this.colORDER_STATUS_CD_NAME.Caption = "订单状态";
            this.colORDER_STATUS_CD_NAME.FieldName = "ORDER_STATUS_CD_NAME";
            this.colORDER_STATUS_CD_NAME.MinWidth = 59;
            this.colORDER_STATUS_CD_NAME.Name = "colORDER_STATUS_CD_NAME";
            this.colORDER_STATUS_CD_NAME.Visible = true;
            this.colORDER_STATUS_CD_NAME.Width = 91;
            // 
            // colSHIPPING_DESTINATION
            // 
            this.colSHIPPING_DESTINATION.Caption = "送货地址";
            this.colSHIPPING_DESTINATION.FieldName = "SHIPPING_DESTINATION";
            this.colSHIPPING_DESTINATION.MinWidth = 59;
            this.colSHIPPING_DESTINATION.Name = "colSHIPPING_DESTINATION";
            this.colSHIPPING_DESTINATION.Visible = true;
            this.colSHIPPING_DESTINATION.Width = 290;
            // 
            // colTEMPLATE_ID
            // 
            this.colTEMPLATE_ID.Caption = "TEMPLATE_ID";
            this.colTEMPLATE_ID.FieldName = "TEMPLATE_ID";
            this.colTEMPLATE_ID.MinWidth = 59;
            this.colTEMPLATE_ID.Name = "colTEMPLATE_ID";
            this.colTEMPLATE_ID.Width = 223;
            // 
            // colSTYLE_ID
            // 
            this.colSTYLE_ID.Caption = "STYLE_ID";
            this.colSTYLE_ID.FieldName = "STYLE_ID";
            this.colSTYLE_ID.MinWidth = 59;
            this.colSTYLE_ID.Name = "colSTYLE_ID";
            this.colSTYLE_ID.Width = 223;
            // 
            // colREF_STYLE_ID
            // 
            this.colREF_STYLE_ID.Caption = "REF_STYLE_ID";
            this.colREF_STYLE_ID.FieldName = "REF_STYLE_ID";
            this.colREF_STYLE_ID.MinWidth = 59;
            this.colREF_STYLE_ID.Name = "colREF_STYLE_ID";
            this.colREF_STYLE_ID.Width = 223;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.BackColor = System.Drawing.Color.Yellow;
            this.gridBand2.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand2.Caption = "款式信息";
            this.gridBand2.Columns.Add(this.colSTYLE_NAME_CN);
            this.gridBand2.MinWidth = 13;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 136;
            // 
            // colSTYLE_NAME_CN
            // 
            this.colSTYLE_NAME_CN.Caption = "款式名称";
            this.colSTYLE_NAME_CN.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN.MinWidth = 59;
            this.colSTYLE_NAME_CN.Name = "colSTYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Visible = true;
            this.colSTYLE_NAME_CN.Width = 136;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.BackColor = System.Drawing.Color.Aqua;
            this.gridBand3.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand3.Caption = "任务状态";
            this.gridBand3.Columns.Add(this.colSTATUS_ITEM_NAME_CN);
            this.gridBand3.Columns.Add(this.colCREATE_DATE);
            this.gridBand3.Columns.Add(this.colUSER_NAME);
            this.gridBand3.MinWidth = 13;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 410;
            // 
            // colSTATUS_ITEM_NAME_CN
            // 
            this.colSTATUS_ITEM_NAME_CN.Caption = "任务状态";
            this.colSTATUS_ITEM_NAME_CN.FieldName = "STATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.MinWidth = 59;
            this.colSTATUS_ITEM_NAME_CN.Name = "colSTATUS_ITEM_NAME_CN";
            this.colSTATUS_ITEM_NAME_CN.Visible = true;
            this.colSTATUS_ITEM_NAME_CN.Width = 104;
            // 
            // colCREATE_DATE
            // 
            this.colCREATE_DATE.Caption = "任务指派时间";
            this.colCREATE_DATE.FieldName = "CREATE_DATE";
            this.colCREATE_DATE.MinWidth = 59;
            this.colCREATE_DATE.Name = "colCREATE_DATE";
            this.colCREATE_DATE.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colCREATE_DATE.Visible = true;
            this.colCREATE_DATE.Width = 118;
            // 
            // colUSER_NAME
            // 
            this.colUSER_NAME.Caption = "任务指派人";
            this.colUSER_NAME.FieldName = "USER_NAME";
            this.colUSER_NAME.MinWidth = 59;
            this.colUSER_NAME.Name = "colUSER_NAME";
            this.colUSER_NAME.Visible = true;
            this.colUSER_NAME.Width = 188;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.Red;
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.Caption = "异常标签";
            this.gridBand4.MinWidth = 13;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 268;
            // 
            // Frm待办任务
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 673);
            this.Controls.Add(this.gridControl任务);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm待办任务";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Frm待办任务";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm待办任务_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl任务)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl任务;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colORDER_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCUSTOMER_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCUSTOMER_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colORDER_STATUS_CD_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSHIPPING_DESTINATION;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTEMPLATE_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTYLE_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colREF_STYLE_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTYLE_NAME_CN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTATUS_ITEM_NAME_CN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCREATE_DATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUSER_NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}