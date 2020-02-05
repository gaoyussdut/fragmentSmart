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
    public class UserService
    {
        /// <summary>
        /// 取得所有用户
        /// </summary>
        /// <returns></returns>
        public static List<UserDTO> getUserAll() {
            String sql = "SELECT\n" +
                "	LOGIN_USER_ID,\n" +
                "	FIRST_NAME,\n" +
                "	LAST_NAME,\n" +
                "	LOGIN_NAME,\n" +
                "	PASSWORD,\n" +
                "	SEX,\n" +
                "	BIRTH_DATE,\n" +
                "	COUNTRY,\n" +
                "	CITY,\n" +
                "	ADDRESS,\n" +
                "	TEL_NO,\n" +
                "	MOBILE,\n" +
                "	EMAIL,\n" +
                "	FAX_NO,\n" +
                "	USER_TYPE,\n" +
                "	EMAIL_RANDOM_CODE,\n" +
                "	EMAIL_SEND_TIME,\n" +
                "	MAILSEND_FLAG,\n" +
                "	ADMIN_FLAG,\n" +
                "	DELETE_FLAG,\n" +
                "	LOGIN_IP,\n" +
                "	LAST_DATE,\n" +
                "	REMARKS,\n" +
                "	VERSION,\n" +
                "	CREATE_DATE,\n" +
                "	UPDATE_DATE,\n" +
                "	CREATE_USER,\n" +
                "	UPDATE_USER \n" +
                "FROM\n" +
                "	a_login_user_p";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<UserDTO> UserDTOs = new List<UserDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                UserDTOs.Add(new UserDTO(dr));
            }
            return UserDTOs;
        }
    }
}
