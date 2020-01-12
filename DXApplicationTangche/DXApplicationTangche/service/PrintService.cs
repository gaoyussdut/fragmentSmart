using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 打印服务
    /// </summary>
    public class PrintService
    {
        /// <summary>
        /// 查询已打印
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetPrintedData(String orderno)
        {
            String sql = "SELECT * FROM a_product_log_p WHERE ORDER_NO='" + orderno + "'";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 无订单打印日志
        /// </summary>
        /// <param name="dTO"></param>
        public static void save_noorder_print_p(DTO无订单打印 dTO)
        {
            int i = SQLmtm.DoInsert("a_noorder_print_p", new string[] { "clothes_log_id", "shop_id", "style_id", "materials_id", "size_cd", "json" }, new string[] { dTO.clothes_log_id, dTO.shop_id, dTO.style_id, dTO.materials_id, dTO.size_cd, dTO.json });
        }
    }
}
