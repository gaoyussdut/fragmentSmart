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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;
using DevExpress.XtraGrid.Demos.util;

namespace DXApplicationTangche.UC.库存
{
    public partial class XtraFrm门店出库 : DevExpress.XtraEditors.XtraForm
    {
        BindingList<BarCodeInfoDto> barCodeInfoDtos = new BindingList<BarCodeInfoDto>();    //  条码信息
        List<String> barCodes = new List<string>(); //  条码
        public XtraFrm门店出库()
        {
            InitializeComponent();
        }

        #region 选择门店
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
                SimpleButton btOK = new SimpleButton() { Name = "btOK", Text = "确定" };
                btOK.Click += btOK_Click;
                myLCI.Control = btOK;
                myLCI.SizeConstraintsType = SizeConstraintsType.Custom;//控件的大小设置为自定义
                myLCI.MaxSize = clearLCI.MaxSize;
                myLCI.MinSize = clearLCI.MinSize;
                myLCI.Move(clearLCI, DevExpress.XtraLayout.Utils.InsertType.Left);
            }
        }

        public class LookUpMultSelectValues
        {
            public string FindText { get; set; }
            public List<string> SelectedValues { get; set; }
            public List<string> SelectedDisplays { get; set; }
        }
        //参与者
        private List<LookUpMultSelectValues> luValues = new List<LookUpMultSelectValues>();
        //参与者去重
        private List<string>[] GetLuValues()
        {
            List<string> r = new List<string>();
            foreach (var a in luValues)
            {
                r.AddRange(a.SelectedValues);
            }

            List<string> b = new List<string>();
            foreach (var a in luValues)
            {
                b.AddRange(a.SelectedDisplays);
            }
            return new[] { r.Distinct().ToList<string>(), b.Distinct().ToList<string>() };
        }

        /// <summary>
        /// 参与者清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.luValues.Clear();
            searchLookUpEdit1.EditValue = null;
        }
        /// <summary>
        /// 参与者确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            searchLookUpEdit1.ClosePopup();
        }


        private void searchLookUpEdit1_Closed(object sender, ClosedEventArgs e)
        {
            var re = GetLuValues();
            this.searchLookUpEdit1.EditValue = string.Join(",", re[1].ToArray());   //  name
            this.searchLookUpEdit1.ToolTip = string.Join(",", re[0].ToArray()); //  id
        }

        private void searchLookUpEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (FunctionHelper.GetValue(e.Value).Contains(","))
            {
                e.DisplayText = e.Value.ToString();
            }
            else
            {
                var re = GetLuValues();
                if (re[0].Count == 1)
                {
                    e.DisplayText = re[1].First();
                }
                else
                {
                    e.DisplayText = "";
                }
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string estateId = FunctionHelper.GetValue(this.searchLookUpEdit1.EditValue);
            //if (estateId != "")
            //{
            //    this.searchLookUpEdit1.Properties.Buttons[1].Visible = true;
            //}
            //else
            //{
            //    this.searchLookUpEdit1.ToolTip = null;
            //    this.searchLookUpEdit1.Properties.View.ClearSelection();
            //    this.searchLookUpEdit1.Properties.Buttons[1].Visible = false;
            //}
        }

        private void searchLookUpEdit1View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var a = this.searchLookUpEdit1.Properties.View.GetSelectedRows();
            var v = luValues.Find(b => b.FindText == this.searchLookUpEdit1.Properties.View.FindFilterText);
            if (v == null)
            {
                v = new LookUpMultSelectValues();
                v.FindText = this.searchLookUpEdit1.Properties.View.FindFilterText;
                v.SelectedValues = new List<string>();
                v.SelectedDisplays = new List<string>();
                luValues.Add(v);
            }
            if (a.Length > 0)
            {
                //新增状态时
                if (e.Action == CollectionChangeAction.Add)
                {
                    foreach (int rowHandle in a)
                    {
                        var vv = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "Id").ToString();//id 是 Value Member
                        if (string.IsNullOrEmpty(v.SelectedValues.Find(b => b == vv)))
                        {
                            v.SelectedValues.Add(vv);
                            v.SelectedDisplays.Add(this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "Name").ToString());//name 是 Display Member
                        }

                    }
                }
            }
            //删除状态时
            if (e.Action == CollectionChangeAction.Remove)
            {
                List<string> dels = new List<string>();
                List<string> deld = new List<string>();

                for (int i = 0; i < v.SelectedValues.Count; i++)
                {
                    bool finded = false;
                    foreach (int rowHandle in a)
                    {
                        var vv = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "Id").ToString();//id 是 Value Member
                        var vn = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "Name").ToString();//name 是 Display Member
                        if (v.SelectedValues[i] == vv)
                        {
                            finded = true;
                            break;
                        }
                    }

                    if (!finded)
                    {
                        dels.Add(v.SelectedValues[i]);
                        deld.Add(v.SelectedDisplays[i]);
                    }
                }

                v.SelectedValues.RemoveAll(b => dels.Contains(b));
                v.SelectedDisplays.RemoveAll(b => deld.Contains(b));

                for (int i = 0; i < luValues.Count; i++)
                {
                    var ev = luValues[i];

                    ev.SelectedValues.RemoveAll(b => dels.Contains(b));
                    ev.SelectedDisplays.RemoveAll(b => deld.Contains(b));
                }
            }
        }

        #endregion

        private void textEdit扫码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //判断是回车键
            {
                if (this.barCodes.Contains(this.textEdit扫码.Text))
                {
                    //  重复扫描
                    this.textEdit扫码.Text = "";
                    return;
                }
                else {
                    this.barCodes.Add(this.textEdit扫码.Text);
                }
                String sql = "select Id,ORDER_ID,CUSTOMER_ID,SHOP_ID,SHOP_NAME,STYLE_ID,ORDER_DATE,STYLE_NAME_CN,SYTLE_YEAR,SYTLE_SEASON,REF_STYLE_ID,SYTLE_FABRIC_ID,MATERIAL_NAME_CN,MATERIAL_COLOR,STYLE_PUBLISH_CATEGORY_CD,ORDER_NO from a_product_log_p " +
                    "where id not in (select barcode_id from t_godown_entry) and id = '"+this.textEdit扫码.Text+"'";
                this.textEdit扫码.Text = "";
                DataTable dt = SQLmtm.GetDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("本商品已出库");
                    return;
                }
                else {
                    this.barCodeInfoDtos.Add(new BarCodeInfoDto(dt));
                    this.gridControl1.DataSource = this.barCodeInfoDtos;
                    //this.pivotGridControl.ForceInitialize();
                    this.pivotGridControl.DataSource = this.barCodeInfoDtos;
                    this.pivotGridControl.RefreshData();
                }
            }
        }
    }
}