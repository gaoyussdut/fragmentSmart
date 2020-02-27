using DXApplicationTangche.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    class ProduceService
    {
        public static Boolean UpData裁剪条码打印生产工序(String orderid)
        {
            String STYLE_BAR_CODE;
            String ORDERNO;
            String PRODUCTION_ID = "0";
            try
            {
                ORDERNO = OrderService.GetOrderNoWithOrderid(orderid);
                STYLE_BAR_CODE = OrderService.GetSBCWithOrderid(orderid);
                #region 定制款式款式生产工序表更新
                SQLerp.DoUpdate("s_style_operating_s", new string[] { "OPERATING_STATUS", "UPDATE_USER" }, new string[] { "OPERATING_STATUS-OS_10", "429" }, new string[] { "STYLE_BAR_CODE", "OPERATING_ITME_ID" }, new string[] { STYLE_BAR_CODE, "3" });
                #endregion

                #region 通过barCode从生产制单信息管理表里面获取PRODUCTION_ID
                String sql = "SELECT\n" +
"CASE\n" +
"		\n" +
"	WHEN\n" +
"		(\n" +
"		SELECT\n" +
"			pp.PRODUCTION_ID \n" +
"		FROM\n" +
"			p_production_p pp\n" +
"			LEFT JOIN p_notice_production_r notice_production ON pp.PRODUCTION_ID = notice_production.PRODUCTION_ID\n" +
"			LEFT JOIN p_plan_notice_order_r notice_order ON notice_order.NOTICE_ID = notice_production.NOTICE_ID \n" +
"		WHERE\n" +
"			notice_order.ORDER_ID = "+orderid+" \n" +
"			) IS NOT NULL THEN\n" +
"			(\n" +
"			SELECT\n" +
"				pp.PRODUCTION_ID \n" +
"			FROM\n" +
"				p_production_p pp\n" +
"				LEFT JOIN p_notice_production_r notice_production ON pp.PRODUCTION_ID = notice_production.PRODUCTION_ID\n" +
"				LEFT JOIN p_plan_notice_order_r notice_order ON notice_order.NOTICE_ID = notice_production.NOTICE_ID \n" +
"			WHERE\n" +
"				notice_order.ORDER_ID = "+orderid+" \n" +
"			) ELSE ( SELECT pp.PRODUCTION_ID FROM p_production_p pp LEFT JOIN c_contract_custom_order_r cco ON cco.CONTRACT_ID = pp.CONTRACT_ID WHERE cco.ORDER_ID = "+orderid+" ) \n" +
"	END productionId";
                #endregion
                DataRow dr = SQLerp.GetDataRow(sql);
                if(dr==null)
                {
                    PRODUCTION_ID = "0";
                }
                else
                {
                    PRODUCTION_ID = "1";
                }
                #region p_production_item_s增加一条数据
                SQLerp.DoInsert("p_production_item_s", new string[] { "PRODUCTION_ID", "ORDER_ID", "ORDER_NO", "BAR_CODE", "OPERATING_ID", "PROCESS_NUMBER", "PROCESS_STATUS", "SETTLE_FLAG", "VERSION", "DEL_FLG", "CREATE_USER_ID", "UPDATE_USER_ID" }, new string[] { PRODUCTION_ID, orderid, ORDERNO, STYLE_BAR_CODE, "3", "1", "OPERATING_STATUS-OS_10", "0", "1", "0", "429", "429" });
                #endregion
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
