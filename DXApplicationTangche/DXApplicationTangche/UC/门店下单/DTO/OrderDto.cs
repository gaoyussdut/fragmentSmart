using DevExpress.XtraGrid.Demos.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单.DTO
{
    /// <summary>
    /// 订单DTO
    /// </summary>
    class OrderDto
    {
        public String ID { get; set; }
        public String CUSTOMER_ID { get; set; }
        public String shop_id { get; set; }
        public String shop_name { get; set; }
        public String style_id { get; set; }
        public String ORDER_NO { get; set; }
        public Double ORDER_NUMBER { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String STYLE_NAME_CN { get; set; }
        public String SYTLE_YEAR { get; set; }
        public String SYTLE_SEASON { get; set; }
        public String REF_STYLE_ID { get; set; }
        public String SYTLE_FABRIC_ID { get; set; }
        public String MATERIAL_NAME_CN { get; set; }
        public String MATERIAL_COLOR { get; set; }
        public String STYLE_PUBLISH_CATEGORY_CD { get; set; }
        public Enum_ORDER_TYPE ORDER_TYPE { get; set; }

        public Image Picture { get; set; }

        public enum Enum_ORDER_TYPE {服装定制 =1,标准款=2,受托加工=3}

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="CUSTOMER_ID"></param>
        /// <param name="shop_id"></param>
        /// <param name="shop_name"></param>
        /// <param name="style_id"></param>
        /// <param name="ORDER_NO"></param>
        /// <param name="ORDER_NUMBER"></param>
        /// <param name="ORDER_DATE"></param>
        /// <param name="STYLE_SIZE_CD"></param>
        /// <param name="STYLE_NAME_CN"></param>
        /// <param name="SYTLE_YEAR"></param>
        /// <param name="SYTLE_SEASON"></param>
        /// <param name="REF_STYLE_ID"></param>
        /// <param name="SYTLE_FABRIC_ID"></param>
        /// <param name="MATERIAL_NAME_CN"></param>
        /// <param name="MATERIAL_COLOR"></param>
        /// <param name="STYLE_PUBLISH_CATEGORY_CD"></param>
        /// <param name="ORDER_TYPE"></param>
        public OrderDto(String CUSTOMER_ID, String shop_id, String shop_name, String style_id, String ORDER_NO, int ORDER_NUMBER, DateTime ORDER_DATE, String STYLE_SIZE_CD, String STYLE_NAME_CN, String SYTLE_YEAR, String SYTLE_SEASON, String REF_STYLE_ID, String SYTLE_FABRIC_ID, String MATERIAL_NAME_CN, String MATERIAL_COLOR, String STYLE_PUBLISH_CATEGORY_CD, int ORDER_TYPE,String PictureName) {
            this.ID = FunctionHelper.uuid;
            this.CUSTOMER_ID = CUSTOMER_ID;
            this.shop_id = shop_id;
            this.shop_name = shop_name;
            this.style_id = style_id;
            this.ORDER_NO = ORDER_NO;
            this.ORDER_NUMBER = ORDER_NUMBER;
            this.ORDER_DATE = ORDER_DATE;
            this.STYLE_SIZE_CD = STYLE_SIZE_CD;
            this.STYLE_NAME_CN = STYLE_NAME_CN;
            this.Picture = Image.FromFile(@"pic\" +PictureName);
            this.SYTLE_YEAR = SYTLE_YEAR;
            this.SYTLE_SEASON = SYTLE_SEASON;
            this.REF_STYLE_ID = REF_STYLE_ID;
            this.SYTLE_FABRIC_ID = SYTLE_FABRIC_ID;
            this.MATERIAL_NAME_CN = MATERIAL_NAME_CN;
            this.MATERIAL_COLOR = MATERIAL_COLOR;
            this.STYLE_PUBLISH_CATEGORY_CD = STYLE_PUBLISH_CATEGORY_CD;
            this.ORDER_TYPE = (Enum_ORDER_TYPE)ORDER_TYPE;
        }
    }
}
