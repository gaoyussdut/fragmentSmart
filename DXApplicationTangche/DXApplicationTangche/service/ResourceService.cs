using mendian;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 资源服务
    /// </summary>
    class ResourceService
    {
        /// <summary>
        /// 同步图片资源到本地
        /// </summary>
        public static void synPictureResouces() {
            if (!Directory.Exists(@"xml"))
            {
                Directory.CreateDirectory(@"xml");
                Directory.CreateDirectory(@"pic");
                DealXML.ObjectToXMLFile(new List<StylePic>() { new StylePic("1", "1", "1", "1") }, @"xml\stylepicxml.xml", Encoding.UTF8);
                DealXML.ObjectToXMLFile(new List<MianLiaoPic>() { new MianLiaoPic("1", "1", "1", "1", "1") }, @"xml\mlpicxml.xml", Encoding.UTF8);
                DealXML.ObjectToXMLFile(new List<SheJiDianPic>() { new SheJiDianPic("1", "1", "1", "1", "1") }, @"xml\shjdpicxml.xml", Encoding.UTF8);
            }
            //款式图片更新
            StylePicList spl = new StylePicList();
            List<StylePic> styleOldlist = DealXML.XMLFlieToObject<List<StylePic>>(@"xml\stylepicxml.xml", Encoding.UTF8);
            List<StylePic> styleDifflist = ImpService.listCompare(spl.stylepiclist, styleOldlist);
            ImpService.DownloadDifferentPic(styleDifflist);
            bool yn = DealXML.ObjectToXMLFile(spl.stylepiclist, @"xml\stylepicxml.xml", Encoding.UTF8);
            //面料图片更新
            MianLiaoPicList mlpl = new MianLiaoPicList();
            //bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoOldlist = DealXML.XMLFlieToObject<List<MianLiaoPic>>(@"xml\mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoDifflist = ImpService.mianliaolistCompare(mlpl.mianliaopiclist, mianliaoOldlist);
            ImpService.DownloadMianliaoPic(mianliaoDifflist);
            bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"xml\mlpicxml.xml", Encoding.UTF8);
            //设计点图片更新
            SheJiDianPicList sjdpl = new SheJiDianPicList();
            //bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianOldlist = DealXML.XMLFlieToObject<List<SheJiDianPic>>(@"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianDifflist = ImpService.shejidianlistCompare(sjdpl.shejidianpiclist, shejidianOldlist);
            ImpService.DownloadSheJiDianPic(shejidianDifflist);
            bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);

        }
    }
}
