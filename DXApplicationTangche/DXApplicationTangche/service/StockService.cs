using DiaoPaiDaYin;
using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
