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
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.form.订单修改;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;

namespace DXApplicationTangche.UC.门店下单.form
{

    public partial class Frm订单一览 : DevExpress.XtraEditors.XtraForm
    {
        private List<Order_Status> Order_Status = new List<Order_Status>();
        public Frm订单一览()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 初始化状态数据
        /// </summary>
        private void initStatusData() {
            this.status_code = "ORDER_STATUS-OS_20";
            this.status_name = "待加工";
            this.searchLookUpEdit1.EditValue = "待加工";

            this.Order_Status.Add(new Order_Status("客户未确认", "ORDER_STATUS-OS_05"));
            this.Order_Status.Add(new Order_Status("客户已确认", "ORDER_STATUS-OS_10"));
            this.Order_Status.Add(new Order_Status("提交待付款", "ORDER_STATUS-OS_11"));
            this.Order_Status.Add(new Order_Status("付款待确认", "ORDER_STATUS-OS_12"));
            this.Order_Status.Add(new Order_Status("已付款", "ORDER_STATUS-OS_13"));
            this.Order_Status.Add(new Order_Status("待加工", "ORDER_STATUS-OS_20"));
            this.Order_Status.Add(new Order_Status("订单取消", "ORDER_STATUS-OS_80"));
            this.Order_Status.Add(new Order_Status("客户收货", "ORDER_STATUS-OS_60"));
            this.Order_Status.Add(new Order_Status("客户退款", "ORDER_STATUS-OS_16"));
            this.Order_Status.Add(new Order_Status("已评价", "ORDER_STATUS-OS_65"));
            this.Order_Status.Add(new Order_Status("生产完成", "ORDER_STATUS-OS_40"));
            this.Order_Status.Add(new Order_Status("客户待收货", "ORDER_STATUS-OS_55"));
            this.Order_Status.Add(new Order_Status("订单返工", "ORDER_STATUS-OS_9"));
            this.searchLookUpEdit1.Properties.DataSource = this.Order_Status;
        }

        private void Frm已付款订单一览_Load(object sender, EventArgs e)
        {
            initStatusData();   //  初始化状态数据
            List<String> status = new List<string>();
            status.Add(this.status_code);
            this.gridControl订单一览.DataSource = OrderService.get订单(status);
            this.gridView1.Columns["ORDER_DATE"].SortOrder = ColumnSortOrder.Descending;
            this.gridView1.ExpandAllGroups();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            List<尺寸呈现dto>  lst = SizeService.getDto尺寸ByOrderId(
                this.gridView1.GetDataRow(e.RowHandle)["ORDER_ID"].ToString()
                ,this.gridView1.GetDataRow(e.RowHandle)["STYLE_FIT_CD"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["STYLE_CATEGORY_CD"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["STYLE_SIZE_CD"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["STYLE_SIZE_GROUP_CD"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["CUSTOMER_ID"].ToString()
                );
            //  CUSTOMER_ID


            new Frm订单预览(
                this.gridView1.GetDataRow(e.RowHandle)["STYLE_ID"].ToString()
                , lst
                , this.gridView1.GetDataRow(e.RowHandle)["ORDER_ID"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["REMARKS"].ToString()
                , this
                ).ShowDialog();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void refreshData() {
            List<String> status = new List<string>();
            status.Add(this.status_code);
            this.gridControl订单一览.DataSource = OrderService.get订单(status);
            this.gridView1.Columns["ORDER_DATE"].SortOrder = ColumnSortOrder.Descending;
            this.gridView1.RefreshData();
            this.gridView1.ExpandAllGroups();
        }


        #region 选择门店
        private String status_code;
        private String status_name;
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
                this.status_code //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "code").ToString();//id 是 Value Member
                this.status_name //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "name").ToString();//id 是 Value Member
            }

            this.refreshData();
        }

        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.ToolTip = null;
            this.searchLookUpEdit1.EditValue = null;
        }
        private void searchLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = this.status_name;
        }
        #endregion
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public class Order_Status
    {
        public String code { get; set; }
        public String name { get; set; }
        public Order_Status(String name, String code)
        {
            this.code = code;
            this.name = name;
        }
    }
}