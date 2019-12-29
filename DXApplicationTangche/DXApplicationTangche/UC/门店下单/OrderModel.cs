using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单
{
    /// <summary>
    /// 门店下单充血模型
    /// </summary>
    class OrderModel
    {
        private List<OrderDto> orderDtos = new List<OrderDto>();

        #region 属性
        internal List<OrderDto> OrderDtos { get => orderDtos; set => orderDtos = value; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="CUSTOMER_ID"></param>
        /// <param name="shop_id"></param>
        /// <param name="shop_name"></param>
        /// <param name="style_id"></param>
        /// <param name="ORDER_NO"></param>
        /// <param name="ORDER_NUMBER"></param>
        /// <param name="ORDER_DATE"></param>
        /// <param name="STYLE_SIZE_CD"></param>
        /// <param name="STYLE_NAME_CN"></param>
        /// <param name="SYTLE_YEAR"></param>
        /// <param name="SYTLE_SEASON"></param>
        /// <param name="REF_STYLE_ID"></param>
        /// <param name="SYTLE_FABRIC_ID"></param>
        /// <param name="MATERIAL_NAME_CN"></param>
        /// <param name="MATERIAL_COLOR"></param>
        /// <param name="STYLE_PUBLISH_CATEGORY_CD"></param>
        /// <param name="ORDER_TYPE"></param>
        /// <returns></returns>
        public OrderModel buildAddOrderDtos(String CUSTOMER_ID, String shop_id, String shop_name, String style_id, String ORDER_NO, int ORDER_NUMBER, DateTime ORDER_DATE, String STYLE_SIZE_CD, String STYLE_NAME_CN, String SYTLE_YEAR, String SYTLE_SEASON, String REF_STYLE_ID, String SYTLE_FABRIC_ID, String MATERIAL_NAME_CN, String MATERIAL_COLOR, String STYLE_PUBLISH_CATEGORY_CD, int ORDER_TYPE,String PictureName) {
            this.orderDtos.Add(new OrderDto(CUSTOMER_ID, shop_id, shop_name, style_id, ORDER_NO, ORDER_NUMBER, ORDER_DATE, STYLE_SIZE_CD, STYLE_NAME_CN, SYTLE_YEAR, SYTLE_SEASON, REF_STYLE_ID, SYTLE_FABRIC_ID, MATERIAL_NAME_CN, MATERIAL_COLOR, STYLE_PUBLISH_CATEGORY_CD, ORDER_TYPE, PictureName));
            return this;
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderModel buildDeletaOrderDtos(String id) {
            foreach (OrderDto orderDto in this.OrderDtos) {
                if (id.Equals(orderDto.ID)) {
                    this.OrderDtos.Remove(orderDto);
                    return this;
                }
            }
            return this;
        }
    }
}
