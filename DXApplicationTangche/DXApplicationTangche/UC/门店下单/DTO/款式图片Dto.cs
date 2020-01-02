using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单.DTO
{
    public class 款式图片Dto
    {
        public String StyleId { get; set; }
        public String StyleNameCn { get; set; }
        public String MaterialId { get; set; }
        public String MaterialNameCn { get; set; }
        public Image Picture { get; set; }
        public String STYLE_CATEGORY_CD { get; set; }
        public String STYLE_FIT_CD { get; set; }
        public String STYLE_SIZE_GROUP_CD { get; set; }
        public String STYLE_DRESS_CATEGORY { get; set; }
        public String STYLE_DESIGN_TYPE { get; set; }
        public String STYLE_PUBLISH_CATEGORY_CD { get; set; }
        public String SYTLE_YEAR { get; set; }
        public String SYTLE_SEASON { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String Flag;

        public 款式图片Dto(String flag, DataRow dr) {
            this.Flag = flag;
            this.StyleId = dr["styleId"].ToString();
            this.StyleNameCn = dr["styleEntity.styleNameCn"].ToString();
            this.MaterialId = dr["materialEntity.id"].ToString();
            this.MaterialNameCn = dr["materialEntity.materialNameCn"].ToString();
            this.STYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
            this.STYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
            this.STYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
            this.STYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
            this.STYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
            this.SYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
            this.SYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
            this.STYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
            this.Picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
        }
    }

    public class 款式图片一览Dto
    {
        public String SYS_STYLE_ID { get; set; }
        public String CUSTOMER_COUNT_ID { get; set; }
        public String STYLE_CD { get; set; }
        public String STYLE_CATEGORY_CD { get; set; }
        public String STYLE_DRESS_CATEGORY { get; set; }
        public String STYLE_DESIGN_TYPE { get; set; }
        public String STYLE_PUBLISH_CATEGORY_CD { get; set; }
        public String REF_STYLE_ID { get; set; }
        public String STYLE_NAME_CN { get; set; }
        public String STYLE_NAME_EN { get; set; }
        public String STYLE_FIT_CD { get; set; }
        public String SYTLE_YEAR { get; set; }
        public String SYTLE_SEASON { get; set; }
        public String SYTLE_FABRIC_ID { get; set; }
        public String STYLE_SIZE_GROUP_CD { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String STYLE_MAKE_TYPE { get; set; }
        public String STYLE_MATERIAL_NUMBER { get; set; }
        public String STYLE_DESIGN_PRICE { get; set; }
        public String PIC_URL { get; set; }
        public Image Picture { get; set; }
        public Byte ENABLE_FLAG { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public 款式图片一览Dto(DataRow dr) {
            this.SYS_STYLE_ID = dr["SYS_STYLE_ID"].ToString();
            this.CUSTOMER_COUNT_ID = dr["CUSTOMER_COUNT_ID"].ToString();
            this.STYLE_CD = dr["STYLE_CD"].ToString();
            this.STYLE_CATEGORY_CD = dr["STYLE_CATEGORY_CD"].ToString();
            this.STYLE_DRESS_CATEGORY = dr["STYLE_DRESS_CATEGORY"].ToString();
            this.STYLE_DESIGN_TYPE = dr["STYLE_DESIGN_TYPE"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = dr["STYLE_PUBLISH_CATEGORY_CD"].ToString();
            this.REF_STYLE_ID = dr["REF_STYLE_ID"].ToString();
            this.STYLE_NAME_CN = dr["STYLE_NAME_CN"].ToString();
            this.STYLE_NAME_EN = dr["STYLE_NAME_EN"].ToString();
            this.STYLE_FIT_CD = dr["STYLE_FIT_CD"].ToString();
            this.SYTLE_YEAR = dr["SYTLE_YEAR"].ToString();
            this.SYTLE_SEASON = dr["SYTLE_SEASON"].ToString();
            this.SYTLE_FABRIC_ID = dr["SYTLE_FABRIC_ID"].ToString();
            this.STYLE_SIZE_GROUP_CD = dr["STYLE_SIZE_GROUP_CD"].ToString();
            this.STYLE_SIZE_CD = dr["STYLE_SIZE_CD"].ToString();
            this.STYLE_MAKE_TYPE = dr["STYLE_MAKE_TYPE"].ToString();
            this.STYLE_MATERIAL_NUMBER = dr["STYLE_MATERIAL_NUMBER"].ToString();
            this.STYLE_DESIGN_PRICE = dr["STYLE_DESIGN_PRICE"].ToString();
            this.PIC_URL = dr["PIC_URL"].ToString();
            try
            {
                this.Picture = Image.FromFile(@"pic\" + dr["PIC_NAME"].ToString());
            }
            catch { 
            }
            this.ENABLE_FLAG = Convert.ToByte(dr["ENABLE_FLAG"].ToString());
            this.CREATE_DATE = Convert.ToDateTime( dr["CREATE_DATE"].ToString());
        }
    }
}
