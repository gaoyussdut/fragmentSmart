using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.BLL
{
    public class BarCodePrintBLL
    {
        /// <summary>
        ///  定制订单生产信息打印管理
        /// </summary>
        public void orderPrintManager(string strPrintType, object printObject)
        {

            // 定制订单 - 订单信息
            if (strPrintType.Equals("5"))
            {
                orderPrint(printObject);
                //orderPrint2(printObject);
            }

            // 定制订单 - 扣
            if (strPrintType.Equals("2"))
            {
                sbuPrint(printObject);
            }

        }

        /// <summary>
        ///  裁剪信息打印
        /// </summary>
        public void clipOrderPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(5);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            //PrintLab.PTK_SetLabelHeight(345, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelHeight(260, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);

            DataTable tbl = (DataTable)printObject;

            String strQrId = "";
            String strOrderNo = "";
            String strProductOrder = "";
            String strCustomerOrderNo = "";
            String strBarCode = "";
            String strClipNumber = "";

            DataView dv = tbl.DefaultView;
            if (dv.Count > 0)
            {
                DataRowView dr = dv[0];
                strQrId = dr["QR_ID"].ToString();
                strOrderNo = dr["QR_OTHER0"].ToString();
                strProductOrder = dr["QR_OTHER9"].ToString();
                strCustomerOrderNo = dr["QR_NAME"].ToString();
                strBarCode = dr["QR_BAR_CODE"].ToString();
                strClipNumber = dr["QR_CLIP_NUMBER"].ToString();

                int iPageNumber = int.Parse(strClipNumber) / 2;
                int iRemain = int.Parse(strClipNumber) % 2;

                for (int i = 0; i < iPageNumber; i++)
                {
                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();

                    PrintLab.PTK_DrawTextTrueTypeW(210, 40, 35, 0, "Arial", 1, 300, false, false, false, "A1", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(225, 100, 0, "1", 2, 2, 30, 'B', strBarCode);

                    PrintLab.PTK_DrawTextTrueTypeW(650, 40, 35, 0, "Arial", 1, 300, false, false, false, "A2", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(665, 100, 0, "1", 2, 2, 30, 'B', strBarCode);

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);
                }

                if (iRemain > 0)
                {
                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();

                    PrintLab.PTK_DrawTextTrueTypeW(210, 40, 35, 0, "Arial", 1, 300, false, false, false, "A3", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(225, 100, 0, "1", 2, 2, 30, 'B', strBarCode);

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);
                }
            }

            PrintLab.ClosePort();//关闭打印机端口
        }

        /// <summary>
        ///  裁剪小贴打印
        /// </summary>
        public void clipSmallOrderPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(5);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(345, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            //PrintLab.PTK_SetLabelHeight(237, 21, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);

            DataTable tbl = (DataTable)printObject;

            String strQrId = "";
            String strOrderNo = "";
            String strProductOrder = "";
            String strCustomerOrderNo = "";
            String strBarCode = "";
            String strClipNumber = "";

            DataView dv = tbl.DefaultView;
            if (dv.Count > 0)
            {
                DataRowView dr = dv[0];
                strQrId = dr["QR_ID"].ToString();
                strOrderNo = dr["QR_OTHER0"].ToString();
                strProductOrder = dr["QR_OTHER9"].ToString();
                strCustomerOrderNo = dr["QR_NAME"].ToString();
                strBarCode = dr["QR_BAR_CODE"].ToString();
                strClipNumber = dr["QR_CLIP_NUMBER"].ToString();

                int iPageNumber = int.Parse(strClipNumber) / 3;
                int iRemain = int.Parse(strClipNumber) % 3;

                for (int i = 0; i < iPageNumber; i++)
                {
                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();

                    // 打印一行TrueTypeFont文字;
                    PrintLab.PTK_DrawTextTrueTypeW(100, 12, 26, 0, "Arial", 1, 300, false, false, false, "A1", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(110, 55, 0, "1", 2, 2, 22, 'B', strBarCode);
                    // 打印一行TrueTypeFont文字;
                    PrintLab.PTK_DrawTextTrueTypeW(480, 12, 26, 0, "Arial", 1, 300, false, false, false, "A2", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(490, 55, 0, "1", 2, 2, 22, 'B', strBarCode);
                    // 打印一行TrueTypeFont文字;
                    PrintLab.PTK_DrawTextTrueTypeW(860, 12, 26, 0, "Arial", 1, 300, false, false, false, "A3", "生产号: " + strProductOrder);
                    PrintLab.PTK_DrawBarcode(870, 55, 0, "1", 2, 2, 22, 'B', strBarCode);

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);
                }

                if (iRemain > 0)
                {
                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();

                    if (iRemain == 2)
                    {

                        // 打印一行TrueTypeFont文字;
                        PrintLab.PTK_DrawTextTrueTypeW(100, 12, 20, 0, "Arial", 1, 300, false, false, false, "A1", "生产号:" + strProductOrder);
                        PrintLab.PTK_DrawBarcode(110, 55, 0, "1", 2, 2, 22, 'B', strBarCode);
                        // 打印一行TrueTypeFont文字;
                        PrintLab.PTK_DrawTextTrueTypeW(480, 12, 20, 0, "Arial", 1, 300, false, false, false, "A2", "生产号:" + strProductOrder);
                        PrintLab.PTK_DrawBarcode(490, 55, 0, "1", 2, 2, 22, 'B', strBarCode);

                    }
                    else
                    {
                        // 打印一行TrueTypeFont文字;
                        PrintLab.PTK_DrawTextTrueTypeW(100, 12, 20, 0, "Arial", 1, 300, false, false, false, "A1", "生产号:" + strProductOrder);
                        PrintLab.PTK_DrawBarcode(110, 55, 0, "1", 2, 2, 22, 'B', strBarCode);
                    }

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);
                }
            }

            PrintLab.ClosePort();//关闭打印机端口
        }


        /// <summary>
        ///  服装包装信息打印
        /// </summary>
        public void packageOrderPrintManager(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(2);                  //设置打印速度
            PrintLab.PTK_SetDarkness(8);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(400, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);
            //清空缓冲区
            PrintLab.PTK_ClearBuffer();

            DataTable tbl = (DataTable)printObject;

            string strShopName = "";
            string strCustomerName = "";
            string strProductOrder = "";
            string strCustomerOrderNo = "";
            string strQrBarCode = "";
            string strMakeType = "";
            string strSmallBox = "";
            string strTailor = "";
            string strDestinationCode = "";
            string strHangerSize = "";
            string strShirtItem = "";
            string strHangtag = "";
            string strShopNumber = "";

            int iPx1 = 0;
            int iPx2 = 0;

            DataView dv = tbl.DefaultView;
            if (dv.Count > 0)
            {
                DataRowView dr = dv[0];

                strShopName = dr["QR_OTHER11"].ToString();
                strCustomerName = dr["QR_OTHER12"].ToString();
                strProductOrder = dr["QR_OTHER9"].ToString();
                strCustomerOrderNo = dr["QR_OTHER10"].ToString();
                strQrBarCode = "*" + dr["QR_BAR_CODE"].ToString() + "*";
                strMakeType = dr["QR_OTHER13"].ToString();
                strSmallBox = dr["QR_OTHER15"].ToString();
                strTailor = dr["QR_OTHER21"].ToString();
                strDestinationCode = dr["QR_OTHER22"].ToString();
                strHangerSize = dr["QR_OTHER23"].ToString();
                strShirtItem = dr["QR_OTHER24"].ToString();
                strHangtag = dr["QR_OTHER19"].ToString();
                strShopNumber = dr["QR_OTHER25"].ToString();

                if (!"".Equals(strHangerSize))
                    strHangerSize = "{" + strHangerSize + "}";

                if (strQrBarCode.Length == 8)
                {
                    iPx1 = 145;
                    iPx2 = 670 + 100;
                }
                else if (strQrBarCode.Length == 12)
                {
                    iPx1 = 90;
                    iPx2 = 670 + 40;
                }
                else if (strQrBarCode.Length == 13)
                {
                    iPx1 = 70;
                    iPx2 = 670 + 20;
                }
                else if (strQrBarCode.Length == 14)
                {
                    iPx1 = 130;
                    iPx2 = 670 + 80;
                }
                else
                {
                    iPx1 = 90;
                    iPx2 = 670 + 40;
                }

                if (strQrBarCode.Length < 14)
                {
                    PrintLab.PTK_DrawTextTrueTypeW(320, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A2", "" + strCustomerOrderNo);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A3", "" + strShopName + "," + strTailor);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 125, 32, 0, "Cambria", 5, 100, false, false, false, "A4", "" + strCustomerName);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 170, 36, 0, "Cambria", 5, 100, false, false, false, "A7", "" + strShopNumber);
                    PrintLab.PTK_DrawBarcode((uint)iPx1, 200, 0, "1", 3, 3, 35, 'N', strQrBarCode);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 270, 36, 0, "Cambria", 5, 100, false, false, false, "A5", "" + strDestinationCode + strHangerSize + "|[" + strMakeType + "]" + strShirtItem);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 305, 36, 0, "Cambria", 5, 100, false, false, false, "A6", "" + strHangtag);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 335, 38, 0, "Cambria", 5, 100, false, false, false, "A1", "" + strSmallBox);

                    PrintLab.PTK_DrawTextTrueTypeW(940, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A12", "" + strCustomerOrderNo);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A13", "" + strShopName + "," + strTailor);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 125, 32, 0, "Cambria", 5, 100, false, false, false, "A14", "" + strCustomerName);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 170, 36, 0, "Cambria", 5, 100, false, false, false, "A17", "" + strShopNumber);
                    PrintLab.PTK_DrawBarcode((uint)iPx2, 200, 0, "1", 3, 3, 35, 'N', strQrBarCode);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 270, 36, 0, "Cambria", 5, 100, false, false, false, "A15", "" + strDestinationCode + strHangerSize + "|[" + strMakeType + "]" + strShirtItem);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 305, 36, 0, "Cambria", 5, 100, false, false, false, "A16", "" + strHangtag);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 335, 38, 0, "Cambria", 5, 100, false, false, false, "A11", "" + strSmallBox);

                }
                else
                {
                    PrintLab.PTK_DrawTextTrueTypeW(320, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A2", "" + strCustomerOrderNo);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A3", "" + strShopName + "," + strTailor);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 125, 32, 0, "Cambria", 5, 100, false, false, false, "A4", "" + strCustomerName);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 170, 36, 0, "Cambria", 5, 100, false, false, false, "A7", "" + strShopNumber);
                    PrintLab.PTK_DrawBarcode((uint)iPx1, 200, 0, "1", 2, 3, 35, 'N', strQrBarCode);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 270, 36, 0, "Cambria", 5, 100, false, false, false, "A5", "" + strDestinationCode + strHangerSize + "|[" + strMakeType + "]" + strShirtItem);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 305, 36, 0, "Cambria", 5, 100, false, false, false, "A6", "" + strHangtag);
                    PrintLab.PTK_DrawTextTrueTypeW(320, 335, 38, 0, "Cambria", 5, 100, false, false, false, "A1", "" + strSmallBox);

                    PrintLab.PTK_DrawTextTrueTypeW(940, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A12", "" + strCustomerOrderNo);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A13", "" + strShopName + "," + strTailor);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 125, 32, 0, "Cambria", 5, 100, false, false, false, "A14", "" + strCustomerName);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 170, 36, 0, "Cambria", 5, 100, false, false, false, "A17", "" + strShopNumber);
                    PrintLab.PTK_DrawBarcode((uint)iPx2, 200, 0, "1", 2, 3, 35, 'N', strQrBarCode);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 270, 36, 0, "Cambria", 5, 100, false, false, false, "A15", "" + strDestinationCode + strHangerSize + "|[" + strMakeType + "]" + strShirtItem);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 305, 36, 0, "Cambria", 5, 100, false, false, false, "A16", "" + strHangtag);
                    PrintLab.PTK_DrawTextTrueTypeW(940, 335, 38, 0, "Cambria", 5, 100, false, false, false, "A11", "" + strSmallBox);
                }

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);

            }

            PrintLab.ClosePort();//关闭打印机端口
        }
        /// <summary>
        ///  春衫包装打印
        /// </summary>
        public void packageOrderPrintManagerForWechat(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(2);                  //设置打印速度
            PrintLab.PTK_SetDarkness(8);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(400, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);
            //清空缓冲区
            PrintLab.PTK_ClearBuffer();

            DataTable tbl = (DataTable)printObject;

            string countingNo = "";
            string orderNo = "";
            string customerName = "";
            string materialNo = "";
            string strCustomerOrderNo = "";
            string strQrBarCode = "";
            string strShopName = "";

            DataView dv = tbl.DefaultView;
            if (dv.Count > 0)
            {
                DataRowView dr = dv[0];

                countingNo = dr["QR_NAME"].ToString();
                orderNo = dr["QR_OTHER10"].ToString();
                customerName = dr["QR_OTHER12"].ToString();
                strCustomerOrderNo = dr["QR_OTHER10"].ToString();
                materialNo = dr["QR_OTHER4"].ToString();
                strQrBarCode = dr["QR_OTHER14"].ToString();
                strShopName = dr["QR_OTHER11"].ToString();

                PrintLab.PTK_DrawTextTrueTypeW(320, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A2", "" + countingNo);
                PrintLab.PTK_DrawTextTrueTypeW(320, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A3", "" + orderNo);
                PrintLab.PTK_DrawTextTrueTypeW(320, 135, 32, 0, "Cambria", 5, 100, false, false, false, "A4", "" + customerName);
                PrintLab.PTK_DrawTextTrueTypeW(320, 175, 32, 0, "Cambria", 5, 100, false, false, false, "A5", "" + materialNo);
                PrintLab.PTK_DrawBarcode(150, 250, 0, "1", 3, 3, 35, 'N', strQrBarCode);
                PrintLab.PTK_DrawTextTrueTypeW(320, 320, 32, 0, "Cambria", 5, 100, false, false, false, "A6", "" + strShopName);

                PrintLab.PTK_DrawTextTrueTypeW(940, 50, 40, 0, "Cambria", 5, 100, false, false, false, "A12", "" + countingNo);
                PrintLab.PTK_DrawTextTrueTypeW(940, 90, 32, 0, "Cambria", 5, 100, false, false, false, "A13", "" + orderNo);
                PrintLab.PTK_DrawTextTrueTypeW(940, 135, 32, 0, "Cambria", 5, 100, false, false, false, "A14", "" + customerName);
                PrintLab.PTK_DrawTextTrueTypeW(940, 175, 32, 0, "Cambria", 5, 100, false, false, false, "A15", "" + materialNo);
                PrintLab.PTK_DrawBarcode(770, 250, 0, "1", 3, 3, 35, 'N', strQrBarCode);
                PrintLab.PTK_DrawTextTrueTypeW(940, 320, 32, 0, "Cambria", 5, 100, false, false, false, "A16", "" + strShopName);

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);

            }

            PrintLab.ClosePort();//关闭打印机端口
        }

        /// <summary>
        ///  服装大箱号信息打印
        /// </summary>
        public void masterBoxPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(345, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);

            //清空缓冲区
            PrintLab.PTK_ClearBuffer();

            DataTable tbl = (DataTable)printObject;

            string strMasterCTN = "";
            string strSmallCTN = "";
            string strOrderNo = "";
            string strDestination = "";
            string strCountry = "";
            string strShopName = "";
            string strPackageStatus = "";
            string strPackageUser = "";
            string strPackageDate = "";

            foreach (DataRow dr in tbl.Rows)
            {

                strMasterCTN = dr["MasterCTN"].ToString();
                //strSmallCTN = dr["SmallCTN"].ToString();
                //strOrderNo = dr["OrderNo"].ToString();
                strDestination = dr["Destination"].ToString();
                //strCountry = dr["Country"].ToString();
                //strShopName = dr["ShopName"].ToString();
                //strPackageStatus = dr["PackageStatus"].ToString();
                //strPackageUser = dr["PackageUser"].ToString();
                //strPackageDate = dr["PackageDate"].ToString();

                if (!strMasterCTN.Equals(""))
                {
                    PrintLab.PTK_DrawTextTrueTypeW(50, 10, 50, 0, "Arial", 1, 100, false, false, false, "A1", "M.CTN NO : ");
                    PrintLab.PTK_DrawTextTrueTypeW(50, 70, 90, 0, "Arial", 1, 90, false, false, false, "A2", "" + strMasterCTN);
                    PrintLab.PTK_DrawTextTrueTypeW(50, 180, 48, 0, "Arial", 1, 300, false, false, false, "A3", "Destination : " + strDestination);
                    PrintLab.PTK_DrawBarcode(60, 250, 0, "1", 3, 3, 35, 'B', strMasterCTN);

                    PrintLab.PTK_DrawTextTrueTypeW(665, 10, 50, 0, "Arial", 1, 100, false, false, false, "A11", "M.CTN NO : ");
                    PrintLab.PTK_DrawTextTrueTypeW(665, 70, 90, 0, "Arial", 1, 90, false, false, false, "A12", "" + strMasterCTN);
                    PrintLab.PTK_DrawTextTrueTypeW(665, 180, 48, 0, "Arial", 1, 300, false, false, false, "A13", "Destination :  " + strDestination);
                    PrintLab.PTK_DrawBarcode(675, 250, 0, "1", 3, 3, 35, 'B', strMasterCTN);

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);

                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();

                    //Console.WriteLine(strMasterCTN + "///" + strDestination);
                }
            }

            //PrintLab.ClosePort();//关闭打印机端口
        }

        /// <summary>
        ///  服装小箱号信息打印
        /// </summary>
        public void smallBoxPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(345, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);
            //清空缓冲区
            PrintLab.PTK_ClearBuffer();

            DataTable tbl = (DataTable)printObject;

            string strMasterCTN = "";
            string strSmallCTN = "";
            string strOrderNo = "";
            string strDestination = "";
            string strCountry = "";
            string strShopName = "";
            string strPackageStatus = "";
            string strPackageUser = "";
            string strPackageDate = "";

            foreach (DataRow dr in tbl.Rows)
            {
                //Console.WriteLine(dr["SmallCTN"].ToString() + "///" + dr["Destination"].ToString() );


                //strMasterCTN = dr["MasterCTN"].ToString();
                strSmallCTN = dr["SmallCTN"].ToString();
                //strOrderNo = dr["OrderNo"].ToString();
                strDestination = dr["Destination"].ToString();
                //strCountry = dr["Country"].ToString();
                //strShopName = dr["ShopName"].ToString();
                //strPackageStatus = dr["PackageStatus"].ToString();
                //strPackageUser = dr["PackageUser"].ToString();
                //strPackageDate = dr["PackageDate"].ToString();

                if (!strSmallCTN.Equals(""))
                {
                    PrintLab.PTK_DrawTextTrueTypeW(50, 10, 50, 0, "Arial", 1, 100, false, false, false, "A1", "S.CTN NO : ");
                    PrintLab.PTK_DrawTextTrueTypeW(50, 80, 72, 0, "Arial", 1, 90, false, false, false, "A2", "" + strSmallCTN);
                    PrintLab.PTK_DrawTextTrueTypeW(50, 180, 48, 0, "Arial", 1, 300, false, false, false, "A3", "Destination : " + strDestination);
                    PrintLab.PTK_DrawBarcode(60, 250, 0, "1", 2, 2, 25, 'B', strSmallCTN);

                    PrintLab.PTK_DrawTextTrueTypeW(665, 10, 50, 0, "Arial", 1, 100, false, false, false, "A11", "S.CTN NO : ");
                    PrintLab.PTK_DrawTextTrueTypeW(665, 80, 72, 0, "Arial", 1, 90, false, false, false, "A12", "" + strSmallCTN);
                    PrintLab.PTK_DrawTextTrueTypeW(665, 180, 48, 0, "Arial", 1, 300, false, false, false, "A13", "Destination :  " + strDestination);
                    PrintLab.PTK_DrawBarcode(675, 250, 0, "1", 2, 2, 25, 'B', strSmallCTN);

                    // 命令打印机执行打印工作
                    PrintLab.PTK_PrintLabel(1, 1);

                    //清空缓冲区
                    PrintLab.PTK_ClearBuffer();
                }
            }

            PrintLab.ClosePort();//关闭打印机端口
        }


        /// <summary>
        ///  定制订单信息打印
        /// </summary>
        public void orderPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(172, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);

            DataTable tbl = (DataTable)printObject;
            DataView dv = tbl.DefaultView;
            // 获取总行数
            int rowcount = dv.Count;

            // int index = 1;
            for (int i = 0; i < rowcount; i++)
            {

                //清空缓冲区
                PrintLab.PTK_ClearBuffer();

                DataRowView dr = dv[i];

                string strQcID = dr["QR_ID"].ToString();
                // 条形码
                string strBarCode = dr["QR_BAR_CODE"].ToString();
                string strCutBarCode = "";
                if (strBarCode.Length > 7)
                {
                    strCutBarCode = strBarCode.Substring(strBarCode.Length - 7);
                }
                else
                {
                    strCutBarCode = strBarCode;
                }
                // 生产号
                string strProCode = dr["PRODUCTION_ORDER"].ToString();
                // 订单号
                string strOrderCode = dr["ORDER_NO"].ToString();
                // 面料号
                string strMarterialCode = dr["QR_OTHER4"].ToString();
                // 客户订单号
                strCutBarCode = dr["QR_NAME"].ToString();
                strCutBarCode = strCutBarCode.Replace(".", "") + "F";

                // 打印一行TrueTypeFont文字;
                PrintLab.PTK_DrawTextTrueTypeW(350, 15, 41, 0, "Arial", 1, 300, false, false, false, "A1", "合同号 ：" + strOrderCode);
                PrintLab.PTK_DrawTextTrueTypeW(350, 70, 36, 0, "Arial", 1, 100, false, false, false, "A2", "订单号 ：" + strCutBarCode);
                PrintLab.PTK_DrawBarcode(360, 120, 0, "1", 3, 3, 35, 'B', strBarCode);
                PrintLab.PTK_DrawTextTrueTypeW(350, 215, 36, 0, "Arial", 1, 100, false, false, false, "A3", "面料号 ：" + strMarterialCode);
                //PrintLab.PTK_DrawBarcode(360, 250, 0, "1", 2, 2, 30, 'B', strCutBarCode);

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);

            }

            PrintLab.ClosePort();//关闭打印机端口
        }

        /// <summary>
        ///  定制订单信息双排打印
        /// </summary>
        public void orderPrint2(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(345, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);


            DataTable tbl = (DataTable)printObject;
            DataView dv = tbl.DefaultView;
            // 获取总行数
            int rowcount = dv.Count;

            // int index = 1;
            for (int i = 0; i < rowcount; i++)
            {

                //清空缓冲区
                PrintLab.PTK_ClearBuffer();

                DataRowView dr = dv[i];

                string strQcID = dr["QR_ID"].ToString();
                // 条形码
                string strBarCode = dr["QR_BAR_CODE"].ToString();
                string strCutBarCode = "";
                if (strBarCode.Length > 7)
                {
                    strCutBarCode = strBarCode.Substring(strBarCode.Length - 7);
                }
                else
                {
                    strCutBarCode = strBarCode;
                }
                // 生产号
                string strProCode = dr["PRODUCTION_ORDER"].ToString();
                // 订单号
                string strOrderCode = dr["ORDER_NO"].ToString();
                // 面料号
                string strMarterialCode = dr["QR_OTHER4"].ToString();
                // 画矩形
                //PrintLab.PTK_DrawRectangle(22, 10, 0, 1200, 300);

                // 打印一行TrueTypeFont文字;
                PrintLab.PTK_DrawTextTrueTypeW(50, 10, 41, 0, "Arial", 1, 100, false, false, false, "A1", "生产号 ：" + strProCode);
                PrintLab.PTK_DrawTextTrueTypeW(50, 70, 36, 0, "Arial", 1, 90, false, false, false, "A2", "订单号 ：" + strOrderCode);
                PrintLab.PTK_DrawBarcode(50, 110, 0, "1", 3, 3, 35, 'B', strBarCode);
                PrintLab.PTK_DrawTextTrueTypeW(50, 180, 36, 0, "Arial", 1, 300, false, false, false, "A3", "面料号 ：" + strMarterialCode);
                PrintLab.PTK_DrawBarcode(60, 250, 0, "1", 3, 3, 35, 'B', strCutBarCode);

                PrintLab.PTK_DrawTextTrueTypeW(665, 10, 41, 0, "Arial", 1, 100, false, false, false, "A11", "生产号 ：" + strProCode);
                PrintLab.PTK_DrawTextTrueTypeW(665, 70, 36, 0, "Arial", 1, 90, false, false, false, "A12", "订单号 ：" + strOrderCode);
                PrintLab.PTK_DrawTextTrueTypeW(665, 180, 36, 0, "Arial", 1, 300, false, false, false, "A13", "面料号 ：" + strMarterialCode);
                PrintLab.PTK_DrawBarcode(675, 250, 0, "1", 3, 3, 35, 'B', strCutBarCode);

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);

            }

            PrintLab.ClosePort();//关闭打印机端口
        }


        /// <summary>
        ///  定制订单信息打印
        /// </summary>
        public void clothPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(172, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);

            DataTable tbl = (DataTable)printObject;
            DataView dv = tbl.DefaultView;
            // 获取总行数
            int rowcount = dv.Count;

            // int index = 1;
            for (int i = 0; i < rowcount; i++)
            {
                //清空缓冲区
                PrintLab.PTK_ClearBuffer();

                DataRowView dr = dv[i];

                string strQcID = dr["QR_ID"].ToString();
                // 条形码
                string strBarCode = dr["QR_BAR_CODE"].ToString();
                string strCutBarCode = "";
                if (strBarCode.Length > 7)
                {
                    strCutBarCode = strBarCode.Substring(strBarCode.Length - 7);
                }
                else
                {
                    strCutBarCode = strBarCode;
                }
                // 生产号
                string strProCode = dr["PRODUCTION_ORDER"].ToString();
                // 订单号
                string strOrderCode = dr["ORDER_NO"].ToString();
                // 面料号
                string strMarterialCode = dr["QR_OTHER4"].ToString();
                // 画矩形
                //PrintLab.PTK_DrawRectangle(22, 10, 0, 1200, 300);

                // 打印一行TrueTypeFont文字;
                PrintLab.PTK_DrawTextTrueTypeW(350, 50, 41, 0, "Arial", 1, 300, false, false, false, "A1", "生产号 ：" + strProCode);
                PrintLab.PTK_DrawTextTrueTypeW(350, 105, 36, 0, "Arial", 1, 100, false, false, false, "A2", "订单号 ：" + strOrderCode);
                PrintLab.PTK_DrawBarcode(360, 160, 0, "1", 2, 2, 30, 'B', strBarCode);
                //PrintLab.PTK_DrawTextTrueTypeW(350, 205, 36, 0, "Arial", 1, 100, false, false, false, "A3", "面料号:" + strMarterialCode);
                //PrintLab.PTK_DrawBarcode(360, 250, 0, "1", 3, 3, 35, 'B', strCutBarCode);

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);
                //updatePrint(strQcID);
            }

            PrintLab.ClosePort();//关闭打印机端口
        }

        /// <summary>
        ///  正常单裁 订扣 信息打印
        /// </summary>
        public void sbuPrint(object printObject)
        {
            PrintLab.OpenPort("POSTEK G-3106");             //打开打印机端口                                             
            PrintLab.PTK_SetPrintSpeed(4);                  //设置打印速度
            PrintLab.PTK_SetDarkness(10);                   //设置打印黑度
            PrintLab.PTK_SetLabelHeight(172, 15, 0, false); //设置标签的高度和定位间隙\黑线\穿孔的高度
            PrintLab.PTK_SetLabelWidth(1252);               //设置标签的宽度
            PrintLab.PTK_SetDarkness(0);
            // 清空缓冲区
            PrintLab.PTK_ClearBuffer();

            DataTable tbl = (DataTable)printObject;
            DataView dv = tbl.DefaultView;

            // 获取总行数
            int rowcount = dv.Count;
            // 条码ID
            string strQcID = "";

            for (int i = 0; i < rowcount; i++)
            {
                DataRowView dr = dv[i];
                strQcID = dr["QR_ID"].ToString();

                // 条形码
                string strBarCode = dr["QR_BAR_CODE"].ToString();
                // 生产号
                string strProNo = dr["PRODUCTION_ORDER"].ToString();
                // 大扣数
                string strSBU1 = dr["QR_OTHER2"].ToString();
                // 小扣数
                string strSBU2 = dr["QR_OTHER3"].ToString();
                // 扣
                string strSBU = dr["QR_OTHER4"].ToString();
                // 订扣
                string strSAT = dr["QR_OTHER5"].ToString();
                // 扣眼颜色
                string strSBT = dr["QR_OTHER6"].ToString();
                // 打印一行 左侧
                PrintLab.PTK_DrawTextTrueTypeW(350, 14, 40, 0, "Arial", 1, 41, false, false, false, "A1", "生产号   ：" + strProNo);
                PrintLab.PTK_DrawTextTrueTypeW(350, 55, 40, 0, "Arial", 1, 41, false, false, false, "A2", "大扣数   ：" + strSBU1);
                PrintLab.PTK_DrawTextTrueTypeW(350, 95, 40, 0, "Arial", 1, 41, false, false, false, "A3", "小扣数   ：" + strSBU2);
                PrintLab.PTK_DrawTextTrueTypeW(350, 135, 40, 0, "Arial", 1, 41, false, false, false, "A4", "扣　　　：" + strSBU);
                PrintLab.PTK_DrawTextTrueTypeW(350, 175, 40, 0, "Arial", 1, 41, false, false, false, "A5", "订扣　　：" + strSAT);
                PrintLab.PTK_DrawTextTrueTypeW(350, 225, 40, 0, "Arial", 1, 41, false, false, false, "A6", "订扣线颜色：" + strSBT);
                PrintLab.PTK_DrawBarcode(380, 280, 0, "1", 2, 2, 30, 'B', strBarCode);

                // 命令打印机执行打印工作
                PrintLab.PTK_PrintLabel(1, 1);

                // 清空缓冲区
                PrintLab.PTK_ClearBuffer();

                //updatePrint(strQcID);

            }

            // 命令打印机执行打印工作
            PrintLab.PTK_PrintLabel(1, 1);
            //updatePrint(strQcID);

            PrintLab.ClosePort();//关闭打印机端口
        }


        public class PrintLab
        {
            [DllImport("WINPSK.dll")]
            public static extern int OpenPort(string printname);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_SetPrintSpeed(uint px);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_SetDarkness(uint id);
            [DllImport("WINPSK.dll")]
            public static extern int ClosePort();
            [DllImport("WINPSK.dll")]
            public static extern int PTK_PrintLabel(uint number, uint cpnumber);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawTextTrueTypeW
                                                (int x, int y, int FHeight,
                                                int FWidth, string FType,
                                                int Fspin, int FWeight,
                                                bool FItalic, bool FUnline,
                                                bool FStrikeOut,
                                                string id_name,
                                                string data);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawBarcode(uint px,
                                            uint py,
                                            uint pdirec,
                                            string pCode,
                                            uint pHorizontal,
                                            uint pVertical,
                                            uint pbright,
                                            char ptext,
                                            string pstr);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_SetLabelHeight(uint lheight, uint gapH, int gapOffset, bool bFlag);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_SetLabelWidth(uint lwidth);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_ClearBuffer();
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawRectangle(uint px, uint py, uint thickness, uint pEx, uint pEy);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawLineOr(uint px, uint py, uint pLength, uint pH);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawBar2D_QR(uint x, uint y, uint w, uint v, uint o, uint r, uint m, uint g, uint s, string pstr);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawBar2D_Pdf417(uint x, uint y, uint w, uint v, uint s, uint c, uint px, uint py, uint r, uint l, uint t, uint o, string pstr);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_PcxGraphicsDel(string pid);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_PcxGraphicsDownload(string pcxname, string pcxpath);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawPcxGraphics(uint px, uint py, string gname);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_DrawText(uint px, uint py, uint pdirec, uint pFont, uint pHorizontal, uint pVertical, char ptext, string pstr);
            [DllImport("WINPSK.dll")]
            public static extern int PTK_CutPage(uint page);
            internal static void PTK_DrawText(int v1, int v2, int v3, int v4, string v5, int v6, int v7, bool v8, bool v9, bool v10, string v11, string v12)
            {
                throw new NotImplementedException();
            }
            [DllImport("WINPSK.dll")]
            public static extern int PTK_MediaDetect();
        }
    }

}
