using DevExpress.XtraGrid.Demos.util;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
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
        #region 属性
        public String ID { get; set; }
        public String CUSTOMER_ID { get; set; }
        public String CUSTOMER_NAME { get; set; }
        public String ADDRESS_ID { get; set; }
        public String CUSTOMER_COUNT_ID { get; set; }
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
        public String STYLE_CATEGORY_CD { get; set; }
        public String STYLE_FIT_CD { get; set; }
        public String STYLE_SIZE_GROUP_CD { get; set; }
        public String STYLE_DRESS_CATEGORY { get; set; }
        public String STYLE_DESIGN_TYPE { get; set; }
        public Enum_ORDER_TYPE ORDER_TYPE { get; set; }

        public Image Picture { get; set; }
        #endregion

        #region 枚举
        public enum Enum_ORDER_TYPE { 服装定制 = 1, 标准款 = 2, 受托加工 = 3 }
        #endregion

        #region 设计点和量体制信息
        public List<Dto设计点> Dto设计点s { get => dto设计点s; }
        public Dto尺寸 Dto尺寸 { get => dto尺寸; }

        private List<Dto设计点> dto设计点s = new List<Dto设计点>();   //  设计点
        private Dto尺寸 dto尺寸;  //  尺寸
        #endregion

        /// <summary>
        /// 新增订单转为一览
        /// </summary>
        /// <param name="dto定制下单"></param>
        public OrderDto(Dto定制下单 dto定制下单) {
            this.ID = new FunctionHelper().Uuid;
            this.dto设计点s = dto定制下单.Dto设计点s; //  设计点信息
            this.dto尺寸 = dto定制下单.Dto尺寸; //  尺寸信息

            //  款式和面料信息
            this.REF_STYLE_ID = dto定制下单.Style_Id;
            this.SYTLE_FABRIC_ID = dto定制下单.SYTLE_FABRIC_ID;

            this.STYLE_CATEGORY_CD = dto定制下单.STYLE_CATEGORY_CD;
            this.STYLE_FIT_CD = dto定制下单.STYLE_FIT_CD;
            this.STYLE_SIZE_GROUP_CD = dto定制下单.STYLE_SIZE_GROUP_CD;

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
            this.buildStyle();  //  更新款式信息
            this.buildMaterialInfo();   //  更新面料信息
        }

        /// <summary>
        /// 更新款式信息
        /// </summary>
        private void buildStyle() {
            DataRow dataRow = ImpService.generateStyleInfo(this.REF_STYLE_ID);
            this.STYLE_NAME_CN = dataRow["STYLE_NAME_CN"].ToString();
            this.SYTLE_YEAR = dataRow["SYTLE_YEAR"].ToString();
            this.SYTLE_SEASON = dataRow["SYTLE_SEASON"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = dataRow["STYLE_PUBLISH_CATEGORY_CD"].ToString();
            this.STYLE_DRESS_CATEGORY = dataRow["STYLE_DRESS_CATEGORY"].ToString();
            this.STYLE_DESIGN_TYPE = dataRow["STYLE_DESIGN_TYPE"].ToString();
        }

        /// <summary>
        /// 更新面料信息
        /// </summary>
        private void buildMaterialInfo() {
            DataRow dataRow = ImpService.generateMaterialInfo(this.SYTLE_FABRIC_ID);
            this.MATERIAL_NAME_CN = dataRow["MATERIAL_NAME_CN"].ToString();
            this.MATERIAL_COLOR = dataRow["MATERIAL_COLOR"].ToString();
        }
    }
}
