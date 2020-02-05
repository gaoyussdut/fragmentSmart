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
        public static List<UserTaskDTO> getUserTasks(String USER_ID,String START_DATE,String END_DATE) {
            String sql = "SELECT\n" +
                "	T_TASK.ID,\n" +
                "	T_TASK.USER_ID,\n" +
                "	CONCAT(a_login_user_p.FIRST_NAME,a_login_user_p.LAST_NAME) as USERNAME,\n" +
                "	T_TASK.CREATE_TIME,\n" +
                "	T_TASK.STATUS,\n" +
                "	T_TASK_STATUS.STATUS_DESC,\n" +
                "	T_TASK.XML_DESC,\n" +
                "	T_TASK.TEMPLATE_ID,\n" +
                "   t_task_template.TEMPLATE_NAME,\n"+
                "	T_TASK.DOC_DESC \n" +
                "FROM\n" +
                "	T_TASK \n" +
                "	LEFT JOIN a_login_user_p on 	T_TASK.USER_ID = a_login_user_p.LOGIN_USER_ID\n" +
                "	LEFT JOIN T_TASK_STATUS on T_TASK.STATUS = T_TASK_STATUS.ID\n" +
                "	LEFT JOIN t_task_template ON t_task_template.TEMPLATE_ID = T_TASK.TEMPLATE_ID \n" +
                "WHERE\n" +
                "	1 = 1 \n" +
                "	AND T_TASK.USER_ID = '"+ USER_ID + "' \n" +
                "	AND T_TASK.CREATE_TIME BETWEEN '"+ START_DATE + "' AND '"+ END_DATE + "';";

            DataTable dt = SQLmtm.GetDataTable(sql);
            List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();
            foreach (DataRow dataRow in dt.Rows) {
                userTaskDTOs.Add(new UserTaskDTO(dataRow));
            }

            return userTaskDTOs;
        }
    }
}
