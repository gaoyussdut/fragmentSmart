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

namespace DXApplicationTangche.UC.库存.门店出库
{
    public partial class XtraFrm出货预览 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFrm出货预览(BindingList<BarCodeInfoDto> barCodeInfoDtos)
        {
            InitializeComponent();
            this.pivotGridControl.DataSource = barCodeInfoDtos;
        }
    }
}