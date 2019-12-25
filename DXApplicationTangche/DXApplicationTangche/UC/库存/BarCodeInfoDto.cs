using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.库存
{
    /// <summary>
    /// 条码信息
    /// </summary>
    public class BarCodeInfoDto
    {
        public String Id { get; set; }
        public String ORDER_ID { get; set; }
        public String CUSTOMER_ID { get; set; }
        public String SHOP_ID { get; set; }
        public String SHOP_NAME { get; set; }
        public String STYLE_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public String STYLE_NAME_CN { get; set; }
        public String SYTLE_YEAR { get; set; }
        public String SYTLE_SEASON { get; set; }
        public String REF_STYLE_ID { get; set; }
        public String SYTLE_FABRIC_ID { get; set; }
        public String MATERIAL_NAME_CN { get; set; }
        public String MATERIAL_COLOR { get; set; }
        public String STYLE_PUBLISH_CATEGORY_CD { get; set; }
        public String ORDER_NO { get; set; }

        public BarCodeInfoDto(DataTable dataTable) {
            this.Id = dataTable.Rows[0]["Id"].ToString();
            this.ORDER_ID = dataTable.Rows[0]["ORDER_ID"].ToString();
            this.CUSTOMER_ID = dataTable.Rows[0]["CUSTOMER_ID"].ToString();
            this.SHOP_ID = dataTable.Rows[0]["SHOP_ID"].ToString();
            this.SHOP_NAME = dataTable.Rows[0]["SHOP_NAME"].ToString();
            this.STYLE_ID = dataTable.Rows[0]["STYLE_ID"].ToString();
            this.ORDER_DATE = Convert.ToDateTime(dataTable.Rows[0]["ORDER_DATE"].ToString());
            this.STYLE_NAME_CN = dataTable.Rows[0]["STYLE_NAME_CN"].ToString();
            this.SYTLE_YEAR = dataTable.Rows[0]["SYTLE_YEAR"].ToString();
            this.SYTLE_SEASON = dataTable.Rows[0]["SYTLE_SEASON"].ToString();
            this.REF_STYLE_ID = dataTable.Rows[0]["REF_STYLE_ID"].ToString();
            this.SYTLE_FABRIC_ID = dataTable.Rows[0]["SYTLE_FABRIC_ID"].ToString();
            this.MATERIAL_NAME_CN = dataTable.Rows[0]["MATERIAL_NAME_CN"].ToString();
            this.MATERIAL_COLOR = dataTable.Rows[0]["MATERIAL_COLOR"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = dataTable.Rows[0]["STYLE_PUBLISH_CATEGORY_CD"].ToString();
            this.ORDER_NO = dataTable.Rows[0]["ORDER_NO"].ToString();
        }
    }
}
