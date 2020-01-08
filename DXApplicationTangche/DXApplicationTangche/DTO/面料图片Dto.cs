using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.DTO
{
    class 面料图片DTo
    {
        public String materialid { get; set; }
        public String materialcd { get; set; }
        public String materialname { get; set; }
        public Image Picture { get; set; }
        public 面料图片DTo (DataRow dr)
        {
            this.materialid = dr["id"].ToString();
            this.materialcd = dr["materialCode"].ToString();
            this.materialname = dr["mianliao"].ToString();
            try
            {
                this.Picture = Image.FromFile(@"pic\" + dr["picn"].ToString());
            }
            catch
            {
                this.Picture = Image.FromFile(@"pic\SSHIRT.jpg");
            }
        }
    }
}
