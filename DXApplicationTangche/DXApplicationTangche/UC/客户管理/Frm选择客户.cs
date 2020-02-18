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

namespace mendian
{
    public partial class Frm选择客户 : DevExpress.XtraEditors.XtraForm
    {
        public Frm选择客户()
        {
            InitializeComponent();
        }

        private void CustomerChoose_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT CUSTOMER_ID AS ID,CONCAT(CONCAT(CUSTOMER_FIRST_NAME,' '),CUSTOMER_LAST_NAME ) AS 客户姓名,MOBILE AS 手机,CREATE_DATE AS 注册时间 FROM `a_customer_p` ORDER BY CREATE_DATE DESC LIMIT 1000");
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT CUSTOMER_ID AS ID,CONCAT(CONCAT(CUSTOMER_FIRST_NAME,' '),CUSTOMER_LAST_NAME ) AS 客户姓名,MOBILE AS 手机,CREATE_DATE AS 注册时间 FROM `a_customer_p` WHERE CUSTOMER_FIRST_NAME LIKE'%"+this.textBox1.Text+"%' OR CUSTOMER_LAST_NAME LIKE '%"+this.textBox1.Text+"%' OR MOBILE LIKE '%"+this.textBox1.Text+"%' ORDER BY CREATE_DATE DESC LIMIT 1000");
            gridControl1.DataSource = dt;
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
                if (e.Button == MouseButtons.Left && e.Clicks == 2)//判断是否左键双击
                {
                    ////判断光标是否在行范围内 
                    //if (hInfo.InRow)
                    //{
                    DataRow dr;
                    int handle = this.gridView1.FocusedRowHandle;
                    dr = this.gridView1.GetDataRow(handle);
                    DataTable dt = SQLmtm.GetDataTable("SELECT * FROM (SELECT * FROM a_customer_fit_r) s1 RIGHT JOIN (SELECT * FROM a_customer_fit_count_r WHERE CUSTOMER_ID ='" + Convert.ToInt32(dr["ID"]) + "' AND DEFAULT_FLAG ='1') s2 on s1.FIT_COUNT_ID=s2.ID");
                    if (dt.Rows[0]["CUSTOMER_FIT_ID"].ToString() != "")
                    {
                        Frm客户.customer_name = dr["客户姓名"].ToString();
                        Frm客户.cUSTOMER_ID = Convert.ToInt32(dr["ID"]);
                        DataRow drr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_fit_count_r` WHERE CUSTOMER_ID='" + Frm客户.cUSTOMER_ID.ToString() + "' AND DEFAULT_FLAG=1");
                        DataRow ddr = SQLmtm.GetDataRow("SELECT * FROM `a_customer_address_p` WHERE DEFAULT_ADDR_FLAG=1 AND CUSTOMER_ID='"+ Frm客户.cUSTOMER_ID.ToString() + "'");
                        if(drr==null||ddr==null)
                        {
                            MessageBox.Show("缺少客户信息");
                            return;
                        }
                        Frm客户.customer_countid = Convert.ToInt32(drr["ID"]);
                        Frm客户.aDDRESS_ID = Convert.ToInt32(ddr["ADDRESS_ID"]);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("选择的客户未建立量体值");
                    }
                    //写双击后需要执行的程序
                    //}
                }
            }
            catch
            {
                MessageBox.Show("选择的客户未建立量体值");
            }

        }
    }
}
