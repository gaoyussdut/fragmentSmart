using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 下线服务
    /// </summary>
    public class RollOffService
    {
        /// <summary>
        /// 取得所有已下线DTO
        /// </summary>
        /// <returns></returns>
        public static List<下线DTO> getAll下线DTO() {
            String sql = "SELECT\n" +
                "	id,\n" +
                "code \n" +
                "FROM\n" +
                "	t_rolloff \n" +
                "WHERE\n" +
                "	flag = 0";
            List<下线DTO> 下线DTOs = new List<下线DTO>();

            DataTable dataTable = SQLmtm.GetDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                下线DTOs.Add(new 下线DTO(dataRow));
            }
            return 下线DTOs;
        }

        /// <summary>
        /// 返回值：K：下线id，V：款式list
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static Dictionary<String,List<String>> getStyleRelationById(List<String> ids) {
            String sql = "SELECT\n" +
                "	ROLLOFF_ID,\n" +
                "	STYLE_ID \n" +
                "FROM\n" +
                "	r_rolloff_style \n" +
                "WHERE\n" +
                "	ROLLOFF_ID IN ( '"+String.Join("','",ids)+"' )";

            Dictionary<String, List<String>> rtn = new Dictionary<String, List<String>>();
            DataTable dataTable = SQLmtm.GetDataTable(sql);

            foreach (DataRow dataRow in dataTable.Rows) {
                if (rtn.ContainsKey(dataRow["ROLLOFF_ID"].ToString()))
                {
                    //  key已经存在
                    if (!rtn[dataRow["ROLLOFF_ID"].ToString()].Contains(dataRow["STYLE_ID"].ToString())) {
                        //  加入新的style
                        rtn[dataRow["ROLLOFF_ID"].ToString()].Add(dataRow["STYLE_ID"].ToString());
                    }
                }
                else {
                    //  新增key
                    rtn.Add(dataRow["ROLLOFF_ID"].ToString(), new List<string>() { dataRow["STYLE_ID"].ToString() });
                }
            }
            return rtn;
        }

        /// <summary>
        /// 执行下线
        /// </summary>
        /// <param name="下线DTOs"></param>
        public static void doRollOff(List<下线DTO> 下线DTOs) {
            //  执行款式下线
            List<String> 下线StyleIds = new List<string>();
            List<String> 下线logIds = new List<string>();
            foreach (下线DTO 下线DTO in 下线DTOs) {
                foreach (DXApplicationTangche.UC.门店下单.DTO.款式图片一览Dto 款式图片一览Dto in 下线DTO.款式一览) {
                    下线StyleIds.Add(款式图片一览Dto.SYS_STYLE_ID);
                }
                下线logIds.Add(下线DTO.Id);
            }
            String sql = "UPDATE s_style_p \n" +
                "SET ENABLE_FLAG = 0 \n" +
                "WHERE\n" +
                "	SYS_STYLE_ID IN ( '"+String.Join("','", 下线StyleIds) +"' );";
            SQLmtm.ExecuteSql(sql);
            //  log变更
            sql = "update t_rolloff set flag = 1 where id in ('" + String.Join("','", 下线logIds) + "');";
            SQLmtm.ExecuteSql(sql);
        }
    }
}
