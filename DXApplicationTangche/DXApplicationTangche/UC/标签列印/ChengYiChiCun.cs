using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaoPaiDaYin
{
    public class ChengYiChiCun
    {
        public String itemCd;
        public String itemValue;
        public String fitValue;

        public ChengYiChiCun(String itemCd,String itemValue,String fitValue)
        {
            this.itemCd = itemCd;
            this.itemValue = itemValue;
            this.fitValue = fitValue;
        }

        public ChengYiChiCun()
        { 
        }
    }
}
