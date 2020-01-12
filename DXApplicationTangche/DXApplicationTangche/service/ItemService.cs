using DiaoPaiDaYin;
using DXApplicationTangche.DTO;
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
    /// 设计点服务
    /// </summary>
    public class ItemService
    {
        /// <summary>
        /// 查询默认项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<设计点图片Dto> DefaultItem(String id)
        {
            String sql = "SELECT\n" +
                "	a.ITEM_CD AS 'itemCD',\n" +
                "	a.ITEM_VALUE AS 'itemValue',\n" +
                "	w.UPLOAD_FILE AS picn,\n" +
                "	a.ITEM_NAME_CN AS 'itemNameCN'\n" +
                "FROM\n" +
                "	a_kuanshi_p a\n" +
                "	LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID \n" +
                "WHERE\n" +
                "	a.FILE_ID IS NOT NULL \n" +
                "	AND a.PARENT_ID = '" + id + "';";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<设计点图片Dto> 设计点图片Dtos = new List<设计点图片Dto>();
            foreach (DataRow dr in dt.Rows)
            {
                设计点图片Dtos.Add(new 设计点图片Dto(dr));
            }
            return 设计点图片Dtos;
        }

        /// <summary>
        /// 取得设计点中文名
        /// </summary>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public static String GetNameCN(String itemValue)
        {
            DataRow dr = SQLmtm.GetDataRow("SELECT PROPERTY_NAME_CN FROM a_fit_property_p WHERE PROPERTY_VALUE='" + itemValue + "'");
            if (dr == null)
            {
                return "";
            }
            else
            {
                return dr["PROPERTY_NAME_CN"].ToString();
            }
        }

        /// <summary>
        /// 去设计点信息
        /// </summary>
        /// <param name="itemcd">设计点</param>
        /// <param name="str">模糊查询字段</param>
        /// <returns></returns>
        public static List<设计点图片Dto> GetDesign(String itemcd, String str)
        {
            String sql = "SELECT\n" +
                " a.DESIGN_ID id,\n" +
                " a.STYLE_CATEGORY_CD styleCategoryCD,\n" +
                " a.FILE_ID fileID,\n" +
                " a.ITEM_CD itemCD,\n" +
                " a.ITEM_VALUE itemValue,\n" +
                " a.ITEM_NAME_CN itemNameCN,\n" +
                " file.UPLOAD_FILE \"picn\",\n" +
                " CONCAT( 'shirtmtm.com',file.FILE_PATH, file.UPLOAD_FILE ) \"picurl\",\n" +
                " a.ITEM_NAME_EN itemNameEN,\n" +
                " a.ITEM_NAME_JP itemNameJP,\n" +
                " IFNULL( a.ITEM_COST, 0 ) itemCost,\n" +
                " a.REMARKS remarks,\n" +
                " a.ENABLE_FLAG enableFlag,\n" +
                " a.DELETE_FLAG deleteFlag,\n" +
                " a.HAVETO_FLAG haveToFlag,\n" +
                " a.VERSION version,\n" +
                " a.CREATE_DATE createDate,\n" +
                " a.CREATE_USER \"createBy.id\",\n" +
                " a.UPDATE_USER \"updateBy.id\",\n" +
                " a.ITEM_SORT itemSort,\n" +
                " a.ITEM_CATEGORY_CD itemCategoryCD,\n" +
                " file.FILE_ID \"uploadFile.fileId\",\n" +
                " file.FILE_SOURCE \"uploadFile.fileSource\",\n" +
                " file.MODULE_KBN \"uploadFile.moduleKbn\",\n" +
                " file.FTP_FILE \"uploadFile.ftpFile\",\n" +
                " file.FILE_PATH \"uploadFile.filePath\",\n" +
                " CONCAT( p.FIRST_NAME, p.LAST_NAME ) \"updateBy.firstName\" \n" +
                "FROM\n" +
                " a_designoption_p a\n" +
                " LEFT JOIN a_login_user_p p ON a.UPDATE_USER = p.login_user_id\n" +
                " LEFT JOIN w_upload_file_p file ON a.FILE_ID = file.FILE_ID \n" +
                " LEFT JOIN a_ognization_desgin_r adr ON a.DESIGN_ID = adr.DESGIN_ID \n" +
                "WHERE\n" +
                " a.STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT' and a.DESIGN_ID IN ( SELECT DESGIN_ID FROM a_shop_desgin_r WHERE SHOP_ID = 18 ) \n" +
                " AND a.ITEM_CD='" + itemcd + "'\n" +
                " AND a.DELETE_FLAG = 0 \n" +
                " AND adr.OGNIZATION_ID = 95 \n" +
                " AND (a.ITEM_VALUE LIKE '%" + str + "%' OR a.ITEM_NAME_CN LIKE '%" + str + "%') " +
                "ORDER BY\n" +
                " a.item_sort,\n" +
                " a.UPDATE_DATE DESC";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<设计点图片Dto> 设计点图片dtos = new List<设计点图片Dto>();
            foreach (DataRow dr in dt.Rows)
            {
                设计点图片dtos.Add(new 设计点图片Dto(dr));
            }
            return 设计点图片dtos;
        }

        /// <summary>
        /// build设计点
        /// </summary>
        /// <param name="styleid"></param>
        /// <returns></returns>
        public static List<设计点DTO> Get设计点DTOs(String styleid)
        {
            String sql = "SELECT\n" +
                "	sr.*,\n" +
                "	adp.ITEM_NAME_CN AS OPTION_NAME,\n" +
                "	adp1.ITEM_NAME_CN AS ITEM_NAME \n" +
                "FROM\n" +
                "	s_style_option_r AS sr\n" +
                "	LEFT JOIN a_designoption_p AS adp ON sr.OPTION_VALUE = adp.ITEM_VALUE\n" +
                "	LEFT JOIN a_designoption_p AS adp1 ON sr.ITEM_VALUE = adp1.ITEM_VALUE \n" +
                "WHERE\n" +
                "	sr.SYS_STYLE_ID = '" + styleid + "';";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<设计点DTO> 设计点dtos = new List<设计点DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                设计点dtos.Add(new 设计点DTO(dr));
            }
            return 设计点dtos;
        }
    }
}
