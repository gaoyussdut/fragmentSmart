using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DiaoPaiDaYin;
using DXApplicationTangche.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplicationTangche
{
    public partial class FluentMainFrame : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentMainFrame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化导航
        /// </summary>
        /// <param name="uC"></param>
        private void initNavigationPage(XtraUserControl uC)
        {
            uC.Dock = DockStyle.Fill;
            this.navigationPage库存.Controls.Clear();
            this.navigationPage库存.Controls.Add(uC);
            this.navigationFrame.Pages[0].Show();
        }

        /// <summary>
        /// 初始化panel
        /// </summary>
        /// <param name="frm"></param>
        private void initPanel(Form frm)
        {
            this.navigationPage库存.Controls.Clear();
            //指示窗体显示是否为顶级窗口
            frm.TopLevel = false;
            this.navigationPage库存.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.Show();
        }

        private void ElementBarCode_Click(object sender, EventArgs e)
        {
            this.initPanel(new Form1());
        }



        private void ElementStockOut_Click(object sender, EventArgs e)
        {
            this.initNavigationPage(new XtraUC库存一览());
        }
    }
}
