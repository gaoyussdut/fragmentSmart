using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.model
{
    public class 裁剪条码打印Model
    {
        public 裁剪条码打印显示DTO 裁剪条码打印显示DTO { get; set; }
        public 裁剪条码打印Model(String BarCode)
        {
            try
            {
                this.裁剪条码打印显示DTO = new 裁剪条码打印显示DTO(BarCode);
            }
            catch
            {
                this.裁剪条码打印显示DTO = new 裁剪条码打印显示DTO();
            }
        }
    }
    public class 裁剪条码打印显示DTO
    {
        public String QR_ID { get; set; }
        public String QR_OTHER0 { get; set; }
        public String QR_OTHER9 { get; set; }
        public String QR_NAME { get; set; }
        public String QR_BAR_CODE { get; set; }
        public String QR_OTHER6 { get; set; }
        public 裁剪条码打印显示DTO(String BarCode)
        {
            DataRow dr = OrderService.Get裁剪条码信息(BarCode);
            this.QR_ID = dr["QR_ID"].ToString();
            this.QR_OTHER0 = dr["QR_OTHER0"].ToString();
            this.QR_OTHER9 = dr["QR_OTHER9"].ToString();
            this.QR_NAME = dr["QR_NAME"].ToString();
            this.QR_BAR_CODE = dr["QR_BAR_CODE"].ToString();
            this.QR_OTHER6 = dr["QR_OTHER6"].ToString();
        }
        public 裁剪条码打印显示DTO()
        {
            this.QR_ID = "";
            this.QR_OTHER0 = "";
            this.QR_OTHER9 = "";
            this.QR_NAME = "";
            this.QR_BAR_CODE = "";
            this.QR_OTHER6 = "";
        }
    }
    
}
