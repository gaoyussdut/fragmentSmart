using DiaoPaiDaYin;
using DXApplicationTangche.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 任务服务
    /// </summary>
    class TaskService
    {
        /// <summary>
        /// 取得所有任务
        /// </summary>
        /// <returns></returns>
        public static List<UserTaskDTO> getUserTasks() {
            String sql = "SELECT\n" +
                "	t_remark.remark_id,\n" +
                "	t_remark.order_id /*订单号*/\n" +
                "	,\n" +
                "	v_order_p.CUSTOMER_ID,\n" +
                "	v_order_p.CUSTOMER_NAME,\n" +
                "	v_order_p.SHIPPING_DESTINATION,\n" +
                "	v_order_p.ORDER_STATUS_CD,\n" +
                "	v_order_p.ORDER_STATUS_CD_NAME,\n" +
                "	t_remark.remark /*备注——文档*/\n" +
                "	,\n" +
                "	t_remark.file_name,\n" +
                "	t_remark.template_id /*模板id*/\n" +
                "	,\n" +
                "	t_remark.DATA /*json数据*/\n" +
                "	,\n" +
                "	t_remark.style_id,\n" +
                "	s_style_p.STYLE_NAME_CN,\n" +
                "	t_remark.ref_style_id,\n" +
                "	t_remark.CREATE_DATE /*创建时间*/\n" +
                "	,\n" +
                "	t_remark.parent_id /*父ID*/\n" +
                "	,\n" +
                "	t_remark.version /*版本*/\n" +
                "	,\n" +
                "	t_remark.principal /*负责人*/\n" +
                "	,\n" +
                "	CONCAT( a_login_user_p.FIRST_NAME, a_login_user_p.LAST_NAME ) AS USER_NAME /*姓名*/\n" +
                "	,\n" +
                "	t_remark.serial_number /*流水号*/\n" +
                "	,\n" +
                "	t_remark.STATUS,\n" +
                "	MISSION_STATUS.ITEM_NAME_CN /*状态*/\n" +
                "FROM\n" +
                "	t_remark\n" +
                "	LEFT JOIN v_order_p ON v_order_p.ORDER_ID = t_remark.order_id\n" +
                "	LEFT JOIN s_style_p ON s_style_p.SYS_STYLE_ID = t_remark.style_id\n" +
                "	LEFT JOIN a_login_user_p ON a_login_user_p.LOGIN_USER_ID = t_remark.principal\n" +
                "	LEFT JOIN ( SELECT item_value, ITEM_NAME_CN FROM a_dict_p WHERE ITEM_CD = 'MISSION_STATUS' ) MISSION_STATUS ON MISSION_STATUS.item_value = t_remark.STATUS;";

            DataTable dt = SQLmtm.GetDataTable(sql);
            List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();
            foreach (DataRow dataRow in dt.Rows) {
                userTaskDTOs.Add(new UserTaskDTO(dataRow));
            }

            return userTaskDTOs;
        }

        /// <summary>
        /// 取得所有任务模板
        /// </summary>
        /// <returns></returns>
        public static List<TaskTemplateDTO> getTaskTemplateDTO() {
            String sql = "SELECT\n" +
                "	TEMPLATE_ID,TEMPLATE_NAME \n" +
                "FROM\n" +
                "	t_task_template;";

            DataTable dt = SQLmtm.GetDataTable(sql);
            List<TaskTemplateDTO> taskTemplateDTOs = new List<TaskTemplateDTO>();
            foreach (DataRow dataRow in dt.Rows)
            {
                taskTemplateDTOs.Add(new TaskTemplateDTO(dataRow));
            }

            return taskTemplateDTOs;
        }

        /// <summary>
        /// 取得所有任务模板
        /// </summary>
        /// <returns></returns>
        public static void updateTaskTemplate(String TEMPLATE_ID, String TEMPLATE_XML)
        {
            String sql = "update t_task_template set TEMPLATE_XML='"+ TEMPLATE_XML 
                + "' where TEMPLATE_ID = '"+ TEMPLATE_ID + "'";
            SQLmtm.ExecuteSql(sql);            
        }
    }
}
