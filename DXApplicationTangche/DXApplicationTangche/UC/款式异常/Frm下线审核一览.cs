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
using DXApplicationTangche.UC.款式异常.DTO;

namespace DXApplicationTangche.UC.款式异常
{
    public partial class Frm下线审核一览 : DevExpress.XtraEditors.XtraForm
    {
        private List<下线DTO> 下线DTOs = new List<下线DTO>(); //  下线审核列表
        public Frm下线审核一览()
        {
            InitializeComponent();
        }
    }
}