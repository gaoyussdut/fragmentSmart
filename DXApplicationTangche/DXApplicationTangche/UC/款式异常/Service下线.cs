using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.款式异常
{
    public class Service下线
    {

        /// <summary>
        /// 产品下线方法
        /// </summary>
        /// <param name="下线DTO"></param>
        internal static void Func产品下线(下线DTO 下线DTO)
        {
            //  审核表
            String sql = "INSERT INTO t_rolloff ( id, create_date, CODE, flag )\n" +
                "VALUES\n" +
                "	( '" + 下线DTO.Id + "', NOW( ), '" + 下线DTO.Code + "', 0 );";
            SQLmtm.ExecuteSql(sql);
            //  关联表
            foreach (DXApplicationTangche.UC.门店下单.DTO.款式图片一览Dto 款式图片一览Dto in 下线DTO.款式一览)
            {
                sql = "INSERT INTO r_rolloff_style ( ROLLOFF_ID, STYLE_ID )\n" +
                    "VALUES\n" +
                    "	( '" + 下线DTO.Id + "', '" + 款式图片一览Dto.SYS_STYLE_ID + "' );";
                SQLmtm.ExecuteSql(sql);
            }

        }
    }
}
