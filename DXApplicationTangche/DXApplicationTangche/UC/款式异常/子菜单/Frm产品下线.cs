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
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.款式异常.DTO;
using mendian;

namespace DXApplicationTangche.UC.款式异常.子菜单
{
    public partial class Frm产品下线 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private 下线DTO 下线DTO;
        public Frm产品下线(List<款式图片一览Dto> 款式图片一览Dtos)
        {
            InitializeComponent();
            this.下线DTO = new 下线DTO(款式图片一览Dtos);
            this.gridControl待办.DataSource = this.下线DTO.款式一览;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  执行下线操作
            Service下线.Func产品下线(this.下线DTO);

            //  控件行为
            MessageBox.Show("已提交审核");
            this.gridControl待办.DataSource = new List<款式图片一览Dto>();
            this.gridView待办.RefreshData();
        }
    }
}