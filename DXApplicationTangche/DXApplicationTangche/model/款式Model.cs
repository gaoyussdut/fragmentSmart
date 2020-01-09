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
        #region 变量
        private List<款式图片Dto> 款式图片dtos = new List<款式图片Dto>();
        private 款式图片Dto 款式图片Dto;
        private DataTable 款式尺寸dt;
        private DataTable 选中尺寸dt;
        public Dto定制下单 Dto定制下单=new Dto定制下单();
        #endregion

        #region 属性
        public List<款式图片Dto> 款式图片 { get => 款式图片dtos; set => 款式图片dtos = value; }
        public DataTable 选中尺寸 { get => 选中尺寸dt; set => 选中尺寸dt = value; }
        #endregion

        #region 构造函数
        public 门店下单选款式Model(String flag, int page)
        {
            this.款式图片dtos = ImpService.initStyleInfo(flag, page);
        }
        public 门店下单选款式Model()
        {

        }
        #endregion

        #region build方法
        public 门店下单选款式Model build款式全尺寸(String styleid)
        {
            this.款式尺寸dt = ImpService.StyleCombobox(styleid);
            return this;
        }
        public 门店下单选款式Model build选中尺寸(String size, String styleid, DataTable dt)
        {
            this.选中尺寸dt = ImpService.StyleValue(size, styleid, dt);
            //this.Dto定制下单.STYLE_SIZE_CD= ImpService.SizeCD(size, this.选中尺寸dt);
            return this;
        }
        #endregion

        #region 校验方法
        /// <summary>
        /// 校验订单方法
        /// </summary>
        /// <returns></returns>
        public bool verify订单() {
            try
            {
                this.Dto定制下单.verify订单();
            }
            catch (Exception ex) {
                throw ex;
            }
            return true;
        }
        #endregion
    }
    public class 面料图片Model
    {
        #region 变量和属性
        private List<面料图片Dto> 面料图片DTos = new List<面料图片Dto>();
        internal List<面料图片Dto> 面料卡s { get => 面料图片DTos; set => 面料图片DTos = value; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 全部面料
        /// </summary>
        /// <param name="str">模糊查询字段</param>
        /// <param name="page"></param>
        public 面料图片Model(String str, int page)
        {
            this.面料图片DTos = ImpService.GetMianLiao(str, page);
        }
        /// <summary>
        /// 款式的默认面料
        /// </summary>
        /// <param name="styleid"></param>
        /// <param name="str">模糊查询字段</param>
        /// <param name="page"></param>
        public 面料图片Model(String styleid,String str,int page)
        {
            this.面料图片DTos = ImpService.DefaultMianLiao(styleid, str, page);
        }
        #endregion

    }
    public class 设计点图片Model
    {
        #region 变量和属性
        private List<设计点图片Dto> 设计点图片Dtos = new List<设计点图片Dto>();
        internal List<设计点图片Dto> 设计点s { get => 设计点图片Dtos; set => 设计点图片Dtos = value; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 根据设计点查询设计点图片
        /// </summary>
        /// <param name="itemcd">设计点</param>
        /// <param name="str">模糊查询字段</param>
        public 设计点图片Model(String itemcd, String str)
        {
            this.设计点s = ImpService.GetDesign(itemcd, str);
        }
        /// <summary>
        /// 查询默认项
        /// </summary>
        /// <param name="id"></param>
        public 设计点图片Model(String id)
        {
            this.设计点s = ImpService.DefaultItem(id);
        }
        #endregion
    }

}
