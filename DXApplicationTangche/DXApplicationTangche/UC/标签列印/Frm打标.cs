using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
using mendian;
using Seagull.BarTender.Print;
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
    public partial class Frm打标 : DevExpress.XtraEditors.XtraForm
    {
        public DTO无订单打印 dto无订单打印 = new DTO无订单打印();
        public DataTable stylesizedt = new DataTable();
        public DataTable chooseStyleSize = new DataTable();
        public String json;
        public String sTYLE_SIZE_CD;
        public String shopid;
        public DataTable shop;
        public Frm打标()
        {
            InitializeComponent();
        }

        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.chooseStyleSize = ImpService.StyleValue(this.chicun01.Text.Trim().ToString(), this.styleid.Text.Trim(), this.stylesizedt);
                this.gridControl1.DataSource = this.chooseStyleSize;
                this.gridControl1.Refresh();
                this.sTYLE_SIZE_CD = this.chooseStyleSize.Rows[0]["SIZE_CD"].ToString();
            }
            catch
            {

            }
        }

        private void styleid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                try
                {
                    this.chicun01.Items.Clear();
                    this.stylename.Text = SQLmtm.GetDataRow("SELECT STYLE_NAME_CN FROM s_style_p WHERE SYS_STYLE_ID='" + this.styleid.Text.Trim() + "'")["STYLE_NAME_CN"].ToString();
                    this.stylesizedt = ImpService.StyleCombobox(this.styleid.Text.Trim());
                    if (this.stylesizedt != null)
                    {
                        foreach (DataRow dr in this.stylesizedt.Rows)
                        {
                            //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                            this.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach(DataRow dr in this.shop.Rows)
            {
                if(dr["shop_name"].ToString()==this.shopname.Text.Trim())
                {
                    this.shopid = dr["shop_id"].ToString();
                    break;
                }
            }
            this.dto无订单打印.buildDTO无订单打印(this.shopid, this.styleid.Text.Trim(), this.mianliaoid.Text.Trim(),this.mianliaocd.Text.Trim(), this.chicun01.Text.Trim());
            this.dto无订单打印.builddto尺寸(this.chooseStyleSize);
            //this.dto无订单打印.json = Newtonsoft.Json.JsonConvert.SerializeObject(this.dto无订单打印);
            this.dto无订单打印.json = "";
            ImpService.SiveINa_noorder_print_p(this.dto无订单打印);
            ///////////////////////////////////////////
            this.print信息();
            this.print条码();
        }

        private void mianliaoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                try
                {
                    this.mianliaocd.Text = ImpService.GetMianLiaoCD(this.mianliaoid.Text, "cd");
                    this.chengfen.Text = ImpService.GetMianLiaoCD(this.mianliaoid.Text, "dd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void print信息()
        {
            Engine btEngine = new Engine();
            btEngine.Start();
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "顺丰订单模板.btw";  //test.btw是BT的模板
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "001.btw";  //test.btw是BT的模板
            String lj = "C:\\001.btw";
            LabelFormatDocument btFormat = btEngine.Documents.Open(lj);
            //指定打印机名 
            //btFormat.PrintSetup.PrinterName = "HPRT HLP106S-UE";
            //btFormat.PrintSetup.PrinterName = "TEC";
            btFormat.PrintSetup.PrinterName = "POSTEK G-3106";
            //打印份数                   
            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
            //改变标签打印数份连载 
            btFormat.PrintSetup.NumberOfSerializedLabels = 2;
            //对BTW模版相应字段进行赋值 
            btFormat.SubStrings["kuanhao"].Value = this.stylename.Text;
            btFormat.SubStrings["haoxing"].Value = this.chicun01.Text;
            btFormat.SubStrings["mianliaohao"].Value = this.mianliaocd.Text;
            btFormat.SubStrings["chengfen"].Value = this.chengfen.Text;
            btFormat.SubStrings["shoujia"].Value = "¥" + this.shoujia.Text;
            int i = 1;
            foreach (dto尺寸 cy in this.dto无订单打印.dtos)
            {
                if (Convert.ToDouble(cy.fit_item_value) != 0)
                {
                    btFormat.SubStrings[i.ToString()].Value = cy.item_name_cn + " " + cy.fit_item_value;
                    //btFormat.SubStrings[i.ToString()+i.ToString()].Value = cy.fitValue;
                    i++;
                }
                if (i > 10)
                {
                    break;
                }
            }
            btFormat.SubStrings["styleid"].Value = this.dto无订单打印.clothes_log_id;
            Messages messages;
            int waitout = 10000; // 10秒 超时 
            Result nResult1 = btFormat.Print("吊牌" + this.dto无订单打印.clothes_log_id, waitout, out messages);
            btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
            //不保存对打开模板的修改 
            btFormat.Close(SaveOptions.DoNotSaveChanges);
            //结束打印引擎                  
            btEngine.Stop();
        }
        public void print条码()
        {
            Engine btEngine = new Engine();
            btEngine.Start();
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "顺丰订单模板.btw";  //test.btw是BT的模板
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "001.btw";  //test.btw是BT的模板
            String lj2 = "C:\\002.btw";
            LabelFormatDocument btFormat = btEngine.Documents.Open(lj2);
            //指定打印机名 
            //btFormat.PrintSetup.PrinterName = "HPRT HLP106S-UE";
            //btFormat.PrintSetup.PrinterName = "TEC";
            btFormat.PrintSetup.PrinterName = "POSTEK G-3106";
            //打印份数                   
            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
            //改变标签打印数份连载 
            btFormat.PrintSetup.NumberOfSerializedLabels = 2;
            //对BTW模版相应字段进行赋值 

            btFormat.SubStrings["styleid"].Value = this.dto无订单打印.clothes_log_id;
            Messages messages1;
            int waitout1 = 10000; // 10秒 超时 
            Result nResult2 = btFormat.Print("条码" + this.dto无订单打印.clothes_log_id, waitout1, out messages1);
            btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
            //不保存对打开模板的修改 
            btFormat.Close(SaveOptions.DoNotSaveChanges);
            //结束打印引擎                  
            btEngine.Stop();
        }

        private void Frm打标_Load(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.Properties.DataSource = ImpService.GetAllMaterial();
            this.shop = SQLmtm.GetDataTable("SELECT * FROM  t_shop");
            foreach (DataRow dr in this.shop.Rows)
            {
                //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                this.shopname.Items.Add(Convert.ToString(dr["shop_name"]));
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            DataRow dr = SQLmtm.GetDataRow("SELECT * FROM a_noorder_print_p WHERE clothes_log_id='" + this.tiaomaid.Text.Trim() + "';");
            if (e.KeyValue == 13) //判断是回车键
            {
                try
                {
                    List<Grid2information> grid2Information = new List<Grid2information>();
                    grid2Information.Add(new Grid2information("店铺", SQLmtm.GetDataRow("SELECT * FROM t_shop WHERE shop_id='" + dr["shop_id"].ToString() + "'")["shop_name"].ToString()));
                    grid2Information.Add(new Grid2information("styleid", dr["style_id"].ToString()));
                    grid2Information.Add(new Grid2information("款式名称", SQLmtm.GetDataRow("SELECT STYLE_NAME_CN FROM s_style_p WHERE SYS_STYLE_ID='" + dr["style_id"].ToString() + "'")["STYLE_NAME_CN"].ToString()));
                    grid2Information.Add(new Grid2information("面料id", dr["materials_id"].ToString()));
                    grid2Information.Add(new Grid2information("面料号", ImpService.GetMianLiaoCD(dr["materials_id"].ToString(), "dd")));
                    grid2Information.Add(new Grid2information("尺寸", dr["size_cd"].ToString()));
                    this.gridControl2.DataSource = grid2Information;
                    this.gridControl2.Refresh();
                }
                catch
                {

                }
                
            }

        }
        #region 选择面料
        private void searchLookUpEdit1_Popup(object sender, EventArgs e)
        {
            //得到当前SearchLookUpEdit弹出窗体
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            SearchEditLookUpPopup popup = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl layout = popup.Controls.OfType<LayoutControl>().FirstOrDefault();
            //如果窗体内空间没有确认按钮，则自定义确认simplebutton，取消simplebutton，选中结果label
            if (layout.Controls.OfType<Control>().Where(ct => ct.Name == "btOK").FirstOrDefault() == null)
            {
                //得到空的空间
                EmptySpaceItem a = layout.Items.Where(it => it.TypeName == "EmptySpaceItem").FirstOrDefault() as EmptySpaceItem;

                //得到取消按钮，重写点击事件
                Control clearBtn = layout.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
                LayoutControlItem clearLCI = (LayoutControlItem)layout.GetItemByControl(clearBtn);
                clearBtn.Click += clearBtn_Click;

                //添加一个simplebutton控件(确认按钮)
                LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
                myLCI.TextVisible = false;
            }
        }

        private void searchLookUpEdit1View_Click(object sender, EventArgs e)
        {
            var a = this.searchLookUpEdit1.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                this.dto无订单打印.materials_id //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "id").ToString();//id 是 Value Member
                this.dto无订单打印.materials_cd //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "materialCode").ToString();//id 是 Value Member
                this.dto无订单打印.materialComposition = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "materialComposition").ToString();
                this.dto无订单打印.materialNameCn = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "materialNameCn").ToString();
            }
            this.mianliaoid.Text = this.dto无订单打印.materials_id;
            this.mianliaocd.Text = this.dto无订单打印.materials_cd;
            this.chengfen.Text = this.dto无订单打印.materialComposition;
        }

        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.searchLookUpEdit1.ToolTip = null;
            searchLookUpEdit1.EditValue = null;
        }
        private void searchLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = this.dto无订单打印.materialNameCn;
        }
        #endregion
    }

    public class Grid2information
    {
        public String style { get; set; } = "";
        public String value { get; set; } = "";
        public Grid2information(String l1,String l2)
        {
            this.style = l1;
            this.value = l2;
        }
    }
}
