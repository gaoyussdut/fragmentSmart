using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplicationTangche
{
    public partial class Frm更改尺寸测 : Form
    {
        public List<当前尺寸dto> 尺寸dtos = new List<当前尺寸dto>();
        public Frm更改尺寸测()
        {
            InitializeComponent();
        }

        private void Frm更改尺寸测_Load(object sender, EventArgs e)
        {
            String sql = "SELECT\n" +
"	* \n" +
"FROM\n" +
"	a_size_fit_p \n" +
"WHERE\n" +
"	FIT_CD = 'FIT_BODY_TYPE-1914F' \n" +
"	AND STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT' \n" +
"	AND SIZEGROUP_CD = 'GROUP_SIZE-EGS_GROUP_SIZE' " +
"   AND SIZE_CD = 'EGS_GROUP_SIZE-38';";
            DataTable dt = SQLmtm.GetDataTable(sql);
            foreach(DataRow dr in dt.Rows)
            {
                this.尺寸dtos.Add(new 当前尺寸dto(dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), "", "", Convert.ToDouble(dr["ITEM_FIT_VALUE"].ToString()), 0, 0, dr["ITEM_NAME_CN"].ToString()));
            }
            this.gridControl1.DataSource = this.尺寸dtos;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "ITEM_FIT_VALUE")
            {
                this.尺寸dtos[e.RowHandle].ITEM_FIT_VALUE = Convert.ToDouble(e.Value.ToString());
            }
            else if(e.Column.FieldName== "IN_VALUE")
            {
                this.尺寸dtos[e.RowHandle].IN_VALUE = Convert.ToDouble(e.Value.ToString());
            }
            else if(e.Column.FieldName == "OUT_VALUE")
            {
                this.尺寸dtos[e.RowHandle].OUT_VALUE = Convert.ToDouble(e.Value.ToString());
            }
        }
    }
    public class 当前尺寸dto
    {
        public String ITEM_CD { get; set; }//衣服CD
        public String ITEM_VALUE { get; set; }//衣服VALUE
        public String PROPERTY_VALUE { get; set; }//人VALUE
        public String FIT_VALUE { get; set; }//人尺寸值
        public Double ITEM_FIT_VALUE { get; set; }//衣服尺寸值
        public Double IN_VALUE { get; set; }//加值
        public Double OUT_VALUE { get; set; }//减值
        public String ITEM_NAME_CN { get; set; }//尺寸名称
        public String GarmentSize { get; set; }//成衣尺寸
        public Double leastReasonable { get; set; }//最小合理值
        public Double maxReasonable { get; set; }//最大合理值
        public 当前尺寸dto(String itemcd,String itemvalue,String propertyvalue,String fitvalue, Double itemfitvalue, Double invalue, Double outvalue,String itemnamecn)
        {
            this.ITEM_CD = itemcd;
            this.ITEM_VALUE = itemvalue;
            this.PROPERTY_VALUE = propertyvalue;
            this.FIT_VALUE = fitvalue;
            this.ITEM_FIT_VALUE = itemfitvalue;
            this.IN_VALUE = invalue;
            this.OUT_VALUE = outvalue;
            this.ITEM_NAME_CN = itemnamecn;
        }

    }
}
