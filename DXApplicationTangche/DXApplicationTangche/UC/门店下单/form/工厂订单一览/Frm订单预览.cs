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
using static mendian.Frm设计点;
using DiaoPaiDaYin;
using System.IO;

namespace DXApplicationTangche.UC.门店下单.form.订单修改
{
    public partial class Frm订单预览 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private 门店下单选款式Model model = new 门店下单选款式Model();
        private String Style_Id;
        private String ORDER_ID;
        private String REMARKS;
        private List<DTO.款式图片一览Dto> 款式图片一览Dtos = new List<DTO.款式图片一览Dto>();
        private Frm订单一览 Frm订单一览;

        //private List<尺寸呈现dto> 尺寸呈现 = new List<尺寸呈现dto>();
        public Frm订单预览(String Style_Id,List<尺寸呈现dto> lst,String ORDER_ID,String REMARKS, Frm订单一览 Frm订单一览)
        {
            InitializeComponent();
            this.Style_Id = Style_Id;
            this.model.尺寸呈现 = lst;
            this.ORDER_ID = ORDER_ID;
            this.REMARKS = REMARKS;
            this.Frm订单一览 = Frm订单一览;
            this.款式图片一览Dtos.Add(StyleService.getStyleByORDER_ID(ORDER_ID));

            //  尺寸
            this.model.build款式全尺寸(Style_Id).build设计点(Style_Id);

            //  控件行为
            this.gridControl款式.DataSource = this.款式图片一览Dtos;
            this.gridControl面料.DataSource = this.model.面料信息;
            this.gridControlSize.DataSource = this.model.尺寸呈现;
            this.gridControl设计点.DataSource = this.model.Dto定制下单.Dto设计点s;
            this.textBoxREMARKS.Text = this.REMARKS;
            //  模板  TODO
            ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items.Add("样品下单");
            ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items.Add("定制下单");
            this.barEditItemTemplate.EditValue = ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items[0];
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
            this.model.build尺寸保存();
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
            this.tileView2.RefreshData();
            this.tileView1.RefreshData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.layoutControl1.SaveLayoutToXml(this.barEditItemTemplate.EditValue+".xml");
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            this.layoutControl1.RestoreLayoutFromXml("layout_xml\\" + this.barEditItemTemplate.EditValue + ".xml");
            this.richEditControl备注.LoadDocument("文档模板\\" + this.barEditItemTemplate.EditValue + ".docx");
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            new Frm设计点(this.model.Dto定制下单.Dto设计点s[this.tileView1.FocusedRowHandle], Enum选择设计点类型.全部).ShowDialog();
        }

        private void Frm订单预览_Load(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM t_remark WHERE order_id='" + this.ORDER_ID + "'";
            DataRow dr = SQLmtm.GetDataRow(sql);
            if (dr == null)
            {               
            }
            else
            {
                byte[] decBytes = Convert.FromBase64String(dr["remark"].ToString());
                FileBinaryConvertHelper.Bytes2File(decBytes, @"" + this.ORDER_ID + ".doc");
                this.richEditControl备注.LoadDocument(@"" + this.ORDER_ID + ".doc");
            }
        }

        private void Frm订单预览_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(this.ORDER_ID + ".doc");
            }
            catch
            {

            }
        }
    }
}