namespace DXApplicationTangche
{
    partial class Frm打标
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
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colstyle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiaomaid = new System.Windows.Forms.TextBox();
            this.shopname = new System.Windows.Forms.ComboBox();
            this.stylename = new System.Windows.Forms.TextBox();
            this.chicun01 = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSizeNameCn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mianliaocd = new System.Windows.Forms.TextBox();
            this.chengfan = new System.Windows.Forms.TextBox();
            this.shoujia = new System.Windows.Forms.TextBox();
            this.mianliaoid = new System.Windows.Forms.TextBox();
            this.styleid = new System.Windows.Forms.TextBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.tiaomaid);
            this.layoutControl1.Controls.Add(this.shopname);
            this.layoutControl1.Controls.Add(this.stylename);
            this.layoutControl1.Controls.Add(this.chicun01);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.mianliaocd);
            this.layoutControl1.Controls.Add(this.chengfan);
            this.layoutControl1.Controls.Add(this.shoujia);
            this.layoutControl1.Controls.Add(this.mianliaoid);
            this.layoutControl1.Controls.Add(this.styleid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(933, 525);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(584, 36);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(337, 477);
            this.gridControl2.TabIndex = 17;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colstyle,
            this.colvalue});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // colstyle
            // 
            this.colstyle.Caption = "类型";
            this.colstyle.FieldName = "style";
            this.colstyle.Name = "colstyle";
            this.colstyle.Visible = true;
            this.colstyle.VisibleIndex = 0;
            // 
            // colvalue
            // 
            this.colvalue.Caption = "值";
            this.colvalue.FieldName = "value";
            this.colvalue.Name = "colvalue";
            this.colvalue.Visible = true;
            this.colvalue.VisibleIndex = 1;
            // 
            // tiaomaid
            // 
            this.tiaomaid.Location = new System.Drawing.Point(635, 12);
            this.tiaomaid.Name = "tiaomaid";
            this.tiaomaid.Size = new System.Drawing.Size(286, 20);
            this.tiaomaid.TabIndex = 16;
            this.tiaomaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // shopname
            // 
            this.shopname.FormattingEnabled = true;
            this.shopname.Location = new System.Drawing.Point(63, 133);
            this.shopname.Name = "shopname";
            this.shopname.Size = new System.Drawing.Size(454, 22);
            this.shopname.TabIndex = 15;
            // 
            // stylename
            // 
            this.stylename.Location = new System.Drawing.Point(63, 36);
            this.stylename.Name = "stylename";
            this.stylename.Size = new System.Drawing.Size(454, 20);
            this.stylename.TabIndex = 14;
            // 
            // chicun01
            // 
            this.chicun01.FormattingEnabled = true;
            this.chicun01.Location = new System.Drawing.Point(63, 60);
            this.chicun01.Name = "chicun01";
            this.chicun01.Size = new System.Drawing.Size(454, 22);
            this.chicun01.TabIndex = 12;
            this.chicun01.SelectedIndexChanged += new System.EventHandler(this.chicun01_SelectedIndexChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(12, 484);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(505, 29);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "打印";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 206);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(505, 274);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSizeNameCn,
            this.colSize});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colSizeNameCn
            // 
            this.colSizeNameCn.Caption = "尺寸名";
            this.colSizeNameCn.FieldName = "ITEM_NAME_CN";
            this.colSizeNameCn.Name = "colSizeNameCn";
            this.colSizeNameCn.Visible = true;
            this.colSizeNameCn.VisibleIndex = 0;
            // 
            // colSize
            // 
            this.colSize.Caption = "尺寸";
            this.colSize.FieldName = "ITEM_FIT_VALUE";
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 1;
            // 
            // mianliaocd
            // 
            this.mianliaocd.Location = new System.Drawing.Point(63, 109);
            this.mianliaocd.Name = "mianliaocd";
            this.mianliaocd.Size = new System.Drawing.Size(454, 20);
            this.mianliaocd.TabIndex = 9;
            // 
            // chengfan
            // 
            this.chengfan.Location = new System.Drawing.Point(63, 158);
            this.chengfan.Name = "chengfan";
            this.chengfan.Size = new System.Drawing.Size(454, 20);
            this.chengfan.TabIndex = 8;
            // 
            // shoujia
            // 
            this.shoujia.Location = new System.Drawing.Point(63, 182);
            this.shoujia.Name = "shoujia";
            this.shoujia.ReadOnly = true;
            this.shoujia.Size = new System.Drawing.Size(454, 20);
            this.shoujia.TabIndex = 7;
            // 
            // mianliaoid
            // 
            this.mianliaoid.Location = new System.Drawing.Point(63, 85);
            this.mianliaoid.Name = "mianliaoid";
            this.mianliaoid.Size = new System.Drawing.Size(454, 20);
            this.mianliaoid.TabIndex = 5;
            this.mianliaoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mianliaoid_KeyDown);
            // 
            // styleid
            // 
            this.styleid.Location = new System.Drawing.Point(63, 12);
            this.styleid.Name = "styleid";
            this.styleid.Size = new System.Drawing.Size(454, 20);
            this.styleid.TabIndex = 4;
            this.styleid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.styleid_KeyDown);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.emptySpaceItem2,
            this.layoutControlItem9,
            this.layoutControlItem12});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(933, 525);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.styleid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem1.Text = "styleid";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.mianliaoid;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem2.Text = "面料id";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.shoujia;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 170);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem4.Text = "售价";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chengfan;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 146);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem5.Text = "成分";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.mianliaocd;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem6.Text = "面料号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridControl1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 194);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(509, 278);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.simpleButton1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 472);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(509, 33);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chicun01;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(509, 25);
            this.layoutControlItem3.Text = "尺寸";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.stylename;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(509, 24);
            this.layoutControlItem10.Text = "款式名称";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.shopname;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(509, 25);
            this.layoutControlItem11.Text = "店铺";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(509, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(63, 505);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.tiaomaid;
            this.layoutControlItem9.Location = new System.Drawing.Point(572, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(341, 24);
            this.layoutControlItem9.Text = "条码id";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gridControl2;
            this.layoutControlItem12.Location = new System.Drawing.Point(572, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(341, 481);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // Frm打标
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm打标";
            this.Text = "Frm打标";
            this.Load += new System.EventHandler(this.Frm打标_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox mianliaocd;
        private System.Windows.Forms.TextBox chengfan;
        private System.Windows.Forms.TextBox shoujia;
        private System.Windows.Forms.TextBox mianliaoid;
        private System.Windows.Forms.TextBox styleid;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.ComboBox chicun01;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colSizeNameCn;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private System.Windows.Forms.TextBox stylename;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private System.Windows.Forms.ComboBox shopname;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.TextBox tiaomaid;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraGrid.Columns.GridColumn colstyle;
        private DevExpress.XtraGrid.Columns.GridColumn colvalue;
    }
}