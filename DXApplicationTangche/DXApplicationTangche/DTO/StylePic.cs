using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class StylePic
    {
        public String styleId;
        public String styleCd;
        public String stylePicN;
        public String stylePicURL;
        
        public StylePic(String styleid,String stylecd,String stylepicn,String stylepicurl)
        {
            this.styleId = styleid;
            this.styleCd = stylecd;
            this.stylePicN = stylepicn;
            this.stylePicURL = stylepicurl;
        }
        public StylePic()
        {

        }
    }
}
