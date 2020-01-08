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
using DXApplicationTangche.UC.库存.service;
using DXApplicationTangche.service;

namespace DXApplicationTangche.UC.库存
{
    public partial class XtraFrm门店出库 : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<BarCodeInfoDto> barCodeInfoDtos = new BindingList<BarCodeInfoDto>();    //  条码信息
        private List<String> barCodes = new List<string>(); //  条码
        private String shopId;
        private String shopName;
        public XtraFrm门店出库()
        {
            InitializeComponent();
        }

        #region 选择门店
        private void searchLookUpEdit1_Popup(object sender, EventArgs e)
        {
            //得到当前SearchLookUpEdit弹出窗体
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl layout = popup.Controls.OfType<LayoutControl>().FirstOrDefault();
            //如果窗体内空间没有确认按钮，则自定义确认simplebutton，取消simplebutton，选中结果label
            if (layout.Controls.OfType<Control>().Where(ct => ct.Name == "btOK").FirstOrDefault() == null)
            {
                //得到空的空间
                EmptySpaceItem a = layout.Items.Where(it => it.TypeName == "EmptySpaceItem").FirstOrDefault() as EmptySpaceItem;

                //得到取消按钮，重写点击事件
                Control clearBtn = layout.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
                LayoutControlItem clearLCI = (LayoutControlItem)layout.GetItemByControl(clearBtn);
                clearBtn.Click += clearBtn_Click;

                //添加一个simplebutton控件(确认按钮)
                LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
                myLCI.TextVisible = false;
            }
        }

        private void searchLookUpEdit1View_Click(object sender, EventArgs e)
        {
            var a = this.searchLookUpEdit1.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                this.shopId //  id
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "shop_id").ToString();//id 是 Value Member
                this.shopName //  name
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "shop_name").ToString();//name 是 Display Member
            }
        }

        private void searchLookUpEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if(null!= e.Value)
                e.DisplayText = this.shopName;
        }


        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.ToolTip = null;
            searchLookUpEdit1.EditValue = null;
        }        
        #endregion

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
                    barCodeInfo = StockBillService.getStockOutBarCodeInfo(this.textEdit扫码.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误信息: " + ex.Message);
                    return;
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
            this.searchLookUpEdit1.Properties.DataSource = ShopService.getShopAll();

            //  单号生成
            this.textEdit出库单号.Text = FunctionHelper.generateBillNo("t_godown_bill", "godown_code","CH", "00000");
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
                //  出库
                StockBillService.generateStockOut(this.dateTimePicker1.Value, this.textEdit出库单号.Text, this.shopId, this.barCodeInfoDtos);
                //  提醒
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