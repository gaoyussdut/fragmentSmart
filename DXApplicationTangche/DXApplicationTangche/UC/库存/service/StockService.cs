using DiaoPaiDaYin;
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
    class StockService
    {
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
    }

    /// <summary>
    /// 门店服务
    /// </summary>
    class ShopService {
        /// <summary>
        /// 取得所有门店
        /// </summary>
        /// <returns></returns>
        public static DataTable getShopAll() {
            String sql = "select shop_id,shop_name,shop_type from t_shop";
            return SQLmtm.GetDataTable(sql);
        }
    }
}
