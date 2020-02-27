using DiaoPaiDaYin;
using DXApplicationTangche.DTO;
using DXApplicationTangche.Utils;
using DXApplicationTangche.原型;
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
    public class TaskService
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
"	MISSION_TEMPLATE.ITEM_NAME_CN TEMPLATE_NAME,\n" +
"	v_order_p.CUSTOMER_ID,\n" +
"	v_order_p.CUSTOMER_NAME,\n" +
"	v_order_p.SHIPPING_DESTINATION,\n" +
"	v_order_p.ORDER_STATUS_CD,\n" +
"	v_order_p.ORDER_STATUS_CD_NAME,\n" +
"	s_style_p.STYLE_FIT_CD,\n" +
"	s_style_p.STYLE_CATEGORY_CD,\n" +
"	s_style_p.STYLE_SIZE_CD,\n" +
"	s_style_p.STYLE_SIZE_GROUP_CD,\n" +
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
"	\n" +
"FROM\n" +
"	t_remark\n" +
"	LEFT JOIN v_order_p ON v_order_p.ORDER_ID = t_remark.order_id\n" +
"	LEFT JOIN s_style_p ON s_style_p.SYS_STYLE_ID = t_remark.style_id\n" +
"	LEFT JOIN a_login_user_p ON a_login_user_p.LOGIN_USER_ID = t_remark.principal\n" +
"	LEFT JOIN ( SELECT item_value, ITEM_NAME_CN FROM a_dict_p WHERE ITEM_CD = 'MISSION_STATUS' ) MISSION_STATUS ON MISSION_STATUS.item_value = t_remark.\n" +
"	STATUS LEFT JOIN ( SELECT item_value, ITEM_NAME_CN FROM a_dict_p WHERE ITEM_CD = 'MISSION_TEMPLATE' ) MISSION_TEMPLATE ON MISSION_TEMPLATE.item_value = t_remark.template_id";

            DataTable dt = SQLmtm.GetDataTable(sql);
            List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();
            foreach (DataRow dataRow in dt.Rows) {
                userTaskDTOs.Add(new UserTaskDTO(dataRow));
            }

            return userTaskDTOs;
        }


        /// <summary>
        /// 取得当前订单所有任务
        /// </summary>
        /// <returns></returns>
        public static List<UserTaskDTO> getUserTasksByOrderId(String ORDER_ID)
        {
            String sql = "SELECT\n" +
"	t_remark.remark_id,\n" +
"	t_remark.order_id /*订单号*/\n" +
"	,\n" +
"	MISSION_TEMPLATE.ITEM_NAME_CN TEMPLATE_NAME,\n" +
"	v_order_p.CUSTOMER_ID,\n" +
"	v_order_p.CUSTOMER_NAME,\n" +
"	v_order_p.SHIPPING_DESTINATION,\n" +
"	v_order_p.ORDER_STATUS_CD,\n" +
"	v_order_p.ORDER_STATUS_CD_NAME,\n" +
"	s_style_p.STYLE_FIT_CD,\n" +
"	s_style_p.STYLE_CATEGORY_CD,\n" +
"	s_style_p.STYLE_SIZE_CD,\n" +
"	s_style_p.STYLE_SIZE_GROUP_CD,\n" +
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
"	\n" +
"FROM\n" +
"	t_remark\n" +
"	LEFT JOIN v_order_p ON v_order_p.ORDER_ID = t_remark.order_id\n" +
"	LEFT JOIN s_style_p ON s_style_p.SYS_STYLE_ID = t_remark.style_id\n" +
"	LEFT JOIN a_login_user_p ON a_login_user_p.LOGIN_USER_ID = t_remark.principal\n" +
"	LEFT JOIN ( SELECT item_value, ITEM_NAME_CN FROM a_dict_p WHERE ITEM_CD = 'MISSION_STATUS' ) MISSION_STATUS ON MISSION_STATUS.item_value = t_remark.\n" +
"	STATUS LEFT JOIN ( SELECT item_value, ITEM_NAME_CN FROM a_dict_p WHERE ITEM_CD = 'MISSION_TEMPLATE' ) MISSION_TEMPLATE ON MISSION_TEMPLATE.item_value = t_remark.template_id \n" +
"WHERE\n" +
"	t_remark.order_id = '"+ORDER_ID+"';";

            DataTable dt = SQLmtm.GetDataTable(sql);
            List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();
            foreach (DataRow dataRow in dt.Rows)
            {
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
        /// <summary>
        /// 查询所有模板
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTemplate()
        {
            String sql = "SELECT\n" +
"	ITEM_CD,\n" +
"	ITEM_VALUE AS template_id,\n" +
"	ITEM_NAME_CN AS template_name \n" +
"FROM\n" +
"	a_dict_p \n" +
"WHERE\n" +
"	ITEM_CD = 'MISSION_TEMPLATE'";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 更改订单状态(MS_01未签收)(MS_02已签收)(MS_03已完成)
        /// </summary>
        /// <param name="remark_id"></param>
        /// <param name="status"></param>
        public static void UpdataStatus(String remark_id,String status)
        {
            SQLmtm.DoUpdate("t_remark", new string[] { "status" }, new string[] { status }, new string[] { "remark_id" }, new string[] { remark_id });
        }
        /// <summary>
        /// 获取生产模板
        /// </summary>
        /// <returns></returns>
        public static DataTable Get生产模板()
        {
            String sql = "SELECT\n" +
"	a_dict_p.ITEM_ID,\n" +
"	a_dict_p.PARENT_ITEM_CD,\n" +
"	a_dict_p.ITEM_CD,\n" +
"	a_dict_p.ITEM_VALUE,\n" +
"	a_dict_p.ITEM_SORT,\n" +
"	a_dict_p.ITEM_REAL_VALUE,\n" +
"	a_dict_p.ITEM_NAME_CN,\n" +
"	a_dict_p.ITEM_SHORT_NAME_CN,\n" +
"	a_dict_p.ITEM_NAME_EN,\n" +
"	a_dict_p.ITEM_SHORT_NAME_EN,\n" +
"	a_dict_p.ITEM_NAME_JP,\n" +
"	a_dict_p.ITEM_SHORT_NAME_JP,\n" +
"	a_dict_p.REMARKS,\n" +
"	a_dict_p.ENABLE_FLAG,\n" +
"	a_dict_p.DELETE_FLAG,\n" +
"	a_dict_p.VERSION,\n" +
"	a_dict_p.CREATE_DATE,\n" +
"	a_dict_p.UPDATE_DATE,\n" +
"	a_dict_p.CREATE_USER,\n" +
"	a_dict_p.UPDATE_USER \n" +
"FROM\n" +
"	a_dict_p \n" +
"WHERE\n" +
"	a_dict_p.ITEM_CD = 'PRODUCTION_TEMPLATE'";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 文档存入erp
        /// </summary>
        /// <param name="TaskDTOS"></param>
        /// <returns></returns>
        public static Boolean SaveFileToErp(TaskDTOS TaskDTOS)
        {
            try
            {
                foreach (TaskDTO taskDTo in TaskDTOS.taskDTOs)
                {
                    if (SQLerp.GetDataRow("SELECT * FROM t_remark WHERE remark_id='" + taskDTo.remark_id + "'") != null)
                    {
                        SQLerp.DoInsert("t_remark", new string[] { "remark_id", "order_id", "remark", "file_name", "template_id", "data", "style_id", "ref_style_id", "serial_number", "status" }, new string[] { taskDTo.remark_id, taskDTo.order_id, taskDTo.remark, taskDTo.file_name, taskDTo.template_id, taskDTo.data, taskDTo.style_id, taskDTo.ref_style_id, taskDTo.serial_number, taskDTo.status });
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 任务类别枚举
        /// </summary>
        public enum Enum任务类别 { 销售任务,生产任务};
        /// <summary>
        /// usertaskdto转成taskdto
        /// </summary>
        /// <param name="taskDTO"></param>
        /// <param name="userTaskDTO"></param>
        /// <returns></returns>
        public static TaskDTO TaskDTO_UserTaskDTO_Change(TaskDTO taskDTO, UserTaskDTO userTaskDTO)
        {
            taskDTO.remark_id = userTaskDTO.ID;
            taskDTO.template_id = userTaskDTO.TEMPLATE_ID;
            taskDTO.order_id = userTaskDTO.ORDER_ID;
            taskDTO.style_id = userTaskDTO.STYLE_ID;
            taskDTO.ref_style_id = userTaskDTO.REF_STYLE_ID;
            taskDTO.principal = userTaskDTO.PRINCIPAL;
            taskDTO.remark = userTaskDTO.REMARK;
            taskDTO.file_name = userTaskDTO.FILE_NAME;
            taskDTO.parent_id = userTaskDTO.PARENT_ID;
            taskDTO.version = userTaskDTO.VERSION;
            taskDTO.data = userTaskDTO.DATA;
            taskDTO.template_name = userTaskDTO.TEMPLATE_NAME;
            taskDTO.serial_number = userTaskDTO.SERIAL_NUMBER;
            taskDTO.status = userTaskDTO.STATUS;
            taskDTO.CREATE_DATE = userTaskDTO.CREATE_DATE;
            return taskDTO;
        }
    }
}
