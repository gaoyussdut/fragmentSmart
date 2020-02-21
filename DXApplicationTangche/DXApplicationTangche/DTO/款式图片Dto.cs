using DXApplicationTangche.service;
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
        public String STYLE_SHOP_TOTAL_PRICE { get; set; }
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
            this.STYLE_PUBLISH_CATEGORY_CD = getSTYLE_PUBLISH_CATEGORY_CD(dr["styleEntity.stylePublishCategoryCd"].ToString());
            this.SYTLE_YEAR = dr["styleEntity.sytleYear"].ToString();
            this.SYTLE_SEASON = getSYTLE_SEASON(dr["styleEntity.sytleSeason"].ToString());
            this.STYLE_SIZE_CD = dr["styleEntity.styleSizeCd"].ToString();
            this.STYLE_SHOP_TOTAL_PRICE = dr["STYLE_SHOP_TOTAL_PRICE"].ToString();
            try
            {
                this.Picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
            }
            catch
            {
                this.Picture= Image.FromFile(@"pic\SSHIRT.jpg");
            }
        }
        private static String getSYTLE_SEASON(String SYTLE_SEASON) {
            if ("SEASON-SEASON_10".Equals(SYTLE_SEASON))
            {
                return "春季";
            }
            if ("SEASON-SEASON_20".Equals(SYTLE_SEASON))
            {
                return "秋季";
            }
            return SYTLE_SEASON;
        }
        private static String getSTYLE_PUBLISH_CATEGORY_CD (String STYLE_PUBLISH_CATEGORY_CD) {
            if ("PUBLISH_STYLE_CATEGORY-WShirt".Equals(STYLE_PUBLISH_CATEGORY_CD)) {
                return "女衬衫";
            }
            if ("PUBLISH_STYLE_CATEGORY-MShirt".Equals(STYLE_PUBLISH_CATEGORY_CD))
            {
                return "男衬衫";
            }
            return STYLE_PUBLISH_CATEGORY_CD;
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
        private List<String> SYTLE_FABRIC_ID { get; set; }
        public String STYLE_SIZE_GROUP_CD { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String STYLE_MAKE_TYPE { get; set; }
        public String STYLE_MATERIAL_NUMBER { get; set; }
        public String STYLE_DESIGN_PRICE { get; set; }
        public String PIC_URL { get; set; }
        public Image Picture { get; set; }
        public Byte ENABLE_FLAG { get; set; }
        public DateTime CREATE_DATE { get; set; }

        public String ErrorMessage { get; set; }

        public List<版型尺码DTO> 尺码一览 { get => 版型尺码Dtos; set => 版型尺码Dtos = value; }
        public List<面料DTO> 面料 { get => 面料DTOs; set => 面料DTOs = value; }
        public List<设计点DTO> 设计点 { get => 设计点DTOs; set => 设计点DTOs = value; }

        private List<面料DTO> 面料DTOs = new List<面料DTO>();
        private List<设计点DTO> 设计点DTOs = new List<设计点DTO>();

        private List<版型尺码DTO> 版型尺码Dtos = new List<版型尺码DTO>();

        public 款式图片一览Dto build版型尺码(
            Dictionary<String, List<String>> EGS_GROUP_SIZEs    //  欧洲尺码
            , Dictionary<String, List<String>> IGS_GROUP_SIZEs  //  国际尺码
            )
        {
            try
            {
                if (!EGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD))
                {
                    this.ErrorMessage += "[没有欧洲尺码]";
                }
                if (!IGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD)) {
                    this.ErrorMessage += "[没有国际尺码]";
                }
                if (!EGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD) && !IGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD))
                {
                    this.ErrorMessage += "[没有尺寸值]";
                }
            }
            catch {
                this.ErrorMessage += "[没有尺寸值]";
                return this;
            }

            if (
                EGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD)
                && IGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD)
                && EGS_GROUP_SIZEs[this.STYLE_FIT_CD].Count == EGS_GROUP_SIZEs[this.STYLE_FIT_CD].Count
                )
            {
                //  正常情况
                for (int i = 0; i < EGS_GROUP_SIZEs[this.STYLE_FIT_CD].Count; i++)
                {
                    this.版型尺码Dtos.Add(
                        new 版型尺码DTO(
                            this.STYLE_FIT_CD
                            , EGS_GROUP_SIZEs[this.STYLE_FIT_CD][i]
                            , IGS_GROUP_SIZEs[this.STYLE_FIT_CD][i])
                        );

                }
            } else if (!EGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD)&& IGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD)) {
                //  没有欧洲尺码
                for (int i = 0; i < IGS_GROUP_SIZEs[this.STYLE_FIT_CD].Count; i++)
                {
                    this.版型尺码Dtos.Add(
                            new 版型尺码DTO(
                                this.STYLE_FIT_CD
                                , null
                                , IGS_GROUP_SIZEs[this.STYLE_FIT_CD][i])
                            );
                }
            }
            else if (EGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD) && !IGS_GROUP_SIZEs.ContainsKey(this.STYLE_FIT_CD))
            {
                //  没有欧洲尺码
                for (int i = 0; i < EGS_GROUP_SIZEs[this.STYLE_FIT_CD].Count; i++)
                {
                    this.版型尺码Dtos.Add(
                            new 版型尺码DTO(
                                this.STYLE_FIT_CD
                                , EGS_GROUP_SIZEs[this.STYLE_FIT_CD][i]
                                , null)
                            );
                }

            }
            return this;
        }

        /// <summary>
        /// 面料信息
        /// </summary>
        internal void build面料()
        {
            this.面料 = FabricService.get面料DTOs(this.SYTLE_FABRIC_ID);
        }
        public void build设计点()
        {
            this.设计点 = ItemService.Get设计点DTOs(this.SYS_STYLE_ID);
        }
        public 款式图片一览Dto(DataRow dr) {
            this.SYS_STYLE_ID = dr["SYS_STYLE_ID"].ToString();
            this.CUSTOMER_COUNT_ID = dr["CUSTOMER_COUNT_ID"].ToString();
            this.STYLE_CD = dr["STYLE_CD"].ToString();
            this.STYLE_CATEGORY_CD = dr["STYLE_CATEGORY_CD"].ToString();
            this.STYLE_DRESS_CATEGORY = dr["STYLE_DRESS_CATEGORY"].ToString();
            this.STYLE_DESIGN_TYPE = dr["STYLE_DESIGN_TYPE"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = String.IsNullOrEmpty(dr["STYLE_PUBLISH_CATEGORY_CD"].ToString())
                ? "无"
                :dr["STYLE_PUBLISH_CATEGORY_CD"].ToString();
            this.REF_STYLE_ID = dr["REF_STYLE_ID"].ToString();
            this.STYLE_NAME_CN = dr["STYLE_NAME_CN"].ToString();
            this.STYLE_NAME_EN = dr["STYLE_NAME_EN"].ToString();
            this.STYLE_FIT_CD = dr["STYLE_FIT_CD"].ToString();
            this.SYTLE_YEAR = dr["SYTLE_YEAR"].ToString();
            this.SYTLE_SEASON = dr["SYTLE_SEASON"].ToString();
            this.SYTLE_FABRIC_ID = new List<string>(dr["SYTLE_FABRIC_ID"].ToString().Split(','));
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
                this.Picture = Image.FromFile(@"pic\SSHIRT.jpg");
                this.ErrorMessage += "[没有款式图片]";
            }
            this.ENABLE_FLAG = Convert.ToByte(dr["ENABLE_FLAG"].ToString());
            this.CREATE_DATE = Convert.ToDateTime( dr["CREATE_DATE"].ToString());
        }
    }

    public class 面料DTO
    {
        private String id ;
        private String fileId ;
        private String materialNameCn ;
        private String materialNameEn ;
        private String materialCode ;
        private String materialUseType ;
        private String materialTypeCd ;
        private String materialComposition ;
        private String materialSpec ;
        private String materialUnitCd ;
        private String materialYear ;
        private String materialColor ;
        private String materialSeason ;
        private String remarks ;
        private String materialStyleCategory ;
        private String modelFilepath ;
        private String filePath ;
        private String createby_lastName ;
        private String createby_firstName ;
        private String materialPrice_materialSalePrice ;
        private String inventoryMaterial_materialQuantity ;
        private String materialLevel ;
        private String materialStyle ;
        private String materialWeave ;
        private String materiaFacPrice ;
        private String mianliao ;
        private String picn ;
        private String picurl ;
        private Image picture ;

        public 面料DTO(DataRow dr) {
            this.Id = dr["id"].ToString();
            this.fileId = dr["fileId"].ToString();
            this.materialNameCn = dr["materialNameCn"].ToString();
            this.materialNameEn = dr["materialNameEn"].ToString();
            this.materialCode = dr["materialCode"].ToString();
            this.materialUseType = dr["materialUseType"].ToString();
            this.materialTypeCd = dr["materialTypeCd"].ToString();
            this.materialComposition = dr["materialComposition"].ToString();
            this.materialSpec = dr["materialSpec"].ToString();
            this.materialUnitCd = dr["materialUnitCd"].ToString();
            this.materialYear = dr["materialYear"].ToString();
            this.materialColor = dr["materialColor"].ToString();
            this.materialSeason = dr["materialSeason"].ToString();
            this.remarks = dr["remarks"].ToString();
            this.materialStyleCategory = dr["materialStyleCategory"].ToString();
            this.modelFilepath = dr["modelFilepath"].ToString();
            this.filePath = dr["filePath"].ToString();
            this.createby_lastName = dr["createby_lastName"].ToString();
            this.createby_firstName = dr["createby_firstName"].ToString();
            this.materialPrice_materialSalePrice = dr["materialPrice_materialSalePrice"].ToString();
            this.inventoryMaterial_materialQuantity = dr["inventoryMaterial_materialQuantity"].ToString();
            this.materialLevel = dr["materialLevel"].ToString();
            this.materialStyle = dr["materialStyle"].ToString();
            this.materialWeave = dr["materialWeave"].ToString();
            this.materiaFacPrice = dr["materiaFacPrice"].ToString();
            this.mianliao = dr["mianliao"].ToString();
            this.picn = dr["picn"].ToString();
            this.picurl = dr["picurl"].ToString();
            this.picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
        }

        public string Id { get => id; set => id = value; }
        public string 面料名称 { get => materialNameCn; set => materialNameCn = value; }
        public string 面料售价 { get => materialPrice_materialSalePrice; set => materialPrice_materialSalePrice = value; }
    }
    public class 设计点DTO
    {
        private String ITEM_CD;
        private String ITEM_VALUE;
        private String OPTION_VALUE;
        private String ITEM_NAME;
        private String OPTION_NAME;
        public 设计点DTO(DataRow dr)
        {
            this.ITEM_CD = dr["ITEM_CD"].ToString();
            this.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
            this.OPTION_VALUE = dr["OPTION_VALUE"].ToString();
            this.ITEM_NAME = dr["ITEM_NAME"].ToString();
            this.OPTION_NAME = dr["OPTION_NAME"].ToString();
        }

        public string 设计点种类 { get => ITEM_NAME; set => ITEM_NAME = value; }
        public string 设计点 { get => OPTION_NAME; set => OPTION_NAME = value; }
    }
    public class 版型尺码DTO { 
        public String FIT_CD { get; set; }  //  版型id
        public string 欧洲尺码组 { get => eGS_GROUP_SIZE; set => eGS_GROUP_SIZE = value; }
        public string 国际尺码组 { get => iGS_GROUP_SIZE; set => iGS_GROUP_SIZE = value; }

        private String eGS_GROUP_SIZE;   //  欧洲尺码
        private String iGS_GROUP_SIZE;    //  国际尺码
        public 版型尺码DTO(String FIT_CD,String EGS_GROUP_SIZE,String IGS_GROUP_SIZE) {
            this.FIT_CD = FIT_CD;
            this.eGS_GROUP_SIZE = EGS_GROUP_SIZE;
            this.iGS_GROUP_SIZE = IGS_GROUP_SIZE;
        }
    }
}
