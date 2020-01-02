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
using mendian;

namespace DXApplicationTangche.UC.款式异常
{
    public partial class Frm款式异常 : DevExpress.XtraEditors.XtraForm
    {
        public Frm款式异常()
        {
            InitializeComponent();
            this.gridControl款式一览.DataSource = ImpService.getAllStyle();
        }
    }
}