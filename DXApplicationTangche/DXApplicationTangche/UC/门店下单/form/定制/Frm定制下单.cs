using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mendian
{
    public partial class Frm定制下单 : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public static String ORDER_NO;
        public static int page { get; set; } = 1;
        public static String billid { get; set; }
        //private List<DingDanDTO> dingDanDTO = new List<DingDanDTO>();
        private String jsData;
        private PanelLocition panelLocition;
        int height = 0;//用户控件纵坐标
        int width = 0;  //用户控件横坐标
        public Frm定制下单()
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            InitializeComponent();
            this.fenYeLan1.xiaye.Click += new EventHandler(this.xiaye_Button);
            this.fenYeLan1.shangye.Click += new EventHandler(this.shangye_Button);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息

            Frm定制下单.page = 1;
            //  图片布局
            this.generatePictureLayout();
        }
        /// <summary>
        /// 模糊查询,返回匹配的款式名
        /// </summary>
        /// <param name="str"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        //private List<String> onFindKeyWord(string str, List<String> list)
        //{

        //    List<String> m_list = new List<String>();
        //    foreach (String data in list)
        //    {
        //        if (data.IndexOf(str) != -1)
        //        {
        //            m_list.Add(data);
        //        }
        //    }
        //    return m_list;

        //}       
        //private List<Card> onFindKeyWord(string str, List<Card> cardlist)
        //{
        //    List<Card> list = new List<Card>();
        //    foreach (Card card in cardlist)
        //    {
        //        if (card.quanming.IndexOf(str) != -1)
        //        {
        //            list.Add(card);
        //        }

        //    }
        //    return list;
        //}

        public void generateUserControl(UserControl userControl, int i)
        {
            userControl.Name = "pic" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 7 == 0)
                {
                    width = 0;
                    height = height + 200;
                }
            }
            userControl.Location = new Point(panelLocition.UcLeft + width * 160, panelLocition.UcHeight + height);//控件位置
            width++;
        }

        private void Index_Load(object sender, EventArgs e)
        {

            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");     // 信息
            //  同步图片资源到本地
            ResourceService.synPictureResouces();

            this.searchLookUpEdit1.Properties.DataSource = CustomerService.GetCustomerData("");

            this.splashScreenManager.CloseWaitForm();

        }
        /// <summary>
        /// 刷新gridcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_Activated(object sender, EventArgs e)
        {
            this.gridControl2.DataSource = CustomerService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
        }
        //private void RefreshGridcontrol(String str)
        //{
        //    DataTable dt = SQLmtm.GetDataTable("SELECT op.ORDER_ID,op.ORDER_NO,op.CUSTOM_NAME,ap.CONSIGNEE,acp.MOBILE,sp.STYLE_NAME_CN,op.ORDER_DATE,op.STYLE_ID  FROM o_order_p AS op LEFT JOIN s_style_p AS sp ON op.STYLE_ID=sp.SYS_STYLE_ID LEFT JOIN a_customer_address_p AS ap ON op.CUSTOMER_ID=ap.CUSTOMER_ID LEFT JOIN a_customer_p AS acp ON op.CUSTOMER_ID=acp.CUSTOMER_ID WHERE op.SHOP_ID='18' AND (ap.CONSIGNEE LIKE '%"+ str + "%' OR acp.MOBILE LIKE '%"+ str + "%') ORDER BY op.ORDER_DATE DESC LIMIT 100");
        //    this.gridControl1.DataSource = dt;
        //    this.gridControl1.Refresh();
        //}
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xiaye_Button(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            Frm定制下单.page++;
            //  图片布局
            this.generatePictureLayout();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shangye_Button(object sender, EventArgs e)
        {
            if (Frm定制下单.page == 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            Frm定制下单.page--;
            //  图片布局
            this.generatePictureLayout();
        }

        /// <summary>
        /// 图片布局
        /// </summary>
        private void generatePictureLayout() { 
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            DataTable dt = StyleService.initStyle(this.textBox1.Text, Frm定制下单.page);
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("已经是最后一页");
            //    ImpService.page--;
            //    dt = ImpService.initStyle(this.textBox1.Text, ImpService.page);
            //}
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                UC款式卡片 sc = new UC款式卡片("Change", dr);
                this.generateUserControl(sc, i);
                this.panel1.Controls.Add(sc);//将控件加入panel
                try
                {
                    sc.stylecardpicbox.Image = Image.FromFile(sc.picture);
                }
                catch
                {

                }
                i++;
            }
            this.fenYeLan1.label1.Text = Frm定制下单.page.ToString();
            this.splashScreenManager.CloseWaitForm();
        }

        #region 选择门店
        private void searchLookUpEdit1_Popup(object sender, EventArgs e)
        {
            //得到当前SearchLookUpEdit弹出窗体
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl layout = popup.Controls.OfType<LayoutControl>().FirstOrDefault();
            //如果窗体内空间没有确认按钮，则自定义确认simplebutton，取消simplebutton，选中结果label
            if (layout.Controls.OfType<Control>().Where(ct => ct.Name == "btOK").FirstOrDefault() == null)
            {
                //得到空的空间
                EmptySpaceItem a = layout.Items.Where(it => it.TypeName == "EmptySpaceItem").FirstOrDefault() as EmptySpaceItem;

                //得到取消按钮，重写点击事件
                Control clearBtn = layout.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
                LayoutControlItem clearLCI = (LayoutControlItem)layout.GetItemByControl(clearBtn);
                clearBtn.Click += clearBtn_Click;

                //添加一个simplebutton控件(确认按钮)
                LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
                myLCI.TextVisible = false;
            }
        }

        private void searchLookUpEdit1View_Click(object sender, EventArgs e)
        {
            var a = this.searchLookUpEdit1.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                CreateCustomer.cUSTOMER_ID //  no
                    = Convert.ToInt32(this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());//id 是 Value Member
                CreateCustomer.customer_name //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "客户姓名").ToString();//id 是 Value Member
            }
            DataTable dt = SQLmtm.GetDataTable("SELECT * FROM (SELECT * FROM a_customer_fit_r) s1 RIGHT JOIN (SELECT * FROM a_customer_fit_count_r WHERE CUSTOMER_ID ='" + CreateCustomer.cUSTOMER_ID + "' AND DEFAULT_FLAG ='1') s2 on s1.FIT_COUNT_ID=s2.ID");
            if (dt.Rows.Count!=0)
            {
                DataRow drr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_fit_count_r` WHERE CUSTOMER_ID='" + CreateCustomer.cUSTOMER_ID.ToString() + "' AND DEFAULT_FLAG=1");
                DataRow ddr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_address_p` WHERE DEFAULT_ADDR_FLAG=1 AND CUSTOMER_ID='" + CreateCustomer.cUSTOMER_ID.ToString() + "'");
                if (drr == null || ddr == null)
                {
                    CreateCustomer.cUSTOMER_ID = 0;
                    CreateCustomer.customer_name = "";
                    MessageBox.Show("缺少客户信息");
                    return;
                }
                CreateCustomer.customer_countid = Convert.ToInt32(drr["ID"]);
                CreateCustomer.aDDRESS_ID = Convert.ToInt32(ddr["ADDRESS_ID"]);
            }
            else
            {
                CreateCustomer.cUSTOMER_ID = 0;
                CreateCustomer.customer_name = "";
                MessageBox.Show("选择的客户未建立量体值");
                return;
            }
            this.gridControl2.DataSource = CustomerService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
        }

        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.ToolTip = null;
            searchLookUpEdit1.EditValue = null;
        }
        private void searchLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = CreateCustomer.customer_name;
        }
        #endregion
    }
}
