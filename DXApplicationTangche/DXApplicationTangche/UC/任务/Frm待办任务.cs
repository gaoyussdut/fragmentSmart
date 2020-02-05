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
using DXApplicationTangche.service;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DiaoPaiDaYin;

namespace DXApplicationTangche.UC.任务
{
    public partial class Frm待办任务 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public Frm待办任务()
        {
            InitializeComponent();
        }

        private void Frm待办任务_Load(object sender, EventArgs e)
        {
            this.searchLookUpEditUser.Properties.DataSource = UserService.getUserAll();
        }


        #region 选择负责人
        private String userId;  //  用户id
        private String userName;    //  用户名
        private void searchLookUpEditUser_Popup(object sender, EventArgs e)
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
            var a = this.searchLookUpEditUser.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                this.userId
                    = this.searchLookUpEditUser.Properties.View.GetRowCellValue(rowHandle, "LOGIN_USER_ID").ToString();//id 是 Value Member
                this.userName 
                    = this.searchLookUpEditUser.Properties.View.GetRowCellValue(rowHandle, "FIRST_NAME").ToString()
                    + this.searchLookUpEditUser.Properties.View.GetRowCellValue(rowHandle, "LAST_NAME").ToString()
                    ;//id 是 Value Member
            }
            //  TODO    刷新一览
        }

        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.searchLookUpEditUser.ToolTip = null;
            this.searchLookUpEditUser.EditValue = null;
        }
        private void searchLookUpEditUser_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = this.userName;
        }
        #endregion
    }
}