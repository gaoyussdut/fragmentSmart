using DiaoPaiDaYin;
using DXApplicationTangche.service;
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
    public partial class Frm定制下单修改尺寸 : DevExpress.XtraEditors.XtraForm
    {
        public static int styleid { get; set; }
        public static DataTable StyleDesign { get; set; }
        public static String sTYLE_SIZE_CD { get; set; }
        public static DataTable stylesizedt { get; set; }
        //public static List<Option> OptionList { get; set; }
        public static String entryid { get; set; }
        public static String kuanshiid { get; set; }
        private List<String> style = new List<string>();
        //private List<ReducedFkeyField> fields = new List<ReducedFkeyField>();
        private String tkid;
        //private Dictionary<String, String> relationCaptionAndKey = new Dictionary<string, string>();
        private UC款式卡片 uc = new UC款式卡片();
        public Frm定制下单修改尺寸()
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            InitializeComponent();
        }
        public Frm定制下单修改尺寸(UC款式卡片 uc)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            this.uc = uc;
            InitializeComponent();
            this.label8.Text = uc.stylecardlabel.Text;
            kuanshiid = uc.kuanshiid;
            try
            {
                this.pictureBox1.Image = Image.FromFile(uc.picture);
            }
            catch
            {

            }
            //clothingName= uc.stylecardlabel.Text;
            //this.pictureBox1.Load("C:/Users/Doge/Documents/text.jpg");
            //BasicInformation();
            //StyleDesign = ImpService.initCombobox(this);
        }
        private void sizechange_Click(object sender, EventArgs e)
        {
            new Frm尺寸变更().ShowDialog();
        }

        private void stylechange_Click(object sender, EventArgs e)
        {
            new Frm款式变更().ShowDialog();
        }


        private void Change_Load(object sender, EventArgs e)
        {
            this.jisuan.Parent = null;
            //this.tabPage2.Parent = null;
            //this.tabPage1.Parent = null;
            ImpService.LoadChiCunCard(this, uc);
            ImpService.LoadSheJiDian(this, uc.kuanshiid);

            stylesizedt = StyleService.StyleCombobox(uc.kuanshiid);
            if (stylesizedt != null)
            {
                foreach (DataRow dr in stylesizedt.Rows)
                {
                    //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                    this.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                }
            }


        }
        /// <summary>
        /// 订单信息保存
        /// </summary>
        private void stylechangesave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (Frm面料选择.mianliaoid == "" || this.chicun01.Text == "" || this.shuliang.Text == "")
                {
                    MessageBox.Show("请填写完整");
                    return;
                }
                DataRow drstylefit = SQLmtm.GetDataRow("SELECT MAX(STYLE_FIT_ID) as STYLE_FIT_ID FROM `a_customer_fit_value_r`");
                int sTYLE_FIT_ID = Convert.ToInt32(drstylefit["STYLE_FIT_ID"]);
                sTYLE_FIT_ID++;
                DataRow drcustomer = SQLmtm.GetDataRow("select * from a_customer_p where CUSTOMER_ID='" + CreateCustomer.cUSTOMER_ID.ToString() + "'");
                string customername = Convert.ToString(drcustomer["CUSTOMER_FIRST_NAME"]) + Convert.ToString(drcustomer["CUSTOMER_LAST_NAME"]);
                sTYLE_SIZE_CD = SizeService.SizeCD(this.chicun01.Text.Trim(), stylesizedt);
                DataRow drstyle = SQLmtm.GetDataRow("SELECT MAX(SYS_STYLE_ID) SYS_STYLE_ID FROM `s_style_p`");
                styleid = Convert.ToInt32(drstyle["SYS_STYLE_ID"]);
                styleid++;
                //a_customer_fit_value_r,s_style_fit_r表存储
                //ImpService.insertFit_R(sTYLE_FIT_ID, customername, fitv, ftvl, inftvl, outftvl);
                //动态尺寸保存
                ImpService.DynamicSaveSize(this, sTYLE_FIT_ID, customername);

                //s_style_p储存
                ImpService.insertS_Style_P(this, uc);
                //s_style_fit_r


                //设计点保存
                //ImpService.SaveDesign(this);
                ImpService.DynamicSaveDesign(this);
                //o_order_p
                //RestCall.httpGetMethod("https://shirtmtm.com/fragsmart-mtm/customer/update/payment?styleId=" + styleid.ToString() + "&customerId=" + CreateCustomer.cUSTOMER_ID.ToString() + "&addressId=" + CreateCustomer.aDDRESS_ID.ToString() + "&number=" + this.shuliang.Text);
                RestCall.httpGetMethod("http://localhost:8080/customer/update/payment?styleId=" + styleid.ToString() + "&customerId=" + CreateCustomer.cUSTOMER_ID.ToString() + "&addressId=" + CreateCustomer.aDDRESS_ID.ToString() + "&number=" + this.shuliang.Text);
                DataRow ORDER_ID = SQLmtm.GetDataRow("SELECT MAX(ORDER_ID) AS ORDER_ID FROM `o_order_p`");
                int order_id = Convert.ToInt32(ORDER_ID["ORDER_ID"]);
                //order_id++;
                SQLmtm.DoInsert("o_order_brand_r", new string[] { "OGNIZATION_ID", "SHOP_ID", "BRAND_ID", "ORDER_ID" }, new string[] { "95", "18", "", order_id.ToString() });
                SQLmtm.DoInsert("t_order_type", new string[] { "ORDER_ID", "ORDER_TYPE" }, new string[] { order_id.ToString(), "1" });
                if (Convert.ToInt32(this.shuliang.Text) == Convert.ToInt32(this.shuliang.Text))
                {
                    MessageBox.Show("保存成功!");
                    //this.closeForm();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            //else
            //{
            //    MessageBox.Show("请填写完整");
            //    //return;
            //}       
            else
            {
                return;
            }



        }
        /// <summary>
        ///查找可选面料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chmianliao_Click(object sender, EventArgs e)
        {
            //new Frm面料选择().ShowDialog();
        }
        /// <summary>
        /// 实时加载设计点信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Change_Activated(object sender, EventArgs e)
        {
            //if (Frm面料选择.dr != null)
            //{
            //    this.mianliao.Text = Convert.ToString(Frm面料选择.dr["面料编码"]);
            //}
            this.mianliaoname.Text = Frm面料选择.mianliao;
            //ImpService.SpyStatic();
            //ImpService.realTimeLoading(this);
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            DataTable dt = SizeService.StyleValue(this.chicun01.Text.Trim().ToString(), uc.kuanshiid, Frm定制下单修改尺寸.stylesizedt);
            ImpService.RefreshChiCun(this, dt);
            ImpService.CountChiCun(this);
        }


        private void jisuan_Click(object sender, EventArgs e)
        {
            ImpService.CountChiCun(this);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //new Frm面料选择().ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //new Frm面料选择(kuanshiid).ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
