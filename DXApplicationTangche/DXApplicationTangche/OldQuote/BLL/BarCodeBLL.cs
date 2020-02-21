using DXApplicationTangche.OldQuote.DALFactory;
using DXApplicationTangche.OldQuote.IDAL;
using DXApplicationTangche.OldQuote.Model;
using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.BLL
{
    public class BarCodeBLL
    {
        private readonly IBarCodeDAL dal = AbstractFactory.CreateBarCodeDAL();

        public BarCodeBLL()
        { }

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long QR_ID)
        {
            return dal.Exists(QR_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BarCodeModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BarCodeModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long QR_ID)
        {
            return dal.Delete(QR_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string QR_IDlist)
        {
            return dal.DeleteList(Untils.PageValidate.SafeLongFilter(QR_IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BarCodeModel GetModel(long QR_ID)
        {
            return dal.GetModel(QR_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public BarCodeModel GetModelByCache(long QR_ID)
        {
            string CacheKey = "BarCodeBLLModel-" + QR_ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(QR_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Untils.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (BarCodeModel)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BarCodeModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BarCodeModel> DataTableToList(DataTable dt)
        {
            List<BarCodeModel> modelList = new List<BarCodeModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BarCodeModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public BarCodeModel GetModelByStr(string strwhere)
        {
            return dal.GetModelByStr(strwhere);
        }

        /// <summary>
        /// 根据条形码，查询a_bar_code_p表，得到一个对象实体
        /// </summary>
        public BarCodeModel GetModelByBarcodeNo(string barcodeNo)
        {
            return dal.GetModelByBarcodeNo(barcodeNo);
        }
        public BarCodeModel GetModelByBarcodeNoforWashPrint(string barcodeNo)
        {
            return dal.GetModelByBarcodeNoforWashPrint(barcodeNo);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }

}
