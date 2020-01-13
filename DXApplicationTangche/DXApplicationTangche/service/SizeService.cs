﻿using DiaoPaiDaYin;
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

    }
}