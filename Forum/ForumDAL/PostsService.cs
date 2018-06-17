using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ForumModels;

namespace ForumDAL
{
    public class PostsService
    {
        /// <summary>
        /// 通过贴子ID来删除贴子
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool DelPost(int postId)
        {
            string sql = "DELETE FROM [Posts] WHERE Id=" + postId.ToString() + ";";
            sql += "DELETE FROM [PostsComment] WHERE PostsId=" + postId.ToString();
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPosts()
        {
            string sql = @"select p.Id,p.TypeId,p.Subject,ui.UserID,p.Contents,p.CommentNum,p.AppTime,ui.Name from Posts p 
left join UserInfo ui on  ui.UserID = p.FromId";
            return DBHelper.GetDateSet(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 根据ID获得实体信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetPostsByID(int ID)
        {
            string sql = @"select * from Posts
where Id = " + ID;
            return DBHelper.GetDateSet(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 根据分类ID搜索
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int GetPostsByTypeID(int tId)
        {
            int count = 0;
            string sql = @"select count(*) as count from Posts
where TypeId = " + tId;
            DataSet ds = DBHelper.GetDateSet(sql, CommandType.Text, null);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    count = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                }
            }
            return count;
        }

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddPosts(Posts entity)
        {
            string sql = "insert into Posts(TypeId,FromId,Subject,Contents,CommentNum,AppTime) values(@tid,@fid,@subject,@content,@num,@time)";
            SqlParameter[] pars = new SqlParameter[] 
            { 
                new SqlParameter("@tid", entity.TypeId),
                new SqlParameter("@fid", entity.FromId),
                new SqlParameter("@subject", entity.Subject),
                new SqlParameter("@content", entity.Contents),
                new SqlParameter("@num", entity.CommentNum),
                new SqlParameter("@time", entity.AppTime)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }
    }
}

