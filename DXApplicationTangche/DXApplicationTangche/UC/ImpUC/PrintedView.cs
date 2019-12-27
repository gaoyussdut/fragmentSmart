using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mendian;

namespace DXApplicationTangche
{
    public partial class PrintedView : UserControl
    {
        public PrintedView()
        {
            InitializeComponent();
        }
        public void refresh(String picn, List<CustomerInformation> customers)
        {
            try
            {
                this.pictureBox1.Image = Image.FromFile(picn);
            }
            catch
            {
            }
            try
            {
                this.gridControl1.DataSource = customers;
            }
            catch
            {
            }
        }
    }
}
