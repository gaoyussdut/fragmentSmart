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

namespace DXApplicationTangche.UC.库存.门店验货
{
    public partial class XtraForm门店验货 : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<BarCodeInfoDto> barCodeInfoDtos = new BindingList<BarCodeInfoDto>();    //  条码信息
        private List<String> barCodes = new List<string>(); //  条码
        private String shopId;
        private String shopName;
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
                String sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                    "where Id not in (select barcode_id from t_godown_entry) and LOG_ID = '" + this.textEdit扫码.Text+"'";

                DataTable dt = SQLmtm.GetDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                    "where LOG_ID = '" + this.textEdit扫码.Text + "'";
                    dt = SQLmtm.GetDataTable(sql);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("系统中无本产品标签列印信息");
                    }
                    else {
                        MessageBox.Show("本商品已出库");
                    }
                    return;
                }
                else {
                    BarCodeInfoDto barCodeInfo = new BarCodeInfoDto(dt);
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
        }

        private void XtraFrm门店出库_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.shopId)) {
                MessageBox.Show("请选择门店");
                return;
            }
            if (this.barCodeInfoDtos.Count == 0)
            {
                MessageBox.Show("请选择出货成衣");
                return;
            }


            DialogResult dialogResult= MessageBox.Show("确认出货？", "出货提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.OK) {
                String godown_id = System.Guid.NewGuid().ToString("N");
                //  出货单
                SQLmtm.DoInsert(
                    "t_godown_bill"
                    , new string[] { "godown_id", "godown_date", "godown_code", "shop_id" }
                    , new string[] { godown_id, this.dateTimePicker1.Value.ToString(), this.textEdit出库单号.Text, this.shopId }
                    );
                //  出货单分录           
                foreach (BarCodeInfoDto barCodeInfo in this.barCodeInfoDtos)
                {
                    SQLmtm.DoInsert(
                        "t_godown_entry"
                        , new string[] { "godown_entry_id", "godown_id", "barcode_id", "is_validate" }
                        , new string[] { System.Guid.NewGuid().ToString("N"), godown_id, barCodeInfo.Id, "1" }
                        );
                }


                MessageBox.Show("出库单号"+this.textEdit出库单号.Text + "已出库完成");
                //  单号变更
                this.textEdit出库单号.Text = FunctionHelper.generateBillNo("t_godown_bill", "godown_code", "CH", "00000");
                //  清空成衣列表
                this.barCodeInfoDtos.Clear();
                this.barCodes.Clear();
                //  TODO,不确定是否做清空门店
            }
        }
    }
}