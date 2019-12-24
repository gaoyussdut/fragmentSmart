using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp1;

namespace DXApplicationTangche.UC
{
    public partial class XtraUC库存一览 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUC库存一览()
        {
            InitializeComponent();
        }

        private void XtraUC库存一览_Load(object sender, EventArgs e)
        {
            String sql = "select '入库' as stock_type,t_stock_detail.id,t_stock_detail.material_no,t_stock_detail.chima,t_stock_detail.create_date,t_stock_detail.amount "
                + " , t_material.style_id,t_material.age,t_material.season,t_material.sex,t_material.fuzhong,t_material.mianliao_no,t_material.mianliao_name"
                + "  from t_stock_detail"
                + "  left join t_material on t_material.material_no = t_stock_detail.material_no";
            
            this.pivotGridControl.DataSource = DBUtil.ExecuteDataTable(sql); ;
        }

        private void pivotGridControl_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            try
            {
                this.treeList1.DataSource = e.CreateDrillDownDataSource();
                this.treeList1.ExpandAll();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
