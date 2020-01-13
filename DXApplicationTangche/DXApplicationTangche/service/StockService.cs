using DiaoPaiDaYin;
using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DXApplicationTangche.UC.门店下单.form.标准款.Frm扫码下单;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 门店服务
    /// </summary>
    public class StockService
    {
        public enum Enum在库类别 { 成品仓,在途,在库,已出库 };
        /// <summary>
        /// 取得门店全部库存
        /// </summary>
        /// <returns></returns>
        public static List<ShopStockDto> getStopStockAll() {
            String sql = "SELECT\n" +
                "	amount,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	shop_id,\n" +
                "	shop_name,\n" +
                "	MATERIAL_ID,\n" +
                "	MATERIAL_NAME_CN,\n" +
                "	MATERIAL_COLOR,\n" +
                "	SYS_STYLE_ID,\n" +
                "	SYTLE_YEAR,\n" +
                "	SYTLE_SEASON,\n" +
                "	SYS_STYLE_SIZE_CD,\n" +
                "	STYLE_NAME_CN,\n" +
                "	STYLE_PUBLISH_CATEGORY_CD \n" +
                "FROM\n" +
                "	v_stock_inventory \n" +
                "   where amount<>0";
            DataTable dataTable = SQLmtm.GetDataTable(sql);

            List<ShopStockDto> shopStockDtos = new List<ShopStockDto>();
            foreach (DataRow dataRow in dataTable.Rows) {
                shopStockDtos.Add(new ShopStockDto(dataRow));
            }
            return shopStockDtos;
        }

        /// <summary>
        /// 根据条码查询库存
        /// </summary>
        /// <param name="billNo"></param>
        /// <returns></returns>
        public static DataTable getStopStockByBillNo(String billNo) {
            String sql = "SELECT\n" +
                "	t_inventory_sub_ledger.bill_id,\n" +
                "	v_stock_inventory.shop_name,\n" +
                "	t_inventory_sub_ledger.REF_STYLE_ID,\n" +
                "	v_stock_inventory.STYLE_NAME_CN,\n" +
                "	v_stock_inventory.amount,\n" +
                "	t_inventory_sub_ledger.STYLE_SIZE_CD \n" +
                "FROM\n" +
                "	t_inventory_sub_ledger\n" +
                "	LEFT JOIN v_stock_inventory ON v_stock_inventory.SYS_STYLE_ID = t_inventory_sub_ledger.REF_STYLE_ID \n" +
                "	AND v_stock_inventory.shop_id = t_inventory_sub_ledger.shop_id \n" +
                "WHERE\n" +
                "	REF_STYLE_ID = '“+billNo+”' \n" +
                "ORDER BY\n" +
                "	create_date DESC \n" +
                "	LIMIT 1";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 出入库
        /// </summary>
        /// <param name="enum进出库类型"></param>
        /// <param name="barCode"></param>
        public static void generateLedge(Enum进出库类型 enum进出库类型,String barCode,String shopId) {
            switch (enum进出库类型) {
                case Enum进出库类型.调拨:
                    generate门店扫码调拨(barCode, shopId);
                    break;
                default:
                    generate门店扫码出入库(enum进出库类型,barCode);
                    break;
            }                
        }

        private static void generate门店扫码调拨(String barCode, String shopId) {
            if (String.IsNullOrEmpty(shopId)) {
                throw new Exception("请选择调拨门店");
            }
            generate门店扫码出入库(Enum进出库类型.出库, barCode); //  调拨出库
            generate门店扫码出入库(Enum进出库类型.入库, barCode, shopId);   //  调拨入库
        }

        private static void generate门店扫码出入库(Enum进出库类型 enum进出库类型, String barCode) {
            String sql = "SELECT dispath_type FROM a_noorder_print_p WHERE clothes_log_id = '" + barCode + "'";
            DataTable dataTable = SQLmtm.GetDataTable(sql);
            if (dataTable.Rows.Count == 0)
            {
                throw new Exception("条码" + barCode + "不存在！");
            }
            else
            {
                Enum在库类别 enum在库类别;
                try
                {
                    enum在库类别 = (Enum在库类别)Convert.ToInt32(dataTable.Rows[0]["dispath_type"].ToString());
                }
                catch
                {
                    enum在库类别 = Enum在库类别.成品仓;
                }
                if (enum在库类别.Equals(Enum在库类别.已出库) && enum进出库类型.Equals(Enum进出库类型.出库))
                {
                    throw new Exception("条码" + barCode + "已出库！");
                }
                if (enum在库类别.Equals(Enum在库类别.在库) && enum进出库类型.Equals(Enum进出库类型.入库))
                {
                    throw new Exception("条码" + barCode + "已入库！");
                }
            }

            //  生成库存明细账
            sql = "INSERT INTO t_inventory_sub_ledger ( shop_id, ref_style_id, style_fabric_id, amount, bill_id, STYLE_SIZE_CD, create_date ) SELECT\n" +
                "shop_id,\n" +
                "style_id,\n" +
                "materials_id,\n";
            if (enum进出库类型.Equals(Enum进出库类型.出库))
            {
                sql += "-1,\n";
            }
            else
            {
                sql += "1,\n";
            }

            sql += "clothes_log_id,\n" +
                "size_cd,\n" +
                "now( ) \n" +
                "FROM\n" +
                "	a_noorder_print_p \n" +
                "WHERE\n" +
                "	clothes_log_id = '" + barCode + "'";
            SQLmtm.ExecuteSql(sql);
            //  更新库存状态
            sql = "update a_noorder_print_p set dispath_type = '" + (int)getEnum在库类别(enum进出库类型) + "' WHERE clothes_log_id = '" + barCode + "'";
            SQLmtm.ExecuteSql(sql);
        }

        /// <summary>
        /// 指定门店出入库
        /// </summary>
        /// <param name="enum进出库类型"></param>
        /// <param name="barCode"></param>
        /// <param name="shop_id"></param>
        private static void generate门店扫码出入库(Enum进出库类型 enum进出库类型, String barCode,String shop_id)
        {
            String sql = "SELECT dispath_type FROM a_noorder_print_p WHERE clothes_log_id = '" + barCode + "'";
            DataTable dataTable = SQLmtm.GetDataTable(sql);
            if (dataTable.Rows.Count == 0)
            {
                throw new Exception("条码" + barCode + "不存在！");
            }
            else
            {
                Enum在库类别 enum在库类别;
                try
                {
                    enum在库类别 = (Enum在库类别)Convert.ToInt32(dataTable.Rows[0]["dispath_type"].ToString());
                }
                catch
                {
                    enum在库类别 = Enum在库类别.成品仓;
                }
                if (enum在库类别.Equals(Enum在库类别.已出库) && enum进出库类型.Equals(Enum进出库类型.出库))
                {
                    throw new Exception("条码" + barCode + "已出库！");
                }
                if (enum在库类别.Equals(Enum在库类别.在库) && enum进出库类型.Equals(Enum进出库类型.入库))
                {
                    throw new Exception("条码" + barCode + "已入库！");
                }
            }

            //  生成库存明细账
            sql = "INSERT INTO t_inventory_sub_ledger ( shop_id, ref_style_id, style_fabric_id, amount, bill_id, STYLE_SIZE_CD, create_date ) SELECT\n" +
                shop_id + ",\n" +
                "style_id,\n" +
                "materials_id,\n";
            if (enum进出库类型.Equals(Enum进出库类型.出库))
            {
                sql += "-1,\n";
            }
            else
            {
                sql += "1,\n";
            }

            sql += "clothes_log_id,\n" +
                "size_cd,\n" +
                "now( ) \n" +
                "FROM\n" +
                "	a_noorder_print_p \n" +
                "WHERE\n" +
                "	clothes_log_id = '" + barCode + "'";
            SQLmtm.ExecuteSql(sql);
            //  更新库存状态
            sql = "update a_noorder_print_p set dispath_type = '" + (int)getEnum在库类别(enum进出库类型) + "' WHERE clothes_log_id = '" + barCode + "'";
            SQLmtm.ExecuteSql(sql);
        }

        /// <summary>
        /// 根据进出库类型更新在库类别
        /// </summary>
        /// <param name="enum进出库类型"></param>
        /// <returns></returns>
        private static Enum在库类别 getEnum在库类别(Enum进出库类型 enum进出库类型) {
            switch (enum进出库类型) {
                case Enum进出库类型.入库:
                    return Enum在库类别.在库;
                case Enum进出库类型.出库:
                    return Enum在库类别.已出库;
                default:
                    return Enum在库类别.成品仓;
            }
        }
    }

    /// <summary>
    /// 门店服务
    /// </summary>
    class ShopService
    {
        /// <summary>
        /// 取得所有门店
        /// </summary>
        /// <returns></returns>
        public static DataTable getShopAll()
        {
            String sql = "select shop_id,shop_name,shop_type from t_shop";
            return SQLmtm.GetDataTable(sql);
        }
    }
}
