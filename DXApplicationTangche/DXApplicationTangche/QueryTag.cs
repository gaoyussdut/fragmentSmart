﻿using DevExpress.Utils.Design.Internal;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
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
    public partial class QueryTag : DevExpress.XtraEditors.XtraForm
    {
        public String ORDER_NO;
        public String style_id;
        public String order_text;
        public QueryTag()
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
            }
        }

        private void searchLookUpEdit1View_Click(object sender, EventArgs e)
        {
            var a = this.searchLookUpEdit1.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                this.ORDER_NO //  no
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "ORDER_NO").ToString();//id 是 Value Member
                this.style_id //  id
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "style_id").ToString();//name 是 Display Member
                this.order_text//text
                    = this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "ORDER_NO").ToString()+ this.searchLookUpEdit1.Properties.View.GetRowCellValue(rowHandle, "STYLE_NAME_CN").ToString();
            }
            this.gridControl1.DataSource = SQLmtm.GetDataTable("SELECT * FROM a_product_log_p WHERE ORDER_NO='" + this.ORDER_NO + "'");
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
                e.DisplayText = this.order_text;
        }
        #endregion

        private void QueryTag_Load(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM v_printed_p  ";
            this.searchLookUpEdit1.Properties.DataSource = SQLmtm.GetDataTable(sql);
        }
    }
}
