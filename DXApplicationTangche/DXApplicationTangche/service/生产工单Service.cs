using DXApplicationTangche.UC.款式异常;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    class 生产工单Service
    {
        public 门店下单选款式Model model { get; set; }
        //  当前任务,持久化用（CUD）
        //  任务列表list，只用来查询

        public 生产工单Service(String ORDER_ID, String STYLE_FIT_CD, String STYLE_CATEGORY_CD, String STYLE_SIZE_CD, String STYLE_SIZE_GROUP_CD, String CUSTOMER_ID) {
            this.model = new 门店下单选款式Model(ORDER_ID);
            this.model= this.model.build尺寸呈现(SizeService.getDto尺寸ByOrderId(ORDER_ID,  STYLE_FIT_CD,  STYLE_CATEGORY_CD,  STYLE_SIZE_CD,  STYLE_SIZE_GROUP_CD,  CUSTOMER_ID))
                    .build款式全尺寸(this.model.STYLE_ID)
                    .build设计点(this.model.STYLE_ID)
                    .build款式图片();
        }

        public 生产工单Service build任务列表() {

            String ORDER_ID = model.build订单Model().ORDER_ID;
            //  TODO
            return this;
        }

        /// <summary>
        /// 创建当前任务
        /// </summary>
        /// <returns></returns>
        public 生产工单Service create当前任务(
                //  TODO    任务类
            ) {
            return this;
        }

        /// <summary>
        /// 更新当前任务
        /// </summary>
        /// <returns></returns>
        public 生产工单Service update当前任务(
            //  TODO    任务类
            )
        {
            return this;
        }

        /// <summary>
        /// 作废当前任务
        /// </summary>
        /// <returns></returns>
        public 生产工单Service delete当前任务(
            //  TODO    任务类
            )
        {
            return this;
        }
    }
}
