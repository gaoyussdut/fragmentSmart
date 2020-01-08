using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mendian
{
    public partial class DefaultSheJiDian : Form
    {
        private PanelLocition panelLocition;
        public UC设计点选择 card = new UC设计点选择();
        int height = 0;//用户控件纵坐标
        int width = 0;  //用户控件横坐标
        public DefaultSheJiDian()
        {
            InitializeComponent();
        }
        public DefaultSheJiDian(UC设计点选择 card)
        {
            InitializeComponent();
            this.card = card;
        }
        private void DefaultSheJiDian_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();
            this.splashScreenManager1.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager1.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0)
            {
                this.splashScreenManager1.CloseWaitForm();
                MessageBox.Show("请联系管理员完善相关信息");
                this.Close();
                return;
            }
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach(DataRow dr in dt.Rows)
            {
                UC设计点卡片 card = new UC设计点卡片(dr["ITEM_NAME_CN"].ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["picn"].ToString(),this,this.card);
                generateUserControl(card, i);
                this.panel1.Controls.Add(card);
                i++;
            }
            UC设计点卡片 carD = new UC设计点卡片("无", this.card.PitemValue, "无", "", this, this.card);
            generateUserControl(carD, i);
            this.panel1.Controls.Add(carD);
            this.splashScreenManager1.CloseWaitForm();
        }
        private void generateUserControl(UserControl userControl, int i)
        {
            userControl.Name = "pic" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 5 == 0)
                {
                    width = 0;
                    height = height + 240;
                }
            }
            userControl.Location = new Point(panelLocition.UcLeft + width * 200, panelLocition.UcHeight + height);//控件位置
            width++;
        }
    }
}
