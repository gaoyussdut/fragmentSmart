using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.Model
{
	/// <summary>
	/// Productionitems:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductionItemModel
	{
		public ProductionItemModel()
		{ }
		#region Model
		private int _pro_item_id;
		private int _production_id;
		private string _production_no;
		private int _order_id;
		private string _order_no;
		private string _bar_code;
		private int _operating_id;
		private int? _make_user_id;
		private string _process_color_cd;
		private string _process_color_name;
		private string _process_size_cd;
		private decimal? _process_number;
		private int? _user_group_id;
		private string _process_status = "1";
		private string _settle_flag = "1";
		private string _remarks;
		private int? _version = 1;
		private int _del_flg = 0;
		private int? _create_user_id;
		private DateTime? _create_date_time;
		private int? _update_user_id;
		private DateTime? _update_date_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int PRO_ITEM_ID
		{
			set { _pro_item_id = value; }
			get { return _pro_item_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int PRODUCTION_ID
		{
			set { _production_id = value; }
			get { return _production_id; }
		}
		public string PRODUCTION_NO
		{
			set { _production_no = value; }
			get { return _production_no; }
		}
		public string BAR_CODE
		{
			set { _bar_code = value; }
			get { return _bar_code; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_ID
		{
			set { _order_id = value; }
			get { return _order_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_NO
		{
			set { _order_no = value; }
			get { return _order_no; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int OPERATING_ID
		{
			set { _operating_id = value; }
			get { return _operating_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MAKE_USER_ID
		{
			set { _make_user_id = value; }
			get { return _make_user_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PROCESS_COLOR_CD
		{
			set { _process_color_cd = value; }
			get { return _process_color_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PROCESS_COLOR_NAME
		{
			set { _process_color_name = value; }
			get { return _process_color_name; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PROCESS_SIZE_CD
		{
			set { _process_size_cd = value; }
			get { return _process_size_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PROCESS_NUMBER
		{
			set { _process_number = value; }
			get { return _process_number; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? USER_GROUP_ID
		{
			set { _user_group_id = value; }
			get { return _user_group_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PROCESS_STATUS
		{
			set { _process_status = value; }
			get { return _process_status; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SETTLE_FLAG
		{
			set { _settle_flag = value; }
			get { return _settle_flag; }
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
		public int DEL_FLG
		{
			set { _del_flg = value; }
			get { return _del_flg; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CREATE_USER_ID
		{
			set { _create_user_id = value; }
			get { return _create_user_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set { _create_date_time = value; }
			get { return _create_date_time; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UPDATE_USER_ID
		{
			set { _update_user_id = value; }
			get { return _update_user_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UPDATE_DATE_TIME
		{
			set { _update_date_time = value; }
			get { return _update_date_time; }
		}
		#endregion Model

	}
}
