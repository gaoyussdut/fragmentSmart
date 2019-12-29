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
using DXApplicationTangche.UC.门店下单.form;

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
        public String flag;
        public Frm门店下单选款式 form;

        public StyleCard()
        {
            InitializeComponent();
        }

        public StyleCard(String flag, DataRow dr)
        {
            InitializeComponent();
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
        }
        public StyleCard(Frm门店下单选款式 form, String flag, DataRow dr)
        {
            InitializeComponent();
            this.form = form;
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
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if(CreateCustomer.cUSTOMER_ID==0)
            //{
            //    MessageBox.Show("请先选择客户");
            //    return;
            //}
            //if(this.flag== "标准款下单具体")
            //{
            //    new Frm标准款下单具体(this).ShowDialog();
            //}
            //else if(this.flag=="Change")
            //{
            //    new Change(this).ShowDialog();
            //}
            //else if(this.flag=="门店下单选款式")
            //{
            this.form.Dto定制下单.Style_Id = this.kuanshiid;
            this.form.Dto定制下单.STYLE_CATEGORY_CD = this.sTYLE_CATEGORY_CD;
            this.form.Dto定制下单.STYLE_FIT_CD = this.sTYLE_FIT_CD;
            this.form.Dto定制下单.STYLE_SIZE_GROUP_CD = this.sTYLE_SIZE_GROUP_CD;
            this.form.Dto定制下单.STYLE_SIZE_CD = this.sTYLE_SIZE_CD;
            ImpService.LoadChiCunCard(this.form);
            ImpService.LoadSheJiDian(this.form, this.form.Dto定制下单.Style_Id);
            Change.stylesizedt = ImpService.StyleCombobox(this.form.Dto定制下单.Style_Id);
            if (Change.stylesizedt != null)
            {
                foreach (DataRow dr in Change.stylesizedt.Rows)
                {
                    //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                    this.form.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                }
            }
            this.form.xtraTabControl1.SelectedTabPage = this.form.xtraTabControl1.TabPages[1];
            //}
        }


        //public StyleCard(string.n)
    }
}
