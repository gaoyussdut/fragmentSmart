﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationTangche.UC.门店下单.form;

namespace mendian
{
    public partial class UC面料卡片 : DevExpress.XtraEditors.XtraUserControl
    {
        public String mianliao;
        public String mianliaoid;
        public String mianliaocd;
        public String picurl;
        public String picn;
        public Frm面料选择 form;
        public bool flag;

        private Frm门店下单选款式 frm;

        public UC面料卡片()
        {
            InitializeComponent();
        }

        public UC面料卡片(String mianliao, String mianliaoid, String mianliaocd, String picurl, String picn, Frm面料选择 form, Frm门店下单选款式 frm)
        {
            InitializeComponent();
            this.frm = frm;
            this.flag = true;
            this.mianliao = mianliao;
            this.mianliaoid = mianliaoid;
            this.mianliaocd = mianliaocd;
            this.picurl = picurl;
            this.picn = picn;
            this.form = form;
            this.label1.Text = this.mianliao;
            try
            {
                this.pictureBox1.Image = Image.FromFile(@"pic\" + this.picn.Trim());
            }
            catch
            {
            }
        }

        public UC面料卡片(String mianliao, String mianliaoid, String mianliaocd, String picurl, String picn, Frm面料选择 form)
        {
            InitializeComponent();
            this.flag = true;
            this.mianliao = mianliao;
            this.mianliaoid = mianliaoid;
            this.mianliaocd = mianliaocd;
            this.picurl = picurl;
            this.picn = picn;
            this.form = form;
            this.label1.Text = this.mianliao;
            try
            {
                this.pictureBox1.Image = Image.FromFile(@"pic\" + this.picn.Trim());
            }
            catch
            {
            }
        }

        public UC面料卡片(String pic)
        {
            InitializeComponent();
            this.flag = false;
            try
            {
                this.pictureBox1.Image = Image.FromFile(@"pic\" + pic.Trim());
            }
            catch
            {
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.flag == true)
            {
                DialogResult dialogResult =
MessageBox.Show("确认保存“" + this.label1.Text + "”吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.frm.model.Dto定制下单.SYTLE_FABRIC_ID = this.mianliaoid;
                    Frm面料选择.mianliao = this.mianliao;
                    Frm面料选择.mianliaoid = this.mianliaoid;
                    Frm面料选择.mianliaocd = this.mianliaocd;
                    this.form.Close();
                }
                else
                {
                    return;
                }
            }

        }

    }
}
