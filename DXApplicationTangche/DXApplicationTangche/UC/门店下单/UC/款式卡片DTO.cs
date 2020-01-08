using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单.UC
{
    public class 款式卡片DTO
    {
        public String kuanshiid { get; set; }
        public String kuanshimingcheng { get; set; }
        public String mianliaoid { get; set; }
        public String mianliaomingcheng { get; set; }
        public String banid { get; set; }
        public String id { get; set; }
        public String jiage { get; set; }
        public Image Picture { get; set; }
        public String styleid { get; set; }
        public String sTYLE_CATEGORY_CD { get; set; }
        public String sTYLE_FIT_CD { get; set; }
        public String sTYLE_SIZE_GROUP_CD { get; set; }
        public String sTYLE_DRESS_CATEGORY { get; set; }
        public String sTYLE_DESIGN_TYPE { get; set; }
        public String sTYLE_PUBLISH_CATEGORY_CD { get; set; }
        public String sYTLE_YEAR { get; set; }
        public String sYTLE_SEASON { get; set; }
        public String sTYLE_SIZE_CD { get; set; }
        public String flag;

        public 款式卡片DTO(String flag, DataRow dr)
        {
            this.flag = flag;
            this.kuanshiid = dr["styleId"].ToString();
            this.kuanshimingcheng = dr["styleEntity.styleNameCn"].ToString();
            this.mianliaoid = dr["materialEntity.id"].ToString();
            this.mianliaomingcheng = dr["materialEntity.materialNameCn"].ToString();
            this.sTYLE_CATEGORY_CD = dr["styleEntity.styleCategoryCd"].ToString();
            this.sTYLE_FIT_CD = dr["styleEntity.styleFitCd"].ToString();
            this.sTYLE_SIZE_GROUP_CD = dr["styleEntity.styleSizeGroupCd"].ToString();
            this.sTYLE_DRESS_CATEGORY = dr["styleEntity.styleDressCategory"].ToString();
            this.sTYLE_DESIGN_TYPE = dr["styleEntity.styleDesignType"].ToString();
            this.sTYLE_PUBLISH_CATEGORY_CD = dr["styleEntity.stylePublishCategoryCd"].ToString();
            this.sYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
            this.sYTLE_SEASON = dr["styleEntity.sytleSeason"].ToString();
            this.sTYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
            this.Picture = String.IsNullOrEmpty(dr["picn"].ToString()) 
                ? Image.FromFile(@"pic\SSHIRT.jpg") 
                : Image.FromFile(@"pic\" + dr["picn"].ToString());
        }
    }
}
