using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.IDAL
{
    /// <summary>
	/// 接口层StyleOperatingModel
	/// </summary>
	public interface IStyleOperatingDAL
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int OPERATING_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Model.StyleOperatingModel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.StyleOperatingModel model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int OPERATING_ID);
        bool DeleteList(string OPERATING_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.DesignOptionModel GetOptionModel(int styleId, String itemValue);
        Model.StyleOperatingModel GetModel(int OPERATING_ID);
        Model.StyleOperatingModel DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表private System.Windows.Forms.Label 
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        int GetRecordCount(string strWhere);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateByItemId(Model.StyleOperatingModel model);
        /// <summary>
        /// 更新barcode获取订单Id
        /// </summary>
        int GetOrderIdByBarcode(string styleBarCode);

        /// <summary>
        /// 获根据用户名和工序Id获取生产时间
        /// </summary>
        DateTime GetMakeDateByUSerOrderNo(Model.StyleOperatingModel model);


        /// <summary>
        /// 根据barCode和工序Id获取实体类
        /// </summary>
        Model.StyleOperatingModel GetModeByStr(string strWhere);
        /// <summary>
        /// 工序Id,从表a_operating_r获取工序项目个数个数
        /// </summary>
        int GetItemCountByOperatingId(int operatingId);

        /// <summary>
        /// 从表a_operating_r获取工序Id
        /// </summary>
        DataSet GetOperatingId();

        string GetFitTypeByStyleId(int styleId);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
