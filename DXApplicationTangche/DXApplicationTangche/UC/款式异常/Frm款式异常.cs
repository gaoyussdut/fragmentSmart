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
    public partial class Frm款式异常 : DevExpress.XtraEditors.XtraForm
    {
        private 款式异常Model 款式异常Model;
        public Frm款式异常()
        {
            InitializeComponent();
            this.款式异常Model = ImpService.getAllStyle().initData();
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.comboBox年份.DataSource = this.款式异常Model.List年份;
            this.comboBox服装种类.DataSource = this.款式异常Model.List服装种类;
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
            this.款式异常Model = ImpService.getAllStyle().initData();
            this.gridControl款式一览.DataSource = 款式异常Model.Views;
            this.tileView款式异常.RefreshData();
        }
    }
}