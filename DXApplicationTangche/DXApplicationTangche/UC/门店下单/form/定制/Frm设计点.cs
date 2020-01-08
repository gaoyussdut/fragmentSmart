using DiaoPaiDaYin;
using DXApplicationTangche.UC.款式异常;
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
    public partial class AllSheJiDian : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public  设计点图片Model model { get; set; }
        private UC设计点选择 card;
        public AllSheJiDian()
        {
            InitializeComponent();
        }

        public AllSheJiDian(UC设计点选择 card)
        {
            InitializeComponent();
            this.card = card;
            this.Text = this.card.PitemName;
            generatePictureLayout();
        }
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            generatePictureLayout();
        }

        private void generatePictureLayout()
        {
            this.splashScreenManager.ShowWaitForm();
            this.splashScreenManager.SetWaitFormCaption("请稍后,正在加载中....");     // 标题
            this.splashScreenManager.SetWaitFormDescription("正在初始化.....");　　　　　// 信息
            this.model = new 设计点图片Model(this.card.PitemValue,this.textBox11.Text);
            this.gridControl1.DataSource = this.model.设计点s;
            this.splashScreenManager.CloseWaitForm();
        }
    }
}
