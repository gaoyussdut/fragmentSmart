using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.DTO
{
    /// <summary>
    /// Loginuserp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LoginUserModel
    {
        public LoginUserModel()
        { }
        #region Model
        private int _login_user_id;
        private string _user_barcode;
        private string _first_name;
        private string _last_name;
        private string _login_name;
        private string _password;
        private string _sex;
        private DateTime? _birth_date;
        private string _country;
        private string _city;
        private string _address;
        private string _idientity_card_number;
        private string _tel_no;
        private string _mobile;
        private string _email;
        private string _fax_no;
        private string _payroll_type;
        private decimal? _payroll_sum;
        private int? _user_type = 1;
        private string _email_random_code;
        private DateTime? _email_send_time;
        private int? _mailsend_flag;
        private int? _admin_flag = 0;
        private int _delete_flag = 0;
        private string _login_ip;
        private DateTime? _last_date;
        private int? _version = 1;
        private string _remarks;
        private DateTime? _create_date;
        private DateTime? _update_date;
        private int? _create_user;
        private int? _update_user;
        private string _name;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int LOGIN_USER_ID
        {
            set { _login_user_id = value; }
            get { return _login_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USER_BARCODE
        {
            set { _user_barcode = value; }
            get { return _user_barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FIRST_NAME
        {
            set { _first_name = value; }
            get { return _first_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_NAME
        {
            set { _last_name = value; }
            get { return _last_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGIN_NAME
        {
            set { _login_name = value; }
            get { return _login_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BIRTH_DATE
        {
            set { _birth_date = value; }
            get { return _birth_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COUNTRY
        {
            set { _country = value; }
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CITY
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDIENTITY_CARD_NUMBER
        {
            set { _idientity_card_number = value; }
            get { return _idientity_card_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEL_NO
        {
            set { _tel_no = value; }
            get { return _tel_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MOBILE
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FAX_NO
        {
            set { _fax_no = value; }
            get { return _fax_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PAYROLL_TYPE
        {
            set { _payroll_type = value; }
            get { return _payroll_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PAYROLL_SUM
        {
            set { _payroll_sum = value; }
            get { return _payroll_sum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? USER_TYPE
        {
            set { _user_type = value; }
            get { return _user_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL_RANDOM_CODE
        {
            set { _email_random_code = value; }
            get { return _email_random_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EMAIL_SEND_TIME
        {
            set { _email_send_time = value; }
            get { return _email_send_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MAILSEND_FLAG
        {
            set { _mailsend_flag = value; }
            get { return _mailsend_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ADMIN_FLAG
        {
            set { _admin_flag = value; }
            get { return _admin_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DELETE_FLAG
        {
            set { _delete_flag = value; }
            get { return _delete_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGIN_IP
        {
            set { _login_ip = value; }
            get { return _login_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_DATE
        {
            set { _last_date = value; }
            get { return _last_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VERSION
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string REMARKS
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UPDATE_DATE
        {
            set { _update_date = value; }
            get { return _update_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UPDATE_USER
        {
            set { _update_user = value; }
            get { return _update_user; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion Model
    }
}
