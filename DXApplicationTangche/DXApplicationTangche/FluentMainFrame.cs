using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DiaoPaiDaYin;
using DXApplicationTangche.UC;
using DXApplicationTangche.UC.库存;
using mendian;
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
            this.initPanel(new Frm吊牌打印());
        }



        private void ElementStockOut_Click(object sender, EventArgs e)
        {
            this.initPanel(new XtraFrm门店出库());
        }

        private void ElementStoreOrder_Click(object sender, EventArgs e)
        {
            this.initPanel(new Index());
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.initPanel(new QueryTag());
        }
    }
}
