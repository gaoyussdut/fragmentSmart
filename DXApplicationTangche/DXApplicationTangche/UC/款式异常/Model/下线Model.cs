using DXApplicationTangche.service;
using DXApplicationTangche.UC.款式异常.DTO;
using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.款式异常.Model
{
    class 下线Model
    {
        private List<下线DTO> 下线DTOs = new List<下线DTO>(); //  下线审核列表
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>(); //  下线款式一览

        public List<款式图片一览Dto> 款式一览 { get => 款式图片一览Dtos; set => 款式图片一览Dtos = value; }

        /// <summary>
        /// 初始化下线列表
        /// </summary>
        /// <param name="dataTable"></param>
        public 下线Model() {
            this.initData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void initData() {
            this.下线DTOs = RollOffService.getAll下线DTO();

            //  下线id列表
            List<String> 下线ids = new List<string>();
            foreach (下线DTO 下线DTO in this.下线DTOs)
            {
                下线ids.Add(下线DTO.Id);
            }
            //  K：下线id，V：款式list
            Dictionary<String, List<String>> idAndStyles = RollOffService.getStyleRelationById(下线ids);

            //  款式id列标
            List<String> 款式ids = new List<string>();
            foreach (List<String> v in idAndStyles.Values)
            {
                款式ids.AddRange(v);
            }

            //  获取所有款式图片
            this.款式图片一览Dtos = StyleService.getStyleByIds(款式ids);

            //  循环构造图片信息
            foreach (下线DTO 下线DTO in this.下线DTOs)
            {
                List<String> styles = idAndStyles[下线DTO.Id];    //  款式id列表
                foreach (款式图片一览Dto 款式图片一览Dto in this.款式图片一览Dtos)
                {
                    if (styles.Contains(款式图片一览Dto.SYS_STYLE_ID))
                    {
                        下线DTO.build款式图片(款式图片一览Dto);
                    }
                }
            }
        }

        /// <summary>
        /// 执行下线
        /// </summary>
        public void doRollOff(){
            /// 执行下线
            RollOffService.doRollOff(this.下线DTOs);
            //  重新初始化数据
            this.initData();
        }
    }
}
