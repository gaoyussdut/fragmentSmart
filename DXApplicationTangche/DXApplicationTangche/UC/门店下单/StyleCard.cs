using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public StyleCard(bool flag)
        {
            this.flag = flag;
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
                
            }
            else
            {
                new Change(this).ShowDialog();
            }
        }


        //public StyleCard(string.n)
    }
}
