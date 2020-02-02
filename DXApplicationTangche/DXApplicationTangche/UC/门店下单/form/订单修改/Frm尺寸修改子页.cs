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
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.service;
using mendian;

namespace DXApplicationTangche.UC.门店下单.form.订单修改
{
    public partial class Frm尺寸修改子页 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private 门店下单选款式Model model = new 门店下单选款式Model();
        private String Style_Id;
        private String ORDER_ID;
        private String REMARKS;
        private Frm已付款订单一览 Frm已付款订单一览;

        //private List<尺寸呈现dto> 尺寸呈现 = new List<尺寸呈现dto>();
        public Frm尺寸修改子页(String Style_Id,List<尺寸呈现dto> lst,String ORDER_ID,String REMARKS, Frm已付款订单一览 Frm已付款订单一览)
        {
            InitializeComponent();
            this.Style_Id = Style_Id;
            this.model.尺寸呈现 = lst;
            this.ORDER_ID = ORDER_ID;
            this.REMARKS = REMARKS;
            this.Frm已付款订单一览 = Frm已付款订单一览;

            this.model.build款式全尺寸(Style_Id);

            this.gridControlSize.DataSource = this.model.尺寸呈现;
        }

        private void gridViewSize_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.model.尺寸呈现[e.RowHandle]  //  DTO
                .SizeConflict() //  尺寸冲突
                .build尺寸增减值(e.Column.FieldName, e.Value.ToString());   //  根据修改列修改尺寸值

            //  尺寸计算
            foreach (尺寸呈现dto dto in this.model.尺寸呈现)
            {
                dto.CountSize();
            }

            //  保存入数据库
            this.model.build动态设计点();
            SizeService.save设计点(this.Style_Id, this.model.Dto定制下单.Dto尺寸);

            //  刷新
            this.gridControlSize.DataSource = this.model.尺寸呈现;
            this.gridControlSize.Refresh();
        }

        private void gridViewSize_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //e.Appearance.BackColor = Color.NavajoWhite;
            if (e.Column.Name == "colGarment")
            {
                if (this.model.尺寸呈现[e.RowHandle].OUT_VALUE > this.model.尺寸呈现[e.RowHandle].leastReasonable)
                {
                    //该行数据的该列的值不为空时时,其背景色为Red
                    e.Appearance.BackColor = Color.Red;//设置单元格变色
                                                       //e.Column.AppearanceCell.BackColor = Color.Red;//设置数据列变色
                }
                else if (this.model.尺寸呈现[e.RowHandle].IN_VALUE > this.model.尺寸呈现[e.RowHandle].maxReasonable)
                {
                    //该行数据的该列的值不为空时时,其背景色为Red
                    e.Appearance.BackColor = Color.Green;//设置单元格变色
                                                         //e.Column.AppearanceCell.BackColor = Color.Red;//设置数据列变色
                }
                else
                {
                    e.Appearance.BackColor = Color.CornflowerBlue;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new Frm面料选择(this.model.Dto定制下单.Style_Id, Frm面料选择.Enum选择面料类型.全部, this.model).ShowDialog();
        }

        private void Frm尺寸修改子页_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = this.model.款式信息[0].name;
        }

    }
}