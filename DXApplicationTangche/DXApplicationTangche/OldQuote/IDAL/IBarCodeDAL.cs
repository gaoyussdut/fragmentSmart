using DXApplicationTangche.OldQuote.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.IDAL
{
    public interface IBarCodeDAL
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(long QR_ID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(BarCodeModel model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(BarCodeModel model);

        /// <summary>
        /// 删除数据
        /// </summary>
        bool Delete(long QR_ID);

        bool DeleteList(string QR_IDlist);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BarCodeModel GetModel(long QR_ID);

        BarCodeModel DataRowToModel(DataRow row);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获取记录总数
        /// </summary>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        BarCodeModel GetModelByStr(string strwhere);

        /// <summary>
        /// 根据条形码，查询a_bar_code_p表，得到一个对象实体
        /// </summary>
        BarCodeModel GetModelByBarcodeNo(string barcodeNo);
        BarCodeModel GetModelByBarcodeNoforWashPrint(string barcodeNo);
        #endregion  成员方法
    }
}
