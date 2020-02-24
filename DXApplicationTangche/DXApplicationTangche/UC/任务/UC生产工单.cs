using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationTangche.service;

namespace DXApplicationTangche.UC.任务
{
    public partial class UC生产工单 : System.Windows.Forms.UserControl
    {
        private 生产工单Service Service { get; set; }
        public UC生产工单()
        {
            InitializeComponent();
        }

        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            String str = this.barEditItemOrderid.EditValue.ToString();
            if (e.KeyValue == 13) //判断是回车键
            {
                this.Refresh任务一览(this.barEditItemOrderid.EditValue.ToString());
            }
        }

        public void Refresh任务一览(String ORDER_ID)
        {
            if(!OrderService.VerifyOrder(ORDER_ID))
            {
                MessageBox.Show("无此订单");
                return;
            }
            this.Service = new 生产工单Service(ORDER_ID);
            this.gridControl任务一览.DataSource = this.Service.UserTaskDTOs;
            this.gridControl任务一览.Refresh();
        }
    }
}
