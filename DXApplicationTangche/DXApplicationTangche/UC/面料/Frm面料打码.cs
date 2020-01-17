using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DevExpress.Utils.Win;
using DXApplicationTangche.service;
using Seagull.BarTender.Print;

namespace DXApplicationTangche.UC.面料
{
    public partial class Frm面料打码 : DevExpress.XtraEditors.XtraForm
    {
        public List<面料条码打印dto> dtos = new List<面料条码打印dto>();
        public 面料条码打印dto dto = new 面料条码打印dto();
        public Frm面料打码()
        {
            InitializeComponent();
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
                this.dto.materialid //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "id").ToString();//id 是 Value Member
                this.dto.materialcd //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "materialCode").ToString();//id 是 Value Member
                this.dto.materialname = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "materialNameCn").ToString();
            }
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
                e.DisplayText = this.dto.materialcd + "  " + this.dto.materialname;
        }
        #endregion

        private void Frm面料打码_Load(object sender, EventArgs e)
        {
            RefreshGridControl();
            this.gridControl面料打码.DataSource = this.dtos;
            this.searchLookUpEdit1.Properties.DataSource = FabricService.GetAllMaterial();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FabricService.InsertMianLiaoLog(this.dto.materialid);
            this.print条码();
            RefreshGridControl();
        }
        public void print条码()
        {
            Engine btEngine = new Engine();
            btEngine.Start();
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "顺丰订单模板.btw";  //test.btw是BT的模板
            //string lj = AppDomain.CurrentDomain.BaseDirectory + "001.btw";  //test.btw是BT的模板
            String lj2 = "C:\\003.btw";
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

            btFormat.SubStrings["styleid"].Value = this.dto.materialid;
            btFormat.SubStrings["cd"].Value = this.dto.materialcd + "  "+this.dto.materialname;
            Messages messages1;
            int waitout1 = 10000; // 10秒 超时 
            Result nResult2 = btFormat.Print("条码" + this.dto.materialid, waitout1, out messages1);
            btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
            //不保存对打开模板的修改 
            btFormat.Close(SaveOptions.DoNotSaveChanges);
            //结束打印引擎                  
            btEngine.Stop();
        }
        private void RefreshGridControl()
        {
            DataTable dt = FabricService.GetMianLiaoLogDT();
            foreach (DataRow dr in dt.Rows)
            {
                this.dtos.Add(new 面料条码打印dto(dr));
            }
            this.gridControl面料打码.DataSource = this.dtos;
            this.gridControl面料打码.Refresh();
        }
    }
    public class 面料条码打印dto
    {
        public String materialid { get; set; }
        public String materialcd { get; set; }
        public String materialname { get; set; }
        public String MATERIAL_SOURCE { get; set; }//原辅料来源
        public String MATERIAL_SPEC { get; set; }//物料幅宽
        public String MATERIAL_GRAM_WEIGHT { get; set; }//原辅料克重
        public String MATERIAL_THREAD_COUNT { get; set; }//原辅料纱支密度
        public String MATERIAL_COMPOSITION { get; set; }//物料成分
        public String MATERIAL_OTHER1 { get; set; }//面料供应商名称
        public 面料条码打印dto(String id, String cd, String name, String materialname, String MATERIAL_SOURCE, String MATERIAL_SPEC, String MATERIAL_GRAM_WEIGHT, String MATERIAL_THREAD_COUNT, String MATERIAL_COMPOSITION, String MATERIAL_OTHER1)
        {
            this.materialid = id;
            this.materialcd = cd;
            this.materialname = name;
            this.MATERIAL_SOURCE = MATERIAL_SOURCE;
            this.MATERIAL_SPEC = MATERIAL_SPEC;
            this.MATERIAL_GRAM_WEIGHT = MATERIAL_GRAM_WEIGHT;
            this.MATERIAL_THREAD_COUNT = MATERIAL_THREAD_COUNT;
            this.MATERIAL_COMPOSITION = MATERIAL_COMPOSITION;
            this.MATERIAL_OTHER1 = MATERIAL_OTHER1;
        }
        public 面料条码打印dto(DataRow dr)
        {
            this.materialid = dr["MATERIAL_ID"].ToString();
            this.materialcd = dr["MATERIAL_CODE"].ToString();
            this.materialname = dr["MATERIAL_NAME_CN"].ToString();
            this.MATERIAL_SOURCE = dr["MATERIAL_SOURCE"].ToString();
            this.MATERIAL_SPEC = dr["MATERIAL_SPEC"].ToString();
            this.MATERIAL_GRAM_WEIGHT = dr["MATERIAL_GRAM_WEIGHT"].ToString();
            this.MATERIAL_THREAD_COUNT = dr["MATERIAL_THREAD_COUNT"].ToString();
            this.MATERIAL_COMPOSITION = dr["MATERIAL_COMPOSITION"].ToString();
            this.MATERIAL_OTHER1 = dr["MATERIAL_OTHER1"].ToString();
        }
        public 面料条码打印dto()
        {
            this.materialid = "";
            this.materialcd = "";
            this.materialname = "";
            this.MATERIAL_SOURCE = "";
            this.MATERIAL_SPEC = "";
            this.MATERIAL_GRAM_WEIGHT = "";
            this.MATERIAL_THREAD_COUNT = "";
            this.MATERIAL_COMPOSITION = "";
            this.MATERIAL_OTHER1 = "";
        }
    }
}