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
        private 款式Model 款式异常Model;
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

            this.款式异常Model.buildView(this.barEditItem年份.EditValue.ToString(), this.barEditItem服装种类.EditValue.ToString());
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.tileView款式异常.RefreshData();

        }

        private void Frm款式异常_Load(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");     // 信息

            this.款式异常Model = ImpService.getAllStyle(this.ENABLE_FLAG);
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.initCombo();

            this.splashScreenManager.CloseWaitForm();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void initCombo() {
            this.repositoryItemComboBox年份.Items.AddRange(this.款式异常Model.List年份);
            try
            {
                this.barEditItem年份.EditValue = this.款式异常Model.List年份[0];
            }
            catch { }
            
            this.repositoryItemComboBox服装种类.Items.AddRange(this.款式异常Model.List服装种类);
            try
            {
                this.barEditItem服装种类.EditValue = this.款式异常Model.List服装种类[0];
            }
            catch { }
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

            this.gridControl待办.DataSource = this.款式异常Model.送审款式;
            this.gridView待办.RefreshData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");     // 信息

            this.款式异常Model = ImpService.getAllStyle(this.ENABLE_FLAG);
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.tileView款式异常.RefreshData();
            this.initCombo();

            this.splashScreenManager.CloseWaitForm();
        }

        private void repositoryItemComboBox服装种类_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void repositoryItemComboBox年份_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }
    }
}