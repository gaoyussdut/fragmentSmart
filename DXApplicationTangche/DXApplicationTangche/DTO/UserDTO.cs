using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.DTO
{
    public class UserDTO
    {
        public String LOGIN_USER_ID { get; set; }
        public String FIRST_NAME { get; set; }
        public String LAST_NAME { get; set; }
        public String LOGIN_NAME { get; set; }
        public String PASSWORD { get; set; }
        public String SEX { get; set; }
        public String BIRTH_DATE { get; set; }
        public String COUNTRY { get; set; }
        public String CITY { get; set; }
        public String ADDRESS { get; set; }
        public String TEL_NO { get; set; }
        public String MOBILE { get; set; }
        public String EMAIL { get; set; }
        public String FAX_NO { get; set; }
        public String USER_TYPE { get; set; }
        public String EMAIL_RANDOM_CODE { get; set; }
        public String EMAIL_SEND_TIME { get; set; }
        public String MAILSEND_FLAG { get; set; }
        public String ADMIN_FLAG { get; set; }
        public String DELETE_FLAG { get; set; }
        public String LOGIN_IP { get; set; }
        public DateTime LAST_DATE { get; set; }
        public String REMARKS { get; set; }
        public String VERSION { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String CREATE_USER { get; set; }
        public String UPDATE_USER { get; set; }

        public UserDTO(DataRow dr){
            this.LOGIN_USER_ID = dr["LOGIN_USER_ID"].ToString();
            this.FIRST_NAME = dr["FIRST_NAME"].ToString();
            this.LAST_NAME = dr["LAST_NAME"].ToString();
            this.LOGIN_NAME = dr["LOGIN_NAME"].ToString();
            this.PASSWORD = dr["PASSWORD"].ToString();
            this.SEX = dr["SEX"].ToString();
            this.BIRTH_DATE = dr["BIRTH_DATE"].ToString();
            this.COUNTRY = dr["COUNTRY"].ToString();
            this.CITY = dr["CITY"].ToString();
            this.ADDRESS = dr["ADDRESS"].ToString();
            this.TEL_NO = dr["TEL_NO"].ToString();
            this.MOBILE = dr["MOBILE"].ToString();
            this.EMAIL = dr["EMAIL"].ToString();
            this.FAX_NO = dr["FAX_NO"].ToString();
            this.USER_TYPE = dr["USER_TYPE"].ToString();
            this.EMAIL_RANDOM_CODE = dr["EMAIL_RANDOM_CODE"].ToString();
            this.EMAIL_SEND_TIME = dr["EMAIL_SEND_TIME"].ToString();
            this.MAILSEND_FLAG = dr["MAILSEND_FLAG"].ToString();
            this.ADMIN_FLAG = dr["ADMIN_FLAG"].ToString();
            this.DELETE_FLAG = dr["DELETE_FLAG"].ToString();
            this.LOGIN_IP = dr["LOGIN_IP"].ToString();
            try{ 
                this.LAST_DATE = Convert.ToDateTime(dr["LAST_DATE"].ToString()); 
            }catch{ }

            this.REMARKS = dr["REMARKS"].ToString();
            this.VERSION = dr["VERSION"].ToString();
            try
            {
                this.CREATE_DATE = Convert.ToDateTime(dr["CREATE_DATE"].ToString());
            }
            catch { }
            try
                {
                    this.UPDATE_DATE = Convert.ToDateTime(dr["UPDATE_DATE"].ToString());
            }
            catch { }
            this.CREATE_USER = dr["CREATE_USER"].ToString();
            this.UPDATE_USER = dr["UPDATE_USER"].ToString();
        }
    }
}
