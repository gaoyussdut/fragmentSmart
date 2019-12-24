using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    class Style
    {
        public static List<ReducedTokenDataDto> temporarytTokenDataDtoList { get; set; }
        public static List<String> temporaryStyle { get; set; }
        public static List<DingDanDTO> temporaryDingDanDTO { get; set; }
        private Dictionary<String, String> relationCaptionAndKey = new Dictionary<String, String>();
        private List<DingDanDTO> dingDanDTO = new List<mendian.DingDanDTO>();
        private List<String> style=new List<string>();
        private List<ReducedTokenDataDto> tokenDataDtoList=new List<ReducedTokenDataDto>();
        private List<Card> card = new List<Card>();
        public Style()
        {
            //getJsonData("dingdan");
            GetData.GetTokenDataDtoList(tokenDataDtoList);
            //style =GetData.GetJsonData(GetData.GetDingDanDTO(tokenDataDtoList));
            Card = GetData.GetCard(tokenDataDtoList);
            temporaryDingDanDTO = GetData.GetDingDanDTO(tokenDataDtoList);
            temporaryStyle = style;
            temporarytTokenDataDtoList = tokenDataDtoList;
            //String[] a = new string[]
            //{
            //    "千鸟格女休闲西裤", "静谧蓝条纹女衫", "女士方格休闲衬衫", "棉弹格商务女衫", "女士印花休闲衬衫","棉弹条纹女衫", "鱼尾宽黄蓝条衬衫裙",
            //    "长袖棉麻印花女衫", "亮色系纯棉平纹休闲女衫" ,"纯棉直筒通勤衬衫","棉弹V领套头休闲格衬衫","棉弹V领套头休闲墨绿衬衫","超薄纯棉休闲V领衬衫"};
            //style.AddRange(a);
        }
        private void getMetaData(string metaId)
        {
            //String viewDtostrMeta = RestCall.httpGetMethod("http://192.168.1.7:5090/meta/findByMetaId?metaId=" + metaId);
            //Result metaInfos = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(viewDtostrMeta);
            //List<MetaInfoDTO> metaInfoDTOs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MetaInfoDTO>>(metaInfos.data.ToString());
            //foreach (MetaInfoDTO metaInfo in metaInfoDTOs)
            //{
            //    this.Dt.Columns.Add(metaInfo.caption);
            //    RelationCaptionAndKey.Add(metaInfo.key, metaInfo.caption);
            //}
        }

        public List<ReducedTokenDataDto> getReducedTokenDataDtos(string ttid) {
            String viewDtostrToken = RestCall.httpGetMethod("http://192.168.1.7:5090/bill/generalView?tokenTemplateId=" + ttid + "&pageSize=" + "500" + "&pageNo=" + "1");
            Result previewResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(viewDtostrToken);
            PreviewDTO previewDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<PreviewDTO>(previewResult.data.ToString());
            return previewDTO.datas.tokenDataDtoList;     
        }

        //public List<ReducedTokenDataDto> getReducedTokenDataDtos(List<String> metaKeys, string ttid)
        //{
        //    List<ReducedTokenDataDto> tokenDataDtoList = new List<ReducedTokenDataDto>();

        //    DataTable dt = DBUtil.ExecuteDataTable("select * from chunshan_kuanshibiao LEFT JOIN  chunshan_mianliao on chunshan_kuanshibiao.mianliaoid=chunshan_mianliao.id");
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        List<ReducedFkeyField> reducedFkeyFields = new List<ReducedFkeyField>();
        //        //  TODO,用meta信息for
        //        reducedFkeyFields.Add(new ReducedFkeyField("kuanhao", Convert.ToString(dr["kuanhao"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("mingcheng", Convert.ToString(dr["mingcheng"])));

        //        reducedFkeyFields.Add(new ReducedFkeyField("mianliaohoudu", Convert.ToString(dr["mianliaohoudu"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("shiyongjijie", Convert.ToString(dr["shiyongjijie"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("mianliaozhishu", Convert.ToString(dr["mianliaozhishu"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("mianliaotanli", Convert.ToString(dr["mianliaotanli"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("mianliaochengfen", Convert.ToString(dr["mianliaochengfen"])));
        //        reducedFkeyFields.Add(new ReducedFkeyField("mianliaokezhong", Convert.ToString(dr["mianliaokezhong"])));
        //        tokenDataDtoList.Add(new ReducedTokenDataDto(Convert.ToString(dr["id"]) , reducedFkeyFields));
        //    }
        //    //"select * from "+  ttid;
        //    //metaKeys.ForEach().
        //    return tokenDataDtoList;
        //}

        //private void getJsonData(List<ReducedTokenDataDto> tokenDataDtoList)
        //{
        //    List<ReducedFkeyField> ssstyle = new List<ReducedFkeyField>();
        //    //List<string> style = new List<string>();
        //    foreach (ReducedTokenDataDto sstyle in tokenDataDtoList)
        //    {
        //        //dingDanDTO.Add(new DingDanDTO { TokenId = sstyle.tokenId });
        //        //ssstyle.AddRange(sstyle.fields);
        //        foreach (ReducedFkeyField sssstyle in sstyle.fields)
        //        {
        //            if (sssstyle.key == "mingcheng")
        //            {
        //                jsData = sssstyle.jsonData;
        //                //style.Add(sssstyle.jsonData);
        //            }
        //        }
        //        dingDanDTO.Add(new DingDanDTO { TokenId = sstyle.tokenId, Mingcheng = jsData });
        //    }
        //    foreach (DingDanDTO dindanDTO in DingDanDTO)
        //    {
        //        style.Add(dindanDTO.Mingcheng);
        //    }
        //}
        public List<string> Styles
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }

        public Dictionary<string, string> RelationCaptionAndKey
        {
            get
            {
                return relationCaptionAndKey;
            }

            set
            {
                relationCaptionAndKey = value;
            }
        }

        internal List<DingDanDTO> DingDanDTO
        {
            get
            {
                return dingDanDTO;
            }

            set
            {
                dingDanDTO = value;
            }
        }

        internal List<Card> Card
        {
            get
            {
                return card;
            }

            set
            {
                card = value;
            }
        }
    }
}
