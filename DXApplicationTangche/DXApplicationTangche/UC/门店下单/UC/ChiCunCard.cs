using System;
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
    public partial class ChiCunCard : UserControl
    {
        public String iTEM_CD = "";
        public String iTEM_VALUE = "";
        public String fIT_VALUE = "";
        public String nAME_CN = "";
        public String fIT_ITEM_VALUE = "";
        //public ReviseStyle form;
        public Change change;
        public Frm门店下单选款式 frm;
        public ChiCunCard()
        {
            InitializeComponent();
        }
        public ChiCunCard(String itemcd, String itemvalue, String namecn,String fit_item_value,Change change)
        {
            iTEM_CD = itemcd;
            iTEM_VALUE = itemvalue;           
            nAME_CN = namecn;
            InitializeComponent();
            this.label1.Text = nAME_CN;
            fIT_ITEM_VALUE = fit_item_value;
            this.change = change;          
        }
        public ChiCunCard(String itemcd, String itemvalue, String namecn, String fit_item_value, Frm门店下单选款式 frm)
        {
            iTEM_CD = itemcd;
            iTEM_VALUE = itemvalue;
            nAME_CN = namecn;
            InitializeComponent();
            this.label1.Text = nAME_CN;
            fIT_ITEM_VALUE = fit_item_value;
            this.frm = frm;
        }

        //public ChiCunCard(String itemcd, String itemvalue, String namecn, String fit_item_value,ReviseStyle form)
        //{
        //    iTEM_CD = itemcd;
        //    iTEM_VALUE = itemvalue;
        //    nAME_CN = namecn;
        //    InitializeComponent();
        //    this.label1.Text = nAME_CN;
        //    fIT_ITEM_VALUE = fit_item_value;
        //    this.form = form;
        //}

        private void jia_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.jian.Text != "" && this.jian.Text != "0")
            {
                this.jia.Text = "0";
                MessageBox.Show("加减值冲突");
            }
        }

        private void jian_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.jia.Text != "" && this.jia.Text != "0")
            {
                this.jian.Text = "0";
                MessageBox.Show("加减值冲突");
            }
        }

        private void jia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImpService.CountChiCun(this.frm);
            }
            catch
            {
                ImpService.CountChiCun(change);
            }          
        }

        private void jian_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ImpService.CountChiCun(this.frm);
            }
            catch
            {
                ImpService.CountChiCun(change);
            }
        }
    }
}
