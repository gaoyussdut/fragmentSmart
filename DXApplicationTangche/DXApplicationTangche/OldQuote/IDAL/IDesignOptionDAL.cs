using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.IDAL
{
    /// <summary>
    /// 接口层IDesignOptionDAL
    /// </summary>
    public interface IDesignOptionDAL
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int DESIGN_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Model.DesignOptionModel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.DesignOptionModel model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int DESIGN_ID);
        bool DeleteList(string DESIGN_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.DesignOptionModel GetModel(string ITEM_CD, string ITEM_VALUE);
        Model.DesignOptionModel DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 工序Id,从表a_operating_r获取工序项目个数个数
        /// </summary>
        DataSet GetItemValueByOperatingId(int operatingId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.DesignOptionModel GetModelByItemValue(string ITEM_VALUE);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
