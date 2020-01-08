using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.门店下单.DTO
{
    /// <summary>
    /// 门店库存DTO
    /// </summary>
    public class ShopStockDto
    {
        public int amount { get; set; }
        public String STYLE_SIZE_CD { get; set; }
        public String shop_id { get; set; }
        public String shop_name { get; set; }
        public String MATERIAL_ID { get; set; }
        public String MATERIAL_NAME_CN { get; set; }
        public String MATERIAL_COLOR { get; set; }
        public String SYS_STYLE_ID { get; set; }
        public String SYTLE_YEAR { get; set; }
        public String SYTLE_SEASON { get; set; }
        public String SYS_STYLE_SIZE_CD { get; set; }
        public String STYLE_NAME_CN { get; set; }
        public String STYLE_PUBLISH_CATEGORY_CD { get; set; }
        public Image Picture { get; set; }

        public ShopStockDto(DataRow dataRow) {
            this.amount = Convert.ToInt32(dataRow["amount"].ToString());
            this.STYLE_SIZE_CD = dataRow["STYLE_SIZE_CD"].ToString();
            this.shop_id = dataRow["shop_id"].ToString();
            this.shop_name = dataRow["shop_name"].ToString();
            this.MATERIAL_ID = dataRow["MATERIAL_ID"].ToString();
            this.MATERIAL_NAME_CN = dataRow["MATERIAL_NAME_CN"].ToString();
            this.MATERIAL_COLOR = dataRow["MATERIAL_COLOR"].ToString();
            this.SYS_STYLE_ID = dataRow["SYS_STYLE_ID"].ToString();
            this.SYTLE_YEAR = dataRow["SYTLE_YEAR"].ToString();
            this.SYTLE_SEASON = dataRow["SYTLE_SEASON"].ToString();
            this.SYS_STYLE_SIZE_CD = dataRow["SYS_STYLE_SIZE_CD"].ToString();
            this.STYLE_NAME_CN = dataRow["STYLE_NAME_CN"].ToString();
            this.STYLE_PUBLISH_CATEGORY_CD = dataRow["STYLE_PUBLISH_CATEGORY_CD"].ToString();

            //try
            //{
            //    this.Picture = Image.FromFile(@"pic\" + ImpService.GetMianLiaoFile(this.MATERIAL_ID));
            //}
            //catch
            //{
            //    this.Picture = Image.FromFile(@"pic\SSHIRT.jpg");
            //}
        }
    }
}
