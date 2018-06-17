using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ForumDAL;
using ForumModels;


namespace ForumBLL
{
    public class PostsCommentManager
    {
        PostsCommentService ms = new PostsCommentService();

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddPostsComment(PostsComment entity)
        {
            return ms.AddPostsComment(entity);
        }

        /// <summary>
        /// 获取该贴的所有评论
        /// </summary>
        /// <returns></returns>
        public DataSet GetPostsComment(int Pid)
        {
            return ms.GetPostsComment(Pid);
        }
    }
}
