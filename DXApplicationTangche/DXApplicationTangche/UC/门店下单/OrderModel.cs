using DXApplicationTangche.service;
using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
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

        public OrderModel buildAddOrderDtos(Dto定制下单 dto定制下单) {
            this.orderDtos.Add(new OrderDto(dto定制下单));
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

        public OrderModel buildCustomer()
        {
            foreach(OrderDto orderDto in this.OrderDtos)
            {
                orderDto.CUSTOMER_ID = CreateCustomer.cUSTOMER_ID.ToString();
                orderDto.CUSTOMER_COUNT_ID = CreateCustomer.customer_countid.ToString();
                orderDto.CUSTOMER_NAME = CreateCustomer.customer_name;
                orderDto.ADDRESS_ID = CreateCustomer.aDDRESS_ID.ToString();
            }
            return this;
        }
        /// <summary>
        /// 订单存入数据库
        /// </summary>
        public void SaveOrderInDatabase()
        {
            this.buildCustomer();
            foreach (OrderDto orderDto in OrderDtos)
            {
                OrderService.DynamicSaveOrder(orderDto);
            }
        }
    }
}
