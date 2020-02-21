using DXApplicationTangche.IDAL;
using DXApplicationTangche.OldQuote.IDAL;
using DXApplicationTangche.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.OldQuote.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public static class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];



        #region CreateObject 
        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;// 记录错误日志
                return null;
            }

        }

        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region CreateSysManage
        public static ISysManage CreateSysManage()
        {
            //方式1			
            //return (.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (ISysManage)objType;
        }
        #endregion



        /// <summary>
        /// 创建条码数据层接口。
        /// </summary>
        public static IBarCodeDAL CreateBarCodeDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".BarCodeDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IBarCodeDAL)objType;
        }

        /// <summary>
        /// 创建订单数据层接口。
        /// </summary>
        public static IOrderDAL CreateOrderDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".OrderDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IOrderDAL)objType;
        }

        /// <summary>
        /// 创建箱单数据层接口。
        /// </summary>
        public static IPackageCustomDAL CreatePackageCustomDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".PackageCustomDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IPackageCustomDAL)objType;
        }

        /// <summary>
        /// 创建箱单明细数据层接口。
        /// </summary>
        public static IPackageCustomDetailsDAL CreatePackageCustomDetailsDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".PackageCustomDetailsDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IPackageCustomDetailsDAL)objType;
        }

        /// <summary>
        /// 款式工序明细数据层接口。
        /// </summary>
        public static IStyleOperatingDAL CreateStyleOperatingDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".StyleOperatingDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IStyleOperatingDAL)objType;
        }

        /// <summary>
        /// a_designoption_p数据层接口。
        /// </summary>
        public static IDesignOptionDAL CreateDesignOptionDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".DesignOptionDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDesignOptionDAL)objType;
        }

        /// <summary>
        /// 登录帐户数据层接口。
        /// </summary>
        public static ILoginUserDAL CreateLoginUserDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".LoginUserDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ILoginUserDAL)objType;
        }

        /// <summary>
        /// 生产工票信息详情数据层接口。
        /// </summary>
        public static IProductionItemDAL CreateProductionItemDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".ProductionItemDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IProductionItemDAL)objType;
        }
        /// <summary>
        /// 系统:  定制生产工序设置。
        /// </summary>
        public static IAOperatingDAL CreateAOperatingDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".AOperatingDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAOperatingDAL)objType;
        }
        /*
        /// <summary>
        /// Production
        /// </summary>
        public static IProductionDAL CreateProductionDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".ProductionDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IProductionDAL)objType;
        }
        /// <summary>
        /// s_style_material_s
        /// </summary>
        public static IStyleMaterialDAL CreateStyleMaterialDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".StyleMaterialDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IStyleMaterialDAL)objType;
        }

        /// <summary>
        /// f_accounting_p
        /// </summary>
        public static IAccountingDAL CreateAccountingDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".AccountingDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAccountingDAL)objType;
        }

        /// <summary>
        /// a_sys_area
        /// </summary>
        public static ISysAreaDAL CreateSysAreaDAL()
        {
            string ClassNamespace = "LS." + AssemblyPath + ".SysAreaDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISysAreaDAL)objType;
        }
        */

    }
}
