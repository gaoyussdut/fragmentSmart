using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.DTO
{
    /// <summary>
    /// 用户任务DTO
    /// </summary>
    class UserTaskDTO
    {
        public String ID { get; set; }
        public String USER_ID { get; set; }
        public String USERNAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public String STATUS { get; set; }
        public String STATUS_DESC { get; set; }
        public String TEMPLATE_ID { get; set; } //  任务模板
        public String TEMPLATE_NAME { get; set; }   //  任务模板名称
        public byte[] XML_DESC { get; set; }    //  XML描述
        public byte[] DOC_DESC { get; set; } //  文件

        public UserTaskDTO(DataRow dataRow) {
            this.ID = dataRow["ID"].ToString();
            this.USER_ID = dataRow["USER_ID"].ToString();
            this.USERNAME = dataRow["USERNAME"].ToString();
            this.CREATE_TIME = Convert.ToDateTime(dataRow["CREATE_TIME"].ToString());
            this.STATUS = dataRow["STATUS"].ToString(); 
            this.STATUS_DESC = dataRow["STATUS_DESC"].ToString();
            this.TEMPLATE_ID = dataRow["TEMPLATE_ID"].ToString();
            this.TEMPLATE_NAME = dataRow["TEMPLATE_NAME"].ToString();
            try
            {
                this.XML_DESC = Convert.FromBase64String(dataRow["XML_DESC"].ToString());
            }
            catch { }
            try {
                this.DOC_DESC = Convert.FromBase64String(dataRow["DOC_DESC"].ToString());
            } catch { }       
        }
    }

    /// <summary>
    /// 任务模板DTO
    /// </summary>
    public class TaskTemplateDTO {
        public String TEMPLATE_ID { get; set; }  //  任务模板ID
        public String TEMPLATE_NAME { get; set; }    //  任务模板名称
        public TaskTemplateDTO(DataRow dataRow) {
            this.TEMPLATE_ID = dataRow["TEMPLATE_ID"].ToString();
            this.TEMPLATE_NAME = dataRow["TEMPLATE_NAME"].ToString();
        }
    }
}
