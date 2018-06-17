using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ForumDAL
{
    public class DBHelper
    {
        #region  数据库连接字符串
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        #endregion

        #region  查询的方法
        /// <summary>
        /// 查询的方法
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="commandType">执行语句的类型</param>
        /// <param name="pars">参数列表</param>
        /// <returns>DataSet集</returns>
        public static DataSet GetDateSet(string sql, CommandType commandText, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                DataSet ds = null;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = commandText;
                cmd.CommandText = sql;
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
        }
        #endregion

        #region 执行增加返回的增加序号
        /// <summary>
        /// 执行增加返回的增加序号
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="commandType">执行语句的类型</param>
        /// <param name="pars">参数列表</param>
        /// <returns>DataSet集</returns>
        public static object ExecuteScalar(string sql, CommandType commandText, params SqlParameter[] pars)
        {
            object obj = null;
            using (SqlConnection conn = new SqlConnection(DBHelper.conString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                comm.CommandType = commandText;
                if (pars != null)
                {
                    comm.Parameters.AddRange(pars);
                }
                 
                try
                {
                    conn.Open();
                    obj = (comm.ExecuteScalar());
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
                return obj;
            }
        }
        #endregion

        #region  执行增删改操作
        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="commandText">要实现的sql语句或者存储过程名字</param>
        /// <param name="commandType">命令的类型，sql语句还是存储过程</param>
        /// <param name="pars">参数列表</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.conString))
            {
                SqlCommand comm = new SqlCommand();
                int count = 0;
                try
                {
                    comm.Connection = conn;
                    comm.CommandText = commandText;
                    comm.CommandType = commandType;
                    if (pars != null)
                    {
                        comm.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    count = comm.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
                return count;
            }
        }

        #endregion

        #region  用事物执行增删改操作
        public static int ExecuteNonQueryTran(string commandText, CommandType commandType, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.conString))
            {
                SqlCommand comm = new SqlCommand();
                int count = 0;
                SqlTransaction t = null;
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    t = conn.BeginTransaction();
                    comm.Transaction = t;
                    comm.CommandText = commandText;
                    comm.CommandType = commandType;
                    if (pars != null)
                    {
                        comm.Parameters.AddRange(pars);
                    }
                    count = comm.ExecuteNonQuery();
                    t.Commit();
                    
                }
                catch (SqlException e)
                {
                    t.Rollback();
                    throw e;
                }
                catch (Exception e)
                {
                    t.Rollback();
                    throw e;
                }
                return count;
            }
        }
        #endregion
    }
}
