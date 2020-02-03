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
    public partial class UC设计点选择 : DevExpress.XtraEditors.XtraUserControl
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
        public Image pic { get; set; }
        public UC设计点选择()
        {
            InitializeComponent();
        }
        public UC设计点选择(String id,String pitemname,String pitemcd,String pitemvalue,String itemname,String itemcd,String itemvalue,String picurl)
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
            new Frm设计点(this, Frm设计点.Enum选择设计点类型.默认).ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new Frm设计点(this, Frm设计点.Enum选择设计点类型.全部).ShowDialog();
        }
        public UC设计点选择 build设计点(String itemName,String itemCd,String itemValue,String picn,Image pic)
        {
            this.itemName = itemName;
            this.itemCd = itemCd;
            this.itemValue = itemValue;
            this.textBox1.Text = itemValue + ":" + this.itemName;
            this.picn = picn;
            this.pic = pic;
            return this;
        }
    }
}
