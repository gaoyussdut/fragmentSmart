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

namespace DXApplicationTangche
{
    public partial class Frm标准款下单具体 : DevExpress.XtraEditors.XtraForm
    {
        public StyleCard styleCard { get; set; }
        public Frm标准款下单具体()
        {
            InitializeComponent();
        }
        public Frm标准款下单具体(StyleCard styleCard)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化
            this.styleCard = styleCard;
            InitializeComponent();
            this.label8.Text = styleCard.stylecardlabel.Text;
            Change.kuanshiid = styleCard.kuanshiid;
            try
            {
                this.pictureBox1.Image = Image.FromFile(styleCard.picture);
            }
            catch
            {

            }
        }
        private void Frm标准款下单具体_Load(object sender, EventArgs e)
        {
            Change.stylesizedt = ImpService.StyleCombobox(styleCard.kuanshiid);
            if (Change.stylesizedt != null)
            {
                foreach (DataRow dr in Change.stylesizedt.Rows)
                {
                    //this.chicun.Items.Add(Convert.ToString(dr["尺寸"]));
                    this.chicun01.Items.Add(Convert.ToString(dr["尺寸"]));
                }
            }
        }

        private void mianliaoname_Click(object sender, EventArgs e)
        {
            new MianLiaochoose(Change.kuanshiid).ShowDialog();
        }

        private void chicun01_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ImpService.StyleValue(this.chicun01.Text.Trim().ToString(), styleCard.kuanshiid, Change.stylesizedt);
            }
            catch
            {

            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new MianLiaochoose().ShowDialog();
        }

        private void Frm标准款下单具体_Activated(object sender, EventArgs e)
        {
            this.mianliaoname.Text = MianLiaochoose.mianliao;
        }
    }
}
