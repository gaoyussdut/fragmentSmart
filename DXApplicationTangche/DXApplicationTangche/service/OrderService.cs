using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.门店下单.form;
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
        public static List<Order_Status> getOrderStatus() {
            String sql = "SELECT\n" +
                "	CONCAT( ITEM_CD, '-', ITEM_VALUE ) AS ITEM_VALUE,\n" +
                "	ITEM_NAME_CN \n" +
                "FROM\n" +
                "	a_dict_p \n" +
                "WHERE\n" +
                "	item_cd LIKE 'ORDER_STATUS'";
            DataTable dataTable=  SQLmtm.GetDataTable(sql);

            List<Order_Status> order_Statuses = new List<Order_Status>();
            order_Statuses.Add(new Order_Status("全部"));

            foreach (DataRow dataRow in dataTable.Rows) {
                order_Statuses.Add(new Order_Status(dataRow));
            }
            return order_Statuses;
        }
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

        public static List<Dto设计点> get设计点BySYS_STYLE_ID(String SYS_STYLE_ID) {
            String sql = "SELECT\n" +
                "	s_style_option_r.SYTLE_OPTION_ID,\n" +
                "	s_style_option_r.SYS_STYLE_ID,\n" +
                "	s_style_option_r.ITEM_CD,\n" +
                "	s_style_option_r.ITEM_VALUE,\n" +
                "	s_style_option_r.OPTION_VALUE,\n" +
                "	s_style_option_r.ITEM_TYPE_NAME_CN,\n" +
                "	s_style_option_r.ITEM_NAME_CN,\n" +
                "	w_upload_file_p.UPLOAD_FILE \n" +
                "FROM\n" +
                "	(\n" +
                "	SELECT\n" +
                "		sr.SYTLE_OPTION_ID,\n" +
                "		sr.SYS_STYLE_ID,\n" +
                "		sr.ITEM_CD,\n" +
                "		sr.ITEM_VALUE,\n" +
                "		sr.OPTION_VALUE,\n" +
                "		ap1.ITEM_NAME_CN AS ITEM_TYPE_NAME_CN,\n" +
                "		ap.ITEM_NAME_CN,\n" +
                "		ap.FILE_ID \n" +
                "	FROM\n" +
                "		s_style_option_r AS sr\n" +
                "		LEFT JOIN a_designoption_p AS ap1 ON sr.ITEM_VALUE = ap1.ITEM_VALUE\n" +
                "		LEFT JOIN a_designoption_p AS ap ON sr.OPTION_VALUE = ap.ITEM_VALUE \n" +
                "		AND sr.ITEM_VALUE = ap.ITEM_CD \n" +
                "	WHERE\n" +
                "		sr.SYS_STYLE_ID = '"+ SYS_STYLE_ID + "' \n" +
                "		AND ap.ITEM_NAME_CN IS NOT NULL \n" +
                "	) AS s_style_option_r\n" +
                "	LEFT JOIN w_upload_file_p ON w_upload_file_p.FILE_ID = s_style_option_r.FILE_ID";
            List<Dto设计点> 设计点s = new List<Dto设计点>();

            DataTable dataTable = SQLmtm.GetDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows) {
                设计点s.Add(new Dto设计点(dataRow));
            }
            return 设计点s;
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
            SQLmtm.DoInsert(
                "s_style_fit_r"
                , new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" }
                , new string[] { orderDto.style_id, "AUDIT_PHASE_CD-PHASE_CD_10", orderDto.Dto尺寸.ITEM_CD, orderDto.Dto尺寸.ITEM_VALUE, orderDto.Dto尺寸.FIT_VALUE, orderDto.Dto尺寸.FM_VALUE, "0", "1", "46", orderDto.Dto尺寸.IN_VALUE, orderDto.Dto尺寸.OUT_VALUE }
                );
            SQLmtm.DoInsert(
                "a_customer_fit_value_r"
                , new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }
                , new string[] { orderDto.CUSTOMER_ID, orderDto.CUSTOMER_NAME, orderDto.Dto尺寸.ITEM_CD, orderDto.Dto尺寸.ITEM_VALUE, orderDto.Dto尺寸.FIT_VALUE, orderDto.Dto尺寸.FM_VALUE, orderDto.Dto尺寸.IN_VALUE, orderDto.Dto尺寸.OUT_VALUE, "0", "0", orderDto.CUSTOMER_COUNT_ID }
                );
            SQLmtm.DoInsert(
                "s_style_p"
                , new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" }
                , new string[] { orderDto.style_id, "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", orderDto.STYLE_CATEGORY_CD, orderDto.SYTLE_FABRIC_ID, orderDto.STYLE_SIZE_GROUP_CD, orderDto.STYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", orderDto.STYLE_NAME_CN, "", orderDto.CUSTOMER_COUNT_ID, orderDto.STYLE_FIT_CD, orderDto.REF_STYLE_ID, orderDto.STYLE_DRESS_CATEGORY, orderDto.STYLE_DESIGN_TYPE, orderDto.STYLE_PUBLISH_CATEGORY_CD, orderDto.SYTLE_YEAR, orderDto.SYTLE_SEASON }
                );
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

        public static DataTable get订单(List<String> status) {
            String str;
            if (status == null || status.Count == 0) {
                throw new Exception("请选择订单状态");
            }
            else if (status.Count == 1) {
                str = status[0];
            }
            else {
                str = String.Join("','", status);
            }

            String sql = "SELECT\n" +
                "	s_style_p.STYLE_NAME_CN,\n" +
                "	s_style_p.STYLE_FIT_CD,\n" +
                "	s_style_p.STYLE_CATEGORY_CD,\n" +
                "	s_style_p.STYLE_SIZE_CD,\n" +
                "	s_style_p.STYLE_SIZE_GROUP_CD,\n" +
                "	ORDER_ID,\n" +
                "	o_order_p.OGNIZATION_ID,\n" +
                "	o_order_p.SHOP_ID,\n" +
                "	o_order_p.SHOP_NAME,\n" +
                "	o_order_p.ORDER_NO,\n" +
                "	o_order_p.ORDER_TYPE_CD,\n" +
                "	o_order_p.CUSTOM_ORDER_NO,\n" +
                "	o_order_p.CUSTOM_NAME,\n" +
                "	o_order_p.CUSTOM_MAKE_SHIRT,\n" +
                "	o_order_p.TRANSIT_GROUP,\n" +
                "	o_order_p.COUNTRY,\n" +
                "	o_order_p.SLEEVE_FLAG,\n" +
                "	o_order_p.CUSTOMER_ID,\n" +
                "	o_order_p.CUSTOMER_NAME,\n" +
                "	o_order_p.FACTORY_ID,\n" +
                "	o_order_p.STYLE_ID,\n" +
                "	o_order_p.REF_ORDER_ID,\n" +
                "	o_order_p.SPECIAL_ORDER,\n" +
                "	o_order_p.TRYON_ORDER,\n" +
                "	o_order_p.FIT_STYLE_SIZE,\n" +
                "	o_order_p.TAILOR_ID,\n" +
                "	o_order_p.SHIPPING_DESTINATION,\n" +
                "	o_order_p.PAYMENT_DATE,\n" +
                "	o_order_p.PAYMENT_CONFIRM_DATE,\n" +
                "	o_order_p.ORDER_ACCEPT_DATE,\n" +
                "	o_order_p.ORDER_PRO_START_DATE,\n" +
                "	o_order_p.ORDER_PRO_END_DATE,\n" +
                "	o_order_p.ORDER_PACK_DATE,\n" +
                "	o_order_p.ORDER_SHIPMENTS_DATE,\n" +
                "	o_order_p.TARGET_DATE,\n" +
                "	o_order_p.REAL_DATE,\n" +
                "	o_order_p.ORDER_STATUS_CD,\n" +
                "	ORDER_STATUS.ITEM_NAME_CN,\n" +
                "	o_order_p.ORDER_PRODUCE_STATUS_CD,\n" +
                "	o_order_p.ORDER_QC34,\n" +
                "	o_order_p.ORDER_QC35,\n" +
                "	o_order_p.ORDER_QC36,\n" +
                "	o_order_p.ORDER_QC37,\n" +
                "	o_order_p.ORDER_NUMBER,\n" +
                "	o_order_p.ORDER_MATERIAL_COST,\n" +
                "	o_order_p.ORDER_DESIGN_COST,\n" +
                "	o_order_p.ORDER_PROCESS_COST,\n" +
                "	o_order_p.ORDER_PACK_COST,\n" +
                "	o_order_p.ORDER_EXPRESS_COST,\n" +
                "	o_order_p.ORDER_SELL_ACCOUNT,\n" +
                "	o_order_p.ORDER_OTHER_COST,\n" +
                "	o_order_p.MATERIAL_SOURCE,\n" +
                "	o_order_p.URGENT_CD,\n" +
                "	o_order_p.AFTER_SALE_STATUS,\n" +
                "	o_order_p.FIT_COMPLETE_FLAG,\n" +
                "	o_order_p.REMARKS,\n" +
                "	o_order_p.DELETE_FLAG,\n" +
                "	o_order_p.VERSION,\n" +
                "	o_order_p.CREATE_DATE,\n" +
                "	o_order_p.UPDATE_DATE,\n" +
                "	o_order_p.CREATE_USER,\n" +
                "	o_order_p.UPDATE_USER,\n" +
                "	o_order_p.SEL_KBN,\n" +
                "	o_order_p.ACTUAL_PAYMENT_COST,\n" +
                "	o_order_p.PREFERENTIAL_AMOUNT_COST,\n" +
                "	o_order_p.PREFERENTIAL_PERCENTAGE,\n" +
                "   DATE_FORMAT( o_order_p.ORDER_DATE, '%Y-%m-%d' ) AS ORDER_DATE \n" +
                "FROM\n" +
                "	o_order_p\n" +
                "	LEFT JOIN s_style_p ON o_order_p.STYLE_ID = s_style_p.SYS_STYLE_ID \n" +
                "   LEFT JOIN\n" +
                "(SELECT\n" +
                "	CONCAT( ITEM_CD, '-', ITEM_VALUE ) AS ITEM_VALUE,\n" +
                "	ITEM_NAME_CN \n" +
                "FROM\n" +
                "	a_dict_p \n" +
                "WHERE\n" +
                "item_cd LIKE 'ORDER_STATUS' ) ORDER_STATUS ON ORDER_STATUS.ITEM_VALUE = o_order_p.ORDER_STATUS_CD\n" +
                "WHERE\n" +
                "	o_order_p.ORDER_STATUS_CD in ('" + str + "' ) \n" +
                "	AND o_order_p.SHOP_ID = '18' \n" +
                "ORDER BY\n" +
                "	o_order_p.order_date DESC";
            return SQLmtm.GetDataTable(sql);
        }
    }
}
