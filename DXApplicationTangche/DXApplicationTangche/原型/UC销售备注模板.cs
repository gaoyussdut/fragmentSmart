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
        public TaskDTO TaskDTO { get; set; }
        public UC销售备注模板()
        {
            InitializeComponent();
        }
        public UC销售备注模板(TaskDTO taskDTO,bool ifedit)
        {
            this.TaskDTO = taskDTO;
            InitializeComponent();
            
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
    }
}
