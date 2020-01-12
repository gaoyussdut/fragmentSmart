using DiaoPaiDaYin;
using DXApplicationTangche.DTO;
using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 面料服务
    /// </summary>
    public class FabricService
    {
        public static List<面料DTO> get面料DTOs(List<String> SYTLE_FABRIC_ID)
        {
            String sql = "SELECT\n" +
                "	id,\n" +
                "	fileId,\n" +
                "	materialNameCn,\n" +
                "	materialNameEn,\n" +
                "	materialCode,\n" +
                "	materialUseType,\n" +
                "	materialTypeCd,\n" +
                "	materialComposition,\n" +
                "	materialSpec,\n" +
                "	materialUnitCd,\n" +
                "	materialYear,\n" +
                "	materialColor,\n" +
                "	materialSeason,\n" +
                "	remarks,\n" +
                "	materialStyleCategory,\n" +
                "	modelFilepath,\n" +
                "	filePath,\n" +
                "	createby_lastName,\n" +
                "	createby_firstName,\n" +
                "	materialPrice_materialSalePrice,\n" +
                "	inventoryMaterial_materialQuantity,\n" +
                "	materialLevel,\n" +
                "	materialStyle,\n" +
                "	materialWeave,\n" +
                "	materiaFacPrice,\n" +
                "	mianliao,\n" +
                "	picn,\n" +
                "	picurl \n" +
                "FROM\n" +
                "	V_MATERIAL_CATEGORY_Fabric \n" +
                "WHERE\n" +
                "	id IN ( '" + String.Join("','", SYTLE_FABRIC_ID) + "' );";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<面料DTO> 面料DTOs = new List<面料DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                面料DTOs.Add(new 面料DTO(dr));
            }
            return 面料DTOs;
        }


        /// <summary>
        /// 所有面料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllMaterial()
        {
            String sql = "SELECT id,materialNameCn,materialCode,materialComposition FROM v_material_category_fabric";
            return SQLmtm.GetDataTable(sql);
        }

        /// <summary>
        /// 根据id取面料信息
        /// </summary>
        /// <param name="SYTLE_FABRIC_ID"></param>
        /// <returns></returns>
        public static DataRow generateMaterialInfo(String SYTLE_FABRIC_ID)
        {
            String sql = "SELECT\n" +
                "	MATERIAL_ID,\n" +
                "	MATERIAL_NAME_CN,\n" +
                "	MATERIAL_COLOR \n" +
                "FROM\n" +
                "	i_material_p \n" +
                "WHERE\n" +
                "	MATERIAL_ID = '" + SYTLE_FABRIC_ID + "'";
            return SQLmtm.GetDataRow(sql);
        }

        /// <summary>
        /// 查询面料
        /// </summary>
        /// <param name="str"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<面料图片Dto> GetMianLiao(String str, int page)
        {
            String sql = "SELECT\n" +
                "	*,CONCAT(s1.materialCode,':',s1.materialNameCn) AS mianliao,\n" +
                "SUBSTRING_INDEX( s1.filePath, '/',- 1 ) AS picn,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( s1.filePath, '/',- 1 ) ) AS picurl \n" +
                "FROM\n" +
                "	(\n" +
                "	SELECT\n" +
                "		a.material_id AS \"id\",\n" +
                "		a.material_file_id AS \"fileId\",\n" +
                "		a.material_name_cn AS \"materialNameCn\",\n" +
                "		a.material_name_en AS \"materialNameEn\",\n" +
                "		a.material_code AS \"materialCode\",\n" +
                "		a.material_use_type AS \"materialUseType\",\n" +
                "		a.material_type_cd AS \"materialTypeCd\",\n" +
                "		a.material_composition AS \"materialComposition\",\n" +
                "		a.material_spec AS \"materialSpec\",\n" +
                "		a.material_unit_cd AS \"materialUnitCd\",\n" +
                "		a.material_year AS \"materialYear\",\n" +
                "		a.material_color AS \"materialColor\",\n" +
                "		a.material_season AS \"materialSeason\",\n" +
                "		a.remarks AS \"remarks\",\n" +
                "		a.material_category AS \"materialStyleCategory\",\n" +
                "		a.model_filepath AS \"modelFilepath\",\n" +
                "	CASE\n" +
                "			\n" +
                "			WHEN file.FILE_PATH IS NOT NULL \n" +
                "			AND file.FILE_PATH != '' THEN\n" +
                "				REPLACE ( CONCAT( file.FILE_PATH, file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) ELSE REPLACE ( CONCAT( upload_file.FILE_PATH, upload_file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) \n" +
                "				END AS filePath,\n" +
                "			a_login_user_p.LAST_NAME AS \"createby_lastName\",\n" +
                "			a_login_user_p.FIRST_NAME AS \"createby_firstName\",\n" +
                "			IFNULL( s.material_sale_price, 0 ) AS \"materialPrice.materialSalePrice\",\n" +
                "			IFNULL( inventory_material.MATERIAL_QUANTITY, 0 ) AS \"inventoryMaterial.materialQuantity\",\n" +
                "			a.MATERIAL_LEVEL AS \"materialLevel\",\n" +
                "			a.MATERIAL_STYLE AS \"materialStyle\",\n" +
                "			a.MATERIAL_WEAVE AS \"materialWeave\",\n" +
                "		CASE\n" +
                "				\n" +
                "				WHEN adp.ITEM_VALUE = \"A_150\" THEN\n" +
                "				150 \n" +
                "				WHEN adp.ITEM_VALUE = \"B_180\" THEN\n" +
                "				180 \n" +
                "				WHEN adp.ITEM_VALUE = \"C_240\" THEN\n" +
                "				240 \n" +
                "				WHEN adp.ITEM_VALUE = \"D_320\" THEN\n" +
                "				320 ELSE 0 \n" +
                "			END AS \"materiaFacPrice\" \n" +
                "		FROM\n" +
                "			i_material_p a\n" +
                "			LEFT JOIN a_shop_material_r ar ON a.MATERIAL_ID = ar.MATERIAL_ID\n" +
                "			LEFT JOIN a_login_user_p a_login_user_p ON a_login_user_p.login_user_id = a.create_user\n" +
                "			LEFT JOIN i_material_price_s s ON s.material_id = a.material_id \n" +
                "			AND s.SHOP_ID = 18\n" +
                "			INNER JOIN i_inventory_material_p inventory_material ON inventory_material.material_id = a.material_id\n" +
                "			LEFT JOIN w_upload_file_p file ON a.material_file_id = file.FILE_ID \n" +
                "			AND file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_upload_file_p upload_file ON upload_file.FILE_ID = a.MATERIAL_FILE_ID \n" +
                "			AND upload_file.FILE_KBN = 0 \n" +
                "			AND upload_file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_dict_p adp ON a.MATERIAL_LEVEL = CONCAT( adp.ITEM_CD, \"-\", adp.ITEM_VALUE ) \n" +
                "		WHERE\n" +
                "			a.delete_flag = 0 \n" +
                "			AND a.material_category IN ( 'MATERIAL_CATEGORY-Fabric', 'MATERIAL_CATEGORY-ButtonL', 'MATERIAL_CATEGORY-Suit_Fabric', 'MATERIAL_CATEGORY-Suit_Material' ) \n" +
                "			AND ar.SHOP_ID = 18 \n" +
                "			AND ( a.material_name_cn LIKE '%" + str + "%' OR a.material_code LIKE '%" + str + "%' ) \n" +
                "           AND a.material_category ='MATERIAL_CATEGORY-Fabric'" +
                "		ORDER BY\n" +
                "			a.MATERIAL_CATEGORY,\n" +
                "			a.MATERIAL_ID \n" +
                " LIMIT " + ((page - 1) * 36).ToString() + ",36" +
                "	) AS s1";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<面料图片Dto> 面料图片dtos = new List<面料图片Dto>();
            foreach (DataRow dr in dt.Rows)
            {
                面料图片dtos.Add(new 面料图片Dto(dr));
            }
            return 面料图片dtos;
        }

        /// <summary>
        /// 查询默认面料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>          
        public static List<面料图片Dto> DefaultMianLiao(String id, String str, int page)
        {
            String sql = "SELECT\n" +
                "	ap.ITEM_CD AS 'materialCode',\n" +
                "	ap.ITEM_VALUE AS 'id',\n" +
                "	ap.ITEM_NAME_CN AS 'mianliao',\n" +
                "	SUBSTRING_INDEX( s1.filePath, '/',- 1 ) AS picn,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( s1.filePath, '/',- 1 ) ) AS picurl \n" +
                "FROM\n" +
                "	a_kuanshi_p AS ap\n" +
                "	LEFT JOIN (\n" +
                "	SELECT\n" +
                "		a.material_id AS \"id\",\n" +
                "		a.material_file_id AS \"fileId\",\n" +
                "		a.material_name_cn AS \"materialNameCn\",\n" +
                "		a.material_name_en AS \"materialNameEn\",\n" +
                "		a.material_code AS \"materialCode\",\n" +
                "		a.material_use_type AS \"materialUseType\",\n" +
                "		a.material_type_cd AS \"materialTypeCd\",\n" +
                "		a.material_composition AS \"materialComposition\",\n" +
                "		a.material_spec AS \"materialSpec\",\n" +
                "		a.material_unit_cd AS \"materialUnitCd\",\n" +
                "		a.material_year AS \"materialYear\",\n" +
                "		a.material_color AS \"materialColor\",\n" +
                "		a.material_season AS \"materialSeason\",\n" +
                "		a.remarks AS \"remarks\",\n" +
                "		a.material_category AS \"materialStyleCategory\",\n" +
                "		a.model_filepath AS \"modelFilepath\",\n" +
                "	CASE\n" +
                "			\n" +
                "			WHEN file.FILE_PATH IS NOT NULL \n" +
                "			AND file.FILE_PATH != '' THEN\n" +
                "				REPLACE ( CONCAT( file.FILE_PATH, file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) ELSE REPLACE ( CONCAT( upload_file.FILE_PATH, upload_file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) \n" +
                "				END AS filePath,\n" +
                "			a_login_user_p.LAST_NAME AS \"createby.lastName\",\n" +
                "			a_login_user_p.FIRST_NAME AS \"createby.firstName\",\n" +
                "			IFNULL( s.material_sale_price, 0 ) AS \"materialPrice.materialSalePrice\",\n" +
                "			IFNULL( inventory_material.MATERIAL_QUANTITY, 0 ) AS \"inventoryMaterial.materialQuantity\",\n" +
                "			a.MATERIAL_LEVEL AS \"materialLevel\",\n" +
                "			a.MATERIAL_STYLE AS \"materialStyle\",\n" +
                "			a.MATERIAL_WEAVE AS \"materialWeave\",\n" +
                "		CASE\n" +
                "				\n" +
                "				WHEN adp.ITEM_VALUE = \"A_150\" THEN\n" +
                "				150 \n" +
                "				WHEN adp.ITEM_VALUE = \"B_180\" THEN\n" +
                "				180 \n" +
                "				WHEN adp.ITEM_VALUE = \"C_240\" THEN\n" +
                "				240 \n" +
                "				WHEN adp.ITEM_VALUE = \"D_320\" THEN\n" +
                "				320 ELSE 0 \n" +
                "			END AS \"materiaFacPrice\" \n" +
                "		FROM\n" +
                "			i_material_p a\n" +
                "			LEFT JOIN a_shop_material_r ar ON a.MATERIAL_ID = ar.MATERIAL_ID\n" +
                "			LEFT JOIN a_login_user_p a_login_user_p ON a_login_user_p.login_user_id = a.create_user\n" +
                "			LEFT JOIN i_material_price_s s ON s.material_id = a.material_id \n" +
                "			AND s.SHOP_ID = 18\n" +
                "			INNER JOIN i_inventory_material_p inventory_material ON inventory_material.material_id = a.material_id\n" +
                "			LEFT JOIN w_upload_file_p file ON a.material_file_id = file.FILE_ID \n" +
                "			AND file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_upload_file_p upload_file ON upload_file.FILE_ID = a.MATERIAL_FILE_ID \n" +
                "			AND upload_file.FILE_KBN = 0 \n" +
                "			AND upload_file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_dict_p adp ON a.MATERIAL_LEVEL = CONCAT( adp.ITEM_CD, \"-\", adp.ITEM_VALUE ) \n" +
                "		WHERE\n" +
                "			a.delete_flag = 0 \n" +
                "			AND a.material_category IN ( 'MATERIAL_CATEGORY-Fabric', 'MATERIAL_CATEGORY-ButtonL', 'MATERIAL_CATEGORY-Suit_Fabric', 'MATERIAL_CATEGORY-Suit_Material' ) \n" +
                "			AND ar.SHOP_ID = 18 \n" +
                "			AND ( a.material_name_cn LIKE '%" + str + "%' OR a.material_code LIKE '%" + str + "%' ) \n" +
                "			AND a.material_category = 'MATERIAL_CATEGORY-Fabric' \n" +
                "		ORDER BY\n" +
                "			a.MATERIAL_CATEGORY,\n" +
                "			a.MATERIAL_ID \n" +
                "		) AS s1 ON ap.ITEM_VALUE = s1.id \n" +
                "	WHERE\n" +
                "	ap.PARENT_ID IN ( SELECT id FROM a_kuanshi_p WHERE STYLEID = '" + id + "' AND ITEM_VALUE = 'mianliaoid' ) \n" +
                "	AND ITEM_NAME_CN LIKE '%" + str + "%' " +
                " LIMIT " + ((page - 1) * 36).ToString() + ",36";
            DataTable dt = SQLmtm.GetDataTable(sql);
            List<面料图片Dto> 面料图片dtos = new List<面料图片Dto>();
            foreach (DataRow dr in dt.Rows)
            {
                面料图片dtos.Add(new 面料图片Dto(dr));
            }
            return 面料图片dtos;
        }

        /// <summary>
        /// 获取面料图片路径
        /// </summary>
        /// <param name="mlid"></param>
        /// <returns></returns>
        public static String GetMianLiaoFilePath(String mlid)
        {
            String sql = "SELECT\n" +
                "	*,CONCAT(s1.materialCode,':',s1.materialNameCn) AS mianliao,\n" +
                "SUBSTRING_INDEX( s1.filePath, '/',- 1 ) AS picn,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( s1.filePath, '/',- 1 ) ) AS picurl \n" +
                "FROM\n" +
                "	(\n" +
                "	SELECT\n" +
                "		a.material_id AS \"id\",\n" +
                "		a.material_file_id AS \"fileId\",\n" +
                "		a.material_name_cn AS \"materialNameCn\",\n" +
                "		a.material_name_en AS \"materialNameEn\",\n" +
                "		a.material_code AS \"materialCode\",\n" +
                "		a.material_use_type AS \"materialUseType\",\n" +
                "		a.material_type_cd AS \"materialTypeCd\",\n" +
                "		a.material_composition AS \"materialComposition\",\n" +
                "		a.material_spec AS \"materialSpec\",\n" +
                "		a.material_unit_cd AS \"materialUnitCd\",\n" +
                "		a.material_year AS \"materialYear\",\n" +
                "		a.material_color AS \"materialColor\",\n" +
                "		a.material_season AS \"materialSeason\",\n" +
                "		a.remarks AS \"remarks\",\n" +
                "		a.material_category AS \"materialStyleCategory\",\n" +
                "		a.model_filepath AS \"modelFilepath\",\n" +
                "	CASE\n" +
                "			\n" +
                "			WHEN file.FILE_PATH IS NOT NULL \n" +
                "			AND file.FILE_PATH != '' THEN\n" +
                "				REPLACE ( CONCAT( file.FILE_PATH, file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) ELSE REPLACE ( CONCAT( upload_file.FILE_PATH, upload_file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) \n" +
                "				END AS filePath,\n" +
                "			a_login_user_p.LAST_NAME AS \"createby.lastName\",\n" +
                "			a_login_user_p.FIRST_NAME AS \"createby.firstName\",\n" +
                "			IFNULL( s.material_sale_price, 0 ) AS \"materialPrice.materialSalePrice\",\n" +
                "			IFNULL( inventory_material.MATERIAL_QUANTITY, 0 ) AS \"inventoryMaterial.materialQuantity\",\n" +
                "			a.MATERIAL_LEVEL AS \"materialLevel\",\n" +
                "			a.MATERIAL_STYLE AS \"materialStyle\",\n" +
                "			a.MATERIAL_WEAVE AS \"materialWeave\",\n" +
                "		CASE\n" +
                "				\n" +
                "				WHEN adp.ITEM_VALUE = \"A_150\" THEN\n" +
                "				150 \n" +
                "				WHEN adp.ITEM_VALUE = \"B_180\" THEN\n" +
                "				180 \n" +
                "				WHEN adp.ITEM_VALUE = \"C_240\" THEN\n" +
                "				240 \n" +
                "				WHEN adp.ITEM_VALUE = \"D_320\" THEN\n" +
                "				320 ELSE 0 \n" +
                "			END AS \"materiaFacPrice\" \n" +
                "		FROM\n" +
                "			i_material_p a\n" +
                "			LEFT JOIN a_shop_material_r ar ON a.MATERIAL_ID = ar.MATERIAL_ID\n" +
                "			LEFT JOIN a_login_user_p a_login_user_p ON a_login_user_p.login_user_id = a.create_user\n" +
                "			LEFT JOIN i_material_price_s s ON s.material_id = a.material_id \n" +
                "			AND s.SHOP_ID = 18\n" +
                "			INNER JOIN i_inventory_material_p inventory_material ON inventory_material.material_id = a.material_id\n" +
                "			LEFT JOIN w_upload_file_p file ON a.material_file_id = file.FILE_ID \n" +
                "			AND file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_upload_file_p upload_file ON upload_file.FILE_ID = a.MATERIAL_FILE_ID \n" +
                "			AND upload_file.FILE_KBN = 0 \n" +
                "			AND upload_file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_dict_p adp ON a.MATERIAL_LEVEL = CONCAT( adp.ITEM_CD, \"-\", adp.ITEM_VALUE ) \n" +
                "		WHERE\n" +
                "			a.delete_flag = 0 \n" +
                "			AND a.material_category IN ( 'MATERIAL_CATEGORY-Fabric', 'MATERIAL_CATEGORY-ButtonL', 'MATERIAL_CATEGORY-Suit_Fabric', 'MATERIAL_CATEGORY-Suit_Material' ) \n" +
                "			AND ar.SHOP_ID = 18  AND a.MATERIAL_ID ='" + mlid + "'\n" +
                //"			AND ( a.material_name_cn LIKE '%" + mlname + "%' OR a.material_code LIKE '%" + mlname + "%' ) \n" +
                "           AND a.material_category ='MATERIAL_CATEGORY-Fabric'" +
                "		ORDER BY\n" +
                "			a.MATERIAL_CATEGORY,\n" +
                "			a.MATERIAL_ID \n" +
                "	) AS s1";

            return @"pic\" + SQLmtm.GetDataRow(sql)["picn"].ToString().Trim();
            //SQLmtm.GetDataRow(sql)["picn"].ToString();
        }

        /// <summary>
        /// 获取面料图片
        /// </summary>
        /// <param name="mlid"></param>
        /// <returns></returns>
        public static Image GetMianLiaoFile(String mlid)
        {
            return Image.FromFile(GetMianLiaoFilePath(mlid));
        }

        /// <summary>
        /// 根据面料id查询面料CD
        /// </summary>
        /// <param name="mlid"></param>
        /// <returns></returns>
        public static String GetMianLiaoCD(String mlid, String tab)
        {
            String sql = "SELECT\n" +
                "	*,CONCAT(s1.materialCode,':',s1.materialNameCn) AS mianliao,\n" +
                "SUBSTRING_INDEX( s1.filePath, '/',- 1 ) AS picn,s1.materialCode,s1.materialComposition,\n" +
                "	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( s1.filePath, '/',- 1 ) ) AS picurl \n" +
                "FROM\n" +
                "	(\n" +
                "	SELECT\n" +
                "		a.material_id AS \"id\",\n" +
                "		a.material_file_id AS \"fileId\",\n" +
                "		a.material_name_cn AS \"materialNameCn\",\n" +
                "		a.material_name_en AS \"materialNameEn\",\n" +
                "		a.material_code AS \"materialCode\",\n" +
                "		a.material_use_type AS \"materialUseType\",\n" +
                "		a.material_type_cd AS \"materialTypeCd\",\n" +
                "		a.material_composition AS \"materialComposition\",\n" +
                "		a.material_spec AS \"materialSpec\",\n" +
                "		a.material_unit_cd AS \"materialUnitCd\",\n" +
                "		a.material_year AS \"materialYear\",\n" +
                "		a.material_color AS \"materialColor\",\n" +
                "		a.material_season AS \"materialSeason\",\n" +
                "		a.remarks AS \"remarks\",\n" +
                "		a.material_category AS \"materialStyleCategory\",\n" +
                "		a.model_filepath AS \"modelFilepath\",\n" +
                "	CASE\n" +
                "			\n" +
                "			WHEN file.FILE_PATH IS NOT NULL \n" +
                "			AND file.FILE_PATH != '' THEN\n" +
                "				REPLACE ( CONCAT( file.FILE_PATH, file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) ELSE REPLACE ( CONCAT( upload_file.FILE_PATH, upload_file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) \n" +
                "				END AS filePath,\n" +
                "			a_login_user_p.LAST_NAME AS \"createby.lastName\",\n" +
                "			a_login_user_p.FIRST_NAME AS \"createby.firstName\",\n" +
                "			IFNULL( s.material_sale_price, 0 ) AS \"materialPrice.materialSalePrice\",\n" +
                "			IFNULL( inventory_material.MATERIAL_QUANTITY, 0 ) AS \"inventoryMaterial.materialQuantity\",\n" +
                "			a.MATERIAL_LEVEL AS \"materialLevel\",\n" +
                "			a.MATERIAL_STYLE AS \"materialStyle\",\n" +
                "			a.MATERIAL_WEAVE AS \"materialWeave\",\n" +
                "		CASE\n" +
                "				\n" +
                "				WHEN adp.ITEM_VALUE = \"A_150\" THEN\n" +
                "				150 \n" +
                "				WHEN adp.ITEM_VALUE = \"B_180\" THEN\n" +
                "				180 \n" +
                "				WHEN adp.ITEM_VALUE = \"C_240\" THEN\n" +
                "				240 \n" +
                "				WHEN adp.ITEM_VALUE = \"D_320\" THEN\n" +
                "				320 ELSE 0 \n" +
                "			END AS \"materiaFacPrice\" \n" +
                "		FROM\n" +
                "			i_material_p a\n" +
                "			LEFT JOIN a_shop_material_r ar ON a.MATERIAL_ID = ar.MATERIAL_ID\n" +
                "			LEFT JOIN a_login_user_p a_login_user_p ON a_login_user_p.login_user_id = a.create_user\n" +
                "			LEFT JOIN i_material_price_s s ON s.material_id = a.material_id \n" +
                "			AND s.SHOP_ID = 18\n" +
                "			INNER JOIN i_inventory_material_p inventory_material ON inventory_material.material_id = a.material_id\n" +
                "			LEFT JOIN w_upload_file_p file ON a.material_file_id = file.FILE_ID \n" +
                "			AND file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_upload_file_p upload_file ON upload_file.FILE_ID = a.MATERIAL_FILE_ID \n" +
                "			AND upload_file.FILE_KBN = 0 \n" +
                "			AND upload_file.FTP_FILE = \"/material\"\n" +
                "			LEFT JOIN a_dict_p adp ON a.MATERIAL_LEVEL = CONCAT( adp.ITEM_CD, \"-\", adp.ITEM_VALUE ) \n" +
                "		WHERE\n" +
                "			a.delete_flag = 0 \n" +
                "			AND a.material_category IN ( 'MATERIAL_CATEGORY-Fabric', 'MATERIAL_CATEGORY-ButtonL', 'MATERIAL_CATEGORY-Suit_Fabric', 'MATERIAL_CATEGORY-Suit_Material' ) \n" +
                "			AND ar.SHOP_ID = 18  AND a.MATERIAL_ID ='" + mlid + "'\n" +
                //"			AND ( a.material_name_cn LIKE '%" + mlname + "%' OR a.material_code LIKE '%" + mlname + "%' ) \n" +
                "           AND a.material_category ='MATERIAL_CATEGORY-Fabric'" +
                "		ORDER BY\n" +
                "			a.MATERIAL_CATEGORY,\n" +
                "			a.MATERIAL_ID \n" +
                "	) AS s1";
            if (tab == "cd")
            {
                return SQLmtm.GetDataRow(sql)["materialCode"].ToString();
            }
            else
            {
                return SQLmtm.GetDataRow(sql)["materialComposition"].ToString();
            }
        }
    }
}
