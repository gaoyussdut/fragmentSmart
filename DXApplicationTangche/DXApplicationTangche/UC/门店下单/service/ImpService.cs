using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DiaoPaiDaYin;
using DXApplicationTangche;
using DXApplicationTangche.UC.门店下单.form;
using DXApplicationTangche.UC.门店下单.DTO;

namespace mendian
{
    class ImpService
    {
        public static void generateOrderSytleInfo(OrderDto orderDto)
        {
            String sql = "SELECT\n" +
                "	SYS_STYLE_ID,\n" +
                "	STYLE_SIZE_CD,\n" +
                "	STYLE_NAME_CN,\n" +
                "	SYTLE_YEAR,\n" +
                "	( CASE `s_style_p`.`SYTLE_SEASON` WHEN 'SEASON-SEASON_10' THEN '春季' WHEN 'SEASON-SEASON_20' THEN '秋季' ELSE `s_style_p`.`SYTLE_SEASON` END ) AS `SYTLE_SEASON`,\n" +
                "	( CASE `s_style_p`.`STYLE_PUBLISH_CATEGORY_CD` WHEN 'PUBLISH_STYLE_CATEGORY-MShirt' THEN '男士衬衫' WHEN 'PUBLISH_STYLE_CATEGORY-WShirt' THEN '女式衬衫' ELSE `s_style_p`.`STYLE_PUBLISH_CATEGORY_CD` END ) AS `STYLE_PUBLISH_CATEGORY_CD` \n" +
                "FROM\n" +
                "	s_style_p \n" +
                "WHERE\n" +
                "	SYS_STYLE_ID = '" + orderDto.style_id + "'";

            DataRow dataRow = SQLmtm.GetDataRow(sql);
            orderDto.STYLE_SIZE_CD = dataRow["STYLE_SIZE_CD"].ToString();
            orderDto.STYLE_NAME_CN = dataRow["STYLE_NAME_CN"].ToString();
            orderDto.SYTLE_YEAR = dataRow["SYTLE_YEAR"].ToString();
            orderDto.SYTLE_SEASON = dataRow["SYTLE_SEASON"].ToString();
            orderDto.STYLE_PUBLISH_CATEGORY_CD = dataRow["STYLE_PUBLISH_CATEGORY_CD"].ToString();

            sql = "SELECT\n" +
                "	MATERIAL_ID,\n" +
                "	MATERIAL_NAME_CN,\n" +
                "	MATERIAL_COLOR \n" +
                "FROM\n" +
                "	i_material_p \n" +
                "WHERE\n" +
                "	MATERIAL_ID = '" + orderDto.SYTLE_FABRIC_ID + "'";
            dataRow = SQLmtm.GetDataRow(sql);
            orderDto.MATERIAL_NAME_CN = dataRow["MATERIAL_NAME_CN"].ToString();
            orderDto.MATERIAL_COLOR = dataRow["MATERIAL_COLOR"].ToString();
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
        public static DataTable StyleCombobox(String str)
        {
            DataRow dr = SQLmtm.GetDataRow("SELECT * FROM s_style_p WHERE SYS_STYLE_ID = '" + str + "'");
            DataTable dt = new DataTable();
            try
            {
                dt = SQLmtm.GetDataTable(" SELECT\n" +
"-- 	*,\n" +
" DISTINCT SIZE_CD,\n" +
" SUBSTRING_INDEX( SIZE_CD, '-',- 1 ) AS 尺寸\n" +
"FROM\n" +
"	`a_size_fit_p` \n" +
"WHERE\n" +
"	FIT_CD = '" + dr["STYLE_FIT_CD"].ToString() + "' \n" +
"	AND STYLE_CATEGORY_CD = '" + dr["STYLE_CATEGORY_CD"].ToString() + "' \n" +
"	AND SIZEGROUP_CD = '" + dr["STYLE_SIZE_GROUP_CD"] + "';");
            }
            catch
            {

            }
            return dt;
        }
        /// <summary>
        /// 获取选择的尺码的尺寸
        /// </summary>
        /// <param name="size"></param>
        /// <param name="styleid"></param>
        /// <returns></returns>
        public static DataTable StyleValue(String size, String styleid, DataTable stylesizedt)
        {
            DataRow st = SQLmtm.GetDataRow("SELECT * FROM s_style_p WHERE SYS_STYLE_ID = '" + styleid + "'");
            DataTable dt = new DataTable();
            foreach (DataRow dr in stylesizedt.Rows)
            {
                if (dr["尺寸"].ToString() == size)
                {
                    dt = SQLmtm.GetDataTable("SELECT\n" +
"	*,\n" +
"	SUBSTRING_INDEX( SIZE_CD, '-',- 1 ) \n" +
"FROM\n" +
"	`a_size_fit_p` \n" +
"WHERE\n" +
"	FIT_CD = '" + st["STYLE_FIT_CD"].ToString() + "' \n" +
"	AND STYLE_CATEGORY_CD = '" + st["STYLE_CATEGORY_CD"].ToString() + "' \n" +
"	AND SIZEGROUP_CD = '" + st["STYLE_SIZE_GROUP_CD"] + "' \n" +
"	AND SIZE_CD = '" + dr["SIZE_CD"].ToString() + "';");
                    break;
                }
            }
            return dt;
        }
        /// <summary>
        /// 获得STYLE_SIZE_CD
        /// </summary>
        /// <param name="size"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static String SizeCD(String size, DataTable dt)
        {
            string str = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["尺寸"].ToString() == size)
                {
                    str = dr["SIZE_CD"].ToString();
                    break;
                }

            }
            return str;
        }
        /// <summary>
        /// 字符串按指定长度换行
        /// </summary>
        /// <param name="conten">字符串</param>
        /// <param name="start">指定长度</param>
        /// <param name="sSymbol">换行符</param>
        /// <returns>按指定长度换行后的字符串</returns>
        public static String SqritBySymbol(string conten, int start, string sSymbol)
        {
            string str = "";
            char[] param = conten.ToCharArray();
            if (param.Length > 0)
            {
                if (param.Length > start)
                {
                    int j = 1;
                    for (int i = 0; i < param.Length; i++)
                    {
                        str += param[i];
                        if (i == (start * j))
                        {
                            j++;
                            str = str + sSymbol;
                        }
                    }
                }
            }
            return str;
        }
        /// <summary>
        /// 将新建客户未填项设为0
        /// </summary>
        /// <param name="cc"></param>
        public static void customerZero(CreateCustomer cc)
        {
            cc.jiankuan.Text = cc.jiankuan.Text.Trim() == "" ? "0" : cc.jiankuan.Text;
            cc.yaowei.Text = cc.yaowei.Text.Trim() == "" ? "0" : cc.yaowei.Text;
            cc.tunwei.Text = cc.tunwei.Text.Trim() == "" ? "0" : cc.tunwei.Text;
            cc.shenchang.Text = cc.shenchang.Text.Trim() == "" ? "0" : cc.shenchang.Text;
            cc.lingwei.Text = cc.lingwei.Text.Trim() == "" ? "0" : cc.lingwei.Text;
            cc.wanwei.Text = cc.wanwei.Text.Trim() == "" ? "0" : cc.wanwei.Text;
            cc.xiuchang.Text = cc.xiuchang.Text.Trim() == "" ? "0" : cc.xiuchang.Text;
            cc.shangbixiufei.Text = cc.shangbixiufei.Text.Trim() == "" ? "0" : cc.shangbixiufei.Text;
        }
        /// <summary>
        /// 保存尺寸a_customer_fit_value_r,s_style_fit_r插入数据
        /// </summary>
        /// <param name="sTYLE_FIT_ID"></param>
        /// <param name="customername"></param>
        /// <param name="fitv"></param>
        /// <param name="ftvl"></param>
        /// <param name="inftvl"></param>
        /// <param name="outftvl"></param>
        public static void insertFit_R(int sTYLE_FIT_ID, string customername, Fit_ValueDTo fitv, String ftvl, String inftvl, String outftvl)
        {
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE"
                                                                                    ,"IN_VALUE","OUT_VALUE","STATUS","DELETE_FLAG","CUSTOMER_COUNT_ID"},
new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString() , customername ,
                "SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,",
                "CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19,",
                ftvl,"CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19,",
                inftvl,outftvl,"0","0",CreateCustomer.customer_countid.ToString()});
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", "SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003" ,
                   "CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19",
                   ftvl,"CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19",
                   "0","1","46",inftvl,outftvl});

        }
        /// <summary>
        /// s_style_p插入数据
        /// </summary>
        /// <param name="change"></param>
        /// <param name="uc"></param>
        public static void insertS_Style_P(Change change, UC款式卡片 uc)
        {
            Change.sTYLE_SIZE_CD = ImpService.SizeCD(change.chicun01.Text.Trim(), Change.stylesizedt);
            //DataRow drstyle = SQLmtm.GetDataRow("SELECT MAX(SYS_STYLE_ID) SYS_STYLE_ID FROM `s_style_p`");
            //Change.styleid = Convert.ToInt32(drstyle["SYS_STYLE_ID"]);
            //Change.styleid++;
            SQLmtm.DoInsert("s_style_p", new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" },
    new string[] { Change.styleid.ToString(), "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", uc.sTYLE_CATEGORY_CD, MianLiaochoose.mianliaoid, uc.sTYLE_SIZE_GROUP_CD, Change.sTYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", uc.kuanshimingcheng, "", CreateCustomer.customer_countid.ToString(), uc.sTYLE_FIT_CD, uc.kuanshiid, uc.sTYLE_DRESS_CATEGORY, uc.sTYLE_DESIGN_TYPE, uc.sTYLE_PUBLISH_CATEGORY_CD, uc.sYTLE_YEAR, uc.sYTLE_SEASON });
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="picUrl">图片Http地址</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns></returns>
        public static bool DownloadPicture(string picUrl, string savePath, int timeOut)
        {
            //savePath = @"pic\" + savePath + ".jpg";
            bool value = false;
            WebResponse response = null;
            Stream stream = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(picUrl);
                if (timeOut != -1) request.Timeout = timeOut;
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/"))
                    value = SaveBinaryFile(response, savePath);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            return value;
        }
        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (File.Exists(savePath)) File.Delete(savePath);
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }
            return value;
        }

        /// <summary>
        ///比较两个list，取出存在menuOneList中，但不存在resourceList中的数据，差异数据放入differentList
        /// </summary>
        /// <param name="newlist">新list</param>
        /// <param name="oldlist">旧list</param>
        public static List<StylePic> listCompare(List<StylePic> newlist, List<StylePic> oldlist)
        {
            List<StylePic> differentList = new List<StylePic>();
            int i = 0;
            foreach (StylePic nl in newlist)
            {
                i = 0;
                foreach (StylePic ol in oldlist)
                {
                    if (nl.styleCd != ol.styleCd || nl.styleId != ol.styleId || nl.stylePicN != ol.stylePicN || nl.stylePicURL != ol.stylePicURL)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }
        /// <summary>
        /// 下载没有的款式图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadDifferentPic(List<StylePic> difflist)
        {
            foreach (StylePic sp in difflist)
            {
                if (sp.stylePicN != "")
                {
                    try
                    {
                        DownloadPicture(sp.stylePicURL, @"pic\" + sp.stylePicN, -1);
                    }
                    catch
                    {

                    }
                }
            }
        }
        /// <summary>
        /// 比较面料图片
        /// </summary>
        /// <param name="newlist"></param>
        /// <param name="oldlist"></param>
        /// <returns></returns>
        public static List<MianLiaoPic> mianliaolistCompare(List<MianLiaoPic> newlist, List<MianLiaoPic> oldlist)
        {
            List<MianLiaoPic> differentList = new List<MianLiaoPic>();
            int i = 0;
            foreach (MianLiaoPic nl in newlist)
            {
                i = 0;
                foreach (MianLiaoPic ol in oldlist)
                {
                    if (nl.mianliao != ol.mianliao || nl.mianliaoid != ol.mianliaoid || nl.mianliaocd != ol.mianliaocd || nl.picn != ol.picn || nl.picurl != ol.picurl)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }
        /// <summary>
        /// 下载没有的面料图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadMianliaoPic(List<MianLiaoPic> difflist)
        {
            foreach (MianLiaoPic sp in difflist)
            {
                if (sp.picn != "")
                {
                    try
                    {
                        DownloadPicture(sp.picurl, @"pic\" + sp.picn, -1);
                    }
                    catch
                    {

                    }
                }
            }
        }
        /// <summary>
        /// 比较设计点图片
        /// </summary>
        /// <param name="newlist"></param>
        /// <param name="oldlist"></param>
        /// <returns></returns>
        public static List<SheJiDianPic> shejidianlistCompare(List<SheJiDianPic> newlist, List<SheJiDianPic> oldlist)
        {
            List<SheJiDianPic> differentList = new List<SheJiDianPic>();
            int i = 0;
            foreach (SheJiDianPic nl in newlist)
            {
                i = 0;
                foreach (SheJiDianPic ol in oldlist)
                {
                    if (nl.itemCode != ol.itemCode || nl.itemValue != ol.itemValue || nl.itemNameCn != ol.itemNameCn || nl.picn != ol.picn || nl.picurl != ol.picurl)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }
        /// <summary>
        /// 下载没有的设计点图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadSheJiDianPic(List<SheJiDianPic> difflist)
        {
            foreach (SheJiDianPic sjdp in difflist)
            {
                if (sjdp.picn != "")
                {
                    try
                    {
                        DownloadPicture(sjdp.picurl, @"pic\" + sjdp.picn, -1);
                    }
                    catch
                    {

                    }
                }
            }
        }
        /// <summary>
        /// 查询面料
        /// </summary>
        /// <param name="str"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static DataTable GetMianLiao(String str, int page)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
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
"			AND ar.SHOP_ID = 18 \n" +
"			AND ( a.material_name_cn LIKE '%" + str + "%' OR a.material_code LIKE '%" + str + "%' ) \n" +
"           AND a.material_category ='MATERIAL_CATEGORY-Fabric'" +
"		ORDER BY\n" +
"			a.MATERIAL_CATEGORY,\n" +
"			a.MATERIAL_ID \n" +
" LIMIT " + ((page - 1) * 36).ToString() + ",36" +
"	) AS s1");
            return dt;
        }

        private static PanelLocition panelLocition;
        private static int height = 0;
        private static int width = 0;
        /// <summary>
        /// 动态加载尺寸控件
        /// </summary>
        /// <param name="change"></param>
        /// <param name="sc"></param>
        public static void LoadChiCunCard(Change change, UC款式卡片 sc)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
" sp.FIT_ITEM_VALUE,\n" +
" property.PROPERTY_CD propertyCd,\n" +
"/*量体属性CD*/\n" +
"property.PROPERTY_VALUE propertyValue,\n" +
"/*量体VALUE*/\n" +
" sp.ITEM_IN_FROM propertyInFrom,\n" +
"/*量体属性值可增加范围从*/\n" +
" sp.ITEM_IN_TO propertyInTo,\n" +
"/*量体属性值可增加范围到*/\n" +
" sp.ITEM_OUT_FROM propertyOutFrom,\n" +
"/*量体属性值可缩减范围从*/\n" +
" sp.ITEM_OUT_TO propertyOutTo,\n" +
"/*量体属性值可缩减范围到*/\n" +
" property.PROPERTY_NAME_CN propertyNameCn,\n" +
"/*量体属性中文名称*/\n" +
" property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
"/*0-非净量体，1-净量体*/\n" +
" property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
" sp.ITEM_SORT,\n" +
" sp.ITEM_CD,\n" +
" sp.ITEM_VALUE\n" +
"FROM\n" +
" a_fit_property_p property\n" +
" LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
" AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
"WHERE\n" +
" property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + sc.sTYLE_CATEGORY_CD + "' ) \n" +
" AND property.DEL_FLG = 0 \n" +
"  AND sp.FIT_CD = '" + sc.sTYLE_FIT_CD + "'  /*款式*/\n" +
" AND sp.SIZEGROUP_CD = '" + sc.sTYLE_SIZE_GROUP_CD + "' \n" +
"-- AND sp.SIZE_CD = '" + sc.sTYLE_SIZE_CD + "'   /*尺码*/\n" +
" AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
" AND sp.ENABLE_FLAG = 1 \n" +
" AND property.FIT_FLAG = 1 \n" +
" AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
"GROUP BY property.PROPERTY_VALUE  \n" +
"ORDER BY\n" +
" -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
" sp.ITEM_SORT ASC");
            //change.panel3.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(change.panel4.Width, change.panel4.Height, dt.Rows.Count);
            UC尺寸头 hhh = new UC尺寸头();
            ImpService.generateUserControl(hhh, i);
            change.panel4.Controls.Add(hhh);
            i++;
            foreach (DataRow dr in dt.Rows)
            {
                UC尺寸卡片 ccc = new UC尺寸卡片(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), change);
                ImpService.generateUserControl(ccc, i);
                change.panel4.Controls.Add(ccc);//将控件加入panel                
                i++;
            }
            //DataTable ddt=SQLmtm.GetDataTable("")
            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
"	*,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
"FROM\n" +
"	a_customer_fit_r ar\n" +
"	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
"WHERE\n" +
"	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["pv1"].ToString() == c.iTEM_VALUE || dr["pv2"].ToString() == c.iTEM_VALUE)
                        {
                            c.kehu.Text = dr["FIT_VALUE"].ToString();
                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 修改款式尺寸动态加载
        /// </summary>
        /// <param name="form"></param>
        //        public static void ReviseLoadChiCunCard(ReviseStyle form)
        //        {
        //            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
        //" sp.FIT_ITEM_VALUE,\n" +
        //" property.PROPERTY_CD propertyCd,\n" +
        //"/*量体属性CD*/\n" +
        //"property.PROPERTY_VALUE propertyValue,\n" +
        //"/*量体VALUE*/\n" +
        //" sp.ITEM_IN_FROM propertyInFrom,\n" +
        //"/*量体属性值可增加范围从*/\n" +
        //" sp.ITEM_IN_TO propertyInTo,\n" +
        //"/*量体属性值可增加范围到*/\n" +
        //" sp.ITEM_OUT_FROM propertyOutFrom,\n" +
        //"/*量体属性值可缩减范围从*/\n" +
        //" sp.ITEM_OUT_TO propertyOutTo,\n" +
        //"/*量体属性值可缩减范围到*/\n" +
        //" property.PROPERTY_NAME_CN propertyNameCn,\n" +
        //"/*量体属性中文名称*/\n" +
        //" property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
        //"/*0-非净量体，1-净量体*/\n" +
        //" property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
        //" sp.ITEM_SORT,\n" +
        //" sp.ITEM_CD,\n" +
        //" sp.ITEM_VALUE\n" +
        //"FROM\n" +
        //" a_fit_property_p property\n" +
        //" LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
        //" AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
        //"WHERE\n" +
        //" property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + ReviseStyle.sTYLE_CATEGORY_CD + "' ) \n" +
        //" AND property.DEL_FLG = 0 \n" +
        //"  AND sp.FIT_CD = '" + ReviseStyle.sTYLE_FIT_CD + "'  /*款式*/\n" +
        //" AND sp.SIZEGROUP_CD = '" + ReviseStyle.sTYLE_SIZE_GROUP_CD + "' \n" +
        //"-- AND sp.SIZE_CD = '" + ReviseStyle.sTYLE_SIZE_CD + "'   /*尺码*/\n" +
        //" AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
        //" AND sp.ENABLE_FLAG = 1 \n" +
        //" AND property.FIT_FLAG = 1 \n" +
        //" AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
        //"GROUP BY property.PROPERTY_VALUE  \n" +
        //"ORDER BY\n" +
        //" -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
        //" sp.ITEM_SORT ASC");
        //            //form.panel3.Controls.Clear();
        //            height = 0;
        //            width = 0;
        //            int i = 0;
        //            panelLocition = new PanelLocition(form.panel4.Width, form.panel4.Height, dt.Rows.Count);
        //            ChiCunHead hhh = new ChiCunHead();
        //            ImpService.generateUserControl(hhh, i);
        //            form.panel4.Controls.Add(hhh);
        //            i++;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                ChiCunCard ccc = new ChiCunCard(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), form);
        //                ImpService.generateUserControl(ccc, i);
        //                form.panel4.Controls.Add(ccc);//将控件加入panel 

        //                i++;
        //            }
        //            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
        //"	*,\n" +
        //"	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
        //"	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
        //"FROM\n" +
        //"	a_customer_fit_r ar\n" +
        //"	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
        //"WHERE\n" +
        //"	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
        //            foreach (Control card in form.panel4.Controls)
        //            {
        //                if (card is ChiCunCard)
        //                {
        //                    ChiCunCard c = (ChiCunCard)card;
        //                    foreach (DataRow dr in dtt.Rows)
        //                    {
        //                        if (c.fIT_ITEM_VALUE == dr["ITEM_VALUE"].ToString())
        //                        //if (dr["pv1"].ToString() == card.iTEM_VALUE || dr["pv2"].ToString() == card.iTEM_VALUE)
        //                        {
        //                            c.kehu.Text = dr["FIT_VALUE"].ToString();
        //                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
        //                        }
        //                    }
        //                }
        //            }
        //        }

        public static void generateUserControl(System.Windows.Forms.UserControl userControl, int i)
        {
            userControl.Name = "chicuncard" + i.ToString();
            //userControl.Size = new Size(200, 30);
            //if (i != 0)
            //{
            //    if (i % 5 == 0)
            //    {
            //        width = 0;
            //        height = height + 240;
            //    }
            //}
            userControl.Location = new System.Drawing.Point(panelLocition.UcLeft + width, panelLocition.UcHeight + height * 33);//控件位置
            height++;
        }
        /// <summary>
        /// 动态保存尺寸
        /// </summary>
        /// <param name="change"></param>
        public static void DynamicSaveSize(Change change, int sTYLE_FIT_ID, String customername)
        {
            ImpService.TurnChiCunZero(change);
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    fitv.icadd(c.iTEM_CD);
                    fitv.ivadd(c.iTEM_VALUE);
                    fitv.fvadd(c.chengyi.Text);
                    fitv.fmvadd(c.iTEM_VALUE);
                    fitv.invadd(c.jia.Text);
                    fitv.outvadd(c.jian.Text);
                }
            }
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }

        //    public static void ReviseDynamicSaveSize(ReviseStyle form, int sTYLE_FIT_ID, String customername)
        //    {
        //        ImpService.TurnChiCunZero(form);
        //        Fit_ValueDTo fitv = new Fit_ValueDTo();
        //        foreach (Control card in form.panel4.Controls)
        //        {
        //            if (card is ChiCunCard)
        //            {
        //                ChiCunCard c = (ChiCunCard)card;
        //                fitv.icadd(c.iTEM_CD);
        //                fitv.ivadd(c.iTEM_VALUE);
        //                //fitv.fvadd(c.chengyi.Text);
        //                fitv.fmvadd(c.iTEM_VALUE);
        //                //fitv.invadd(c.jia.Text);
        //                //fitv.outvadd(c.jian.Text);
        //            }
        //        }
        //        SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
        //        SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
        //new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        //    }

        /// <summary>
        /// 刷新尺寸
        /// </summary>
        /// <param name="change"></param>
        /// <param name="dt"></param>
        public static void RefreshChiCun(Change change, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (Control card in change.panel4.Controls)
                {
                    if (card is UC尺寸卡片)
                    {
                        UC尺寸卡片 c = (UC尺寸卡片)card;
                        if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
                        {
                            c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
                            break;
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 修改款式刷新尺寸
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dt"></param>
        //public static void RefreshChiCun(ReviseStyle form, DataTable dt)
        //{
        //foreach (DataRow dr in dt.Rows)
        //{
        //    foreach (Control card in form.panel4.Controls)
        //    {
        //        if (card is ChiCunCard)
        //        {
        //            ChiCunCard c = (ChiCunCard)card;
        //            if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
        //            {
        //                c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
        //                break;
        //            }
        //        }
        //    }
        //}
        //}
        /// <summary>
        /// 将空尺寸设为0
        /// </summary>
        /// <param name="change"></param>
        public static void TurnChiCunZero(Change change)
        {
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    if (c.biaozhun.Text == "")
                    {
                        c.biaozhun.Text = "0";
                    }
                    if (c.jia.Text == "")
                    {
                        c.jia.Text = "0";
                    }
                    if (c.jian.Text == "")
                    {
                        c.jian.Text = "0";
                    }
                }
            }
        }
        /// <summary>
        /// 修改尺寸将空尺寸设为0
        /// </summary>
        /// <param name="form"></param>
        //public static void TurnChiCunZero(ReviseStyle form)
        //{
        //foreach (Control card in form.panel4.Controls)
        //{
        //    if (card is ChiCunCard)
        //    {
        //        ChiCunCard c = (ChiCunCard)card;
        //        if (c.biaozhun.Text == "")
        //        {
        //            c.biaozhun.Text = "0";
        //        }
        //        if (c.jia.Text == "")
        //        {
        //            c.jia.Text = "0";
        //        }
        //        if (c.jian.Text == "")
        //        {
        //            c.jian.Text = "0";
        //        }
        //    }
        //}
        //}
        /// <summary>
        /// 计算成衣尺寸
        /// </summary>
        /// <param name="change"></param>
        public static void CountChiCun(Change change)
        {
            ImpService.TurnChiCunZero(change);
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
                }
            }
        }
        /// <summary>
        /// 修改款式计算成衣尺寸
        /// </summary>
        /// <param name="form"></param>
        //public static void CountChiCun(ReviseStyle form)
        //{
        //ImpService.TurnChiCunZero(form);
        //foreach (Control card in form.panel4.Controls)
        //{
        //    if (card is ChiCunCard)
        //    {
        //        ChiCunCard c = (ChiCunCard)card;
        //        c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
        //    }
        //}
        //}
        /// <summary>
        /// 修改款式修改尺寸
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseChangeChiCun(ReviseStyle form, String sizecd)
        //{
        //    int i2 = SQLmtm.DoUpdate("s_style_p", new string[] { "STYLE_SIZE_CD" }, new string[] { sizecd }, new string[] { "SYS_STYLE_ID" }, new string[] { ReviseStyle.sYS_STYLE_ID });
        //    if (i2 != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //    ImpService.TurnChiCunZero(form);
        //    Fit_ValueDTo fitv = new Fit_ValueDTo();
        //    foreach (Control card in form.panel4.Controls)
        //    {
        //        if (card is ChiCunCard)
        //        {
        //            ChiCunCard c = (ChiCunCard)card;
        //            fitv.icadd(c.iTEM_CD);
        //            fitv.ivadd(c.iTEM_VALUE);
        //            fitv.fvadd(c.chengyi.Text);
        //            fitv.fmvadd(c.iTEM_VALUE);
        //            fitv.invadd(c.jia.Text);
        //            fitv.outvadd(c.jian.Text);
        //        }
        //    }
        //    int i = SQLmtm.DoUpdate("a_customer_fit_value_r", new string[] { "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE" }, new string[] { fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE }, new string[] { "CUSTOMER_COUNT_ID" }, new string[] { CreateCustomer.customer_countid.ToString() });
        //    if (i != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //    int i1 = SQLmtm.DoUpdate("s_style_fit_r", new string[] { "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE" }, new string[] { fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE }, new string[] { "STYLE_ID" }, new string[] { ReviseStyle.sYS_STYLE_ID });
        //    if (i1 != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //}
        /// <summary>
        /// 修改款式客户基本信息加载
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseLoudCustomer(ReviseStyle form)
        //{
        //    DataRow drr = SQLmtm.GetDataRow("SELECT * FROM o_order_p WHERE STYLE_ID='" + ReviseStyle.sYS_STYLE_ID + "'");
        //    form.beizhu01.Text = drr["REMARKS"].ToString();
        //    form.dangqiankehu.Text = drr["CUSTOM_NAME"].ToString();
        //    DataTable dt = SQLmtm.GetDataTable("SELECT * FROM (SELECT * FROM a_customer_fit_r) s1 RIGHT JOIN (SELECT * FROM a_customer_fit_count_r WHERE CUSTOMER_ID ='" + drr["CUSTOMER_ID"].ToString() + "' AND DEFAULT_FLAG ='1') s2 on s1.FIT_COUNT_ID=s2.ID");
        //    //if(dt.Rows[0]["CUSTOMER_FIT_ID"].ToString()!="")
        //    //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_ITEM_09")
        //        {
        //            form.kehushengao.Text = dr["FIT_VALUE"].ToString();
        //        }

        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_ITEM_10")
        //        {
        //            form.kehutizhong.Text = dr["FIT_VALUE"].ToString();
        //        }

        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_CODE_01")
        //        {
        //            switch (dr["FIT_VALUE"].ToString())
        //            {
        //                case "1":
        //                    form.kehujianxing.Text = "平肩";
        //                    break;
        //                case "2":
        //                    form.kehujianxing.Text = "溜肩";
        //                    break;
        //                case "3":
        //                    form.kehujianxing.Text = "正常";
        //                    break;
        //            }
        //        }


        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_CODE_02")
        //        {
        //            switch (dr["FIT_VALUE"].ToString())
        //            {
        //                case "4":
        //                    form.kehuduxing.Text = "凹陷";
        //                    break;
        //                case "5":
        //                    form.kehuduxing.Text = "平坦";
        //                    break;
        //                case "6":
        //                    form.kehuduxing.Text = "微凸";
        //                    break;
        //                case "7":
        //                    form.kehuduxing.Text = "中凸";
        //                    break;
        //                case "8":
        //                    form.kehuduxing.Text = "重凸";
        //                    break;
        //            }
        //        }


        //    }
        //}
        /// <summary>
        /// 修改款式修改备注
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseSaveBeiZhu(ReviseStyle form)
        //{
        //    int i = SQLmtm.DoUpdate("o_order_p", new string[] { "REMARKS" }, new string[] { form.beizhu01.Text }, new string[] { "ORDER_ID" }, new string[] { ReviseStyle.oRDER_ID });
        //    if (i != 1)
        //    {
        //        MessageBox.Show("修改备注失败");
        //        return;
        //    }
        //}
        /// <summary>
        /// 动态加载设计点控件
        /// </summary>
        /// <param name="change"></param>
        public static void LoadSheJiDian(Change change, String styleid)
        {
            DataTable dt = SQLmtm.GetDataTable("select * from a_kuanshi_p where STYLEID =" + styleid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请联系管理员完善相关信息");
                return;
            }
            change.panel6.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(change.panel6.Width, change.panel6.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ITEM_VALUE"].ToString() != "mianliaoid")
                {
                    UC设计点选择 chooseCard = new UC设计点选择(dr["id"].ToString(), dr["ITEM_NAME_CN"].ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["DEFAULT_NAME_CN"].ToString(), dr["DEFAULT_CD"].ToString(), dr["DEFAULT_VALUE"].ToString(), "");
                    ArrayUC(chooseCard, i);
                    change.panel6.Controls.Add(chooseCard);
                    i++;
                }
                else
                {
                    MianLiaochoose.mianliaocd = dr["DEFAULT_CD"].ToString();
                    MianLiaochoose.mianliaoid = dr["DEFAULT_VALUE"].ToString();
                    MianLiaochoose.mianliao = change.mianliaoname.Text = dr["DEFAULT_NAME_CN"].ToString();
                }
            }
        }
        private static void ArrayUC(System.Windows.Forms.UserControl userControl, int i)
        {
            userControl.Name = "shejidiancard" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 16 == 0)
                {
                    width = width + 500;
                    height = 0;
                }
            }
            userControl.Location = new System.Drawing.Point(panelLocition.UcLeft + width, panelLocition.UcHeight + height * 50);//控件位置
            height++;
        }
        /// <summary>
        /// 查询默认项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable DefaultItem(String id)
        {
            String sql = "SELECT\n" +
"	a.ITEM_CD,\n" +
"	a.ITEM_VALUE,\n" +
"	w.UPLOAD_FILE AS picn,\n" +
"	a.ITEM_NAME_CN\n" +
"FROM\n" +
"	a_kuanshi_p a\n" +
"	LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID \n" +
"WHERE\n" +
"	a.FILE_ID IS NOT NULL \n" +
"	AND a.PARENT_ID = '" + id + "';";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 查询默认面料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>          
        public static DataTable DefaultMianLiao(String id, String str, int page)
        {
            String sql = "SELECT\n" +
"	ap.*,\n" +
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
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 动态设计点保存
        /// </summary>
        /// <param name="change"></param>
        public static void DynamicSaveDesign(Change change)
        {
            UC设计点选择 c = new UC设计点选择();
            foreach (Control card in change.panel6.Controls)
            {
                if (card is UC设计点选择)
                {
                    c = (UC设计点选择)card;
                    SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" },
new string[] { Change.styleid.ToString(), c.PitemCd, c.PitemValue, c.itemValue, "1", "0" });
                }
            }
        }
        /// <summary>
        /// 获取客户基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<CustomerInformation> GetCustomerInformation(int id)
        {
            List<CustomerInformation> ci = new List<CustomerInformation>();
            String sql = "SELECT " +
"fcr.id, " +
"fcr.CUSTOMER_ID, " +
"fcr.CUSTOMER_NAME, " +
"fcr.SEX, " +
"fcr.AGE, " +
"fr.STYLE_CATEGORY_CD, " +
"fr.ITEM_CD, " +
"fr.ITEM_VALUE, " +
"fr.FIT_VALUE, " +
"fpp.PROPERTY_NAME_CN, " +
"dop.ITEM_NAME_CN  " +
"FROM " +
"	a_customer_fit_count_r AS fcr " +
"	LEFT JOIN a_customer_fit_r fr ON fcr.id = fr.FIT_COUNT_ID " +
"	LEFT JOIN a_fit_property_p AS fpp ON fr.ITEM_VALUE = fpp.PROPERTY_VALUE " +
"	LEFT JOIN w_dict_option_p AS dop ON fr.ITEM_VALUE = dop.ITEM_CD  " +
"	AND fr.FIT_VALUE = dop.ITEM_VALUE  " +
"WHERE " +
"	fcr.CUSTOMER_ID = '" + id.ToString() + "' " +
"	AND fcr.DEFAULT_FLAG = '1'";
            DataTable dt = SQLmtm.GetDataTable(sql);
            if (dt.Rows.Count != 0)
            {
                ci.Add(new CustomerInformation("收件人姓名", dt.Rows[0]["CUSTOMER_NAME"].ToString()));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ITEM_NAME_CN"].ToString() != "")
                    {
                        ci.Add(new CustomerInformation(dr["PROPERTY_NAME_CN"].ToString(), dr["ITEM_NAME_CN"].ToString()));
                    }
                    else
                    {
                        ci.Add(new CustomerInformation(dr["PROPERTY_NAME_CN"].ToString(), dr["FIT_VALUE"].ToString()));
                    }
                }
            }
            return ci;
        }
        /// <summary>
        /// 查询已打印
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetPrintedData(String orderno)
        {
            String sql = "SELECT * FROM a_product_log_p WHERE ORDER_NO='" + orderno + "'";
            return SQLmtm.GetDataTable(sql);
        }

        public static DataRow GetDataFromStyleid(String id)
        {
            String sql = "SELECT ";
            sql = sql + "sp.SYS_STYLE_ID, ";
            sql = sql + "sp.STYLE_NAME_CN, ";
            sql = sql + "imp.MATERIAL_CODE, ";
            sql = sql + "imp.MATERIAL_COMPOSITION, ";
            sql = sql + "sp.STYLE_SHOP_TOTAL_PRICE, ";
            sql = sql + "sp.STYLE_FIT_CD, ";
            sql = sql + "sp.STYLE_CATEGORY_CD, ";
            sql = sql + "sp.STYLE_SIZE_GROUP_CD ";
            sql = sql + "FROM ";
            sql = sql + "s_style_p AS sp ";
            sql = sql + "LEFT JOIN i_material_p imp ON sp.SYTLE_FABRIC_ID = imp.MATERIAL_ID ";
            sql = sql + "WHERE ";
            sql = sql + "sp.SYS_STYLE_ID = '" + id + "';";
            return SQLmtm.GetDataRow(sql);
        }

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
        /// 成衣尺寸数据
        /// </summary>
        /// <param name="styleid"></param>
        /// <returns></returns>
        public static List<ChengYiChiCun> GetChengYiChiCun(String styleid)
        {
            List<ChengYiChiCun> cycc = new List<ChengYiChiCun>();
            String sql = "SELECT\n" +
"	ITEM_CD AS itemCd,\n" +
"	ITEM_VALUE AS itemValue,\n" +
"	FIT_VALUE AS fitValue,\n" +
"	IN_VALUE AS inValue,\n" +
"	OUT_VALUE AS outValue \n" +
"FROM\n" +
"	s_style_fit_r \n" +
"WHERE\n" +
"	STYLE_ID = '" + styleid + "'";
            DataRow chengyidr = SQLmtm.GetDataRow(sql);
            List<String> itemCdList = new List<String>(chengyidr["itemCd"].ToString().Split(','));
            List<String> itemValueList = new List<String>(chengyidr["itemValue"].ToString().Split(','));
            List<String> fitValueList = new List<String>(chengyidr["fitValue"].ToString().Split(','));

            List<Tradd> itemCdHoldList = new List<Tradd>();
            List<Tradd> itemValueHoldList = new List<Tradd>();
            List<Tradd> fitValueHoldList = new List<Tradd>();
            int i = 0;
            foreach (String cdvl in itemCdList)
            {
                itemCdHoldList.Add(new Tradd(i, cdvl));
                i++;
            }
            i = 0;
            foreach (String cdvl in itemValueList)
            {
                itemValueHoldList.Add(new Tradd(i, cdvl));
                i++;
            }
            i = 0;
            foreach (String cdvl in fitValueList)
            {
                fitValueHoldList.Add(new Tradd(i, cdvl));
                i++;
            }
            foreach (Tradd tradd1 in itemCdHoldList)
            {
                foreach (Tradd tradd2 in itemValueHoldList)
                {
                    if (tradd1.i == tradd2.i)
                    {
                        foreach (Tradd tradd3 in fitValueHoldList)
                        {
                            if (tradd2.i == tradd3.i)
                            {
                                cycc.Add(new ChengYiChiCun(tradd1.str, tradd2.str, tradd3.str));
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return cycc;
        }

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
        /// 查询订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetOrder(String orderno, int order_type)
        {
            String sql = "SELECT * FROM v_order_with_type WHERE order_type ='" + order_type + "'" +
                " and ORDER_NO like '%" + orderno + "%'";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 查询未打印订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static DataTable GetNotPrintedData(String orderno, DateTime startTime, DateTime endTime, int order_type)
        {
            String sql = "SELECT " +
                "	*  " +
                "FROM " +
                "	v_order_with_type " +
                "WHERE " +
                "	ORDER_NO NOT IN ( SELECT ORDER_NO FROM a_product_log_p ) " +
                "	AND ORDER_NO LIKE '%" + orderno + "%' " +
                " and ORDER_DATE between '" + startTime.ToString() + "' and '" + endTime.ToString() + "'" +
                " and order_type ='" + order_type + "'" +
                "	order by ORDER_DATE";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable GetCustomerData(String str)
        {
            String sql = "SELECT " +
"	acp.CUSTOMER_ID AS ID, " +
"	CONCAT( CONCAT( acp.CUSTOMER_FIRST_NAME, ' ' ), acp.CUSTOMER_LAST_NAME ) AS 微信名称, " +
"	acp.MOBILE AS 手机, " +
"	acp.CREATE_DATE AS 注册时间, " +
"	cap.CONSIGNEE AS 客户姓名 " +
"FROM " +
"	a_customer_p AS acp " +
"LEFT JOIN a_customer_address_p AS cap ON cap.CUSTOMER_ID = acp.CUSTOMER_ID " +
"WHERE " +
"	acp.CUSTOMER_FIRST_NAME LIKE '%" + str + "%'  " +
"	OR acp.CUSTOMER_LAST_NAME LIKE '%" + str + "%'  " +
"	OR acp.MOBILE LIKE '%" + str + "%'  " +
"	OR cap.CONSIGNEE LIKE '%" + str + "%'  " +
"ORDER BY " +
"	acp.CREATE_DATE DESC  ";
            return SQLmtm.GetDataTable(sql);
        }

        public static String GetMianLiaoFile(String mlid)
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
            return SQLmtm.GetDataRow(sql)["picn"].ToString();
        }

        public static List<CustomerInformation> AddSomething(List<CustomerInformation> ci, String information, String value)
        {
            List<CustomerInformation> customerInformation = new List<CustomerInformation>();
            customerInformation.Add(new CustomerInformation(information, value));
            customerInformation.AddRange(ci);
            return customerInformation;
        }

        public static DataTable getOrderTypeCode()
        {
            String sql = "select * from t_order_type_code;";
            return SQLmtm.GetDataTable(sql);
        }
        /// <summary>
        /// 标准款设计点保存
        /// </summary>
        public static void StandardModelsDesignSive()
        {
            try
            {
                String sql = "SELECT * FROM s_style_option_r WHERE SYS_STYLE_ID='" + Change.kuanshiid + "'";
                DataTable dt = SQLmtm.GetDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" },
    new string[] { Change.styleid.ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["OPTION_VALUE"].ToString(), "1", "0" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息: " + ex.Message);
                return;
            }

        }
        /// <summary>
        /// 标准款尺寸保存
        /// </summary>
        /// <param name="dt"></param>
        public static void StandardModelsSizeSive(DataTable dt)
        {
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (DataRow dr in dt.Rows)
            {
                fitv.icadd(dr["ITEM_CD"].ToString());
                fitv.ivadd(dr["ITEM_VALUE"].ToString());
                fitv.fvadd(dr["ITEM_FIT_VALUE"].ToString());
                fitv.fmvadd(dr["ITEM_VALUE"].ToString());
                fitv.invadd("0");
                fitv.outvadd("0");
            }
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { CreateCustomer.cUSTOMER_ID.ToString(), CreateCustomer.customer_name, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }
        /// <summary>
        /// 清空个别静态变量
        /// </summary>
        public static void ClearStaticVariable()
        {
            MianLiaochoose.mianliao = "";
            MianLiaochoose.mianliaocd = "";
            MianLiaochoose.mianliaoid = "";
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
        /// <summary>
        /// 标准款s_style_p写入数据
        /// </summary>
        /// <param name="uc"></param>
        public static void insertS_Style_P(UC款式卡片 uc)
        {
            SQLmtm.DoInsert("s_style_p", new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" },
    new string[] { Change.styleid.ToString(), "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", uc.sTYLE_CATEGORY_CD, MianLiaochoose.mianliaoid, uc.sTYLE_SIZE_GROUP_CD, Change.sTYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", uc.kuanshimingcheng, "", CreateCustomer.customer_countid.ToString(), uc.sTYLE_FIT_CD, uc.kuanshiid, uc.sTYLE_DRESS_CATEGORY, uc.sTYLE_DESIGN_TYPE, uc.sTYLE_PUBLISH_CATEGORY_CD, uc.sYTLE_YEAR, uc.sYTLE_SEASON });
        }

        public static void LoadSheJiDian(Frm门店下单选款式 frm, String styleid)
        {
            frm.panel3.Controls.Clear();
            DataTable dt = SQLmtm.GetDataTable("select * from a_kuanshi_p where STYLEID =" + styleid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请联系管理员完善相关信息");
                return;
            }
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(frm.panel3.Width, frm.panel3.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ITEM_VALUE"].ToString() != "mianliaoid")
                {
                    UC设计点选择 chooseCard = new UC设计点选择(dr["id"].ToString(), dr["ITEM_NAME_CN"].ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["DEFAULT_NAME_CN"].ToString(), dr["DEFAULT_CD"].ToString(), dr["DEFAULT_VALUE"].ToString(), "");
                    ArrayUC(chooseCard, i);
                    frm.panel3.Controls.Add(chooseCard);
                    i++;
                }
                else
                {
                    MianLiaochoose.mianliaocd = dr["DEFAULT_CD"].ToString();
                    MianLiaochoose.mianliaoid = dr["DEFAULT_VALUE"].ToString();
                    MianLiaochoose.mianliao = frm.mianliaoname.Text = dr["DEFAULT_NAME_CN"].ToString();
                }
            }
        }

        public static void LoadChiCunCard(Frm门店下单选款式 frm)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
" sp.FIT_ITEM_VALUE,\n" +
" property.PROPERTY_CD propertyCd,\n" +
"/*量体属性CD*/\n" +
"property.PROPERTY_VALUE propertyValue,\n" +
"/*量体VALUE*/\n" +
" sp.ITEM_IN_FROM propertyInFrom,\n" +
"/*量体属性值可增加范围从*/\n" +
" sp.ITEM_IN_TO propertyInTo,\n" +
"/*量体属性值可增加范围到*/\n" +
" sp.ITEM_OUT_FROM propertyOutFrom,\n" +
"/*量体属性值可缩减范围从*/\n" +
" sp.ITEM_OUT_TO propertyOutTo,\n" +
"/*量体属性值可缩减范围到*/\n" +
" property.PROPERTY_NAME_CN propertyNameCn,\n" +
"/*量体属性中文名称*/\n" +
" property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
"/*0-非净量体，1-净量体*/\n" +
" property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
" sp.ITEM_SORT,\n" +
" sp.ITEM_CD,\n" +
" sp.ITEM_VALUE\n" +
"FROM\n" +
" a_fit_property_p property\n" +
" LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
" AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
"WHERE\n" +
" property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + frm.Dto定制下单.STYLE_CATEGORY_CD + "' ) \n" +
" AND property.DEL_FLG = 0 \n" +
"  AND sp.FIT_CD = '" + frm.Dto定制下单.STYLE_FIT_CD + "'  /*款式*/\n" +
" AND sp.SIZEGROUP_CD = '" + frm.Dto定制下单.STYLE_SIZE_GROUP_CD + "' \n" +
"-- AND sp.SIZE_CD = '" + frm.Dto定制下单.STYLE_SIZE_CD + "'   /*尺码*/\n" +
" AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
" AND sp.ENABLE_FLAG = 1 \n" +
" AND property.FIT_FLAG = 1 \n" +
" AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
"GROUP BY property.PROPERTY_VALUE  \n" +
"ORDER BY\n" +
" -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
" sp.ITEM_SORT ASC");
            //change.panel3.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(frm.panel4.Width, frm.panel4.Height, dt.Rows.Count);
            UC尺寸头 hhh = new UC尺寸头();
            ImpService.generateUserControl(hhh, i);
            frm.panel4.Controls.Clear();
            frm.panel4.Controls.Add(hhh);
            i++;
            foreach (DataRow dr in dt.Rows)
            {
                UC尺寸卡片 ccc = new UC尺寸卡片(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), frm);
                ImpService.generateUserControl(ccc, i);
                frm.panel4.Controls.Add(ccc);//将控件加入panel                
                i++;
            }
            //DataTable ddt=SQLmtm.GetDataTable("")
            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
"	*,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
"FROM\n" +
"	a_customer_fit_r ar\n" +
"	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
"WHERE\n" +
"	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["pv1"].ToString() == c.iTEM_VALUE || dr["pv2"].ToString() == c.iTEM_VALUE)
                        {
                            c.kehu.Text = dr["FIT_VALUE"].ToString();
                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 动态设计点保存
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dto"></param>
        public static void DynamicSaveSize(Frm门店下单选款式 frm, Dto定制下单 dto)
        {
            ImpService.TurnChiCunZero(frm);
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    fitv.icadd(c.iTEM_CD);
                    fitv.ivadd(c.iTEM_VALUE);
                    fitv.fvadd(c.chengyi.Text);
                    fitv.fmvadd(c.iTEM_VALUE);
                    fitv.invadd(c.jia.Text);
                    fitv.outvadd(c.jian.Text);
                }
            }
            dto.build尺寸(
                fitv.iTEM_CD
                , fitv.iTEM_VALUE
                , fitv.fitValue
                , fitv.fM_VALUE
                , fitv.iN_VALUE
                , fitv.oUT_VALUE
                , "0"
                , "0"
                , CreateCustomer.customer_countid.ToString()
                , "AUDIT_PHASE_CD-PHASE_CD_10"
                , "1"
                , "46"
                );
            //        SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            //        SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
            //new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }
        /// <summary>
        /// 尺寸空设为0
        /// </summary>
        /// <param name="frm"></param>
        public static void TurnChiCunZero(Frm门店下单选款式 frm)
        {
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    if (c.biaozhun.Text == "")
                    {
                        c.biaozhun.Text = "0";
                    }
                    if (c.jia.Text == "")
                    {
                        c.jia.Text = "0";
                    }
                    if (c.jian.Text == "")
                    {
                        c.jian.Text = "0";
                    }
                }

            }
        }
        /// <summary>
        /// 动态保存设计点
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dto"></param>
        public static void DynamicSaveDesign(Frm门店下单选款式 frm, Dto定制下单 dto)
        {
            UC设计点选择 c = new UC设计点选择();
            foreach (Control card in frm.panel3.Controls)
            {
                if (card is UC设计点选择)
                {
                    c = (UC设计点选择)card;
                    dto.build设计点(c.PitemCd, c.PitemValue, c.itemValue, "1", "0", c.itemName, c.PitemName, c.pic);
                    //                    SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" },
                    //new string[] { Change.styleid.ToString(), c.PitemCd, c.PitemValue, c.itemValue, "1", "0" });
                }
            }
        }
        /// <summary>
        /// 刷新尺寸
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dt"></param>
        public static void RefreshChiCun(Frm门店下单选款式 frm, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (Control card in frm.panel4.Controls)
                {
                    if (card is UC尺寸卡片)
                    {
                        UC尺寸卡片 c = (UC尺寸卡片)card;
                        if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
                        {
                            c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
                            break;
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 计算成衣尺寸
        /// </summary>
        /// <param name="frm"></param>
        public static void CountChiCun(Frm门店下单选款式 frm)
        {
            ImpService.TurnChiCunZero(frm);
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
                }
            }
        }

        public static String GetPicn(String value)
        {
            String sql = "SELECT \n" +
" s1.itemValue , \n" +
" s1.itemNameCn , \n" +
" s1.itemCode , \n" +
" S2.UPLOAD_FILE AS picn, \n" +
" s2.picurl  \n" +
" FROM \n" +
" ( \n" +
" SELECT \n" +
" 	ap.ITEM_VALUE itemValue, \n" +
" 	ap.DESIGN_ID id, \n" +
" 	CONCAT( ap.ITEM_VALUE, \":\", ap.ITEM_NAME_CN ) itemNameCn, \n" +
" 	ap.ITEM_CD itemCode, \n" +
" 	adp.ITEM_CD itemParentCode  \n" +
" FROM \n" +
" 	a_designoption_p ap \n" +
" 	LEFT JOIN a_designoption_p adp ON adp.ITEM_VALUE = ap.ITEM_CD \n" +
" 	LEFT JOIN a_ognization_desgin_r adr ON ap.DESIGN_ID = adr.DESGIN_ID  \n" +
" WHERE \n" +
" 	( ap.ITEM_CATEGORY_CD = \"\" OR ap.ITEM_CATEGORY_CD IS NULL )  \n" +
" 	AND ap.STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT'  \n" +
" 	-- AND ap.ITEM_CD = '' -- AND ap.ITEM_CD IN ( SELECT ap.ITEM_VALUE itemValue FROM a_designoption_p ap WHERE ap.ITEM_CATEGORY_CD ='ITEM_TYPE_CD-10' ) \n" +
" 	AND ap.ITEM_VALUE = '" + value + "'\n" +
" 	AND adr.OGNIZATION_ID = 95  \n" +
" 	AND ap.ITEM_VALUE IN ( \n" +
" 	SELECT \n" +
" 		ap.ITEM_VALUE itemValue  \n" +
" 	FROM \n" +
" 		a_designoption_p ap  \n" +
" 	WHERE \n" +
" 		ap.DESIGN_ID IN ( SELECT ar.DESGIN_ID FROM a_shop_desgin_r ar WHERE ar.SHOP_ID = 18 )  \n" +
" 	)  \n" +
" ORDER BY \n" +
" 	ap.ITEM_CD, \n" +
" 	ap.ITEM_SORT ASC  \n" +
" ) AS s1 \n" +
" LEFT JOIN ( \n" +
" SELECT \n" +
" 	a.ITEM_CD, \n" +
" 	a.ITEM_VALUE, \n" +
" 	a.ITEM_NAME_CN, \n" +
" 	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', w.UPLOAD_FILE ) AS picurl, \n" +
" 	w.*  \n" +
" FROM \n" +
" 	a_designoption_p a \n" +
" 	LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID  \n" +
" WHERE \n" +
" 	a.FILE_ID IS NOT NULL  \n" +
" ) AS s2 ON s1.itemCode = s2.ITEM_CD  \n" +
" AND s1.itemValue = s2.ITEM_VALUE";
            DataRow dr = SQLmtm.GetDataRow(sql);
            try
            {
                String str = dr["picn"].ToString();
                return str;
            }
            catch
            {
                return "SSHIRT.jpg";
            }

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

        public static void SiveINa_noorder_print_p(DTO无订单打印 dTO)
        {
            int i = SQLmtm.DoInsert("a_noorder_print_p", new string[] { "clothes_log_id", "shop_id", "style_id", "materials_id", "size_cd", "json" }, new string[] { dTO.clothes_log_id, dTO.shop_id, dTO.style_id, dTO.materials_id, dTO.size_cd, dTO.json });
        }
    }
}

