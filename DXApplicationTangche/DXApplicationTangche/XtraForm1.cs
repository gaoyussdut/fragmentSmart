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

namespace DXApplicationTangche
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private List<OKRDto> oKRDtos = new List<OKRDto>();
        public XtraForm1()
        {
            InitializeComponent();

            List<任务详情Dto> xxx = new List<任务详情Dto>();
            xxx.Add(new 任务详情Dto("吃屎","窦鹏",DateTime.Now));
            xxx.Add(new 任务详情Dto("吃屎", "窦鹏", DateTime.Now));
            xxx.Add(new 任务详情Dto("吃屎", "窦鹏", DateTime.Now));
            this.oKRDtos.Add(new OKRDto("1", "我相关的任务", "操你妹", "黄药师", DateTime.Now, 15, xxx));
            this.oKRDtos.Add(new OKRDto("2", "我相关的任务", "操你妹", "黄药师", DateTime.Now, 100, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("3", "公司级OKR", "操你妹", "黄药师", DateTime.Now, 30, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("4", "公司级OKR", "操你妹", "黄药师", DateTime.Now, 50, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("5", "部门级OKR", "操你妹", "黄药师", DateTime.Now, 50, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("6", "部门级OKR", "操你妹", "黄药师", DateTime.Now, 50, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("7", "部门级OKR", "操你妹", "黄药师", DateTime.Now, 50, new List<任务详情Dto>() { }));
            this.oKRDtos.Add(new OKRDto("8", "我相关的任务", "操你妹", "黄药师", DateTime.Now, 50, new List<任务详情Dto>() { }));
            this.gridControl1.DataSource = this.oKRDtos;
        }

    }

    public class OKRDto
    {
        public String ID { get; set; }
        public String OKR { get; set; }
        public String Title { get; set; }
        public String Assignee { get; set; }
        public DateTime StartDate { get; set; }
        public int Progress { get; set; }
        public List<任务详情Dto> 任务详情 { get => dtos; set => dtos = value; }
        public List<string> 附件 { get => xx; set => xx = value; }

        private List<任务详情Dto> dtos = new List<任务详情Dto>();
        private List<String> xx = new List<string>();

        public OKRDto(String ID
            , String OKR
            , String Title
            , String Assignee
            , DateTime StartDate
            , int Progress
            , List<任务详情Dto> 任务详情
            )
        {
            this.ID = ID;
            this.OKR = OKR;
            this.Title = Title;
            this.Assignee = Assignee;
            this.StartDate = StartDate;
            this.Progress = Progress;
            this.dtos = 任务详情;
        }
    }

    public class 任务详情Dto { 
        public String 描述 { get; set; }
        public String 负责人 { get; set; }
        public DateTime 日期 { get; set; }

        public 任务详情Dto(String 描述, String 负责人, DateTime 日期) {
            this.描述 = 描述;
            this.负责人 = 负责人;
            this.日期 = 日期;
        }
    }
}