using DXApplicationTangche.DTO;
using DXApplicationTangche.model;
using DXApplicationTangche.OldQuote.BLL;
using DXApplicationTangche.service;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DXApplicationTangche.UC.任务.任务模板UC
{
    public partial class UC裁剪条码打印 : UserControl
    {
        裁剪条码打印Model Model;
        DataTable printTbl;
        public int userId = 0;
        public String ORDER_ID { get; set; }//订单id
        public UC裁剪条码打印(String orderid)
        {
            this.ORDER_ID = orderid;
            InitializeComponent();
            this.txtBarCode.Text = OrderService.GetSBCWithOrderid(ORDER_ID);
            if (checkFrom())
            {
                // 设置画面显示列表数据
                setGridViewList(setWhere());
                ProduceService.UpData裁剪条码打印生产工序(this.ORDER_ID);
            }
        }
        public UC裁剪条码打印()
        {
            InitializeComponent();
        }
        private void UC裁剪条码打印_Load(object sender, EventArgs e)
        {
            //this.labelLine.Width = this.Width;
            this.txtClipNumber.Text = "0";

            this.ActiveControl = this.txtBarCode;
            //this.AcceptButton = this.butPrint;
            //隐藏窗口边框  
            //this.ControlBox = false;
            //获取屏幕的宽度和高度  
            int w = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
            int h = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
            //设置最大尺寸  和  最小尺寸  （如果没有修改默认值，则不用设置）  
            //this.MaximumSize = new Size(w, h);
            //this.MinimumSize = new Size(w, h);
            //设置窗口位置  
            //this.Location = new Point(0, 0);
            //设置窗口大小  
            this.Width = w;
            this.Height = h;
            //置顶显示  
            //this.TopMost = false;

            // 登录用户信息
            //LoginUserModel loginUserMode = (LoginUserModel)DataCache.GetCache("dsLoginUserCacheObject");
            //userId = loginUserMode.LOGIN_USER_ID;
            //this.txtUserCode.Text = loginUserMode.FIRST_NAME + loginUserMode.LAST_NAME;
            //this.txtTimeBox.Text = DateTime.Now.ToLocalTime().ToString();

            printTbl = null;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (checkFrom())
            {
                // 设置画面显示列表数据
                setGridViewList(setWhere());
                ProduceService.UpData裁剪条码打印生产工序(this.ORDER_ID);
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            string strClipText = "0";

            if (checkFrom())
            {
                // 设置画面显示列表数据
                setGridViewList(setWhere());

                if (!this.txtPrintClipNumber.Text.Equals(""))
                {
                    strClipText = this.txtPrintClipNumber.Text;
                }
                else
                {
                    strClipText = this.txtClipNumber.Text;
                }

                if (printTbl != null)
                {
                    DataView dv = printTbl.DefaultView;
                    DataRowView dr = dv[0];
                    dr["QR_CLIP_NUMBER"] = strClipText;

                    BarCodePrintBLL barCodePrintBLL = new BarCodePrintBLL();
                    barCodePrintBLL.clipOrderPrint(this.printTbl);

                    this.ActiveControl = this.butPrint;
                    //this.AcceptButton = this.butPrint;
                    this.txtBarCode.Focus();
                    this.printTbl = null;
                    this.txtBarCode.Text = "";
                    this.txtProductCode.Text = "";
                    this.txtPrintClipNumber.Text = "";
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        private string setWhere()
        {
            StringBuilder strWhere = new StringBuilder();

            // 条码编号
            string strBarCodeText = this.txtBarCode.Text.ToString();
            string strProductCodeText = this.txtProductCode.Text.ToString();

            strWhere.Append(" QR_TYPE = 5 ");

            if (!strBarCodeText.Trim().Equals(""))
            {
                strWhere.Append(" AND QR_BAR_CODE = '");
                strWhere.Append(strBarCodeText);
                strWhere.Append("' ");
            }
            else if (!strProductCodeText.Trim().Equals(""))
            {
                strWhere.Append(" AND QR_OTHER5 like '%");
                strWhere.Append(strProductCodeText);
                strWhere.Append("%' ");
            }

            return strWhere.ToString();
        }


        /// <summary>
        /// 设置画面显示数据
        /// </summary>
        public void setGridViewList(String strWhere)
        {
            resetFrom();

            this.lblMessage.Text = "";

            {
                this.Model = new 裁剪条码打印Model(this.txtBarCode.Text);
                this.txtQrId.Text = this.Model.裁剪条码打印显示DTO.QR_ID;
                this.txtOrderNo.Text = this.Model.裁剪条码打印显示DTO.QR_OTHER0;
                this.txtProductOrder.Text = this.Model.裁剪条码打印显示DTO.QR_OTHER9;
                this.txtCustomerOrderNo.Text = this.Model.裁剪条码打印显示DTO.QR_NAME;
                this.txtQrBarCode.Text = this.Model.裁剪条码打印显示DTO.QR_BAR_CODE;
                string strBarCodeText = this.txtBarCode.Text.ToString();
                string strProductCodeText = this.txtProductCode.Text.ToString();
                if (strBarCodeText.Trim().Equals("") && (!strProductCodeText.Equals("")))
                {
                    this.txtClipNumber.Text = "2";
                }
                else
                {
                    this.txtClipNumber.Text = this.Model.裁剪条码打印显示DTO.QR_OTHER6;
                }
            }

            //BarCodeBLL barCodeBLL = new BarCodeBLL();

            //DataSet ds = new DataSet();
            //ds = barCodeBLL.GetList(strWhere);

            //DataTable tbl = ds.Tables[0];
            //DataView dv = tbl.DefaultView;

            //if (!tbl.Columns.Contains("QR_CLIP_NUMBER"))
            //{
            //    tbl.Columns.Add("QR_CLIP_NUMBER", typeof(string));
            //}

            //if (dv.Count == 1)
            //{
            //    DataRowView dr = dv[0];
            //    this.txtQrId.Text = dr["QR_ID"].ToString();
            //    this.txtOrderNo.Text = dr["QR_OTHER0"].ToString();
            //    this.txtProductOrder.Text = dr["QR_OTHER9"].ToString();
            //    this.txtCustomerOrderNo.Text = dr["QR_NAME"].ToString();
            //    this.txtQrBarCode.Text = dr["QR_BAR_CODE"].ToString();
            //    string strBarCodeText = this.txtBarCode.Text.ToString();
            //    string strProductCodeText = this.txtProductCode.Text.ToString();
            //    if (strBarCodeText.Trim().Equals("") && (!strProductCodeText.Equals("")))
            //    {
            //        this.txtClipNumber.Text = "2";
            //    }
            //    else
            //    {
            //        this.txtClipNumber.Text = dr["QR_OTHER6"].ToString();
            //    }
            //    dr["QR_CLIP_NUMBER"] = dr["QR_OTHER6"].ToString();
            //    setUpdateData();

            //}
            //else
            //{
            //    resetFrom();
            //    this.lblMessage.Text = "没有查询到相应的数据. 请再次扫描  !!!";
            //    return;
            //}

            //printTbl = tbl;
        }
        public void setUpdateData()
        {
            //StyleOperatingModel soModel = new StyleOperatingModel();

            //StyleOperatingBLL styleOperatingBLL = new StyleOperatingBLL();

            //StringBuilder strWhereTemp = new StringBuilder();

            //// 条码编号
            //string strBarCodeText = this.txtBarCode.Text.ToString();

            //if (!strBarCodeText.Trim().Equals(""))
            //{
            //    strWhereTemp.Append("OPERATING_ITME_ID  = ");
            //    strWhereTemp.Append(3);
            //    strWhereTemp.Append(" AND STYLE_BAR_CODE = '");
            //    strWhereTemp.Append(strBarCodeText);
            //    strWhereTemp.Append("' ");
            //    strWhereTemp.Append("  AND DEL_FLG = 0 ");

            //}
            //soModel = styleOperatingBLL.GetModeByStr(strWhereTemp.ToString());


            ////定制款式款式生产工序表更新
            ////StyleOperatingBLL styleOperatingBLL = new StyleOperatingBLL();
            //soModel.OPERATING_STATUS = "OPERATING_STATUS-OS_10";
            //soModel.UPDATE_DATE = DateTime.Now.ToLocalTime();
            //soModel.UPDATE_USER = userId;
            //soModel.STYLE_BAR_CODE = this.txtQrBarCode.Text;
            //soModel.OPERATING_ITME_ID = 3;
            //soModel.VERSION = soModel.VERSION + 1;
            //styleOperatingBLL.UpdateByItemId(soModel);

            ////生产工票信息详情
            //ProductionItemModel productionItemModel = new ProductionItemModel();
            ////通过barCode从生产制单信息管理表里面获取PRODUCTION_ID
            //ProductionItemBLL productionItemBLL = new ProductionItemBLL();
            //Console.WriteLine("13--" + System.DateTime.Now.ToString());
            //int strPRODUCTION_ID = productionItemBLL.GetProductionNoBybarCode(soModel.ORDER_ID.ToString());
            //Console.WriteLine("14--" + System.DateTime.Now.ToString());
            ////if (strPRODUCTION_ID != 0)
            ////{
            //productionItemModel.PRODUCTION_ID = strPRODUCTION_ID;
            ////订单id
            //productionItemModel.ORDER_ID = soModel.ORDER_ID;
            //productionItemModel.ORDER_NO = soModel.ORDER_NO.ToString();
            //productionItemModel.BAR_CODE = soModel.STYLE_BAR_CODE;
            //productionItemModel.PROCESS_STATUS = "OPERATING_STATUS-OS_10";
            //productionItemModel.OPERATING_ID = 3;
            //productionItemModel.PROCESS_NUMBER = 1;
            //productionItemModel.CREATE_USER_ID = userId;
            //productionItemModel.CREATE_DATE_TIME = DateTime.Now.ToLocalTime();
            //productionItemModel.UPDATE_DATE_TIME = DateTime.Now.ToLocalTime();
            //productionItemModel.UPDATE_USER_ID = userId;
            //productionItemModel.SETTLE_FLAG = "0";
            //productionItemBLL.Add(productionItemModel);
            ////}


            ////裁剪工序总表时 订单表的生产状态改成生产中 
            //OrderBLL orderBLL = new OrderBLL();
            //OrderModel orderModel = new OrderModel();
            //orderModel.ORDER_ID = soModel.ORDER_ID;
            //orderModel.UPDATE_DATE = DateTime.Now.ToLocalTime();
            //orderModel.UPDATE_USER = userId;
            //orderModel.ORDER_PRODUCE_STATUS_CD = "PRODUCTION_STATUS-PRO_05";
            ////工厂加工中
            //orderModel.ORDER_STATUS_CD = "ORDER_STATUS-OS_30";
            ////获取版本号
            //OrderModel orModel = new OrderModel();
            //orModel = orderBLL.GetModelByStr("ORDER_ID = " + soModel.ORDER_ID);
            //if (orModel != null)
            //{
            //    orderModel.VERSION = orModel.VERSION + 1;
            //    orderBLL.UpdateByOrderId(orderModel);
            //}
        }

        private Boolean checkFrom()
        {
            bool blcheck = true;
            if (this.txtBarCode.Text.Equals(""))
            {
                if (this.txtProductCode.Equals(""))
                {
                    //System.Windows.Forms.MessageBox.Show("请输入要打印的订单编号 !!!");
                    //return false;
                    //resetFrom();
                    this.lblMessage.Text = "请再次扫描要打印的订单编号 !!!";
                    blcheck = false;
                }

            }

            if (this.txtClipNumber.Text.Equals(""))
            {
                resetFrom();
                this.lblMessage.Text = "请输入要打印的裁剪片数 !!!";
                blcheck = false;
            }

            return blcheck;
        }

        private void resetFrom()
        {
            //this.txtBarCode.Text = "";
            this.txtQrId.Text = "";
            this.txtOrderNo.Text = "";
            this.txtProductOrder.Text = "";
            this.txtCustomerOrderNo.Text = "";
            this.txtQrBarCode.Text = "";
            this.txtClipNumber.Text = "0";
            //this.txtPrintClipNumber.Text = "";
        }

        private void UC裁剪条码打印_Load_1(object sender, EventArgs e)
        {
            this.txtClipNumber.Text = "0";
            this.ActiveControl = this.txtBarCode;
            printTbl = null;
        }
    }
}
