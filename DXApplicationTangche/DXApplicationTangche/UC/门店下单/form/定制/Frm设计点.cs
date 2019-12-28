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
    public partial class AllSheJiDian : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        private SheJiDianChooseCard card;
        private PanelLocition panelLocition;
        private int height = 0;
        private int width = 0;
        public AllSheJiDian()
        {
            InitializeComponent();
        }

        public AllSheJiDian(SheJiDianChooseCard card)
        {
            InitializeComponent();
            this.card = card;
            this.Text = this.card.PitemName;
            DoButtonClick("");
        }
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            DoButtonClick(this.textBox11.Text);
        }

        private void DoButtonClick(String str)
        {
            this.splashScreenManager1.ShowWaitForm();
            this.splashScreenManager1.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager1.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
"	s1.itemValue ,\n" +
"	s1.itemNameCn ,\n" +
"	s1.itemCode ,\n" +
"S2.UPLOAD_FILE AS picn,\n" +
"	s2.picurl \n" +
"FROM\n" +
"	(\n" +
"	SELECT\n" +
"		ap.ITEM_VALUE itemValue,\n" +
"		ap.DESIGN_ID id,\n" +
"		CONCAT( ap.ITEM_VALUE, \":\", ap.ITEM_NAME_CN ) itemNameCn,\n" +
"		ap.ITEM_CD itemCode,\n" +
"		adp.ITEM_CD itemParentCode \n" +
"	FROM\n" +
"		a_designoption_p ap\n" +
"		LEFT JOIN a_designoption_p adp ON adp.ITEM_VALUE = ap.ITEM_CD\n" +
"		LEFT JOIN a_ognization_desgin_r adr ON ap.DESIGN_ID = adr.DESGIN_ID \n" +
"	WHERE\n" +
"		( ap.ITEM_CATEGORY_CD = \"\" OR ap.ITEM_CATEGORY_CD IS NULL ) \n" +
"		AND ap.STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT' \n" +
"		AND ap.ITEM_CD = '"+this.card.PitemValue+"' -- AND ap.ITEM_CD IN ( SELECT ap.ITEM_VALUE itemValue FROM a_designoption_p ap WHERE ap.ITEM_CATEGORY_CD ='ITEM_TYPE_CD-10' )\n" +
"		AND (ap.ITEM_VALUE LIKE '%"+str+"%' OR ap.ITEM_NAME_CN LIKE '%"+str+"%')\n" +
"		AND adr.OGNIZATION_ID = 95 \n" +
"		AND ap.ITEM_VALUE IN (\n" +
"		SELECT\n" +
"			ap.ITEM_VALUE itemValue \n" +
"		FROM\n" +
"			a_designoption_p ap \n" +
"		WHERE\n" +
"			ap.DESIGN_ID IN ( SELECT ar.DESGIN_ID FROM a_shop_desgin_r ar WHERE ar.SHOP_ID = 18 ) \n" +
"		) \n" +
"	ORDER BY\n" +
"		ap.ITEM_CD,\n" +
"		ap.ITEM_SORT ASC \n" +
"	) AS s1\n" +
"	LEFT JOIN (\n" +
"	SELECT\n" +
"		a.ITEM_CD,\n" +
"		a.ITEM_VALUE,\n" +
"		a.ITEM_NAME_CN,\n" +
"		CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', w.UPLOAD_FILE ) AS picurl,\n" +
"		w.* \n" +
"	FROM\n" +
"		a_designoption_p a\n" +
"		LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID \n" +
"	WHERE\n" +
"		a.FILE_ID IS NOT NULL \n" +
"	) AS s2 ON s1.itemCode = s2.ITEM_CD \n" +
"	AND s1.itemValue = s2.ITEM_VALUE");

            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                SheJiDianCard card = new SheJiDianCard(dr["itemNameCn"].ToString(), dr["itemCode"].ToString(), dr["itemValue"].ToString(), dr["picn"].ToString(), this, this.card);
                this.generateUserControl(card, i);
                this.panel1.Controls.Add(card);//将控件加入panel
                //oc.pictureBox1.Click += new EventHandler(this.picture_Click);
                i++;
            }
            this.splashScreenManager1.CloseWaitForm();
        }

        public void generateUserControl(UserControl userControl, int i)
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
