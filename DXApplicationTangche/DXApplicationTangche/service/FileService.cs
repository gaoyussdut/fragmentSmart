using DiaoPaiDaYin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DXApplicationTangche.service
{
    class FileService
    {
        public static void updateTempalteFile(String fileName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择文件";
            ofd.Filter = "(*xlsx;*.xls;*.docx;*.doc;*.pdf)|*xlsx;*.xls;*.docx;*.doc;*.pdf";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Byte[] byteArray = FileBinaryConvertHelper.File2Bytes(ofd.FileName);
                String str = Convert.ToBase64String(byteArray);
                //int i = DBUtil.ExecuteSQL("UPDATE task_template SET task_template_file = '" + str + "',task_template_file_name='" + ofd.SafeFileName + "' WHERE task_template_name = '" + this.barTaskTemplate.EditValue + "'");
                //int i = DocService.UpdataMoBan(str, ofd.SafeFileName, fileName);
                //if (i != 0)
                //{
                //    MessageBox.Show("上传成功");
                //}
            }
        }
        /*
        public static void uploadTaskFile(String taskId, String empId)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择文件";
            ofd.Filter = "(*xlsx;*.xls;*.docx;*.doc;*.pdf)|*xlsx;*.xls;*.docx;*.doc;*.pdf";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Byte[] byteArray = FileBinaryConvertHelper.File2Bytes(ofd.FileName);
                String fileStr = Convert.ToBase64String(byteArray);

                String uuid = System.Guid.NewGuid().ToString("N");
                string sql = "insert into file (id,filename,file)"
                    + " values('" + uuid + "'"
                    + "         , '" + ofd.SafeFileName + "'"
                    + "         , '" + fileStr + "'); ";
                DBUtil.ExecuteSQL(sql);
                sql = "update custom_appointment_assignee"
                    + " set file_id = '" + uuid + "'"
                    + " , status = '" + (int)EnumAssignment.已完成 + "'"
                    + " where task_id = '" + taskId + "' and emp_id = '" + empId + "'; ";
                int i = DBUtil.ExecuteSQL(sql);
                //int i = DocService.UpdataMoBan(str, ofd.SafeFileName, fileName);
                if (i != 0)
                {
                    MessageBox.Show("上传成功");
                }
            }
        }*/
        /// <summary>
        /// 保存备注文档
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="orderid"></param>
        public static void SaveRemarkFile(String file,String fileName,String orderid)
        {
            String sql = "SELECT * FROM t_remark WHERE order_id='" + orderid + "'";
            if(SQLmtm.GetDataRow(sql)==null)
            {
                SQLmtm.DoInsert("t_remark", new string[] { "order_id", "remark", "file_name" }, new string[] { orderid, file, fileName });
            }
            else
            {
                SQLmtm.DoUpdate("t_remark", new string[] { "remark" }, new string[] { file }, new string[] { "order_id" }, new string[] { orderid });
            }
        }
    }
}
