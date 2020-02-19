using DiaoPaiDaYin;
using mendian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.service
{
    /// <summary>
    /// 图片服务
    /// </summary>
    public class PictureService
    {
        /// <summary>
        /// 下载没有的款式图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadDifferentPic(List<StylePic> difflist)
        {
            foreach (StylePic sp in difflist)
            {
                if (sp.stylePicN != "")
                {
                    try
                    {
                        DownloadPicture(sp.stylePicURL, @"pic\" + sp.stylePicN, -1);
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 下载没有的设计点图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadSheJiDianPic(List<SheJiDianPic> difflist)
        {
            foreach (SheJiDianPic sjdp in difflist)
            {
                if (sjdp.picn != "")
                {
                    try
                    {
                        DownloadPicture(sjdp.picurl, @"pic\" + sjdp.picn, -1);
                        //DownloadPic(sjdp.picurl, @"pic\", sjdp.picn);
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 下载没有的面料图片
        /// </summary>
        /// <param name="difflist"></param>
        public static void DownloadMianliaoPic(List<MianLiaoPic> difflist)
        {
            foreach (MianLiaoPic sp in difflist)
            {
                if (sp.picn != "")
                {
                    try
                    {
                        DownloadPicture(sp.picurl, @"pic\" + sp.picn, -1);
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="picUrl">图片Http地址</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns></returns>
        public static bool DownloadPicture(string picUrl, string savePath, int timeOut)
        {
            //savePath = @"pic\" + savePath + ".jpg";
            bool value = false;
            WebResponse response = null;
            Stream stream = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(picUrl);
                if (timeOut != -1) request.Timeout = timeOut;
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/"))
                    value = SaveBinaryFile(response, savePath);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            return value;
        }

        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (File.Exists(savePath)) File.Delete(savePath);
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }
            return value;
        }

        /// <summary>
        /// 根据名字取图片
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Image GetImage(String value)
        {
            String sql = "SELECT \n" +
                " s1.itemValue , \n" +
                " s1.itemNameCn , \n" +
                " s1.itemCode , \n" +
                " S2.UPLOAD_FILE AS picn, \n" +
                " s2.picurl  \n" +
                " FROM \n" +
                " ( \n" +
                " SELECT \n" +
                " 	ap.ITEM_VALUE itemValue, \n" +
                " 	ap.DESIGN_ID id, \n" +
                " 	CONCAT( ap.ITEM_VALUE, \":\", ap.ITEM_NAME_CN ) itemNameCn, \n" +
                " 	ap.ITEM_CD itemCode, \n" +
                " 	adp.ITEM_CD itemParentCode  \n" +
                " FROM \n" +
                " 	a_designoption_p ap \n" +
                " 	LEFT JOIN a_designoption_p adp ON adp.ITEM_VALUE = ap.ITEM_CD \n" +
                " 	LEFT JOIN a_ognization_desgin_r adr ON ap.DESIGN_ID = adr.DESGIN_ID  \n" +
                " WHERE \n" +
                " 	( ap.ITEM_CATEGORY_CD = \"\" OR ap.ITEM_CATEGORY_CD IS NULL )  \n" +
                " 	AND ap.STYLE_CATEGORY_CD = 'STYLE_CATEGORY-SHIRT'  \n" +
                " 	-- AND ap.ITEM_CD = '' -- AND ap.ITEM_CD IN ( SELECT ap.ITEM_VALUE itemValue FROM a_designoption_p ap WHERE ap.ITEM_CATEGORY_CD ='ITEM_TYPE_CD-10' ) \n" +
                " 	AND ap.ITEM_VALUE = '" + value + "'\n" +
                " 	AND adr.OGNIZATION_ID = 95  \n" +
                " 	AND ap.ITEM_VALUE IN ( \n" +
                " 	SELECT \n" +
                " 		ap.ITEM_VALUE itemValue  \n" +
                " 	FROM \n" +
                " 		a_designoption_p ap  \n" +
                " 	WHERE \n" +
                " 		ap.DESIGN_ID IN ( SELECT ar.DESGIN_ID FROM a_shop_desgin_r ar WHERE ar.SHOP_ID = 18 )  \n" +
                " 	)  \n" +
                " ORDER BY \n" +
                " 	ap.ITEM_CD, \n" +
                " 	ap.ITEM_SORT ASC  \n" +
                " ) AS s1 \n" +
                " LEFT JOIN ( \n" +
                " SELECT \n" +
                " 	a.ITEM_CD, \n" +
                " 	a.ITEM_VALUE, \n" +
                " 	a.ITEM_NAME_CN, \n" +
                " 	CONCAT( 'https://sshirtmtmbucket.oss-cn-zhangjiakou.aliyuncs.com/sshirtmtm/', w.UPLOAD_FILE ) AS picurl, \n" +
                " 	w.*  \n" +
                " FROM \n" +
                " 	a_designoption_p a \n" +
                " 	LEFT JOIN w_upload_file_p w ON a.FILE_ID = w.FILE_ID  \n" +
                " WHERE \n" +
                " 	a.FILE_ID IS NOT NULL  \n" +
                " ) AS s2 ON s1.itemCode = s2.ITEM_CD  \n" +
                " AND s1.itemValue = s2.ITEM_VALUE";
            DataRow dr = SQLmtm.GetDataRow(sql);

            String strRtn;
            try
            {
                strRtn = dr["picn"].ToString();
            }
            catch
            {
                strRtn = "SSHIRT.jpg";
            }
            return Image.FromFile(@"pic\" + strRtn);
        }
    }
}
