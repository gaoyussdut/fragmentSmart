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
            List<StylePic> styleDifflist = ResourceService.listCompare(spl.stylepiclist, styleOldlist);
            PictureService.DownloadDifferentPic(styleDifflist);
            bool yn = DealXML.ObjectToXMLFile(spl.stylepiclist, @"xml\stylepicxml.xml", Encoding.UTF8);
            //面料图片更新
            MianLiaoPicList mlpl = new MianLiaoPicList();
            //bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoOldlist = DealXML.XMLFlieToObject<List<MianLiaoPic>>(@"xml\mlpicxml.xml", Encoding.UTF8);
            List<MianLiaoPic> mianliaoDifflist = ResourceService.mianliaolistCompare(mlpl.mianliaopiclist, mianliaoOldlist);
            PictureService.DownloadMianliaoPic(mianliaoDifflist);
            bool mlyn = DealXML.ObjectToXMLFile(mlpl.mianliaopiclist, @"xml\mlpicxml.xml", Encoding.UTF8);
            //设计点图片更新
            SheJiDianPicList sjdpl = new SheJiDianPicList();
            //bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianOldlist = DealXML.XMLFlieToObject<List<SheJiDianPic>>(@"xml\shjdpicxml.xml", Encoding.UTF8);
            List<SheJiDianPic> shejidianDifflist = ResourceService.shejidianlistCompare(sjdpl.shejidianpiclist, shejidianOldlist);
            PictureService.DownloadSheJiDianPic(shejidianDifflist);
            bool shjdyn = DealXML.ObjectToXMLFile(sjdpl.shejidianpiclist, @"xml\shjdpicxml.xml", Encoding.UTF8);
        }

        /// <summary>
        ///比较两个list，取出存在menuOneList中，但不存在resourceList中的数据，差异数据放入differentList
        /// </summary>
        /// <param name="newlist">新list</param>
        /// <param name="oldlist">旧list</param>
        private static List<StylePic> listCompare(List<StylePic> newlist, List<StylePic> oldlist)
        {
            List<StylePic> differentList = new List<StylePic>();
            int i = 0;
            foreach (StylePic nl in newlist)
            {
                i = 0;
                foreach (StylePic ol in oldlist)
                {
                    if (nl.styleCd != ol.styleCd || nl.styleId != ol.styleId || nl.stylePicN != ol.stylePicN || nl.stylePicURL != ol.stylePicURL)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }


        /// <summary>
        /// 比较面料图片
        /// </summary>
        /// <param name="newlist"></param>
        /// <param name="oldlist"></param>
        /// <returns></returns>
        private static List<MianLiaoPic> mianliaolistCompare(List<MianLiaoPic> newlist, List<MianLiaoPic> oldlist)
        {
            List<MianLiaoPic> differentList = new List<MianLiaoPic>();
            int i = 0;
            foreach (MianLiaoPic nl in newlist)
            {
                i = 0;
                foreach (MianLiaoPic ol in oldlist)
                {
                    if (nl.mianliao != ol.mianliao || nl.mianliaoid != ol.mianliaoid || nl.mianliaocd != ol.mianliaocd || nl.picn != ol.picn || nl.picurl != ol.picurl)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }

        /// <summary>
        /// 比较设计点图片
        /// </summary>
        /// <param name="newlist"></param>
        /// <param name="oldlist"></param>
        /// <returns></returns>
        private static List<SheJiDianPic> shejidianlistCompare(List<SheJiDianPic> newlist, List<SheJiDianPic> oldlist)
        {
            List<SheJiDianPic> differentList = new List<SheJiDianPic>();
            int i = 0;
            foreach (SheJiDianPic nl in newlist)
            {
                i = 0;
                foreach (SheJiDianPic ol in oldlist)
                {
                    if (nl.itemCode != ol.itemCode || nl.itemValue != ol.itemValue || nl.itemNameCn != ol.itemNameCn || nl.picn != ol.picn || nl.picurl != ol.picurl)
                    {
                        i++;
                    }
                    if (i == oldlist.Count())
                    {
                        differentList.Add(nl);
                    }
                }
            }
            return differentList;
        }
    }
}
