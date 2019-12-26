using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
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
    public partial class Index : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public static String ORDER_NO;
        public static int page { get; set; } = 1;
        public static String billid { get; set; }
        //private List<DingDanDTO> dingDanDTO = new List<DingDanDTO>();
        private String jsData;
        private PanelLocition panelLocition;
        int height = 0;//用户控件纵坐标
        int width = 0;  //用户控件横坐标
        public Index()
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

            Index.page = 1;
            /*
            Style stylee = new Style();
            //  模糊查询,返回匹配的款式名
            List<Card> styleReturn 
                = this.onFindKeyWord(
                    textBox1.Text
                    //, new Style().Styles    //  款式名
                    , stylee.Card    //  款式名

                );*/

            //  布局方法
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            DataTable dt = ImpService.initStyle(this.textBox1.Text, Index.page);
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                StyleCard sc = new StyleCard();
                sc.stylecardlabel.Text = dr["styleEntity.styleNameCn"].ToString();
                sc.kuanshiid = dr["styleId"].ToString();
                sc.kuanshimingcheng = dr["styleEntity.styleNameCn"].ToString();
                sc.mianliaoid = dr["materialEntity.id"].ToString();
                sc.mianliaomingcheng = dr["materialEntity.materialNameCn"].ToString();
                sc.sTYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
                sc.sTYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
                sc.sTYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
                sc.sTYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
                sc.sTYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
                sc.sTYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
                sc.sYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
                sc.sYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
                sc.sTYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
                //sc.id = cd.id;
                //sc.banid = cd.banid;
                //sc.jiage = cd.jiage;
                sc.picture = @"pic\" + dr["picn"].ToString();
                this.generateUserControl(sc, i);
                this.panel1.Controls.Add(sc);//将控件加入panel
                try
                {
                    //string url = string.Format(@cd.picture, 5, 123456);
                    //string url = string.Format(@"https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/ZSF-1-320.jpg?size={0}&content={1}", 5, 123456);
                    /*
                    System.Net.WebRequest webreq = System.Net.WebRequest.Create(sc.picture);
                    System.Net.WebResponse webres = webreq.GetResponse();

                    using (System.IO.Stream stream = webres.GetResponseStream())
                    {
                        sc.stylecardpicbox.Image = Image.FromStream(stream);
                    }
                    */
                    sc.stylecardpicbox.Image = Image.FromFile(sc.picture);
                }
                catch
                {

                }
                i++;
                this.fenYeLan1.label1.Text = Index.page.ToString();
            }
            this.splashScreenManager.CloseWaitForm();

            //foreach (Card cd in styleReturn)
            //{
            //    StyleCard sc=new StyleCard();
            //    sc.stylecardlabel.Text = cd.kuanshiid+cd.kuanshiming+"\n面料:"+cd.mianliaoid;
            //    sc.kuanshiid = cd.kuanshiid;
            //    sc.kuanshimingcheng = cd.kuanshiming;
            //    sc.mianliaoid = cd.mianliaoid;
            //    sc.mianliaomingcheng = cd.mianliaomingcheng;
            //    sc.id = cd.id;
            //    sc.banid = cd.banid;
            //    sc.jiage = cd.jiage;
            //    sc.picture = cd.picture;
            //    this.generateUserControl(sc, i);
            //    this.panel1.Controls.Add(sc);//将控件加入panel
            //    try
            //    {
            //        //string url = string.Format(@cd.picture, 5, 123456);
            //        //string url = string.Format(@"https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/ZSF-1-320.jpg?size={0}&content={1}", 5, 123456);
            //        System.Net.WebRequest webreq = System.Net.WebRequest.Create(cd.picture);
            //        System.Net.WebResponse webres = webreq.GetResponse();
            //        using (System.IO.Stream stream = webres.GetResponseStream())
            //        {
            //            sc.stylecardpicbox.Image = Image.FromStream(stream);
            //        }
            //    }
            //    catch
            //    {

            //    }
            //    i++;
            //}
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
            if (!Directory.Exists(@"xml"))
            {
                Directory.CreateDirectory(@"xml");
                Directory.CreateDirectory(@"pic");
                DealXML.ObjectToXMLFile(new List<StylePic>() { new StylePic("1","1","1","1")}, @"xml\stylepicxml.xml", Encoding.UTF8);
                DealXML.ObjectToXMLFile(new List<MianLiaoPic>() { new MianLiaoPic("1", "1", "1", "1","1") }, @"xml\mlpicxml.xml", Encoding.UTF8);
                DealXML.ObjectToXMLFile(new List<SheJiDianPic>() { new SheJiDianPic("1", "1", "1", "1","1") }, @"xml\shjdpicxml.xml", Encoding.UTF8);
            }
            //款式图片更新
            StylePicList spl = new StylePicList();
            List<StylePic> styleOldlist = DealXML.XMLFlieToObject<List<StylePic>>(@"xml\stylepicxml.xml", Encoding.UTF8);
            List<StylePic> styleDifflist = ImpService.listCompare(spl.stylepiclist, styleOldlist);
            ImpService.DownloadDifferentPic(styleDifflist);
            bool yn = DealXML.ObjectToXMLFile(spl.stylepiclist, @"xml\stylepicxml.xml", Encoding.UTF8);
            //面料图片更新
            MianLiaoPicList mlpl = new MianLiaoPicList();
            //bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoOldlist = DealXML.XMLFlieToObject<List<MianLiaoPic>>(@"xml\mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoDifflist = ImpService.mianliaolistCompare(mlpl.mianliaopiclist, mianliaoOldlist);
            ImpService.DownloadMianliaoPic(mianliaoDifflist);
            bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"xml\mlpicxml.xml", Encoding.UTF8);
            //设计点图片更新
            SheJiDianPicList sjdpl = new SheJiDianPicList();
            //bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianOldlist = DealXML.XMLFlieToObject<List<SheJiDianPic>>(@"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianDifflist = ImpService.shejidianlistCompare(sjdpl.shejidianpiclist, shejidianOldlist);
            ImpService.DownloadSheJiDianPic(shejidianDifflist);
            bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);

            this.searchLookUpEdit1.Properties.DataSource = ImpService.GetCustomerData("");

            this.splashScreenManager.CloseWaitForm();

        }
        /// <summary>
        /// 刷新gridcontrol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_Activated(object sender, EventArgs e)
        {
            this.gridControl2.DataSource = ImpService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
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
            Index.page++;
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            DataTable dt = ImpService.initStyle(this.textBox1.Text, Index.page);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("已经是最后一页");
                Index.page--;
                dt = ImpService.initStyle(this.textBox1.Text, Index.page);
            }
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                StyleCard sc = new StyleCard();
                sc.stylecardlabel.Text = dr["styleEntity.styleNameCn"].ToString();
                sc.kuanshiid = dr["styleId"].ToString();
                sc.kuanshimingcheng = dr["styleEntity.styleNameCn"].ToString();
                sc.mianliaoid = dr["materialEntity.id"].ToString();
                sc.mianliaomingcheng = dr["materialEntity.materialNameCn"].ToString();
                sc.sTYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
                sc.sTYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
                sc.sTYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
                sc.sTYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
                sc.sTYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
                sc.sTYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
                sc.sYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
                sc.sYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
                sc.sTYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
                //sc.id = cd.id;
                //sc.banid = cd.banid;
                //sc.jiage = cd.jiage;
                sc.picture = @"pic\" + dr["picn"].ToString();
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
            this.fenYeLan1.label1.Text = Index.page.ToString();
            this.splashScreenManager.CloseWaitForm();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shangye_Button(object sender, EventArgs e)
        {
            if (Index.page == 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            Index.page--;
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            DataTable dt = ImpService.initStyle(this.textBox1.Text, Index.page);
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("已经是最后一页");
            //    ImpService.page--;
            //    dt = ImpService.initStyle(this.textBox1.Text, ImpService.page);
            //}
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                StyleCard sc = new StyleCard();
                sc.stylecardlabel.Text = dr["styleEntity.styleNameCn"].ToString();
                sc.kuanshiid = dr["styleId"].ToString();
                sc.kuanshimingcheng = dr["styleEntity.styleNameCn"].ToString();
                sc.mianliaoid = dr["materialEntity.id"].ToString();
                sc.mianliaomingcheng = dr["materialEntity.materialNameCn"].ToString();
                sc.sTYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
                sc.sTYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
                sc.sTYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
                sc.sTYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
                sc.sTYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
                sc.sTYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
                sc.sYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
                sc.sYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
                sc.sTYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
                //sc.id = cd.id;
                //sc.banid = cd.banid;
                //sc.jiage = cd.jiage;
                sc.picture = @"pic\" + dr["picn"].ToString();
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
            this.fenYeLan1.label1.Text = Index.page.ToString();
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
                //this.style_id //  id
                //    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "style_id").ToString();//name 是 Display Member
                //this.order_text//text
                //    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "ORDER_NO").ToString() + this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "STYLE_NAME_CN").ToString();
            }
            this.gridControl2.DataSource = ImpService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
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
                e.DisplayText = CreateCustomer.cUSTOMER_ID.ToString();
        }
        #endregion
    }
}
