using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplicationTangche.service;
using DevExpress.Data;

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm已付款订单一览 : DevExpress.XtraEditors.XtraForm
    {
        public Frm已付款订单一览()
        {
            InitializeComponent();
        }

        private void Frm已付款订单一览_Load(object sender, EventArgs e)
        {
            this.gridControl订单一览.DataSource = OrderService.get未付款订单();
            this.gridView1.Columns["ORDER_DATE"].SortOrder = ColumnSortOrder.Descending;
        }
    }
}