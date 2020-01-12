using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.DTO
{
    public class 设计点图片Dto
    {
        public String pitem_value { get; set; }
        public String pitem_cd { get; set; }
        public String pitem_name { get; set; }
        public String item_value { get; set; }
        public String item_cd { get; set; }
        public String item_name { get; set; }
        public Image picture { get; set; }
        public String picn { get; set; }
        public 设计点图片Dto(DataRow dr)
        {
            this.item_cd = dr["itemCD"].ToString();
            this.item_value = dr["itemValue"].ToString();
            this.item_name = dr["itemNameCN"].ToString();
            this.picn = dr["picn"].ToString();
            try
            {
                this.picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
            }
            catch (Exception)
            {
                this.picture = Image.FromFile(@"pic\SSHIRT.jpg");
            }

        }
    }
}
