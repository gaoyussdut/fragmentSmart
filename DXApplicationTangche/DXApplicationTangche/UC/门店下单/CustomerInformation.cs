using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    public class CustomerInformation
    {
        public String information { get; set; }
        public String value { get; set; }
        public CustomerInformation(String information,String value)
        {
            this.information = information;
            this.value = value;
        }
    }
}
