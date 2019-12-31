﻿using DiaoPaiDaYin;
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
                "	v_stock_inventory \n";
            DataTable dataTable = SQLmtm.GetDataTable(sql);

            List<ShopStockDto> shopStockDtos = new List<ShopStockDto>();
            foreach (DataRow dataRow in dataTable.Rows) {
                shopStockDtos.Add(new ShopStockDto(dataRow));
            }
            return shopStockDtos;
        }

        /// <summary>
        /// 出入库
        /// </summary>
        /// <param name="enum进出库类型"></param>
        /// <param name="barCode"></param>
        public static void generateLedge(Enum进出库类型 enum进出库类型,String barCode) {
            String sql = "SELECT 1 FROM a_noorder_print_p WHERE clothes_log_id = '"+ barCode + "'";
            DataTable dataTable = SQLmtm.GetDataTable(sql);
            if (dataTable.Rows.Count == 0) {
                throw new Exception("条码"+barCode+"不存在！");
            }

            sql = "INSERT INTO t_inventory_sub_ledger ( shop_id, ref_style_id, style_fabric_id, amount, bill_id, STYLE_SIZE_CD, create_date ) SELECT\n" +
                "shop_id,\n" +
                "style_id,\n" +
                "materials_id,\n";
            if (enum进出库类型.Equals(Enum进出库类型.出库))
            {
                sql += "1,\n";
            }
            else {
                sql += "-1,\n";
            }

            sql +="clothes_log_id,\n" +
                "size_cd,\n" +
                "now( ) \n" +
                "FROM\n" +
                "	a_noorder_print_p \n" +
                "WHERE\n" +
                "	clothes_log_id = '"+ barCode + "'";
            SQLmtm.ExecuteSql(sql);
        }
    }
}
