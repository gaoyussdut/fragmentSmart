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
    /// 尺寸服务
    /// </summary>
    public class SizeService
    {
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
                    String sql = "SELECT\n" +
                    "	*,\n" +
                    "	SUBSTRING_INDEX( SIZE_CD, '-',- 1 ) \n" +
                    "FROM\n" +
                    "	`a_size_fit_p` \n" +
                    "WHERE\n" +
                    "	FIT_CD = '" + st["STYLE_FIT_CD"].ToString() + "' \n" +
                    "	AND STYLE_CATEGORY_CD = '" + st["STYLE_CATEGORY_CD"].ToString() + "' \n" +
                    "	AND SIZEGROUP_CD = '" + st["STYLE_SIZE_GROUP_CD"] + "' \n" +
                    "	AND SIZE_CD = '" + dr["SIZE_CD"].ToString() + "';";
                    dt = SQLmtm.GetDataTable(sql);
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
        /// 成衣尺寸数据
        /// </summary>
        /// <param name="styleid"></param>
        /// <returns></returns>
        public static List<成衣尺寸DTO> Get成衣尺寸DTO(String styleid)
        {
            List<成衣尺寸DTO> cycc = new List<成衣尺寸DTO>();
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
                                cycc.Add(new 成衣尺寸DTO(tradd1.str, tradd2.str, tradd3.str));
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return cycc;
        }

        public static List<尺寸呈现dto> GetThisSize(Dto定制下单 dto)
        {
            return GetThisSize(dto.STYLE_FIT_CD, dto.STYLE_CATEGORY_CD, dto.STYLE_SIZE_CD, dto.STYLE_SIZE_GROUP_CD, dto.Style_Id,true);
        }


        private static List<尺寸呈现dto> GetThisSize(String STYLE_FIT_CD,String STYLE_CATEGORY_CD,String STYLE_SIZE_CD,String STYLE_SIZE_GROUP_CD,String Style_Id,Boolean isRef)
        {
            List<尺寸呈现dto> 尺寸呈现 = new List<尺寸呈现dto>();
            String sql;
            if (!isRef)  //  是否标准款
            {
                sql = "SELECT\n" +
                    "	S1.*,\n" +
                    "	S2.* \n" +
                    "FROM\n" +
                    "	( SELECT * FROM a_size_fit_p WHERE FIT_CD = 'FIT_BODY_TYPE-1914F' AND STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT' AND SIZE_CD = 'EGS_GROUP_SIZE-42' AND SIZEGROUP_CD = 'GROUP_SIZE-EGS_GROUP_SIZE' ) AS s1\n" +
                    "	LEFT JOIN ( SELECT * FROM a_reasonable_p WHERE styleID IN ( SELECT REF_STYLE_ID FROM s_style_p WHERE SYS_STYLE_ID = " + Style_Id + " ) ) AS s2 ON s1.ITEM_VALUE = s2.itemValue;";
            }
            else {
                sql = "SELECT\n" +
                "	S1.*,\n" +
                "	S2.* \n" +
                "FROM\n" +
                "	( SELECT * FROM a_size_fit_p WHERE" +
                " FIT_CD = '" + STYLE_FIT_CD + "'" +
                " AND STYLE_CATEGORY_CD = '" + STYLE_CATEGORY_CD + "'" +
                " AND SIZE_CD = '" + STYLE_SIZE_CD + "'" +
                " AND SIZEGROUP_CD = '" + STYLE_SIZE_GROUP_CD + "' ) AS s1\n" +
                "	LEFT JOIN ( SELECT * FROM a_reasonable_p WHERE styleID = " + Style_Id + " ) AS s2 ON s1.ITEM_VALUE = s2.itemValue;";
            }

            DataTable dt = SQLmtm.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                尺寸呈现.Add(
                    new 尺寸呈现dto(
                        dr["ITEM_CD"].ToString()
                        , dr["ITEM_VALUE"].ToString()
                        , ""
                        , ""
                        , Convert.ToDouble(dr["ITEM_FIT_VALUE"].ToString())
                        , 0
                        , 0
                        , dr["ITEM_NAME_CN"].ToString()
                        , Convert.ToDouble(dr["leastReasonable"].ToString() == "" ? "0" : dr["leastReasonable"].ToString())
                        , Convert.ToDouble(dr["maxReasonable"].ToString() == "" ? "0" : dr["maxReasonable"].ToString())
                        )
                    );
            }
            return 尺寸呈现;
        }

        public static List<尺寸呈现dto> getDto尺寸ByOrderId(String orderId, String STYLE_FIT_CD, String STYLE_CATEGORY_CD, String STYLE_SIZE_CD, String STYLE_SIZE_GROUP_CD,String CUSTOMER_ID) {
            //  尺寸
            String sql = "SELECT\n" +
                "	STYLE_ID,\n" +
                "	PHASE_CD,\n" +
                "	ITEM_CD,\n" +
                "	ITEM_VALUE,\n" +
                "	FIT_VALUE,\n" +
                "	FM_VALUE,\n" +
                "	DELETE_FLAG,\n" +
                "	VERSION,\n" +
                "	CREATE_USER,\n" +
                "	IN_VALUE,\n" +
                "	OUT_VALUE \n" +
                "FROM\n" +
                "	s_style_fit_r \n" +
                "WHERE\n" +
                "	STYLE_ID IN ( SELECT STYLE_ID FROM o_order_p WHERE ORDER_ID = '"+ orderId + "' );";
            DataTable dt = SQLmtm.GetDataTable(sql);
            //  客户量体值
            sql = "SELECT\n" +
                "	customer_fit.CUSTOMER_FIT_ID,\n" +
                "	customer_fit.CUSTOMER_ID,\n" +
                "	customer_fit.STYLE_CATEGORY_CD,\n" +
                "	customer_fit.ITEM_CD,\n" +
                "	customer_fit.ITEM_VALUE,\n" +
                "	customer_fit.FIT_VALUE,\n" +
                "	property.PROPERTY_NAME_CN,\n" +
                "	property.PROPERTY_CD,\n" +
                "	property.PROPERTY_VALUE,\n" +
                "	property.PROPERTY_UNIT_CD,\n" +
                "	customer_fit.STYLE_CATEGORY_CD \n" +
                "FROM\n" +
                "	a_customer_fit_r customer_fit\n" +
                "	LEFT JOIN a_fit_property_p property ON property.PROPERTY_CD = customer_fit.ITEM_CD \n" +
                "	AND property.PROPERTY_VALUE = customer_fit.ITEM_VALUE \n" +
                "WHERE\n" +
                "	customer_fit.DELETE_FLAG = 0 \n" +
                "	AND customer_fit.CUSTOMER_ID = '" + CUSTOMER_ID + "' \n" +
                "	AND customer_fit.CREATE_DATE = ( SELECT CREATE_DATE FROM a_customer_fit_r WHERE CUSTOMER_ID = '"+ CUSTOMER_ID + "' ORDER BY CREATE_DATE DESC LIMIT 1 ) \n" +
                "ORDER BY\n" +
                "	property.PROPERTY_COST";
            DataTable dataTable客户量体值 = SQLmtm.GetDataTable(sql);

            
            Dto尺寸 Dto尺寸;
            foreach (DataRow dr in dt.Rows)
            {
                Dto尺寸 = new Dto尺寸(dr);
                List<尺寸呈现dto> 尺寸呈现dto = SizeService.GetThisSize(STYLE_FIT_CD, STYLE_CATEGORY_CD, STYLE_SIZE_CD, STYLE_SIZE_GROUP_CD, dr["STYLE_ID"].ToString(),false);
                Dto尺寸.build尺寸呈现dto(尺寸呈现dto, dataTable客户量体值);
                return 尺寸呈现dto;
            }


            throw new Exception("没有量体值");
        }

        public static void save设计点(String Style_Id, Dto尺寸 Dto尺寸)
        {
            SQLmtm.DoUpdate(
                "s_style_fit_r"
                , new string[] { "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" }
                , new string[] { "AUDIT_PHASE_CD-PHASE_CD_10", Dto尺寸.ITEM_CD, Dto尺寸.ITEM_VALUE, Dto尺寸.FIT_VALUE, Dto尺寸.FM_VALUE, "0", "1", "46", Dto尺寸.IN_VALUE, Dto尺寸.OUT_VALUE }
                , new string[] { "STYLE_ID" }
                , new string[] { Style_Id }
                );
        }
    }
}
