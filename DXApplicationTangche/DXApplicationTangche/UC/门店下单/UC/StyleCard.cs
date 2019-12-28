using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationTangche;

namespace mendian
{
    public partial class StyleCard : UserControl
    {
        public String kuanshiid = "";
        public String kuanshimingcheng = "";
        public String mianliaoid = "";
        public String mianliaomingcheng = "";
        public String banid = "";
        public String id = "";
        public String jiage = "";
        public String picture = "";
        public String styleid = "";
        public String sTYLE_CATEGORY_CD = "";
        public String sTYLE_FIT_CD = "";
        public String sTYLE_SIZE_GROUP_CD = "";
        public String sTYLE_DRESS_CATEGORY = "";
        public String sTYLE_DESIGN_TYPE = "";
        public String sTYLE_PUBLISH_CATEGORY_CD = "";
        public String sYTLE_YEAR = "";
        public String sYTLE_SEASON = "";
        public String sTYLE_SIZE_CD = "";
        public bool flag = true;

        public StyleCard()
        {
            InitializeComponent();
        }

        public StyleCard(bool flag,DataRow dr)
        {
            this.flag = flag;
            this.stylecardlabel.Text = dr["styleEntity.styleNameCn"].ToString();
            this.kuanshiid = dr["styleId"].ToString();
            this.kuanshimingcheng = dr["styleEntity.styleNameCn"].ToString();
            this.mianliaoid = dr["materialEntity.id"].ToString();
            this.mianliaomingcheng = dr["materialEntity.materialNameCn"].ToString();
            this.sTYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
            this.sTYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
            this.sTYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
            this.sTYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
            this.sTYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
            this.sTYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
            this.sYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
            this.sYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
            this.sTYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
            //sc.id = cd.id;
            //sc.banid = cd.banid;
            //sc.jiage = cd.jiage;
            this.picture = @"pic\" + dr["picn"].ToString();
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(CreateCustomer.cUSTOMER_ID==0)
            {
                MessageBox.Show("请先选择客户");
                return;
            }
            if(this.flag==false)
            {
                new Frm标准款下单具体(this).ShowDialog();
            }
            else
            {
                new Change(this).ShowDialog();
            }
        }


        //public StyleCard(string.n)
    }
}
