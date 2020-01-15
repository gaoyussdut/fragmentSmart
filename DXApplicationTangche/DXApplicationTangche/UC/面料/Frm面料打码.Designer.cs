namespace DXApplicationTangche.UC.面料
{
    partial class Frm面料打码
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
            this.components = new System.ComponentModel.Container();
            this.gridControl面料打码 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATERIAL_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_SOURCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_SPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_GRAM_WEIGHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_THREAD_COUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_COMPOSITION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_OTHER1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_FILE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colmaterial_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaterital_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaterialComposition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl面料打码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl面料打码
            // 
            this.gridControl面料打码.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl面料打码.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl面料打码.Location = new System.Drawing.Point(0, 0);
            this.gridControl面料打码.MainView = this.gridView1;
            this.gridControl面料打码.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl面料打码.Name = "gridControl面料打码";
            this.gridControl面料打码.Size = new System.Drawing.Size(668, 425);
            this.gridControl面料打码.TabIndex = 0;
            this.gridControl面料打码.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMATERIAL_CODE,
            this.colMATERIAL_NAME_CN,
            this.colMATERIAL_SOURCE,
            this.colMATERIAL_SPEC,
            this.colMATERIAL_GRAM_WEIGHT,
            this.colMATERIAL_THREAD_COUNT,
            this.colMATERIAL_COMPOSITION,
            this.colMATERIAL_OTHER1,
            this.colMATERIAL_FILE_ID});
            this.gridView1.DetailHeight = 272;
            this.gridView1.GridControl = this.gridControl面料打码;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMATERIAL_CODE
            // 
            this.colMATERIAL_CODE.Caption = "面料号";
            this.colMATERIAL_CODE.FieldName = "materialcd";
            this.colMATERIAL_CODE.MinWidth = 22;
            this.colMATERIAL_CODE.Name = "colMATERIAL_CODE";
            this.colMATERIAL_CODE.Visible = true;
            this.colMATERIAL_CODE.VisibleIndex = 0;
            this.colMATERIAL_CODE.Width = 82;
            // 
            // colMATERIAL_NAME_CN
            // 
            this.colMATERIAL_NAME_CN.Caption = "面料名称";
            this.colMATERIAL_NAME_CN.FieldName = "materialname";
            this.colMATERIAL_NAME_CN.MinWidth = 22;
            this.colMATERIAL_NAME_CN.Name = "colMATERIAL_NAME_CN";
            this.colMATERIAL_NAME_CN.Visible = true;
            this.colMATERIAL_NAME_CN.VisibleIndex = 1;
            this.colMATERIAL_NAME_CN.Width = 82;
            // 
            // colMATERIAL_SOURCE
            // 
            this.colMATERIAL_SOURCE.Caption = "原辅料来源";
            this.colMATERIAL_SOURCE.FieldName = "MATERIAL_SOURCE";
            this.colMATERIAL_SOURCE.MinWidth = 22;
            this.colMATERIAL_SOURCE.Name = "colMATERIAL_SOURCE";
            this.colMATERIAL_SOURCE.Visible = true;
            this.colMATERIAL_SOURCE.VisibleIndex = 2;
            this.colMATERIAL_SOURCE.Width = 82;
            // 
            // colMATERIAL_SPEC
            // 
            this.colMATERIAL_SPEC.Caption = "物料幅宽";
            this.colMATERIAL_SPEC.FieldName = "MATERIAL_SPEC";
            this.colMATERIAL_SPEC.MinWidth = 22;
            this.colMATERIAL_SPEC.Name = "colMATERIAL_SPEC";
            this.colMATERIAL_SPEC.Visible = true;
            this.colMATERIAL_SPEC.VisibleIndex = 3;
            this.colMATERIAL_SPEC.Width = 82;
            // 
            // colMATERIAL_GRAM_WEIGHT
            // 
            this.colMATERIAL_GRAM_WEIGHT.Caption = "原辅料克重";
            this.colMATERIAL_GRAM_WEIGHT.FieldName = "MATERIAL_GRAM_WEIGHT";
            this.colMATERIAL_GRAM_WEIGHT.MinWidth = 22;
            this.colMATERIAL_GRAM_WEIGHT.Name = "colMATERIAL_GRAM_WEIGHT";
            this.colMATERIAL_GRAM_WEIGHT.Visible = true;
            this.colMATERIAL_GRAM_WEIGHT.VisibleIndex = 4;
            this.colMATERIAL_GRAM_WEIGHT.Width = 82;
            // 
            // colMATERIAL_THREAD_COUNT
            // 
            this.colMATERIAL_THREAD_COUNT.Caption = "原辅料纱支密度";
            this.colMATERIAL_THREAD_COUNT.FieldName = "MATERIAL_THREAD_COUNT";
            this.colMATERIAL_THREAD_COUNT.MinWidth = 22;
            this.colMATERIAL_THREAD_COUNT.Name = "colMATERIAL_THREAD_COUNT";
            this.colMATERIAL_THREAD_COUNT.Visible = true;
            this.colMATERIAL_THREAD_COUNT.VisibleIndex = 5;
            this.colMATERIAL_THREAD_COUNT.Width = 82;
            // 
            // colMATERIAL_COMPOSITION
            // 
            this.colMATERIAL_COMPOSITION.Caption = "物料成分";
            this.colMATERIAL_COMPOSITION.FieldName = "MATERIAL_COMPOSITION";
            this.colMATERIAL_COMPOSITION.MinWidth = 22;
            this.colMATERIAL_COMPOSITION.Name = "colMATERIAL_COMPOSITION";
            this.colMATERIAL_COMPOSITION.Visible = true;
            this.colMATERIAL_COMPOSITION.VisibleIndex = 6;
            this.colMATERIAL_COMPOSITION.Width = 82;
            // 
            // colMATERIAL_OTHER1
            // 
            this.colMATERIAL_OTHER1.Caption = "面料供应商名称";
            this.colMATERIAL_OTHER1.FieldName = "MATERIAL_OTHER1";
            this.colMATERIAL_OTHER1.MinWidth = 22;
            this.colMATERIAL_OTHER1.Name = "colMATERIAL_OTHER1";
            this.colMATERIAL_OTHER1.Visible = true;
            this.colMATERIAL_OTHER1.VisibleIndex = 7;
            this.colMATERIAL_OTHER1.Width = 82;
            // 
            // colMATERIAL_FILE_ID
            // 
            this.colMATERIAL_FILE_ID.Caption = "面料图片";
            this.colMATERIAL_FILE_ID.MinWidth = 22;
            this.colMATERIAL_FILE_ID.Name = "colMATERIAL_FILE_ID";
            this.colMATERIAL_FILE_ID.Visible = true;
            this.colMATERIAL_FILE_ID.VisibleIndex = 8;
            this.colMATERIAL_FILE_ID.Width = 82;
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
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("38b239f1-51cd-41a5-9990-f281e4980700");
            this.dockPanel1.Location = new System.Drawing.Point(668, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(395, 200);
            this.dockPanel1.Size = new System.Drawing.Size(395, 425);
            this.dockPanel1.Text = "选择面料打码";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tablePanel1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 30);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(388, 392);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15.56F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 44.44F)});
            this.tablePanel1.Controls.Add(this.searchLookUpEdit1);
            this.tablePanel1.Controls.Add(this.simpleButton1);
            this.tablePanel1.Controls.Add(this.label1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 46F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(388, 392);
            this.tablePanel1.TabIndex = 0;
            // 
            // searchLookUpEdit1
            // 
            this.tablePanel1.SetColumn(this.searchLookUpEdit1, 1);
            this.searchLookUpEdit1.Location = new System.Drawing.Point(104, 8);
            this.searchLookUpEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.searchLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.tablePanel1.SetRow(this.searchLookUpEdit1, 0);
            this.searchLookUpEdit1.Size = new System.Drawing.Size(281, 30);
            this.searchLookUpEdit1.TabIndex = 19;
            this.searchLookUpEdit1.Popup += new System.EventHandler(this.searchLookUpEdit1_Popup);
            this.searchLookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.searchLookUpEdit1_CustomDisplayText);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colmaterial_id,
            this.colmaterital_name,
            this.colmaterialCode,
            this.colmaterialComposition});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.Click += new System.EventHandler(this.searchLookUpEdit1View_Click);
            // 
            // colmaterial_id
            // 
            this.colmaterial_id.Caption = "面料id";
            this.colmaterial_id.FieldName = "id";
            this.colmaterial_id.Name = "colmaterial_id";
            // 
            // colmaterital_name
            // 
            this.colmaterital_name.Caption = "面料名称";
            this.colmaterital_name.FieldName = "materialNameCn";
            this.colmaterital_name.Name = "colmaterital_name";
            this.colmaterital_name.Visible = true;
            this.colmaterital_name.VisibleIndex = 0;
            // 
            // colmaterialCode
            // 
            this.colmaterialCode.Caption = "面料号";
            this.colmaterialCode.FieldName = "materialCode";
            this.colmaterialCode.Name = "colmaterialCode";
            this.colmaterialCode.Visible = true;
            this.colmaterialCode.VisibleIndex = 1;
            // 
            // colmaterialComposition
            // 
            this.colmaterialComposition.Caption = "成分";
            this.colmaterialComposition.FieldName = "materialComposition";
            this.colmaterialComposition.Name = "colmaterialComposition";
            this.colmaterialComposition.Visible = true;
            this.colmaterialComposition.VisibleIndex = 2;
            // 
            // simpleButton1
            // 
            this.tablePanel1.SetColumn(this.simpleButton1, 1);
            this.simpleButton1.Location = new System.Drawing.Point(104, 207);
            this.simpleButton1.Name = "simpleButton1";
            this.tablePanel1.SetRow(this.simpleButton1, 1);
            this.simpleButton1.Size = new System.Drawing.Size(281, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "打印";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tablePanel1.SetColumn(this.label1, 0);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.tablePanel1.SetRow(this.label1, 0);
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择面料";
            // 
            // Frm面料打码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 425);
            this.Controls.Add(this.gridControl面料打码);
            this.Controls.Add(this.dockPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm面料打码";
            this.Text = "Frm面料打码";
            this.Load += new System.EventHandler(this.Frm面料打码_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl面料打码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl面料打码;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME_CN;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_SOURCE;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_SPEC;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_GRAM_WEIGHT;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_THREAD_COUNT;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_COMPOSITION;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_OTHER1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_FILE_ID;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colmaterial_id;
        private DevExpress.XtraGrid.Columns.GridColumn colmaterital_name;
        private DevExpress.XtraGrid.Columns.GridColumn colmaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colmaterialComposition;
    }
}