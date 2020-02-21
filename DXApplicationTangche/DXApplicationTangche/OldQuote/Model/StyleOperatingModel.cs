using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.Model
{
	/// <summary>
	/// StyleOperatingModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StyleOperatingModel
	{
		public StyleOperatingModel()
		{ }
		#region Model
		private int _operating_id;
		private int _contract_id;
		private int _order_id;
		private string _order_no;
		private string _order_type_cd;
		private int _style_id;
		private string _style_no;
		private string _style_kbn;
		private string _style_bar_code;
		private string _material_code;
		private int _operating_itme_id;
		private string _operating_code;
		private string _operating_value;
		private DateTime? _operating_start_date;
		private DateTime? _operating_end_date;
		private string _operating_status;
		private string _remarks;
		private string _order_remarks;
		private int _del_flg = 0;
		private int? _version = 1;
		private DateTime? _create_date;
		private int? _create_user;
		private DateTime? _update_date;
		private int? _update_user;
		private DateTime? _make_date;
		private int? _make_user;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int OPERATING_ID
		{
			set { _operating_id = value; }
			get { return _operating_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int CONTRACT_ID
		{
			set { _contract_id = value; }
			get { return _contract_id; }
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
		public string ORDER_TYPE_CD
		{
			set { _order_type_cd = value; }
			get { return _order_type_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int STYLE_ID
		{
			set { _style_id = value; }
			get { return _style_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string STYLE_NO
		{
			set { _style_no = value; }
			get { return _style_no; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string STYLE_KBN
		{
			set { _style_kbn = value; }
			get { return _style_kbn; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string STYLE_BAR_CODE
		{
			set { _style_bar_code = value; }
			get { return _style_bar_code; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string MATERIAL_CODE
		{
			set { _material_code = value; }
			get { return _material_code; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int OPERATING_ITME_ID
		{
			set { _operating_itme_id = value; }
			get { return _operating_itme_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPERATING_CODE
		{
			set { _operating_code = value; }
			get { return _operating_code; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPERATING_VALUE
		{
			set { _operating_value = value; }
			get { return _operating_value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OPERATING_START_DATE
		{
			set { _operating_start_date = value; }
			get { return _operating_start_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OPERATING_END_DATE
		{
			set { _operating_end_date = value; }
			get { return _operating_end_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPERATING_STATUS
		{
			set { _operating_status = value; }
			get { return _operating_status; }
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
		public string ORDER_REMARKS
		{
			set { _order_remarks = value; }
			get { return _order_remarks; }
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
		public int? CREATE_USER
		{
			set { _create_user = value; }
			get { return _create_user; }
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? UPDATE_DATE
		{
			set { _update_date = value; }
			get { return _update_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UPDATE_USER
		{
			set { _update_user = value; }
			get { return _update_user; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MAKE_DATE
		{
			set { _make_date = value; }
			get { return _make_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MAKE_USER
		{
			set { _make_user = value; }
			get { return _make_user; }
		}
		#endregion Model

	}
}
