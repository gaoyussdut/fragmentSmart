namespace DXApplicationTangche
{
    partial class Frm更改尺寸测
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colitemcd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpropertyvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfit_value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemnamecn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemfitvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coloutvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(776, 426);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colitemcd,
            this.colitemvalue,
            this.colpropertyvalue,
            this.colfit_value,
            this.colitemnamecn,
            this.colitemfitvalue,
            this.colinvalue,
            this.coloutvalue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colitemcd
            // 
            this.colitemcd.Caption = "ITEM_CD";
            this.colitemcd.FieldName = "ITEM_CD";
            this.colitemcd.Name = "colitemcd";
            this.colitemcd.Visible = true;
            this.colitemcd.VisibleIndex = 0;
            // 
            // colitemvalue
            // 
            this.colitemvalue.Caption = "ITEM_VALUE";
            this.colitemvalue.FieldName = "ITEM_VALUE";
            this.colitemvalue.Name = "colitemvalue";
            this.colitemvalue.Visible = true;
            this.colitemvalue.VisibleIndex = 1;
            // 
            // colpropertyvalue
            // 
            this.colpropertyvalue.Caption = "PROPERTY_VALUE";
            this.colpropertyvalue.FieldName = "PROPERTY_VALUE";
            this.colpropertyvalue.Name = "colpropertyvalue";
            this.colpropertyvalue.Visible = true;
            this.colpropertyvalue.VisibleIndex = 2;
            // 
            // colfit_value
            // 
            this.colfit_value.Caption = "FIT_VALUE";
            this.colfit_value.FieldName = "FIT_VALUE";
            this.colfit_value.Name = "colfit_value";
            this.colfit_value.Visible = true;
            this.colfit_value.VisibleIndex = 3;
            // 
            // colitemnamecn
            // 
            this.colitemnamecn.Caption = "尺寸类别";
            this.colitemnamecn.FieldName = "ITEM_NAME_CN";
            this.colitemnamecn.Name = "colitemnamecn";
            this.colitemnamecn.Visible = true;
            this.colitemnamecn.VisibleIndex = 7;
            // 
            // colitemfitvalue
            // 
            this.colitemfitvalue.Caption = "尺寸";
            this.colitemfitvalue.FieldName = "ITEM_FIT_VALUE";
            this.colitemfitvalue.Name = "colitemfitvalue";
            this.colitemfitvalue.Visible = true;
            this.colitemfitvalue.VisibleIndex = 4;
            // 
            // colinvalue
            // 
            this.colinvalue.Caption = "加";
            this.colinvalue.FieldName = "IN_VALUE";
            this.colinvalue.Name = "colinvalue";
            this.colinvalue.Visible = true;
            this.colinvalue.VisibleIndex = 5;
            // 
            // coloutvalue
            // 
            this.coloutvalue.Caption = "减";
            this.coloutvalue.FieldName = "OUT_VALUE";
            this.coloutvalue.Name = "coloutvalue";
            this.coloutvalue.Visible = true;
            this.coloutvalue.VisibleIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 430);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Frm更改尺寸测
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm更改尺寸测";
            this.Text = "Frm更改尺寸测";
            this.Load += new System.EventHandler(this.Frm更改尺寸测_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colitemcd;
        private DevExpress.XtraGrid.Columns.GridColumn colitemvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colpropertyvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colfit_value;
        private DevExpress.XtraGrid.Columns.GridColumn colitemnamecn;
        private DevExpress.XtraGrid.Columns.GridColumn colitemfitvalue;
        private DevExpress.XtraGrid.Columns.GridColumn colinvalue;
        private DevExpress.XtraGrid.Columns.GridColumn coloutvalue;
    }
}