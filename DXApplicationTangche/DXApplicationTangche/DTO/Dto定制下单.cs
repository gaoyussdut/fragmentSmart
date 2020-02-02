using DXApplicationTangche.service;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.UC.门店下单.UC;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单.DTO
{
    public class Dto定制下单
    {
        public String Style_Id { get; set; }    //  款式id
        public String SYTLE_FABRIC_ID { get; set; } //  面料id
        public String STYLE_CATEGORY_CD { get; set; }//款式类别
        public String STYLE_FIT_CD { get; set; } //版型
        public String STYLE_SIZE_GROUP_CD { get; set; }//尺码组
        public String STYLE_SIZE_CD { get; set; }//尺码
        public int ORDER_NUMBER { get; set; }   //  订单数量
        public String STYLE_DRESS_CATEGORY { get; set; }
        public String STYLE_DESIGN_TYPE { get; set; }


        public List<Dto设计点> Dto设计点s { get => dto设计点s; set => dto设计点s = value; }
        public Dto尺寸 Dto尺寸 { get => dto尺寸; }

        private List<Dto设计点> dto设计点s = new List<Dto设计点>();   //  设计点
        private Dto尺寸 dto尺寸;  //  尺寸

        public Dto定制下单 build设计点(String ITEM_CD, String ITEM_VALUE, String OPTION_VALUE, String ENABLE_FLAG, String DELETE_FLAG, String Name, String Style,Image pic)
        {
            this.dto设计点s.Add(new Dto设计点(ITEM_CD, ITEM_VALUE, OPTION_VALUE, ENABLE_FLAG, DELETE_FLAG, Name, Style, pic));
            return this;
        }

        public Dto定制下单 build尺寸(String ITEM_CD, String ITEM_VALUE, String FIT_VALUE, String FM_VALUE, String IN_VALUE, String OUT_VALUE, String STATUS, String DELETE_FLAG, String CUSTOMER_COUNT_IDSTYLE_ID, String PHASE_CD, String VERSION, String CREATE_USER) {
            this.dto尺寸 = new Dto尺寸(ITEM_CD, ITEM_VALUE, FIT_VALUE, FM_VALUE, IN_VALUE, OUT_VALUE, STATUS, DELETE_FLAG, CUSTOMER_COUNT_IDSTYLE_ID, PHASE_CD, VERSION, CREATE_USER);
            return this;
        }
        public Dto定制下单 build选中款式(String Style_Id, String STYLE_CATEGORY_CD, String STYLE_FIT_CD, String STYLE_SIZE_GROUP_CD, String SYTLE_FABRIC_ID)
        {
            this.Style_Id = Style_Id;
            this.STYLE_CATEGORY_CD = STYLE_CATEGORY_CD;
            this.STYLE_FIT_CD = STYLE_FIT_CD;
            this.STYLE_SIZE_GROUP_CD = STYLE_SIZE_GROUP_CD;
            //this.STYLE_SIZE_CD = this.tileView1.GetRowCellValue(e.Item.RowHandle, "STYLE_SIZE_CD").ToString();
            this.SYTLE_FABRIC_ID = SYTLE_FABRIC_ID;
            return this;
        }
        //public Dto定制下单 build款式卡片(款式卡片DTO 款式卡片DTO) {
        //    this.Style_Id = 款式卡片DTO.kuanshiid;
        //    this.STYLE_CATEGORY_CD = 款式卡片DTO.sTYLE_CATEGORY_CD;
        //    this.STYLE_FIT_CD = 款式卡片DTO.sTYLE_FIT_CD;
        //    this.STYLE_SIZE_GROUP_CD = 款式卡片DTO.sTYLE_SIZE_GROUP_CD;
        //    this.STYLE_SIZE_CD = 款式卡片DTO.sTYLE_SIZE_CD;
        //    this.SYTLE_FABRIC_ID = 款式卡片DTO.mianliaoid;
        //    return this;
        //}
        public Dto定制下单 build面料(String SYTLE_FABRIC_ID)
        {
            this.SYTLE_FABRIC_ID = SYTLE_FABRIC_ID;
            return this;
        }
        public Dto定制下单 build数量(String ORDER_NUMBER)
        {
            try
            {
                this.ORDER_NUMBER = Convert.ToInt32(ORDER_NUMBER);
            }
            catch (Exception)
            {                
            }
            return this;
        }
        public void verify订单()
        {
            if (String.IsNullOrEmpty(this.Style_Id))
            {
                throw new Exception("款式id为空");
            }
            if (String.IsNullOrEmpty(this.SYTLE_FABRIC_ID))
            {
                throw new Exception("面料id为空");
            }
            if (String.IsNullOrEmpty(this.STYLE_CATEGORY_CD))
            {
                throw new Exception("服装种类为空");
            }
            if (String.IsNullOrEmpty(this.STYLE_FIT_CD))
            {
                throw new Exception("版型为空");
            }
            if (String.IsNullOrEmpty(this.STYLE_SIZE_GROUP_CD))
            {
                throw new Exception("尺码为空");
            }
            if (this.ORDER_NUMBER<=0)
            {
                throw new Exception("订单数量必须大于0");
            }
            if (this.Dto设计点s.Count == 0) {
                throw new Exception("设计点为空");
            }
            if (this.Dto尺寸 == null) {
                throw new Exception("尺寸为空");
            }
        }
    }

    /// <summary>
    /// 设计点
    /// </summary>
    public class Dto设计点
    {
        public Dto设计点(string iTEM_CD, string iTEM_VALUE, string oPTION_VALUE, string eNABLE_FLAG, string dELETE_FLAG, String Name, String Style,Image pic)
        {
            this.ITEM_CD = iTEM_CD;
            this.ITEM_VALUE = iTEM_VALUE;
            this.OPTION_VALUE = oPTION_VALUE;
            this.ENABLE_FLAG = eNABLE_FLAG;
            this.DELETE_FLAG = dELETE_FLAG;
            this.Picture = pic == null ? Image.FromFile(@"pic\SSHIRT.jpg") : pic;

            this.Name = Name;
            this.Style = Style;
        }
        public Dto设计点(DataRow dr) {
            this.Name = dr["ITEM_NAME_CN"].ToString();
            this.ITEM_CD = dr["ITEM_CD"].ToString();
            this.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
            this.Style = dr["ID"].ToString();
            
            this.Picture = PictureService.GetImage(this.ITEM_VALUE);    //  写的什么鸡巴玩意
            this.Picture = this.Picture == null ? Image.FromFile(@"pic\SSHIRT.jpg") : this.Picture;
        }

        public String ITEM_CD { get; set; }
        public String ITEM_VALUE { get; set; }
        public String OPTION_VALUE { get; set; }
        public String ENABLE_FLAG { get; set; }
        public String DELETE_FLAG { get; set; }

        public Image Picture { get; set; }
        public String Name { get; set; }
        public String Style { get; set; }
    }

    public class Dto尺寸
    {
        public Dto尺寸(string iTEM_CD, string iTEM_VALUE, string fIT_VALUE, string fM_VALUE, string iN_VALUE, string oUT_VALUE, string sTATUS, string dELETE_FLAG, string cUSTOMER_COUNT_ID, string pHASE_CD, string vERSION, string cREATE_USER)
        {
            this.ITEM_CD = iTEM_CD;
            this.ITEM_VALUE = iTEM_VALUE;
            this.FIT_VALUE = fIT_VALUE;
            this.FM_VALUE = fM_VALUE;
            this.IN_VALUE = iN_VALUE;
            this.OUT_VALUE = oUT_VALUE;
            this.STATUS = sTATUS;
            this.DELETE_FLAG = dELETE_FLAG;
            this.CUSTOMER_COUNT_ID = cUSTOMER_COUNT_ID;
            this.PHASE_CD = pHASE_CD;
            this.VERSION = vERSION;
            this.CREATE_USER = cREATE_USER;
        }

        /// <summary>
        /// 从数据库取数据
        /// </summary>
        /// <param name="STYLE_ID"></param>
        /// <param name="iTEM_CD"></param>
        /// <param name="iTEM_VALUE"></param>
        /// <param name="fIT_VALUE"></param>
        /// <param name="fM_VALUE"></param>
        /// <param name="iN_VALUE"></param>
        /// <param name="oUT_VALUE"></param>
        /// <param name="sTATUS"></param>
        /// <param name="dELETE_FLAG"></param>
        /// <param name="cUSTOMER_COUNT_ID"></param>
        /// <param name="pHASE_CD"></param>
        /// <param name="vERSION"></param>
        /// <param name="cREATE_USER"></param>
        public Dto尺寸(DataRow dr)
        {
            this.STYLE_ID = dr["STYLE_ID"].ToString();
            this.ITEM_CD = dr["ITEM_CD"].ToString();
            this.ITEM_VALUE = dr["ITEM_VALUE"].ToString();
            this.FIT_VALUE = dr["FIT_VALUE"].ToString();
            this.FM_VALUE = dr["FM_VALUE"].ToString();
            this.IN_VALUE = dr["IN_VALUE"].ToString();
            this.OUT_VALUE = dr["OUT_VALUE"].ToString();
            this.DELETE_FLAG = dr["DELETE_FLAG"].ToString();
            this.PHASE_CD = dr["PHASE_CD"].ToString();
            this.VERSION = dr["VERSION"].ToString();
            this.CREATE_USER = dr["CREATE_USER"].ToString();
        }

        public void build尺寸呈现dto(List<尺寸呈现dto> 尺寸呈现dto) {
            List<String> ITEM_CD = new List<string>(this.ITEM_CD.Split(','));
            List<String> ITEM_VALUE = new List<string>(this.ITEM_VALUE.Split(','));
            List<String> IN_VALUE = new List<string>(this.IN_VALUE.Split(','));
            List<String> OUT_VALUE = new List<string>(this.OUT_VALUE.Split(','));

            for (int i = 0; i < 尺寸呈现dto.Count; i++) {
                for (int j= 0;j < ITEM_VALUE.Count;j++) {
                    if (尺寸呈现dto[i].ITEM_VALUE.Equals(ITEM_VALUE[j])) {
                        尺寸呈现dto[i].IN_VALUE = Convert.ToDouble("NaN".Equals(IN_VALUE[j]) ? "0" : IN_VALUE[j]);
                        尺寸呈现dto[i].OUT_VALUE = Convert.ToDouble("NaN".Equals(OUT_VALUE[j]) ? "0" : OUT_VALUE[j]);
                        //尺寸呈现dto[i].ITEM_VALUE = ITEM_VALUE[j];
                        尺寸呈现dto[i].CountSize();
                        break;
                    }                
                }
            }
        }

        public String STYLE_ID { get; set; }
        public String ITEM_CD { get; set; }
        public String ITEM_VALUE { get; set; }
        public String FIT_VALUE { get; set; }
        public String FM_VALUE { get; set; }
        public String IN_VALUE { get; set; }
        public String OUT_VALUE { get; set; }
        public String STATUS { get; set; }
        public String DELETE_FLAG { get; set; }
        public String CUSTOMER_COUNT_ID { get; set; }
        public String PHASE_CD { get; set; }
        public String VERSION { get; set; }
        public String CREATE_USER { get; set; }

    }
}
