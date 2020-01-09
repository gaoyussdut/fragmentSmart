using DiaoPaiDaYin;
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
" a.DESIGN_ID id,\n" +
" a.STYLE_CATEGORY_CD styleCategoryCD,\n" +
" a.FILE_ID fileID,\n" +
" a.ITEM_CD itemCode,\n" +
" a.ITEM_VALUE itemValue,\n" +
" a.ITEM_NAME_CN itemNameCn,\n" +
" CONCAT( file.FILE_PATH, file.UPLOAD_FILE ) \"picurl\",\n" +
"  file.UPLOAD_FILE \"picn\",\n" +
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
" \n" +
" AND a.DELETE_FLAG = 0 \n" +
" AND adr.OGNIZATION_ID = 95 \n" +
"ORDER BY\n" +
" a.item_sort,\n" +
" a.UPDATE_DATE DESC");
            foreach (DataRow dr in dt.Rows)
            {
                String picurl = dr["picurl"].ToString().Trim();
                if(picurl!="")
                {
                    picurl = "shirtmtm.com" + picurl;
                }
                this.shejidianpiclist.Add(new SheJiDianPic(dr["itemCode"].ToString().Trim(), dr["itemValue"].ToString().Trim(), dr["itemNameCn"].ToString().Trim(), dr["picn"].ToString().Trim(), picurl));
            }
        }

    }
}
