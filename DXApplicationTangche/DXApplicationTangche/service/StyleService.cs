using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常;
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
    /// 款式服务
    /// </summary>
    public class StyleService
    {

        public static 款式图片一览Dto getStyleByORDER_ID(String ORDER_ID)
        {
            String sql = "SELECT\n" +
                "	SYS_STYLE_ID,\n" +
                "	CUSTOMER_COUNT_ID,\n" +
                "	STYLE_CD,\n" +
                "	STYLE_CATEGORY_CD,\n" +
                "	STYLE_DRESS_CATEGORY,\n" +
                "	STYLE_DESIGN_TYPE,\n" +
                "	STYLE_PUBLISH_CATEGORY_CD,\n" +
                "	REF_STYLE_ID,\n" +
                "	STYLE_NAME_CN,\n" +
                "	STYLE_NAME_EN,\n" +
                "	STYLE_FIT_CD,\n" +
                "	SYTLE_YEAR,\n" +
                "	SYTLE_SEASON,\n" +
                "	SYTLE_FABRIC_ID,\n" +
                "	STYLE_SIZE_GROUP_CD,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	STYLE_MAKE_TYPE,\n" +
                "	STYLE_MATERIAL_NUMBER,\n" +
                "	STYLE_DESIGN_PRICE,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) ) AS PIC_URL,\n" +
                "	SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) AS PIC_NAME,\n" +
                "	ENABLE_FLAG,\n" +
                "	CREATE_DATE\n" +
                "FROM\n" +
                "	s_style_p\n" +
                " where s_style_p.SYS_STYLE_ID in (select STYLE_ID from o_order_p where order_id = '" + ORDER_ID+"')" +
                "	order by CREATE_DATE";
            List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();

            DataTable dataTable = SQLmtm.GetDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return new 款式图片一览Dto(dataRow);
            }
            throw new Exception("没有款式信息");
        }

            /// <summary>
            /// 取得所有款式信息
            /// </summary>
            /// <returns></returns>
            public static 款式Model getAllStyle(byte ENABLE_FLAG)
        {
            String sql = "SELECT\n" +
                "	SYS_STYLE_ID,\n" +
                "	CUSTOMER_COUNT_ID,\n" +
                "	STYLE_CD,\n" +
                "	STYLE_CATEGORY_CD,\n" +
                "	STYLE_DRESS_CATEGORY,\n" +
                "	STYLE_DESIGN_TYPE,\n" +
                "	STYLE_PUBLISH_CATEGORY_CD,\n" +
                "	REF_STYLE_ID,\n" +
                "	STYLE_NAME_CN,\n" +
                "	STYLE_NAME_EN,\n" +
                "	STYLE_FIT_CD,\n" +
                "	SYTLE_YEAR,\n" +
                "	SYTLE_SEASON,\n" +
                "	SYTLE_FABRIC_ID,\n" +
                "	STYLE_SIZE_GROUP_CD,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	STYLE_MAKE_TYPE,\n" +
                "	STYLE_MATERIAL_NUMBER,\n" +
                "	STYLE_DESIGN_PRICE,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) ) AS PIC_URL,\n" +
                "	SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) AS PIC_NAME,\n" +
                "	ENABLE_FLAG,\n" +
                "	CREATE_DATE\n" +
                "FROM\n" +
                "	v_style_p\n" +
                " where v_style_p.ENABLE_FLAG = '" + ENABLE_FLAG + "'" +
                "	order by CREATE_DATE";
            List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();

            List<String> FIT_CDs = new List<string>();  //  版型id
            DataTable dataTable = SQLmtm.GetDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                款式图片一览Dto 款式图片一览Dto = new 款式图片一览Dto(dataRow);
                款式图片一览Dtos.Add(款式图片一览Dto);
                if (!FIT_CDs.Contains(款式图片一览Dto.STYLE_FIT_CD))
                {
                    FIT_CDs.Add(款式图片一览Dto.STYLE_FIT_CD);    //  版型
                }
            }
            款式Model model = new 款式Model(款式图片一览Dtos);

            if (FIT_CDs.Count > 0)
            {
                sql = "SELECT DISTINCT\n" +
                    "	FIT_CD,\n" +
                    "	SIZEGROUP_CD,\n" +
                    "	SIZE_CD \n" +
                    "FROM\n" +
                    "	a_size_fit_p \n" +
                    "WHERE\n" +
                    "	FIT_CD IN ( '" + String.Join("','", FIT_CDs) + "' ) \n" +
                    "ORDER BY\n" +
                    "	FIT_CD,\n" +
                    "	SIZEGROUP_CD,\n" +
                    "	SIZE_CD";
                dataTable = SQLmtm.GetDataTable(sql);
                //List<String> EGS_GROUP_SIZEs = new List<string>();   //  数字尺码
                //List<String> IGS_GROUP_SIZEs = new List<string>();  //  英文尺码
                model.buildSizeFit(dataTable);
            }

            return model.buildView();
        }

        /// <summary>
        /// 取得所有款式信息
        /// </summary>
        /// <returns></returns>
        public static List<款式图片一览Dto> getStyleByIds(List<String> ids)
        {
            String sql = "SELECT\n" +
                "	SYS_STYLE_ID,\n" +
                "	CUSTOMER_COUNT_ID,\n" +
                "	STYLE_CD,\n" +
                "	STYLE_CATEGORY_CD,\n" +
                "	STYLE_DRESS_CATEGORY,\n" +
                "	STYLE_DESIGN_TYPE,\n" +
                "	STYLE_PUBLISH_CATEGORY_CD,\n" +
                "	REF_STYLE_ID,\n" +
                "	STYLE_NAME_CN,\n" +
                "	STYLE_NAME_EN,\n" +
                "	STYLE_FIT_CD,\n" +
                "	SYTLE_YEAR,\n" +
                "	SYTLE_SEASON,\n" +
                "	SYTLE_FABRIC_ID,\n" +
                "	STYLE_SIZE_GROUP_CD,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	STYLE_MAKE_TYPE,\n" +
                "	STYLE_MATERIAL_NUMBER,\n" +
                "	STYLE_DESIGN_PRICE,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) ) AS PIC_URL,\n" +
                "	SUBSTRING_INDEX( COVER_PHOTO_PATH, '/',- 1 ) AS PIC_NAME,\n" +
                "	ENABLE_FLAG,\n" +
                "	CREATE_DATE\n" +
                "FROM\n" +
                "	v_style_p\n" +
                " where v_style_p.SYS_STYLE_ID in ('"+String.Join("','",ids)+"')" +
                "	order by CREATE_DATE";
            List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();

            DataTable dataTable = SQLmtm.GetDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                款式图片一览Dto 款式图片一览Dto = new 款式图片一览Dto(dataRow);
                款式图片一览Dtos.Add(款式图片一览Dto);
            }
            return 款式图片一览Dtos;
        }

        /// <summary>
        /// 根据标准款取款式信息
        /// </summary>
        /// <param name="REF_STYLE_ID"></param>
        /// <returns></returns>
        public static DataRow generateStyleInfo(String REF_STYLE_ID)
        {
            String sql = "SELECT\n" +
                "	SYS_STYLE_ID,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	STYLE_NAME_CN,\n" +
                "	SYTLE_YEAR,STYLE_DRESS_CATEGORY,STYLE_DESIGN_TYPE,\n" +
                "	( CASE `s_style_p`.`SYTLE_SEASON` WHEN 'SEASON-SEASON_10' THEN '春季' WHEN 'SEASON-SEASON_20' THEN '秋季' ELSE `s_style_p`.`SYTLE_SEASON` END ) AS `SYTLE_SEASON`,\n" +
                "	( CASE `s_style_p`.`STYLE_PUBLISH_CATEGORY_CD` WHEN 'PUBLISH_STYLE_CATEGORY-MShirt' THEN '男士衬衫' WHEN 'PUBLISH_STYLE_CATEGORY-WShirt' THEN '女式衬衫' ELSE `s_style_p`.`STYLE_PUBLISH_CATEGORY_CD` END ) AS `STYLE_PUBLISH_CATEGORY_CD` \n" +
                "FROM\n" +
                "	s_style_p \n" +
                "WHERE\n" +
                "	SYS_STYLE_ID = '" + REF_STYLE_ID + "'";

            return SQLmtm.GetDataRow(sql);
        }

        /// <summary>
        /// 查找款式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable initStyle(String str, int page)
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
                " style.COVER_PHOTO_PATH \"styleEntity.coverPhotoPath\", \n" +
                "SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1) AS picn," +
                " CONCAT('https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/',SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1)) AS picurl \n" +
                "FROM\n" +
                " s_style_p style\n" +
                " LEFT JOIN i_material_p material ON FIND_IN_SET( CAST( material.MATERIAL_ID AS CHAR ), style.SYTLE_FABRIC_ID )\n" +
                " LEFT JOIN a_login_user_p login_user ON login_user.LOGIN_USER_ID = style.CREATE_USER \n" +
                "WHERE\n" +
                " style.DELETE_FLAG = 0 \n" +
                " AND style.STYLE_NAME_CN IS NOT NULL \n" +
                "   AND style.STYLE_KBN != 'STYLE_SOURCE-STYLE_SOURCE_50' \n" +
                " AND ( style.SHOP_ID = 18 OR style.SHOP_ID = 0 )\n" +
                "AND style.STYLE_NAME_CN LIKE '%" + str + "%'\n" +
                "GROUP BY\n" +
                " style.SYS_STYLE_ID \n" +
                "ORDER BY\n" +
                " style.UPDATE_DATE DESC \n" +
                " LIMIT " + ((page - 1) * 21).ToString() + ",21");
            return dt;
        }

        /// <summary>
        /// 获得款式所有尺码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable StyleCombobox(String styleid)
        {
            DataRow dr = SQLmtm.GetDataRow("SELECT SYS_STYLE_ID,SHOP_ID,STYLE_NO,CUSTOMER_COUNT_ID,STYLE_CD,STYLE_KBN,STYLE_SOURCE,STYLE_CATEGORY_CD,STYLE_DRESS_CATEGORY,STYLE_DESIGN_TYPE,STYLE_PUBLISH_CATEGORY_CD,REF_STYLE_ID,STYLE_NAME_CN,STYLE_NAME_EN,STYLE_FIT_CD,SYTLE_YEAR,SYTLE_SEASON,SYTLE_FABRIC_ID,SYTLE_FABRIC_NO,STYLE_COMPOSITION,STYLE_DESCRIBE,STYLE_COLOR_CD,STYLE_COLOR_NAME,STYLE_SIZE_GROUP_CD,STYLE_SIZE_CD,STYLE_MAKE_TYPE,STYLE_FIT_BODY_TYPE,STYLE_SEX_CD,STYLE_STANDARD,STYLE_BAR_CODE,STYLE_DESIGNER_DATE,STYLE_DESIGNER,STYLE_MATERIAL_NUMBER,STYLE_DESIGN_PRICE,STYLE_FACTORY_TOTAL_PRICE,STYLE_SHOP_TOTAL_PRICE,REMARKS,ENABLE_FLAG,DELETE_FLAG,VERSION,CREATE_DATE,UPDATE_DATE,CREATE_USER,UPDATE_USER,COVER_PHOTO_PATH FROM s_style_p WHERE SYS_STYLE_ID = '" + styleid + "'");
            DataTable dt = new DataTable();
            try
            {
                String sql = " SELECT\n" +
                    "-- 	*,\n" +
                    " DISTINCT SIZE_CD,\n" +
                    " SUBSTRING_INDEX( SIZE_CD, '-',- 1 ) AS 尺寸\n" +
                    "FROM\n" +
                    "	`a_size_fit_p` \n" +
                    "WHERE\n" +
                    "	FIT_CD = '" + dr["STYLE_FIT_CD"].ToString() + "' \n" +
                    "	AND STYLE_CATEGORY_CD = '" + dr["STYLE_CATEGORY_CD"].ToString() + "' \n" +
                    "	AND SIZEGROUP_CD = '" + dr["STYLE_SIZE_GROUP_CD"] + "';";
                dt = SQLmtm.GetDataTable(sql);
            }
            catch
            {

            }
            return dt;
        }

        /// <summary>
        /// 获得款式所有尺码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable StyleCombobox(DataRow dr, String str)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = " SELECT\n" +
                    "-- 	*,\n" +
                    " DISTINCT SIZE_CD,\n" +
                    " SUBSTRING_INDEX( SIZE_CD, '-',- 1 ) AS 尺寸\n" +
                    "FROM\n" +
                    "	`a_size_fit_p` \n" +
                    "WHERE\n" +
                    "	FIT_CD = '" + dr["STYLE_FIT_CD"].ToString() + "' \n" +
                    "	AND STYLE_CATEGORY_CD = '" + dr["STYLE_CATEGORY_CD"].ToString() + "' \n" +
                    "	AND SIZEGROUP_CD = '" + dr["STYLE_SIZE_GROUP_CD"] + "';";
                dt = SQLmtm.GetDataTable(sql);
            }
            catch
            {

            }
            return dt;
        }

        public static List<款式图片Dto> initStyleInfo(String flag, int page)
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
                " style.COVER_PHOTO_PATH \"styleEntity.coverPhotoPath\", \n" +
                "SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1) AS picn," +
                " CONCAT('https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/',SUBSTRING_INDEX(style.COVER_PHOTO_PATH,'/',-1)) AS picurl \n" +
                "FROM\n" +
                " s_style_p style\n" +
                " LEFT JOIN i_material_p material ON FIND_IN_SET( CAST( material.MATERIAL_ID AS CHAR ), style.SYTLE_FABRIC_ID )\n" +
                " LEFT JOIN a_login_user_p login_user ON login_user.LOGIN_USER_ID = style.CREATE_USER \n" +
                "WHERE\n" +
                " style.DELETE_FLAG = 0 \n" +
                " and style.ENABLE_FLAG = 1 \n" +
                " AND style.STYLE_NAME_CN IS NOT NULL \n" +
                "   AND style.STYLE_KBN != 'STYLE_SOURCE-STYLE_SOURCE_50' \n" +
                " AND ( style.SHOP_ID = 18 OR style.SHOP_ID = 0 )\n" +
                "AND style.STYLE_NAME_CN LIKE '%" + flag + "%'\n" +
                "GROUP BY\n" +
                " style.SYS_STYLE_ID \n" +
                "ORDER BY\n" +
                " style.UPDATE_DATE DESC \n" 
                //+" LIMIT " + ((page - 1) * 42).ToString() + ",42"
                );
            List<款式图片Dto> 款式图片Dtos = new List<款式图片Dto>();
            foreach (DataRow dataRow in dt.Rows)
            {
                款式图片Dtos.Add(new 款式图片Dto(flag, dataRow));
            }

            return 款式图片Dtos;
        }

        /// <summary>
        /// 取款式信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataRow GetDataRowFromOrder(String id)
        {
            String sql = "SELECT\n" +
                "	sp.SYS_STYLE_ID,\n" +
                "	sp.STYLE_NAME_CN,\n" +
                "	imp.MATERIAL_CODE,\n" +
                "	imp.MATERIAL_COMPOSITION,\n" +
                "	sp.STYLE_SHOP_TOTAL_PRICE,\n" +
                "	sp.STYLE_FIT_CD,\n" +
                "	sp.STYLE_CATEGORY_CD,\n" +
                "	sp.STYLE_SIZE_GROUP_CD,sp.STYLE_SIZE_CD,SUBSTRING_INDEX( sp.STYLE_SIZE_CD, '-',- 1 ) AS SIZE\n" +
                "FROM\n" +
                "	s_style_p AS sp\n" +
                "	LEFT JOIN i_material_p imp ON sp.SYTLE_FABRIC_ID = imp.MATERIAL_ID \n" +
                "WHERE\n" +
                "	sp.SYS_STYLE_ID IN ( SELECT op.STYLE_ID FROM o_order_p AS op WHERE ORDER_NO like '%" + id + "%' );";
            return SQLmtm.GetDataRow(sql);
        }

        /// <summary>
        /// 获得最新的styleid
        /// </summary>
        /// <returns></returns>
        public static int GetNewStyleID()
        {
            DataRow drstyle = SQLmtm.GetDataRow("SELECT MAX(SYS_STYLE_ID) SYS_STYLE_ID FROM `s_style_p`");
            return (Convert.ToInt32(drstyle["SYS_STYLE_ID"]) + 1);
        }
    }
}
