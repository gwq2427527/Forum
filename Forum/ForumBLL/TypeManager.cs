using ForumDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumBLL
{
    public class TypeManager
    {

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<ForumModels.Type> GetTyps()
        {
            List<ForumModels.Type> list = new List<ForumModels.Type>();
            DataSet ds = new TypeService().GetTypes();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ForumModels.Type entity = new ForumModels.Type()
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            CreateTime = DateTime.Parse(dr["CreateTime"].ToString())
                        };
                        list.Add(entity);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取分类名称
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public ForumModels.Type GetNameById(int tid)
        {
            DataSet ds = new TypeService().GetNameById(tid);
            ForumModels.Type entity = null;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        entity = new ForumModels.Type()
                       {
                           ID = int.Parse(dr["ID"].ToString()),
                           Name = dr["Name"].ToString(),
                           Description = dr["Description"].ToString(),
                           CreateTime = DateTime.Parse(dr["CreateTime"].ToString())
                       };
                    }
                }
            }
            return entity;
        }


        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddType(ForumModels.Type entity)
        {
            return new TypeService().AddType(entity);
        }

        /// <summary>
        /// 修改方法信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateTypeInfo(ForumModels.Type entity)
        {
            return new TypeService().UpdateTypeInfo(entity);
        }

         /// <summary>
        /// 通过贴子ID来删除分类
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool DelType(int typeId)
        {
            return new TypeService().DelType(typeId);
        }
    }
}
