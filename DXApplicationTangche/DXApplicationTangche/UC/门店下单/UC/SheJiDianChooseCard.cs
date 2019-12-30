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
    public partial class SheJiDianChooseCard : UserControl
    {
        public String id { get; set; }
        public String PitemName { get; set; }
        public String PitemCd { get; set; }
        public String PitemValue { get; set; }
        public String itemName { get; set; }
        public String itemCd { get; set; }
        public String itemValue { get; set; }
        public String picurl { get; set; }
        public String picn { get; set; }
        public SheJiDianChooseCard()
        {
            InitializeComponent();
        }
        public SheJiDianChooseCard(String id,String pitemname,String pitemcd,String pitemvalue,String itemname,String itemcd,String itemvalue,String picurl)
        {
            InitializeComponent();
            this.id = id;
            this.PitemName = pitemname;
            this.PitemCd = pitemcd;
            this.PitemValue = pitemvalue;
            this.itemName = itemname;
            this.itemCd = itemcd;
            this.itemValue = itemvalue;
            this.picurl = picurl;
            this.label1.Text = "·" + this.PitemName;
            this.textBox1.Text = this.itemName;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            new DefaultSheJiDian(this).ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new AllSheJiDian(this).ShowDialog();
        }
    }
}
