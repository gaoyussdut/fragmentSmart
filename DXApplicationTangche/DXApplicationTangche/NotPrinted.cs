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
                DataTable dt= ImpService.GetNotPrintedData(this.textBox1.Text);
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("订单吊牌已打印");
                }
                this.gridControl1.DataSource = dt;
            }
        }
    }
}
