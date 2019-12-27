using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Demos.util;
using mendian;
using Seagull.BarTender.Print;

namespace DiaoPaiDaYin
{
    public partial class Frm吊牌打印 : DevExpress.XtraEditors.XtraForm
    {
        public DataTable stylesizedt = new DataTable();
        public DataRow impdr = null;
        public List<ChengYiChiCun> cycc = new List<ChengYiChiCun>();
        public int ordernumber = new int();
        public DataTable logdt = null;
        public String logid;
        public Frm吊牌打印()
        {
            InitializeComponent();

            //int n = 3;
            //string s = n.ToString().PadLeft(4, '0'); //0003
            //s = string.Format("{0:d4}", n);
            //s = FunctionHelper.generateBillNo("a_product_log_p", "LOG_ID", "CY", "000000");
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.logdt.Rows.Count != 0)
            {
                for (int on = 0; on < ordernumber; on++)
                {
                    try
                    {
                        this.logid = FunctionHelper.generateBillNo("a_product_log_p", "LOG_ID", "CY", "000000");
                        SQLmtm.DoInsert("a_product_log_p"
                            , new string[] { "ORDER_ID", "CUSTOMER_ID", "SHOP_ID", "SHOP_NAME", "STYLE_ID", "ORDER_NUMBER", "ORDER_DATE", "STYLE_NAME_CN", "SYTLE_YEAR", "SYTLE_SEASON", "REF_STYLE_ID", "SYTLE_FABRIC_ID", "MATERIAL_NAME_CN", "MATERIAL_COLOR", "STYLE_PUBLISH_CATEGORY_CD", "ORDER_NO", "LOG_ID", "STYLE_SIZE_CD" }
                            , new string[] { this.logdt.Rows[0]["ORDER_ID"].ToString(), this.logdt.Rows[0]["CUSTOMER_ID"].ToString(), this.logdt.Rows[0]["shop_id"].ToString(), this.logdt.Rows[0]["shop_name"].ToString(), this.logdt.Rows[0]["style_id"].ToString(), this.logdt.Rows[0]["ORDER_NUMBER"].ToString(), this.logdt.Rows[0]["ORDER_DATE"].ToString(), this.logdt.Rows[0]["STYLE_NAME_CN"].ToString(), this.logdt.Rows[0]["SYTLE_YEAR"].ToString(), this.logdt.Rows[0]["SYTLE_SEASON"].ToString(), this.logdt.Rows[0]["REF_STYLE_ID"].ToString(), this.logdt.Rows[0]["SYTLE_FABRIC_ID"].ToString(), this.logdt.Rows[0]["MATERIAL_NAME_CN"].ToString(), this.logdt.Rows[0]["MATERIAL_COLOR"].ToString(), this.logdt.Rows[0]["STYLE_PUBLISH_CATEGORY_CD"].ToString(), this.logdt.Rows[0]["ORDER_NO"].ToString(), logid, this.logdt.Rows[0]["STYLE_SIZE_CD"].ToString() });
                        Engine btEngine = new Engine();
                        btEngine.Start();
                        //string lj = AppDomain.CurrentDomain.BaseDirectory + "顺丰订单模板.btw";  //test.btw是BT的模板
                        //string lj = AppDomain.CurrentDomain.BaseDirectory + "001.btw";  //test.btw是BT的模板
                        String lj = "C:\\001.btw";
                        LabelFormatDocument btFormat = btEngine.Documents.Open(lj);
                        //指定打印机名 
                        //btFormat.PrintSetup.PrinterName = "HPRT HLP106S-UE";
                        btFormat.PrintSetup.PrinterName = "TEC";
                        //btFormat.PrintSetup.PrinterName = "POSTEK G-3106";
                        //打印份数                   
                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                        //改变标签打印数份连载 
                        btFormat.PrintSetup.NumberOfSerializedLabels = 1;
                        //对BTW模版相应字段进行赋值 
                        btFormat.SubStrings["kuanhao"].Value = this.impdr["STYLE_NAME_CN"].ToString();
                        btFormat.SubStrings["haoxing"].Value = this.impdr["SIZE"].ToString();
                        btFormat.SubStrings["mianliaohao"].Value = this.impdr["MATERIAL_CODE"].ToString();
                        btFormat.SubStrings["chengfen"].Value = this.impdr["MATERIAL_COMPOSITION"].ToString();
                        btFormat.SubStrings["shoujia"].Value = "¥" + this.impdr["STYLE_SHOP_TOTAL_PRICE"].ToString();
                        int i = 1;
                        foreach (ChengYiChiCun cy in this.cycc)
                        {
                            if (Convert.ToDouble(cy.fitValue) != 0)
                            {
                                btFormat.SubStrings[i.ToString()].Value = ImpService.GetNameCN(cy.itemValue) + " " + cy.fitValue;
                                //btFormat.SubStrings[i.ToString()+i.ToString()].Value = cy.fitValue;
                                i++;
                            }
                            if (i > 10)
                            {
                                break;
                            }
                        }
                        btFormat.SubStrings["styleid"].Value = this.logid;
                        Messages messages;
                        int waitout = 10000; // 10秒 超时 
                        Result nResult1 = btFormat.Print("吊牌" + this.logid, waitout, out messages);
                        btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
                        //不保存对打开模板的修改 
                        btFormat.Close(SaveOptions.DoNotSaveChanges);
                        //结束打印引擎                  
                        btEngine.Stop();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误信息: " + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("查询数据为空不能打印");
                return;
            }
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.impdr = ImpService.GetDataRowFromOrder(this.orderno.Text);
            if (impdr == null)
            {
                MessageBox.Show("没有找到信息,请查看订单号是否正确");
                return;
            }
            //this.mianliaohao.Text = this.impdr["MATERIAL_CODE"].ToString();
            //this.chengfen.Text = this.impdr["MATERIAL_COMPOSITION"].ToString();
            //this.shoujia.Text = "¥" + this.impdr["STYLE_SHOP_TOTAL_PRICE"].ToString();
            this.cycc = ImpService.GetChengYiChiCun(this.impdr["SYS_STYLE_ID"].ToString());

        }
        private void orderno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                try
                {
                    this.impdr = ImpService.GetDataRowFromOrder(this.orderno.Text);
                    this.logdt = ImpService.GetOrder(this.orderno.Text);
                    gridControl1.DataSource = logdt;
                    this.ordernumber = Convert.ToInt32(Convert.ToDouble(logdt.Rows[0]["ORDER_NUMBER"].ToString()));
                    //this.mianliaohao.Text = this.impdr["MATERIAL_CODE"].ToString();
                    //this.chengfen.Text = this.impdr["MATERIAL_COMPOSITION"].ToString();
                    //this.shoujia.Text = "¥" + this.impdr["STYLE_SHOP_TOTAL_PRICE"].ToString();
                    this.cycc = ImpService.GetChengYiChiCun(this.impdr["SYS_STYLE_ID"].ToString());
                }
                catch/*(Exception ex)*/
                {
                    //MessageBox.Show("错误信息: " + ex.Message);
                }
            }
        }
    }

    public class Tradd
    {
        public int i;
        public String str;
        public Tradd(int i, String str)
        {
            this.i = i;
            this.str = str;
        }
    }
}
