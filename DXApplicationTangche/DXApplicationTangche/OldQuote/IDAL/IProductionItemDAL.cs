using DXApplicationTangche.OldQuote.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.IDAL
{
	/// <summary>
	/// 接口层Productionitems
	/// </summary>
	public interface IProductionItemDAL
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int PRO_ITEM_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(ProductionItemModel model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(ProductionItemModel model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int PRO_ITEM_ID);
		bool DeleteList(string PRO_ITEM_IDlist);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		ProductionItemModel GetModel(int PRO_ITEM_ID);
		ProductionItemModel DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);


		/// <summary>
		/// 更新工序id和订单id更新数据
		/// </summary>
		bool UpdateByOrderItemId(ProductionItemModel model);

		/// <summary>
		/// 根据员工号条码号得到一个对象实体
		/// </summary>
		ProductionItemModel GetModelBybarcodeMakeUser(string strWhere);

		/// <summary>
		/// 通过barCode从生产制单信息管理表里面获取PRODUCTION_ID
		/// </summary>
		int GetProductionNoBybarCode(string strWhere);

		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	}
}
