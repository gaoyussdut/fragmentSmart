using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class StylePicList
    {
        public List<StylePic> stylepiclist = new List<StylePic>();

        public StylePicList()
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
" style.SYS_STYLE_ID AS styleId,\n" +
" style.STYLE_CD \"styleEntity.styleCd\",\n" +
" style.STYLE_NAME_CN \"styleEntity.styleNameCn\",\n" +
" style.STYLE_CATEGORY_CD \"styleEntity.styleCategoryCd\",\n" +
" style.STYLE_DRESS_CATEGORY \"styleEntity.styleDressCategory\",\n" +
" style.STYLE_DESIGN_TYPE \"styleEntity.styleDesignType\",\n" +
" style.STYLE_PUBLISH_CATEGORY_CD \"styleEntity.stylePublishCategoryCd\",\n" +
" style.SYTLE_YEAR \"styleEntity.sytleYear\",\n" +
" style.SYTLE_SEASON \"styleEntity.sytleSeason\",\n" +
" style.STYLE_FIT_CD \"styleEntity.styleFitCd\",\n" +
" material.MATERIAL_NAME_CN AS \"materialEntity.materialNameCn\",\n" +
" material.MATERIAL_NAME_EN AS \"materialEntity.materialNameEn\",\n" +
" material.material_id \"materialEntity.id\",\n" +
" GROUP_CONCAT( DISTINCT material.MATERIAL_CODE ) \"materialEntity.materialCode\",\n" +
" style.VERSION,\n" +
" style.CREATE_USER,\n" +
" style.STYLE_MAKE_TYPE \"styleEntity.styleMakeType\",\n" +
" style.STYLE_SIZE_GROUP_CD \"styleEntity.styleSizeGroupCd\",\n" +
" style.STYLE_SIZE_CD \"styleEntity.styleSizeCd\",\n" +
" style.STYLE_FIT_BODY_TYPE \"styleEntity.styleFitBodyType\",\n" +
" CONCAT( login_user.FIRST_NAME, login_user.LAST_NAME ) \"user.loginName\",\n" +
" style.CREATE_DATE,\n" +
" style.COVER_PHOTO_PATH \"styleEntity.coverPhotoPath\",\n" +
" SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1) AS picn,\n" +
" CONCAT('https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/',SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1)) AS picurl   \n" +
"FROM\n" +
" s_style_p style\n" +
" LEFT JOIN i_material_p material ON FIND_IN_SET( CAST( material.MATERIAL_ID AS CHAR ), style.SYTLE_FABRIC_ID )\n" +
" LEFT JOIN a_login_user_p login_user ON login_user.LOGIN_USER_ID = style.CREATE_USER \n" +
"WHERE\n" +
" style.DELETE_FLAG = 0 \n" +
" AND style.STYLE_NAME_CN IS NOT NULL \n" +
"   AND style.STYLE_KBN != 'STYLE_SOURCE-STYLE_SOURCE_50' \n" +
" AND ( style.SHOP_ID = 18 OR style.SHOP_ID = 0 ) \n" +
"GROUP BY\n" +
" style.SYS_STYLE_ID \n" +
"ORDER BY\n" +
" style.UPDATE_DATE DESC \n" +
" -- LIMIT 50");
            foreach(DataRow dr in dt.Rows)
            {
                //StylePic sp = new StylePic(dr["styleId"].ToString().Trim(), dr["styleEntity.styleCd"].ToString().Trim(), dr["picn"].ToString().Trim(), dr["picurl"].ToString().Trim());
                this.stylepiclist.Add(new StylePic(dr["styleId"].ToString().Trim(), dr["styleEntity.styleCd"].ToString().Trim(), dr["picn"].ToString().Trim(), dr["picurl"].ToString().Trim()));
            }
        }
    }
}
