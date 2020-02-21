using DXApplicationTangche.IDAL;
using DXApplicationTangche.OldQuote.DALFactory;
using DXApplicationTangche.OldQuote.Untils;
using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.model
{
	/// <summary>
	/// OrderBLL
	/// </summary>
	public partial class OrderBLL
	{


		private readonly IOrderDAL dal = AbstractFactory.CreateOrderDAL();


		public OrderBLL()
		{ }
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ORDER_ID)
		{
			return dal.Exists(ORDER_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(OrderModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(OrderModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ORDER_ID)
		{

			return dal.Delete(ORDER_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ORDER_IDlist)
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(ORDER_IDlist, 0));
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public OrderModel GetModel(int ORDER_ID)
		{

			return dal.GetModel(ORDER_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public OrderModel GetModelByCache(int ORDER_ID)
		{

			string CacheKey = "OorderpModelModel-" + ORDER_ID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ORDER_ID);
					if (objModel != null)
					{
						int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch { }
			}
			return (OrderModel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<OrderModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<OrderModel> DataTableToList(DataTable dt)
		{
			List<OrderModel> modelList = new List<OrderModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				OrderModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
		}

		/// <summary>
		/// 根据oderNo更新一条数据
		/// </summary>
		public bool UpdateByOrderId(OrderModel orderModel)
		{
			return dal.UpdateByOrderId(orderModel);
		}

		/// <summary>
		/// 根据合同id更新一条数据
		/// </summary>
		public bool UpdateByContractId(int contractId)
		{
			return dal.UpdateByContractId(contractId);
		}

		/// <summary>
		/// 根据合同id更新一条数据
		/// </summary>
		public bool UpdateFinanceByContractId(int contractId, string status)
		{
			return dal.UpdateFinanceByContractId(contractId, status);
		}

		/// <summary>
		/// 根据条件得到一个对象实体
		/// </summary>
		public OrderModel GetModelByStr(string strWhere)
		{
			return dal.GetModelByStr(strWhere);
		}
		public int GetOrderCountByContractIdSum(int contractId)
		{
			return dal.GetOrderCountByContractIdSum(contractId);
		}
		public int GetOrderCountByContractId(int contractId)
		{
			return dal.GetOrderCountByContractId(contractId);
		}
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			return dal.GetList(PageSize,PageIndex,strWhere);
		}
        */
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
