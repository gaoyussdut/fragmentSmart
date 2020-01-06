using DevExpress.XtraGrid.Demos.util;
using mendian;
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

        public enum Enum_ORDER_TYPE { 服装定制 = 1, 标准款 = 2, 受托加工 = 3 }

        #region 设计点和量体制信息
        public List<Dto设计点> Dto设计点s { get => dto设计点s; }
        public Dto尺寸 Dto尺寸 { get => dto尺寸; }

        private List<Dto设计点> dto设计点s = new List<Dto设计点>();   //  设计点
        private Dto尺寸 dto尺寸;  //  尺寸
        #endregion

        public OrderDto(Dto定制下单 dto定制下单) {
            this.ID = new FunctionHelper().Uuid;
            this.dto设计点s = dto定制下单.Dto设计点s; //  设计点信息
            this.dto尺寸 = dto定制下单.Dto尺寸; //  尺寸信息

            //  款式和面料信息
            this.style_id = dto定制下单.Style_Id;
            this.SYTLE_FABRIC_ID = dto定制下单.SYTLE_FABRIC_ID;
            //this.STYLE_CATEGORY_CD = dto定制下单.STYLE_CATEGORY_CD;
            //this.STYLE_FIT_CD = dto定制下单.STYLE_FIT_CD;
            //this.STYLE_SIZE_GROUP_CD = dto定制下单.STYLE_SIZE_GROUP_CD;
            this.STYLE_SIZE_CD = dto定制下单.STYLE_SIZE_CD;
            this.ORDER_NUMBER = dto定制下单.ORDER_NUMBER;
            this.ORDER_TYPE = Enum_ORDER_TYPE.服装定制;
            try
            {
                this.Picture = Image.FromFile(@"pic\" + ImpService.GetMianLiaoFile(this.SYTLE_FABRIC_ID));
            }
            catch
            {
                this.Picture = Image.FromFile(@"pic\SSHIRT.jpg");
            }
            ImpService.generateOrderSytleInfo(this);
        }

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
            this.ID = new FunctionHelper().Uuid;
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
