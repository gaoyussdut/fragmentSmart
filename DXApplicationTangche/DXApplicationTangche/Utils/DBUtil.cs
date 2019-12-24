//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using MySql.Data.MySqlClient;
//using System.Data;
//using System.Text;
//namespace Learn
//{
//    public class DBUtil
//    {
//        //public static string ConnStr = "server=localhost;port=3306;user id=root;password=liyue@;database=text01;charset=utf8";
//        public static DataTable GetDataTable(string SQL)
//        {
//            DataTable ADt = new DataTable();
//            MySqlConnection AConn = new MySqlConnection(ConnStr);
//            try
//            {
//                MySqlDataAdapter ADp = new MySqlDataAdapter(SQL, AConn);
//                ADp.Fill(ADt);
//            }
//            catch
//            {
//                ;
//            }
//            finally
//            {
//                AConn.Close();
//                AConn.Dispose();
//                AConn = null;
//            }
//            return ADt;
//        }
//        public static DataRow GetDataRow(string SQL)
//        {
//            DataRow ARow = null;
//            DataTable ADt = GetDataTable(SQL);
//            try
//            {
//                if (ADt.Rows.Count > 0) ARow = ADt.Rows[0];
//            }
//            finally
//            {
//                ADt.Dispose();
//                ADt = null;
//            }
//            return ARow;
//        }     /// <summary>
//              /// 执行 Insert Delete Update
//              /// </summary>
//              /// <param name="SQL">SQL语句</param>
//              /// <param name="AParaNames">参数名数组</param>
//              /// <param name="AParaValues">参数值数组</param> 
//              /// <returns>成功-1;失败-0</returns>
//        public static int DoExecute(string SQL, string[] AParaNames, object[] AParaValues)
//        {
//            if (AParaNames != null)
//            {
//                if (AParaNames.Length != AParaValues.Length)
//                {
//                    return 0;
//                }
//            }
//            int Ares = 0;
//            MySqlConnection AConn = new MySqlConnection(ConnStr);
//            MySqlCommand Acmd = new MySqlCommand(SQL, AConn);
//            Acmd.Parameters.Clear();
//            Acmd.CommandText = SQL;
//            try
//            {
//                if (AParaNames != null)
//                {
//                    for (int i = 0; i < AParaNames.Length; i++)
//                    {
//                        MySqlParameter Ap = null;
//                        if (AParaValues[i] != null)
//                        {
//                            Ap = new MySqlParameter(AParaNames[i], AParaValues[i]);
//                        }
//                        else
//                        {
//                            if (AParaNames[i].ToUpper().Contains("F_SYMBOL"))
//                            {
//                                Ap = new MySqlParameter(AParaNames[i], SqlDbType.Image);
//                                Ap.Value = DBNull.Value;
//                            }
//                            else if (AParaNames[i].ToUpper().Contains("F_PHOTO"))
//                            {
//                                Ap = new MySqlParameter(AParaNames[i], SqlDbType.Image);
//                                Ap.Value = DBNull.Value;
//                            }
//                            else
//                            {
//                                Ap = new MySqlParameter(AParaNames[i], DBNull.Value);
//                            }
//                        }
//                        Acmd.Parameters.Add(Ap);
//                    }
//                }
//                AConn.Open();
//                Acmd.ExecuteNonQuery();
//                Ares = 1;
//            }
//            catch (Exception err)
//            {
//                ;
//            }
//            finally
//            {
//                AConn.Close();
//                Acmd.Dispose();
//            }
//            return Ares;
//        }     /// <summary>
//              /// 执行Insert
//              /// </summary>
//              /// <param name="ATable"></param> 
//              /// <param name="AFields"></param> 
//              /// <param name="AValues"></param>
//              /// <returns></returns> 
//        public static int DoInsert(string ATable, string[] AFields, object[] AValues)
//        {
//            string SQL = "Insert into " + ATable + "(";
//            for (int i = 0; i < AFields.Length; i++)
//            {
//                SQL += AFields[i] + " ,";
//            }
//            SQL = SQL.Substring(0, SQL.Length - 1) + ") values (";
//            string[] APs = new string[AFields.Length];
//            for (int i = 0; i < AFields.Length; i++)
//            {
//                APs[i] = "@AP_" + AFields[i];
//                SQL += APs[i] + " ,";
//            }
//            SQL = SQL.Substring(0, SQL.Length - 1) + ") ";
//            return DoExecute(SQL, APs, AValues);
//        }
//        /// <summary>
//        /// 更新数据表 
//        /// </summary>
//        /// <param name="ATable"></param>
//        /// <param name="AFields"></param>
//        /// <param name="AValues"></param> 
//        /// <param name="ACondFields"></param> 
//        /// <param name="ACondValues"></param>
//        /// <returns></returns>  
//        public static int DoUpdate(string ATable, string[] AFields, object[] AValues, string[] ACondFields, object[] ACondValues)
//        {
//            string[] APs = new string[AFields.Length + ACondFields.Length];
//            object[] AVs = new object[AValues.Length + ACondValues.Length];
//            string SQL = "Update " + ATable + " Set ";
//            for (int i = 0; i < AFields.Length; i++)
//            {
//                APs[i] = "@AF_" + AFields[i];
//                AVs[i] = AValues[i];
//                SQL += AFields[i] + " =" + APs[i] + " ,";
//            }
//            SQL = SQL.Substring(0, SQL.Length - 1);
//            if (ACondValues != null)
//            {
//                SQL += " where (1>0) ";
//                for (int i = 0; i < ACondFields.Length; i++)
//                {
//                    APs[i + AFields.Length] = "@AP_" + ACondFields[i];
//                    AVs[i + AFields.Length] = ACondValues[i];
//                    SQL += " and " + ACondFields[i] + " =" + APs[i + AFields.Length];
//                }
//            }
//            return DoExecute(SQL, APs, AVs);
//        }
//        public static int DoDelete(string ATable, string[] ACondFields, object[] ACondValues)
//        {
//            string[] APs = new string[ACondFields.Length];
//            object[] AVs = new object[ACondValues.Length];
//            string SQL = "Delete From  " + ATable + "  ";
//            if (ACondValues != null)
//            {
//                SQL += " where (1>0) ";
//                for (int i = 0; i < ACondFields.Length; i++)
//                {
//                    APs[i] = "@AP_" + ACondFields[i];
//                    AVs[i] = ACondValues[i];
//                    SQL += " and " + ACondFields[i] + " =" + APs[i];
//                }
//            }
//            return DoExecute(SQL, APs, AVs);
//        }
//    }
//}


using Npgsql;
using System;
using System.Configuration;
using System.Data;


namespace WindowsFormsApp1
{
    class DBUtil
    {
        //public static string ConnectionString = "Server=172.16.0.91;Port=5432;User Id=fp;Password=fp@123;Database=xindian0624;";
        public static string ConnectionString = "Server=101.71.4.181;Port=15333;User Id=fp;Password=fp@123;Database=test;";
        //public static string ConnectionString = "Server=10.220.184.24;Port=5432;User Id=postgres;Password=123456;Database=postgres;";
        /// <summary>  
        /// 执行SQL语句  
        /// </summary>  
        /// <param name="sql">SQL</param>  
        /// <returns>成功返回大于0的数字</returns>  
        public static int ExecuteSQL(string sql)
        {
            int num2 = -1;
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        num2 = command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (NpgsqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return num2;
        }

        //带参数的执行查询，不返回结果，返回影响行数
        //执行SQL语句并返回受影响的行数
        public static int ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //foreach (SqlParameter param in parameters)
                    //{
                    //    cmd.Parameters.Add(param);
                    //}
                    cmd.Parameters.AddRange(parameters);
                    conn.Close();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
        public static object ExecuteScalar(string sql, params NpgsqlParameter[] parameters)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();

                }
            }
        }

        //查询并返回结果集DataTable,一般只用来执行查询结果比较少的sql。
        public static DataTable ExecuteDataTable(string sql, params NpgsqlParameter[] parameters)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        return dataset.Tables[0];
                    }
                    catch (NpgsqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            //查询较大的数据用 DateRead()，但应尽可能用分页数据，仍然用datatable更好。
        }

    }
}