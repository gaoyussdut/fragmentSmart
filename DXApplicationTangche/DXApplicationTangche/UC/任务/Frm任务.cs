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

namespace DXApplicationTangche.UC.任务
{
    public partial class Frm任务 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public UC销售备注模板 uc销售备注模板 = new UC销售备注模板();
        public TaskDTO TaskDTO = new TaskDTO();
        public bool ifEdit = true;//是否编辑
        public Frm任务()
        {
            InitializeComponent();
        }
        public Frm任务(TaskDTO taskDTO,bool ifEdit)
        {
            this.ifEdit = ifEdit;
            this.TaskDTO = taskDTO;
            InitializeComponent();
        }

        private void Frm任务_Load(object sender, EventArgs e)
        {
            switch (this.TaskDTO.template_id)
            {
                case "1":
                    this.uc销售备注模板 = new UC销售备注模板(this.TaskDTO, this.ifEdit); uc销售备注模板.Dock = DockStyle.Fill;
                    this.panel任务.Controls.Clear();
                    this.panel任务.Controls.Add(uc销售备注模板);
                    this.panel任务.Refresh();
                    break;
            }
        }

        private void barButtonItem保存_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("是否保存",
        "Saving a document", MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    switch (this.TaskDTO.template_id)
                    {
                        case "1":
                            this.uc销售备注模板.SaveToDTO();
                            break;
                    }
                    this.TaskDTO.buildserial_number().buildStatus(1).SaveInMTM();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败" + ex.Message);
                }
        }
    }
}
