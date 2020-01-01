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
}
