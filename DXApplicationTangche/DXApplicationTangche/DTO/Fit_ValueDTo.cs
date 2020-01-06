using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    class Fit_ValueDTo
    {
        public String lingwei = "0";
        public String xiongwei2 = "0";
        public String qianxiong2 = "0";
        public String beikuan2 = "0";
        public String yaowei2 = "0";
        public String tunwei2 = "0";
        public String jiankuan2 = "0";
        public String dabiwei = "0";
        public String duwei2 = "0";
        public String youxiutouwei = "0";
        public String zuoxiutouwei = "0";
        public String qianshen = "0";
        public String shenchang = "0";
        public String youchangxiuchang = "0";
        public String zuochangxiuchang = "0";
        public String youduanxiuchang = "0";
        public String zuoduanxiuchang = "0";
        public String lingshen = "0";
        public String linggao = "0";
        public String youjiangao = "0";
        public String zuojiangao = "0";
        //摆围
        public String baiwei = "0";
        public String fitValue = "";
        public String iTEM_CD = "";
        public String iTEM_VALUE = "";
        public String fM_VALUE = "";
        public String iN_VALUE = "";
        public String oUT_VALUE = "";


        public string fit_value()
        {
            string fv = lingwei + "," + xiongwei2 + "," + qianxiong2 + "," + beikuan2 + "," + yaowei2 + "," + tunwei2 + "," + jiankuan2 + "," + dabiwei + "," +
                  duwei2 + "," + youxiutouwei + "," + zuoxiutouwei + "," + qianshen + "," + shenchang + "," +
                  youchangxiuchang + "," + zuochangxiuchang + "," + youduanxiuchang + "," + zuoduanxiuchang + "," + lingshen + "," + linggao + ","
                  + youjiangao + "," + zuojiangao + ",";
            return fv;
        }
        public void icadd(String str)
        {
            iTEM_CD = iTEM_CD + str + ",";
        }
        public void ivadd(String str)
        {
            iTEM_VALUE = iTEM_VALUE + str + ",";
        }
        public void fvadd(String str)
        {
            fitValue = fitValue + str + ",";
        }
        public void fmvadd(String str)
        {
            fM_VALUE = fM_VALUE + str + ",";
        }
        public void invadd(String str)
        {
            if (str == "0")
            {
                iN_VALUE = iN_VALUE + "NaN" + ",";
            }
            else
            {
                iN_VALUE = iN_VALUE + str + ",";
            }
        }
        public void outvadd(String str)
        {
            if (str == "0")
            {
                oUT_VALUE = oUT_VALUE + "NaN" + ",";
            }
            else
            {
                oUT_VALUE = oUT_VALUE + str + ",";
            }
        }

    }
}
