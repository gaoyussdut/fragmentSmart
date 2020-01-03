﻿using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.款式异常
{
    class 款式异常Model
    {
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();
        private List<款式图片一览Dto> 送审款式s = new List<款式图片一览Dto>();

        //  展示视图
        private List<款式图片一览Dto> views = new List<款式图片一览Dto>();
        //  服装种类
        private List<String> list服装种类 = new List<string>();
        //  年份
        private List<String> list年份 = new List<string>();

        public List<款式图片一览Dto> Views { get => views; set => views = value; }
        public List<string> List服装种类 { get => list服装种类; set => list服装种类 = value; }
        public List<string> List年份 { get => list年份; set => list年份 = value; }
        public List<款式图片一览Dto> 送审款式s1 { get => 送审款式s; set => 送审款式s = value; }

        /// <summary>
        /// 生成尺寸信息
        /// </summary>
        /// <param name="dataTable"></param>
        public void generateSize_Fit(DataTable dataTable) {
            Dictionary<String, List<String>> EGS_GROUP_SIZEs = new Dictionary<string, List<string>>();  //  数字尺码
            Dictionary<String, List<String>> IGS_GROUP_SIZEs = new Dictionary<string, List<string>>();  //  英文尺码

            const String EGS_GROUP_SIZEStr = "GROUP_SIZE-EGS_GROUP_SIZE";   //  数字尺码组
            const String IGS_GROUP_SIZEStr = "GROUP_SIZE-IGS_GROUP_SIZE";   //  英文尺码组
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (EGS_GROUP_SIZEStr.Equals(dataRow["SIZEGROUP_CD"].ToString()))
                {
                    //  数字尺码组
                    if (EGS_GROUP_SIZEs.ContainsKey(dataRow["FIT_CD"].ToString()))
                    {
                        EGS_GROUP_SIZEs[dataRow["FIT_CD"].ToString()]
                            .Add(
                                dataRow["SIZE_CD"].ToString().Replace("EGS_GROUP_SIZE-","")
                            );
                    }
                    else
                    {
                        EGS_GROUP_SIZEs.Add(
                            dataRow["FIT_CD"].ToString()    //  版型id
                            , new List<String>() { 
                                dataRow["SIZE_CD"].ToString().Replace("EGS_GROUP_SIZE-","")
                            }  //  尺码
                            );
                    }
                }
                else if (IGS_GROUP_SIZEStr.Equals(dataRow["SIZEGROUP_CD"]))
                {
                    //  英文尺码组
                    if (IGS_GROUP_SIZEs.ContainsKey(dataRow["FIT_CD"].ToString()))
                    {
                        IGS_GROUP_SIZEs[dataRow["FIT_CD"].ToString()]
                            .Add(
                                dataRow["SIZE_CD"].ToString().Replace("IGS_GROUP_SIZE-", "")
                            );
                    }
                    else
                    {
                        IGS_GROUP_SIZEs.Add(
                            dataRow["FIT_CD"].ToString()    //  版型id
                            , new List<String>() { 
                                dataRow["SIZE_CD"].ToString().Replace("IGS_GROUP_SIZE-", "")
                            }  //  尺码
                            );
                    }
                }
            }
            //  迭代更新尺寸信息
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                dto.build版型尺码(EGS_GROUP_SIZEs, IGS_GROUP_SIZEs);
            }
        }

        public 款式异常Model(List<款式图片一览Dto> 款式图片一览Dtos) {
            this.款式图片一览Dtos = 款式图片一览Dtos;
        }

        public 款式异常Model initData() {
            this.views.AddRange(this.款式图片一览Dtos);
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (!this.List服装种类.Contains(dto.STYLE_PUBLISH_CATEGORY_CD))
                {
                    this.List服装种类.Add(dto.STYLE_PUBLISH_CATEGORY_CD);
                }
                if (!this.List年份.Contains(dto.SYTLE_YEAR))
                {
                    this.List年份.Add(dto.SYTLE_YEAR);
                }
            }

            if (List年份.Count > 0 && List服装种类.Count > 0)
            {
                this.build款式异常Model(List年份[0], List服装种类[0]);
            }
            return this;
        }

        public 款式异常Model build款式异常Model(String 年份, String 服装种类) {
            this.Views.Clear();
            List<款式图片一览Dto> dtos = new List<款式图片一览Dto>();
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (dto.SYTLE_YEAR.Equals(年份) && dto.STYLE_PUBLISH_CATEGORY_CD.Equals(服装种类))
                {
                    dtos.Add(dto);
                }
            }
            this.Views = dtos;
            return this;
        }

        public 款式异常Model build送审款式(String style_id) {
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos) {
                if (style_id.Equals(dto.SYS_STYLE_ID)) {
                    if (this.送审款式s.Contains(dto))
                    {
                        throw new Exception(dto.STYLE_NAME_CN + "已在待审列表中");
                    }
                    else {
                        this.送审款式s.Add(dto);
                        break;
                    }
                }
            }
            return this;
        }

    }
}
