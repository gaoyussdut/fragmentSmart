using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class MianLiaoPic
    {
        public String mianliao;
        public String mianliaoid;
        public String mianliaocd;
        public String picn;
        public String picurl;

        public MianLiaoPic(String mianliao, String mianliaoid, String mianliaocd,String picn, String picurl)
        {
            this.mianliao = mianliao;
            this.mianliaoid = mianliaoid;
            this.mianliaocd = mianliaocd;
            this.picn = picn;
            this.picurl = picurl;
        }
        public MianLiaoPic()
        {

        }
    }
}
