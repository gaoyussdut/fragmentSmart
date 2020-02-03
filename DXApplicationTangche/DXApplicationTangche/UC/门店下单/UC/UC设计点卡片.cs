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
    public partial class UC设计点卡片 : DevExpress.XtraEditors.XtraUserControl
    {
        public String itemName { get; set; } = "";
        public String itemCd { get; set; } = "";
        public String itemValue { get; set; } = "";
        public String picN { get; set; } = "";
        public UC设计点选择 card = new UC设计点选择();
        public Frm设计点 allform = new Frm设计点();
        public DefaultSheJiDian form;
        
        private bool flag;
        public UC设计点卡片()
        {
            InitializeComponent();
        }
        public UC设计点卡片(String itemname, String itemcd, String itemvalue, String picn, DefaultSheJiDian form, UC设计点选择 card)
        {
            InitializeComponent();
            this.flag = true;
            this.itemName = itemname;
            this.itemCd = itemcd;
            this.itemValue = itemvalue;
            this.picN = picn;
            this.label1.Text = this.itemValue + ":" + this.itemName;
            this.form = form;
            this.card = card;
            try
            {
                this.pictureBox1.Image = Image.FromFile(@"pic\" + this.picN.Trim());
            }
            catch
            {
            }
        }
        public UC设计点卡片(String itemname, String itemcd, String itemvalue, String picn, Frm设计点 allform, UC设计点选择 card)
        {
            InitializeComponent();
            this.flag = false;
            this.itemName = itemname;
            this.itemCd = itemcd;
            this.itemValue = itemvalue;
            this.picN = picn;
            this.label1.Text = this.itemValue + ":" + this.itemName;
            this.allform = allform;
            this.card = card;
            try
            {
                this.pictureBox1.Image = Image.FromFile(@"pic\" + this.picN.Trim());
            }
            catch
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult =
            MessageBox.Show("确认保存“" + this.label1.Text + "”吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.card.itemName = this.itemName;
                this.card.itemCd = this.itemCd;
                this.card.itemValue = this.itemValue;
                this.card.textBox1.Text = this.itemValue + ":" + this.itemName;
                this.card.picn = this.picN;
                this.card.pic = this.pictureBox1.Image;
                if (this.flag == true)
                {
                    this.form.Close();
                }
                else
                {
                    this.allform.Close();
                }
            }
            else
            {
                return;
            }
        }
    }
}
