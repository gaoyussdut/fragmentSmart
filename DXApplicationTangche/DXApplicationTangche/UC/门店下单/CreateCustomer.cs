using DiaoPaiDaYin;
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
    public partial class CreateCustomer : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public static int cUSTOMER_ID { get; set; }
        public String sEX_CD;
        public String sexno;
        //public int cUSTOMER_FIT_ID;
        public static int aDDRESS_ID;
        public static String customer_name { get; set; }
        public static int customer_countid { get; set; }
        public CreateCustomer()
        {
            InitializeComponent();
            initCombobox();
        }
        private void initCombobox()
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT * FROM a_sys_area WHERE PARENT_CODE='7'");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.shengfen.Items.Add(Convert.ToString(dr["TREE_PATH"]));
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(this.shengao.Text==""||this.tizhong.Text==""||this.tixing.Text==""||this.jianxing.Text==""||this.fuxing.Text==""||this.tunxing.Text=="")
            {
                MessageBox.Show("请填写完整");
                return;
            }
            ImpService.customerZero(this);
            customer_name = this.xing.Text + this.ming.Text;
            
            if (this.sex.Text == "男")
            {
                sEX_CD = "SEX-M_10";
                sexno = "0";
            }
            else
            {
                sEX_CD = "SEX-W_20";
                sexno = "1";
            }
            DataRow dr_customerid = SQLmtm.GetDataRow("SELECT MAX(CUSTOMER_ID) AS CUSTOMER_ID FROM a_customer_p ");
            cUSTOMER_ID= Convert.ToInt32(dr_customerid["CUSTOMER_ID"]);
            cUSTOMER_ID++;
            int i1= SQLmtm.DoInsert("a_customer_p",new string[] { "CUSTOMER_ID", "CUSTOMER_FIRST_NAME" , "CUSTOMER_LAST_NAME", "MOBILE" , "DEFAULT_ADDR_FLAG" , "SEX_CD" , "E_MAIL_URL" , "DELETE_FLAG", "VERSION", "CUSTOMER_STATUS" },
            new string[] { cUSTOMER_ID.ToString(),this.xing.Text,this.ming.Text,this.shouji.Text,"0",sEX_CD,this.eml.Text,"0","1", "CUSTOMER_SOURCE-CS_SHOP" });
            if (i1!=1)
            {
                MessageBox.Show("保存失败");
            }

            //a_customer_fit_count_r           
            int i14 = SQLmtm.DoInsert("a_customer_fit_count_r", new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "SEX", "AGE", "CREATE_DATE", "DELETE_FLAG", "DEFAULT_FLAG", "DATA_COMPLETE" },
                new string[] { cUSTOMER_ID.ToString(), customer_name, sexno, this.nianling.Text, DateTime.Now.ToUniversalTime().ToString(), "0", "1", "1" });
            DataRow dr_customer_countid = SQLmtm.GetDataRow("SELECT MAX(ID) AS ID FROM a_customer_fit_count_r");
            customer_countid = Convert.ToInt32(dr_customer_countid["ID"]);
            if (i14!=1)
            {
                MessageBox.Show("保存失败");
            }

            //门店客户表
            int i2 =SQLmtm.DoInsert("a_shop_customer_r", new string[] { "SHOP_CUSTOMER_ID", "SHOP_ID", "CUSTOMER_ID" }, new string[] { (cUSTOMER_ID - 1).ToString(), "18", cUSTOMER_ID.ToString() });
            ////取量体id
            //DataRow dr_customerfitid = SQLmtm.GetDataRow("SELECT MAX(CUSTOMER_FIT_ID) AS CUSTOMER_FIT_ID FROM a_customer_fit_r");
            //cUSTOMER_FIT_ID = Convert.ToInt32(dr_customerfitid["CUSTOMER_FIT_ID"]);
            //cUSTOMER_FIT_ID++;
            if (i2 != 1)
            {
                MessageBox.Show("保存失败");
            }
            //身高
            int i3= SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
                new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_09", "0", this.shengao.Text,customer_countid.ToString() });
            if (i3 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //体重
            int i4= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
                    new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_10", "0", this.tizhong.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i4 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //肩宽CODE
            int i5= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_05", "0", this.jiankuan.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i5 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //胸围CODE
            int i6= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_02", "0", this.xiongwei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i6 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //腰围CODE
            int i7= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_12", "0", this.yaowei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i7 != 1)
            {
                MessageBox.Show("保存失败");
            }
            //臀围CODE
            int i8= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_03", "0", this.tunwei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i8 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //身长CODE
            int i9= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_04", "0", this.shenchang.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i9 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //领围CODE
            int i10= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_01", "0", this.lingwei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i10 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //腕围CODE
            int i11= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_08", "0", this.wanwei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i11 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //袖长CODE
            int i12= SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_06", "0", this.xiuchang.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i12 != 1)
            {
                MessageBox.Show("保存失败");
            }

            //上臂袖肥CODE
            int i13=SQLmtm.DoInsert("a_customer_fit_r", new string[] {  "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
        new string[] {  cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_ITEM_07", "0", this.shangbixiufei.Text, customer_countid.ToString() });
            //cUSTOMER_FIT_ID++;
            if (i13 != 1)
            {
                MessageBox.Show("保存失败");
            }
            //腹型CODE

            switch (this.fuxing.Text)
            {
                case "凹陷":SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_02", "0", "4", customer_countid.ToString() });break;
                case "平坦":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_02", "0", "5", customer_countid.ToString() }); break;
                case "微凸":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_02", "0", "6", customer_countid.ToString() }); break;
                case "中凸":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_02", "0", "7", customer_countid.ToString() }); break;
                case "重凸":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_02", "0", "8", customer_countid.ToString() }); break;
            }
            //cUSTOMER_FIT_ID++;
            //体型CODE
            switch(this.tixing.Text)
            {
                case "超瘦":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_01", customer_countid.ToString() });break;
                case "标准":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_02", customer_countid.ToString() }); break;
                case "微胖":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_03", customer_countid.ToString() }); break;
                case "肥胖":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_04", customer_countid.ToString() }); break;
                case "肌肉":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_05", customer_countid.ToString() }); break;
                case "健身达人":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_03", "0", "CD03_06", customer_countid.ToString() }); break;

            }
            //cUSTOMER_FIT_ID++;
            //特征CODE
            switch(this.shentitezheng.Text)
            {
                case "背部厚实":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_01", customer_countid.ToString() });break;
                case "脖子特别粗":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_02", customer_countid.ToString() }); break;
                case "臀部特别大":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_03", customer_countid.ToString() }); break;
                case "手臂特别长":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_04", customer_countid.ToString() }); break;
                case "肩部特别宽":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_05", customer_countid.ToString() }); break;
                case "脖子特别短":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_05", "0", "CD05_06", customer_countid.ToString() }); break;


            }

            
            //cUSTOMER_FIT_ID++;
            //肩型
            switch(this.jianxing.Text)
            {
                case "平肩":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
            new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_01", "0", "1", customer_countid.ToString() });break;
                case "溜肩":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
            new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_01", "0", "2", customer_countid.ToString() }); break;
                case "正常":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
            new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_01", "0", "3", customer_countid.ToString() }); break;


            }
            //cUSTOMER_FIT_ID++;
            //背型
            switch(this.tunxing.Text)
            {
                case "挺胸":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_04", "0", "CD04_01", customer_countid.ToString() }); break;
                case "直背":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE" , "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_04", "0", "CD04_02", customer_countid.ToString() }); break;
                case "驼背":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_04", "0", "CD04_03", customer_countid.ToString() }); break;

            }
            //cUSTOMER_FIT_ID++;
            //臀型
            switch (this.tunxing.Text)
            {
                case "正常":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_07", "0", "1", customer_countid.ToString() }); break;
                case "翘臀":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_07", "0", "2", customer_countid.ToString() }); break;
                case "平臀":
                    SQLmtm.DoInsert("a_customer_fit_r", new string[] { "CUSTOMER_ID", "STYLE_CATEGORY_CD", "ITEM_CD", "ITEM_VALUE", "DELETE_FLAG", "FIT_VALUE", "FIT_COUNT_ID" },
new string[] { cUSTOMER_ID.ToString(), "STYLE_CATEGORY-SHIRT", "SHIRT_FITMT004", "FITMT_CODE_07", "0", "3", customer_countid.ToString() }); break;

            }
            DataRow dr_addressid = SQLmtm.GetDataRow("SELECT MAX(ADDRESS_ID) AS ADDRESS_ID FROM a_customer_address_p");
            aDDRESS_ID = Convert.ToInt32(dr_addressid["ADDRESS_ID"]);
            aDDRESS_ID++;
            SQLmtm.DoInsert("a_customer_address_p", new string[] {"ADDRESS_ID" ,"CUSTOMER_ID", "DEFAULT_ADDR_FLAG", "CONSIGNEE", "ADDRESS_PROVINCE_CD", "ADDRESS_CITY_CD", "ADDRESS_DISTRICT", "ADDRESS_DETAIL", "ZIP_CODE", "MOBILE", "DELETE_FLAG" },
                new string[] { aDDRESS_ID.ToString(),cUSTOMER_ID.ToString(), "1", this.shouhuoren.Text, this.shengfen.Text, this.chengshi.Text, this.qvyv.Text, this.xiangxidizhi.Text, this.youbian.Text, this.shoujianshouji.Text, "0" });
            String listFitData=null;            
            try
            {
                DataTable dt = SQLmtm.GetDataTable("SELECT CUSTOMER_ID,ITEM_CD,ITEM_VALUE,FIT_VALUE FROM `a_customer_fit_r` WHERE FIT_COUNT_ID='" + customer_countid.ToString() + "'");
                foreach(DataRow dr in dt.Rows)
                {
                    listFitData = listFitData + dr["ITEM_CD"].ToString() +"-"+ dr["ITEM_VALUE"].ToString()+":"+dr["FIT_VALUE"]+",";
                }
            }
            catch
            {
                MessageBox.Show("保存失败");
                return;
            }
            FitValueCalculate fvc = new FitValueCalculate(customer_countid.ToString(),listFitData);

            String fjsondata = Newtonsoft.Json.JsonConvert.SerializeObject(fvc);
            //String entryDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(class1);
            RestCall.PostHttp("https://shirtmtm.com/fragsmart-mtm/customer/update/update", fjsondata);
            //RestCall.PostHttp("http://localhost:8080/customer/update/update", fjsondata);
            MessageBox.Show("保存成功");
            this.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if(this.xing.Text==""||this.ming.Text==""||this.shouji.Text=="")
            {
                MessageBox.Show("请填写完整");
                return;
            }
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(this.shouhuoren.Text==""||this.shengfen.Text==""||this.chengshi.Text==""||this.qvyv.Text==""||this.xiangxidizhi.Text==""||this.youbian.Text==""||this.shoujianshouji.Text=="")
            {
                MessageBox.Show("请填写完整");
                return;
            }
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void shengfen_TextChanged(object sender, EventArgs e)
        {
            this.chengshi.Items.Clear();
            this.qvyv.Items.Clear();
            try
            {
                DataTable dt = SQLmtm.GetDataTable("SELECT a1.AREA_ID,a2.PARENT_CODE,a1.TREE_PATH AS shengfen,a2.AREA_NAME AS chengshi FROM (SELECT * FROM a_sys_area  WHERE TREE_PATH='" + this.shengfen.Text + "')AS a1 LEFT JOIN a_sys_area a2 ON a1.AREA_ID=a2.PARENT_CODE ");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.chengshi.Items.Add(Convert.ToString(dr["chengshi"]));
                    }
                }
            }
            catch
            {

            }
        }

        private void chengshi_TextChanged(object sender, EventArgs e)
        {
            this.qvyv.Items.Clear();
            try
            {
                DataTable dt = SQLmtm.GetDataTable("SELECT a1.AREA_ID,a2.PARENT_CODE,a1.AREA_NAME AS chengshi,a2.AREA_NAME AS qvyv FROM (SELECT * FROM a_sys_area  WHERE AREA_NAME='" + this.chengshi.Text + "')AS a1 LEFT JOIN a_sys_area a2 ON a1.AREA_ID=a2.PARENT_CODE ;");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.qvyv.Items.Add(Convert.ToString(dr["qvyv"]));
                    }
                }
            }
            catch
            {

            }
        }
    }
}
