using DevExpress.XtraGrid.Demos.util;
using DiaoPaiDaYin;
using DXApplicationTangche.DTO;
using DXApplicationTangche.service;
using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

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
            else
            {
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
                        dto.build设计点();
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

    /// <summary>
    /// 用来做序列化
    /// </summary>
    public class 订单Model {
        #region 变量
        private String 订单Id;
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();
        private List<面料信息dto> 面料信息dtos = new List<面料信息dto>();
        private List<尺寸呈现dto> 尺寸呈现dtos = new List<尺寸呈现dto>();
        private Dto定制下单 Dto定制下单 = new Dto定制下单();
        #endregion


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="款式图片一览Dtos"></param>
        /// <param name="面料信息dtos"></param>
        /// <param name="尺寸呈现dtos"></param>
        /// <param name="Dto定制下单"></param>
        public 订单Model(
            String ORDER_ID
            , List<款式图片一览Dto> 款式图片一览Dtos
            , List<面料信息dto> 面料信息dtos
            , List<尺寸呈现dto> 尺寸呈现dtos
            , Dto定制下单 Dto定制下单)
        {
            this.款式图片一览Dtos = 款式图片一览Dtos;
            this.面料信息dtos = 面料信息dtos;
            this.尺寸呈现dtos = 尺寸呈现dtos;
            this.Dto定制下单 = Dto定制下单;
            this.订单Id = ORDER_ID;
        }

        /// <summary>
        /// 序列化方法
        /// </summary>
        /// <returns></returns>
        public String JsonSerialization() {
            return FunctionHelper.JsonSerialization(this);
        }

        #region 属性
        //  款式图片
        public List<款式图片一览Dto> STYLE_PIC { get => 款式图片一览Dtos; set => 款式图片一览Dtos = value; }
        //  面料信息
        public List<面料信息dto> MATERIAL_INFO { get => 面料信息dtos; set => 面料信息dtos = value; }
        //  尺寸呈现
        public List<尺寸呈现dto> SIZE_INFO { get => 尺寸呈现dtos; set => 尺寸呈现dtos = value; }
        //  订单信息
        public Dto定制下单 ORDER_INFO { get => Dto定制下单; set => Dto定制下单 = value; }
        public string ORDER_ID { get => 订单Id; set => 订单Id = value; }
        #endregion

    }

    public class 门店下单选款式Model
    {
        #region 变量
        private String ORDER_ID;
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();
        private List<款式图片Dto> 款式图片dtos = new List<款式图片Dto>();
        //private 款式图片Dto 款式图片Dto;
        private DataTable 款式尺寸dt;
        private DataTable 选中尺寸dt;
        public Dto定制下单 Dto定制下单 = new Dto定制下单();
        private List<尺寸呈现dto> 尺寸呈现dtos = new List<尺寸呈现dto>();
        private List<面料信息dto> 面料信息dtos = new List<面料信息dto>();
        #endregion

        #region 属性
        public List<款式图片一览Dto> 款式图片一览 { get => 款式图片一览Dtos; set => 款式图片一览Dtos = value; }
        public List<款式图片Dto> 款式图片 { get => 款式图片dtos; set => 款式图片dtos = value; }
        public DataTable 选中尺寸 { get => 选中尺寸dt; set => 选中尺寸dt = value; }
        public List<尺寸呈现dto> 尺寸呈现 { get => 尺寸呈现dtos; set => 尺寸呈现dtos = value; }
        public List<面料信息dto> 面料信息 { get => 面料信息dtos; set => 面料信息dtos = value; }

        #endregion

        #region 构造函数
        public 门店下单选款式Model(String flag, int page)
        {
            this.款式图片dtos = StyleService.initStyleInfo(flag, page);
        }
        public 门店下单选款式Model()
        {

        }
        public 门店下单选款式Model(String ORDER_ID)
        {
            this.ORDER_ID = ORDER_ID;
        }
        #endregion

        #region build方法
        public 门店下单选款式Model build款式全尺寸(String styleid)
        {
            DataRow dr = SQLmtm.GetDataRow("SELECT SYS_STYLE_ID,SHOP_ID,STYLE_NO,CUSTOMER_COUNT_ID,STYLE_CD,STYLE_KBN,STYLE_SOURCE,STYLE_CATEGORY_CD,STYLE_DRESS_CATEGORY,STYLE_DESIGN_TYPE,STYLE_PUBLISH_CATEGORY_CD,REF_STYLE_ID,STYLE_NAME_CN,STYLE_NAME_EN,STYLE_FIT_CD,SYTLE_YEAR,SYTLE_SEASON,SYTLE_FABRIC_ID,SYTLE_FABRIC_NO,STYLE_COMPOSITION,STYLE_DESCRIBE,STYLE_COLOR_CD,STYLE_COLOR_NAME,STYLE_SIZE_GROUP_CD,STYLE_SIZE_CD,STYLE_MAKE_TYPE,STYLE_FIT_BODY_TYPE,STYLE_SEX_CD,STYLE_STANDARD,STYLE_BAR_CODE,STYLE_DESIGNER_DATE,STYLE_DESIGNER,STYLE_MATERIAL_NUMBER,STYLE_DESIGN_PRICE,STYLE_FACTORY_TOTAL_PRICE,STYLE_SHOP_TOTAL_PRICE,REMARKS,ENABLE_FLAG,DELETE_FLAG,VERSION,CREATE_DATE,UPDATE_DATE,CREATE_USER,UPDATE_USER,COVER_PHOTO_PATH FROM s_style_p WHERE SYS_STYLE_ID = '" + styleid + "'");
            this.款式尺寸dt = StyleService.StyleCombobox(dr,styleid);
            this.build款式信息面料(dr["SYTLE_FABRIC_ID"].ToString());
            return this;
        }

        public 门店下单选款式Model build款式图片()
        {
            this.款式图片一览Dtos.Add(StyleService.getStyleByORDER_ID(this.ORDER_ID));
            return this;
        }

        public 门店下单选款式Model build设计点(String styleid)
        {
            List<Dto设计点> 设计点s = OrderService.get设计点BySYS_STYLE_ID(styleid);
            this.Dto定制下单.Dto设计点s = 设计点s;
            return this;
        }

        public 门店下单选款式Model build选中尺寸(String size, String styleid, DataTable dt)
        {
            this.选中尺寸dt = SizeService.StyleValue(size, styleid, dt);
            //this.Dto定制下单.STYLE_SIZE_CD= ImpService.SizeCD(size, this.选中尺寸dt);
            return this;
        }
        /// <summary>
        /// 尺寸计算
        /// </summary>
        /// <returns></returns>
        public 门店下单选款式Model buildCountSize(int RowHandle,String FieldName,String value) {
            this.尺寸呈现[RowHandle]  //  DTO
                .SizeConflict() //  尺寸冲突
                .build尺寸增减值(FieldName,value);   //  根据修改列修改尺寸值

            //  尺寸计算
            foreach (尺寸呈现dto dto in this.尺寸呈现)
            {
                dto.CountSize();
            }
            return this;
        }
        /// <summary>
        /// 款式信息添加款式
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        public 门店下单选款式Model build款式信息款式(String tab, String name, String description, Image picture)
        {
            this.面料信息.Clear();
            this.面料信息.Add(new 面料信息dto(tab, name, description, picture));
            return this;
        }
        /// <summary>
        /// 款式信息中添加面料
        /// </summary>
        /// <param name="SYTLE_FABRIC_ID"></param>
        /// <returns></returns>
        public 门店下单选款式Model build款式信息面料(String SYTLE_FABRIC_ID)
        {
            this.面料信息.Add(new 面料信息dto(SYTLE_FABRIC_ID));
            return this;
        }

        /// <summary>
        /// 动态设计点保存
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dto"></param>
        public void build尺寸保存()
        {
            //ImpService.TurnChiCunZero(frm);
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (尺寸呈现dto 尺寸呈现dto in this.尺寸呈现)
            {
                fitv.icadd(尺寸呈现dto.ITEM_CD);//ITEM_CD 衣服CD
                fitv.ivadd(尺寸呈现dto.ITEM_VALUE);//ITEM_VALUE 衣服VALUE
                fitv.fvadd(Convert.ToString(尺寸呈现dto.garmentSize));// garmentSize 成衣尺寸
                fitv.fmvadd(尺寸呈现dto.ITEM_VALUE);//ITEM_VALUE 衣服VALUE
                fitv.invadd(Convert.ToString(尺寸呈现dto.IN_VALUE));//IN_VALUE 加值
                fitv.outvadd(Convert.ToString(尺寸呈现dto.OUT_VALUE));//OUT_VALUE 减值
            }
            this.Dto定制下单.build尺寸(
                fitv.iTEM_CD
                , fitv.iTEM_VALUE
                , fitv.fitValue
                , fitv.fM_VALUE
                , fitv.iN_VALUE
                , fitv.oUT_VALUE
                , "0"
                , "0"
                , Frm客户.customer_countid.ToString()
                , "AUDIT_PHASE_CD-PHASE_CD_10"
                , "1"
                , "46"
                );
            //        SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            //        SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
            //new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }

        /// <summary>
        /// 用来做序列化
        /// </summary>
        /// <returns></returns>
        public 订单Model build订单Model() {
            return new 订单Model(
                this.ORDER_ID
                ,this.款式图片一览Dtos
                , this.面料信息dtos
                , this.尺寸呈现dtos
                , this.Dto定制下单
                );
        }
        #endregion

        #region 校验方法
        /// <summary>
        /// 校验订单方法
        /// </summary>
        /// <returns></returns>
        public bool verify订单()
        {
            try
            {
                this.Dto定制下单.verify订单();
            }
            catch (Exception ex)
            {
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
            this.面料图片DTos = FabricService.GetMianLiao(str, page);
        }
        /// <summary>
        /// 款式的默认面料
        /// </summary>
        /// <param name="styleid"></param>
        /// <param name="str">模糊查询字段</param>
        /// <param name="page"></param>
        public 面料图片Model(String styleid, String str, int page)
        {
            this.面料图片DTos = FabricService.DefaultMianLiao(styleid, str, page);
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
            this.设计点s = ItemService.GetDesign(itemcd, str);
        }
        /// <summary>
        /// 查询默认项
        /// </summary>
        /// <param name="id"></param>
        public 设计点图片Model(String id)
        {
            this.设计点s = ItemService.DefaultItem(id);
        }
        #endregion
    }
    public class 尺寸呈现dto
    {
        public String ITEM_CD { get; set; }//衣服CD
        public String ITEM_VALUE { get; set; }//衣服VALUE
        public String PROPERTY_VALUE { get; set; }//人VALUE
        public String FIT_VALUE { get; set; }//人尺寸值
        public Double ITEM_FIT_VALUE { get; set; }//衣服尺寸值
        public Double IN_VALUE { get; set; }//加值
        public Double OUT_VALUE { get; set; }//减值
        public String ITEM_NAME_CN { get; set; }//尺寸名称
        public Double garmentSize { get; set; }//成衣尺寸
        public Double leastReasonable { get; set; }//最小合理值
        public Double maxReasonable { get; set; }//最大合理值
        public Double CUSTOMER_FIT_VALUE { get; set; }  //  客户量体值
        public 尺寸呈现dto(String itemcd, String itemvalue, String propertyvalue, String fitvalue, Double itemfitvalue, Double invalue, Double outvalue, String itemnamecn, Double leastReasonable, Double maxReasonable)
        {
            this.ITEM_CD = itemcd;
            this.ITEM_VALUE = itemvalue;
            this.PROPERTY_VALUE = propertyvalue;
            this.FIT_VALUE = fitvalue;
            this.ITEM_FIT_VALUE = itemfitvalue;
            this.IN_VALUE = invalue;
            this.OUT_VALUE = outvalue;
            this.ITEM_NAME_CN = itemnamecn;
            this.leastReasonable = leastReasonable;
            this.maxReasonable = maxReasonable;
        }

        /// <summary>
        /// 尺寸计算
        /// </summary>
        /// <returns></returns>
        public 尺寸呈现dto CountSize()
        {
            this.garmentSize = this.ITEM_FIT_VALUE + this.IN_VALUE - this.OUT_VALUE;
            return this;
        }
        public int CountReasonable()
        {
            if (this.IN_VALUE > this.maxReasonable)
            {
                return 1;
            }
            else if (this.OUT_VALUE > this.leastReasonable)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 尺寸冲突
        /// </summary>
        /// <returns></returns>
        public 尺寸呈现dto SizeConflict()
        {
            if(this.IN_VALUE!=0)
            {
                this.IN_VALUE = 0;
            }
            if(this.OUT_VALUE!=0)
            {
                this.OUT_VALUE = 0;
            }
            return this;
        }

        /// <summary>
        /// 根据修改列修改尺寸值
        /// </summary>
        /// <param name="ColumnFieldName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public 尺寸呈现dto build尺寸增减值(String ColumnFieldName,String Value) {
            if (ColumnFieldName == "ITEM_FIT_VALUE")
            {
                this.ITEM_FIT_VALUE = Convert.ToDouble(Value);
            }
            else if (ColumnFieldName == "IN_VALUE")
            {
                this.IN_VALUE = Convert.ToDouble(Value);
            }
            else if (ColumnFieldName == "OUT_VALUE")
            {
                this.OUT_VALUE = Convert.ToDouble(Value);
            }
            return this;
        } 
    }
    public class 面料信息dto
    {
        #region 变量
        public String tab { get; set; }//类别
        public String name { get; set; }//名称
        public String description { get; set; }//详情
        public Image picture { get; set; }//图片
        #endregion
        #region 构造方法
        public 面料信息dto(String tab,String name, String description, Image picture)
        {
            this.tab = tab;
            this.name = name;
            this.description = description;
            this.picture = picture;
        }
        public 面料信息dto(String SYTLE_FABRIC_ID)
        {
            try
            {
                DataRow dr = FabricService.GetMianLiaoDR(SYTLE_FABRIC_ID);
                this.tab = "m";
                this.name = dr["mianliao"].ToString();
                this.description = dr["materialComposition"].ToString();
                try
                {
                    this.picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
                }
                catch
                {
                    this.picture = Image.FromFile(@"pic\SSHIRT.jpg");
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        #endregion

    }
}
