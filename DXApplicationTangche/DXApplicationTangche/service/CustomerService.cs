using DiaoPaiDaYin;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 客户服务
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// 获取客户基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<CustomerInformation> GetCustomerInformation(int id)
        {
            List<CustomerInformation> ci = new List<CustomerInformation>();
            String sql = "SELECT " +
                "fcr.id, " +
                "fcr.CUSTOMER_ID, " +
                "fcr.CUSTOMER_NAME, " +
                "fcr.SEX, " +
                "fcr.AGE, " +
                "fr.STYLE_CATEGORY_CD, " +
                "fr.ITEM_CD, " +
                "fr.ITEM_VALUE, " +
                "fr.FIT_VALUE, " +
                "fpp.PROPERTY_NAME_CN, " +
                "dop.ITEM_NAME_CN  " +
                "FROM " +
                "	a_customer_fit_count_r AS fcr " +
                "	LEFT JOIN a_customer_fit_r fr ON fcr.id = fr.FIT_COUNT_ID " +
                "	LEFT JOIN a_fit_property_p AS fpp ON fr.ITEM_VALUE = fpp.PROPERTY_VALUE " +
                "	LEFT JOIN w_dict_option_p AS dop ON fr.ITEM_VALUE = dop.ITEM_CD  " +
                "	AND fr.FIT_VALUE = dop.ITEM_VALUE  " +
                "WHERE " +
                "	fcr.CUSTOMER_ID = '" + id.ToString() + "' " +
                "	AND fcr.DEFAULT_FLAG = '1'";
            DataTable dt = SQLmtm.GetDataTable(sql);
            if (dt.Rows.Count != 0)
            {
                ci.Add(new CustomerInformation("收件人姓名", dt.Rows[0]["CUSTOMER_NAME"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ITEM_NAME_CN"].ToString() != "")
                    {
                        ci.Add(new CustomerInformation(dr["PROPERTY_NAME_CN"].ToString(), dr["ITEM_NAME_CN"].ToString()));
                    }
                    else
                    {
                        ci.Add(new CustomerInformation(dr["PROPERTY_NAME_CN"].ToString(), dr["FIT_VALUE"].ToString()));
                    }
                }
            }
            return ci;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetCustomerData(String str)
        {
            String sql = "SELECT " +
                "	acp.CUSTOMER_ID AS ID, " +
                "	CONCAT( CONCAT( acp.CUSTOMER_FIRST_NAME, ' ' ), acp.CUSTOMER_LAST_NAME ) AS 微信名称, " +
                "	acp.MOBILE AS 手机, " +
                "	acp.CREATE_DATE AS 注册时间, " +
                "	cap.CONSIGNEE AS 客户姓名 " +
                "FROM " +
                "	a_customer_p AS acp " +
                "LEFT JOIN a_customer_address_p AS cap ON cap.CUSTOMER_ID = acp.CUSTOMER_ID " +
                "WHERE " +
                "	acp.CUSTOMER_FIRST_NAME LIKE '%" + str + "%'  " +
                "	OR acp.CUSTOMER_LAST_NAME LIKE '%" + str + "%'  " +
                "	OR acp.MOBILE LIKE '%" + str + "%'  " +
                "	OR cap.CONSIGNEE LIKE '%" + str + "%'  " +
                "ORDER BY " +
                "	acp.CREATE_DATE DESC  ";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="information"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<CustomerInformation> createCustomer(List<CustomerInformation> ci, String information, String value)
        {
            List<CustomerInformation> customerInformation = new List<CustomerInformation>();
            customerInformation.Add(new CustomerInformation(information, value));
            customerInformation.AddRange(ci);
            return customerInformation;
        }
    }
}
