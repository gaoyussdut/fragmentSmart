using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.IDAL
{
	/// <summary>
	/// 接口层Loginuserp
	/// </summary>
	public interface ILoginUserDAL
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int LOGIN_USER_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Model.LoginUserModel model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.LoginUserModel model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int LOGIN_USER_ID);
		bool DeleteList(string LOGIN_USER_IDlist);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Model.LoginUserModel GetModel(int LOGIN_USER_ID);

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Model.LoginUserModel GetModelByBarCode(string USER_BARCODE);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		string GetModelByUpdateUserName(int UPDATE_USER);

		Model.LoginUserModel DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	}
}
