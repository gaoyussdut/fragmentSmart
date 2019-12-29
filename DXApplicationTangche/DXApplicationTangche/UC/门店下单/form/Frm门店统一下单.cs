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

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm门店统一下单 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 订单充血类
        /// </summary>
        private OrderModel orderModel = new OrderModel();
        public Frm门店统一下单()
        {
            InitializeComponent();
            this.initData();    //  测试方法
            this.gridControl订单分录一览.DataSource = this.orderModel.OrderDtos;
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
    }
}