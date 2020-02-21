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
	/// 接口层Aoperatingp
	/// </summary>
	public interface IAOperatingDAL
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ITEM_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(AoperatingModel model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(AoperatingModel model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ITEM_ID);
		bool DeleteList(string ITEM_IDlist);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		AoperatingModel GetModel(int ITEM_ID);
		Model.AoperatingModel DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);

		/// <summary>
		/// 获取排序后的获取数据列表
		/// </summary>
		DataSet GetdateOrderbyItemsort(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	}
}
