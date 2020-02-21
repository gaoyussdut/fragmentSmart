using DXApplicationTangche.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAL
{
    /// <summary>
    /// 接口层IOrderBLL
    /// </summary>
    public interface IOrderDAL
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ORDER_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(OrderModel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(OrderModel model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ORDER_ID);
        bool DeleteList(string ORDER_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        OrderModel GetModel(int ORDER_ID);
        OrderModel DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);

        /// <summary>
        /// 根据oderNo更新一条数据
        /// </summary>
        bool UpdateByOrderId(OrderModel orderModel);
        /// <summary>
        /// 根据合同获取订单件数
        /// </summary>
        int GetOrderCountByContractIdSum(int contractId);
        int GetOrderCountByContractId(int contractId);
        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        OrderModel GetModelByStr(string strWhere);
        bool UpdateByContractId(int contractId);
        bool UpdateFinanceByContractId(int contractId, string status);

        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
