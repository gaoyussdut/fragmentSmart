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
using DXApplicationTangche.UC.款式异常.DTO;
using DXApplicationTangche.UC.款式异常.Model;
using DXApplicationTangche.service;

namespace DXApplicationTangche.UC.款式异常
{
    public partial class Frm下线审核一览 : DevExpress.XtraEditors.XtraForm
    {

        private 下线Model 下线Model = new 下线Model();
        public Frm下线审核一览()
        {
            InitializeComponent();
            this.gridControl款式一览.DataSource = this.下线Model.款式一览;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /// 执行下线
            this.下线Model.doRollOff();
            //  控件行为
            this.gridControl款式一览.DataSource = this.下线Model.款式一览;
            this.tileView款式异常.RefreshData();
            MessageBox.Show("下线完成");
        }
    }
}