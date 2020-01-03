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
using mendian;

namespace DXApplicationTangche.UC.款式异常
{
    public partial class Frm款式一览 : DevExpress.XtraEditors.XtraForm
    {
        private 款式异常Model 款式异常Model;
        private byte ENABLE_FLAG;   //  是否启用
        public Frm款式一览(byte ENABLE_FLAG)
        {
            InitializeComponent();
            this.ENABLE_FLAG = ENABLE_FLAG;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData() {

            this.款式异常Model.build款式异常Model(this.comboBox年份.Text, this.comboBox服装种类.Text);
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.tileView款式异常.RefreshData();

        }

        private void comboBox服装种类_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void comboBox年份_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void simpleButton重置_Click(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");     // 信息

            this.款式异常Model = ImpService.getAllStyle(this.ENABLE_FLAG).initData();
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.tileView款式异常.RefreshData();
            this.comboBox年份.DataSource = this.款式异常Model.List年份;
            this.comboBox服装种类.DataSource = this.款式异常Model.List服装种类;

            this.splashScreenManager.CloseWaitForm();
        }

        private void Frm款式异常_Load(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");     // 信息

            this.款式异常Model = ImpService.getAllStyle(this.ENABLE_FLAG).initData();
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.comboBox年份.DataSource = this.款式异常Model.List年份;
            this.comboBox服装种类.DataSource = this.款式异常Model.List服装种类;

            this.splashScreenManager.CloseWaitForm();
        }

        private void tileView款式异常_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            String style_id = this.tileView款式异常.GetRowCellValue(e.Item.RowHandle, "SYS_STYLE_ID").ToString();
            try
            {
                this.款式异常Model.build送审款式(style_id);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }

            this.gridControl待办.DataSource = this.款式异常Model.送审款式s1;
            this.gridView待办.RefreshData();
        }
    }
}