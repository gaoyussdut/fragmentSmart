using DXApplicationTangche.service;
using DXApplicationTangche.UC.任务.任务模板UC;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.form.订单修改;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplicationTangche.生产工单
{
    public partial class Frm生产工单 : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public UC裁剪条码打印 uc裁剪条码打印 = new UC裁剪条码打印();
        public String ORDER_ID { get; set; }
        public String TEMPLATE_ID { get; set; }
        private List<尺寸呈现dto> dtos = new List<尺寸呈现dto>();
        public Frm生产工单(String TEMPLATE_ID)
        {
            this.TEMPLATE_ID = TEMPLATE_ID;
            InitializeComponent();
        }

        private void textBoxOrderid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                if (!OrderService.VerifyOrder(this.textBoxOrderid.Text))
                {
                    MessageBox.Show("无此订单");
                    return;
                }
                this.ORDER_ID = this.textBoxOrderid.Text;
                this.uC生产工单.Refresh任务一览(this.ORDER_ID);
                switch (this.TEMPLATE_ID)
                {
                    case "4":
                        this.uc裁剪条码打印 = new UC裁剪条码打印(this.ORDER_ID);
                        this.uc裁剪条码打印.Dock = DockStyle.Fill;
                        this.uC生产工单.panel任务.Controls.Clear();
                        this.uC生产工单.panel任务.Controls.Add(this.uc裁剪条码打印);
                        this.uC生产工单.panel任务.Refresh();
                        break;
                }
                
            }
        }

        private void simpleButton订单预览_Click(object sender, EventArgs e)
        {
            if (!OrderService.VerifyOrder(this.ORDER_ID))
            {
                MessageBox.Show("无此订单");
                return;
            }
            this.dtos = SizeService.getDto尺寸WithOrderId(this.ORDER_ID);
            new Frm订单预览(
                OrderService.GetStyleidWithOrderid(this.ORDER_ID)
                , dtos
                , this.ORDER_ID
                , "").ShowDialog();
        }
    }
}
