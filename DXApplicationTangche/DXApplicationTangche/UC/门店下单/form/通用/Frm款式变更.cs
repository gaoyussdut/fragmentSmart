using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mendian
{
    public partial class Frm款式变更 : Form
    {
        public Frm款式变更()
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            InitializeComponent();
            this.label1.Text = Frm定制下单修改尺寸.kuanshiid;

        }

        private void stylechangesave_Click(object sender, EventArgs e)
        {

        }
    }
}
