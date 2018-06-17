using ForumModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL
{
    public class CollectionService
    {

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddCollection(Collection entity)
        {
            string sql = "insert into Collection(UserId,PostsId,CreateTime) values(@uid,@pid,@time)";
            SqlParameter[] pars = new SqlParameter[] 
            { 
                new SqlParameter("@uid", entity.UserID),
                new SqlParameter("@pid", entity.PostsId),
                new SqlParameter("@time", entity.CreateTime)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

        /// <summary>
        /// 判断这个人是否收藏该贴
        /// </summary>
        /// <returns></returns>
        public bool IsCollection(int uid, int pid)
        {
            string sql = "select count(*) as count from Collection where UserId=@uid and PostsId=@pid";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@uid",uid),
            new SqlParameter("@pid",pid)
            };
            return Convert.ToInt32(DBHelper.GetDateSet(sql, CommandType.Text, pars).Tables[0].Rows[0]["count"]) > 0;
        }


        /// <summary>
        /// 删除个人收藏贴
        /// </summary>
        /// <returns></returns>
        public bool DeleteCollection(int uid, int pid)
        {
            string sql = "Delete Collection  where UserId=@uid and PostsId=@pid";
            SqlParameter[] pars = new SqlParameter[] {
            new SqlParameter("@uid",uid),
            new SqlParameter("@pid",pid)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

    }
}
