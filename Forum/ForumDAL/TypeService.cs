using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL
{
    public class TypeService
    {

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet GetTypes()
        {
            string sql = @"select * from Type";
            return DBHelper.GetDateSet(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 根据ID获取分类名称
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public DataSet GetNameById(int tid)
        {
            string sql = @"select * from Type where Id=" + tid;
            return DBHelper.GetDateSet(sql, CommandType.Text, null);
        }


        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddType(ForumModels.Type entity)
        {
            string sql = "insert into Type(Name,Description,CreateTime) values(@name,@desc,@time)";
            SqlParameter[] pars = new SqlParameter[] 
            { 
                new SqlParameter("@name", entity.Name),
                new SqlParameter("@desc", entity.Description),
                new SqlParameter("@time", DateTime.Now)
            };
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

        /// <summary>
        /// 修改方法信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateTypeInfo(ForumModels.Type entity)
        {
            string sql = string.Empty;
            SqlParameter[] pars = null;

            sql = "update Type set Name=@name,Description=@desc where ID=@id";
            pars = new SqlParameter[] 
                {
                        new SqlParameter("@name",entity.Name),           
                        new SqlParameter("@desc",entity.Description),
                        new SqlParameter("@id",entity.ID)
                };

            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, pars) > 0;
        }

        /// <summary>
        /// 通过贴子ID来删除分类
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool DelType(int typeId)
        {
            string sql = "DELETE FROM [Type] WHERE ID=" + typeId.ToString() + ";";
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text) > 0;
        }
    }
}
