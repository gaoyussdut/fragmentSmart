using DXApplicationTangche.service;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DXApplicationTangche.UC.门店下单.form.Frm门店统一下单;

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm门店下单选款式 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public 门店下单选款式Model model = new 门店下单选款式Model();
        public List<Pic各种> pics = new List<Pic各种>();
        //public Dto定制下单 Dto定制下单 { get => dto定制下单; set => dto定制下单 = value; }

        private Frm门店统一下单 frm;

        //private Dto定制下单 dto定制下单;

        public Frm门店下单选款式(Frm门店统一下单 frm, Enum下单类型 enum下单类型)
        {
            InitializeComponent();

            this.frm = frm;
            this.model.Dto定制下单 = new Dto定制下单();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Frm标准款下单.page = 1;

            //  图片布局
            this.generatePictureLayout();
        }
        /// <summary>
        /// 图片布局
        /// </summary>
        private void generatePictureLayout()
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            this.model = new 门店下单选款式Model(this.textBox1.Text, Frm标准款下单.page);
            this.gridControl选择款式.DataSource = this.model.款式图片;
            this.splashScreenManager.CloseWaitForm();
        }

        private void Frm门店下单选款式_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new Frm面料选择(this.model.Dto定制下单.Style_Id,Frm面料选择.Enum选择面料类型.全部,this.model).ShowDialog();
        }

        private void mianliaoname_Click(object sender, EventArgs e)
        {
            new Frm面料选择(this.model.Dto定制下单.Style_Id, Frm面料选择.Enum选择面料类型.默认,this.model).ShowDialog();
        }

        private void Frm门店下单选款式_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = Frm面料选择.mianliao;
            //this.gridControlSI.DataSource = this.model.款式信息;
            //this.gridControlSI.Refresh();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                
                //this.model.Dto定制下单.ORDER_NUMBER = Convert.ToInt32(this.barEditItemNumber.EditValue);
                                
                //ImpService.DynamicSaveSize(this, this.model.Dto定制下单);//尺寸保存
                this.model.build动态设计点();//尺寸保存

                ImpService.DynamicSaveDesign(this, this.model.Dto定制下单);//设计点保存
                try
                {
                    //  校验订单
                    this.model.verify订单();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                this.frm.buildOrderModel(this.model.Dto定制下单);
                this.frm.refreshGridControl();
                //this.addPics();

                MessageBox.Show("保存成功");
                this.Close();
            }
        }
        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.model.build选中尺寸(this.chicun01.Text.Trim(), this.model.Dto定制下单.Style_Id, Frm定制下单修改尺寸.stylesizedt);
            this.model.Dto定制下单.STYLE_SIZE_CD= SizeService.SizeCD(this.chicun01.Text.Trim(), Frm定制下单修改尺寸.stylesizedt);
            ImpService.RefreshChiCun(this, this.model.选中尺寸);
            ImpService.CountChiCun(this);
            this.model.尺寸呈现 = SizeService.GetThisSize(this.model.Dto定制下单);
            foreach (尺寸呈现dto dto in this.model.尺寸呈现)
            {
                dto.CountSize();
            }
            this.gridControlSize.DataSource = this.model.尺寸呈现;
        }

        public void addPics()
        {
            try
            {
                this.pics.Add(new Pic各种(FabricService.GetMianLiaoFile(this.model.Dto定制下单.SYTLE_FABRIC_ID), this.mianliaoname.Text, "面料"));
            }
            catch
            {
                this.pics.Add(new Pic各种(Image.FromFile(@"pic\SSHIRT.jpg"), this.mianliaoname.Text, "面料"));
            }
            UC设计点选择 c = new UC设计点选择();
            foreach (Control card in this.panel3.Controls)
            {
                if (card is UC设计点选择)
                {
                    c = (UC设计点选择)card;
                    try
                    {
                        this.pics.Add(new Pic各种(PictureService.GetImage(c.itemValue), c.itemName, c.PitemName));
                    }
                    catch
                    {
                        this.pics.Add(new Pic各种(Image.FromFile(@"pic\SSHIRT.jpg"), c.itemName, c.PitemName));
                    }
                }
            }
        }

        private void tileView1_ItemRightClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认选择该款式？", "款式选择", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.model.Dto定制下单.build选中款式(this.tileView1.GetRowCellValue(e.Item.RowHandle, "StyleId").ToString(), this.tileView1.GetRowCellValue(e.Item.RowHandle, "STYLE_CATEGORY_CD").ToString(), this.tileView1.GetRowCellValue(e.Item.RowHandle, "STYLE_FIT_CD").ToString(), this.tileView1.GetRowCellValue(e.Item.RowHandle, "STYLE_SIZE_GROUP_CD").ToString(), this.tileView1.GetRowCellValue(e.Item.RowHandle, "MaterialId").ToString());//添加选中款式数据
                //  控件行为
                this.mianliaoname.Text = this.tileView1.GetRowCellValue(e.Item.RowHandle, "MaterialNameCn").ToString();
                //  TODO    改为tileview，不准传任何控件进去
                //  TODO    不允许使用DataTable
                ImpService.LoadChiCunCard(this);
                //  TODO    不准传任何控件进去
                //  TODO    不允许使用DataTable
                ImpService.LoadSheJiDian(this, this.model.Dto定制下单.Style_Id);
                this.model.build款式信息款式("style", this.tileView1.GetRowCellValue(e.Item.RowHandle, "StyleNameCn").ToString(), this.tileView1.GetRowCellValue(e.Item.RowHandle, "STYLE_CATEGORY_CD").ToString(), (Image)this.tileView1.GetRowCellValue(e.Item.RowHandle, "Picture")).build款式信息面料(this.model.Dto定制下单.SYTLE_FABRIC_ID);//添加更新款式信息
                this.gridControlSI.DataSource = this.model.款式信息;
                this.model.build款式全尺寸(this.model.Dto定制下单.Style_Id);
                Frm定制下单修改尺寸.stylesizedt = StyleService.StyleCombobox(this.model.Dto定制下单.Style_Id);
                this.chicun01.Items.Clear();
                if (Frm定制下单修改尺寸.stylesizedt != null)
                {
                    foreach (DataRow dr in Frm定制下单修改尺寸.stylesizedt.Rows)
                    {
                        this.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                    }
                }
                this.addPics();
                this.xtraTabControl1.SelectedTabPage = this.xtraTabControl1.TabPages[1];
            }

        }

        private void barEditItemNumber_EditValueChanged(object sender, EventArgs e)
        {
            this.model.Dto定制下单.build数量(this.barEditItemNumber.EditValue.ToString());
        }

        private void gridViewSize_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.model.buildCountSize(e.RowHandle, e.Column.FieldName, e.Value.ToString());    //  尺寸计算

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
    }

    public class Pic各种
    {
        public Image Picture { get; set; }
        public String Name { get; set; }
        public String Style { get; set; }
        public Pic各种(Image pic, String Name, String Style)
        {
            this.Picture = pic;
            this.Name = Name;
            this.Style = Style;
        }
    }
}