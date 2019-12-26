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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.UC.库存;
using DXApplicationTangche.UC.库存.service;

namespace DXApplicationTangche.UC.库存.门店验货
{
    public partial class XtraForm门店验货 : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<BarCodeInfoDto> barCodeInfoDtos = new BindingList<BarCodeInfoDto>();    //  条码信息
        private List<String> barCodes = new List<string>(); //  条码
        private String shopId;  //  门店id

        public XtraForm门店验货()
        {
            InitializeComponent();
        }


        private void textEdit扫码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                if (this.barCodes.Contains(this.textEdit扫码.Text))
                {
                    //  重复扫描
                    this.textEdit扫码.Text = "";
                    return;
                }

                BarCodeInfoDto barCodeInfo;
                try
                {
                    barCodeInfo = StockService.getStockInBarCodeInfo(this.textEdit扫码.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误信息: " + ex.Message);
                    return;
                }

                //  订单信息更新
                if (String.IsNullOrEmpty(this.textEdit出库单号.Text))
                {
                    DataTable dataTable = StockService.getStockInInfo(barCodeInfo.LOG_ID);
                    this.textEdit出库单号.Text = dataTable.Rows[0]["godown_code"].ToString();
                    this.dateTimePicker1.Value = Convert.ToDateTime(dataTable.Rows[0]["godown_date"].ToString());
                    this.textEdit门店.Text = dataTable.Rows[0]["shop_name"].ToString(); 
                    this.shopId = dataTable.Rows[0]["shop_id"].ToString();
                }


                //  条码记录
                this.barCodes.Add(barCodeInfo.LOG_ID);
                this.textEdit扫码.Text = "";
                //  条码信息
                this.barCodeInfoDtos.Add(barCodeInfo);
                //  刷新数据源
                this.gridControl1.DataSource = this.barCodeInfoDtos;
                //this.pivotGridControl.ForceInitialize();
                this.pivotGridControl.DataSource = this.barCodeInfoDtos;
                this.pivotGridControl.RefreshData();
            }
        }

        private void XtraFrm门店出库_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<String> barIds = new List<string>();
            foreach (BarCodeInfoDto barCodeInfo in this.barCodeInfoDtos) {
                barIds.Add(barCodeInfo.Id);
            }
            if (barIds.Count == 0) {
                MessageBox.Show("请先扫码");
                return;
            }


            DialogResult dialogResult = MessageBox.Show("确认入库？", "入库提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.OK)
            {
                //  库存明细账
                StockService.generateInventoryLedge(barIds, this.shopId, this.textEdit出库单号.Text, "验货入库", false);
                //  提醒
                MessageBox.Show("出库单号" + this.textEdit出库单号.Text + "已入库完成");
                //  单号变更
                this.textEdit出库单号.Text = null;
                //  清空成衣列表
                this.barCodeInfoDtos.Clear();
                this.barCodes.Clear();
                //  TODO,不确定是否做清空门店
            }
        }
    }
}