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
using DXApplicationTangche.service;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
using DevExpress.XtraGrid.Demos.util;

namespace DXApplicationTangche.UC.任务
{
    public partial class Frm待办任务 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public Frm待办任务()
        {
            InitializeComponent();
        }

        private void Frm待办任务_Load(object sender, EventArgs e)
        {
            this.gridControl任务.DataSource = TaskService.getUserTasks();
            this.bandedGridView1.ExpandAllGroups();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            new Frm任务新建().ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Frm任务新建().ShowDialog();
        }
    }
    
}