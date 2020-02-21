using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.Model
{
	/// <summary>
	/// PackageCustomModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PackageCustomModel
	{
		public PackageCustomModel()
		{ }
		#region Model
		private int _package_id;
		private string _package_no;
		private DateTime _delivery_date;
		private string _contract_id;
		private string _package_style;
		private string _carton_id;
		private decimal? _master_carton_quantity;
		private decimal? _small_box_quantity;
		private decimal? _package_net_weight;
		private decimal? _package_rough_weight;
		private decimal? _package_volume;
		private decimal? _package_style_quantity;
		private string _package_status = "0";
		private string _package_audit_status = "0";
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
		public int PACKAGE_ID
		{
			set { _package_id = value; }
			get { return _package_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PACKAGE_NO
		{
			set { _package_no = value; }
			get { return _package_no; }
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
		public string CONTRACT_ID
		{
			set { _contract_id = value; }
			get { return _contract_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PACKAGE_STYLE
		{
			set { _package_style = value; }
			get { return _package_style; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CARTON_ID
		{
			set { _carton_id = value; }
			get { return _carton_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MASTER_CARTON_QUANTITY
		{
			set { _master_carton_quantity = value; }
			get { return _master_carton_quantity; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SMALL_BOX_QUANTITY
		{
			set { _small_box_quantity = value; }
			get { return _small_box_quantity; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PACKAGE_NET_WEIGHT
		{
			set { _package_net_weight = value; }
			get { return _package_net_weight; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PACKAGE_ROUGH_WEIGHT
		{
			set { _package_rough_weight = value; }
			get { return _package_rough_weight; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PACKAGE_VOLUME
		{
			set { _package_volume = value; }
			get { return _package_volume; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PACKAGE_STYLE_QUANTITY
		{
			set { _package_style_quantity = value; }
			get { return _package_style_quantity; }
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
		public string PACKAGE_AUDIT_STATUS
		{
			set { _package_audit_status = value; }
			get { return _package_audit_status; }
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
