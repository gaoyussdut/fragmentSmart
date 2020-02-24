using DXApplicationTangche.DTO;
using DXApplicationTangche.UC.款式异常;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 走redis
    /// </summary>
    class 生产工单Service
    {
        public 门店下单选款式Model model { get; set; }
        internal List<UserTaskDTO> UserTaskDTOs { get => userTaskDTOs; set => userTaskDTOs = value; }

        private UserTaskDTO currentUserTaskDTO;//  当前任务,持久化用（CUD）
        private List<UserTaskDTO> userTaskDTOs = new List<UserTaskDTO>();//  任务列表list，只用来查询

        /// <summary>
        /// 走redis
        /// </summary>
        /// <param name="ORDER_ID"></param>
        /// <param name="STYLE_FIT_CD"></param>
        /// <param name="STYLE_CATEGORY_CD"></param>
        /// <param name="STYLE_SIZE_CD"></param>
        /// <param name="STYLE_SIZE_GROUP_CD"></param>
        /// <param name="CUSTOMER_ID"></param>
        public 生产工单Service(String ORDER_ID, String STYLE_FIT_CD, String STYLE_CATEGORY_CD, String STYLE_SIZE_CD, String STYLE_SIZE_GROUP_CD, String CUSTOMER_ID) {
            this.model = new 门店下单选款式Model(ORDER_ID);
            this.model= this.model.build尺寸呈现(SizeService.getDto尺寸ByOrderId(ORDER_ID,  STYLE_FIT_CD,  STYLE_CATEGORY_CD,  STYLE_SIZE_CD,  STYLE_SIZE_GROUP_CD,  CUSTOMER_ID))
                    .build款式全尺寸(this.model.STYLE_ID)
                    .build设计点(this.model.STYLE_ID)
                    .build款式图片();
        }
        public 生产工单Service(String ORDER_ID)
        {
            this.model = new 门店下单选款式Model(ORDER_ID);
            this.model = this.model
                .build尺寸呈现(SizeService.getDto尺寸WithOrderId(ORDER_ID))
                .build款式全尺寸(this.model.STYLE_ID)
                .build设计点(this.model.STYLE_ID)
                .build款式图片();
            this.build任务列表();
        }
        /// <summary>
        /// 走redis
        /// </summary>
        /// <returns></returns>
        public 生产工单Service build任务列表() {
            this.UserTaskDTOs = TaskService.getUserTasksByOrderId(model.build订单Model().ORDER_ID);
            return this;
        }

        /// <summary>
        /// 创建当前任务
        /// </summary>
        /// <returns></returns>
        public 生产工单Service create当前任务(
                UserTaskDTO UserTaskDTO
            ) {
            this.currentUserTaskDTO = UserTaskDTO;
            //  持久化
            return this;
        }

        /// <summary>
        /// 更新当前任务
        /// </summary>
        /// <returns></returns>
        public 生产工单Service update当前任务(
            UserTaskDTO UserTaskDTO
            )
        {
            //  持久化
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
