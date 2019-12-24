﻿namespace DXApplicationTangche
{
    partial class FluentMainFrame
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
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage库存 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ElementStock = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ElementStockOut = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ElementShopStockIn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ElementShopOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ElementBarCode = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.navigationFrame);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(297, 37);
            this.fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(493, 571);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // navigationFrame
            // 
            this.navigationFrame.Controls.Add(this.navigationPage库存);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage库存});
            this.navigationFrame.SelectedPage = this.navigationPage库存;
            this.navigationFrame.Size = new System.Drawing.Size(493, 571);
            this.navigationFrame.TabIndex = 3;
            this.navigationFrame.Text = "navigationFrame1";
            this.navigationFrame.TransitionAnimationProperties.FrameInterval = 5000;
            // 
            // navigationPage库存
            // 
            this.navigationPage库存.Caption = "navigationPage库存";
            this.navigationPage库存.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navigationPage库存.Name = "navigationPage库存";
            this.navigationPage库存.Size = new System.Drawing.Size(493, 571);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ElementStock,
            this.accordionControlElement2});
            this.accordionControl1.Location = new System.Drawing.Point(0, 37);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(297, 571);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // ElementStock
            // 
            this.ElementStock.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ElementStockOut,
            this.ElementShopStockIn,
            this.ElementShopOrder});
            this.ElementStock.Expanded = true;
            this.ElementStock.Name = "ElementStock";
            this.ElementStock.Text = "进销存管理";
            // 
            // ElementStockOut
            // 
            this.ElementStockOut.Name = "ElementStockOut";
            this.ElementStockOut.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ElementStockOut.Text = "扫码出货";
            this.ElementStockOut.Click += new System.EventHandler(this.ElementStockOut_Click);
            // 
            // ElementShopStockIn
            // 
            this.ElementShopStockIn.Name = "ElementShopStockIn";
            this.ElementShopStockIn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ElementShopStockIn.Text = "门店验货";
            // 
            // ElementShopOrder
            // 
            this.ElementShopOrder.Name = "ElementShopOrder";
            this.ElementShopOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ElementShopOrder.Text = "门店销售";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ElementBarCode});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "标签列印";
            // 
            // ElementBarCode
            // 
            this.ElementBarCode.Name = "ElementBarCode";
            this.ElementBarCode.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ElementBarCode.Text = "标签列印";
            this.ElementBarCode.Click += new System.EventHandler(this.ElementBarCode_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(790, 37);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // FluentMainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 608);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FluentMainFrame";
            this.NavigationControl = this.accordionControl1;
            this.Text = "春衫体验店进销存管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementStock;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementStockOut;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementShopStockIn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementShopOrder;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage库存;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementBarCode;
    }
}