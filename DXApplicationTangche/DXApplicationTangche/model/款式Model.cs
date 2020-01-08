using DXApplicationTangche.DTO;
using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;

namespace DXApplicationTangche.UC.款式异常
{
    public class 款式Model
    {
        #region 变量
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();
        private List<款式图片一览Dto> 送审款式s = new List<款式图片一览Dto>();
        //  展示视图
        private List<款式图片一览Dto> views = new List<款式图片一览Dto>();
        //  服装种类
        private List<String> list服装种类 = new List<string>();
        //  年份
        private List<String> list年份 = new List<string>();
        #endregion

        #region 界面视图
        public List<款式图片一览Dto> Views { get => views; set => views = value; }
        public List<款式图片一览Dto> 送审款式 { get => 送审款式s; set => 送审款式s = value; }
        #endregion

        #region ComboBox视图
        public List<string> List服装种类 { get => list服装种类; set => list服装种类 = value; }
        public List<string> List年份 { get => list年份; set => list年份 = value; }
        #endregion

        #region 构造函数
        public 款式Model(List<款式图片一览Dto> 款式图片一览Dtos)
        {
            this.款式图片一览Dtos = 款式图片一览Dtos;
        }
        #endregion

        #region build方法
        /// <summary>
        /// 生成界面视图
        /// </summary>
        /// <returns></returns>
        public 款式Model buildView()
        {            
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
                this.buildView(List年份[0], List服装种类[0]);
            }
            else {
                this.views.Clear();
                this.views.AddRange(this.款式图片一览Dtos);
            }
            return this;
        }

        /// <summary>
        /// 生成界面视图
        /// </summary>
        /// <param name="年份"></param>
        /// <param name="服装种类"></param>
        /// <returns></returns>
        public 款式Model buildView(String 年份, String 服装种类)
        {
            this.Views.Clear();
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (dto.SYTLE_YEAR.Equals(年份) && dto.STYLE_PUBLISH_CATEGORY_CD.Equals(服装种类))
                {
                    this.Views.Add(dto);
                    continue;
                }
            }
            return this;
        }

        /// <summary>
        /// 生成送审的款式
        /// </summary>
        /// <param name="style_id"></param>
        /// <returns></returns>
        public 款式Model build送审款式(String style_id)
        {
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (style_id.Equals(dto.SYS_STYLE_ID))
                {
                    if (this.送审款式s.Contains(dto))
                    {
                        throw new Exception(dto.STYLE_NAME_CN + "已在待审列表中");
                    }
                    else
                    {
                        this.送审款式s.Add(dto);
                        dto.build面料();
                        break;
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 生成尺寸信息
        /// </summary>
        /// <param name="dataTable"></param>
        public void buildSizeFit(DataTable dataTable)
        {
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
                                dataRow["SIZE_CD"].ToString().Replace("EGS_GROUP_SIZE-", "")
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
        #endregion
    }

    public class 门店下单选款式Model {
        private List<款式图片Dto> 款式图片dtos = new List<款式图片Dto>();
        private 款式图片Dto 款式图片Dto;
        private DataTable 款式尺寸dt;
        private DataTable 选中尺寸dt;
        public List<款式图片Dto> 款式图片 { get => 款式图片dtos; set => 款式图片dtos = value; }
        public 款式图片Dto 选中款式 { get => 款式图片Dto; set => 款式图片Dto = value; }
        public DataTable 款式全尺寸 { get => 款式尺寸dt; set => 款式尺寸dt = value; }
        public DataTable 选中尺寸 { get => 选中尺寸dt; set => 选中尺寸dt = value; }

        public 门店下单选款式Model(String flag, int page) { 
            this.款式图片dtos = ImpService.initStyleInfo(flag, page);
        }
        public void build款式全尺寸(String styleid)
        {
            this.款式尺寸dt = ImpService.StyleCombobox(styleid);
        }
        public void build选中尺寸(String size,String styleid,DataTable dt)
        {
            this.选中尺寸dt = ImpService.StyleValue(size, styleid, dt);
        }
    }
    public class 面料Model
    {
        private List<面料图片DTo> 面料图片DTos = new List<面料图片DTo>();

        public 面料Model(String str, int page)
        {
            this.面料图片DTos = ImpService.GetMianLiao(str, page);
        }

        internal List<面料图片DTo> 面料卡s { get => 面料图片DTos; set => 面料图片DTos = value; }
    }
}
