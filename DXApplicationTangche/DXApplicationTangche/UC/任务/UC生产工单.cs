using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationTangche.service;
using DXApplicationTangche.原型;
using DXApplicationTangche.UC.任务.任务模板UC;
using DXApplicationTangche.UC.门店下单.form.订单修改;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.service.redis_service;
using DXApplicationTangche.DTO;

namespace DXApplicationTangche.UC.任务
{
    public partial class UC生产工单 : System.Windows.Forms.UserControl
    {
        public UC裁剪条码打印 uc裁剪条码打印 = new UC裁剪条码打印();
        public TaskDTO TaskDTO = new TaskDTO();
        public String ORDER_ID { get; set; }
        public String Style_Id { get; set; }
        private List<尺寸呈现dto> dtos = new List<尺寸呈现dto>();
        //private 生产工单Service Service { get; set; }
        private Dictionary<String, String> template_choose = new Dictionary<string, string>();//模板名称和id
        public List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();
        public UC生产工单()
        {
            InitializeComponent();
            //LoudCombobox();
        }

        //private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.ORDER_ID = this.barEditItemOrderid.EditValue.ToString();
        //    try
        //    {
        //        this.Style_Id = OrderService.GetStyleidWithOrderid(this.ORDER_ID);
        //    }
        //    catch
        //    {

        //    }
        //    if (e.KeyValue == 13) //判断是回车键
        //    {
        //        this.Refresh任务一览(this.barEditItemOrderid.EditValue.ToString());
        //    }
        //}
        /// <summary>
        /// 刷新任务一览
        /// </summary>
        /// <param name="ORDER_ID"></param>
        public void Refresh任务一览(String ORDER_ID)
        {
            if(!OrderService.VerifyOrder(ORDER_ID))
            {
                MessageBox.Show("无此订单");
                return;
            }
            //this.Service = new 生产工单Service(ORDER_ID);
            OrderRedisService orderRedisService = new OrderRedisService();
            userTaskDTOs = orderRedisService.getTaskByOrderID<UserTaskDTO>(ORDER_ID);
            this.gridControl任务一览.DataSource = userTaskDTOs;
            this.gridControl任务一览.Refresh();
        }
        /// <summary>
        /// 加载下拉框
        /// </summary>
        //public void LoudCombobox()
        //{
        //    DataTable dt = TaskService.Get生产模板();
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        this.template_choose.Add(dr["ITEM_NAME_CN"].ToString(), dr["ITEM_VALUE"].ToString());
        //        ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)barEditItem任务.Edit).Items.Add(dr["ITEM_NAME_CN"].ToString());
        //    }
        //}

        //private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (this.barEditItem任务.EditValue == null)
        //    {
        //        return;
        //    }
        //    this.TaskDTO = new TaskDTO().buildNewDTO(this.template_choose[this.barEditItem任务.EditValue.ToString()], this.ORDER_ID, this.Style_Id, "1");
        //    switch (this.TaskDTO.template_id)
        //    {
        //        case "4":
        //            this.uc裁剪条码打印 = new UC裁剪条码打印();
        //            this.uc裁剪条码打印.Dock = DockStyle.Fill;
        //            this.panel任务.Controls.Clear();
        //            this.panel任务.Controls.Add(this.uc裁剪条码打印);
        //            this.panel任务.Refresh();
        //            break;
        //    }
        //}

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.dtos = SizeService.getDto尺寸WithOrderId(this.ORDER_ID);
            new Frm订单预览(
                this.gridView1.GetRowCellValue(e.RowHandle,"STYLE_ID").ToString()
                , dtos 
                , this.gridView1.GetRowCellValue(e.RowHandle,"ORDER_ID").ToString()
                , ""
                ,this.gridView1.GetRowCellValue(e.RowHandle,"ID").ToString()).HideTabcontrol().ShowDialog();
        }
    }
}
