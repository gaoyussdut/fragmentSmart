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
                    ,Convert.ToInt32(this.comboBox订单类型.SelectedValue)
                    );
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("未找到未打印标签数据");
                }
                this.gridControl1.DataSource = dt;
            }
        }

        private void NotPrinted_Load(object sender, EventArgs e)
        {
            //  时间
            this.dateTimePicker2.Value = DateTime.Now;
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-14);
            //  UC
            this.printedView.Dock = DockStyle.Top;
            this.view.Controls.Add(printedView);
            //  出货类型
            this.comboBox订单类型.DataSource = ImpService.getOrderTypeCode();
            this.comboBox订单类型.DisplayMember = "order_type_name";
            this.comboBox订单类型.ValueMember = "order_type_id";
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
