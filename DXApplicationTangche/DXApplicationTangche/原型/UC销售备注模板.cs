using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationTangche.service;
using System.IO;

namespace DXApplicationTangche.原型
{
    public partial class UC销售备注模板 : UserControl
    {
        public const int template_id = 1;
        public bool ifedit = true;
        public TaskDTO TaskDTO { get; set; }
        public UC销售备注模板()
        {
            InitializeComponent();
        }
        public UC销售备注模板(TaskDTO taskDTO, bool ifedit)
        {
            this.ifedit = ifedit;
            this.TaskDTO = taskDTO;
            InitializeComponent();
            ReadFromDTO();

        }
        /// <summary>
        /// 将UC内容保存至dto
        /// </summary>
        public void SaveToDTO()
        {
            String file_name = @"" + this.TaskDTO.order_id + "_" + System.Guid.NewGuid().ToString("N") + ".doc";
            richEditControl备注.SaveDocument(file_name, DevExpress.XtraRichEdit.DocumentFormat.Doc);
            Byte[] byteArray = FileBinaryConvertHelper.File2Bytes(file_name);
            String str = Convert.ToBase64String(byteArray);
            this.单据转dto转json();
            this.TaskDTO.buildForUC(str, this.TaskDTO.data, file_name);
            File.Delete(file_name);
        }

        public void 单据转dto转json()
        {
            this.TaskDTO.uCDocuments.Add(new UCDocument("负责人", this.textBox负责人.Text));
            this.TaskDTO.uCDocuments.Add(new UCDocument("时间", this.dateEdit时间.Text));
            this.TaskDTO.buildData();
        }
        /// <summary>
        /// 从dto中读取内容
        /// </summary>
        /// <param name="taskDTO"></param>
        public void ReadFromDTO()
        {
            this.richEditControl备注.ReadOnly = !this.ifedit;
            this.textBox负责人.ReadOnly = !this.ifedit;
            this.dateEdit时间.ReadOnly = !this.ifedit;
            if (this.TaskDTO.data == "" || this.TaskDTO.data == null)
            {
                this.textBox负责人.Text = "";
                this.dateEdit时间.Text = "";
                this.Refresh();
                //this.TaskDTO.data = "[{\"title\":\"负责人\",\"value\":\"\"},{\"title\":\"时间\",\"value\":\"\"}]";
            }
            else
            {
                foreach (UCDocument uCDocument in this.TaskDTO.uCDocuments)
                {
                    switch (uCDocument.title)
                    {
                        case "负责人":
                            this.textBox负责人.Text = uCDocument.value;
                            break;
                        case "时间":
                            this.dateEdit时间.Text = uCDocument.value;
                            break;
                    }
                }
            }
            this.richEditControl备注.Refresh();
            if (this.TaskDTO.remark != "" && this.TaskDTO.remark != null)
            {
                byte[] decBytes = Convert.FromBase64String(this.TaskDTO.remark);
                FileBinaryConvertHelper.Bytes2File(decBytes, @"" + this.TaskDTO.file_name + ".doc");
                this.richEditControl备注.LoadDocument(@"" + this.TaskDTO.file_name + ".doc");
                File.Delete(@"" + this.TaskDTO.file_name + ".doc");
            }
        }

    }
}
