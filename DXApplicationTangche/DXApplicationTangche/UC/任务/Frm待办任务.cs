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
using DiaoPaiDaYin;
using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.form.订单修改;

namespace DXApplicationTangche.UC.任务
{
    public partial class Frm待办任务 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public Frm待办任务()
        {
            InitializeComponent();
        }

        private void Frm待办任务_Load(object sender, EventArgs e)
        {
            this.gridControl任务.DataSource = TaskService.getUserTasks();
            this.bandedGridView1.ExpandAllGroups();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            new Frm任务新建().ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Frm任务新建().ShowDialog();
        }

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            List<尺寸呈现dto> lst = SizeService.getDto尺寸ByOrderId(
                this.bandedGridView1.GetRowCellValue(e.RowHandle,"ORDER_ID").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle,"STYLE_FIT_CD").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle,"STYLE_CATEGORY_CD").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle,"STYLE_SIZE_CD").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle,"STYLE_SIZE_GROUP_CD").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle,"CUSTOMER_ID").ToString()
                );
            //  CUSTOMER_ID


            new Frm订单预览(
                this.bandedGridView1.GetRowCellValue(e.RowHandle, "STYLE_ID").ToString()
                , lst
                , this.bandedGridView1.GetRowCellValue(e.RowHandle, "ORDER_ID").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle, "REMARK").ToString()
                , this.bandedGridView1.GetRowCellValue(e.RowHandle, "ID").ToString()
                ).ShowDialog();
        }
    }
    
}