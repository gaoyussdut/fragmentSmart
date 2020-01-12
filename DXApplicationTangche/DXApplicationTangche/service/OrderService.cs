using DiaoPaiDaYin;
using DXApplicationTangche.UC.门店下单.DTO;
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
    /// 订单服务
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetOrder(String orderno, int order_type)
        {
            String sql = "SELECT * FROM v_order_with_type WHERE order_type ='" + order_type + "'" +
                " and ORDER_NO = '" + orderno + "'";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 查询未打印订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetNotPrintedData(String orderno, DateTime startTime, DateTime endTime, int order_type)
        {
            String sql = "SELECT " +
                "	*  " +
                "FROM " +
                "	v_order_with_type " +
                "WHERE " +
                "	ORDER_NO NOT IN ( SELECT ORDER_NO FROM a_product_log_p ) " +
                "	AND ORDER_NO LIKE '%" + orderno + "%' " +
                " and ORDER_DATE between '" + startTime.ToString() + "' and '" + endTime.ToString() + "'" +
                " and order_type ='" + order_type + "'" +
                "	order by ORDER_DATE";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        /// <returns></returns>
        public static DataTable getOrderTypeCode()
        {
            String sql = "select * from t_order_type_code;";
            return SQLmtm.GetDataTable(sql);
        }


        /// <summary>
        /// 动态保存订单
        /// </summary>
        /// <param name="orderDto"></param>
        public static void DynamicSaveOrder(OrderDto orderDto)
        {
            DataRow drstyle = SQLmtm.GetDataRow("SELECT MAX(SYS_STYLE_ID) SYS_STYLE_ID FROM `s_style_p`");
            orderDto.style_id = (Convert.ToInt32(drstyle["SYS_STYLE_ID"]) + 1).ToString();
            //orderDto.style_id = FunctionHelper.generateBillNo("s_style_p", "SYS_STYLE_ID", "", "0000");
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" }, new string[] { orderDto.style_id, "AUDIT_PHASE_CD-PHASE_CD_10", orderDto.Dto尺寸.ITEM_CD, orderDto.Dto尺寸.ITEM_VALUE, orderDto.Dto尺寸.FIT_VALUE, orderDto.Dto尺寸.FM_VALUE, "0", "1", "46", orderDto.Dto尺寸.IN_VALUE, orderDto.Dto尺寸.OUT_VALUE });
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { orderDto.CUSTOMER_ID, orderDto.CUSTOMER_NAME, orderDto.Dto尺寸.ITEM_CD, orderDto.Dto尺寸.ITEM_VALUE, orderDto.Dto尺寸.FIT_VALUE, orderDto.Dto尺寸.FM_VALUE, orderDto.Dto尺寸.IN_VALUE, orderDto.Dto尺寸.OUT_VALUE, "0", "0", orderDto.CUSTOMER_COUNT_ID });
            SQLmtm.DoInsert("s_style_p", new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" }, new string[] { orderDto.style_id, "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", orderDto.STYLE_CATEGORY_CD, orderDto.SYTLE_FABRIC_ID, orderDto.STYLE_SIZE_GROUP_CD, orderDto.STYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", orderDto.STYLE_NAME_CN, "", orderDto.CUSTOMER_COUNT_ID, orderDto.STYLE_FIT_CD, orderDto.REF_STYLE_ID, orderDto.STYLE_DRESS_CATEGORY, orderDto.STYLE_DESIGN_TYPE, orderDto.STYLE_PUBLISH_CATEGORY_CD, orderDto.SYTLE_YEAR, orderDto.SYTLE_SEASON });
            foreach (Dto设计点 dto in orderDto.Dto设计点s)
            {
                SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" }, new string[] { orderDto.style_id, dto.ITEM_CD, dto.ITEM_VALUE, dto.OPTION_VALUE, "1", "0" });
            }
            RestCall.httpGetMethod("https://shirtmtm.com/fragsmart-mtm/customer/update/payment?styleId=" + orderDto.style_id + "&customerId=" + orderDto.CUSTOMER_ID + "&addressId=" + orderDto.ADDRESS_ID + "&number=" + orderDto.ORDER_NUMBER);
            //RestCall.httpGetMethod("http://localhost:8080/customer/update/payment?styleId=" + orderDto.style_id + "&customerId=" + orderDto.CUSTOMER_ID + "&addressId=" + orderDto.ADDRESS_ID + "&number=" + orderDto.ORDER_NUMBER);
            DataRow ORDER_ID = SQLmtm.GetDataRow("SELECT MAX(ORDER_ID) AS ORDER_ID FROM `o_order_p`");
            int order_id = Convert.ToInt32(ORDER_ID["ORDER_ID"]);
            //order_id++;
            SQLmtm.DoInsert("o_order_brand_r", new string[] { "OGNIZATION_ID", "SHOP_ID", "BRAND_ID", "ORDER_ID" }, new string[] { "95", "18", "", order_id.ToString() });
            SQLmtm.DoInsert("t_order_type", new string[] { "ORDER_ID", "ORDER_TYPE" }, new string[] { order_id.ToString(), "1" });
        }
    }
}
