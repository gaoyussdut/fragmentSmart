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
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;

namespace DXApplicationTangche.UC.门店下单.form.标准款
{
    public partial class Frm扫码下单 : DevExpress.XtraEditors.XtraForm
    {
        private String shopId;
        private String shopName;
        public Frm扫码下单()
        {
            InitializeComponent();
            this.gridControl1.DataSource = StockService.getStopStockAll();
        }

        public enum Enum进出库类型 {期初,入库, 出库,调拨 }

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
            else if (this.enum进出库类型.Equals(Enum进出库类型.调拨))
            {
                this.dockPanel扫码.Text = "调拨";
                this.label扫码.Text = "请扫码调拨";
                this.searchLookUpEdit1.Enabled = true;
                this.searchLookUpEdit1.Properties.DataSource = ShopService.getShopAll();
            }

            this.gridControl1.DataSource = StockService.getStopStockAll();
            this.gridView1.ExpandAllGroups();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                try
                {
                    //  执行出入库
                    StockService.generateLedge(this.enum进出库类型, this.textEdit1.Text,this.shopId);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }

                //  后续处理
                //  获取刚刚扫描的数据
                this.gridControl新成衣入库.DataSource = StockService.getStopStockByBillNo(this.textEdit1.Text);
                this.gridView2.RefreshData();
                //  刷新库存
                this.textEdit1.Text = "";
                this.gridControl1.DataSource = StockService.getStopStockAll();
                this.gridView1.RefreshData();
            }
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
            if (null != e.Value)
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
    }
}