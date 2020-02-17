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
using System.IO;
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.门店下单.form;
using DiaoPaiDaYin;

delegate void UCSave();
namespace DXApplicationTangche.原型
{
    public partial class OrderQA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TaskDTO 任务DTO = new TaskDTO();
        private Dictionary<String, String> template_choose = new Dictionary<string, string>();//模板名称和id
        private 门店下单选款式Model model = new 门店下单选款式Model();
        private String Style_Id;
        private String ORDER_ID;
        private String REMARKS;
        private List<DXApplicationTangche.UC.门店下单.DTO.款式图片一览Dto> 款式图片一览Dtos = new List<DXApplicationTangche.UC.门店下单.DTO.款式图片一览Dto>();
        private Frm已付款订单一览 Frm已付款订单一览;
        public UC销售备注模板 uc销售备注模板 = new UC销售备注模板();
        public TaskDTOS TaskDTOS = new TaskDTOS();
        //private List<尺寸呈现dto> 尺寸呈现 = new List<尺寸呈现dto>();
        public OrderQA()
        {           
            InitializeComponent();
        }
        public OrderQA(String Style_Id, List<尺寸呈现dto> lst, String ORDER_ID, String REMARKS, Frm已付款订单一览 Frm已付款订单一览)
        {
            InitializeComponent();
            this.Style_Id = Style_Id;
            this.model.尺寸呈现 = lst;
            this.ORDER_ID = ORDER_ID;
            this.REMARKS = REMARKS;
            this.Frm已付款订单一览 = Frm已付款订单一览;
            this.款式图片一览Dtos.Add(StyleService.getStyleByORDER_ID(ORDER_ID));

            //  尺寸
            this.model.build款式全尺寸(Style_Id).build设计点(Style_Id);

            //  控件行为
            //this.gridControl款式.DataSource = this.款式图片一览Dtos;
            //this.gridControl面料.DataSource = this.model.面料信息;
            //this.gridControlSize.DataSource = this.model.尺寸呈现;
            //this.gridControl设计点.DataSource = this.model.Dto定制下单.Dto设计点s;
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
            //this.gridControlSize.DataSource = this.model.尺寸呈现;
            //this.gridControlSize.Refresh();
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
            new Frm面料选择(this.model.Dto定制下单.Style_Id, Frm面料选择.Enum选择面料类型.全部, this.model, this.Style_Id).ShowDialog();
        }

        private void Frm尺寸修改子页_Activated(object sender, EventArgs e)
        {
            //this.mianliaoname.Text = this.model.面料信息[0].name;
            ////this.gridControl面料.DataSource = this.model.面料信息;
            //this.tileView2.RefreshData();
            //this.tileView1.RefreshData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.layoutControl1.SaveLayoutToXml(this.barEditItemTemplate.EditValue + ".xml");
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            this.layoutControl1.RestoreLayoutFromXml("layout_xml\\" + this.barEditItemTemplate.EditValue + ".xml");
            this.richEditControl备注.LoadDocument("文档模板\\" + this.barEditItemTemplate.EditValue + ".docx");
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            //new Frm设计点(this.model.Dto定制下单.Dto设计点s[this.tileView1.FocusedRowHandle], Enum选择设计点类型.全部, this.Style_Id).ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("是否保存",
        "Saving a document", MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    //richEditControl备注.SaveDocument(@"" + this.ORDER_ID + ".doc", DevExpress.XtraRichEdit.DocumentFormat.Doc);
                    //Byte[] byteArray = FileBinaryConvertHelper.File2Bytes(@"" + this.ORDER_ID + ".doc");
                    //String str = Convert.ToBase64String(byteArray);
                    //FileService.SaveRemarkFile(str, this.ORDER_ID + ".doc", this.ORDER_ID);
                    //File.Delete(this.ORDER_ID + ".doc");

                    switch (this.template_choose[this.barEditItem模板.EditValue.ToString()])
                    {
                        case "1":
                            this.uc销售备注模板.SaveToDTO();
                            break;
                    }
                    this.任务DTO.SaveInMTM();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败" + ex.Message);
                }

        }

        private void OrderQA_Load(object sender, EventArgs e)
        {
            String sql1 = "SELECT\n" +
"	t_remark.remark_id,\n" +
"	t_remark.order_id,\n" +
"	t_remark.remark,\n" +
"	t_remark.file_name,\n" +
"	t_remark.template_id,\n" +
"	t_remark.data jsondata,\n" +
"	t_template.template_name,\n" +
"	t_template_group.template_group_id,\n" +
"	t_template_group.template_group_name \n" +
"FROM\n" +
"	t_remark\n" +
"	LEFT JOIN t_template ON t_remark.template_id = t_template.template_id\n" +
"	LEFT JOIN t_template_group ON t_template.template_group_id = t_template_group.template_group_id";
            //this.treeList导航.DataSource = SQLmtm.GetDataTable(sql);
            String sql = "SELECT\n" +
"	template_id,\n" +
"	template_group_id,\n" +
"	template_name \n" +
"FROM\n" +
"	t_template";
            DataTable dt = SQLmtm.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                this.template_choose.Add(dr["template_name"].ToString(), dr["template_id"].ToString());
                ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)barEditItem模板.Edit).Items.Add(dr["template_name"].ToString());
            }
        }

        private void barButtonItem新增模板_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.任务DTO = new TaskDTO().buildNewDTO("1", this.ORDER_ID, this.Style_Id, "1");
            try
            {
                switch (this.template_choose[this.barEditItem模板.EditValue.ToString()])
                {
                    case "1":this.uc销售备注模板 = new UC销售备注模板(this.任务DTO, true);
                        uc销售备注模板.Dock = DockStyle.Fill;
                        this.panel1.Controls.Add(uc销售备注模板);
                        this.panel1.Refresh();

                        
                        break;
                }
            }
            catch
            {

            }
        }

        private void OrderQA_Activated(object sender, EventArgs e)
        {
            //this.mianliaoname.Text = this.model.面料信息[0].name;
            ////this.gridControl面料.DataSource = this.model.面料信息;
            //this.tileView2.RefreshData();
            //this.tileView1.RefreshData();
            try
            {
                this.TaskDTOS.buildTaskDTOs(this.ORDER_ID);
                this.gridControl导航.DataSource = this.TaskDTOS.taskDTOs;
                this.gridControl导航.Refresh();
            }
            catch
            {

            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.任务DTO = new TaskDTO().buildRead(this.gridView1.GetDataRow(e.RowHandle)["remark_id"].ToString());
            switch (this.gridView1.GetDataRow(e.RowHandle)["template_id"].ToString())
            {
                case "1": this.uc销售备注模板 = new UC销售备注模板(this.任务DTO, true);
            }
        }
    }
}
