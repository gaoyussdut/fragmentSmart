using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class SheJiDianPicList
    {
        public List<SheJiDianPic> shejidianpiclist = new List<SheJiDianPic>();

        public SheJiDianPicList()
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
"S1.itemCode,\n" +
"s1.itemValue ,\n" +
"s1.itemNameCn,\n" +
"S2.UPLOAD_FILE AS picn,\n" +
"s2.picurl \n" +
"FROM\n" +
"(\n" +
"SELECT\n" +
"	ap.ITEM_VALUE itemValue,\n" +
"	ap.DESIGN_ID id,\n" +
"	CONCAT( ap.ITEM_VALUE, \":\", ap.ITEM_NAME_CN ) itemNameCn,\n" +
"	ap.ITEM_CD itemCode,\n" +
"	adp.ITEM_CD itemParentCode \n" +
"FROM\n" +
"	a_designoption_p ap\n" +
"	LEFT JOIN a_designoption_p adp ON adp.ITEM_VALUE = ap.ITEM_CD\n" +
"	LEFT JOIN a_ognization_desgin_r adr ON ap.DESIGN_ID = adr.DESGIN_ID \n" +
"WHERE\n" +
"	( ap.ITEM_CATEGORY_CD = \"\" OR ap.ITEM_CATEGORY_CD IS NULL ) \n" +
"	AND ap.STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT' \n" +
"	-- AND ap.ITEM_CD = '4SFP' -- AND ap.ITEM_CD IN ( SELECT ap.ITEM_VALUE itemValue FROM a_designoption_p ap WHERE ap.ITEM_CATEGORY_CD ='ITEM_TYPE_CD-10' )\n" +
"	\n" +
"	AND adr.OGNIZATION_ID = 95 \n" +
"	AND ap.ITEM_VALUE IN (\n" +
"	SELECT\n" +
"		ap.ITEM_VALUE itemValue \n" +
"	FROM\n" +
"		a_designoption_p ap \n" +
"	WHERE\n" +
"		ap.DESIGN_ID IN ( SELECT ar.DESGIN_ID FROM a_shop_desgin_r ar WHERE ar.SHOP_ID = 18 ) \n" +
"	) \n" +
"ORDER BY\n" +
"	ap.ITEM_CD,\n" +
"	ap.ITEM_SORT ASC \n" +
") AS s1\n" +
"LEFT JOIN (\n" +
"SELECT\n" +
"	a.ITEM_CD,\n" +
"	a.ITEM_VALUE,\n" +
"	a.ITEM_NAME_CN,\n" +
"	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', w.UPLOAD_FILE ) AS picurl,\n" +
"	w.* \n" +
"FROM\n" +
"	a_designoption_p a\n" +
"	LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID \n" +
"WHERE\n" +
"	a.FILE_ID IS NOT NULL \n" +
") AS s2 ON s1.itemCode = s2.ITEM_CD \n" +
"AND s1.itemValue = s2.ITEM_VALUE");
            foreach (DataRow dr in dt.Rows)
            {
                this.shejidianpiclist.Add(new SheJiDianPic(dr["itemCode"].ToString().Trim(), dr["itemValue"].ToString().Trim(), dr["itemNameCn"].ToString().Trim(), dr["picn"].ToString().Trim(), dr["picurl"].ToString().Trim()));
            }
        }

    }
}
