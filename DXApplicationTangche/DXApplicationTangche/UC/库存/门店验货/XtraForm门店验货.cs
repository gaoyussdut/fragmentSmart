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


        private String godown_code; //  出库单号
        private DateTime ORDER_DATE;    //  订单时间
        private String shopId;  //  门店id
        private String shopName;    //  门店名称
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


                this.godown_code = barCodeInfo.LOG_ID;
                this.ORDER_DATE = barCodeInfo.ORDER_DATE;
                this.shopId = barCodeInfo.SHOP_ID;
                this.shopName = barCodeInfo.SHOP_NAME;

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
        }
    }
}