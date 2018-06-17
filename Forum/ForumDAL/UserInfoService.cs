using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ForumModels;

namespace ForumDAL
{
    public class UserInfoService
    {

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public bool AddUserInfo(UserInfo entity)
        //{
        //    return true;
        //}

        public bool CheckUserName(string userName)
        {
            var obj = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM UserInfo WHERE Name='" + userName.Replace("'", "''") + "'", CommandType.Text);
            if (obj == null || obj == DBNull.Value) return false;
            return Convert.ToInt32(obj) > 0;
        }

        /// <summary>
        /// 修改方法信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfo entity, bool isUpdatePwd)
        {
            string sql = string.Empty;
            SqlParameter[] pars = null;
            if (isUpdatePwd)
            {
                sql = "update UserInfo set Pwd=@Pwd where UserID=@id";
                pars = new SqlParameter[] 
                {
                        new SqlParameter("@Pwd",entity.Pwd),           
                        new SqlParameter("@id",entity.UserID)
                };
            }
            else
            {
                sql = "update UserInfo set Sex=@sex,Birthday=@day,Star=@star,Email=@Email,Career=@gar,Company=@com,Address=@add where UserID=@id";
                pars = new SqlParameter[]
                {
                       new SqlParameter("@sex",entity.Sex),
                       new SqlParameter("@day",entity.Birthday),
                       new SqlParameter("@star",entity.Star),
                       new SqlParameter("@Email",entity.Email),
                       new SqlParameter("@gar",entity.Career),
                       new SqlParameter("@com",entity.Company),
                       new SqlParameter("@add",entity.Address),
                       new SqlParameter("@id",entity.UserID)
                };
            }
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

        /// <summary>
        /// 修改图像
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateImg(string imgName)
        {
            string sql = "update UserInfo set Img=@img where UserID=@qq";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@img",imgName),
            new SqlParameter("@qq",2)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetUserInfoByID(int ID)
        {
            string sql = @"select * from UserInfo where UserID=@id";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@id",ID)
            };
            return DBHelper.GetDateSet(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据ID获得实体信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetUserInfoByID(string name, string pwd)
        {
            string sql = "select * from UserInfo where Name=@name and Pwd=@pwd";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@name",name),
             new SqlParameter("@pwd",pwd)
            };
            return DBHelper.GetDateSet(sql, CommandType.Text, pars).Tables[0];
        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfo(string name)
        {
            string sql = "select * from UserInfo where Name=@name";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@name",name)
            };
            return DBHelper.GetDateSet(sql, CommandType.Text, pars).Tables[0];
        }


        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfo entity)
        {
            string sql = "insert into UserInfo(Name,Pwd,NickName,Sex,Birthday,Star,Email,Career,Company,Address,Img,Role) values(@Name,@Pwd,@NickName,@Sex,@Birthday,@Star,@Email,@Career,@Company,@Address,@Img,@Role)";
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Pwd", entity.Pwd),
                new SqlParameter("@NickName", entity.NickName),
                new SqlParameter("@Sex", entity.Sex),
                new SqlParameter("@Birthday", entity.Birthday),
                new SqlParameter("@Star", entity.Star),
                new SqlParameter("@Email", entity.Email),
                new SqlParameter("@Career", entity.Career),
                new SqlParameter("@Company", entity.Company),
                new SqlParameter("@Address", entity.Address),
                new SqlParameter("@Img", entity.Img),
                new SqlParameter("@Role", entity.Role)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }
    }
}

