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
    public partial class SheJiDianCard : UserControl
    {
        public String itemName { get; set; } = "";
        public String itemCd { get; set; } = "";
        public String itemValue { get; set; } = "";
        public String picN { get; set; } = "";
        public SheJiDianChooseCard card = new SheJiDianChooseCard();
        public AllSheJiDian allform = new AllSheJiDian();
        public DefaultSheJiDian form;
        
        private bool flag;
        public SheJiDianCard()
        {
            InitializeComponent();
        }
        public SheJiDianCard(String itemname, String itemcd, String itemvalue, String picn, DefaultSheJiDian form, SheJiDianChooseCard card)
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
        public SheJiDianCard(String itemname, String itemcd, String itemvalue, String picn, AllSheJiDian allform, SheJiDianChooseCard card)
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
