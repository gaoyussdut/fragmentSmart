using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.model
{
	/// <summary>
	/// OrderModel:定制订单实体类
	/// </summary>
	[Serializable]
	public partial class OrderModel
	{
		public OrderModel()
		{ }
		#region Model
		private int _order_id;
		private string _order_no;
		private string _order_type_cd;
		private int? _shop_id;
		private string _shop_name;
		private string _custom_order_no;
		private string _custom_name;
		private string _custom_make_shirt;
		private string _transit_group;
		private string _country;
		private int? _sleeve_flag;
		private int? _customer_id;
		private string _customer_name;
		private string _factory_id;
		private int? _style_id;
		private int? _ref_order_id;
		private string _special_order;
		private string _tryon_order;
		private int? _fit_style_size;
		private int? _tailor_id;
		private string _shipping_destination;
		private DateTime? _order_date;
		private DateTime? _payment_date;
		private DateTime? _payment_confirm_date;
		private DateTime? _order_accept_date;
		private DateTime? _order_pro_start_date;
		private DateTime? _order_pro_end_date;
		private DateTime? _order_pack_date;
		private DateTime? _order_shipments_date;
		private DateTime? _target_date;
		private DateTime? _real_date;
		private string _order_status_cd;
		private string _order_produce_status_cd;
		private string _order_qc34;
		private string _order_qc35;
		private string _order_qc36;
		private string _order_qc37;
		private decimal? _order_number;
		private decimal? _order_material_cost;
		private decimal? _order_design_cost;
		private decimal? _order_process_cost;
		private decimal? _order_pack_cost = 0.000M;
		private decimal? _order_express_cost = 0.000M;
		private decimal? _order_sell_account;
		private decimal? _order_other_cost = 0.000M;
		private string _urgent_cd;
		private string _remarks;
		private int _delete_flag = 0;
		private int _version = 1;
		private DateTime? _create_date;
		private DateTime? _update_date;
		private int? _create_user;
		private int? _update_user;
		/// <summary>
		/// auto_increment
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
		public int? SHOP_ID
		{
			set { _shop_id = value; }
			get { return _shop_id; }
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
		public string CUSTOM_ORDER_NO
		{
			set { _custom_order_no = value; }
			get { return _custom_order_no; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CUSTOM_NAME
		{
			set { _custom_name = value; }
			get { return _custom_name; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CUSTOM_MAKE_SHIRT
		{
			set { _custom_make_shirt = value; }
			get { return _custom_make_shirt; }
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
		public string COUNTRY
		{
			set { _country = value; }
			get { return _country; }
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
		public int? CUSTOMER_ID
		{
			set { _customer_id = value; }
			get { return _customer_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CUSTOMER_NAME
		{
			set { _customer_name = value; }
			get { return _customer_name; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string FACTORY_ID
		{
			set { _factory_id = value; }
			get { return _factory_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? STYLE_ID
		{
			set { _style_id = value; }
			get { return _style_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? REF_ORDER_ID
		{
			set { _ref_order_id = value; }
			get { return _ref_order_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPECIAL_ORDER
		{
			set { _special_order = value; }
			get { return _special_order; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string TRYON_ORDER
		{
			set { _tryon_order = value; }
			get { return _tryon_order; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FIT_STYLE_SIZE
		{
			set { _fit_style_size = value; }
			get { return _fit_style_size; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TAILOR_ID
		{
			set { _tailor_id = value; }
			get { return _tailor_id; }
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
		public DateTime? ORDER_DATE
		{
			set { _order_date = value; }
			get { return _order_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PAYMENT_DATE
		{
			set { _payment_date = value; }
			get { return _payment_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PAYMENT_CONFIRM_DATE
		{
			set { _payment_confirm_date = value; }
			get { return _payment_confirm_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ORDER_ACCEPT_DATE
		{
			set { _order_accept_date = value; }
			get { return _order_accept_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ORDER_PRO_START_DATE
		{
			set { _order_pro_start_date = value; }
			get { return _order_pro_start_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ORDER_PRO_END_DATE
		{
			set { _order_pro_end_date = value; }
			get { return _order_pro_end_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ORDER_PACK_DATE
		{
			set { _order_pack_date = value; }
			get { return _order_pack_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ORDER_SHIPMENTS_DATE
		{
			set { _order_shipments_date = value; }
			get { return _order_shipments_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TARGET_DATE
		{
			set { _target_date = value; }
			get { return _target_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REAL_DATE
		{
			set { _real_date = value; }
			get { return _real_date; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_STATUS_CD
		{
			set { _order_status_cd = value; }
			get { return _order_status_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_PRODUCE_STATUS_CD
		{
			set { _order_produce_status_cd = value; }
			get { return _order_produce_status_cd; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_QC34
		{
			set { _order_qc34 = value; }
			get { return _order_qc34; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_QC35
		{
			set { _order_qc35 = value; }
			get { return _order_qc35; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_QC36
		{
			set { _order_qc36 = value; }
			get { return _order_qc36; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_QC37
		{
			set { _order_qc37 = value; }
			get { return _order_qc37; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_NUMBER
		{
			set { _order_number = value; }
			get { return _order_number; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_MATERIAL_COST
		{
			set { _order_material_cost = value; }
			get { return _order_material_cost; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_DESIGN_COST
		{
			set { _order_design_cost = value; }
			get { return _order_design_cost; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_PROCESS_COST
		{
			set { _order_process_cost = value; }
			get { return _order_process_cost; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_PACK_COST
		{
			set { _order_pack_cost = value; }
			get { return _order_pack_cost; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_EXPRESS_COST
		{
			set { _order_express_cost = value; }
			get { return _order_express_cost; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_SELL_ACCOUNT
		{
			set { _order_sell_account = value; }
			get { return _order_sell_account; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ORDER_OTHER_COST
		{
			set { _order_other_cost = value; }
			get { return _order_other_cost; }
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
		public string REMARKS
		{
			set { _remarks = value; }
			get { return _remarks; }
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
		public int VERSION
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
