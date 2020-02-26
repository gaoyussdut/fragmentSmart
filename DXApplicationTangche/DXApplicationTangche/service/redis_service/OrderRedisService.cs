using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.DTO;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service.redis_service
{
    class OrderRedisService
    {
        private const String TASK = "_TASK";    //任务后缀
        public bool saveOrder(订单Model model, List<UserTaskDTO> userTaskDTOs) {
            //  生成订单kv
            bool orderNoCached = new RedisCacheHelper().StringSet(Convert.ToString(model.ORDER_INFO.ORDER_NUMBER), model.ORDER_ID);
            //  订单数据
            bool orderInfoCached = new RedisCacheHelper().StringSet(model.ORDER_ID, model.JsonSerialization());
            foreach (UserTaskDTO userTaskDTO in userTaskDTOs) {
                this.saveTask(model.ORDER_ID, userTaskDTO);
            }

            return orderNoCached && orderInfoCached;
        }

        /// <summary>
        /// 根据订单id取订单信息 TODO
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public String getOrderInfoById(String orderId) { 
            return new RedisCacheHelper().StringGet(orderId);
        }

        /// <summary>
        /// 根据订单号取订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public String getOrderInfoByOrderNo(String orderNo) {
            String ORDER_ID = new RedisCacheHelper().StringGet(orderNo);
            return this.getOrderInfoById(ORDER_ID);
        }

        /// <summary>
        /// 存任务
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userTaskDTO"></param>
        /// <returns></returns>
        public bool saveTask(String orderId,UserTaskDTO userTaskDTO) {
            //  保存数据
            bool dataCached = new RedisCacheHelper().StringSet(orderId + TASK, FunctionHelper.JsonSerialization(userTaskDTO));
            //  保存关系
            bool relationCached = new RedisCacheHelper().SetAdd(orderId + TASK, userTaskDTO.ID);
            return dataCached && relationCached;
        }

        /// <summary>
        /// 根据id取任务 TODO
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public String getTaskById(String taskId) {
            return new RedisCacheHelper().StringGet(taskId);
        }

        /// <summary>
        /// 根据订单id取任务列表 TODO    返回值
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public List<String> getTaskByOrderID(String ORDER_ID) {
            List<String> taskIds = new RedisCacheHelper().GetMembers(ORDER_ID + TASK); //  任务id列表
            List<String> taskInfo = new List<String>();
            foreach (String taskId in taskIds) {
                taskInfo.Add(this.getTaskById(taskId));
            }

            return taskInfo;
        }

        /// <summary>
        /// 根据订单id取任务列表 TODO    返回值
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public List<String> getTaskByOrderNo(String orderNo) {
            String ORDER_ID = new RedisCacheHelper().StringGet(orderNo);
            return this.getTaskByOrderID(ORDER_ID);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool removeTask(String orderId,String taskId) {
            bool relationDeleted = new RedisCacheHelper().SetRemove(orderId + TASK, taskId);
            bool dataDeleted = new RedisCacheHelper().KeyDelete(taskId);
            return relationDeleted && dataDeleted;
        }
    }
}
