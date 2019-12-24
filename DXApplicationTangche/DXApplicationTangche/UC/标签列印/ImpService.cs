using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaoPaiDaYin
{
    class ImpService
    {
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
"	sp.SYS_STYLE_ID IN ( SELECT op.STYLE_ID FROM o_order_p AS op WHERE ORDER_NO = '"+id+"' );";
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
"	STYLE_ID = '76684'";
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
            DataRow dr = SQLmtm.GetDataRow("SELECT PROPERTY_NAME_CN FROM a_fit_property_p WHERE PROPERTY_VALUE='"+itemValue+"'");
            if(dr==null)
            {
                return "";
            }
            else
            {
                return dr["PROPERTY_NAME_CN"].ToString();
            }
        }

    }
}
