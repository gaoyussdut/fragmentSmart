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
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DevExpress.Utils.Win;
using mendian;
using DiaoPaiDaYin;
using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.门店下单.form.标准款;

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm门店统一下单 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 订单充血类
        /// </summary>
        private OrderModel orderModel = new OrderModel();

        public enum Enum下单类型 { 服装定制下单,标准款扫码下单,标准款无码下单 };

        public Frm门店统一下单()
        {
            InitializeComponent();
            //this.initData();    //  测试方法
            this.gridControl订单分录一览.DataSource = this.orderModel.OrderDtos;
            this.textEdit订单号.Text = FunctionHelper.generateBillNo(
                "t_shop_order", "order_code","SALE","00000"
                );// TODO，单号
        }

        /// <summary>
        /// 新增分录
        /// </summary>
        public void buildOrderModel(Dto定制下单 dto定制下单) {
            this.orderModel.buildAddOrderDtos(dto定制下单);
        }

        //  测试方法
        private void initData() {
            this.orderModel.buildAddOrderDtos("257","18","春衫SSHIRT","70053","SS.SSWX.180415",1,Convert.ToDateTime("2018/11/2 20:59"),"EGS_GROUP_SIZE - 48","正装舒适款","2018","秋季","70008","8755","蓝色经典提花","MATERIAL_COLOR - BLUE","男士衬衫",1, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("275", "18","春衫SSHIRT","70057","SS.SSWX.180416",1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 42","正装舒适款","2018","秋季","70008","8755","蓝色经典提花","MATERIAL_COLOR - BLUE","男士衬衫",1, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("258", "18","春衫SSHIRT","70061","SS.SSWX.180417",1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 44","正装修身款","2018","秋季","70009","8749","白色经典斜纹","MATERIAL_COLOR - WHITE","男士衬衫",1, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("281", "18","春衫SSHIRT","70062","SS.SSWX.180418",1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 42","正装修身款","2018","秋季","70009","8755","蓝色经典提花","MATERIAL_COLOR - BLUE","男士衬衫",1, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("284", "18","春衫SSHIRT","70064","SS.SSWX.180419",1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 44","正装修身款","2018","秋季","70009","8753","白色经典提花","MATERIAL_COLOR - WHITE","男士衬衫",1, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("281", "18", "春衫SSHIRT", "70062", "SS.SSWX.180418", 1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 42", "正装修身款", "2018", "秋季", "70009", "8755", "蓝色经典提花", "MATERIAL_COLOR - BLUE", "男士衬衫", 2, "SSXF02.jpg");
            this.orderModel.buildAddOrderDtos("284", "18", "春衫SSHIRT", "70064", "SS.SSWX.180419", 1, Convert.ToDateTime("2018/11/2 20:59"), "EGS_GROUP_SIZE - 44", "正装修身款", "2018", "秋季", "70009", "8753", "白色经典提花", "MATERIAL_COLOR - WHITE", "男士衬衫", 2, "SSXF02.jpg");
        }

        private void Frm门店统一下单_Load(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.Properties.DataSource = ImpService.GetCustomerData("");
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
                CreateCustomer.cUSTOMER_ID //  no
                    = Convert.ToInt32(this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());//id 是 Value Member
                CreateCustomer.customer_name //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "客户姓名").ToString();//id 是 Value Member
            }
            DataTable dt = SQLmtm.GetDataTable("SELECT * FROM (SELECT * FROM a_customer_fit_r) s1 RIGHT JOIN (SELECT * FROM a_customer_fit_count_r WHERE CUSTOMER_ID ='" + CreateCustomer.cUSTOMER_ID + "' AND DEFAULT_FLAG ='1') s2 on s1.FIT_COUNT_ID=s2.ID");
            if (dt.Rows.Count != 0)
            {
                DataRow drr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_fit_count_r` WHERE CUSTOMER_ID='" + CreateCustomer.cUSTOMER_ID.ToString() + "' AND DEFAULT_FLAG=1");
                DataRow ddr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_address_p` WHERE DEFAULT_ADDR_FLAG=1 AND CUSTOMER_ID='" + CreateCustomer.cUSTOMER_ID.ToString() + "'");
                if (drr == null || ddr == null)
                {
                    CreateCustomer.cUSTOMER_ID = 0;
                    CreateCustomer.customer_name = "";
                    MessageBox.Show("缺少客户信息");
                    return;
                }
                CreateCustomer.customer_countid = Convert.ToInt32(drr["ID"]);
                CreateCustomer.aDDRESS_ID = Convert.ToInt32(ddr["ADDRESS_ID"]);
            }
            else
            {
                CreateCustomer.cUSTOMER_ID = 0;
                CreateCustomer.customer_name = "";
                MessageBox.Show("选择的客户未建立量体值");
                return;
            }
            this.gridControl2.DataSource = ImpService.GetCustomerInformation(CreateCustomer.cUSTOMER_ID);
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
        private void searchLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = CreateCustomer.customer_name;
        }
        #endregion

        private void tileBarItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            new Frm门店下单选款式(this,Enum下单类型.服装定制下单).ShowDialog();
        }

        private void tileBarItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            new Frm门店下单选款式(this, Enum下单类型.标准款无码下单).ShowDialog();
        }

        public void refreshGridControl()
        {
            this.gridControl订单分录一览.DataSource = this.orderModel.OrderDtos;
            this.tileView1.RefreshData();
        }

        private void tileBarItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            new Frm扫码下单().ShowDialog();
        }


        private void tileView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            String ID = (String)tileView1.GetRowCellValue(e.FocusedRowHandle, "ID");
            DataRow dataRow = this.tileView1.GetDataRow(this.tileView1.FocusedRowHandle);

            List<Dto设计点> dto设计点s = new List<Dto设计点>();
            foreach (OrderDto orderDto in this.orderModel.OrderDtos)
            {
                if (ID.Equals(orderDto.ID))
                {
                    dto设计点s = orderDto.Dto设计点s;
                    break;
                }
            }
            this.gridControl设计点.DataSource = dto设计点s;
            this.tileView1.RefreshData();
        }
    }
}