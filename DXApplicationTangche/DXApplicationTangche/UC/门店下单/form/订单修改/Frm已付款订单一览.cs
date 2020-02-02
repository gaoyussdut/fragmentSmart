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

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm已付款订单一览 : DevExpress.XtraEditors.XtraForm
    {
        public Frm已付款订单一览()
        {
            InitializeComponent();
        }

        private void Frm已付款订单一览_Load(object sender, EventArgs e)
        {
            this.gridControl订单一览.DataSource = OrderService.get未付款订单();
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
                );

            new Frm尺寸修改子页(
                this.gridView1.GetDataRow(e.RowHandle)["STYLE_ID"].ToString()
                ,lst
                ,this.gridView1.GetDataRow(e.RowHandle)["ORDER_ID"].ToString()
                , this.gridView1.GetDataRow(e.RowHandle)["REMARKS"].ToString()
                ,this
                ).ShowDialog();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void refreshData() {
            this.gridControl订单一览.DataSource = OrderService.get未付款订单();
            this.gridView1.Columns["ORDER_DATE"].SortOrder = ColumnSortOrder.Descending;
            this.gridView1.RefreshData();
            this.gridView1.ExpandAllGroups();
        }
    }
}