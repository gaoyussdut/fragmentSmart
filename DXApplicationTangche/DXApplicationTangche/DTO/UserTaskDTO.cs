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
        public String ORDER_ID { get; set; }
        public String CUSTOMER_ID { get; set; }
        public String CUSTOMER_NAME { get; set; }
        public String SHIPPING_DESTINATION { get; set; }
        public String ORDER_STATUS_CD { get; set; }
        public String ORDER_STATUS_CD_NAME { get; set; }
        public String REMARK { get; set; }
        public String FILE_NAME { get; set; }
        public String TEMPLATE_ID { get; set; }
        public String DATA { get; set; }
        public String STYLE_ID { get; set; }
        public String STYLE_NAME_CN { get; set; }
        public String REF_STYLE_ID { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public String PARENT_ID { get; set; }
        public String VERSION { get; set; }
        public String PRINCIPAL { get; set; }
        public String USER_NAME { get; set; }
        public String SERIAL_NUMBER { get; set; }
        public String STATUS { get; set; }
        public String STATUS_ITEM_NAME_CN { get; set; }
        public String STYLE_FIT_CD { get; set; }
        public String STYLE_CATEGORY_CD { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String STYLE_SIZE_GROUP_CD { get; set; }


        public UserTaskDTO(DataRow dataRow) {
            this.ID = dataRow["remark_id"].ToString();
            this.ORDER_ID = dataRow["order_id"].ToString();
            this.CUSTOMER_ID = dataRow["CUSTOMER_ID"].ToString();
            this.CUSTOMER_NAME = dataRow["CUSTOMER_NAME"].ToString();
            this.SHIPPING_DESTINATION = dataRow["SHIPPING_DESTINATION"].ToString();
            this.ORDER_STATUS_CD = dataRow["ORDER_STATUS_CD"].ToString();
            this.ORDER_STATUS_CD_NAME = dataRow["ORDER_STATUS_CD_NAME"].ToString();
            this.REMARK = dataRow["remark"].ToString();
            this.FILE_NAME = dataRow["file_name"].ToString();
            this.TEMPLATE_ID = dataRow["template_id"].ToString();
            this.DATA = dataRow["DATA"].ToString();
            this.STYLE_ID = dataRow["style_id"].ToString();
            this.STYLE_NAME_CN = dataRow["STYLE_NAME_CN"].ToString();
            this.REF_STYLE_ID = dataRow["ref_style_id"].ToString();
            this.CREATE_DATE = Convert.ToDateTime(dataRow["CREATE_DATE"].ToString());
            this.PARENT_ID = dataRow["parent_id"].ToString();
            this.VERSION = dataRow["version"].ToString();
            this.PRINCIPAL = dataRow["principal"].ToString();
            this.USER_NAME = dataRow["USER_NAME"].ToString();
            this.SERIAL_NUMBER = dataRow["serial_number"].ToString();
            this.STATUS = dataRow["STATUS"].ToString();
            this.STATUS_ITEM_NAME_CN = dataRow["ITEM_NAME_CN"].ToString();

            this.STYLE_FIT_CD = dataRow["STYLE_FIT_CD"].ToString();
            this.STYLE_CATEGORY_CD = dataRow["STYLE_CATEGORY_CD"].ToString();
            this.STYLE_SIZE_CD = dataRow["STYLE_SIZE_CD"].ToString();
            this.STYLE_SIZE_GROUP_CD = dataRow["STYLE_SIZE_GROUP_CD"].ToString();
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
