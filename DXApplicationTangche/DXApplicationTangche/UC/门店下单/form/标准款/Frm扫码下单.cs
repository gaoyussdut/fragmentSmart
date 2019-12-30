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

namespace DXApplicationTangche.UC.门店下单.form.标准款
{
    public partial class Frm扫码下单 : DevExpress.XtraEditors.XtraForm
    {
        public Frm扫码下单()
        {
            InitializeComponent();
            this.gridControl1.DataSource = StockService.getStopStockAll();
        }
    }
}