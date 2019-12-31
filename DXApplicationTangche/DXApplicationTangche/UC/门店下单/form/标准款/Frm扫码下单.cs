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

        public enum Enum进出库类型 {期初,入库, 出库 }

        private Enum进出库类型 enum进出库类型;

        public Frm扫码下单(Enum进出库类型 enum进出库类型)
        {
            InitializeComponent();
            this.enum进出库类型 = enum进出库类型;

            if (this.enum进出库类型.Equals(Enum进出库类型.期初)) {
                this.dockPanel扫码.Text = "新建期初";
                this.label扫码.Text = "请扫码创建期初";
            }
            else if (this.enum进出库类型.Equals(Enum进出库类型.入库))
            {
                this.dockPanel扫码.Text = "入库";
                this.label扫码.Text = "请扫码入库";
            }
            else if (this.enum进出库类型.Equals(Enum进出库类型.出库))
            {
                this.dockPanel扫码.Text = "出库";
                this.label扫码.Text = "请扫码出库";
            }

            this.gridControl1.DataSource = StockService.getStopStockAll();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //  执行出入库
                StockService.generateLedge(this.enum进出库类型, this.textEdit1.Text);
            }
            catch (Exception exception){
                MessageBox.Show(exception.Message);
                return;
            }

            //  后续处理
            this.textEdit1.Text = "";
            this.gridControl1.DataSource = StockService.getStopStockAll();
            this.gridView1.RefreshData();
        }
    }
}