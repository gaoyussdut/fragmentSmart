namespace DXApplicationTangche.UC.门店下单.form.标准款
{
    partial class Frm扫码下单
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colshop_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshop_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYS_STYLE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_PUBLISH_CATEGORY_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_YEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYTLE_SEASON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTYLE_SIZE_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1071, 496);
            this.tablePanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 1);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(92, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(976, 464);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colshop_id,
            this.colshop_name,
            this.colSYS_STYLE_ID,
            this.colSTYLE_PUBLISH_CATEGORY_CD,
            this.colSTYLE_NAME_CN,
            this.colSYTLE_YEAR,
            this.colSYTLE_SEASON,
            this.colSTYLE_SIZE_CD,
            this.colMATERIAL_ID,
            this.colMATERIAL_NAME_CN,
            this.col});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colshop_id
            // 
            this.colshop_id.Caption = "shop_id";
            this.colshop_id.FieldName = "shop_id";
            this.colshop_id.MinWidth = 25;
            this.colshop_id.Name = "colshop_id";
            this.colshop_id.Width = 94;
            // 
            // colshop_name
            // 
            this.colshop_name.Caption = "店名";
            this.colshop_name.FieldName = "shop_name";
            this.colshop_name.MinWidth = 25;
            this.colshop_name.Name = "colshop_name";
            this.colshop_name.Visible = true;
            this.colshop_name.VisibleIndex = 0;
            this.colshop_name.Width = 94;
            // 
            // colSYS_STYLE_ID
            // 
            this.colSYS_STYLE_ID.Caption = "SYS_STYLE_ID";
            this.colSYS_STYLE_ID.FieldName = "SYS_STYLE_ID";
            this.colSYS_STYLE_ID.MinWidth = 25;
            this.colSYS_STYLE_ID.Name = "colSYS_STYLE_ID";
            this.colSYS_STYLE_ID.Width = 94;
            // 
            // colSTYLE_NAME_CN
            // 
            this.colSTYLE_NAME_CN.Caption = "款名";
            this.colSTYLE_NAME_CN.FieldName = "STYLE_NAME_CN";
            this.colSTYLE_NAME_CN.MinWidth = 25;
            this.colSTYLE_NAME_CN.Name = "colSTYLE_NAME_CN";
            this.colSTYLE_NAME_CN.Visible = true;
            this.colSTYLE_NAME_CN.VisibleIndex = 2;
            this.colSTYLE_NAME_CN.Width = 94;
            // 
            // colSTYLE_PUBLISH_CATEGORY_CD
            // 
            this.colSTYLE_PUBLISH_CATEGORY_CD.Caption = "服装种类";
            this.colSTYLE_PUBLISH_CATEGORY_CD.FieldName = "STYLE_PUBLISH_CATEGORY_CD";
            this.colSTYLE_PUBLISH_CATEGORY_CD.MinWidth = 25;
            this.colSTYLE_PUBLISH_CATEGORY_CD.Name = "colSTYLE_PUBLISH_CATEGORY_CD";
            this.colSTYLE_PUBLISH_CATEGORY_CD.Visible = true;
            this.colSTYLE_PUBLISH_CATEGORY_CD.VisibleIndex = 1;
            this.colSTYLE_PUBLISH_CATEGORY_CD.Width = 94;
            // 
            // colSYTLE_YEAR
            // 
            this.colSYTLE_YEAR.Caption = "年份";
            this.colSYTLE_YEAR.FieldName = "SYTLE_YEAR";
            this.colSYTLE_YEAR.MinWidth = 25;
            this.colSYTLE_YEAR.Name = "colSYTLE_YEAR";
            this.colSYTLE_YEAR.Visible = true;
            this.colSYTLE_YEAR.VisibleIndex = 3;
            this.colSYTLE_YEAR.Width = 94;
            // 
            // colSYTLE_SEASON
            // 
            this.colSYTLE_SEASON.Caption = "季节";
            this.colSYTLE_SEASON.FieldName = "SYTLE_SEASON";
            this.colSYTLE_SEASON.MinWidth = 25;
            this.colSYTLE_SEASON.Name = "colSYTLE_SEASON";
            this.colSYTLE_SEASON.Visible = true;
            this.colSYTLE_SEASON.VisibleIndex = 4;
            this.colSYTLE_SEASON.Width = 94;
            // 
            // colSTYLE_SIZE_CD
            // 
            this.colSTYLE_SIZE_CD.Caption = "尺码";
            this.colSTYLE_SIZE_CD.FieldName = "STYLE_SIZE_CD";
            this.colSTYLE_SIZE_CD.MinWidth = 25;
            this.colSTYLE_SIZE_CD.Name = "colSTYLE_SIZE_CD";
            this.colSTYLE_SIZE_CD.Visible = true;
            this.colSTYLE_SIZE_CD.VisibleIndex = 5;
            this.colSTYLE_SIZE_CD.Width = 94;
            // 
            // colMATERIAL_ID
            // 
            this.colMATERIAL_ID.Caption = "MATERIAL_ID";
            this.colMATERIAL_ID.FieldName = "MATERIAL_ID";
            this.colMATERIAL_ID.MinWidth = 25;
            this.colMATERIAL_ID.Name = "colMATERIAL_ID";
            this.colMATERIAL_ID.Width = 94;
            // 
            // colMATERIAL_NAME_CN
            // 
            this.colMATERIAL_NAME_CN.Caption = "面料名称";
            this.colMATERIAL_NAME_CN.FieldName = "MATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.MinWidth = 25;
            this.colMATERIAL_NAME_CN.Name = "colMATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.Visible = true;
            this.colMATERIAL_NAME_CN.VisibleIndex = 6;
            this.colMATERIAL_NAME_CN.Width = 94;
            // 
            // col
            // 
            this.col.Caption = "面料图片";
            this.col.ColumnEdit = this.repositoryItemPictureEdit1;
            this.col.FieldName = "Picture";
            this.col.MinWidth = 25;
            this.col.Name = "col";
            this.col.Visible = true;
            this.col.VisibleIndex = 7;
            this.col.Width = 94;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // Frm扫码下单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 496);
            this.Controls.Add(this.tablePanel1);
            this.Name = "Frm扫码下单";
            this.Text = "Frm扫码下单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colshop_id;
        private DevExpress.XtraGrid.Columns.GridColumn colshop_name;
        private DevExpress.XtraGrid.Columns.GridColumn colSYS_STYLE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_PUBLISH_CATEGORY_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_YEAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSYTLE_SEASON;
        private DevExpress.XtraGrid.Columns.GridColumn colSTYLE_SIZE_CD;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn col;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    }
}