using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    class FitValueCalculate
    {
        public String countId;
        public String listFitData;
        public String styleGategory = "STYLE_CATEGORY-SHIRT";

        public FitValueCalculate(String ctid,String lfd)
        {
            this.countId = ctid;
            this.listFitData = lfd;
        }
    }
}
