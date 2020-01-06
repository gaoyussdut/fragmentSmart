using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class SheJiDianPic
    {
        public String itemCode;
        public String itemValue;
        public String itemNameCn;
        public String picn;
        public String picurl;

        public SheJiDianPic(String itemCode, String itemValue, String itemNameCn, String picn, String picurl)
        {
            this.itemCode = itemCode;
            this.itemValue = itemValue;
            this.itemNameCn = itemNameCn;
            this.picn = picn;
            this.picurl = picurl;
        }
        public SheJiDianPic()
        {

        }
    }
}
