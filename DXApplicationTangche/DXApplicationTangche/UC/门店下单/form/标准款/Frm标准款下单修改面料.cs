using DiaoPaiDaYin;
using mendian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplicationTangche
{
    public partial class Frm标准款下单具体 : DevExpress.XtraEditors.XtraForm
    {
        public DataTable chooseStyleSize = new DataTable();
        public PrintedView printedView = new PrintedView();
        public UC款式卡片 styleCard { get; set; }
        public Frm标准款下单具体()
        {
            InitializeComponent();
        }
        public Frm标准款下单具体(UC款式卡片 styleCard)
        { 
            ImpService.ClearStaticVariable();
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            this.styleCard = styleCard;
            InitializeComponent();
            this.label8.Text = styleCard.stylecardlabel.Text;
            Change.kuanshiid = styleCard.kuanshiid;
            try
            {
                this.pictureBox1.Image = Image.FromFile(styleCard.picture);
            }
            catch
            {

            }
        }
        private void Frm标准款下单具体_Load(object sender, EventArgs e)
        {
            Change.stylesizedt = ImpService.StyleCombobox(styleCard.kuanshiid);
            if (Change.stylesizedt != null)
            {
                foreach (DataRow dr in Change.stylesizedt.Rows)
                {
                    //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                    this.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                }
            }
            this.printedView.Dock = DockStyle.Top;
            this.dockPanel2.Controls.Add(printedView);
        }

        private void mianliaoname_Click(object sender, EventArgs e)
        {
            //new Frm面料选择(Change.kuanshiid).ShowDialog();
        }

        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.chooseStyleSize = ImpService.StyleValue(this.chicun01.Text.Trim().ToString(), styleCard.kuanshiid, Change.stylesizedt);
                this.gridControl1.DataSource = this.chooseStyleSize;
                Change.sTYLE_SIZE_CD = this.chooseStyleSize.Rows[0]["SIZE_CD"].ToString();
            }
            catch
            {

            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //new Frm面料选择().ShowDialog();
        }

        private void Frm标准款下单具体_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = Frm面料选择.mianliao;
            try
            {
                List<CustomerInformation> ci = ImpService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
                this.printedView.refresh(
                    @"pic\" + ImpService.GetMianLiaoFile(Frm面料选择.mianliaoid), ci);
            }
            catch
            {
            }
        }

        private void stylechangesave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.shuliang.Text == "" || this.mianliaoname.Text == "" || this.chicun01.Text == "")
                {
                    MessageBox.Show("请填写完整");
                    return;
                }
                try
                {
                    Change.styleid = ImpService.GetNewStyleID();
                    //尺寸保存
                    ImpService.StandardModelsSizeSive(this.chooseStyleSize);
                    //s_style_p写入数据
                    ImpService.insertS_Style_P(styleCard);
                    //设计点保存
                    ImpService.StandardModelsDesignSive();
                    //o_order_p写入数据
                    //RestCall.httpGetMethod("https://shirtmtm.com/fragsmart-mtm/customer/update/payment?styleId=" + styleid.ToString() + "&customerId=" + CreateCustomer.cUSTOMER_ID.ToString() + "&addressId=" + CreateCustomer.aDDRESS_ID.ToString() + "&number=" + this.shuliang.Text);
                    RestCall.httpGetMethod("http://localhost:8080/customer/update/payment?styleId=" + Change.styleid.ToString() + "&customerId=" + CreateCustomer.cUSTOMER_ID.ToString() + "&addressId=" + CreateCustomer.aDDRESS_ID.ToString() + "&number=" + this.shuliang.Text);
                    DataRow ORDER_ID = SQLmtm.GetDataRow("SELECT MAX(ORDER_ID) AS ORDER_ID FROM `o_order_p`");
                    int order_id = Convert.ToInt32(ORDER_ID["ORDER_ID"]);
                    //order_id++;
                    SQLmtm.DoInsert("o_order_brand_r", new string[] { "OGNIZATION_ID", "SHOP_ID", "BRAND_ID", "ORDER_ID" }, new string[] { "95", "18", "", order_id.ToString() });
                    SQLmtm.DoInsert("t_order_type", new string[] { "ORDER_ID", "ORDER_TYPE" }, new string[] { order_id.ToString(), "2" });
                    MessageBox.Show("保存成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                return;
            }

        }
    }
}
