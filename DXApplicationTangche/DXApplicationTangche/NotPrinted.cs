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
        public PrintedView printedView = new PrintedView();
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
                if (dt.Rows.Count==0)
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
            this.printedView.Dock = DockStyle.Top;
            this.view.Controls.Add(printedView);
        }

        private void gridView11_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            List<CustomerInformation> ci = ImpService.GetCustomerInformation(Convert.ToInt32(dr["CUSTOMER_ID"].ToString()));
            ci = ImpService.AddSomething(ci, "订单时间", dr["ORDER_DATE"].ToString());
            try
            {
                this.printedView.refresh(
                    @"pic\" + ImpService.GetMianLiaoFile(dr["SYTLE_FABRIC_ID"].ToString()).Trim()
                    , ci
                    );
            }
            catch
            {
            }

        }
    }
}
