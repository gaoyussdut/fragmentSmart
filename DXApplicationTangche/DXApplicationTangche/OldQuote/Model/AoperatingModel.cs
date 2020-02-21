using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.Model
{
	/// <summary>
	/// Aoperatingp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AoperatingModel
	{
		public AoperatingModel()
		{ }
		#region Model
		private int _item_id;
		private string _style_category_cd;
		private int? _item_sort;
		private string _item_name_cn;
		private string _item_short_name_cn;
		private string _item_name_jp;
		private string _item_short_name_jp;
		private string _item_name_en;
		private string _item_short_name_en;
		private int _item_show_flag;
		private string _item_ip;
		private int _enable_flag = 1;
		private int _delete_flag = 0;
		private string _remarks;
		private int? _version = 1;
		private DateTime? _create_date;
		private DateTime? _update_date;
		private int? _create_user;
		private int? _update_user;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ITEM_ID
		{
			set { _item_id = value; }
			get { return _item_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string STYLE_CATEGORY_CD
		{
			set { _style_category_cd = value; }
			get { return _style_category_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ITEM_SORT
		{
			set { _item_sort = value; }
			get { return _item_sort; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME_CN
		{
			set { _item_name_cn = value; }
			get { return _item_name_cn; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_SHORT_NAME_CN
		{
			set { _item_short_name_cn = value; }
			get { return _item_short_name_cn; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME_JP
		{
			set { _item_name_jp = value; }
			get { return _item_name_jp; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_SHORT_NAME_JP
		{
			set { _item_short_name_jp = value; }
			get { return _item_short_name_jp; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME_EN
		{
			set { _item_name_en = value; }
			get { return _item_name_en; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_SHORT_NAME_EN
		{
			set { _item_short_name_en = value; }
			get { return _item_short_name_en; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int ITEM_SHOW_FLAG
		{
			set { _item_show_flag = value; }
			get { return _item_show_flag; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_IP
		{
			set { _item_ip = value; }
			get { return _item_ip; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int ENABLE_FLAG
		{
			set { _enable_flag = value; }
			get { return _enable_flag; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int DELETE_FLAG
		{
			set { _delete_flag = value; }
			get { return _delete_flag; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string REMARKS
		{
			set { _remarks = value; }
			get { return _remarks; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VERSION
		{
			set { _version = value; }
			get { return _version; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_DATE
		{
			set { _create_date = value; }
			get { return _create_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UPDATE_DATE
		{
			set { _update_date = value; }
			get { return _update_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CREATE_USER
		{
			set { _create_user = value; }
			get { return _create_user; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UPDATE_USER
		{
			set { _update_user = value; }
			get { return _update_user; }
		}
		#endregion Model

	}
}
