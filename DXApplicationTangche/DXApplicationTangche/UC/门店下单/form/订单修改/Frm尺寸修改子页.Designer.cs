namespace DXApplicationTangche.UC.门店下单.form.订单修改
{
    partial class Frm尺寸修改子页
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm尺寸修改子页));
            this.gridControlSize = new DevExpress.XtraGrid.GridControl();
            this.gridViewSize = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colitemcd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpropertyvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfit_value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemnamecn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemfitvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coloutvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colleast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGarment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlSize
            // 
            this.gridControlSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSize.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlSize.Location = new System.Drawing.Point(0, 75);
            this.gridControlSize.MainView = this.gridViewSize;
            this.gridControlSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlSize.Name = "gridControlSize";
            this.gridControlSize.Size = new System.Drawing.Size(1086, 395);
            this.gridControlSize.TabIndex = 7;
            this.gridControlSize.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSize});
            // 
            // gridViewSize
            // 
            this.gridViewSize.Appearance.Row.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gridViewSize.Appearance.Row.Options.UseBackColor = true;
            this.gridViewSize.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
            this.gridViewSize.AppearancePrint.Row.Options.UseBackColor = true;
            this.gridViewSize.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colitemcd,
            this.colitemvalue,
            this.colpropertyvalue,
            this.colfit_value,
            this.colitemnamecn,
            this.colitemfitvalue,
            this.colinvalue,
            this.coloutvalue,
            this.colmax,
            this.colleast,
            this.colGarment});
            this.gridViewSize.DetailHeight = 450;
            this.gridViewSize.FixedLineWidth = 3;
            this.gridViewSize.GridControl = this.gridControlSize;
            this.gridViewSize.Name = "gridViewSize";
            this.gridViewSize.OptionsCustomization.AllowSort = false;
            this.gridViewSize.OptionsView.ShowGroupPanel = false;
            this.gridViewSize.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewSize_CustomDrawCell);
            this.gridViewSize.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewSize_CellValueChanged);
            // 
            // colitemcd
            // 
            this.colitemcd.Caption = "ITEM_CD";
            this.colitemcd.FieldName = "ITEM_CD";
            this.colitemcd.MinWidth = 23;
            this.colitemcd.Name = "colitemcd";
            this.colitemcd.Width = 86;
            // 
            // colitemvalue
            // 
            this.colitemvalue.Caption = "ITEM_VALUE";
            this.colitemvalue.FieldName = "ITEM_VALUE";
            this.colitemvalue.MinWidth = 23;
            this.colitemvalue.Name = "colitemvalue";
            this.colitemvalue.Width = 86;
            // 
            // colpropertyvalue
            // 
            this.colpropertyvalue.Caption = "PROPERTY_VALUE";
            this.colpropertyvalue.FieldName = "PROPERTY_VALUE";
            this.colpropertyvalue.MinWidth = 23;
            this.colpropertyvalue.Name = "colpropertyvalue";
            this.colpropertyvalue.Width = 86;
            // 
            // colfit_value
            // 
            this.colfit_value.Caption = "FIT_VALUE";
            this.colfit_value.FieldName = "FIT_VALUE";
            this.colfit_value.MinWidth = 23;
            this.colfit_value.Name = "colfit_value";
            this.colfit_value.Width = 86;
            // 
            // colitemnamecn
            // 
            this.colitemnamecn.Caption = "尺寸类别";
            this.colitemnamecn.FieldName = "ITEM_NAME_CN";
            this.colitemnamecn.MinWidth = 23;
            this.colitemnamecn.Name = "colitemnamecn";
            this.colitemnamecn.OptionsColumn.AllowEdit = false;
            this.colitemnamecn.OptionsColumn.ReadOnly = true;
            this.colitemnamecn.Visible = true;
            this.colitemnamecn.VisibleIndex = 0;
            this.colitemnamecn.Width = 86;
            // 
            // colitemfitvalue
            // 
            this.colitemfitvalue.Caption = "尺寸";
            this.colitemfitvalue.FieldName = "ITEM_FIT_VALUE";
            this.colitemfitvalue.MinWidth = 23;
            this.colitemfitvalue.Name = "colitemfitvalue";
            this.colitemfitvalue.OptionsColumn.AllowEdit = false;
            this.colitemfitvalue.OptionsColumn.ReadOnly = true;
            this.colitemfitvalue.Visible = true;
            this.colitemfitvalue.VisibleIndex = 1;
            this.colitemfitvalue.Width = 86;
            // 
            // colinvalue
            // 
            this.colinvalue.Caption = "加";
            this.colinvalue.FieldName = "IN_VALUE";
            this.colinvalue.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colinvalue.ImageOptions.Image")));
            this.colinvalue.MinWidth = 23;
            this.colinvalue.Name = "colinvalue";
            this.colinvalue.Visible = true;
            this.colinvalue.VisibleIndex = 2;
            this.colinvalue.Width = 86;
            // 
            // coloutvalue
            // 
            this.coloutvalue.Caption = "减";
            this.coloutvalue.FieldName = "OUT_VALUE";
            this.coloutvalue.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("coloutvalue.ImageOptions.Image")));
            this.coloutvalue.MinWidth = 23;
            this.coloutvalue.Name = "coloutvalue";
            this.coloutvalue.Visible = true;
            this.coloutvalue.VisibleIndex = 3;
            this.coloutvalue.Width = 86;
            // 
            // colmax
            // 
            this.colmax.Caption = "合理大";
            this.colmax.FieldName = "maxReasonable";
            this.colmax.MinWidth = 23;
            this.colmax.Name = "colmax";
            this.colmax.OptionsColumn.AllowEdit = false;
            this.colmax.OptionsColumn.ReadOnly = true;
            this.colmax.Visible = true;
            this.colmax.VisibleIndex = 4;
            this.colmax.Width = 86;
            // 
            // colleast
            // 
            this.colleast.Caption = "合理小";
            this.colleast.FieldName = "leastReasonable";
            this.colleast.MinWidth = 23;
            this.colleast.Name = "colleast";
            this.colleast.OptionsColumn.AllowEdit = false;
            this.colleast.OptionsColumn.ReadOnly = true;
            this.colleast.Visible = true;
            this.colleast.VisibleIndex = 5;
            this.colleast.Width = 86;
            // 
            // colGarment
            // 
            this.colGarment.Caption = "成衣尺寸";
            this.colGarment.FieldName = "garmentSize";
            this.colGarment.MinWidth = 23;
            this.colGarment.Name = "colGarment";
            this.colGarment.OptionsColumn.AllowEdit = false;
            this.colGarment.OptionsColumn.ReadOnly = true;
            this.colGarment.Visible = true;
            this.colGarment.VisibleIndex = 6;
            this.colGarment.Width = 86;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "保存";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
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
            this.ribbonControl1.Size = new System.Drawing.Size(1086, 75);
            // 
            // Frm尺寸修改子页
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 470);
            this.Controls.Add(this.gridControlSize);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Frm尺寸修改子页";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Frm尺寸修改子页";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlSize;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSize;
        private DevExpress.XtraGrid.Columns.GridColumn colitemcd;
        private DevExpress.XtraGrid.Columns.GridColumn colitemvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colpropertyvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colfit_value;
        private DevExpress.XtraGrid.Columns.GridColumn colitemnamecn;
        private DevExpress.XtraGrid.Columns.GridColumn colitemfitvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colinvalue;
        private DevExpress.XtraGrid.Columns.GridColumn coloutvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colmax;
        private DevExpress.XtraGrid.Columns.GridColumn colleast;
        private DevExpress.XtraGrid.Columns.GridColumn colGarment;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}