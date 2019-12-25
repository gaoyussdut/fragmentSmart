using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seagull.BarTender.Print;

namespace DiaoPaiDaYin
{
    public partial class Frm吊牌打印 : DevExpress.XtraEditors.XtraForm
    {
        public DataTable stylesizedt = new DataTable();
        public DataRow impdr = null;
        public List<ChengYiChiCun> cycc = new List<ChengYiChiCun>();
        public int ordernumber = new int();
        public DataTable logdt = new DataTable();
        public Frm吊牌打印()
        {
            InitializeComponent();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            for (int on = 0; on < ordernumber; on++)
            {
                try
                {
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
                    btFormat.SubStrings["styleid"].Value = this.logdt.Rows[on]["id"].ToString();
                    Messages messages;
                    int waitout = 10000; // 10秒 超时 
                    Result nResult1 = btFormat.Print("吊牌" + this.logdt.Rows[on]["id"].ToString(), waitout, out messages);
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

        private void orderno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.impdr = ImpService.GetDataRowFromOrder(this.orderno.Text);
                this.logdt = ImpService.GetOrder(this.orderno.Text);
                gridControl1.DataSource = logdt;
                this.ordernumber = logdt.Rows.Count;
                //this.mianliaohao.Text = this.impdr["MATERIAL_CODE"].ToString();
                //this.chengfen.Text = this.impdr["MATERIAL_COMPOSITION"].ToString();
                //this.shoujia.Text = "¥" + this.impdr["STYLE_SHOP_TOTAL_PRICE"].ToString();
                this.cycc = ImpService.GetChengYiChiCun(this.impdr["SYS_STYLE_ID"].ToString());
            }
            catch
            {
            }

        }
    }

    public class Tradd
    {
        public int i;
        public String str;
        public Tradd(int i,String str)
        {
            this.i = i;
            this.str = str;
        }
    }
}
