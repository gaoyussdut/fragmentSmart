using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mendian
{
    public partial class Frm面料选择 : Form
    {
        public 面料Model model { get; set; }
        public static int page { get; set; }
        public static String mianliaoid { get; set; }
        public static String mianliao { get; set; }
        public static String mianliaocd { get; set; }
        public String styleid { get; set; }
        private bool flag { get; set; }
        private PanelLocition panelLocition;
        private Frm门店下单选款式 frm;
        int height = 0;
        int width = 0;
        public Frm面料选择(Frm门店下单选款式 frm)
        {
            InitializeComponent();
            Frm面料选择.page = 1;
            this.frm = frm;
            this.flag = false;
            this.fenYeLan1.xiaye.Click += new EventHandler(this.xiaye_Button);
            this.fenYeLan1.shangye.Click += new EventHandler(this.shangye_Button);
        }

        public Frm面料选择(String styleid, Frm门店下单选款式 frm)
        {
            InitializeComponent();
            this.frm = frm;
            this.flag = true;
            this.Name = "默认面料选择";
            this.styleid = styleid;
            this.fenYeLan1.xiaye.Click += new EventHandler(this.xiaye_Button);
            this.fenYeLan1.shangye.Click += new EventHandler(this.shangye_Button);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            generatePictureLayout();
            //DoButtonClick();
        }
        public void generateUserControl(UserControl userControl, int i)
        {
            userControl.Name = "pic" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 9 == 0)
                {
                    width = 0;
                    height = height + 210;
                }
            }
            userControl.Location = new Point(panelLocition.UcLeft + width * 200, panelLocition.UcHeight + height);//控件位置
            width++;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xiaye_Button(object sender, EventArgs e)
        {
            Frm面料选择.page++;
            generatePictureLayout();
            if (this.model.面料卡s.Count==0)
            {
                MessageBox.Show("已经是最后一页");
                Frm面料选择.page--;
                generatePictureLayout();
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shangye_Button(object sender, EventArgs e)
        {
            if (Frm面料选择.page == 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            Frm面料选择.page--;
            generatePictureLayout();
        }
        /// <summary>
        /// 显示所有
        /// </summary>
        //private void DoButtonClick()
        //{
        //    this.splashScreenManager.ShowWaitForm();
        //    this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
        //    this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
        //    Frm面料选择.page = 1;
        //    this.panel1.Controls.Clear();
        //    height = 0;
        //    width = 0;
        //    int i = 0;
        //    if (flag == false)
        //    {
        //        DataTable dt = ImpService.GetMianLiao(this.textBox1.Text, Frm面料选择.page);
        //        panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            UC面料卡片 oc = new UC面料卡片(dr["mianliao"].ToString(), dr["id"].ToString(), dr["materialCode"].ToString(), dr["picurl"].ToString(), dr["picn"].ToString(), this,this.frm);
        //            this.generateUserControl(oc, i);
        //            this.panel1.Controls.Add(oc);//将控件加入panel
        //                                         //oc.pictureBox1.Click += new EventHandler(this.picture_Click);
        //            i++;
        //        }
        //    }
        //    else
        //    {
        //        DataTable dt = ImpService.DefaultMianLiao(this.styleid, this.textBox1.Text, Frm面料选择.page);
        //        panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            UC面料卡片 oc = new UC面料卡片(dr["ITEM_NAME_CN"].ToString(), dr["ITEM_VALUE"].ToString(), dr["ITEM_CD"].ToString(), dr["picurl"].ToString(), dr["picn"].ToString(), this,this.frm);
        //            this.generateUserControl(oc, i);
        //            this.panel1.Controls.Add(oc);//将控件加入panel
        //                                         //oc.pictureBox1.Click += new EventHandler(this.picture_Click);
        //            i++;
        //        }
        //    }
        //    this.splashScreenManager.CloseWaitForm();
        //}

        private void Frm面料选择_Load(object sender, EventArgs e)
        {
            //DoButtonClick();
            generatePictureLayout();
        }
        private void generatePictureLayout()
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            this.model = new 面料Model(this.textBox1.Text, Frm面料选择.page);
            this.gridControl1.DataSource = this.model.面料卡s;
            this.fenYeLan1.label1.Text = Frm面料选择.page.ToString();
            this.splashScreenManager.CloseWaitForm();
        }
    }
}
