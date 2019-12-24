using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class MianLiaoPicList
    {
        public List<MianLiaoPic> mianliaopiclist = new List<MianLiaoPic>();

        public MianLiaoPicList()
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
"*,CONCAT(s1.materialCode,':',s1.materialNameCn) AS mianliao,\n" +
"SUBSTRING_INDEX( s1.filePath, '/',- 1 ) AS picn,\n" +
"CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', SUBSTRING_INDEX( s1.filePath, '/',- 1 ) ) AS picurl \n" +
"FROM\n" +
"(\n" +
"SELECT\n" +
"	a.material_id AS \"id\",\n" +
"	a.material_file_id AS \"fileId\",\n" +
"	a.material_name_cn AS \"materialNameCn\",\n" +
"	a.material_name_en AS \"materialNameEn\",\n" +
"	a.material_code AS \"materialCode\",\n" +
"	a.material_use_type AS \"materialUseType\",\n" +
"	a.material_type_cd AS \"materialTypeCd\",\n" +
"	a.material_composition AS \"materialComposition\",\n" +
"	a.material_spec AS \"materialSpec\",\n" +
"	a.material_unit_cd AS \"materialUnitCd\",\n" +
"	a.material_year AS \"materialYear\",\n" +
"	a.material_color AS \"materialColor\",\n" +
"	a.material_season AS \"materialSeason\",\n" +
"	a.remarks AS \"remarks\",\n" +
"	a.material_category AS \"materialStyleCategory\",\n" +
"	a.model_filepath AS \"modelFilepath\",\n" +
"CASE\n" +
"		\n" +
"		WHEN file.FILE_PATH IS NOT NULL \n" +
"		AND file.FILE_PATH != '' THEN\n" +
"			REPLACE ( CONCAT( file.FILE_PATH, file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) ELSE REPLACE ( CONCAT( upload_file.FILE_PATH, upload_file.UPLOAD_FILE ), 'fragsmart-erp', 'fragsmart-mtm' ) \n" +
"			END AS filePath,\n" +
"		a_login_user_p.LAST_NAME AS \"createby.lastName\",\n" +
"		a_login_user_p.FIRST_NAME AS \"createby.firstName\",\n" +
"		IFNULL( s.material_sale_price, 0 ) AS \"materialPrice.materialSalePrice\",\n" +
"		IFNULL( inventory_material.MATERIAL_QUANTITY, 0 ) AS \"inventoryMaterial.materialQuantity\",\n" +
"		a.MATERIAL_LEVEL AS \"materialLevel\",\n" +
"		a.MATERIAL_STYLE AS \"materialStyle\",\n" +
"		a.MATERIAL_WEAVE AS \"materialWeave\",\n" +
"	CASE\n" +
"			\n" +
"			WHEN adp.ITEM_VALUE = \"A_150\" THEN\n" +
"			150 \n" +
"			WHEN adp.ITEM_VALUE = \"B_180\" THEN\n" +
"			180 \n" +
"			WHEN adp.ITEM_VALUE = \"C_240\" THEN\n" +
"			240 \n" +
"			WHEN adp.ITEM_VALUE = \"D_320\" THEN\n" +
"			320 ELSE 0 \n" +
"		END AS \"materiaFacPrice\" \n" +
"	FROM\n" +
"		i_material_p a\n" +
"		LEFT JOIN a_shop_material_r ar ON a.MATERIAL_ID = ar.MATERIAL_ID\n" +
"		LEFT JOIN a_login_user_p a_login_user_p ON a_login_user_p.login_user_id = a.create_user\n" +
"		LEFT JOIN i_material_price_s s ON s.material_id = a.material_id \n" +
"		AND s.SHOP_ID = 18\n" +
"		INNER JOIN i_inventory_material_p inventory_material ON inventory_material.material_id = a.material_id\n" +
"		LEFT JOIN w_upload_file_p file ON a.material_file_id = file.FILE_ID \n" +
"		AND file.FTP_FILE = \"/material\"\n" +
"		LEFT JOIN a_upload_file_p upload_file ON upload_file.FILE_ID = a.MATERIAL_FILE_ID \n" +
"		AND upload_file.FILE_KBN = 0 \n" +
"		AND upload_file.FTP_FILE = \"/material\"\n" +
"		LEFT JOIN a_dict_p adp ON a.MATERIAL_LEVEL = CONCAT( adp.ITEM_CD, \"-\", adp.ITEM_VALUE ) \n" +
"	WHERE\n" +
"		a.delete_flag = 0 \n" +
"		AND a.material_category IN ( 'MATERIAL_CATEGORY-Fabric', 'MATERIAL_CATEGORY-ButtonL', 'MATERIAL_CATEGORY-Suit_Fabric', 'MATERIAL_CATEGORY-Suit_Material' ) \n" +
"		AND ar.SHOP_ID = 18 \n" +
"		AND ( a.material_name_cn LIKE '%%' OR a.material_code LIKE '%%' ) \n" +
"    AND a.material_category ='MATERIAL_CATEGORY-Fabric'\n" +
"	ORDER BY\n" +
"		a.MATERIAL_CATEGORY,\n" +
"		a.MATERIAL_ID \n" +
"	-- LIMIT 50 \n" +
") AS s1");
            foreach (DataRow dr in dt.Rows)
            {
                this.mianliaopiclist.Add(new MianLiaoPic(dr["materialNameCn"].ToString().Trim(),dr["id"].ToString().Trim(),dr["materialCode"].ToString().Trim(),dr["picn"].ToString().Trim(),dr["picurl"].ToString().Trim()));
            }
        }
    }
}
