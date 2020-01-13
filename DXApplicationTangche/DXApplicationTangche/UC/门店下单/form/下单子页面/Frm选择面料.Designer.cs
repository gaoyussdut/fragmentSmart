namespace DXApplicationTangche.UC.门店下单.form.下单子页面
{
    partial class Frm选择面料
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tabPane选择面料 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage平台面料 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage进口面料 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage客户带料 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage样衣下单 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage扫码下单 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane选择面料)).BeginInit();
            this.tabPane选择面料.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
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
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(6, 37);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(682, 374);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("6026b325-79dd-4d09-830a-7c0a511a2aa4");
            this.dockPanel1.Location = new System.Drawing.Point(477, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(692, 200);
            this.dockPanel1.Size = new System.Drawing.Size(692, 415);
            this.dockPanel1.Text = "选择面料";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 0.59F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 59.41F)});
            this.tablePanel1.Controls.Add(this.tabPane选择面料);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8.399998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1169, 415);
            this.tablePanel1.TabIndex = 1;
            // 
            // tabPane选择面料
            // 
            this.tablePanel1.SetColumn(this.tabPane选择面料, 1);
            this.tabPane选择面料.Controls.Add(this.tabNavigationPage平台面料);
            this.tabPane选择面料.Controls.Add(this.tabNavigationPage进口面料);
            this.tabPane选择面料.Controls.Add(this.tabNavigationPage客户带料);
            this.tabPane选择面料.Controls.Add(this.tabNavigationPage样衣下单);
            this.tabPane选择面料.Controls.Add(this.tabNavigationPage扫码下单);
            this.tabPane选择面料.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane选择面料.Location = new System.Drawing.Point(14, 11);
            this.tabPane选择面料.Name = "tabPane选择面料";
            this.tabPane选择面料.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage扫码下单,
            this.tabNavigationPage平台面料,
            this.tabNavigationPage进口面料,
            this.tabNavigationPage客户带料,
            this.tabNavigationPage样衣下单});
            this.tabPane选择面料.RegularSize = new System.Drawing.Size(1152, 401);
            this.tablePanel1.SetRow(this.tabPane选择面料, 1);
            this.tabPane选择面料.SelectedPage = this.tabNavigationPage扫码下单;
            this.tabPane选择面料.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            this.tabPane选择面料.Size = new System.Drawing.Size(1152, 401);
            this.tabPane选择面料.TabIndex = 1;
            this.tabPane选择面料.Text = "tabPane1";
            // 
            // tabNavigationPage平台面料
            // 
            this.tabNavigationPage平台面料.Caption = "选择平台面料";
            this.tabNavigationPage平台面料.Name = "tabNavigationPage平台面料";
            this.tabNavigationPage平台面料.Size = new System.Drawing.Size(1152, 401);
            // 
            // tabNavigationPage进口面料
            // 
            this.tabNavigationPage进口面料.Caption = "选择进口面料";
            this.tabNavigationPage进口面料.Name = "tabNavigationPage进口面料";
            this.tabNavigationPage进口面料.Size = new System.Drawing.Size(1152, 401);
            // 
            // tabNavigationPage客户带料
            // 
            this.tabNavigationPage客户带料.Caption = "客户带料";
            this.tabNavigationPage客户带料.Name = "tabNavigationPage客户带料";
            this.tabNavigationPage客户带料.Size = new System.Drawing.Size(1152, 401);
            // 
            // tabNavigationPage样衣下单
            // 
            this.tabNavigationPage样衣下单.Caption = "样衣下单";
            this.tabNavigationPage样衣下单.Name = "tabNavigationPage样衣下单";
            this.tabNavigationPage样衣下单.Size = new System.Drawing.Size(1152, 401);
            // 
            // tabNavigationPage扫码下单
            // 
            this.tabNavigationPage扫码下单.Caption = "扫码下单";
            this.tabNavigationPage扫码下单.Name = "tabNavigationPage扫码下单";
            this.tabNavigationPage扫码下单.Size = new System.Drawing.Size(1152, 363);
            // 
            // Frm选择面料
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 415);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.dockPanel1);
            this.IsMdiContainer = true;
            this.Name = "Frm选择面料";
            this.Text = "Frm选择面料";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane选择面料)).EndInit();
            this.tabPane选择面料.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane选择面料;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage平台面料;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage进口面料;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage客户带料;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage样衣下单;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage扫码下单;
    }
}