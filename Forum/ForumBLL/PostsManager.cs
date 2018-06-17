using ForumDAL;
using ForumModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ForumBLL
{
    public class PostsManager
    {
        PostsService mss = new PostsService();
        /// <summary>
        /// 获取所有论坛的内容
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPosts()
        {
            return mss.GetAllPosts();
        }

        /// <summary>
        /// 能过贴子ID来删贴
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool DelPost(int postId)
        {
            return mss.DelPost(postId);
        }

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddPosts(Posts entity)
        {
            return mss.AddPosts(entity);
        }

        public DataTable GetPageData(string keywords, string tid, int pageIndex, int pageSize, out int recordsCount)
        {
            string where = "1=1";
            if (!string.IsNullOrEmpty(tid)) { where += " AND TypeId=" + int.Parse(tid); }
            if (!string.IsNullOrEmpty(keywords)) where += " AND Subject LIKE '%" + keywords.Replace("'", "''") + "%'";
            PagerProc pp = new PagerProc()
            {
                fields = "Id,Subject,Contents,AppTime,(SELECT Name FROM [UserInfo] WHERE UserId=FromId) AS FromName",
                order = "Id DESC",
                pageIndex = pageIndex,
                pageSize = pageSize,
                tables = "Posts",
                uniqueField = "Id",
                uniqueFieldType = "int",
                where = where,
                group = string.Empty
            };
            var dt = pp.ToDataSet().Tables[0];
            recordsCount = pp.recordsCount;
            return dt;
        }

        public DataTable GetPageData(int uid, int pageIndex, int pageSize, out int recordsCount)
        {
            string where = "1=1";
            where += " AND Id in (Select PostsId from Collection where UserID=" + uid + ")";
            PagerProc pp = new PagerProc()
            {
                fields = "Id,Subject,Contents,AppTime,(SELECT Name FROM [UserInfo] WHERE UserId=FromId) AS FromName",
                order = "Id DESC",
                pageIndex = pageIndex,
                pageSize = pageSize,
                tables = "Posts",
                uniqueField = "Id",
                uniqueFieldType = "int",
                where = where,
                group = string.Empty
            };
            var dt = pp.ToDataSet().Tables[0];
            recordsCount = pp.recordsCount;
            return dt;
        }
        /// <summary>
        /// 根据ID获得实体信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetPostsByID(int ID)
        {
            return mss.GetPostsByID(ID);
        }


        /// <summary>
        /// 根据分类ID搜索
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int GetPostsByTypeID(int tId)
        {
            return mss.GetPostsByTypeID(tId);
        }
    }
}
