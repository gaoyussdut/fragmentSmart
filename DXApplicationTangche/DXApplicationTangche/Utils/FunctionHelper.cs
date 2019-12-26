using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.XtraGrid.Demos.util
{
    class FunctionHelper
    {

        private static DateTime? _systemTime = null;

        public static DateTime SystemTime
        {
            get { return _systemTime.HasValue ? _systemTime.Value : DateTime.Now; }
            set { _systemTime = value; }
        }

        #region 日期操作

        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }

        /// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 取得上个月第一天
        /// </summary>
        /// <param name="datetime">要取得上个月第一天的当前时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfPreviousMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(-1);
        }

        /// <summary>
        /// 取得上个月的最后一天
        /// </summary>
        /// <param name="datetime">要取得上个月最后一天的当前时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfPrdviousMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddDays(-1);
        }

        public static DateTime FirstDateOfQuarter(DateTime datetime)
        {
            return datetime.AddMonths(0 - (datetime.Month - 1) % 3).AddDays(1 - datetime.Day);
        }

        public static DateTime LastDateOfQuarter(DateTime datetime)
        {
            return FirstDateOfQuarter(datetime).AddMonths(3).AddDays(-1);
        }

        public static DateTime FirstDayOfLastQuarter(DateTime datetime)
        {
            return DateTime.Parse(datetime.AddMonths(-3 - ((datetime.Month - 1) % 3)).ToString("yyyy/MM/01"));
        }

        public static DateTime LastDayOfLastQuarter(DateTime datetime)
        {
            return DateTime.Parse(SystemTime.AddMonths(0 - ((SystemTime.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1);
        }

        /// <summary>
        /// 获取指定周数的开始日期(周一)和结束日期（周末）
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="index">周数</param>
        /// <param name="first">当此方法返回时，则包含参数 year 和 index 指定的周的开始日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。</param>
        /// <param name="last">当此方法返回时，则包含参数 year 和 index 指定的周的结束日期的 System.DateTime 值；如果失败，则为 System.DateTime.MinValue。</param>
        /// <returns></returns>
        public static bool GetDaysOfWeeks(int year, int index, out DateTime first, out DateTime last)
        {
            first = DateTime.MinValue;
            last = DateTime.MinValue;
            if (year < 1700 || year > 9999)
            {
                //"年份超限"
                return false;
            }
            if (index < 1 || index > 53)
            {
                //"周数错误"
                return false;
            }
            DateTime startDay = new DateTime(year, 1, 1);  //该年第一天
            DateTime endDay = new DateTime(year + 1, 1, 1).AddMilliseconds(-1);
            int dayOfWeek = 0;
            if (Convert.ToInt32(startDay.DayOfWeek.ToString("d")) > 0)
                dayOfWeek = Convert.ToInt32(startDay.DayOfWeek.ToString("d"));  //该年第一天为星期几,星期天为7

            if (dayOfWeek == 0) { dayOfWeek = 7; }
            if (index == 1)
            {
                first = startDay;
                if (dayOfWeek == 7)
                {
                    last = first;
                }
                else
                {
                    last = startDay.AddDays((7 - dayOfWeek));
                }
            }
            else
            {
                first = startDay.AddDays((7 - dayOfWeek + 1) + (index - 2) * 7); //index周的起始日期
                last = first.AddDays(6);
                if (last > endDay)
                {
                    last = endDay;
                }
            }
            if (first > endDay)  //startDayOfWeeks不在该年范围内
            {
                //"输入周数大于本年最大周数";
                return false;
            }
            return true;
        }

        //计算周一至周日的周数
        //public static int GetWeekOfYear(DateTime dt)
        //{
        //    GregorianCalendar gc = new GregorianCalendar();
        //    int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        //    return weekOfYear;
        //}
        //计算周一至周日的周数
        public static int WeekOfYear1(DateTime dt)
        {
            //找到今年的第一天是周几
            int firstWeekend = Convert.ToInt32(DateTime.Parse(dt.Year + "-1-1").DayOfWeek);

            //获取第一周的差额,如果是周日，则firstWeekend为0，第一周也就是从周天开始的。
            int weekDay = firstWeekend == 0 ? 1 : (7 - firstWeekend + 1);

            //获取今天是一年当中的第几天
            int currentDay = dt.DayOfYear;

            //（今天 减去 第一周周末）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
            //    刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            int current_week = Convert.ToInt32(Math.Ceiling((currentDay - weekDay) / 7.0)) + 1;
            return current_week;
        }
        #endregion

        #region 取值操作

        public static string GetValue(object o, string def = "")
        {
            if (o != null)
            {
                if (o.ToString().Trim() != "")
                {
                    return o.ToString().Trim();
                }
                else
                {
                    return def;
                }
            }
            else
            {
                return def;
            }
        }

        public static string GetDateTimeValue(object o, string format = "yyyy/MM/dd")
        {
            if (o != null)
            {
                if (o.ToString().Trim() != "")
                {
                    DateTime v = SystemTime;
                    if (DateTime.TryParse(o.ToString().Trim(), out v))
                    {
                        return v.ToString(format);
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public static string GetNumberValue(object o, string def = "")
        {
            if (o != null)
            {
                if (o.ToString().Trim() != "")
                {
                    decimal v = 0;
                    if (decimal.TryParse(o.ToString().Trim(), out v))
                    {
                        return v.ToString().Trim();
                    }
                    else
                    {
                        return def;
                    }
                }
                else
                {
                    return def;
                }
            }
            else
            {
                return def;
            }
        }

        public static string GetBooleanValue(object o, string def = "")
        {
            if (o != null)
            {
                if (o.ToString().Trim() != "")
                {
                    bool v = false;
                    if (bool.TryParse(o.ToString().Trim(), out v))
                    {
                        return v.ToString().Trim();
                    }
                    else
                    {
                        return def;
                    }
                }
                else
                {
                    return def;
                }
            }
            else
            {
                return def;
            }
        }
        #endregion

        #region 单号
        /// <summary>
        /// 取单号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="billNoField">单号字段</param>
        /// <param name="formatStr">格式化后缀字段</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static String generateBillNo(String tableName,String billNoField,String prefix, String formatStr) {
            String sql = "select right(max("+ billNoField + "),"+ formatStr.Length + ")+1  as code from "+ tableName +" "
                + " where left(" + billNoField + ", "+ (prefix .Length + 8) + ") = CONCAT('"+ prefix + "', DATE_FORMAT(NOW(), '%Y%m%d'))";
            DataTable dataTable = SQLmtm.GetDataTable(sql);
            if (dataTable.Rows.Count == 0)
            {
                sql = "select CONCAT('"+ prefix + "',DATE_FORMAT(NOW(), '%Y%m%d') , '" + string.Format("{0:" + formatStr + "}", 1) + "') as code";
                return SQLmtm.GetDataTable(sql).Rows[0]["code"].ToString();
            }
            else if (String.IsNullOrEmpty(dataTable.Rows[0]["code"].ToString()))
            {
                sql = "select CONCAT('"+ prefix + "',DATE_FORMAT(NOW(), '%Y%m%d') , '" + string.Format("{0:" + formatStr + "}", 1) + "') as code";
                return SQLmtm.GetDataTable(sql).Rows[0]["code"].ToString();
            }
            else
            {
                String suffix = string.Format("{0:"+ formatStr + "}", Convert.ToInt16(dataTable.Rows[0]["code"].ToString()));
                sql = "select CONCAT('"+ prefix + "',DATE_FORMAT(NOW(), '%Y%m%d') , '" + suffix + "') as code";
                return SQLmtm.GetDataTable(sql).Rows[0]["code"].ToString();
            }
        }
        #endregion
    }
}
