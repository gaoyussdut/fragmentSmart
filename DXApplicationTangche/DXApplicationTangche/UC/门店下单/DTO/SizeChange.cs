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
    public partial class SizeChange : Form
    {
        //private Change form = new Change(StyleCard uc);
        public SizeChange()
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            InitializeComponent();
            this.label20.Text = Change.kuanshiid;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (this.name.Text.Trim() == "" || this.name.Text.Trim() == null)
            //{
            //    MessageBox.Show("请填写完整");
            //}

            DialogResult dialogResult =MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int i = 1;
                    //DBUtil.ExecuteSQL("INSERT INTO chunshan_liangtichicun(id, name, shouji, sex, age, shengao, tizhong, xiongwei, lingwei, yaowei, biwei, shenchang, jiankuan, bichang, bigenwei) VALUES (uuid_generate_v4(), '" + this.name.Text + "', '" + this.shouji.Text + "', '" + this.sex.Text + "', '" + this.age.Text + "', " + this.shengao.Text + ", " + this.tizhong.Text + ", " + this.xiongwei.Text + ", " + this.lingwei.Text + ", " + this.yaowei.Text + ", " + this.biwei.Text + ", " + this.shenchang.Text + ", " + this.jiankuan.Text + ", " + this.bichang.Text + ", " + this.bigenwei.Text + ");");
                if (0==i)
                {
                    MessageBox.Show("保存成功!");
                    //this.closeForm();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            else
            {
                return;
            }

        }
        //public SizeChange(Change form)
        //{
        //    this.WindowState = FormWindowState.Maximized;//窗体最大化
        //    this.form = form;
        //    InitializeComponent();
        //    this.label1.Text=form.
        //}

    }
}
