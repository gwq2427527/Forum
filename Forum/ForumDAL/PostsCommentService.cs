using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ForumModels;
using System.Data.SqlClient;

namespace ForumDAL
{
    public class PostsCommentService
    {

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddPostsComment(PostsComment entity)
        {
            string sql = "insert into PostsComment(UserId,PostsId,Conent,CreateTime) values(@uid,@pid,@conent,@time)";
            SqlParameter[] pars = new SqlParameter[] 
            { 
                new SqlParameter("@uid", entity.UserID),
                new SqlParameter("@pid", entity.PostsId),
                new SqlParameter("@conent", entity.Conent),
                new SqlParameter("@time", entity.CreateTime)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

       
        /// <summary>
        /// 获取该贴的所有评论
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostsComment(int Pid)
        {
            string sql = @"select pc.Id,ui.UserID,pc.PostsId,pc.Conent,pc.CreateTime,ui.Name from PostsComment pc 
inner join UserInfo ui on  ui.UserID = pc.UserId
where pc.PostsId = " + Pid + " Order by pc.CreateTime";
            return DBHelper.GetDateSet(sql, CommandType.Text, null);
        }
    }
}

