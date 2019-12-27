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
using mendian;

namespace DXApplicationTangche
{
    public partial class NotPrinted : DevExpress.XtraEditors.XtraForm
    {
        public NotPrinted()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                DataTable dt= ImpService.GetNotPrintedData(
                    this.textBox1.Text
                    , this.dateTimePicker1.Value
                    , this.dateTimePicker2.Value
                    );
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("订单吊牌已打印");
                }
                this.gridControl1.DataSource = dt;
            }
        }

        private void NotPrinted_Load(object sender, EventArgs e)
        {
            this.dateTimePicker2.Value = DateTime.Now;
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);
        }
    }
}
