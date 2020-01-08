using DXApplicationTangche.UC.门店下单.UC;
using mendian;
using System;
using System.Collections.Generic;
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

        public List<Dto设计点> Dto设计点s { get => dto设计点s; }
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

        public Dto定制下单 build款式卡片(款式卡片DTO 款式卡片DTO) {
            this.Style_Id = 款式卡片DTO.kuanshiid;
            this.STYLE_CATEGORY_CD = 款式卡片DTO.sTYLE_CATEGORY_CD;
            this.STYLE_FIT_CD = 款式卡片DTO.sTYLE_FIT_CD;
            this.STYLE_SIZE_GROUP_CD = 款式卡片DTO.sTYLE_SIZE_GROUP_CD;
            this.STYLE_SIZE_CD = 款式卡片DTO.sTYLE_SIZE_CD;
            this.SYTLE_FABRIC_ID = 款式卡片DTO.mianliaoid;
            return this;
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
            ITEM_CD = iTEM_CD;
            ITEM_VALUE = iTEM_VALUE;
            FIT_VALUE = fIT_VALUE;
            FM_VALUE = fM_VALUE;
            IN_VALUE = iN_VALUE;
            OUT_VALUE = oUT_VALUE;
            STATUS = sTATUS;
            DELETE_FLAG = dELETE_FLAG;
            CUSTOMER_COUNT_ID = cUSTOMER_COUNT_ID;
            PHASE_CD = pHASE_CD;
            VERSION = vERSION;
            CREATE_USER = cREATE_USER;
        }

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
