﻿using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.库存.service
{
    /// <summary>
    /// 库存服务
    /// </summary>
    class StockBillService
    {
        /// <summary>
        /// 门店验货扫描取barcode方法
        /// </summary>
        /// <param name="LOG_ID"></param>
        /// <returns></returns>
        public static BarCodeInfoDto getSaleBarCodeInfo(String LOG_ID)
        {
            //  读取订单信息
            String sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                "where LOG_ID = '" + LOG_ID + "'";

            DataTable dt = SQLmtm.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                "where LOG_ID = '" + LOG_ID + "'";
                dt = SQLmtm.GetDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("系统中无本产品标签列印信息");
                }
                else
                {
                    throw new Exception("本商品未出库");
                }
            }
            else
            {
                return new BarCodeInfoDto(dt);
            }
        }

        /// <summary>
        /// 门店验货扫描取barcode方法
        /// </summary>
        /// <param name="LOG_ID"></param>
        /// <returns></returns>
        public static BarCodeInfoDto getStockInBarCodeInfo(String LOG_ID) {
            //  读取订单信息
            String sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                "where Id in (select barcode_id from t_godown_entry) and LOG_ID = '" + LOG_ID + "'";

            DataTable dt = SQLmtm.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                "where LOG_ID = '" + LOG_ID + "'";
                dt = SQLmtm.GetDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("系统中无本产品标签列印信息");
                }
                else
                {
                    throw new Exception("本商品未出库");
                }
            }
            else
            {
                return new BarCodeInfoDto(dt);
            }
        }

        /// <summary>
        /// 根据条码取得入库信息
        /// </summary>
        /// <param name="LOG_ID"></param>
        /// <returns></returns>
        public static DataTable getStockInInfo(String LOG_ID) {
            String sql = "SELECT"
                + " t_godown_bill.godown_code,"
                + "	t_shop.shop_id,"
                + "	t_shop.shop_name,"
                + " t_godown_bill.godown_date"
                + " FROM"
                + "    t_godown_bill " 
                + " left join t_shop on t_godown_bill.shop_id = t_shop.shop_id"
                + " WHERE"
                + "    godown_id IN(SELECT godown_id FROM t_godown_entry WHERE barcode_id IN (SELECT id FROM a_product_log_p WHERE LOG_ID = '"+ LOG_ID + "') ); ";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 工厂出库扫描取barcode方法
        /// </summary>
        /// <param name="LOG_ID"></param>
        /// <returns></returns>
        public static BarCodeInfoDto getStockOutBarCodeInfo(String LOG_ID) {
            String sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                        "where Id not in (select barcode_id from t_godown_entry) and LOG_ID = '" + LOG_ID + "'";

            DataTable dt = SQLmtm.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "select Id,LOG_ID,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                "where LOG_ID = '" + LOG_ID + "'";
                dt = SQLmtm.GetDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("系统中无本产品标签列印信息");
                }
                else
                {
                    throw new Exception("本商品已出库");
                }
            }
            else
            {
                return new BarCodeInfoDto(dt);
            }
        }

        /// <summary>
        /// 生成出库单
        /// </summary>
        /// <param name="godown_date"></param>
        /// <param name="godown_code"></param>
        /// <param name="shop_id"></param>
        /// <param name="barCodeInfoDtos"></param>
        public static void generateStockOut(DateTime godown_date,String godown_code,String shop_id, BindingList<BarCodeInfoDto> barCodeInfoDtos) {
            String godown_id = System.Guid.NewGuid().ToString("N");
            //  出货单
            SQLmtm.DoInsert(
                "t_godown_bill"
                , new string[] { "godown_id", "godown_date", "godown_code", "shop_id" }
                , new string[] { godown_id, godown_date.ToString(), godown_code, shop_id }
                );
            //  出货单分录           
            foreach (BarCodeInfoDto barCodeInfo in barCodeInfoDtos)
            {
                SQLmtm.DoInsert(
                    "t_godown_entry"
                    , new string[] { "godown_entry_id", "godown_id", "barcode_id", "is_validate" }
                    , new string[] { System.Guid.NewGuid().ToString("N"), godown_id, barCodeInfo.Id, "1" }
                    );
            }
        }

        /// <summary>
        /// 新增库存明细账
        /// </summary>
        /// <param name="barIds">条形码id</param>
        /// <param name="shop_id">门店id</param>
        /// <param name="bill_id">单号</param>
        /// <param name="stockType">出入库类型</param>
        /// <param name="isStockOut">出否出库，如果是，就是负数</param>
        public static void generateInventoryLedge(List<String> barIds,String shop_id,String bill_id,String stockType,bool isStockOut) {
            String sql = "INSERT INTO t_inventory_sub_ledger ( shop_id, ref_style_id, style_fabric_id, ledger_type, amount, bill_id ) SELECT"
                + " '"+ shop_id + "' AS shop_id,"
                + " STYLE_ID,"
                + " SYTLE_FABRIC_ID,"
                + " '"+ stockType + "',"
                + (isStockOut ? " 0 - " : "") + " count(id) AS id_count,"
                + " '"+ bill_id + "' AS bill_id"
                + " FROM"
                + "     a_product_log_p"
                + " WHERE"
                + "     a_product_log_p.id IN( '"+ String.Join("','", barIds) + "' ) "
                + " GROUP BY"
                + "     STYLE_ID,"
                + "     SYTLE_FABRIC_ID";
            SQLmtm.ExecuteSql(sql);
        }
    }
}
