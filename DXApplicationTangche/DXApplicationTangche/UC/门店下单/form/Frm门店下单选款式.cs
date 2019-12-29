﻿using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DXApplicationTangche.UC.门店下单.form.Frm门店统一下单;

namespace DXApplicationTangche.UC.门店下单.form
{
    public partial class Frm门店下单选款式 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static int page { get; set; } = 1;
        public Dto定制下单 Dto定制下单 { get => dto定制下单; set => dto定制下单 = value; }

        private PanelLocition panelLocition;
        int height = 0;//用户控件纵坐标
        int width = 0;  //用户控件横坐标

        private Frm门店统一下单 frm;

        private Dto定制下单 dto定制下单;

        public Frm门店下单选款式(Frm门店统一下单 frm, Enum下单类型 enum下单类型)
        {
            InitializeComponent();
            this.fenYeLan1.xiaye.Click += new EventHandler(this.xiaye_Button);
            this.fenYeLan1.shangye.Click += new EventHandler(this.shangye_Button);

            this.frm = frm;
            dto定制下单 = new Dto定制下单();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息

            Frm标准款下单.page = 1;

            //  图片布局
            this.generatePictureLayout();
        }
        /// <summary>
        /// 图片布局
        /// </summary>
        private void generatePictureLayout()
        {
            this.panel1.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            DataTable dt = ImpService.initStyle(this.textBox1.Text, Frm标准款下单.page);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("已经是最后一页");
                Frm标准款下单.page--;
                dt = ImpService.initStyle(this.textBox1.Text, Frm标准款下单.page);
            }
            panelLocition = new PanelLocition(this.panel1.Width, this.panel1.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                StyleCard sc = new StyleCard(this, "门店下单选款式", dr);
                this.generateUserControl(sc, i);
                this.panel1.Controls.Add(sc);//将控件加入panel
                try
                {
                    sc.stylecardpicbox.Image = Image.FromFile(sc.picture);
                }
                catch
                {

                }
                i++;
            }
            this.fenYeLan1.label1.Text = Frm标准款下单.page.ToString();
            this.splashScreenManager.CloseWaitForm();
        }
        public void generateUserControl(UserControl userControl, int i)
        {
            userControl.Name = "pic" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 7 == 0)
                {
                    width = 0;
                    height += 200;
                }
            }
            userControl.Location = new Point(panelLocition.UcLeft + width * 160, panelLocition.UcHeight + height);//控件位置
            width++;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xiaye_Button(object sender, EventArgs e)
        {
            //  初始化页面
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            Frm标准款下单.page++;
            //  图片布局
            this.generatePictureLayout();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shangye_Button(object sender, EventArgs e)
        {
            if (Frm标准款下单.page == 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            Frm标准款下单.page--;

            //  图片布局
            this.generatePictureLayout();
        }

        private void Frm门店下单选款式_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new MianLiaochoose(this).ShowDialog();
        }

        private void mianliaoname_Click(object sender, EventArgs e)
        {
            new MianLiaochoose(Dto定制下单.Style_Id, this).ShowDialog();
        }

        private void Frm门店下单选款式_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = MianLiaochoose.mianliao;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认保存吗？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ImpService.DynamicSaveSize(this, this.Dto定制下单);//尺寸保存
                ImpService.DynamicSaveDesign(this, this.Dto定制下单);//设计点保存
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //DataTable dt = ImpService.StyleValue(this.chicun01.Text.Trim().ToString(), Dto定制下单.Style_Id, Change.stylesizedt);
            //ImpService.RefreshChiCun(this, dt);
            //ImpService.CountChiCun(this);
        }

        private void jisuan_Click(object sender, EventArgs e)
        {

        }

        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ImpService.StyleValue(this.chicun01.Text.Trim().ToString(), Dto定制下单.Style_Id, Change.stylesizedt);
            ImpService.RefreshChiCun(this, dt);
            ImpService.CountChiCun(this);
        }
    }
}
