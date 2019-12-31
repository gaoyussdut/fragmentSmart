using DevExpress.XtraGrid.Demos.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche
{
    public class DTO无订单打印
    {
        public String clothes_log_id { get; set; } = "";
        public String shop_id { get; set; } = "1";
        public String style_id { get; set; } = "";
        public String materials_id { get; set; } = "";
        public String materials_cd { get; set; } = "";
        public String size_cd { get; set; } = "";
        public String json { get; set; } = "";
        public List<dto尺寸> dtos = new List<dto尺寸>();
        public DTO无订单打印()
        { 
        }
        public void buildDTO无订单打印(String shop_id,String style_id, String materials_id,String materials_cd, String size_cd)
        {
            this.clothes_log_id = FunctionHelper.generateBillNo("a_noorder_print_p", "clothes_log_id", "NOP", "000000");
            this.shop_id = shop_id;
            this.style_id = style_id;
            this.materials_id = materials_id;
            this.materials_cd = materials_cd;
            this.size_cd = size_cd;
        }
        public void builddto尺寸(DataTable dt)
        {
            List<dto尺寸> dtoss = new List<dto尺寸>();
            foreach(DataRow dr in dt.Rows)
            {
                dtoss.Add(new dto尺寸(dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["ITEM_NAME_CN"].ToString(), dr["ITEM_FIT_VALUE"].ToString()));
            }
            this.dtos = dtoss;
        }
    }

    public class dto尺寸
    {
        public String item_cd;
        public String item_value;
        public String item_name_cn;
        public String fit_item_value;
        public dto尺寸(String item_cd,String item_value,String item_name_cn,String fit_item_value)
        {
            this.item_cd = item_cd;
            this.item_value = item_value;
            this.item_name_cn = item_name_cn;
            this.fit_item_value = fit_item_value;
        }
    }
}
