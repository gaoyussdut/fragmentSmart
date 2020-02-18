using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplicationTangche.原型
{
    public class TaskDTOS
    {
        public List<TaskDTO> taskDTOs { get; set; } = new List<TaskDTO>();

        public TaskDTOS()
        {

        }
        public TaskDTOS buildTaskDTOs(String order_id)
        {
            DataTable dt = OrderService.get订单任务(order_id);
            foreach (DataRow dr in dt.Rows)
            {
                this.taskDTOs.Add(new TaskDTO(dr["remark_id"].ToString(), dr["template_id"].ToString(), dr["order_id"].ToString(), dr["style_id"].ToString(), dr["ref_style_id"].ToString(), dr["principal"].ToString(), dr["remark"].ToString(), dr["file_name"].ToString(), dr["parent_id"].ToString(), dr["version"].ToString(), dr["serial_number"].ToString(), dr["status"].ToString(), Convert.ToDateTime(dr["CREATE_DATE"].ToString())).buildTemplateName(dr["template_name"].ToString(), dr["template_group_id"].ToString(), dr["template_group_name"].ToString()));
            }
            return this;
        }
    }

    public class TaskDTO
    {
        public String remark_id { get; set; }//主键id
        public String template_id { get; set; }//模板id
        public String order_id { get; set; }//订单id
        public String style_id { get; set; }//款式id
        public String ref_style_id { get; set; }//参考款式
        public String principal { get; set; }//负责人
        public String remark { get; set; }//文档
        public String file_name { get; set; }//文档名
        public String parent_id { get; set; }//父id
        public String version { get; set; }//版本
        public String data { get; set; }//json data
        public String template_name { get; set; }//模板名称
        public String template_group_id { get; set; }//模板组id
        public String template_group_name { get; set; }//模板组名称
        public String serial_number { get; set; }//流水号
        public String status { get; set; }//状态
        public String A_JSON { get; set; }//Answer Json
        public String A_FILE { get; set; }//Anser 文件
        public DateTime CREATE_DATE { get; set; }//创建时间
        public List<UCDocument> uCDocuments { get; set; } = new List<UCDocument>();//单据数据
        public Dictionary<String, String> dic { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 初始化
        /// </summary>
        public TaskDTO()
        {
            this.remark_id = null;//主键id
            this.template_id = null;//模板id
            this.order_id = null;//订单id
            this.style_id = null;//款式id
            this.ref_style_id = null;//参考款式
            this.principal = null;//负责人
            this.remark = null;//文档
            this.file_name = null;//文档名
            this.parent_id = null;//父id
            this.version = null;//版本
            this.data = null;//json data
            this.template_name = null;//模板名称
            this.template_group_id = null;//模板组id
            this.template_group_name = null;//模板组名称
            this.serial_number = null;//流水号
            this.status = null;//状态
            //this.CREATE_DATE = DateTime.Now;//创建时间
            this.uCDocuments = null;//单据数据
            this.dic = null;
        }
        /// <summary>
        /// 新增任务
        /// </summary>
        /// <param name="template_id"></param>
        /// <param name="order_id"></param>
        /// <param name="style_id"></param>
        /// <param name="ref_style_id"></param>
        /// <returns></returns>
        public TaskDTO buildNewDTO(String template_id, String order_id, String style_id, String ref_style_id)
        {
            this.template_id = template_id;
            this.order_id = order_id;
            this.style_id = style_id;
            this.ref_style_id = ref_style_id;
            return this;
        }
        /// <summary>
        /// 模板名称添加
        /// </summary>
        /// <param name="template_name"></param>
        /// <param name="template_group_id"></param>
        /// <param name="template_group_name"></param>
        /// <returns></returns>
        public TaskDTO buildTemplateName(String template_name, String template_group_id, String template_group_name)
        {
            this.template_name = template_name;
            this.template_group_id = template_group_id;
            this.template_group_name = template_group_name;
            return this;
        }
        public TaskDTO(string remarkid, string template_id, string order_id, string style_id, string ref_style_id, string principal, string remark, string file_name, string parent_id, string version, string serial_number, string status, DateTime CREATE_DATE)
        {
            this.remark_id = remarkid;
            this.template_id = template_id;
            this.order_id = order_id;
            this.style_id = style_id;
            this.ref_style_id = ref_style_id;
            this.principal = principal;
            this.remark = remark;
            this.file_name = file_name;
            this.parent_id = parent_id;
            this.version = version;
            this.serial_number = serial_number;
            this.status = status;
            this.CREATE_DATE = CREATE_DATE;
            this.dic.Add("order_id", order_id);
            this.dic.Add("style_id", style_id);
            this.dic.Add("ref_style_id", ref_style_id);
        }
        /// <summary>
        /// 存入数据库
        /// </summary>
        public void SaveInMTM()
        {
            OrderService.Save订单任务(this);
        }
        /// <summary>
        /// UC内容保存至DTO
        /// </summary>
        /// <param name="remark"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public TaskDTO buildForUC(String remark, String data, String file_name)
        {
            this.remark = remark;
            this.data = data;
            this.file_name = file_name;
            return this;
        }
        /// <summary>
        /// 单据转为json存入data
        /// </summary>
        /// <returns></returns>
        public TaskDTO buildData()
        {
            this.data = Newtonsoft.Json.JsonConvert.SerializeObject(this.uCDocuments);
            return this;
        }
        /// <summary>
        /// 读取任务
        /// </summary>
        /// <param name="remark_id"></param>
        /// <returns></returns>
        public TaskDTO buildRead(String remark_id)
        {
            DataRow dr = OrderService.GetTaskRead(remark_id);
            TaskDTO taskDTO = new TaskDTO(dr["remark_id"].ToString(), dr["template_id"].ToString(), dr["order_id"].ToString(), dr["style_id"].ToString(), dr["ref_style_id"].ToString(), dr["principal"].ToString(), dr["remark"].ToString(), dr["file_name"].ToString(), dr["parent_id"].ToString(), dr["version"].ToString(), dr["serial_number"].ToString(), dr["status"].ToString(), Convert.ToDateTime(dr["CREATE_DATE"].ToString())).buildTemplateName(dr["template_name"].ToString(), dr["template_group_id"].ToString(), dr["template_group_name"].ToString()).buildDoJson(dr["data"].ToString());
            return taskDTO;
        }
        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TaskDTO buildDoJson(String data)
        {
            this.data = data;
            try
            {
                this.uCDocuments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UCDocument>>(this.data);
            }
            catch(Exception ex)
            {
                MessageBox.Show("当前时间：" + DateTime.Now.ToString() + "\n" +
"异常信息：" + ex.Message + "\n" +
"异常对象：" + ex.Source + "\n" +
"调用堆栈：\n" + ex.StackTrace.Trim() + "\n" +
"触发方法：" + ex.TargetSite + "\n");
            }
            return this;
        }
        /// <summary>
        /// 生成流水号
        /// </summary>
        /// <returns></returns>
        public TaskDTO buildserial_number()
        {
            this.serial_number = FunctionHelper.generateBillNo("t_remark", "remark_id", "TR", "000000");//生成流水号
            return this;
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaskDTO buildStatus(int id)
        {
            switch (id)
            {
                case 1: this.status = "MS_01"; break;//未签收
                case 2: this.status = "MS_02"; break;//已签收
                case 3: this.status = "MS_03"; break;//已完成
            }
            return this;
        }
    }
    /// <summary>
    /// 单据dtos
    /// </summary>
    public class UCDocumentS
    {
        public List<UCDocument> uCDocuments = new List<UCDocument>();
        public UCDocumentS()
        {

        }
    }
    /// <summary>
    /// 单据dto
    /// </summary>
    public class UCDocument
    {
        public String title { get; set; }//题目
        public String value { get; set; }//值
        public UCDocument(String title, String value)
        {
            this.title = title;
            this.value = value;
        }
    }
}
