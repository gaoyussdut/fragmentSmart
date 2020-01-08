using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mendian
{
    public partial class AllSheJiDian : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public  设计点图片Model model { get; set; }
        private UC设计点选择 card;
        public AllSheJiDian()
        {
            InitializeComponent();
        }
        public enum Enum选择设计点类型 { 默认, 全部 }
        public Enum选择设计点类型 enum选择设计点类型;
        public AllSheJiDian(UC设计点选择 card, Enum选择设计点类型 enum选择设计点类型)
        {
            InitializeComponent();
            this.enum选择设计点类型 = enum选择设计点类型;
            this.card = card;
            if(this.enum选择设计点类型==Enum选择设计点类型.全部)
            {
                this.Text = "选择全部" + this.card.PitemName;
                generatePictureLayout();
            }
            if(this.enum选择设计点类型 == Enum选择设计点类型.默认)
            {
                this.Text = "选择默认" + this.card.PitemName;
                generatePictureLayout();
            }
        }
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            generatePictureLayout();
        }

        private void generatePictureLayout()
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            if(this.enum选择设计点类型==Enum选择设计点类型.全部)
            {
                this.model = new 设计点图片Model(this.card.PitemValue, this.textBox11.Text);
            }
            else if(this.enum选择设计点类型==Enum选择设计点类型.默认)
            {
                this.model = new 设计点图片Model(this.card.id);
            }
            this.gridControl1.DataSource = this.model.设计点s;
            this.splashScreenManager.CloseWaitForm();
        }

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            this.card.build设计点((String)tileView1.GetRowCellValue(e.Item.RowHandle, "item_name"), (String)tileView1.GetRowCellValue(e.Item.RowHandle, "item_cd"), (String)tileView1.GetRowCellValue(e.Item.RowHandle, "item_value"), (String)tileView1.GetRowCellValue(e.Item.RowHandle, "picn"), (Image)tileView1.GetRowCellValue(e.Item.RowHandle, "picture"));
            this.Close();
        }
    }
}
