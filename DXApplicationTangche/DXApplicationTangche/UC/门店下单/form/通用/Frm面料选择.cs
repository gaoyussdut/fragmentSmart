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
        public 门店下单选款式Model 选Model { get; set; }
        public 面料图片Model model { get; set; }
        public static int page { get; set; }
        public static String mianliaoid { get; set; }
        public static String mianliao { get; set; }
        public static String mianliaocd { get; set; }
        public String styleid { get; set; }
        public enum Enum选择面料类型 { 默认, 全部}
        public Enum选择面料类型 enum选择面料类型;

        public Frm面料选择(String styleid, Enum选择面料类型 enum选择面料类型, 门店下单选款式Model 选Model)
        {
            InitializeComponent();
            Frm面料选择.page = 1;
            this.选Model = 选Model;
            this.styleid = styleid;
            this.enum选择面料类型 = enum选择面料类型;
            this.fenYeLan1.xiaye.Click += new EventHandler(this.xiaye_Button);
            this.fenYeLan1.shangye.Click += new EventHandler(this.shangye_Button);
            if(this.enum选择面料类型==Enum选择面料类型.默认)
            {
                this.Text = "默认面料选择";
            }
            else if(this.enum选择面料类型==Enum选择面料类型.全部)
            {
                this.Text = "全部面料选择";
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            generatePictureLayout();
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
        private void Frm面料选择_Load(object sender, EventArgs e)
        {
            generatePictureLayout();
        }
        private void generatePictureLayout()
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            if(this.enum选择面料类型==Enum选择面料类型.全部)
            {
                this.model = new 面料图片Model(this.textBox1.Text, Frm面料选择.page);
            }
            else if(this.enum选择面料类型==Enum选择面料类型.默认)
            {
                this.model = new 面料图片Model(this.styleid, this.textBox1.Text, Frm面料选择.page);
            }
            this.gridControl1.DataSource = this.model.面料卡s;
            this.fenYeLan1.label1.Text = Frm面料选择.page.ToString();
            this.splashScreenManager.CloseWaitForm();
        }

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Frm面料选择.mianliao = (String)tileView1.GetRowCellValue(e.Item.RowHandle, "materialname");
                String id = (String)tileView1.GetRowCellValue(e.Item.RowHandle, "materialid");
                this.选Model.Dto定制下单.build面料(id);
                foreach (款式信息dto dto in this.选Model.款式信息)
                {
                    if (dto.tab == "m")
                    {
                        this.选Model.款式信息.Remove(dto);
                        this.选Model.款式信息.Add(new 款式信息dto(this.选Model.Dto定制下单.SYTLE_FABRIC_ID));
                        break;
                    }
                }
                this.Close();
            }      
        }
    }
}
