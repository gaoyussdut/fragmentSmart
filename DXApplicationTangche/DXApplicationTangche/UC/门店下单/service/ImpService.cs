using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DiaoPaiDaYin;
using DXApplicationTangche;
using DXApplicationTangche.UC.门店下单.form;
using DXApplicationTangche.UC.门店下单.DTO;
using DXApplicationTangche.UC.款式异常;
using DXApplicationTangche.DTO;
using DevExpress.XtraGrid.Demos.util;
using DXApplicationTangche.UC.款式异常.DTO;
using DXApplicationTangche.service;

namespace mendian
{
    class ImpService
    {
        #region 无引用
        /// <summary>
        /// 字符串按指定长度换行
        /// </summary>
        /// <param name="conten">字符串</param>
        /// <param name="start">指定长度</param>
        /// <param name="sSymbol">换行符</param>
        /// <returns>按指定长度换行后的字符串</returns>
        public static String SqritBySymbol(string conten, int start, string sSymbol)
        {
            string str = "";
            char[] param = conten.ToCharArray();
            if (param.Length > 0)
            {
                if (param.Length > start)
                {
                    int j = 1;
                    for (int i = 0; i < param.Length; i++)
                    {
                        str += param[i];
                        if (i == (start * j))
                        {
                            j++;
                            str = str + sSymbol;
                        }
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 保存尺寸a_customer_fit_value_r,s_style_fit_r插入数据
        /// </summary>
        /// <param name="sTYLE_FIT_ID"></param>
        /// <param name="customername"></param>
        /// <param name="fitv"></param>
        /// <param name="ftvl"></param>
        /// <param name="inftvl"></param>
        /// <param name="outftvl"></param>
        public static void insertFit_R(int sTYLE_FIT_ID, string customername, Fit_ValueDTo fitv, String ftvl, String inftvl, String outftvl)
        {
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE"
                                                                                    ,"IN_VALUE","OUT_VALUE","STATUS","DELETE_FLAG","CUSTOMER_COUNT_ID"},
new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString() , customername ,
                "SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,",
                "CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19,",
                ftvl,"CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19,",
                inftvl,outftvl,"0","0",CreateCustomer.customer_countid.ToString()});
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Frm定制下单修改尺寸.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", "SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_CIRCU001,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_LENGT002,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003,SHIRT_POSTU003" ,
                   "CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19",
                   ftvl,"CIRCU_ITEM_01,CIRCU_ITEM_02,CIRCU_ITEM_03,CIRCU_ITEM_04,CIRCU_ITEM_05,CIRCU_ITEM_06,CIRCU_ITEM_07,LENGT_ITEM_08,CIRCU_ITEM_08,CIRCU_ITEM_18,CIRCU_ITEM_17,LENGT_ITEM_01,LENGT_ITEM_02,POSTU_ITEM_09,POSTU_ITEM_07,LENGT_ITEM_05,LENGT_ITEM_06,POSTU_ITEM_01,POSTU_ITEM_02,CIRCU_ITEM_21,CIRCU_ITEM_19",
                   "0","1","46",inftvl,outftvl});

        }
        public static DataRow GetDataFromStyleid(String id)
        {
            String sql = "SELECT ";
            sql = sql + "sp.SYS_STYLE_ID, ";
            sql = sql + "sp.STYLE_NAME_CN, ";
            sql = sql + "imp.MATERIAL_CODE, ";
            sql = sql + "imp.MATERIAL_COMPOSITION, ";
            sql = sql + "sp.STYLE_SHOP_TOTAL_PRICE, ";
            sql = sql + "sp.STYLE_FIT_CD, ";
            sql = sql + "sp.STYLE_CATEGORY_CD, ";
            sql = sql + "sp.STYLE_SIZE_GROUP_CD ";
            sql = sql + "FROM ";
            sql = sql + "s_style_p AS sp ";
            sql = sql + "LEFT JOIN i_material_p imp ON sp.SYTLE_FABRIC_ID = imp.MATERIAL_ID ";
            sql = sql + "WHERE ";
            sql = sql + "sp.SYS_STYLE_ID = '" + id + "';";
            return SQLmtm.GetDataRow(sql);
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <param name="FileName"></param>
        public static void DownloadPic(String url, String path, String FileName)
        {
            //string path = "http://www.quanjing.com/imgbuy/QJ9107100567.png";//下载图片的地址
            //string newPath = string.Format(@"D:\UPLOAD\");//目标地址
            //string ImsFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png"; //目标文件名
            try
            {
                System.Net.WebRequest imgRequest = System.Net.WebRequest.Create(url);
                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)imgRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                }
                if (res.StatusCode.ToString() == "OK")
                {
                    System.Drawing.Image dwonImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream());
                    if (!System.IO.Directory.Exists(path))//目标地址不存在自动创建
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    dwonImage.Save(path + FileName);
                    dwonImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
        #endregion

        #region 嵌入窗体
        /// <summary>
        /// 标准款尺寸保存
        /// </summary>
        /// <param name="dt"></param>
        public static void StandardModelsSizeSive(DataTable dt)
        {
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (DataRow dr in dt.Rows)
            {
                fitv.icadd(dr["ITEM_CD"].ToString());
                fitv.ivadd(dr["ITEM_VALUE"].ToString());
                fitv.fvadd(dr["ITEM_FIT_VALUE"].ToString());
                fitv.fmvadd(dr["ITEM_VALUE"].ToString());
                fitv.invadd("0");
                fitv.outvadd("0");
            }
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { CreateCustomer.cUSTOMER_ID.ToString(), CreateCustomer.customer_name, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Frm定制下单修改尺寸.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }
        /// <summary>
        /// 清空个别静态变量
        /// </summary>
        public static void ClearStaticVariable()
        {
            Frm面料选择.mianliao = "";
            Frm面料选择.mianliaocd = "";
            Frm面料选择.mianliaoid = "";
        }
        /// <summary>
        /// 标准款设计点保存
        /// </summary>
        public static void StandardModelsDesignSive()
        {
            try
            {
                String sql = "SELECT * FROM s_style_option_r WHERE SYS_STYLE_ID='" + Frm定制下单修改尺寸.kuanshiid + "'";
                DataTable dt = SQLmtm.GetDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SQLmtm.DoInsert(
                        "s_style_option_r"
                        , new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" }
                        , new string[] { Frm定制下单修改尺寸.styleid.ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["OPTION_VALUE"].ToString(), "1", "0" }
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息: " + ex.Message);
                return;
            }

        }
        /// <summary>
        /// 标准款s_style_p写入数据
        /// </summary>
        /// <param name="uc"></param>
        public static void insertS_Style_P(UC款式卡片 uc)
        {
            SQLmtm.DoInsert("s_style_p", new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" },
    new string[] { Frm定制下单修改尺寸.styleid.ToString(), "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", uc.sTYLE_CATEGORY_CD, Frm面料选择.mianliaoid, uc.sTYLE_SIZE_GROUP_CD, Frm定制下单修改尺寸.sTYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", uc.kuanshimingcheng, "", CreateCustomer.customer_countid.ToString(), uc.sTYLE_FIT_CD, uc.kuanshiid, uc.sTYLE_DRESS_CATEGORY, uc.sTYLE_DESIGN_TYPE, uc.sTYLE_PUBLISH_CATEGORY_CD, uc.sYTLE_YEAR, uc.sYTLE_SEASON });
        }

        public static void LoadSheJiDian(Frm门店下单选款式 frm, String styleid)
        {
            frm.panel3.Controls.Clear();
            DataTable dt = SQLmtm.GetDataTable("select * from a_kuanshi_p where STYLEID =" + styleid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请联系管理员完善相关信息");
                return;
            }
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(frm.panel3.Width, frm.panel3.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ITEM_VALUE"].ToString() != "mianliaoid")
                {
                    UC设计点选择 chooseCard = new UC设计点选择(dr["id"].ToString(), dr["ITEM_NAME_CN"].ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["DEFAULT_NAME_CN"].ToString(), dr["DEFAULT_CD"].ToString(), dr["DEFAULT_VALUE"].ToString(), "");
                    ArrayUC(chooseCard, i);
                    frm.panel3.Controls.Add(chooseCard);
                    i++;
                }
                else
                {
                    Frm面料选择.mianliaocd = dr["DEFAULT_CD"].ToString();
                    Frm面料选择.mianliaoid = dr["DEFAULT_VALUE"].ToString();
                    Frm面料选择.mianliao = frm.mianliaoname.Text = dr["DEFAULT_NAME_CN"].ToString();
                }
            }
        }

        public static void LoadChiCunCard(Frm门店下单选款式 frm)
        {
            String sql = "SELECT\n" +
                " sp.FIT_ITEM_VALUE,\n" +
                " property.PROPERTY_CD propertyCd,\n" +
                "/*量体属性CD*/\n" +
                "property.PROPERTY_VALUE propertyValue,\n" +
                "/*量体VALUE*/\n" +
                " sp.ITEM_IN_FROM propertyInFrom,\n" +
                "/*量体属性值可增加范围从*/\n" +
                " sp.ITEM_IN_TO propertyInTo,\n" +
                "/*量体属性值可增加范围到*/\n" +
                " sp.ITEM_OUT_FROM propertyOutFrom,\n" +
                "/*量体属性值可缩减范围从*/\n" +
                " sp.ITEM_OUT_TO propertyOutTo,\n" +
                "/*量体属性值可缩减范围到*/\n" +
                " property.PROPERTY_NAME_CN propertyNameCn,\n" +
                "/*量体属性中文名称*/\n" +
                " property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
                "/*0-非净量体，1-净量体*/\n" +
                " property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
                " sp.ITEM_SORT,\n" +
                " sp.ITEM_CD,\n" +
                " sp.ITEM_VALUE\n" +
                "FROM\n" +
                " a_fit_property_p property\n" +
                " LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
                " AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
                "WHERE\n" +
                " property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + frm.model.Dto定制下单.STYLE_CATEGORY_CD + "' ) \n" +
                " AND property.DEL_FLG = 0 \n" +
                "  AND sp.FIT_CD = '" + frm.model.Dto定制下单.STYLE_FIT_CD + "'  /*款式*/\n" +
                " AND sp.SIZEGROUP_CD = '" + frm.model.Dto定制下单.STYLE_SIZE_GROUP_CD + "' \n" +
                "-- AND sp.SIZE_CD = '" + frm.model.Dto定制下单.STYLE_SIZE_CD + "'   /*尺码*/\n" +
                " AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
                " AND sp.ENABLE_FLAG = 1 \n" +
                " AND property.FIT_FLAG = 1 \n" +
                " AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
                "GROUP BY property.PROPERTY_VALUE  \n" +
                "ORDER BY\n" +
                " -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
                " sp.ITEM_SORT ASC";
            DataTable dt = SQLmtm.GetDataTable(sql);
            //change.panel3.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(frm.panel4.Width, frm.panel4.Height, 0);
            UC尺寸头 hhh = new UC尺寸头();
            ImpService.generateUserControl(hhh, i);
            frm.panel4.Controls.Clear();
            frm.panel4.Controls.Add(hhh);
            i++;
            foreach (DataRow dr in dt.Rows)
            {
                UC尺寸卡片 ccc = new UC尺寸卡片(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), frm);
                ImpService.generateUserControl(ccc, i);
                frm.panel4.Controls.Add(ccc);//将控件加入panel                
                i++;
            }
            //DataTable ddt=SQLmtm.GetDataTable("")
            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
                "	*,\n" +
                "	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
                "	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
                "FROM\n" +
                "	a_customer_fit_r ar\n" +
                "	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
                "WHERE\n" +
                "	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["pv1"].ToString() == c.iTEM_VALUE || dr["pv2"].ToString() == c.iTEM_VALUE)
                        {
                            c.kehu.Text = dr["FIT_VALUE"].ToString();
                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 动态设计点保存
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dto"></param>
        public static void DynamicSaveSize(Frm门店下单选款式 frm, Dto定制下单 dto)
        {
            ImpService.TurnChiCunZero(frm);
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    fitv.icadd(c.iTEM_CD);
                    fitv.ivadd(c.iTEM_VALUE);
                    fitv.fvadd(c.chengyi.Text);
                    fitv.fmvadd(c.iTEM_VALUE);
                    fitv.invadd(c.jia.Text);
                    fitv.outvadd(c.jian.Text);
                }
            }
            dto.build尺寸(
                fitv.iTEM_CD
                , fitv.iTEM_VALUE
                , fitv.fitValue
                , fitv.fM_VALUE
                , fitv.iN_VALUE
                , fitv.oUT_VALUE
                , "0"
                , "0"
                , CreateCustomer.customer_countid.ToString()
                , "AUDIT_PHASE_CD-PHASE_CD_10"
                , "1"
                , "46"
                );
            //        SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            //        SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
            //new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }
        /// <summary>
        /// 尺寸空设为0
        /// </summary>
        /// <param name="frm"></param>
        public static void TurnChiCunZero(Frm门店下单选款式 frm)
        {
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    if (c.biaozhun.Text == "")
                    {
                        c.biaozhun.Text = "0";
                    }
                    if (c.jia.Text == "")
                    {
                        c.jia.Text = "0";
                    }
                    if (c.jian.Text == "")
                    {
                        c.jian.Text = "0";
                    }
                }

            }
        }
        /// <summary>
        /// 动态保存设计点
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dto"></param>
        public static void DynamicSaveDesign(Frm门店下单选款式 frm, Dto定制下单 dto)
        {
            UC设计点选择 c = new UC设计点选择();
            foreach (Control card in frm.panel3.Controls)
            {
                if (card is UC设计点选择)
                {
                    c = (UC设计点选择)card;
                    dto.build设计点(c.PitemCd, c.PitemValue, c.itemValue, "1", "0", c.itemName, c.PitemName, c.pic);
                    //                    SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" },
                    //new string[] { Change.styleid.ToString(), c.PitemCd, c.PitemValue, c.itemValue, "1", "0" });
                }
            }
        }
        /// <summary>
        /// 刷新尺寸
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="dt"></param>
        public static void RefreshChiCun(Frm门店下单选款式 frm, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (Control card in frm.panel4.Controls)
                {
                    if (card is UC尺寸卡片)
                    {
                        UC尺寸卡片 c = (UC尺寸卡片)card;
                        if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
                        {
                            c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
                            break;
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 计算成衣尺寸
        /// </summary>
        /// <param name="frm"></param>
        public static void CountChiCun(Frm门店下单选款式 frm)
        {
            ImpService.TurnChiCunZero(frm);
            foreach (Control card in frm.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
                }
            }
        }
        /// <summary>
        /// s_style_p插入数据
        /// </summary>
        /// <param name="change"></param>
        /// <param name="uc"></param>
        public static void insertS_Style_P(Frm定制下单修改尺寸 change, UC款式卡片 uc)
        {
            Frm定制下单修改尺寸.sTYLE_SIZE_CD = SizeService.SizeCD(change.chicun01.Text.Trim(), Frm定制下单修改尺寸.stylesizedt);
            //DataRow drstyle = SQLmtm.GetDataRow("SELECT MAX(SYS_STYLE_ID) SYS_STYLE_ID FROM `s_style_p`");
            //Change.styleid = Convert.ToInt32(drstyle["SYS_STYLE_ID"]);
            //Change.styleid++;
            SQLmtm.DoInsert("s_style_p", new string[] { "SYS_STYLE_ID", "SHOP_ID", "STYLE_CD", "STYLE_KBN", "STYLE_CATEGORY_CD", "SYTLE_FABRIC_ID", "STYLE_SIZE_GROUP_CD", "STYLE_SIZE_CD", "STYLE_MAKE_TYPE", "ENABLE_FLAG", "DELETE_FLAG", "VERSION", "STYLE_NAME_CN", "REMARKS", "CUSTOMER_COUNT_ID", "STYLE_FIT_CD", "REF_STYLE_ID", "STYLE_DRESS_CATEGORY", "STYLE_DESIGN_TYPE", "STYLE_PUBLISH_CATEGORY_CD", "SYTLE_YEAR", "SYTLE_SEASON" },
    new string[] { Frm定制下单修改尺寸.styleid.ToString(), "18", "", "STYLE_SOURCE-STYLE_SOURCE_50", uc.sTYLE_CATEGORY_CD, Frm面料选择.mianliaoid, uc.sTYLE_SIZE_GROUP_CD, Frm定制下单修改尺寸.sTYLE_SIZE_CD, "4SMA-4M", "1", "0", "1", uc.kuanshimingcheng, "", CreateCustomer.customer_countid.ToString(), uc.sTYLE_FIT_CD, uc.kuanshiid, uc.sTYLE_DRESS_CATEGORY, uc.sTYLE_DESIGN_TYPE, uc.sTYLE_PUBLISH_CATEGORY_CD, uc.sYTLE_YEAR, uc.sYTLE_SEASON });
        }

        private static PanelLocition panelLocition;
        private static int height = 0;
        private static int width = 0;
        /// <summary>
        /// 动态加载尺寸控件
        /// </summary>
        /// <param name="change"></param>
        /// <param name="sc"></param>
        public static void LoadChiCunCard(Frm定制下单修改尺寸 change, UC款式卡片 sc)
        {
            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
" sp.FIT_ITEM_VALUE,\n" +
" property.PROPERTY_CD propertyCd,\n" +
"/*量体属性CD*/\n" +
"property.PROPERTY_VALUE propertyValue,\n" +
"/*量体VALUE*/\n" +
" sp.ITEM_IN_FROM propertyInFrom,\n" +
"/*量体属性值可增加范围从*/\n" +
" sp.ITEM_IN_TO propertyInTo,\n" +
"/*量体属性值可增加范围到*/\n" +
" sp.ITEM_OUT_FROM propertyOutFrom,\n" +
"/*量体属性值可缩减范围从*/\n" +
" sp.ITEM_OUT_TO propertyOutTo,\n" +
"/*量体属性值可缩减范围到*/\n" +
" property.PROPERTY_NAME_CN propertyNameCn,\n" +
"/*量体属性中文名称*/\n" +
" property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
"/*0-非净量体，1-净量体*/\n" +
" property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
" sp.ITEM_SORT,\n" +
" sp.ITEM_CD,\n" +
" sp.ITEM_VALUE\n" +
"FROM\n" +
" a_fit_property_p property\n" +
" LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
" AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
"WHERE\n" +
" property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + sc.sTYLE_CATEGORY_CD + "' ) \n" +
" AND property.DEL_FLG = 0 \n" +
"  AND sp.FIT_CD = '" + sc.sTYLE_FIT_CD + "'  /*款式*/\n" +
" AND sp.SIZEGROUP_CD = '" + sc.sTYLE_SIZE_GROUP_CD + "' \n" +
"-- AND sp.SIZE_CD = '" + sc.sTYLE_SIZE_CD + "'   /*尺码*/\n" +
" AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
" AND sp.ENABLE_FLAG = 1 \n" +
" AND property.FIT_FLAG = 1 \n" +
" AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
"GROUP BY property.PROPERTY_VALUE  \n" +
"ORDER BY\n" +
" -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
" sp.ITEM_SORT ASC");
            //change.panel3.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(change.panel4.Width, change.panel4.Height, dt.Rows.Count);
            UC尺寸头 hhh = new UC尺寸头();
            ImpService.generateUserControl(hhh, i);
            change.panel4.Controls.Add(hhh);
            i++;
            foreach (DataRow dr in dt.Rows)
            {
                UC尺寸卡片 ccc = new UC尺寸卡片(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), change);
                ImpService.generateUserControl(ccc, i);
                change.panel4.Controls.Add(ccc);//将控件加入panel                
                i++;
            }
            //DataTable ddt=SQLmtm.GetDataTable("")
            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
"	*,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
"	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
"FROM\n" +
"	a_customer_fit_r ar\n" +
"	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
"WHERE\n" +
"	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr["pv1"].ToString() == c.iTEM_VALUE || dr["pv2"].ToString() == c.iTEM_VALUE)
                        {
                            c.kehu.Text = dr["FIT_VALUE"].ToString();
                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改款式尺寸动态加载
        /// </summary>
        /// <param name="form"></param>
        //        public static void ReviseLoadChiCunCard(ReviseStyle form)
        //        {
        //            DataTable dt = SQLmtm.GetDataTable("SELECT\n" +
        //" sp.FIT_ITEM_VALUE,\n" +
        //" property.PROPERTY_CD propertyCd,\n" +
        //"/*量体属性CD*/\n" +
        //"property.PROPERTY_VALUE propertyValue,\n" +
        //"/*量体VALUE*/\n" +
        //" sp.ITEM_IN_FROM propertyInFrom,\n" +
        //"/*量体属性值可增加范围从*/\n" +
        //" sp.ITEM_IN_TO propertyInTo,\n" +
        //"/*量体属性值可增加范围到*/\n" +
        //" sp.ITEM_OUT_FROM propertyOutFrom,\n" +
        //"/*量体属性值可缩减范围从*/\n" +
        //" sp.ITEM_OUT_TO propertyOutTo,\n" +
        //"/*量体属性值可缩减范围到*/\n" +
        //" property.PROPERTY_NAME_CN propertyNameCn,\n" +
        //"/*量体属性中文名称*/\n" +
        //" property.FIT_USE_TYPE_CD fitUseTypeCd,\n" +
        //"/*0-非净量体，1-净量体*/\n" +
        //" property.PROPERTY_UNIT_CD propertyUnitCd ,\n" +
        //" sp.ITEM_SORT,\n" +
        //" sp.ITEM_CD,\n" +
        //" sp.ITEM_VALUE\n" +
        //"FROM\n" +
        //" a_fit_property_p property\n" +
        //" LEFT JOIN a_size_fit_p sp ON property.PROPERTY_CD = sp.ITEM_CD \n" +
        //" AND property.PROPERTY_VALUE = sp.ITEM_VALUE \n" +
        //"WHERE\n" +
        //" property.PROPERTY_CD IN ( SELECT PROPERTY_VALUE FROM a_fit_property_p WHERE style_category_cd = '" + ReviseStyle.sTYLE_CATEGORY_CD + "' ) \n" +
        //" AND property.DEL_FLG = 0 \n" +
        //"  AND sp.FIT_CD = '" + ReviseStyle.sTYLE_FIT_CD + "'  /*款式*/\n" +
        //" AND sp.SIZEGROUP_CD = '" + ReviseStyle.sTYLE_SIZE_GROUP_CD + "' \n" +
        //"-- AND sp.SIZE_CD = '" + ReviseStyle.sTYLE_SIZE_CD + "'   /*尺码*/\n" +
        //" AND property.FIT_USE_TYPE_CD = \"FIT_USE_TYPE-FIT_TYPE_20\" \n" +
        //" AND sp.ENABLE_FLAG = 1 \n" +
        //" AND property.FIT_FLAG = 1 \n" +
        //" AND sp.ITEM_VALUE != \"CIRCU_ITEM_09\" \n" +
        //"GROUP BY property.PROPERTY_VALUE  \n" +
        //"ORDER BY\n" +
        //" -- property.PROPERTY_CD,sp.ITEM_SORT ASC\n" +
        //" sp.ITEM_SORT ASC");
        //            //form.panel3.Controls.Clear();
        //            height = 0;
        //            width = 0;
        //            int i = 0;
        //            panelLocition = new PanelLocition(form.panel4.Width, form.panel4.Height, dt.Rows.Count);
        //            ChiCunHead hhh = new ChiCunHead();
        //            ImpService.generateUserControl(hhh, i);
        //            form.panel4.Controls.Add(hhh);
        //            i++;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                ChiCunCard ccc = new ChiCunCard(dr["ITEM_CD"].ToString().Trim(), dr["ITEM_VALUE"].ToString(), dr["propertyNameCn"].ToString(), dr["FIT_ITEM_VALUE"].ToString(), form);
        //                ImpService.generateUserControl(ccc, i);
        //                form.panel4.Controls.Add(ccc);//将控件加入panel 

        //                i++;
        //            }
        //            DataTable dtt = SQLmtm.GetDataTable("SELECT\n" +
        //"	*,\n" +
        //"	SUBSTRING_INDEX( ap.REMARKS, ',', 1 )AS pv1,\n" +
        //"	SUBSTRING_INDEX( ap.REMARKS, ',', -1 )AS pv2\n" +
        //"FROM\n" +
        //"	a_customer_fit_r ar\n" +
        //"	LEFT JOIN a_fit_property_p ap ON ar.ITEM_VALUE = ap.PROPERTY_VALUE \n" +
        //"WHERE\n" +
        //"	FIT_COUNT_ID = '" + CreateCustomer.customer_countid + "'");
        //            foreach (Control card in form.panel4.Controls)
        //            {
        //                if (card is ChiCunCard)
        //                {
        //                    ChiCunCard c = (ChiCunCard)card;
        //                    foreach (DataRow dr in dtt.Rows)
        //                    {
        //                        if (c.fIT_ITEM_VALUE == dr["ITEM_VALUE"].ToString())
        //                        //if (dr["pv1"].ToString() == card.iTEM_VALUE || dr["pv2"].ToString() == card.iTEM_VALUE)
        //                        {
        //                            c.kehu.Text = dr["FIT_VALUE"].ToString();
        //                            c.tiaozheng.Text = dr["FIT_VALUE_CALCULATE"].ToString();
        //                        }
        //                    }
        //                }
        //            }
        //        }

        public static void generateUserControl(System.Windows.Forms.UserControl userControl, int i)
        {
            userControl.Name = "chicuncard" + i.ToString();
            //userControl.Size = new Size(200, 30);
            //if (i != 0)
            //{
            //    if (i % 5 == 0)
            //    {
            //        width = 0;
            //        height = height + 240;
            //    }
            //}
            userControl.Location = new System.Drawing.Point(panelLocition.UcLeft + width, panelLocition.UcHeight + height * 33);//控件位置
            height++;
        }
        /// <summary>
        /// 动态保存尺寸
        /// </summary>
        /// <param name="change"></param>
        public static void DynamicSaveSize(Frm定制下单修改尺寸 change, int sTYLE_FIT_ID, String customername)
        {
            ImpService.TurnChiCunZero(change);
            Fit_ValueDTo fitv = new Fit_ValueDTo();
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    fitv.icadd(c.iTEM_CD);
                    fitv.ivadd(c.iTEM_VALUE);
                    fitv.fvadd(c.chengyi.Text);
                    fitv.fmvadd(c.iTEM_VALUE);
                    fitv.invadd(c.jia.Text);
                    fitv.outvadd(c.jian.Text);
                }
            }
            SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
            SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
    new string[] { Frm定制下单修改尺寸.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        }

        //    public static void ReviseDynamicSaveSize(ReviseStyle form, int sTYLE_FIT_ID, String customername)
        //    {
        //        ImpService.TurnChiCunZero(form);
        //        Fit_ValueDTo fitv = new Fit_ValueDTo();
        //        foreach (Control card in form.panel4.Controls)
        //        {
        //            if (card is ChiCunCard)
        //            {
        //                ChiCunCard c = (ChiCunCard)card;
        //                fitv.icadd(c.iTEM_CD);
        //                fitv.ivadd(c.iTEM_VALUE);
        //                //fitv.fvadd(c.chengyi.Text);
        //                fitv.fmvadd(c.iTEM_VALUE);
        //                //fitv.invadd(c.jia.Text);
        //                //fitv.outvadd(c.jian.Text);
        //            }
        //        }
        //        SQLmtm.DoInsert("a_customer_fit_value_r", new string[] { "STYLE_FIT_ID", "CUSTOMER_ID", "CUSTOMER_NAME", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE", "STATUS", "DELETE_FLAG", "CUSTOMER_COUNT_ID" }, new string[] { sTYLE_FIT_ID.ToString(), CreateCustomer.cUSTOMER_ID.ToString(), customername, fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE, "0", "0", CreateCustomer.customer_countid.ToString() });
        //        SQLmtm.DoInsert("s_style_fit_r", new string[] { "STYLE_ID", "PHASE_CD", "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "DELETE_FLAG", "VERSION", "CREATE_USER", "IN_VALUE", "OUT_VALUE" },
        //new string[] { Change.styleid.ToString(), "AUDIT_PHASE_CD-PHASE_CD_10", fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, "0", "1", "46", fitv.iN_VALUE, fitv.oUT_VALUE });
        //    }

        /// <summary>
        /// 刷新尺寸
        /// </summary>
        /// <param name="change"></param>
        /// <param name="dt"></param>
        public static void RefreshChiCun(Frm定制下单修改尺寸 change, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (Control card in change.panel4.Controls)
                {
                    if (card is UC尺寸卡片)
                    {
                        UC尺寸卡片 c = (UC尺寸卡片)card;
                        if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
                        {
                            c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
                            break;
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 修改款式刷新尺寸
        /// </summary>
        /// <param name="form"></param>
        /// <param name="dt"></param>
        //public static void RefreshChiCun(ReviseStyle form, DataTable dt)
        //{
        //foreach (DataRow dr in dt.Rows)
        //{
        //    foreach (Control card in form.panel4.Controls)
        //    {
        //        if (card is ChiCunCard)
        //        {
        //            ChiCunCard c = (ChiCunCard)card;
        //            if (dr["ITEM_VALUE"].ToString() == c.iTEM_VALUE)
        //            {
        //                c.biaozhun.Text = dr["ITEM_FIT_VALUE"].ToString();
        //                break;
        //            }
        //        }
        //    }
        //}
        //}
        /// <summary>
        /// 将空尺寸设为0
        /// </summary>
        /// <param name="change"></param>
        public static void TurnChiCunZero(Frm定制下单修改尺寸 change)
        {
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    if (c.biaozhun.Text == "")
                    {
                        c.biaozhun.Text = "0";
                    }
                    if (c.jia.Text == "")
                    {
                        c.jia.Text = "0";
                    }
                    if (c.jian.Text == "")
                    {
                        c.jian.Text = "0";
                    }
                }
            }
        }
        /// <summary>
        /// 修改尺寸将空尺寸设为0
        /// </summary>
        /// <param name="form"></param>
        //public static void TurnChiCunZero(ReviseStyle form)
        //{
        //foreach (Control card in form.panel4.Controls)
        //{
        //    if (card is ChiCunCard)
        //    {
        //        ChiCunCard c = (ChiCunCard)card;
        //        if (c.biaozhun.Text == "")
        //        {
        //            c.biaozhun.Text = "0";
        //        }
        //        if (c.jia.Text == "")
        //        {
        //            c.jia.Text = "0";
        //        }
        //        if (c.jian.Text == "")
        //        {
        //            c.jian.Text = "0";
        //        }
        //    }
        //}
        //}
        /// <summary>
        /// 计算成衣尺寸
        /// </summary>
        /// <param name="change"></param>
        public static void CountChiCun(Frm定制下单修改尺寸 change)
        {
            ImpService.TurnChiCunZero(change);
            foreach (Control card in change.panel4.Controls)
            {
                if (card is UC尺寸卡片)
                {
                    UC尺寸卡片 c = (UC尺寸卡片)card;
                    c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
                }
            }
        }
        /// <summary>
        /// 修改款式计算成衣尺寸
        /// </summary>
        /// <param name="form"></param>
        //public static void CountChiCun(ReviseStyle form)
        //{
        //ImpService.TurnChiCunZero(form);
        //foreach (Control card in form.panel4.Controls)
        //{
        //    if (card is ChiCunCard)
        //    {
        //        ChiCunCard c = (ChiCunCard)card;
        //        c.chengyi.Text = (Convert.ToDouble(c.biaozhun.Text) + Convert.ToDouble(c.jia.Text) - Convert.ToDouble(c.jian.Text)).ToString();
        //    }
        //}
        //}
        /// <summary>
        /// 修改款式修改尺寸
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseChangeChiCun(ReviseStyle form, String sizecd)
        //{
        //    int i2 = SQLmtm.DoUpdate("s_style_p", new string[] { "STYLE_SIZE_CD" }, new string[] { sizecd }, new string[] { "SYS_STYLE_ID" }, new string[] { ReviseStyle.sYS_STYLE_ID });
        //    if (i2 != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //    ImpService.TurnChiCunZero(form);
        //    Fit_ValueDTo fitv = new Fit_ValueDTo();
        //    foreach (Control card in form.panel4.Controls)
        //    {
        //        if (card is ChiCunCard)
        //        {
        //            ChiCunCard c = (ChiCunCard)card;
        //            fitv.icadd(c.iTEM_CD);
        //            fitv.ivadd(c.iTEM_VALUE);
        //            fitv.fvadd(c.chengyi.Text);
        //            fitv.fmvadd(c.iTEM_VALUE);
        //            fitv.invadd(c.jia.Text);
        //            fitv.outvadd(c.jian.Text);
        //        }
        //    }
        //    int i = SQLmtm.DoUpdate("a_customer_fit_value_r", new string[] { "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE" }, new string[] { fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE }, new string[] { "CUSTOMER_COUNT_ID" }, new string[] { CreateCustomer.customer_countid.ToString() });
        //    if (i != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //    int i1 = SQLmtm.DoUpdate("s_style_fit_r", new string[] { "ITEM_CD", "ITEM_VALUE", "FIT_VALUE", "FM_VALUE", "IN_VALUE", "OUT_VALUE" }, new string[] { fitv.iTEM_CD, fitv.iTEM_VALUE, fitv.fitValue, fitv.fM_VALUE, fitv.iN_VALUE, fitv.oUT_VALUE }, new string[] { "STYLE_ID" }, new string[] { ReviseStyle.sYS_STYLE_ID });
        //    if (i1 != 1)
        //    {
        //        MessageBox.Show("更改尺寸失败");
        //        return;
        //    }
        //}
        /// <summary>
        /// 修改款式客户基本信息加载
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseLoudCustomer(ReviseStyle form)
        //{
        //    DataRow drr = SQLmtm.GetDataRow("SELECT * FROM o_order_p WHERE STYLE_ID='" + ReviseStyle.sYS_STYLE_ID + "'");
        //    form.beizhu01.Text = drr["REMARKS"].ToString();
        //    form.dangqiankehu.Text = drr["CUSTOM_NAME"].ToString();
        //    DataTable dt = SQLmtm.GetDataTable("SELECT * FROM (SELECT * FROM a_customer_fit_r) s1 RIGHT JOIN (SELECT * FROM a_customer_fit_count_r WHERE CUSTOMER_ID ='" + drr["CUSTOMER_ID"].ToString() + "' AND DEFAULT_FLAG ='1') s2 on s1.FIT_COUNT_ID=s2.ID");
        //    //if(dt.Rows[0]["CUSTOMER_FIT_ID"].ToString()!="")
        //    //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_ITEM_09")
        //        {
        //            form.kehushengao.Text = dr["FIT_VALUE"].ToString();
        //        }

        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_ITEM_10")
        //        {
        //            form.kehutizhong.Text = dr["FIT_VALUE"].ToString();
        //        }

        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_CODE_01")
        //        {
        //            switch (dr["FIT_VALUE"].ToString())
        //            {
        //                case "1":
        //                    form.kehujianxing.Text = "平肩";
        //                    break;
        //                case "2":
        //                    form.kehujianxing.Text = "溜肩";
        //                    break;
        //                case "3":
        //                    form.kehujianxing.Text = "正常";
        //                    break;
        //            }
        //        }


        //        if (dr["ITEM_VALUE"].ToString() == "FITMT_CODE_02")
        //        {
        //            switch (dr["FIT_VALUE"].ToString())
        //            {
        //                case "4":
        //                    form.kehuduxing.Text = "凹陷";
        //                    break;
        //                case "5":
        //                    form.kehuduxing.Text = "平坦";
        //                    break;
        //                case "6":
        //                    form.kehuduxing.Text = "微凸";
        //                    break;
        //                case "7":
        //                    form.kehuduxing.Text = "中凸";
        //                    break;
        //                case "8":
        //                    form.kehuduxing.Text = "重凸";
        //                    break;
        //            }
        //        }


        //    }
        //}
        /// <summary>
        /// 修改款式修改备注
        /// </summary>
        /// <param name="form"></param>
        //public static void ReviseSaveBeiZhu(ReviseStyle form)
        //{
        //    int i = SQLmtm.DoUpdate("o_order_p", new string[] { "REMARKS" }, new string[] { form.beizhu01.Text }, new string[] { "ORDER_ID" }, new string[] { ReviseStyle.oRDER_ID });
        //    if (i != 1)
        //    {
        //        MessageBox.Show("修改备注失败");
        //        return;
        //    }
        //}
        /// <summary>
        /// 动态加载设计点控件
        /// </summary>
        /// <param name="change"></param>
        public static void LoadSheJiDian(Frm定制下单修改尺寸 change, String styleid)
        {
            DataTable dt = SQLmtm.GetDataTable("select * from a_kuanshi_p where STYLEID =" + styleid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请联系管理员完善相关信息");
                return;
            }
            change.panel6.Controls.Clear();
            height = 0;
            width = 0;
            int i = 0;
            panelLocition = new PanelLocition(change.panel6.Width, change.panel6.Height, dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ITEM_VALUE"].ToString() != "mianliaoid")
                {
                    UC设计点选择 chooseCard = new UC设计点选择(dr["id"].ToString(), dr["ITEM_NAME_CN"].ToString(), dr["ITEM_CD"].ToString(), dr["ITEM_VALUE"].ToString(), dr["DEFAULT_NAME_CN"].ToString(), dr["DEFAULT_CD"].ToString(), dr["DEFAULT_VALUE"].ToString(), "");
                    ArrayUC(chooseCard, i);
                    change.panel6.Controls.Add(chooseCard);
                    i++;
                }
                else
                {
                    Frm面料选择.mianliaocd = dr["DEFAULT_CD"].ToString();
                    Frm面料选择.mianliaoid = dr["DEFAULT_VALUE"].ToString();
                    Frm面料选择.mianliao = change.mianliaoname.Text = dr["DEFAULT_NAME_CN"].ToString();
                }
            }
        }
        private static void ArrayUC(System.Windows.Forms.UserControl userControl, int i)
        {
            userControl.Name = "shejidiancard" + i.ToString();
            //userControl.Size = new Size(200, 30);
            if (i != 0)
            {
                if (i % 16 == 0)
                {
                    width = width + 600;
                    height = 0;
                }
            }
            userControl.Location = new System.Drawing.Point(panelLocition.UcLeft + width, panelLocition.UcHeight + height * 50);//控件位置
            height++;
        }


        /// <summary>
        /// 动态设计点保存
        /// </summary>
        /// <param name="change"></param>
        public static void DynamicSaveDesign(Frm定制下单修改尺寸 change)
        {
            UC设计点选择 c = new UC设计点选择();
            foreach (Control card in change.panel6.Controls)
            {
                if (card is UC设计点选择)
                {
                    c = (UC设计点选择)card;
                    SQLmtm.DoInsert("s_style_option_r", new string[] { "SYS_STYLE_ID", "ITEM_CD", "ITEM_VALUE", "OPTION_VALUE", "ENABLE_FLAG", "DELETE_FLAG" },
new string[] { Frm定制下单修改尺寸.styleid.ToString(), c.PitemCd, c.PitemValue, c.itemValue, "1", "0" });
                }
            }
        }
        #endregion
                                         
    }
}

