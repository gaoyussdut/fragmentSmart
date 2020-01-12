using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaoPaiDaYin
{
    public class 成衣尺寸DTO
    {
        public String itemCd;
        public String itemValue;
        public String fitValue;

        public 成衣尺寸DTO(String itemCd,String itemValue,String fitValue)
        {
            this.itemCd = itemCd;
            this.itemValue = itemValue;
            this.fitValue = fitValue;
        }

        public 成衣尺寸DTO()
        { 
        }
    }
}
