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
    public class OrderRedisService
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
        public T getOrderInfoById<T>(String orderId) { 
            return FunctionHelper.JsonDeserialization<T>(new RedisCacheHelper().StringGet(orderId));
        }

        /// <summary>
        /// 根据订单号取订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public T getOrderInfoByOrderNo<T>(String orderNo) {
            String ORDER_ID = new RedisCacheHelper().StringGet(orderNo);
            return this.getOrderInfoById<T>(ORDER_ID);
        }

        /// <summary>
        /// 存任务
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userTaskDTO"></param>
        /// <returns></returns>
        public bool saveTask(String orderId,UserTaskDTO userTaskDTO) {
            //  保存数据
            bool dataCached = new RedisCacheHelper().StringSet(userTaskDTO.ID, FunctionHelper.JsonSerialization(userTaskDTO));
            //  保存关系
            bool relationCached = new RedisCacheHelper().SetAdd(orderId + TASK, userTaskDTO.ID);
            return dataCached && relationCached;
        }

        /// <summary>
        /// 根据id取任务 TODO
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public T getTaskById<T>(String taskId) {
            return FunctionHelper.JsonDeserialization<T>(new RedisCacheHelper().StringGet(taskId));
        }

        /// <summary>
        /// 根据订单id取任务列表 TODO    返回值
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public List<T> getTaskByOrderID<T>(String ORDER_ID) {
            List<String> taskIds = new RedisCacheHelper().GetMembers(ORDER_ID + TASK); //  任务id列表
            List<T> taskInfo = new List<T>();
            foreach (String taskId in taskIds) {
                taskInfo.Add(this.getTaskById<T>(taskId));
            }

            return taskInfo;
        }

        /// <summary>
        /// 根据订单NO取任务列表 TODO    返回值
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public List<T> getTaskByOrderNo<T>(String orderNo) {
            String ORDER_ID = new RedisCacheHelper().StringGet(orderNo);
            return this.getTaskByOrderID<T>(ORDER_ID);
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
