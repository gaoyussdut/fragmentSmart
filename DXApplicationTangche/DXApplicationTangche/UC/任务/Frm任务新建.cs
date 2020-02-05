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
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using DXApplicationTangche.service;
using System.IO;

namespace DXApplicationTangche.UC.任务
{
    public partial class Frm任务新建 : DevExpress.XtraEditors.XtraForm
    {
        public Frm任务新建()
        {
            InitializeComponent();
            this.searchLookUpEditTaskTemplate.Properties.DataSource = TaskService.getTaskTemplateDTO();            
        }

        #region 选择任务模板
        private String TEMPLATE_ID;  //  任务模板ID
        private String TEMPLATE_NAME;    //  任务模板名称
        private String TEMPLATE_XML;    //  任务模板
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
            var a = this.searchLookUpEditTaskTemplate.Properties.View.GetSelectedRows();
            foreach (int rowHandle in a)
            {
                this.TEMPLATE_ID
                    = this.searchLookUpEditTaskTemplate.Properties.View.GetRowCellValue(rowHandle, "TEMPLATE_ID").ToString();//id 是 Value Member
                this.TEMPLATE_NAME
                    = this.searchLookUpEditTaskTemplate.Properties.View.GetRowCellValue(rowHandle, "TEMPLATE_NAME").ToString();//id 是 Value Member
                this.TEMPLATE_XML
                    = this.searchLookUpEditTaskTemplate.Properties.View.GetRowCellValue(rowHandle, "TEMPLATE_XML").ToString();//id 是 Value Member

                System.IO.File.WriteAllText(this.TEMPLATE_ID + ".xml", this.TEMPLATE_XML);  //  写入文件

                this.layoutControlTaskTemplate.RestoreLayoutFromXml("layout_xml\\定制下单.xml");
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
            this.searchLookUpEditTaskTemplate.ToolTip = null;
            this.searchLookUpEditTaskTemplate.EditValue = null;
        }
        private void searchLookUpEditUser_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (null != e.Value)
                e.DisplayText = this.TEMPLATE_NAME;
        }
        #endregion
    }
}