﻿using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.UC.门店下单.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.款式异常.DTO
{
    public class 下线DTO
    {
        #region 变量
        private String id;  //  id
        private String code;    //  下线编码
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>(); //  下线款式一览
        private DataRow dataRow;
        #endregion

        #region 属性
        public string Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public List<款式图片一览Dto> 款式一览 { get => 款式图片一览Dtos; set => 款式图片一览Dtos = value; }
        #endregion


        public 下线DTO(List<款式图片一览Dto> 款式图片一览Dtos) {
            this.id = new FunctionHelper().Uuid;
            this.code = FunctionHelper.generateBillNo("t_rolloff","code","RF","0000");
            this.款式图片一览Dtos = 款式图片一览Dtos;
        }

        public 下线DTO(DataRow dataRow)
        {
            this.id = dataRow["id"].ToString();
            this.code = dataRow["code"].ToString();
        }

        public 下线DTO build款式图片(款式图片一览Dto 款式图片一览Dto) {
            this.款式图片一览Dtos.Add(款式图片一览Dto);
            return this;
        }
    }
}
