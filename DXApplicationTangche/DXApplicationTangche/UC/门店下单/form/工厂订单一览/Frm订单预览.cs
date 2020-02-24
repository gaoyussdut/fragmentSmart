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
using DiaoPaiDaYin;
using DXApplicationTangche.原型;
using DXApplicationTangche.UC.任务;

namespace DXApplicationTangche.UC.门店下单.form.订单修改
{
    public partial class Frm订单预览 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public UC销售备注模板 uc销售备注模板 = new UC销售备注模板();
        public TaskDTOS TaskDTOS = new TaskDTOS();
        public TaskDTO TaskDTO = new TaskDTO();
        private 门店下单选款式Model model;
        private String Style_Id;
        private String ORDER_ID;
        private String REMARKS;
        //private List<尺寸呈现dto> 尺寸呈现 = new List<尺寸呈现dto>();
        private Dictionary<String, String> template_choose = new Dictionary<string, string>();//模板名称和id
        public Frm订单预览(String Style_Id, List<尺寸呈现dto> lst, String ORDER_ID, String REMARKS)
        {
            InitializeComponent();
            this.xtraTabPager任务预览.PageVisible = false;
            this.Style_Id = Style_Id;
            this.ORDER_ID = ORDER_ID;
            this.REMARKS = REMARKS;

            //  订单相关信息
            this.model = new 门店下单选款式Model(ORDER_ID)
                .build尺寸呈现(lst)
                .build款式全尺寸(Style_Id)
                .build设计点(Style_Id)
                .build款式图片();
            //  this.model.build订单Model()
            //  控件行为

            this.gridControl款式.DataSource = this.model.款式图片一览;
            this.gridControl面料.DataSource = this.model.面料信息;
            this.gridControlSize.DataSource = this.model.尺寸呈现;
            this.gridControl设计点.DataSource = this.model.Dto定制下单.Dto设计点s;
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
            new Frm面料选择(this.model.Dto定制下单.Style_Id, Frm面料选择.Enum选择面料类型.全部, this.model, this.Style_Id).ShowDialog();
        }

        private void Frm尺寸修改子页_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = this.model.面料信息[0].name;
            //this.gridControl面料.DataSource = this.model.面料信息;
            this.tileView2.RefreshData();
            this.tileView1.RefreshData();
            try
            {
                this.TaskDTOS.buildTaskDTOs(this.ORDER_ID);
                this.gridControl导航.DataSource = this.TaskDTOS.taskDTOs;
                this.gridControl导航.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前时间：" + DateTime.Now.ToString() + "\n" +
"异常信息：" + ex.Message + "\n" +
"异常对象：" + ex.Source + "\n" +
"调用堆栈：\n" + ex.StackTrace.Trim() + "\n" +
"触发方法：" + ex.TargetSite + "\n");
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.layoutControl1.SaveLayoutToXml(this.barEditItemTemplate.EditValue+".xml");
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            //this.layoutControl1.RestoreLayoutFromXml("layout_xml\\" + this.barEditItemTemplate.EditValue + ".xml");
            //this.richEditControl备注.LoadDocument("文档模板\\" + this.barEditItemTemplate.EditValue + ".docx");
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            new Frm设计点(this.model.Dto定制下单.Dto设计点s[this.tileView1.FocusedRowHandle], Enum选择设计点类型.全部, this.Style_Id).ShowDialog();
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
                    //switch (this.template_choose[this.barEditItem模板.EditValue.ToString()])
                    switch (this.TaskDTO.template_id)
                    {
                        case "1":
                            this.uc销售备注模板.SaveToDTO();
                            break;
                    }
                    this.TaskDTO.buildserial_number().buildStatus(1).SaveInMTM();
                    MessageBox.Show("保存成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败" + ex.Message);
                }

        }

        private void Frm尺寸修改子页_Load(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPager任务预览;            
            DataTable dt = TaskService.GetTemplate();
            foreach (DataRow dr in dt.Rows)
            {
                this.template_choose.Add(dr["template_name"].ToString(), dr["template_id"].ToString());
                ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)barEditItem模板.Edit).Items.Add(dr["template_name"].ToString());
            }
        }

        private void barButtonItem新增模板_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.barEditItem模板.EditValue == null)
            {
                return;
            }
            this.TaskDTO = new TaskDTO().buildNewDTO(this.template_choose[this.barEditItem模板.EditValue.ToString()], this.ORDER_ID, this.Style_Id, "1"); 
            try
            {
                //switch (this.template_choose[this.barEditItem模板.EditValue.ToString()])
                //{
                //    case "1":
                //        this.uc销售备注模板 = new UC销售备注模板(this.任务DTO, true);
                //        uc销售备注模板.Dock = DockStyle.Fill;
                //        this.panel1.Controls.Add(uc销售备注模板);
                //        this.panel1.Refresh();


                //        break;
                //}
                new Frm任务(this.TaskDTO, true).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("当前时间：" + DateTime.Now.ToString() + "\n" +
"异常信息：" + ex.Message + "\n" +
"异常对象：" + ex.Source + "\n" +
"调用堆栈：\n" + ex.StackTrace.Trim() + "\n" +
"触发方法：" + ex.TargetSite + "\n");
            }
        }

        private void gridView一览_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.TaskDTO = new TaskDTO().buildRead(this.gridView一览.GetRowCellValue(e.RowHandle, "remark_id").ToString());
            //switch (this.gridView一览.GetRowCellValue(e.RowHandle, "template_id").ToString())
            //{
            //    case "1":
            //        this.uc销售备注模板 = new UC销售备注模板(this.任务DTO, false); uc销售备注模板.Dock = DockStyle.Fill;
            //        this.panel1.Controls.Clear();
            //        this.panel1.Controls.Add(uc销售备注模板);
            //        this.panel1.Refresh();
            //        break;
            //}
            new Frm任务(this.TaskDTO, false).ShowDialog();
        }
        /// <summary>
        /// 任务预览
        /// </summary>
        /// <param name="Style_Id"></param>
        /// <param name="lst"></param>
        /// <param name="ORDER_ID"></param>
        /// <param name="REMARKS"></param>
        /// <param name="tab"></param>
        public Frm订单预览(String Style_Id, List<尺寸呈现dto> lst, String ORDER_ID, String REMARKS,String remark_id)
        {
            InitializeComponent();
            this.Style_Id = Style_Id;
            this.ORDER_ID = ORDER_ID;
            this.model = new 门店下单选款式Model(ORDER_ID);
            this.model.尺寸呈现 = lst;
            this.REMARKS = REMARKS;

            //  订单相关信息
            this.model
                .build款式全尺寸(Style_Id)
                .build设计点(Style_Id)
                .build款式图片();

            //  控件行为
            this.gridControl款式.DataSource = this.model.款式图片一览;
            this.gridControl面料.DataSource = this.model.面料信息;
            this.gridControlSize.DataSource = this.model.尺寸呈现;
            this.gridControl设计点.DataSource = this.model.Dto定制下单.Dto设计点s;
            //  模板  TODO
            ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items.Add("样品下单");
            ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items.Add("定制下单");
            this.barEditItemTemplate.EditValue = ((DevExpress.XtraEditors.Repository.RepositoryItemComboBox)this.barEditItemTemplate.Edit).Items[0];

            this.TaskDTO = new TaskDTO().buildRead(remark_id);
            switch (this.TaskDTO.template_id)
            {
                case "1":
                    this.uc销售备注模板 = new UC销售备注模板(this.TaskDTO, false); uc销售备注模板.Dock = DockStyle.Fill;
                    this.panel任务预览.Controls.Clear();
                    this.panel任务预览.Controls.Add(uc销售备注模板);
                    this.panel任务预览.Refresh();
                    break;
            }
            TaskService.UpdataStatus(remark_id, "MS_02");//更新任务状态
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String JsonStr = this.model.build订单Model().JsonSerialization();
        }
    }
}