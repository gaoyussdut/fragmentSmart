using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.Model
{
	/// <summary>
	/// PackageCustomDetailsModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PackageCustomDetailsModel
	{
		public PackageCustomDetailsModel()
		{ }
		#region Model
		private int _package_details_id;
		private int _package_id;
		private string _master_carton_no;
		private string _small_box_no;
		private DateTime _delivery_date;
		private int _contract_id;
		private int _order_id;
		private int _style_id;
		private string _shipping_destination;
		private string _country;
		private string _transit_group;
		private string _shop_name;
		private string _style_composition;
		private int? _sleeve_flag;
		private string _urgent_cd;
		private string _package_status = "0";
		private string _remark;
		private int? _del_flg = 0;
		private int? _version = 1;
		private int? _create_user_id;
		private DateTime? _create_date_time;
		private int? _update_user_id;
		private DateTime? _update_date_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int PACKAGE_DETAILS_ID
		{
			set { _package_details_id = value; }
			get { return _package_details_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int PACKAGE_ID
		{
			set { _package_id = value; }
			get { return _package_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string MASTER_CARTON_NO
		{
			set { _master_carton_no = value; }
			get { return _master_carton_no; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMALL_BOX_NO
		{
			set { _small_box_no = value; }
			get { return _small_box_no; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime DELIVERY_DATE
		{
			set { _delivery_date = value; }
			get { return _delivery_date; }
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
		public int STYLE_ID
		{
			set { _style_id = value; }
			get { return _style_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SHIPPING_DESTINATION
		{
			set { _shipping_destination = value; }
			get { return _shipping_destination; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string COUNTRY
		{
			set { _country = value; }
			get { return _country; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string TRANSIT_GROUP
		{
			set { _transit_group = value; }
			get { return _transit_group; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_NAME
		{
			set { _shop_name = value; }
			get { return _shop_name; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string STYLE_COMPOSITION
		{
			set { _style_composition = value; }
			get { return _style_composition; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SLEEVE_FLAG
		{
			set { _sleeve_flag = value; }
			get { return _sleeve_flag; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string URGENT_CD
		{
			set { _urgent_cd = value; }
			get { return _urgent_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PACKAGE_STATUS
		{
			set { _package_status = value; }
			get { return _package_status; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string REMARK
		{
			set { _remark = value; }
			get { return _remark; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DEL_FLG
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
